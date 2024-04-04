#include <iostream>
#include <ctime>
#include <dirent.h>
#include <sys/stat.h>

#define UTC (+2)

using namespace std;

void Beep(int frequency, int duration)
{
	string command = "beep -f " + to_string(frequency) + " -l " + to_string(duration);
	system(command.c_str());
}

int main()
{
	time_t t = time(NULL);
	struct tm *t_m = localtime(&t);

	cout << "Current time is: " << ctime(&t);

	float morning = t_m->tm_hour * 60 + t_m->tm_min + t_m->tm_sec / 60;

	// morning interval in minutes
	int m1 = 500;
	int m2 = 1200;

	if (morning >= m1 && morning <= m2)
	{
		cout << "Good morning!" << endl;
		Beep(1000, 500);
		
		DIR *dir;
		struct dirent *ent;

		if ((dir = opendir("./")) != NULL) // curr dir
		{
			while ((ent = readdir(dir)) != NULL)
			{
				struct stat statbuf;
				stat(ent->d_name, &statbuf);

				time_t modified_time = statbuf.st_mtime;
				struct tm *mod_tm = localtime(&modified_time);
				int make = mod_tm->tm_hour * 60 + mod_tm->tm_min + t_m->tm_sec / 60;

				if (make >= m1 && make <= m2)
				{
					printf("%s -> %d:%d:%d\n", ent->d_name, mod_tm->tm_hour, mod_tm->tm_min, t_m->tm_sec);
				}
			}
			closedir(dir);
		}
		else
		{
			perror("Failed to open directory");
			return 1;
		}
	}

	return 0;
}