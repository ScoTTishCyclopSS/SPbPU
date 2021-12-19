#include <conio.h>
#include <stdio.h>
#include <math.h>
#include <iostream>
using namespace std;
int main()
{
	float sf, hf, vf, a, p, Ss, r, h, se;		//s-площадь основания, h-высота, v-объем, a-апофема, p-периметр, Ss-площадь боковой стороны, r-радиус, se-боковое ребро
	cout << "Programm to colculate the volume of the pyramid \n\n";
	cout << "Write value of two variables: S-footprint, H-height \n";
	cin >> sf >> hf;
	if (sf <= 0)						//для float
	{
		cout << "False. S can not be 0 or less.\n";
	}
	if (hf <= 0)
	{
		cout << "False. H can not be 0 or less.\n";
	}
	else {
		vf = (sf / 3)*hf;
		cout << "Result: V= " << vf << " \n\n";
	}

	cout <<"Programm to colculate the side area of the pyramid \n\n";
	cout <<"Write value of two variables: P-perimeter, A-apothem \n";
	cin >> p >> a;
	if (p <= 0)						//для float
	{
		cout << "False. P can not be 0 or less.\n";
	}
	if (a <= 0)
	{
		cout << "False. A can not be 0 or less.\n";
	}
	else
	{
		Ss = (p / 2)*a;
		cout << "Result: Ss= " << Ss << " \n\n";
	}
	cout << "Programm to colculate the lateral edge of the pyramid \n\n";
	cout << "Write value of two variables: H-height, R-radius \n";
	cin >> h >> r;
	if (h <= 0)						//для float
	{
		cout << "False. H can not be 0 or less.\n";
	}
	if (r <= 0)
	{
		cout << "False. R can not be 0 or less.\n";
	}
	else
	{
		se = sqrt(pow(h, 2) + pow(r, 2));
		cout << "Result: Se= " << se << " \n\n";
	}
	_getch();
}