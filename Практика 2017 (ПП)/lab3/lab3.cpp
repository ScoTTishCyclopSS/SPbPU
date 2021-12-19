#include <iostream>
#include <stdio.h>
#include <ctime>
#include <iomanip>// в заголовочном файле <iomanip> содержится прототип функции setprecision() Задает точность для плавающей запятой.
using namespace std;

int main(int argc, char* argv[])
{
	setlocale(LC_ALL, "Russian");
	srand(time(0)); // генерация случайных чисел
	int count, k, j, n; //count - индекс массива, j - индекс для сдвинутого массива, n - кол-во элементов, k - сдвиг позиций
	float buf; //буфер, хранящий сортируемый массив

	cout << "Введите кол-во элементов: ";cin >> n;	
	cout << "Введите сдвиг: "; cin >> k;
	float *ptrarray = new float[n]; // создание динамического массива вещественных чисел на n элементов
	
	for (count = 0; count < n; count++)//заполнение массива случайными числами с масштабированием от 1 до 10
		*(ptrarray + count) = (rand() % 10 + 1) / float((rand() % 10 + 1));
	
	cout << "/ array / \n";
	for (count = 0; count < n; count++)//вывод массива
		cout << setprecision(2) << *(ptrarray + count) << "\n";

	for (count = 0; count < k; count++)//сдвиг на k позиций
		{
			buf = ptrarray[n - 1]; //запись в буфер

			for (j = n - 1; j > 0; j--)
				*(ptrarray + j) = ptrarray[j - 1];//заполнение сдвинутого массива
				ptrarray[0] = buf; //очистка буфера
		}

	cout << "\n/Сдвиг элементов массива на "  << k <<" позиций:/ \n";
	for (count = 0; count < n; count++)//вывод сдвинутого массива
		cout << setprecision(2) << *(ptrarray + count) << "\n";

	delete[] ptrarray; // высвобождение памяти
	cout << endl;
	system("pause");
	return 0;
}