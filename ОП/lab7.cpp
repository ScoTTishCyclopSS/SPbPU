#include <stdio.h>
#include <locale>
#include <conio.h>
#include <Windows.h>
int main()
{
	int i=0, s = 0, T = 0, F = 0, g = 0;
	char str[51];
	FILE *fin; fopen_s(&fin, "1.txt", "r");
	if (fin == 0)
	{
		printf("File 1.txt not responding\n");
		_getch();
		return -1;
	}
	while (!feof(fin))     
	{
		fgets(str, 51, fin);
		printf("%s\n", str);
		for (i = 0; i < 50; i++)
		{
			if (str[i] == 'T' || str[i] == 't')
				T++;
			if (str[i] == 'F' || str[i] == 'f')
				F++;
			if (str[i] == ' ')
				s++;
		}
		g++;
	}
	fclose(fin);
	printf("Number of strings: %d\n", g);

	
	printf("Number of \"T\" letters: %d\n", T); 
	printf("Number of \"F\" letters: %d\n", F); 
	printf("Number of spaces: %d\n", s); 
	_getch();

	return 0;
}

