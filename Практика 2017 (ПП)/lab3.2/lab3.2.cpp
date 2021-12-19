#include <iostream>
#include <stdio.h>
#include <ctime>
#include <iomanip>// в заголовочном файле <iomanip> содержится прототип функции setprecision() Задает точность для плавающей запятой.
using namespace std;

int main(int argc, char* argv[])
{
	setlocale(LC_ALL, "Russian");
	srand(time(0)); // генерация случайных чисел
	int count, n; //count - индекс массива, j - индекс для сдвинутого массива, n - кол-во элементов, k - сдвиг позиций

	cout << "Введите кол-во строк и столбцов: "; cin >> n;
	int **ptrarray = new int*[n]; // создание динамического массива вещественных чисел на n элементов
	for (int count = 0; count < n; count++)
		*(ptrarray+count) = new int[n];

	for (int count_row = 0; count_row < n; count_row++)
		for (int count_column = 0; count_column < n; count_column++)
			*(*(ptrarray + count_row ) + count_column) =  (rand() % 1 + 1) / int((rand() % 1 + 1)); //заполнение массива случайными числами с масштабированием от 1 до 10
	
	cout << "/ array / \n";
	for (int count_row = 0; count_row < n; count_row++)
	{
		for (int count_column = 0; count_column < n; count_column++)
			cout << setw(4) << *(*(ptrarray + count_row) + count_column) << "   ";
		cout << endl;
	}
	bool *k = new bool[n];
	for (int i = 0; i < n; i++)
	{
		k[i] = true;
		for (int j = 0; j < n; j++)
			if (*(*(ptrarray + i) + j) != *(*(ptrarray + j) + i))
			{
				k[i] = false;
				break;
			}
	}
	cout << "\nНомера k, что k –ая строка матрицы совпадает с k –ым столбцом: ";
	for (int i = 0; i < n; i++)
		if (k[i])
			cout << i + 1 << " ";

	for (int count = 0; count < n; count++)
		delete[] * (ptrarray + count);
	cout << endl;
	system("pause");
	return 0;
}