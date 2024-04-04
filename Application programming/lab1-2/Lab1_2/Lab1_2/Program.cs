using System;

namespace Lab1_2
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Note[] notes =
            {
                new Friend(1, "Timushev Fedor Alexeevich", "+7(911)2195183", "fed.timushev@gmail.com",
                    new[] { 12, 6, 2010 }),
                new Note("Sukachev Ivan Petrovich1", 2, "+7(911)0987654"),
                new Friend(3, "Ivanov Petr Vasilievich", "+7(911)5553535", "petr.ivanov@gmail.com",
                    new[] { 15, 10, 2009 }),
                new Note("Sukachev Ivan Petrovich2", 4, "+7(911)0987654"),
                new Friend(5, "Dinazavrov Alexey Artyomovich", "+7(911)9667721", "alex.dinazavrov@gmail.com",
                    new[] { 08, 6, 2011 }),
                new Note("Sukachev Ivan Petrovich3", 6, "+7(911)0987654"),
                new Friend(7, "Sukachev Ivan Petrovich", "+7(911)0987654", "marlo@gmail.com",
                    new[] { 21, 10, 1994 }),
                new Note("Sukachev Ivan Petrovich4", 8, "+7(911)0987654")
            };

            for (var i = 0; i < 8; i++)
            {
                notes[i].Show();
                Console.WriteLine();
            }

            Console.Write("Enter month number: ");
            int month = Convert.ToInt16(Console.ReadLine());
            Console.Write("\n");

            for (var i = 0; i < 8; i++)
                if (notes[i].Month == month)
                {
                    notes[i].Show();
                    Console.WriteLine();
                }

            Console.ReadKey();
        }
    }
}