#include <conio.h>
#include <stdio.h>
#include <iostream>

void PARAMETR(int, int*, int*);
int PARAMETR_S(int);
int PARAMETR_P(int);
using namespace std;
void main()
{
	int a, S, P; // a-������� ��������, S-������� ��������, P-�������� ��������
	a = 4;
	// �������� ���������� ����� ������(������ � ���������)
	PARAMETR(a, &S, &P); //����� �������
	cout << "\n a=" << a << '\t' << "S=" << S << '\t' << "P=" << P;
	// �������� ���������� ����� return
	S = PARAMETR_S(a); //����� ������� ��� �������(S)
	P = PARAMETR_P(a); //����� ������� ��� ���������(P)
	//�����
	cout << "\n a=" << a << '\t' << "S=" << S << '\t' << "P=" << P;
	_getch();
}
void PARAMETR(int a, int*S, int*P)
{
	*S = a*a;
	*P = 4 * a;
}
int PARAMETR_S(int a)
{
	int SS; //�������
	SS = a*a;
	return(SS);
}
int PARAMETR_P(int a)
{
	int PP; //��������
	PP = 4 * a;
	return(PP);
}
