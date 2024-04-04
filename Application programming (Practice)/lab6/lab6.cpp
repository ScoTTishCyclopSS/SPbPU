#include <iostream>
#include <string>
#include <queue>

using namespace std;

// Prints the queue
template <typename T>
void print(queue<T> q, string invite)
{
    cout << invite;

    while (!q.empty())
    {
        cout << q.front() << " ";
        q.pop();
    }
    cout << endl;
}

// Performs the operation of swapping the first and the last queue element
template <typename T>
queue<T> replace(queue<T> q)
{
    queue<T> result;
    result.push(q.back());
    T tmp = q.front();
    q.pop();

    while (q.size() > 1)
    {
        result.push(q.front());
        q.pop();
    }

    result.push(tmp);
    return result;
}


// Reads the input and creates a queue from it
template <typename T>
queue<T> read(int n, string invite)
{
    queue<T> q;
    T element;

    cout << invite;
    for (int i = 0; i < n; i++)
    {
        cin >> element;
        q.push(element);
    }

    return q;
}

int main()
{
    int n;

    do
    {
        cout << "Enter queue length: ";
        cin >> n;
    } while (n <= 0 || n == 1);
    
    queue<int> queue = read<int>(n, "Queue: ");
    print(replace(queue), "Queue after switch: ");

    return 0;
}
