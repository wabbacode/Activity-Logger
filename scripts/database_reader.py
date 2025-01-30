import sys
import sqlite3

brLine = "\n\n-------------------------------------------------------"
dbFOLDER = "database\\"
dbNAME = sys.argv[1] + ".db"

conn = sqlite3.connect(dbFOLDER + dbNAME)
cursor = sqlite3.Cursor(conn)

cursor.execute("""
CREATE TABLE IF NOT EXISTS Activities (
    id INTEGER PRIMARY KEY AUTOINCREMENT,
    day TEXT NOT NULL,
    starttime TEXT NOT NULL,
    endtime TEXT NOT NULL,
    duration TEXT NOT NULL,    
    notes TEXT NOT NULL,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
)
""")

print("(1, DAY, START-TIME, END-TIME, DURATION, NOTES, UPDATE-TIME)")
table = cursor.fetchall()
print("\n")
cursor.execute("SELECT * FROM Activities")
rows = cursor.fetchall()  
for row in rows:
    print(row)
print("\n")
