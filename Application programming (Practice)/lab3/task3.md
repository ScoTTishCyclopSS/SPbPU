# Pointers and dynamic memory allocation

## Task
Dynamically allocate memory for N elements of real float type. Develop an algorithm and a program for processing a one-dimensional dynamic array. Perform cyclic shift of elements of a one-dimensional array by k positions.

## Input data
- `int n, r` - `n` is the number of elements, `r` is the position shift;

## Functional characteristics
1. user input of data from the keyboard (number of array elements and shift)
2. array filling
3. array output on the screen
4. shift of array elements
5. output the shifted array on the screen

## Output data
- `*(ptrarray + count)` - output of the shifted array

## Functionality
- `rotate` function rotates the array `r` times to the right

## Building
```bash
g++ -o lab3 lab3.cpp
