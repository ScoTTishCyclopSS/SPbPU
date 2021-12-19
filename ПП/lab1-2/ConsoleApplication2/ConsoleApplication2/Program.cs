using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class Program
    {
		static void Main(string[] args) {
			//Note N = new Note();

			Note[] F = new Note[]
			{
				new Friend(1, "Timushev Fedor Alexeevich", "+7(911)2195183", "fed.timushev@gmail.com",  new int[] { 12, 6, 2010 }),
                new Note("Sukachev Ivan Petrovich1",2, "+7(911)0987654"),
				new Friend(3, "Ivanov Petr Vasilievich", "+7(911)5553535", "petr.ivanov@gmail.com",  new int[] { 15, 10, 2009 }),
                new Note("Sukachev Ivan Petrovich2",4, "+7(911)0987654"),
				new Friend(5, "Dinazavrov Alexey Artyomovich", "+7(911)9667721", "alex.dinazavrov@gmail.com",  new int[] { 08, 6, 2011 }),
                new Note("Sukachev Ivan Petrovich3",6, "+7(911)0987654"),
                new Friend(7, "Sukachev Ivan Petrovich", "+7(911)0987654", "marlo@gmail.com",  new int[] { 21, 10, 1994 }),
                new Note("Sukachev Ivan Petrovich4",8, "+7(911)0987654")
			};
            for (int i = 0; i < 8; i++)
            {
                F[i].Show();
                Console.WriteLine();
            }
            
			Console.Write("Enter month number > ");
			int month = Convert.ToInt16(Console.ReadLine());
            Console.Write("\n");


			for (int i = 0; i < 8; i++)

				if (F[i].Month == month)
				{
				F[i].Show();
				Console.WriteLine();
				}
            Console.ReadKey();
        }
    }
    class Note // класс - Запись
    {
        protected string name;
        protected int number;
        protected string pnumber;
        

        public Note() { }
        public Note(string name, int number, string pnumber)
        {
            this.name = name;
            this.number = number;
            this.pnumber = pnumber;
        }
       virtual public void Show() //метод для вывода информации о друге на экран
        {
            Console.Write("Contact #{1}: {0} {2}\n", name, number, pnumber);
        }

       virtual public int Month { get; set; }
    }
    class Friend : Note // порожденный класс Друг
    {
        string email;
        int[] date;

        public Friend(int number, string name, string pnumber, string email, int[] date )
            : base(name, number, pnumber) //конструктор для Друга
        {
            this.email = email;
            this.date = date;
        }
		override public int Month {
			get {
				return date[1];
			}
		}
        override public void Show()
        {
            base.Show();
            Console.Write("\t    Phone number: {1}\n\t    Email: {2} \n\t    Date of birth: {3}.{4}.{5}\n", name, pnumber, email, date[0], date[1], date[2]);
        }

    }
}
