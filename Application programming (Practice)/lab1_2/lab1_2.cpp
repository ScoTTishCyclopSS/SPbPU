#include <stdio.h>
#include <iostream>
#include <string>
#include <unistd.h>

using namespace std;

int main()
{
    int m, s;

    do
    {
        cout << "Minutes: ";
        cin >> m;
    } while (m < 0 || m > 59);

    do
    {
        cout << "Seconds: ";
        cin >> s;
    } while (s < 0 || s > 59);
    
    while (true)
    {
        cout << "\r";

        // fill with 0
        cout.width(2);
        cout.fill('0');
        cout << m << ":";

        cout.width(2);
        cout.fill('0');
        cout << s << flush;

        sleep(1); // 1 sec step

        if (s > 0)
            s--;

        if (s == 0 && m > 0)
        {
            s = 59;
            m--;
        }

        if (s == 0 && m == 0)
        {
            cout << "\nTime is up!" << endl;
            break;
        }
    }
    
    return 0;
}
