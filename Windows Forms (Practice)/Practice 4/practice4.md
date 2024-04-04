# Practice 4

## Topic
Creating projects using different components.

## Objective
The objective of this practice is to gain familiarity with GUI design concepts and event handling in C#. This includes learning about different UI components, such as buttons, labels, text boxes, and panels, and understanding how to respond to user interactions and input events.

## Task 4.1 - Cost of printing photos
The number of photos (integer) is entered. User selects the size of photos to be printed using a group of dependent selection buttons. At the same time, depending on the size of photos, the program sets a different price per photo. Create also a method for processing data in the input field that checks if an integer without a sign is entered correctly. Use the KeyPress event.

## Task 4.2 - Electricity
Initial data are set using input fields: previous meter reading, current meter reading. The previous meter reading must not be greater than the current meter reading. The region is also set by selecting from a list (combined list component). Depending on the region selection, the program sets a different cost of 1 kW. Create also a general function for processing data in the input fields, which checks the correctness of entering an integer without a sign, not more than 6 digits

## Task 4.3 - Ohm's Law
Program for calculating voltage, resistance or current. On the form, place a group of three dependent selection buttons, two text fields and the "Calculate" button. While the program is running, as a result of selecting the Current, Voltage or Resistance switch, the text explaining the purpose of the input fields should change, and the result should be calculated using different formulas.

## Task 4.4 - Deposit income
Initial data are set using input fields: initial amount (in rubles, integer), number of months (integer: 3, 6, 9, 12, 15, 18, 21, 24 with a value switch), interest rate (percent per annum, fractional number). Place two buttons on the form: "Calculate" and "Finish". If you press the "Calculate" button, the deposit income and the increased amount will be calculated (the amount is indexed every month). Pressing the "Finish" button closes the application.

## Task 4.5 - Exact Age
Enter the user's day, month and year of birth in date format. Use masked text input. Calculate the user's exact age as of the current date, that is, how old, months and days the user is now.

## Task 4.6 - Supermarket
Allows you to determine the total cost of all purchases, taking into account the discount. The name of the product is selected from a list (comboBox component, you can enter other names). In the text field to enter the price of goods (fractional number) and the quantity of goods (integer). On the form to place two buttons: "Add" and "Reset". Place a multi-line editor on the form. When you click on the "Add" button, the cost of the next item is added to the total amount, each selected item and its price is added to the editor. If you click on the "Reset" button, the sum is reset to zero, the editor field is cleared. 3% discount is given for the total amount over 500 rubles, 5% discount for the amount over 1000 rubles. Display the total amount without discount and with discount.  

## Task 4.7 - Cost of a telephone call
Determine the cost of a telephone call in real time (with per-second billing). The tariff per minute of conversation is set with the help of dependent selection buttons (within the network - 15 kopecks, other operator - 30 kopecks, on the city - 1 ruble). There are two buttons on the form: "Start a call" and "End a call". The duration of the call is calculated according to the system time. In the morning hours (from 8 a.m. to 1 p.m.) the tariff is reduced by 40%. Place a progressBar on the form that shows the remaining time. Limit the talk time to 1.5 minutes.

## Task 4.8 - Guess the Number
The computer "guesses" a three-digit number using a random number generator. The user enters the answer in the text field. Pressing the Enter key verifies the number entered. Create a status bar panel. Output the hint (more, less, guessed), number of attempts, remaining time. Limit the game time to 1 minute. At the end of the game output the result: "Winning" (for how many attempts) or "Losing" (if the time has expired and the number is not guessed). On the surface of the form place a photo suitable for the theme of the game as a background
