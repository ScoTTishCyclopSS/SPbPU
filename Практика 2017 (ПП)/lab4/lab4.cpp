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
	cout << "������� ������ ������: ";
	char str[100]; gets_s(str);
	cout << "������� ���. ������: ";
	char substr[100]; gets_s(substr);
	cout << endl << "������� ������� �� � ��, � �������� ������� ����� ������� �������: ";
	cin >> n1 >> n2;
	cout << endl << "��������� ������: " << str << endl << endl;
	del = delete_str(str, n1, n2);cout << endl;
	add = add_str(str, substr, n1, n2);
	if (del == NULL || add == NULL)
		cout << "������ ����� ���������!";
	else
	{
		cout << "������ � ���������: " << endl << del << endl << endl;
		cout << "������ � �����������: " << endl << add;
	}
	_getch();
}