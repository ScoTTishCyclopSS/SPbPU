#include <stdio.h>
#include <conio.h>
#include <windows.h> //подключаем библиотеку Windows

int main()
{
	char s[100];	//допуск строки в 100 символов
	COORD position;
	printf("10 simbols !WRITE IN QUOTES!\n>|Your text here|<\n|");
	fgets(s, 11, stdin);
	HANDLE hConsole = GetStdHandle(STD_OUTPUT_HANDLE);	//активируем консоль Windows
	position.X = 11; position.Y = 2;	//добавляем позицию перемещения курсора
	SetConsoleCursorPosition(hConsole, position);	//перемещение курсора
	printf("|<< \n");	//вывод "ограничителя" на позиции перемещенного курсора
	printf("|%s|", s);
	_getch();
}