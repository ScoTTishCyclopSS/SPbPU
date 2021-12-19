#include <stdio.h>
#include <locale>
#include <conio.h>
#include <cstdio>
int main()
{
	int s, v, h;
	int ss, p, a;
	int se, r;
	FILE *fin; fopen_s(&fin, "1.txt", "r");
	if (fin == 0) //отсутствие файла
	{
		printf("File 1.txt not responding\n");
		_getch();
		return -1;
	}
	fscanf_s(fin, "%d%d%d%d%d", &s, &h, &p, &a, &r);
	fclose(fin);
	v = (s / 3)*h;
	ss = (p / 2)*a;
	se = sqrt(pow(h, 2) + pow(r, 2));
	FILE *fout; fopen_s(&fout, "2.txt", "wt");
	fprintf(fout, "%d %d %d", v, ss, se);
	system("cd");
	fclose(fout);
	printf("S = %d\t H = %d ---> V = %d\nP = %d\t A = %d ---> SS = %d\nR = %d\t H = %d ---> SE = %d", s, h, v, p, a, ss, r, h, se);
	_getch();
	return 0;
}
