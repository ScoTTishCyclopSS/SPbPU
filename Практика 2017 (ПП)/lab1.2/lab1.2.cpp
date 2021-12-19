#include <conio.h>
#include <stdio.h>
#include <iostream>
#include <string>
#include <windows.h>
#include <time.h>
using namespace std;
int main()
{
	setlocale(LC_ALL, "Russian");
	int m, s; // минуты и секунды
	cout << "¬ведите минуты: ";
	cin >> m;
	if (m < 0 || m > 59) //проверка на корректность ввода минут
	{
		cout << "¬ведите минуты корректно!";
		_getch();
		exit(0);
	}
	cout << "¬ведите секунды: ";
	cin >> s;
	if (s < 0 || s > 59) //проверка на корректность ввода секунд
	{
		cout << "¬ведите секунды корректно!";
		_getch();
		exit(0);
	}

	while (true)
	{
		system("CLS");
		HANDLE hd = GetStdHandle(STD_OUTPUT_HANDLE);//ввыод по центру консоли
		COORD cd;
		cd.X = 35;
		cd.Y = 10;
		SetConsoleCursorPosition(hd, cd);

		cout.width(2);//заполнение таймера нул€ми
		cout.fill('0');
		cout << m << ":";
		cout.width(2);
		cout.fill('0');
		cout << s;

		Sleep(1000);//шаг в одну секунду
		if (s > 0)
			s--;
		if (s == 0 && m > 0)
		{
			s = 59;
			m--;
		}
		
		if (s == 0 && m == 0)//конец таймера
		{	
			HANDLE hd = GetStdHandle(STD_OUTPUT_HANDLE);//вывод по центру консоли сообщени€
			COORD cd;
			cd.X = 30;
			cd.Y = 10;
			SetConsoleCursorPosition(hd, cd);
			cout << "¬рем€ истекло!" << endl;
			break;
		}		
	}
	system("Pause");
}