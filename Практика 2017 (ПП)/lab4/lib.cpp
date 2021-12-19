#include <iostream>
using namespace std;

char* delete_str(char str[], int n1, int n2)
{
	int n = strlen(str);
	if (n1 < 0 || n2 < 0 || n1 > n2 || n < n1 || n < n2)
		return NULL;
	else
	{
		char *resultdel = new char[n];
		for (int i = 0; i <= n1; i++)
			resultdel[i] = str[i]; //���������� ������� �������� ������ �� ������ ������� ���������
		for (int i = n2; i < n; i++)
			resultdel[i - (n2 - n1)] = str[i]; //��������
		resultdel[n - (n2 - n1)] = '\0';
		return resultdel;
	}
}

char* add_str(char str[], char substr[], int n1, int n2)
{
	int n = strlen(str);
	int nsub = strlen(substr);
	if (n1 < 0 || n2 < 0 || n1 > n2 || n < n1 || n < n2)
		return NULL;
	else
	{
		char *resultadd = new char[n + nsub];
		int i; //������� �������� ������
		int j; //����� �������������� ������
		for (i = j = 0; i < n1; i++, j++)
			resultadd[j] = str[i]; //���������� �������� ������ �� ������ ���������
		for (i = 0; i < nsub; i++, j++)
			resultadd[j] = substr[i]; //���������� ��������� � �������������� ������ 
		for (i = n2; i < n; i++, j++)
			resultadd[j] = str[i]; //� ����� �������������� ������(����� ������� ����� ���������) ���������� ���������� ������� �������� ������
		resultadd[j] = '\0';
		return resultadd;
	}
}