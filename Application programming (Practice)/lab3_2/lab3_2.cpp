#include <iostream>
#include <stdio.h>
#include <ctime>

// Checks for each row if it is equal to its corresponding column
void symmetry(int **ptrarray, int n, bool *k)
{
	for (int i = 0; i < n; i++)
	{
		k[i] = true;
		for (int j = 0; j < n; j++)
		{
			if (*(*(ptrarray + i) + j) != *(*(ptrarray + j) + i))
			{
				k[i] = false;
				break;
			}
		}
	}
}

int main(int argc, char *argv[])
{
	srand(time(0)); // random numbers are generated each time the program runs
	int n;

	printf("Enter the size of square matrix: ");
	scanf("%d", &n);

	// dynamically allocate two-dimensional array
	int **ptrarray = new int *[n];

	// dynamically allocate each row
	for (int i = 0; i < n; i++)
		*(ptrarray + i) = new int[n];

	// fill the matrix with random numbers ranging from 1 to 3
	for (int i = 0; i < n; i++)
		for (int j = 0; j < n; j++)
			*(*(ptrarray + i) + j) = int((rand() % 3 + 1));

	printf("Generated matrix: \n");
	for (int i = 0; i < n; i++)
	{
		for (int j = 0; j < n; j++)
			printf("%d  ", *(*(ptrarray + i) + j));
		printf("\n");
	}

	bool *k = new bool[n];
	symmetry(ptrarray, n, k);

	printf("Equal rows-collums indices: ");
	for (int i = 0; i < n; i++)
	{
		if (k[i])
			printf("%d  ", i + 1);
	}
	printf("\n");

	for (int count = 0; count < n; count++)
		delete[] *(ptrarray + count);

	return 0;
}