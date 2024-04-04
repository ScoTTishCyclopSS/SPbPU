# Self-practice 1

## Topic
Calculating a function using series expansion 

## Task 1
You need to develop a program that calculates the value of a function using series expansion. The sum of the series is calculated using a loop with an unknown number of repetitions, as it is required to find the value with a given accuracy (the accuracy is entered from the keyboard). A convergent numeric series will reach the desired value when the number of summarized members of the series is large. In this case, the difference between neighboring members of the sequence will be very small. We will assume that the required accuracy of calculations has been reached if the difference between the neighboring elements of the series is less than the specified accuracy (the condition of exiting the loop). That is why we need to memorize the previous member of the series at each loop pass. This is convenient because the next term of the series is always calculated through the previous one (do not use degree expansion, it will be a simple multiplication instead). 

To check the obtained result, print the value of the specified function (the left part of the expression), the sum of the series calculated in the loop (the right part of the expression), and the number of summed terms of the series. 

## Task 2 
Add a check: 
- correctness of data input when keyboard keys are pressed into edit fields (use KeyPress event)
- range of input data
- control of empty input fields (lock the "Calculate" button until all data is entered)

## Variant 7


