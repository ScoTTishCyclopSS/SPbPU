#include <iostream>
#include <conio.h>
#include <locale>
#include <Windows.h>
using namespace std;

double arpr(double a, double r, int n)//������� ���������� ����� �����. ���������� �� ��������� ������ � ���������� an - n-��� ���� ����������
{
	return a + (n - 1)*r;//a - ������ ����, r - ��������, n - ����� �����
}
bool arnumber(double a, double r, double an)//������� ��������� �������������� ����� � �������������� ����������
{
	double n;
	n = ((an - a) / r) + 1;//a - ������ ����, r - ��������, an - n-��� ����
	if (n - (int)n == 0)//true - ���� �����������, false - �� �����������
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

	cout << "--���. n-����� �����. ����������--" << endl;
	cout << "\n������� ������ ���� �����. ����������: "; cin >> a;
	cout << "\n������� ��������: "; cin >> r;
	do
	{
		cout << "\n������� ����� ����� �����. ����������: "; cin >> n;
	} 
	while (n < 0);
	an = arpr(a, r, n);
	cout << "\n" << n << "-�� ���� �����. ���������� ����� =  " << an;
	cout << "\n\n������� n-��� ���� �����. ����������: "; cin >> an;
	check = arnumber(a, r, an);
	if (check)
		cout << "\n����� ����������� �����. ����������";
	else
		cout << "\n����� �� ����������� �����. ����������";
	_getch();
}
