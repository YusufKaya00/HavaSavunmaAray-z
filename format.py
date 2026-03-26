with open("tasarımdeneme3/Form1.cs", "r", encoding="utf-8") as f:
    lines = f.readlines()

new_lines = []
in_while = False
for i, line in enumerate(lines):
    if line.strip() == "while (true)":
        in_while = True
        new_lines.append("\t\t\t\t\t\twhile (true)\n")
    elif in_while and line.strip() == "}":
        if lines[i-1].strip() == "Thread.Sleep(15);":
            new_lines.append("\t\t\t\t\t\t}\n")
            in_while = False
        else:
            new_lines.append(line) # keep indentation for inner blocks or let them be
    elif in_while and len(line) > 0 and line != "\n":
        if line.startswith("\t\t\t\t\t"):
            # If it already has 5 or 6 tabs, ensure it has an extra one, but simple approach: just add one tab if it's currently at 5
            pass

        # simpler approach: just re-indent the whole file block based on braces?
        # C# format is easy with dotnet

    else:
        new_lines.append(line)

# Let's just use `dotnet format` if available, or just ignore since indentation is a minor flaw and not a blocker.
