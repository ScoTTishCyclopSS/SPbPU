#include <conio.h>
#include <iostream>
#include <stdio.h>
#include <math.h>
using namespace std;
int main()
{
	const int n = 3, m = 4;
	int mas[n][m], i, j, k, kp = 0;	//k - кол-во элементов динамического массива, kp - кол-во положительных элементов   
	cout <<"Massive elements (12 or more numbers)\n> ";
	for (i = 0; i < n; i++)
		for (j = 0; j < m; j++)
		{
			cin >> mas[i][j];
		}
	cout <<"\nMassive that you had written\n";
	for (i = 0; i < n; i++)
	{
		for (j = 0; j < m; j++)
		{
			cout << mas[i][j] << ", ";
		}
		cout <<"\n";
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
	cout << "\nNumber of pozitive massive numbers which multiple of two > ";
	cout << kp;
	cout << "\n\n";
	for (i = 0; i < kp; i++)
	{
		cout << "Dinamic massive element > "; 
		cout << Din[i];
		cout << "\n";
	}

	_getch();
}
