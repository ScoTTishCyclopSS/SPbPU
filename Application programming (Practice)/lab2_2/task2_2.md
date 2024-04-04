# Numerical Integration using Simpson's Rule and the Trapezoidal Rule

## Task
Develop a program to calculate the integral using the Trapezoidal method and Simpson's method, formulating each method as a separate function. Display the results of integration by different methods for comparison.

## Input data:
- `double accuracy` - accuracy

## Functional characteristics
1. user input from the keyboard
2. calculation of integral by Trapezoidal method
3. calculation of integral by Simpson method
3. output of calculations on the screen

## Output data:
- `double Trapezoidal` - values from calculation by the trapezoid method
- `double Simpson` - values from calculation by Simpson method

## Functionality
- `func` function defines the function to be integrated
- `simpson` function implements Simpson's Rule for numerical integration
- `trapezoidal` function implements the Trapezoidal Rule for numerical integration

## Building
```bash
g++ -o lab2_2 lab2_2.cpp
