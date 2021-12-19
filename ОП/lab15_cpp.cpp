#include <conio.h>
#include <stdio.h>
#include <iostream>

void PARAMETR(int, int*, int*);
int PARAMETR_S(int);
int PARAMETR_P(int);
using namespace std;
void main()
{
	int a, S, P; // a-сторона квадрата, S-площадь квадрата, P-периметр квадрата
	a = 4;
	// Передача параметров через список(Адреса и указатели)
	PARAMETR(a, &S, &P); //Вызов функции
	cout << "\n a=" << a << '\t' << "S=" << S << '\t' << "P=" << P;
	// Передача параметров через return
	S = PARAMETR_S(a); //Вызов функции для площади(S)
	P = PARAMETR_P(a); //Вызов функции для периметра(P)
	//ВЫВОД
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
	int SS; //Площадь
	SS = a*a;
	return(SS);
}
int PARAMETR_P(int a)
{
	int PP; //Периметр
	PP = 4 * a;
	return(PP);
}
