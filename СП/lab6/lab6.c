#include<stdio.h>
#include<conio.h>
#include<locale.h>
#include<dos.h>
void first()
{
		clrscr();
		printf("Read file by C method\n");
		char text[400];
		FILE *file = fopen("text.txt","rt");
		if(file == NULL)
			printf("Error of reading");
		else	
		{
			fgets(text, 400, file);
			puts(text);
			getch();
			fclose(file);
		}	
		printf("\n\n");
}

void second()
{
		printf("\nReading file by interruption\n");
		union REGS in, out; //объединение структур регистров, для управления значениями регистров
		struct SREGS segregs; //структура сегментых сегментных регистров
		char text[400]; //текст файла,хранит адрес сегмента где хранится текст
		char file[20] = "text.txt"; //текстовый файл
		for(int i = 0; i < 400; i++)
		text[i] = '\0';
		in.h.ah = 0x3D; //объявление ф-ии,в регистр ah передаётся название функции 0x3D(возвращает регистр AX, если CF установлен – то код ошибки, иначе вернет описатель(индекс обращения к файлу) файла) открытия файла
		in.h.al = 0x00; // в регистр al(параметр) передаётся значения режима открытия файла только на чтение
		segregs.ds = FP_SEG(file); // регистру ds(сегмент, содержайщий путь) присваивается указатель на сегмент в котором записан путь до файла
		in.x.dx = FP_OFF(file); // ds:dx - указатель на имя файла
		int86x(0x21, &in, &out, &segregs); // вызов 21 прерывания 
		if (out.x.cflag == 1) // устанавливает carry flag (битовый флаг, который устанавливается, если в результате арифметической операции в (n + 1)-м значащем бите появилась единица (соответственно, в результате двоичного сдвига из разрядной сетки ушла единица) в том случае если происходит ошибка
		printf("Error = %d.\n", out.x.ax); // Ошибка = %d.\n", out.x.ax-код ошибки);ax-количество прочтённых символов
	else
	{	
		int handle (описатель файла-область памяти по которой можно найти индекс для работы файла) = out.x.ax; // запомнить значение получившегося регистра ax
		in.x.bx = handle;
		segregs.ds = FP_SEG(text); // возвращает сегмент дальнего указателя ptr
		in.x.dx = FP_OFF(text); // возвращает смещение дальнего указателя ptr
		in.h.ah = 0x3f; // чтение файла
		in.x.cx = 400; // параметр для функции кол-во считанных символов
		int86x(0x21, &in, &out, &segregs);
		if (out.x.cflag == 1)
			printf("Error of reading = %d.\n", out.x.ax); // если cf установлен то код ошибки
		else
		{
			printf("Reading succsess = %d bytes\n", out.x.ax); // иначе кол-во прочитанных символов
			printf("%s\n", text); 
		}
		in.h.ah = 0x3E; // закрытие файла
		in.x.bx = handle;
		int86(0x21, &in, &out);
		if (out.x.cflag == 1)
			printf("Error of opening file = %d.\n", out.x.ax);
		getch();
	}
}

void main()
{
	clrscr();
	first();
	second();
}
