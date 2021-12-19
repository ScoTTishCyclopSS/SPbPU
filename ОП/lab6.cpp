#include <stdio.h>
#include <locale>
#include <conio.h>
#include <cstdio>
//using namespace std;

int main()
{
	setlocale(LC_ALL, "Rus");
	int a, b, s, p;
	FILE *fin; fopen_s(&fin, "qwerty.txt", "r");
	if (fin == 0) //отсутствие файла
	{
		printf("Файл qwerty.txt не найден\n");
		_getch();
		return -1;
	}

	fscanf_s(fin, "%d%d", &a, &b);
	fclose(fin);
	s = a * b;
	p = 2 * (a + b);
	FILE *fout; fopen_s(&fout, "Текст2.txt", "wt");
	fprintf(fout, "%d %d", s, p);
	system("cd");
	fclose(fout);
	printf("a = %d\t b = %d\t s = %d\t p = %d\n", a, b, s, p);
	_getch();
	return 0;
}
