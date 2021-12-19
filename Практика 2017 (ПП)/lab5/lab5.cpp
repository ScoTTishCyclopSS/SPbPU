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
	SetConsoleCP(1251); // Ввод с консоли в кодировке 1251
	SetConsoleOutputCP(1251); // Вывод на консоль в кодировке 1251. Нужно только будет изменить шрифт консоли на Lucida Console или Consolas
	ifstream file("1.txt"); // открыли файл с текстом
	string s, bukva;
	char c;
	int pos;
	cout << "Тыкни букву: ";
	cin >> bukva;
	cout << "\n";
	while (!file.eof()) // поиск
	{ 
		getline(file,s);
		if (s.find(bukva) != -1)
			cout << s << endl;
	}
	file.close();

	file.open("1.txt");
	cout << "\n\nПредложения с ин.язом (также запишуться в файл):\n\n";
	ofstream zap("2.txt");
	while (!file.eof()) // поиск
	{
		getline(file, s);
		if (latfind(s))
		{
			cout << s << endl;
			zap << s << endl;
		}
	}
	zap.close();
	file.close(); // обязательно закрыли
	system("Pause");
}