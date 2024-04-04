# Dynamic data structures

## Task
Compose a program for processing a dynamic data structure: swap the first and last elements of a single-link queue.

## Input data
- `int n` - input of queue length
- `queue<int> q` - queue input

## Functional characteristics
1. input of data by the user from the keyboard (length of the queue, then the queue itself)
2. replacing the first and the last elements in the queue
3. display of the changed queue on the screen

## Output data
- `replace(queue)` - output of the modified queue

## Functionality
- `read` - reads the sequence and creates a queue of them
- `replace` - performs the operation of swapping the places of the last and first elements
- `print` - outputs the queue

## Building
```bash
g++ -o lab6 lab6.cpp
