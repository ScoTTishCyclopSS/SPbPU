#include <iostream>
#include <string>
#include <fstream>
#include <sstream>
#include <windows.h>
using namespace std;

bool IsSquare(int n,)//используется тот факт, что любой квадрат это сумма последовательных нечетных чисел
{ 
	int i = 1;
	while (n>0)
	{
		n -= i;
		i += 2;
	};
	if (n == 0)return true;
	return false;
};


void main()
{
	setlocale(0, ""); // локализация
	int n = 0, x = 1; // i - счетчик, n - количество чисел
	ofstream F("1.bin", std::ios::binary); // создание файловой переменной, поток для записи в файл
	ofstream F2("2.bin", std::ios::binary);
	if (F.fail()) // если открытие файла прошло некорректно, то
	{
		cerr << "Ошибка открытия файла. Проверьте местоположение и имя файла! \n"; // вывод сообщения об ошибке
	}
	else
	{
		cout << "Введите n = ";
		cin >> n; cout << endl;
		
		for (int i = 1; i <= n; i++)// цикл для ввода целых чисел и записи их в файл
		{
			F.write((char*)&i, sizeof(int));
			cout << i << ' ';
		}
		cout <<"\n";
		for (int i = 1; i <= n; i++)// цикл для ввода целых чисел и записи их в файл
		{
			int i2 = i*i;
			if (i2 < n)
			{
				F2.write((char*)&i2, sizeof(int));
				cout << i2 << ' ';
			}
		}
	}
	cout << "\n";
	F.close(); // закрытие потока
	F2.close();
	system("pause");
}