#include <conio.h>
#include <stdio.h>
#include <iostream>
using namespace std;
int main()
{
	float ai, bi, ci;
	cout << "Write two simbols \n";
	cin >> ai >> bi;
	if (bi == 0)
	{
		cout << "False. B can not be 0.\n";
	}
	else
	{
		ci = ai / bi;
		cout << "Result: c= " << ci << " \n";
	}
	_getch();
}
