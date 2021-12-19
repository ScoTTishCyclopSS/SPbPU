#include <stdio.h>
#include "proverka.h"
#include <conio.h>
#include <math.h>
#include <windows.h>

int main()
{ 
	//проверить: h, s
	float s, h, v, p, a, ss, r, se;		//s-площадь основания, h-высота, v-объем, a-апофема, p-периметр, Ss-площадь боковой стороны, r-радиус, se-боковое ребро
	printf("Programm to colculate the volume of the pyramid: \n");
	printf("-----------------------------------------------\n");
	printf("Write value of two variables: S-footprint, H-height \n");
	printf("S");
	proverka(&s);
	printf("H");
	proverka(&h);
	v = (s / 3)*h;
	printf("Result: V = %2.f\n\n", v);

	printf("Programm to colculate the side area of the pyramid: \n");
	printf("-----------------------------------------------\n");
	printf("Write value of two variables: P-perimeter, A-apothem \n");
	printf("P");
	proverka(&p);
	printf("A");
	proverka(&a);
	ss = (p / 2)*a;
	printf("Result: Ss= %2.f \n\n", ss);

	printf("Programm to colculate the lateral edge of the pyramid: \n");
	printf("-----------------------------------------------\n");
	printf("Write value of two variables: H-height, R-radius \n");
	printf("H");
	proverka(&h);
	printf("R");
	proverka(&r); 
	se = sqrt(pow(h, 2) + pow(r, 2));
	printf("Result: Se= %2.f \n\n", se);

	system("pause");
}
