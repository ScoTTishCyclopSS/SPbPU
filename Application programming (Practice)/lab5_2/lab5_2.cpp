#include <iostream>
#include <string>
#include <fstream>
#include <sstream>

using namespace std;

// Checks if a given number 'n' is a perfect square
bool isPerfectSquare(int n)
{
	int i = 1;
	
	while (n > 0)
	{
		n -= i;
		i += 2;
	}

	if (n == 0)
		return true;

	return false;
}

int main()
{
	int n = 0;

	ofstream file1("nums.in");
	ofstream file2("perfectSquares.in");

	if (file1.fail())
	{
		cerr << "Error writing into file1!" << std::endl;
		return 1;
	}

	cout << "Enter max value: ";
	cin >> n;

	for (int i = 1; i <= n; i++)
	{
		file1 << i << ' ';
		cout << i << ' ';
	}
	cout << endl;

	for (int i = 1; i <= n; i++)
	{
		if (isPerfectSquare(i))
		{
			file2 << i << ' ';
			cout << i << ' ';
		}
	}
	cout << endl;

	file1.close();
	file2.close();

	return 0;
}