#include <iostream>
#include <windows.h>
#include <conio.h>
#include <stdlib.h>
#define _USE_MATH_DEFINES
#include <math.h>
using namespace std;

double func(double x)
{
	return (sin(x)*cos(x)) / (2 + pow(sin(x), 2) - pow(cos(x), 2));
}
double simpson(double a, double b, double t) // метод Симпсона
{
	double I = 0, I1 = 0, s, chet, nechet, tt, n = 4;//I - интеграл, I1 - начальное значение, s - шаг разбиения, chet/nechet - четн./нечетн. член ряда, tt - разность, n - кол-во разбиений
	double x = 0, first, last; //x - аргумент, first/last - первый|последний элемент ряда
	n *= 2;
	do
	{
		s = (b - a) / n;
		chet = 0; nechet = 0;
		first = func(a);
		last = func(b);
		for (int i = 1; i < n; i++)
		{
			x = a + i*s;
			if (i % 2 == 0)
			{
				chet += func(x);
			}
			else
			{
				nechet += func(x);
			}
		}
		I = s / 3 * (last + 2 * chet + 4 * nechet + first); //нахождение интеграла
		tt = fabs(I1 - I);
		I1 = I;
		n *= 2; //удваивание отрезков разбиения
	} 
	while (tt >= t);
	return I;
}

double trapeze(double a, double b, double t) //метод трапеций
{
	double I = 0, I1 = 0, s, chet, nechet, tt, n = 4;
	double x = 0, first, last;
	do
	{
		s = (b - a) / n;
		double S = 0; //сумма
		first = func(a);
		last = func(b);
		for (int i = 1; i < n; i++)
		{
			x = a + i*s;
			S += func(x);
		}
		I = s / 2 * (last + 2 * S + first); // интеграл
		tt = fabs(I1 - I);
		I1 = I;
		n *= 2; // удваиваем кол-во отрезков разбиения
	} 
	while (tt >= t);
	return I;
}

void main()
{
	setlocale(LC_ALL, "Russian");
	int a = 0, b = M_PI/2.; // пределы интегрирования
	double accuracy; // точность
	cout << "Введите точность:  ";
	cin >> accuracy;
	if (accuracy <= 0 || accuracy > 1)
		cout << "Точность только от 0 до 1!\n";
	else
	{
		double Trapecia = trapeze(a, b, accuracy);
		cout << "По методу трапеций :" << Trapecia << endl;
		double Simpson = simpson(a, b, accuracy);
		cout << "По методу Симпсона :" << Simpson << endl;
	}
	system("pause");
}