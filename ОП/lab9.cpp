#include <conio.h>
#include <stdio.h>

void main()
{
	int i;
	const int N = 10;
	int mas[N] = { 3, -3, 4, -5, 6, 7, -7, 8, 9, 0 };
	int *p;  //объявление указателя
	p = mas;
	printf("m=");
	for (i = 0; i < N; i++)
		printf("%d, ",  mas[i]);
	printf("\n");
	printf("p=");
	for (i = 0; i < N; i++)
		printf("%d, ", *(p + i));
	_getch();
}