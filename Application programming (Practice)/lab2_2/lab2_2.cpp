#include <iostream>
#include <stdlib.h>
#include <math.h>

// Defines the function to be integrated
double func(double x)
{
	return (sin(x) * cos(x)) / (pow(sin(x), 2) - pow(cos(x), 2) + 2);
}

/*
 * Implements Simpson's Rule for numerical integration
 * Computes the integral of the function 'func' over the interval [a, b] with a given accuracy 'acc'
 */
double simpson(double a, double b, double acc)
{
	double I = 0;	  // integral value to be computed
	double I_tmp = 0; // previous iteration's integral value
	double n = 4;	  // number of subintervals
	double h, even, odd, diff_abs;
	double x = 0, first, last;

	// an iterative approach to refine the approximation
	// until the desired accuracy is achieved
	do
	{
		h = (b - a) / n; // width of each subinterval

		even = 0; // sum of function values at even indices
		odd = 0;  // sum of function values at odd indices

		first = func(a); // value of the function at the left endpoint
		last = func(b);	 // value of the function at the right endpoint

		// loop over each subinterval
		for (int i = 1; i < n; i++)
		{
			x = a + i * h; // midpoint of the current subinterval

			if (i % 2 == 0) // if the index is even ...
				// accumulating the function value at even indices
				even += func(x);
			else
				// accumulating the function value at odd indices
				odd += func(x);
		}

		// Simpson's Rule formula to compute the integral
		I = h / 3 * (last + 2 * even + 4 * odd + first);

		// absolute difference between consecutive iterations
		diff_abs = fabs(I_tmp - I);

		// updating the value of the integral for the next iteration
		I_tmp = I;

		// doubling the number of subintervals for the next iteration
		n *= 2;
	} while (diff_abs >= acc);

	return I;
}

/*
 * Implements the Trapezoidal Rule for numerical integration
 * Computes the integral of the function 'func' over the interval [a, b] with a given accuracy 'acc'
 */
double trapezoidal(double a, double b, double acc)
{
	double I = 0;	  // integral value to be computed
	double I_tmp = 0; // previous iteration's integral value
	double n = 4;	  // number of subintervals
	double h, even, odd, diff_abs;
	double x = 0, first, last;

	do
	{
		h = (b - a) / n; // width of each subinterval

		first = func(a); // value of the function at the left endpoint
		last = func(b);	 // value of the function at the right endpoint

		double S = 0; // sum of function values

		// loop over each subinterval
		for (int i = 1; i < n; i++)
		{
			x = a + i * h; // midpoint of the current subinterval
			S += func(x);  // accumulating the function value at each midpoint
		}

		// Trapezoidal Rule formula to compute the integral
		I = h / 2 * (last + 2 * S + first);

		// absolute difference between consecutive iterations
		diff_abs = fabs(I_tmp - I);

		// updating the value of the integral for the next iteration
		I_tmp = I;

		// doubling the number of subintervals for the next iteration
		n *= 2;
	} while (diff_abs >= acc);

	return I;
}

int main()
{
	int a = 0, b = M_PI / 2.;
	double accuracy;

	printf("Computable igntegral: [%d, %d] | (sin(x) * cos(x)) / (pow(sin(x), 2) - pow(cos(x), 2) + 2)\n", a, b);

	do
	{
		printf("Enter an accuracy (between 0 to 1): ");
		scanf("%lf", &accuracy);
	} while (accuracy <= 0 || accuracy > 1);

	double Trapezoidal = trapezoidal(a, b, accuracy);
	double Simpson = simpson(a, b, accuracy);

	printf("Trapezoidal Rule: %lf\n", Trapezoidal);
	printf("Simpson's Rule: %lf\n", Simpson);

	return 0;
}