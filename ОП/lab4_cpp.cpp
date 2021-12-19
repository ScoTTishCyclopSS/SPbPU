#include <iostream>
#include <conio.h>
#include <stdio.h>
#include <math.h>
using namespace std;
int main()
{
	const int N = 10;
	int mas[N], i, b[N], j;
	cout << "Massive elements\n> ";
	for (i = 0; i < N; i++)
	{
		cin >> mas[i];
	};
	cout << "\nMassive that you had written --------> {", N;
	for (int i = 0; i < N; i++)
	{
		cout << mas[i] << ", ";
	};
	cout << "\b\b}\n";

	j = 0;
	for (i = 0; i < N; i++)
		if (mas[i] > 0)
		{
			b[j] = mas[i];
			j = j + 1;
		}
	cout << "\nMassive with only pozitive numbers --> {", N;
	for (int i = 0; i < j; i++)
	{
		cout << b[i] << ", ";
	};
	cout << "\b\b}\n";

	j = 0;
	for (i = 0; i < N; i++)
		if (mas[i] <= 0)
		{
			mas[i] = 0;
		}
	cout << "\nMassive with negative numbers transfer to 0 > {", N;
	for (i = 0; i < N; i++)
	{
		cout << mas[i] << ", ";
	};
	cout << "\b\b}\n";
	_getch();
	return 0;
}