# String Searcher

## Task
Create a text file in the editor, enter 10 lines of arbitrary text into it. 
Develop a program that:
- displays the lines of the file in which the specified substring occurs
- forms another file, into which it transcribes the lines of the original file containing Latin letters

## Input data
- `string substr` – string to find

## Functional characteristics
1. user input from the keyboard (letters to search for)
2. output of lines containing the searched letter
3. writing lines to the file containing Latin characters

## Output data
- `string s` - output of the string if found Latin alphabet

## Functionality
- `latfind` - check for Latin letters in the string

## Building
```bash
g++ -o lab5 lab5.cpp
