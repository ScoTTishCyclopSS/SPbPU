# Organization of multithreaded data processing

## Task
Write a program that creates a process. Use the default attributes. The parent and newly created process should print lines of text so that the parent and child process output is synchronized: first the parent process would print three lines, then the child five lines, then the parent the next three lines, and so on. Use mutexes.

## Input data
- `file` - source file of strings to display them

## Functional characteristics
1. open the file for reading
2. create two processes
3. take lines from the file
4. call the function of printing and coloring lines from the file
5. print the lines of the file one by one

## Output data
- `lines` - lines of the source file

## Functionality
- `process` - starts a process in the background to access the file at the same time
- `line` - outputs the string in red or not for distinguishability

## Building
```bash
g++ -o lab8 lab8.cpp -pthread
