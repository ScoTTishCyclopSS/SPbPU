#include <iostream>
#include <stdio.h>
#include <ctime>
#include <iomanip>// � ������������ ����� <iomanip> ���������� �������� ������� setprecision() ������ �������� ��� ��������� �������.
using namespace std;

int main(int argc, char* argv[])
{
	setlocale(LC_ALL, "Russian");
	srand(time(0)); // ��������� ��������� �����
	int count, k, j, n; //count - ������ �������, j - ������ ��� ���������� �������, n - ���-�� ���������, k - ����� �������
	float buf; //�����, �������� ����������� ������

	cout << "������� ���-�� ���������: ";cin >> n;	
	cout << "������� �����: "; cin >> k;
	float *ptrarray = new float[n]; // �������� ������������� ������� ������������ ����� �� n ���������
	
	for (count = 0; count < n; count++)//���������� ������� ���������� ������� � ���������������� �� 1 �� 10
		*(ptrarray + count) = (rand() % 10 + 1) / float((rand() % 10 + 1));
	
	cout << "/ array / \n";
	for (count = 0; count < n; count++)//����� �������
		cout << setprecision(2) << *(ptrarray + count) << "\n";

	for (count = 0; count < k; count++)//����� �� k �������
		{
			buf = ptrarray[n - 1]; //������ � �����

			for (j = n - 1; j > 0; j--)
				*(ptrarray + j) = ptrarray[j - 1];//���������� ���������� �������
				ptrarray[0] = buf; //������� ������
		}

	cout << "\n/����� ��������� ������� �� "  << k <<" �������:/ \n";
	for (count = 0; count < n; count++)//����� ���������� �������
		cout << setprecision(2) << *(ptrarray + count) << "\n";

	delete[] ptrarray; // ������������� ������
	cout << endl;
	system("pause");
	return 0;
}