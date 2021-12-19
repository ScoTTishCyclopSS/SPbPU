#include <iostream>
#include <stdio.h>
#include <ctime>
#include <iomanip>// � ������������ ����� <iomanip> ���������� �������� ������� setprecision() ������ �������� ��� ��������� �������.
using namespace std;

int main(int argc, char* argv[])
{
	setlocale(LC_ALL, "Russian");
	srand(time(0)); // ��������� ��������� �����
	int count, n; //count - ������ �������, j - ������ ��� ���������� �������, n - ���-�� ���������, k - ����� �������

	cout << "������� ���-�� ����� � ��������: "; cin >> n;
	int **ptrarray = new int*[n]; // �������� ������������� ������� ������������ ����� �� n ���������
	for (int count = 0; count < n; count++)
		*(ptrarray+count) = new int[n];

	for (int count_row = 0; count_row < n; count_row++)
		for (int count_column = 0; count_column < n; count_column++)
			*(*(ptrarray + count_row ) + count_column) =  (rand() % 1 + 1) / int((rand() % 1 + 1)); //���������� ������� ���������� ������� � ���������������� �� 1 �� 10
	
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
	cout << "\n������ k, ��� k ��� ������ ������� ��������� � k ��� ��������: ";
	for (int i = 0; i < n; i++)
		if (k[i])
			cout << i + 1 << " ";

	for (int count = 0; count < n; count++)
		delete[] * (ptrarray + count);
	cout << endl;
	system("pause");
	return 0;
}