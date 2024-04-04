#include <stdio.h>
#include <iostream>

int main()
{
	const char *months[12] = {"Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"};
	const int days[12] = {31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31};
	int day_num = -1;

	printf("Enter the day number of the year from 1 to 365: ");
	scanf("%d", &day_num);

	if (day_num <= 0 || day_num > 365)
	{
		printf("Enter the day in the correct range!\n\n");
		return 1;
	}

	int check_day = 0;

	for (int i = 0; i < 12; check_day += days[i], i++)
	{
		if (check_day < day_num && day_num <= check_day + days[i])
		{
			printf("The %d'th day of the year is %d of %s\n", day_num, day_num - check_day, months[i]);
			break;
		}
	}

	return 0;
}