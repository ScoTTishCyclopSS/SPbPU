#include <conio.h>
#include <stdio.h>
#include <iostream>
using namespace std;
int main()
{
	int ai, bi, ci;
	float af, bf, cf;
	double ad, bd, cd;

	cout << "Write two simbols \n";
	cin >> ai >> bi;
	if (bi == 0)					//для int
	{
		cout << "False. B can not be 0.\n";
	}
	else
	{
		ci = ai / bi;
		cout << "Result: c= " << ci << " \n";
	}
	cout << "Write two simbols \n";
	cin >> af >> bf;
	if (bf == 0)						//для float
	{
		cout << "False. B can not be 0.\n";
	}
	else
	{
		cf = af / bf;
		cout << "Result: c= " << cf << " \n";
	}
	cout << "Write two simbols \n";
	cin >> ad >> bd;
	if (bd == 0)						//для double
	{
		cout << "False. B can not be 0.\n";
	}
	else
	{
		cd = ad / bd;
		cout << "Result: c= " << cd << " \n";
	}
	_getch();
}