# Working with the file system

## Task
Make a file system program that allows you to find out the system time, and if the time is between 845 and 1115 - displays the message "Good morning!" and gives a beep, and also finds in the specified directory files created at that time.

## Input data
- `string str` – directory input

## Functional characteristics
1. user input of data from the keyboard (directory)
2. checking the time for "morning"
3. obtaining information about the time of file creation
4. comparing the time of file creation and "morning" time
5. output of files created in the "morning"

## Output data
- `wfd.cFileName` - file name
- `(time.wHour + UTC)` - hours of creation
- `time.wMinute` - minutes of creation
- `time.wSecond` - seconds of creation

## Functionality
- `Beep` - makes a beeping noise

## Building
```bash
g++ -o lab7 lab7.cpp
