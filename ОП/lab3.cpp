#include <conio.h>
#include <stdio.h>
#include <math.h>
int main()
{
	float sf, hf, vf, a, p, Ss, r, h, se;		//s-������� ���������, h-������, v-�����, a-�������, p-��������, Ss-������� ������� �������, r-������, se-������� �����
	printf("Programm to colculate the volume of the pyramid \n\n");
	printf("Write value of two variables: S-footprint, H-height \n");
	scanf_s("%f%f", &sf, &hf);
	if (sf <= 0)						//��� float
	{
		printf("False. S can not be 0 or less.\n");
	}
	if (hf <= 0)
	{
		printf("False. H can not be 0 or less.\n");
	}
	else {
		vf = (sf / 3)*hf;
		printf("Result: V= %f \n\n", vf);
	}

	printf("Programm to colculate the side area of the pyramid \n\n");
	printf("Write value of two variables: P-perimeter, A-apothem \n");
	scanf_s("%f%f", &p, &a);
	if (p <= 0)						//��� float
	{
		printf("False. P can not be 0 or less.\n");
	}
	if (a <= 0)
	{
		printf("False. A can not be 0 or less.\n");
	}
	else
	{
		Ss = (p / 2)*a;
		printf("Result: Ss= %f \n\n", Ss);
	}
	printf("Programm to colculate the lateral edge of the pyramid \n\n");
	printf("Write value of two variables: H-height, R-radius \n");
	scanf_s("%f%f", &h, &r);
	if (h <= 0)						//��� float
	{
		printf("False. H can not be 0 or less.\n");
	}
	if (r <= 0)
	{
		printf("False. R can not be 0 or less.\n");
	}
	else
	{
		se = sqrt(pow(h, 2) + pow(r, 2));
		printf("Result: Se= %f \n\n", se);
	}
	_getch();
}

