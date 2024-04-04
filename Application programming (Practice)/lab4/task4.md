# String Manipulation

## Task
- Develop a function that returns a string of characters that is obtained from string S1 by deleting characters from position N1 to position N2.
- Develop a function that returns a string of characters from string S1 by deleting characters from position N1 to position N2 and inserting string S2 in this place.
- Place all functions in a separate file (library). Develop a project that connects its own library to check the results of function calls.

## Input data
- `char str[100], substr[100]` - string and additional string
- `int n1, n2` - positions from and to, within which it is necessary to delete elements and insert an additional string

## Functional characteristics
1. user input of data from the keyboard (both lines and range);
2. output of the initial line to the screen;
3. output of a line with deletion on the screen;
4. output of a line with addition of an additional line;

## Output data
- `char str` - initial string
- `del` - string with deleted elements
- `add` - string with addition of substring

## Functionality
- `delete_str` deletes the characters in string in specified interval
- `add_str` inserts the characters from substring into string in specified interval

## Building
```bash
g++ -o lab4 lab4.cpp lib.cpp
