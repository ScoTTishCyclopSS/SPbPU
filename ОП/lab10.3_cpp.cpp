#include <stdio.h>
#include <Windows.h>
#include <math.h>	
#include <iostream>
using namespace std;
struct clientData {
	int acctNum;
	char lastName[15];
	char firstName[10];
	float balance;
};
/// creates blank file "credit.dat" ---œ–» ¬€¡Œ–≈ ÷≈À» œ–Œ√–¿ÃÃ€ ¬—“¿¬Àﬂ≈Ã Õ”∆Õ”ﬁ Õ¿Ã ‘”Õ ÷»ﬁ ¬ MAIN
int blank();
/// enters	
int enter();
/// formatted print to console from "credit.dat"
int print();
int main()
{
	blank();
	system("pause");
}
int blank() {
	int i;
	FILE *cfPtr;
	struct clientData blankClient = { 0, "", "", 0.0 };

	fopen_s(&cfPtr, "credit.dat", "wb");

	for (i = 0; i < 100; i++)
		fwrite(&blankClient, sizeof(clientData), 1, cfPtr);

	fclose(cfPtr);
	cout << "Created credit.dat";
	return 0;
}
int enter() {
	FILE *cfPtr;
	struct clientData client;
	fopen_s(&cfPtr, "credit.dat", "r+");
	cout << "Enter account number (1 to 100, 0 to end input)\n> ";
	cin >> "%d" &client.acctNum;
	while ((client.acctNum > 0) & (client.acctNum <= 100)) {
		cout << "Enter lastname, firstname, balance\n> ";
		cin >> "%s%s%f" >> client.lastName, (rsize_t)sizeof client.lastName, &client.firstName, (rsize_t)sizeof client.firstName, &client.balance;
		fseek(cfPtr, (client.acctNum - 1) * sizeof(clientData), SEEK_SET);
		fwrite(&client, sizeof(clientData), 1, cfPtr);
		cout <<"Enter account number\n> ";
		cin >> "%d" &client.acctNum;
	}
	fclose(cfPtr);
	return(0);
}
int print() {
	FILE *cfPtr;
	struct clientData client;
	fopen_s(&cfPtr, "credit.dat", "r");
	cout << "%-4s | %-15s | %-10s | %10s\n", "Acct", "Last Name", "First Name", "Balance";
	cout <<"-----|-----------------|------------|-----------\n";
	while (!feof(cfPtr)) {
		fread(&client, sizeof(clientData), 1, cfPtr);
		if ((client.acctNum > 0) & (client.acctNum <= 100))
			cout <<"%-4d | %-15s | %-10s | %10.2f\n",
			client.acctNum,
			client.lastName,
			client.firstName,
			client.balance;
	}
	cout <<"-----|-----------------|------------|-----------\n";
	fclose(cfPtr);
	return(0);
}
