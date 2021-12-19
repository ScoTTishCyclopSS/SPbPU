#include <conio.h>
#include <stdio.h>
#include <math.h>
int main()
{
	const int N = 10;
	int mas[N], i, b[N], j;
	printf("Massive elements\n> ");
	for (i = 0; i < N; i++)
	{
		scanf_s("%d", &mas[i]);
	};
	printf("\nMassive that you had written --------> {", N);
	for (int i = 0; i < N; i++)
	{
		printf("%d, ", mas[i]);
	};
	printf("\b\b}\n");

	j = 0;
	for (i = 0; i < N; i++)
		if (mas[i] > 0)
		{
			b[j] = mas[i];
			j = j + 1;
		}
	printf("\nMassive with only pozitive numbers --> {", N);
	for (int i = 0; i < j; i++)
	{
		printf("%d, ", b[i]);
	};
	printf("\b\b}\n");

	j = 0;
	for (i = 0; i < N; i++)
		if (mas[i] <= 0)
		{
			mas[i] = 0;
		}
	printf("\nMassive with negative numbers transfer to 0 > {", N);
	for (i = 0; i < N; i++)
	{
		printf("%d ", mas[i]);
	};
	printf("\b\b}\n");
	_getch();
	return 0;
}