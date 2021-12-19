#include <conio.h>
#include <locale>

struct clientData
{
	int acctNum;
	char lastName[15];
	char firstName[10];
	float balance;
};


int main()
{
	int i;
	struct clientData blankClient = { 0, "", "", 0.0 };
	FILE *cfPtr; fopen_s(&cfPtr, "credit.dat", "w");
	for (i = 1; i <= 100; i++)
		fwrite(&blankClient, sizeof(struct clientData), 1, cfPtr);
	fclose(cfPtr);
	printf("the file credit.dat has been created");


	struct clientData client;
	FILE *cfPtr; fopen_s(&cfPtr, "credit.dat", "r+");
	if (cfPtr == 0)
	{
		printf("The file can't be open\n");
		_getch();
	}
	else {
		printf("Write the number in the period by 1 to 100\n");
		scanf_s("%d", &client.acctNum);

		while (client.acctNum != 0)
		{
			printf("Enter the name, surname and balance\n");
			//scanf_s("%*s%*s%*f", &client.lastName, &client.firstName, &client.balance);
			scanf_s("%14s", &client.lastName, _countof(client.lastName));
			scanf_s("%9s", &client.firstName, _countof(client.firstName));
			scanf_s("%f", &client.balance);
			fseek(cfPtr, (client.acctNum - 1) * sizeof(struct clientData), SEEK_SET);
			fwrite(&client, sizeof(struct clientData), 1, cfPtr);
			printf("Write 0 to exit\n");
			scanf_s("%d", &client.acctNum);
		}
	}
	fclose(cfPtr);


	FILE *cfPtr;
	struct clientData client;
	fopen_s(&cfPtr, "credit.dat", "r");
	if (cfPtr == 0)
	{
		printf("The file can't be open \n");
		_getch();
	}
	else {
		printf("%-6s%-16s%-11s%10s\n", "Acct", "Last Name", "First Name", "Balance");
		while (!feof(cfPtr))
		{
			fread(&client, sizeof(struct clientData), 1, cfPtr);
			if (client.acctNum != 0)
				printf("%-6d%-16s%-11s%10.2f\n", client.acctNum, client.lastName, client.firstName, client.balance);
		}
	}
	_getch();

	fclose(cfPtr);



	_getch();
	return 0;
}