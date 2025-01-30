# Visual Header
brLine = "-------------------------------------------------------"
print("\n\n")
print(brLine)
print("----------------  READ  SQL  DATABASE  ----------------")
print(brLine)

def writeHeader(dbNAME):
    spaces = ""
    for c in range(len(dbNAME), 20):
        spaces = spaces + " ";
    print(brLine)
    print("---------------- SQL Database READ DB  ----------------")
    print("----------------",dbNAME, spaces,"----------------")
    print(brLine,"\n\n")

import os
try:
    configFile = "activities.lst";
    with open(configFile, "r") as f:
        data = f.read().split("\n")

    for line in data[1:]:
        writeHeader(line)
        os.system(f"python3 database_reader.py {line}")

except Exception as e:
    print(e)

input("...")