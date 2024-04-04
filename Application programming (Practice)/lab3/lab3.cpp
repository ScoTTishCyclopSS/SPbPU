#include <stdio.h>
#include <iostream>
#include <ctime>

// Rotates the array 'r' times to the right
void rotate(float *ptrarray, int n, int r)
{
	for (int i = 0; i < r; i++)
	{
		float tmp = ptrarray[n - 1];

		for (int j = n - 1; j > 0; j--)
			*(ptrarray + j) = ptrarray[j - 1];

		ptrarray[0] = tmp;
	}
}

int main(int argc, char *argv[])
{
	srand(time(0)); // random numbers are generated each time the program runs
	int n, r;

	printf("Enter the size of the array: ");
	scanf("%d", &n);

	printf("Enter the size of rotations: ");
	scanf("%d", &r);

	// dynamically allocate an array
	float *ptrarray = new float[n];

	// fill the array with random numbers ranging from 1 to 10
	for (int i = 0; i < n; i++)
		*(ptrarray + i) = (rand() % 10 + 1) / float((rand() % 10 + 1));

	printf("Generated array: \n");
	for (int i = 0; i < n; i++)
		printf("%.2f ", *(ptrarray + i));
	printf("\n");

	rotate(ptrarray, n, r);

	printf("Rotated array: \n");
	for (int i = 0; i < n; i++)
		printf("%.2f ", *(ptrarray + i));
	printf("\n");

	delete[] ptrarray;
	return 0;
}