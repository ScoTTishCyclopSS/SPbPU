#include <stdio.h>
#include <locale>
#include <conio.h>
#include <Windows.h>

int main()
{
	setlocale(LC_ALL, "Rus");
	int k = 0, N, i, Y_max, Y_min;
	int sum = 0, kchet = 0, sumchet = 0, knechet = 0, sumnechet = 0, sumcheti = 0, kcheti = 0;

	FILE *f; fopen_s(&f, "1.txt", "r");
	if (f == 0) //���������� �����
	{
		printf("���� 1.txt �� ������\n");
		_getch();
		return -1;
	}

	printf("���������� ��������� ������� � �� ��� ������� �� ����� 1.txt\n\n");
	fscanf_s(f, "%d", &N); //���������� ��������� �������
	printf("���������� ��������� �������: %d\n\n", N);

	int *Y = new int[N];

	printf("�������� ������\n");
	for (i = 0; i<N; i++)
	{
		fscanf_s(f, "%d", (Y + i));
		sum += *(Y + i); 	//����� ��������� �������
		if (*(Y + i) % 2 == 0) 	//����� � ���������� ������ ��������� �������
		{
			kchet++;
			sumchet += *(Y + i);
		}
		if (*(Y + i) % 2 != 0) 	//����� � ���������� �������� ��������� �������
		{
			knechet++;
			sumnechet += *(Y + i);
		}
		if (i % 2 == 0) //����� � ���������� ��������� ������� c ������� ���������
		{
			kcheti++;
			sumcheti += *(Y + i);
		}
	}

	for (i = 0; i < N; i++)
	{
		printf("%d ", *(Y + i));
	}

	printf("\n\n����� ��������� �������: %d \n", sum); 
	printf("\n����� ������ ��������� �������: %d \n", sumchet);
	printf("���������� ������ ��������� �������: %d \n", kchet); 
	printf("\n����� �������� ��������� �������: %d \n", sumnechet);
	printf("���������� �������� ��������� �������: %d \n", knechet); 
	printf("\n����� ��������� ������� � ������� ���������: %d \n", sumcheti);
	printf("���������� ��������� ������� � ������� ���������: %d \n", kcheti); 

	//������������ ������� �������
	Y_max = *Y;
	for (i = 0; i<N; i++)
	{
		if (*(Y + i) > Y_max)
		{
			Y_max = *(Y + i);
		}
	}
	printf("\n������������ ������� �������: %d \n", Y_max);

	//����������� ������� �������
	Y_min = *Y;
	for (i = 0; i<N; i++)
	{
		if (*(Y + i) < Y_min)
		{
			Y_min = *(Y + i);
		}
	}
	printf("\n����������� ������� �������: %d \n", Y_min);

	fclose(f);

	//������ ������� � �������� ������� � ��������� ����
	printf("\n\n������ � �������� �������\n�� ����� ������� � ���� 2.txt\n");
	FILE *fout; fopen_s(&fout, "2.txt", "wt");
	fprintf(fout, "������ � �������� �������\n");
	for (i = N - 1; i >= 0; i--)
	{
		fprintf(fout, "%d ", *(Y + i));
		printf("%d ", *(Y + i));
	}
	_getch();
	fclose(fout);

	return 0;
}
