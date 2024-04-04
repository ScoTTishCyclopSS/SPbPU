using System;
using System.Windows.Controls;
using loans_bank;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTestGroup
    {
        [TestMethod]
        public void dgv()
        {
            var db = new Model1Container();
            var dgv = new DataGrid();

            itemsourse.dgv(db, dgv);
            Assert.IsNotNull(dgv.Items);
        }

        [TestMethod]
        public void sum()
        {
            var text = new TextBox();
            var text2 = new TextBox();
            var combo = new ComboBox();

            text.Text = "15000";
            combo.Items.Add(12);
            combo.SelectedItem = 12;

            rem.remainer(text, combo, text2);
            Assert.IsNotNull(text2.Text);
        }

        [TestMethod]
        public void period()
        {
            var start = new DatePicker();
            var end = new DatePicker();
            var start_card = new DatePicker();
            var end_card = new DatePicker();
            var sum_text = new TextBox();

            start.SelectedDate = DateTime.Now.Date;
            end.SelectedDate = DateTime.Now.Date;
            start_card.SelectedDate = DateTime.Now.Date;
            end_card.SelectedDate = DateTime.Now.Date;

            date.date_rem(end, start, sum_text, start_card, end_card);
            Assert.IsNotNull(sum_text.Text);
        }
    }
}