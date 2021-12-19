#include <stdio.h>
#include <conio.h>
int main(int argc, char*argv[])
{
	//argc = 1 + 1 = 2; argv[0] = argmain.exe; argv[1] = a1.txt;
	printf("argc = %d\nargv[0] = %s\nargv[1] = %s\n", argc, argv[0], argv[1]);
	FILE *f;
	if (argc != 2)
	{
		printf("Document is not defined! :(\n");
		return(-1);
	}
	fopen_s(&f, argv[1], "w");
	fprintf_s(f, "Hello, comrade!");
	printf("Done! :)\n");
	fclose(f);	
	_getch;
	return 0;
}