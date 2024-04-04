#include <iostream>
#include <locale>
#include <string.h>
#include "lib.h"

int main()
{

	int n1, n2;
	char *del, *add;
	char str[100], substr[100];

	printf("Enter the main string: ");
	fgets(str, sizeof(str), stdin);
	str[strlen(str) - 1] = '\0'; // remove the newline character

	printf("Enter the substring: ");
	fgets(substr, sizeof(substr), stdin);
	substr[strlen(substr) - 1] = '\0';

	printf("Enter the start and end indices (separated by space): ");
	scanf("%d %d", &n1, &n2);

	del = delete_str(str, n1, n2);
	add = add_str(str, substr, n1, n2);

	if (del == NULL || add == NULL)
		printf("Failed to perform the operations!\n");
	else
	{
		printf("After deletion: %s\n", del);
		printf("After addition: %s\n", add);
	}

	return 0;
}