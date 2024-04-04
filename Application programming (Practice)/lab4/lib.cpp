#include <iostream>
#include <string.h>

// Deletes the characters in string in specified interval from 'n1' to 'n2'
char *delete_str(char str[], int n1, int n2)
{
	int n = strlen(str);

	if (n1 < 0 || n2 < 0 || n1 > n2 || n < n1 || n < n2)
		return NULL;

	char *resultdel = new char[n];

	// copy from 0 to n1
	for (int i = 0; i < n1; i++)
		resultdel[i] = str[i];

	// copy from n2 to end
	for (int i = n1, j = n2; j < n; i++, j++)
		resultdel[i] = str[j];

	return resultdel;
}

// Adds the characters from substring into string in specified interval from 'n1' to 'n2'
char *add_str(char str[], char substr[], int n1, int n2)
{
	int n = strlen(str);
	int nsub = strlen(substr);

	if (n1 < 0 || n2 < 0 || n1 > n2 || n < n1 || n < n2)
		return NULL;

	char *resultadd = new char[n + nsub];

	// copy from 0 to n1
	for (int i = 0; i < n1; i++)
		resultadd[i] = str[i];

	// insert the substring
	for (int i = n1, j = 0; j < nsub; i++, j++)
		resultadd[i] = substr[j];

	// copy from n2 to end
	for (int i = n1 + nsub, j = n2; j < n; i++, j++)
		resultadd[i] = str[j];

	return resultadd;
}
