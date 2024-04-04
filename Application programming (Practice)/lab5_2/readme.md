# String Searcher

## Task
Develop a program to fill a file with integers in the interval [1; N]. 
Obtain a new file from the components of the original file that are complete squares.

## Input data
- `int n` - limit for integers

## Functional characteristics
1. user input from the keyboard (limit for integers)
2. filling a binary file with integers in the specified range
3. output of numbers in the specified range
4. writing to the 2nd component of the source file, which are full squares
5. output full squares on the screen

## Output data
- `int i` - output of numbers
- `int i2` - output of complete squares

## Functionality
- `isPerfectSquare` - checks if a given number is a perfect square

## Building
```bash
g++ -o lab5 lab5.cpp
