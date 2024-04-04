# Arithmetic Progression Term Calculator

## Task
Develop specifications and write a function to calculate the value of any term of an arithmetic progression by a given number if the first term of the progression and its difference are known, as well as a function that checks whether a given number belongs to this progression.

## Input data
- `double first_term, diff, n_term` - `a` is the first term, `diff` is the difference, `n_term` is the n'th term
- `int n` - enter the number of the arithmetic progression term

##  Functional characteristics
1. user input from the keyboard
2. determination of the n-th term of the arithm. progression
3. determining whether the number belongs to the arithm. progression
3. output of calculations on the screen

## Output data
- `double n_term` - n-th term
- `bool check` - check for belonging to the progression

## Functionality
- `arpr` function calculates the n-th term of the arithmetic progression based on the given first term, common difference, and term number
- `arnumber` function checks if a given number belongs to the arithmetic progression defined by the first term and common difference

## Building
```bash
g++ -o lab2 lab2.cpp
