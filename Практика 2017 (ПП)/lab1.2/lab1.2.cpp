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
	int m, s; // ������ � �������
	cout << "������� ������: ";
	cin >> m;
	if (m < 0 || m > 59) //�������� �� ������������ ����� �����
	{
		cout << "������� ������ ���������!";
		_getch();
		exit(0);
	}
	cout << "������� �������: ";
	cin >> s;
	if (s < 0 || s > 59) //�������� �� ������������ ����� ������
	{
		cout << "������� ������� ���������!";
		_getch();
		exit(0);
	}

	while (true)
	{
		system("CLS");
		HANDLE hd = GetStdHandle(STD_OUTPUT_HANDLE);//����� �� ������ �������
		COORD cd;
		cd.X = 35;
		cd.Y = 10;
		SetConsoleCursorPosition(hd, cd);

		cout.width(2);//���������� ������� ������
		cout.fill('0');
		cout << m << ":";
		cout.width(2);
		cout.fill('0');
		cout << s;

		Sleep(1000);//��� � ���� �������
		if (s > 0)
			s--;
		if (s == 0 && m > 0)
		{
			s = 59;
			m--;
		}
		
		if (s == 0 && m == 0)//����� �������
		{	
			HANDLE hd = GetStdHandle(STD_OUTPUT_HANDLE);//����� �� ������ ������� ���������
			COORD cd;
			cd.X = 30;
			cd.Y = 10;
			SetConsoleCursorPosition(hd, cd);
			cout << "����� �������!" << endl;
			break;
		}		
	}
	system("Pause");
}