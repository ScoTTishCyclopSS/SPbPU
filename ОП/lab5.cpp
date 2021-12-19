#include <conio.h>
#include <stdio.h>
#include <math.h>
int main()
{
	const int n = 3, m = 4;
	int mas[n][m], i, j, k, kp = 0;	//k - кол-во элементов динамического массива, kp - кол-во положительных элементов   
	printf("Massive elements (12 or more numbers)\n> ");
	for (i = 0; i < n; i++)
		for (j = 0; j < m; j++)
		{
			scanf_s("%d", &mas[i][j]);
		}
	printf("\nMassive that you had written\n");
	for (i = 0; i < n; i++)
	{
		for (j = 0; j < m; j++)
		{
			printf("%d, ", mas[i][j]);
		}
		printf("\n");
	}
		k = n*m; // кол-во элементов динамического массива
		int *Din = new int[k];
		//Отбор элементов массива, кратных 2-ум
		for (i = 0; i < n; i++)
			for (j = 0; j < m; j++)
				if (mas[i][j] % 2 == 0)
				{
					Din[kp] = mas[i][j];
					kp++;
				}
		printf("\nNumber of pozitive massive numbers which multiple of two > %d \n\n", kp);
		for (i = 0; i < kp; i++)
		{
			printf("Dinamic massive element > %d \n", Din[i]);
		}

		_getch();
}
