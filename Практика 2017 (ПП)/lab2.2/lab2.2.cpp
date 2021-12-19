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
double simpson(double a, double b, double t) // ����� ��������
{
	double I = 0, I1 = 0, s, chet, nechet, tt, n = 4;//I - ��������, I1 - ��������� ��������, s - ��� ���������, chet/nechet - ����./������. ���� ����, tt - ��������, n - ���-�� ���������
	double x = 0, first, last; //x - ��������, first/last - ������|��������� ������� ����
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
		I = s / 3 * (last + 2 * chet + 4 * nechet + first); //���������� ���������
		tt = fabs(I1 - I);
		I1 = I;
		n *= 2; //���������� �������� ���������
	} 
	while (tt >= t);
	return I;
}

double trapeze(double a, double b, double t) //����� ��������
{
	double I = 0, I1 = 0, s, chet, nechet, tt, n = 4;
	double x = 0, first, last;
	do
	{
		s = (b - a) / n;
		double S = 0; //�����
		first = func(a);
		last = func(b);
		for (int i = 1; i < n; i++)
		{
			x = a + i*s;
			S += func(x);
		}
		I = s / 2 * (last + 2 * S + first); // ��������
		tt = fabs(I1 - I);
		I1 = I;
		n *= 2; // ��������� ���-�� �������� ���������
	} 
	while (tt >= t);
	return I;
}

void main()
{
	setlocale(LC_ALL, "Russian");
	int a = 0, b = M_PI/2.; // ������� ��������������
	double accuracy; // ��������
	cout << "������� ��������:  ";
	cin >> accuracy;
	if (accuracy <= 0 || accuracy > 1)
		cout << "�������� ������ �� 0 �� 1!\n";
	else
	{
		double Trapecia = trapeze(a, b, accuracy);
		cout << "�� ������ �������� :" << Trapecia << endl;
		double Simpson = simpson(a, b, accuracy);
		cout << "�� ������ �������� :" << Simpson << endl;
	}
	system("pause");
}