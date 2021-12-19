#include <stdio.h>
#include <conio.h>
void functionc() //реализация с помощью C
{
    printf("Function C\n");
    char text[400];                        //задаем размерность строки
    FILE *file = fopen("text2.txt", "rt"); //открытие файла
    if (file == NULL)                      //проверка на наличие файла
        printf("Error\n");                 //вывод ошибки
    else
    {
        fgets(text, 400, file); //забираем текст из файла
        puts(text);             //помещаем текст в нашу строку
        getch();
        fclose(file);
    }
    printf("\n\n");
}
void assembler() //реализация с помощью assembler
{
    printf("Function Assembler\n");
    char *path = "text2.txt";
    char buffer[401];         //задаем размерность строки
    char *baddr = &buffer[0]; //создаем пустой буффер
    asm { //вставка в си коде
		mov ah, 0x3d //открытие
		xor al, 0                     // al вернет 0 режим открытия файла
		mov dx, path //указываем путь до файла
		xor cx, 0                     // cx вернет 0
		int 0x21              // INT 21H генерирует программное прерывание 0x21 (33 в десятичном значении), в результате чего функция, указанная 34-м вектором в таблице прерываний, должна выполняться, что обычно является вызовом API MS-DOS
                              // Return: AL = character read
        // Notes:
        //^C/^Break are checked
        //^P toggles the DOS-internal echo-to-printer flag
        //^Z is not interpreted, thus not causing an EOF if input is redirected character is echoed //to standard output
		mov bx, ax //Чтение, ax-описатель файла
		mov ah, 0x3f
		mov dx, baddr //указатель на буфер
		mov cx, 400 //сколько символов прочитано в буфере
		int 0x21
		mov bx, baddr //получаем код сегмента
    	add bx, ax //кол-во прочитанных символов к коду добавляем смещение
    	mov byte[bx],'$' //сдвигает до сегмента смещения и ставиться $- конец строки
		mov ah, 9 // вывод
		mov dx, baddr //вывод из буфера
		int 0x21
		mov ah, 0x3e // закрытие
		int 0x21
    }
}

int main()
{
    clrscr();
    functionc();
    assembler();
    getch();
    return 0;
}
