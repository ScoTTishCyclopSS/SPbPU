#include <conio.h>
#include <stdio.h>
void PARAMETR(int, int*, int*);
int PARAMETR_S(int);
int PARAMETR_P(int);

void main()
{
	int a, S, P; // a-������� ��������, S-������� ��������, P-�������� ��������
	a = 4;
	// �������� ���������� ����� ������(������ � ���������)
	PARAMETR(a, &S, &P); //����� �������
	printf(" a=%d \t   S=%d \t  P=%d", a, S, P);
	// �������� ���������� ����� return
	S = PARAMETR_S(a); //����� ������� ��� �������(S)
	P = PARAMETR_P(a); //����� ������� ��� ���������(P)
	//�����
	printf("\n a=%d \t   S=%d \t  P=%d", a, S, P);
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
