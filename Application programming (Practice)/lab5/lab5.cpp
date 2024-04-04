#include <iostream>
#include <fstream>
#include <string>
#include <cstring>

using namespace std;

// Iterates over string and checks if the character is alphabetic (latin)
bool latfind(string s)
{
	for (char c : s)
		if (c >= 'A' && c <= 'Z' || c >= 'a' && c <= 'z')
			return true;

	return false;
}

int main()
{
	ifstream file_in("input.in");
	if (!file_in.is_open())
	{
		cerr << "Error opening input file!" << std::endl;
		return 1;
	}

	string line, substr;
	int pos;

	cout << "Enter a string to find: "; // try 'amet'
	cin >> substr;

	// search for lines, which contain substring
	cout << "Lines, which contain \"" << substr << "\":" << endl;
	cout << "----------------------------------------" << endl;
	while (!file_in.eof())
	{
		getline(file_in, line);
		if (line.find(substr) != -1)
			cout << line << endl;
	}

	// reset file position to beginning
	file_in.clear();
    file_in.seekg(0);

	ofstream file_out("output.out");
	if (!file_out.is_open())
    {
        cerr << "Error opening output file!" << endl;
        return 1;
    }

	// search for lines, which contain Latin characters by using custom func
	cout << "\nLines, which contain Latin characters:" << endl;
	cout << "----------------------------------------" << endl;
	while (!file_in.eof())
	{
		getline(file_in, line);
		if (latfind(line))
		{
			cout << line << endl;
			file_out << line << endl;
		}
	}

	file_in.close();
	file_out.close();

	return 0;
}