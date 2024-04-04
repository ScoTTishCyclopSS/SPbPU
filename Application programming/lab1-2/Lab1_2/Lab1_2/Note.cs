using System;

namespace Lab1_2
{
    public class Note
    {
        protected string name;
        protected int number;
        protected string pnumber;

        public Note()
        {
        }

        public Note(string name, int number, string pnumber)
        {
            this.name = name;
            this.number = number;
            this.pnumber = pnumber;
        }

        public virtual int Month { get; set; }

        public virtual void Show()
        {
            Console.Write("Contact #{1}: {0} {2}\n", name, number, pnumber);
        }
    }
}