#include <conio.h>
#include <stdio.h>
int main()
{
	float ai, bi, ci;
	printf("Write two simbols \n");
	scanf_s("%f%f", &ai, &bi);
	if (bi == 0)
	{
		printf("False. B can not be 0.\n");
	}
	else
	{
		ci = ai / bi;
		printf("Result: c= %f \n", ci);
	}
	_getch();
}
