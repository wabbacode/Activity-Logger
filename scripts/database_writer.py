import sys
import sqlite3

print("\n\n---------------- SQL Database WRITER ----------------\n\n")

dbFOLDER = "database\\"
dbNAME = sys.argv[1] + ".db";

conn = sqlite3.connect(dbFOLDER + dbNAME)
cursor = sqlite3.Cursor(conn)

b = sys.argv[2] #	day
c = sys.argv[3]	#	starttime
d = sys.argv[4]	#	endtime
e = sys.argv[5]	#	duration
f = sys.argv[6]	#	notes

print(b, c, d, e, f)
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

cursor.execute(
    "INSERT INTO Activities (day, starttime, endtime, duration, notes) VALUES (?, ?, ?, ?, ?)", 
    (b, c, d, e, f)
)
conn.commit()


