#include <stdio.h>
#include <conio.h>
#include <locale>

struct clientData{
	int acctNum;
	char lastName[15];
	char firstName[10];
	float balance;
};

int main()
{
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

	return 0;
}