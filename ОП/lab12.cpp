#include <stdio.h>
#include <locale>
#include <conio.h>
#include <Windows.h>

int main()
{
	setlocale(LC_ALL, "Rus");
	int k = 0, N, i, Y_max, Y_min;
	int sum = 0, kchet = 0, sumchet = 0, knechet = 0, sumnechet = 0, sumcheti = 0, kcheti = 0;

	FILE *f; fopen_s(&f, "1.txt", "r");
	if (f == 0) //отсутствие файла
	{
		printf("Файл 1.txt не найден\n");
		_getch();
		return -1;
	}

	printf("Количество элементов массива и он сам берутся из файла 1.txt\n\n");
	fscanf_s(f, "%d", &N); //количество элементов массива
	printf("Количество элементов массива: %d\n\n", N);

	int *Y = new int[N];

	printf("Заданный массив\n");
	for (i = 0; i<N; i++)
	{
		fscanf_s(f, "%d", (Y + i));
		sum += *(Y + i); 	//сумма элементов массива
		if (*(Y + i) % 2 == 0) 	//сумма и количество чётных элементов массива
		{
			kchet++;
			sumchet += *(Y + i);
		}
		if (*(Y + i) % 2 != 0) 	//сумма и количество нечётных элементов массива
		{
			knechet++;
			sumnechet += *(Y + i);
		}
		if (i % 2 == 0) //сумма и количество элементов массива c чётными индексами
		{
			kcheti++;
			sumcheti += *(Y + i);
		}
	}

	for (i = 0; i < N; i++)
	{
		printf("%d ", *(Y + i));
	}

	printf("\n\nСумма элементов массива: %d \n", sum); 
	printf("\nСумма чётных элементов массива: %d \n", sumchet);
	printf("Количество чётных элементов массива: %d \n", kchet); 
	printf("\nСумма нечётных элементов массива: %d \n", sumnechet);
	printf("Количество нечётных элементов массива: %d \n", knechet); 
	printf("\nСумма элементов массива с чётными индексами: %d \n", sumcheti);
	printf("Количество элементов массива с чётными индексами: %d \n", kcheti); 

	//макисмальный элемент массива
	Y_max = *Y;
	for (i = 0; i<N; i++)
	{
		if (*(Y + i) > Y_max)
		{
			Y_max = *(Y + i);
		}
	}
	printf("\nМаксимальный элемент массива: %d \n", Y_max);

	//Минимальный элемент массива
	Y_min = *Y;
	for (i = 0; i<N; i++)
	{
		if (*(Y + i) < Y_min)
		{
			Y_min = *(Y + i);
		}
	}
	printf("\nМинимальный элемент массива: %d \n", Y_min);

	fclose(f);

	//запись массива в обратном порядке в отдельный файл
	printf("\n\nМассив в обратном порядке\nОн будет записан в файл 2.txt\n");
	FILE *fout; fopen_s(&fout, "2.txt", "wt");
	fprintf(fout, "Массив в обратном порядке\n");
	for (i = N - 1; i >= 0; i--)
	{
		fprintf(fout, "%d ", *(Y + i));
		printf("%d ", *(Y + i));
	}
	_getch();
	fclose(fout);

	return 0;
}
