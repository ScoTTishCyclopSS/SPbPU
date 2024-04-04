using System;

namespace Lab1_2
{
    internal class Friend : Note
    {
        private readonly int[] date;
        private readonly string email;

        public Friend(int number, string name, string pnumber, string email, int[] date)
            : base(name, number, pnumber)
        {
            this.email = email;
            this.date = date;
        }

        public override int Month => date[1];

        public override void Show()
        {
            base.Show();
            Console.Write("\t Phone number: {1}\n\t Email: {2} \n\t Date of birth: {3}.{4}.{5}\n", name,
                pnumber, email, date[0], date[1], date[2]);
        }
    }
}