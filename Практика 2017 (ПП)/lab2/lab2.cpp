#include <iostream>
#include <conio.h>
#include <locale>
#include <Windows.h>
using namespace std;

double arpr(double a, double r, int n)//фукнция вычисления члена арифм. прогрессии по заданному номеру и возвращает an - n-ный член прогрессии
{
	return a + (n - 1)*r;//a - первый член, r - разность, n - номер члена
}
bool arnumber(double a, double r, double an)//функция проверяет принадлежность числа к арифметической прогрессии
{
	double n;
	n = ((an - a) / r) + 1;//a - первый член, r - разность, an - n-ный член
	if (n - (int)n == 0)//true - если принадлежит, false - не принадлежит
		return true;
	else
		return false;
}

void main()
{
	setlocale(LC_ALL, "Rus");
	double a, r, an;
	int n;
	bool check;

	cout << "--Опр. n-члена арифм. прогрессии--" << endl;
	cout << "\nВведите первый член арифм. прогрессии: "; cin >> a;
	cout << "\nВведите разность: "; cin >> r;
	do
	{
		cout << "\nВведите номер члена арифм. прогрессии: "; cin >> n;
	} 
	while (n < 0);
	an = arpr(a, r, n);
	cout << "\n" << n << "-ый член арифм. прогрессии равен =  " << an;
	cout << "\n\nВведите n-ный член арифм. прогрессии: "; cin >> an;
	check = arnumber(a, r, an);
	if (check)
		cout << "\nЧисло принадлежит арифм. прогрессии";
	else
		cout << "\nЧисло не принадлежит арифм. прогрессии";
	_getch();
}
