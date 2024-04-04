#include <iostream>
#include <locale>

/*
 *	Fuction for calculating the arithmetic progression term by the given number
 *	Returns the n-th term of the progression
 */
float arpr(float first_term, float diff, int num)
{
	return first_term + (num - 1) * diff;
}

// Function checks if the number belongs to the arithmetic progression
bool arnumber(float first_term, float diff, float n_term)
{
	float n = ((n_term - first_term) / diff) + 1;
	if (n - (int)n == 0)
		return true;

	return false;
}

int main()
{
	float first_term, diff, n_term;
	int n;
	bool check;

	printf("Enter the first term of the arithmetic progression: ");
	scanf("%f", &first_term);

	printf("Enter the difference of the progression: ");
	scanf("%f", &diff);

	do
	{
		printf("Enter the number of arithmetic progression term: ");
		scanf("%d", &n);
	} while (n < 0);

	n_term = arpr(first_term, diff, n);
	printf("The %d-th term of arithmetic progression equals %.2f\n", n, n_term);

	// Pre-appropriation check
	printf("Enter any term of arithmetic progression: ");
	scanf("%f", &n_term);

	check = arnumber(first_term, diff, n_term);
	if (check)
		printf("The number belongs to an arithmetic progression\n");
	else
		printf("The number does not belong to an arithmetic progression\n");

	return 0;
}
