#include <iostream>
#include <string>
#include <fstream>
#include <sstream>
#include <windows.h>
using namespace std;

bool latfind(string s)
{
	for each (char c in s)
	{
		if (c >= 'A' && c <= 'Z' || c >= 'a' && c <= 'z')
			return true;
	}
	return false;
}
int main()
{
	SetConsoleCP(1251); // ���� � ������� � ��������� 1251
	SetConsoleOutputCP(1251); // ����� �� ������� � ��������� 1251. ����� ������ ����� �������� ����� ������� �� Lucida Console ��� Consolas
	ifstream file("1.txt"); // ������� ���� � �������
	string s, bukva;
	char c;
	int pos;
	cout << "����� �����: ";
	cin >> bukva;
	cout << "\n";
	while (!file.eof()) // �����
	{ 
		getline(file,s);
		if (s.find(bukva) != -1)
			cout << s << endl;
	}
	file.close();

	file.open("1.txt");
	cout << "\n\n����������� � ��.���� (����� ���������� � ����):\n\n";
	ofstream zap("2.txt");
	while (!file.eof()) // �����
	{
		getline(file, s);
		if (latfind(s))
		{
			cout << s << endl;
			zap << s << endl;
		}
	}
	zap.close();
	file.close(); // ����������� �������
	system("Pause");
}