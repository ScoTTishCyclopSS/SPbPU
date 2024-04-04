#include <iostream>
#include <fstream>
#include <string>
#include <unistd.h> // for usleep
#include <pthread.h>

using namespace std;

bool func;
pthread_mutex_t mut1, mut2;

// String output in color
bool line(bool isred, ifstream &in)
{
    string line;

    if (!getline(in, line)) // check if line can be read
        return false;

    if (isred)
        cout << "\033[1;31m" << line << "\033[0m" << endl; // red color
    else
        cout << "\033[1;37m" << line << "\033[0m" << endl; // white color

    return true;
}

// A process running in the background
void *process(void *)
{
    ifstream in("input.in");
    do
    {
        pthread_mutex_lock(&mut1);
        for (int i = 0; i < 5; i++)
            func = line(0, in);
        pthread_mutex_unlock(&mut2);
    } while (func);
    return NULL;
}

int main()
{
    ifstream in("input.in");
    if (!in.is_open()) 
    {
        cout << "File not found!!!" << endl;
        return 1;
    }
    
    pthread_t tid;
    pthread_mutex_init(&mut1, NULL);
    pthread_mutex_init(&mut2, NULL);

    pthread_create(&tid, NULL, &process, NULL);
    do
    {
        for (int i = 0; i < 3; i++)
            func = line(1, in);
        pthread_mutex_unlock(&mut1);
    } while (func);

    pthread_join(tid, NULL);
    pthread_mutex_destroy(&mut1);
    pthread_mutex_destroy(&mut2);
    return 0;
}
