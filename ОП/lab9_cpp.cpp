#include <conio.h>
#include <stdio.h>
#include <iostream>
using namespace std;

void main()
{
	int i;
	const int N = 10;
	int mas[N] = { 3, -3, 4, -5, 6, 7, -7, 8, 9, 0 };
	int *p;  //объявление указателя
	p = mas;
	cout << "m=";
	for (i = 0; i < N; i++)
		cout << mas[i] << ", ";
	cout << "\n";
	cout << "p=";
	for (i = 0; i < N; i++)
		cout << *(p + i) << ", ";
	_getch();
}
