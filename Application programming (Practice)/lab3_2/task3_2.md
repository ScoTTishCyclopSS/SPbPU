# Matrix Symmetry Checker

## Task
Dynamically allocate memory for N^2 elements of integer. Develop an algorithm and a program for processing a square matrix of order N: find such numbers in the matrix that the i-th row of the matrix coincides with the i-th column.

## Input data
- `int n` - matrix size

## Functional characteristics
1. user input from the keyboard (number of rows and columns)
2. array filling
3. displaying the array on the screen
4. finding such numbers i that the i-th row of the matrix coincides with the i-th column
5. output these i on the screen

## Output data
- `i + 1` - such numbers i that the i-th row of the matrix coincides with the i-th column

## Functionality
- `symmetry` function checks each row of the matrix to see if it is equal to its corresponding column and stores the result in a boolean array

## Building
```bash
g++ -o lab3_2 lab3_2.cpp
