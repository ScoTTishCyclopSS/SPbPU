#include <stdio.h>
#include <conio.h>

void proverka(float *f)
{
	float n;
	do
		{
			printf(" = ");
			scanf_s("%f", &n);
			if (n <= 0)
			printf("Number cant be < or = 0!\n ");
		} 
	while (n <= 0);
	*f = n;
}
void proverka(int *i)
{
	float a;
	do
	{
		printf(" = ");
		scanf_s("%d", &a);
		if (a <= 0)
			printf("Number cant be < or = 0!\n ");
	} while (a <= 0);
	*i = a;
}
void proverka(double *d)
{
	float b;
	do
	{
		printf(" = ");
		scanf_s("%lf", &b);
		if (b <= 0)
			printf("Number cant be < or = 0!\n ");
	} while (b <= 0);
	*d = b;
}