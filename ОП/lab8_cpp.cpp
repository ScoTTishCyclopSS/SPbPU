#include <stdio.h>
#include <conio.h>
#include <windows.h> //���������� ���������� Windows
#include <iostream>
using namespace std;

int main()
{
	char s[100];	//������ ������ � 100 ��������
	COORD position;
	cout << "10 simbols !WRITE IN QUOTES!\n>|Your text here|<\n|";
	fgets(s, 11, stdin);
	HANDLE hConsole = GetStdHandle(STD_OUTPUT_HANDLE);	//���������� ������� Windows
	position.X = 11; position.Y = 2;	//��������� ������� ����������� �������
	SetConsoleCursorPosition(hConsole, position);	//����������� �������
	cout << "|<< \n";	//����� "������������" �� ������� ������������� �������
	cout << "|" << s << "|";
	_getch();
}