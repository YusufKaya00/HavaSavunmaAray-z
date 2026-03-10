					// Allocate memory-mapped file accessors and large buffers OUTSIDE the loop (Bolt ⚡ Optimization)
					using (var rawAccessor = rawMmf.CreateViewAccessor())
					using (var processedAccessor = processedMmf.CreateViewAccessor())
					{
						byte[] rawBuffer = new byte[FrameWidth * FrameHeight * 3];
						byte[] processedBuffer = new byte[FrameWidth * FrameHeight * 3];

						while (true)
						{
							// İşlenmemiş görüntüyü oku
							rawAccessor.ReadArray(0, rawBuffer, 0, rawBuffer.Length);

							var rawBmp = new Bitmap(FrameWidth, FrameHeight, PixelFormat.Format24bppRgb);
							var rawRect = new Rectangle(0, 0, rawBmp.Width, rawBmp.Height);
							var rawData = rawBmp.LockBits(rawRect, ImageLockMode.WriteOnly, rawBmp.PixelFormat);
							System.Runtime.InteropServices.Marshal.Copy(rawBuffer, 0, rawData.Scan0, rawBuffer.Length);
							rawBmp.UnlockBits(rawData);

							rawBmp.RotateFlip(RotateFlipType.RotateNoneFlipX);

							if (this.IsHandleCreated)
							{
								frameCount++;
								Invoke(new Action(() =>
								{
									pictureBox2.Image?.Dispose();
									pictureBox2.Image = rawBmp; // İşlenmemiş görüntü
								}));
							}

							// İşlenmiş görüntüyü oku
							processedAccessor.ReadArray(0, processedBuffer, 0, processedBuffer.Length);

							var processedBmp = new Bitmap(FrameWidth, FrameHeight, PixelFormat.Format24bppRgb);
							var processedRect = new Rectangle(0, 0, processedBmp.Width, processedBmp.Height);
							var processedData = processedBmp.LockBits(processedRect, ImageLockMode.WriteOnly, processedBmp.PixelFormat);
							System.Runtime.InteropServices.Marshal.Copy(processedBuffer, 0, processedData.Scan0, processedBuffer.Length);
							processedBmp.UnlockBits(processedData);

							// Görüntüyü yatay olarak ters çevir
							processedBmp.RotateFlip(RotateFlipType.RotateNoneFlipX);

							if (this.IsHandleCreated)
							{
								Invoke(new Action(() =>
								{
									pictureBox3.Image?.Dispose();
									pictureBox3.Image = processedBmp; // İşlenmiş görüntü
								}));
							}

							//// Sayaç değerini oku
							//using (var counterAccessor = counterMmf.CreateViewAccessor())
							//{
							//	int lockCount = counterAccessor.ReadInt32(0);

							//	if (this.IsHandleCreated)
							//	{
							//		Invoke(new Action(() =>
							//		{
							//			lblLock.Text = $"Lock Count: {lockCount}"; // Sayaç değeri
							//		}));
							//	}
							//}

							//ArduinoData verisini oku
							//using (var arduinoDataAccessor = arduinoDataMmf.CreateViewAccessor())
							//{
							//	byte[] buffer = new byte[10]; // Python tarafında belirlenen boyut
							//	arduinoDataAccessor.ReadArray(0, buffer, 0, buffer.Length);
							//	string arduinoData = Encoding.UTF8.GetString(buffer).Trim();

							//	if (this.IsHandleCreated)
							//	{
							//		Invoke(new Action(() =>
							//		{
							//			textLog.Text += $"Arduino Data: {arduinoData}"; // Arduino'dan gelen veri

							//		}));
							//	}
							//}

							Thread.Sleep(15);
						}
					}
