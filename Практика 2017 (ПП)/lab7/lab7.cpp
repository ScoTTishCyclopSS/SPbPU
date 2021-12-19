#include <iostream>
#include <conio.h>
#include <windows.h>
#include <time.h>
#include <ctime>   
#define UTC (+3)    

using namespace std;

int main()
{
	time_t t;
	struct tm *t_m;
	t = time(NULL);
	t_m = localtime(&t);
	cout << "Current time is: " << ctime(&t);
	float utro = t_m->tm_hour * 60 + t_m->tm_min + t_m->tm_sec/60;
	if (utro >= 525 && utro <= 1000) //675
	{
		cout << "Good morning!\n";
		Beep(784, 150);Sleep(300);Beep(784, 150);Sleep(300);
		Beep(932, 150);Sleep(150);Beep(1047, 150);Sleep(150);
		Beep(784, 150);Sleep(300);Beep(784, 150);Sleep(300);
		Beep(699, 150);Sleep(150);Beep(740, 150);Sleep(150);
		Beep(784, 150);Sleep(300);Beep(784, 150);Sleep(300);
		Beep(932, 150);Sleep(150);Beep(1047, 150);Sleep(150);
		Beep(784, 150);Sleep(300);Beep(784, 150);Sleep(300);
		Beep(699, 150);Sleep(150);Beep(740, 150);Sleep(150);
		Beep(932, 150);Beep(784, 150);Beep(587, 1200);Sleep(75);
		Beep(932, 150);Beep(784, 150);Beep(554, 1200);Sleep(75);
		Beep(932, 150);Beep(784, 150);Beep(523, 1200);Sleep(150);
		Beep(466, 150);Beep(523, 150);Beep(784, 150);Sleep(300);
		Beep(784, 150);Sleep(300);Beep(932, 150);Sleep(150);
		Beep(1047, 150);Sleep(150);Beep(784, 150);Sleep(300);
		Beep(784, 150);Sleep(300);Beep(699, 150);Sleep(150);
		Beep(740, 150);Sleep(150);Beep(784, 150);
		SYSTEMTIME time;
		WIN32_FIND_DATAW wfd;
		HANDLE const hFind = FindFirstFileW(L"F:\\1\\2\\*.txt", &wfd);
		if (INVALID_HANDLE_VALUE != hFind)
		{
			do
			{
				FileTimeToSystemTime(&wfd.ftCreationTime, &time);
				float make = (time.wHour + UTC) * 60 + time.wMinute + time.wSecond/60;
				if (make >= 525 && make <= 960)
				wcout << wfd.cFileName << ' ' << (time.wHour + UTC) << ':' << time.wMinute << ':' << time.wSecond << std::endl;
			} 
			while (NULL != FindNextFileW(hFind, &wfd));
			FindClose(hFind);
		}
	}
	_getch();
}