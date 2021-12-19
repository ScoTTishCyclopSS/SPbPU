#include <conio.h>
#include <stdio.h>
int main()
{
	int ai, bi, ci;
	float af, bf, cf;
	double ad, bd, cd;
	printf("Write two simbols \n");
	scanf_s("%d%d", &ai, &bi);
	if (bi == 0)					//для int
	{
		printf("False. B can not be 0.\n");
	}
	else
	{
		ci = ai / bi;
		printf("Result: c= %d \n", ci);
	}
	printf("Write two simbols \n");
	scanf_s("%f%f", &af, &bf);
	if (bf == 0)						//для float
	{
		printf("False. B can not be 0.\n");
	}
	else
	{
		cf = af / bf;
		printf("Result: c= %f \n", cf);
	}
	printf("Write two simbols \n");
	scanf_s("%lf%lf", &ad, &bd);
	if (bd == 0)						//для double
	{
		printf("False. B can not be 0.\n");
	}
	else
	{
		cd = ad / bd;
		printf("Result: c= %lf \n", cd);
	}
	_getch();
}
