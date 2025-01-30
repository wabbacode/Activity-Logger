# Activity-Logger
Simple Windows Application (C#, Python and SQLite3) that tracks time spent on activities.

Overview
ActivityLog 1.0 is a Windows Forms application that allows users to log and track activities along with timestamps. It integrates with a Python script (database_writer.py) to store logged activities in *.db files.

Features
 - Select activity from a predefined list (activities.lst)
 - Start and stop activity tracking with timestamps
 - Save activity logs via an external Python script

Requirements
  .NET Framework and 
  Python 3.x

Installation & Setup
	
  1. Ensure Python 3.x is installed.
  2. Modify pypath.config to include the full path to the Python executable.
  3. Create a folder named `database` in the application directory.
  4. Place the required files (database_writer.py, activities.lst, pypath.config) in the same directory as the application.
  5. Run the application.

## File Structure  
- `ActivityLog_1.0.exe` → Main application  
- `database_writer.py` → Python script for database updates  
- `activities.lst` → List of predefined activities  
- `pypath.config` → Contains the path to the Python executable  
```
/Activity-Logger
│
└── /bin                        
    ├── /database               # !! Create this Folder manually !!
    │   ├── WORK.db             # SQLite3 Databases
    │   └── STUDYDING.db        
    ├── Activity-Logger.exe     
    ├── pypath.config           # Path to Python3
    ├── activities.lst          # Edit activities here
    ├── database_writer.py      # Helper script
    ├── db_reader_main.py       # Run this script to read all databases
    └── database_reader.py      # Helper script
```
Make sure to organize the files as per the structure above.

