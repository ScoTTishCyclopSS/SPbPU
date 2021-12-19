#include <iostream>
#include <conio.h>
#include <locale>
#include <Windows.h>
#include <lib.h>
using namespace std;

void main()
{
	setlocale(LC_ALL, "Rus");
	SetConsoleCP(1251);
	SetConsoleOutputCP(1251);
	char *del, *add;
	int n1, n2;
	cout << "Введите строку текста: ";
	char str[100]; gets_s(str);
	cout << "Введите доп. строку: ";
	char substr[100]; gets_s(substr);
	cout << endl << "Введите позиции от и до, в пределах которых нужно удалить символы: ";
	cin >> n1 >> n2;
	cout << endl << "Начальная строка: " << str << endl << endl;
	del = delete_str(str, n1, n2);cout << endl;
	add = add_str(str, substr, n1, n2);
	if (del == NULL || add == NULL)
		cout << "Ошибка ввода диапазона!";
	else
	{
		cout << "Строка с удалением: " << endl << del << endl << endl;
		cout << "Строка с добавлением: " << endl << add;
	}
	_getch();
}