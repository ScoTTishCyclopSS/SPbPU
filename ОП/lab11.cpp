#include "stdafx.h"
#include <iostream>
#include <conio.h>
#include <locale>

using namespace std;

int test(int *a, int *b);
float test(float *a, float *b);
double test(double *a, double *b);
double test2(double *d, double *f);

float testp(float *m, float *n); //свой вариант: половина произведения 2ух чисел - 2 числа флоат и 2 числа дабл
double testp(double *m, double *n);

int main()
{
	int i1, i2, sumi;
	float f1, f2, sumf, fp1, fp2, sump;
	double d1, d2, d3, d4, sumd, dsumd, dp1, dp2, dsump;
	
	sumi = test(&i1, &i2);
	cout << "Summ of integers: " << sumi << endl << endl;
	sumf = test(&f1, &f2);
	cout << "Summ of floats: " << sumf << endl << endl;
	sumd = test(&d1, &d2);
	cout << "Summ of floats with double accuracy: " << sumd << endl << endl;
	dsumd = test2(&d3, &d4);
	cout << "Doubled summ of floats with double accuracy: " << dsumd << endl << endl;

	sump = testp(&fp1, &fp2);
	cout << "Half of 2 float op.: " << sump << endl << endl;
	dsump = testp(&dp1, &dp2);
	cout << "Half of 2 doubles op.: " << dsump << endl << endl;

	_getch();



    return 0;
}

int test(int *a, int *b)
{
	cout << "Enter 2 ints: ";
	cin >> *a >> *b; return(*a + *b);
}
float test(float *a, float *b)
{
	cout << "Enter 2 floats: ";
	cin >> *a >> *b; return(*a + *b);
}
double test(double *a, double *b)
{
	cout << "Enter 2 floats with double accuracy: ";
	cin >> *a >> *b; return(*a + *b);
}
double test2(double *d, double *f)
{
	cout << "Enter 2 floats with double accuracy: ";
	cin >> *d >> *f; return 2 * (*d + *f);
}


float testp(float *m, float *n)
{
	cout << "Enter 2 floats: ";
	cin >> *m >> *n; return (*m * *n)/2;
}
double testp(double *m, double *n)
{
	cout << "Enter 2 doubles: ";
	cin >> *m >> *n; return (*m * *n) / 2;
}