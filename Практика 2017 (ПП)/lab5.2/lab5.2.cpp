#include <iostream>
#include <string>
#include <fstream>
#include <sstream>
#include <windows.h>
using namespace std;

bool IsSquare(int n,)//������������ ��� ����, ��� ����� ������� ��� ����� ���������������� �������� �����
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
	setlocale(0, ""); // �����������
	int n = 0, x = 1; // i - �������, n - ���������� �����
	ofstream F("1.bin", std::ios::binary); // �������� �������� ����������, ����� ��� ������ � ����
	ofstream F2("2.bin", std::ios::binary);
	if (F.fail()) // ���� �������� ����� ������ �����������, ��
	{
		cerr << "������ �������� �����. ��������� �������������� � ��� �����! \n"; // ����� ��������� �� ������
	}
	else
	{
		cout << "������� n = ";
		cin >> n; cout << endl;
		
		for (int i = 1; i <= n; i++)// ���� ��� ����� ����� ����� � ������ �� � ����
		{
			F.write((char*)&i, sizeof(int));
			cout << i << ' ';
		}
		cout <<"\n";
		for (int i = 1; i <= n; i++)// ���� ��� ����� ����� ����� � ������ �� � ����
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
	F.close(); // �������� ������
	F2.close();
	system("pause");
}