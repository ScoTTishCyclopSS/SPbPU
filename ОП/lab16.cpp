//��������� ������� � ������ ����� ����� ���������
//����������� ����� 228/2

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
	double a, v, s, d;					//a-�����, v-����� 
	printf("���������� ������ � ������� ����� � ���� ������ ����.\n \n");
	printf("������� ����� �����. \n");
	printf("����� ����� �����: ");
	scanf_s("%lf", &a);

	while (a <= 0) {
		printf("�� ��������! ����� ����� �� ����� ���� ������������� ��� ������ 0. \n");
		printf("������� ����� �������� ����� �����. \n");
		printf("\n");
		printf("����� ����� �����: ");
		scanf_s("%lf", &a);
		printf("\n");
	}

	par_v(a, &v);					//������ ������� ���������� ������
	par_s(a, &s);					//������ ������� ���������� ������� ����� �����
	d = par_d(s);					//������ ������� ���������� ������� ���� ������
	

	printf("����� ����: %.2lf\n������� ����� ����� ����: %.2lf\n������� ���� ������: %.2lf", v, s, d);	
	//����� ���������� ��������
	_getch();
}

void par_v(double a, double *v)		//������� ���������� ������
{
	*v = pow(a, 3);
}
void par_s(double a, double *s)		//������� ���������� ������� ����� �����
{
	*s = pow(a, 2);
}

double par_d(double s)				//������� ���������� ������� ���� ������
{
	return (6 * s);
}