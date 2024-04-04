# Day of the Year Calculator

## Task
Write an algorithm and a program that outputs the date and month in a common form by the number of the day of the year. For example, the 33rd day of the year is February 2.

## Input data
- `const char *months[12]` - a string array containing the names of the months of the year
- `const int days[12]` - a numeric array containing numbers with the number of days in months
- `int day_num` - a variable of integer type, meaning the number of days in the year, entered from the keyboard
- `int check_day` - a variable of integer type, meaning the number of the day in the month, with with which it will be compared

## Functional characteristics
1. user input from the keyboard
2. calculation of the day of the year, according to the data entered by the user data
3. output of the found day in a common form on the screen

## Output data
- `n` - output of the day entered by the user earlier
- `(n - check_day)` - output of the searched day
- `months[i]` - output the comparable day of the month

## Building
```bash
g++ -o lab1 lab1.cpp
