//Находение площади и сторны ромба через диагонали
//Скарговский Федор 228/2

#include "stdafx.h"
#include <stdio.h>
#include <conio.h>
#include <locale.h>
#include <math.h>

using namespace std;
void par_v(double, double *);
void par_s(double, double *);
double par_d(double);
void main()
{
	setlocale(LC_ALL, "Rus");
	double a, v, s, d;					//a-ребро, v-объем 
	printf("Нахождение объема и площади одной и всех граней куба.\n \n");
	printf("Введите длины ребра. \n");
	printf("Длина ребра равна: ");
	scanf_s("%lf", &a);

	while (a <= 0) {
		printf("Вы ошиблись! Длина ребра не может быть отрицательной или равной 0. \n");
		printf("Введите новое значение длины ребра. \n");
		printf("\n");
		printf("Длина ребра равна: ");
		scanf_s("%lf", &a);
		printf("\n");
	}

	par_v(a, &v);					//вызовф функции вычисления объема
	par_s(a, &s);					//вызовф функции вычисления площади одной грани
	d = par_d(s);					//вызовф функции вычисления площади всех граней
	

	printf("Объем куба: %.2lf\nПлощадь одной грани куба: %.2lf\nПлощадь всех граней: %.2lf", v, s, d);	
	//вывод полученных занчений
	_getch();
}

void par_v(double a, double *v)		//функция вычисления объема
{
	*v = pow(a, 3);
}
void par_s(double a, double *s)		//функция вычисления площади одной грани
{
	*s = pow(a, 2);
}

double par_d(double s)				//функция вычисления площади всех граней
{
	return (6 * s);
}