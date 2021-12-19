using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using interYOURMOMface;
using System.Windows.Controls;

namespace UnitTestGroup
{
    [TestClass]
    public class UnitTestGroup
    {
        [TestMethod]
        public void dgv()
        {
            Model1Container db = new Model1Container();
            DataGrid dgv = new DataGrid();

            interYOURMOMface.itemsourse.dgv(db, dgv);
            Assert.IsNotNull(dgv.Items); //проверка на вывод данных в дгв
        }

        [TestMethod]
        public void sum()
        {
            TextBox text = new TextBox();
            TextBox text2 = new TextBox();
            ComboBox combo = new ComboBox();

            text.Text = "15000";
            combo.Items.Add(12);
            combo.SelectedItem = 12;

            interYOURMOMface.rem.remainer(text, combo, text2);
            Assert.IsNotNull(text2.Text); //проверка на подсчет итоговой суммы кредитования

        }

        [TestMethod]
        public void period()
        {
            DatePicker start = new DatePicker();
            DatePicker end = new DatePicker();
            DatePicker start_card = new DatePicker();
            DatePicker end_card = new DatePicker();
            TextBox sum_text = new TextBox();

            start.SelectedDate = DateTime.Now.Date;
            end.SelectedDate = DateTime.Now.Date;
            start_card.SelectedDate = DateTime.Now.Date;
            end_card.SelectedDate = DateTime.Now.Date;

            interYOURMOMface.date.date_rem(end, start, sum_text, start_card, end_card);
            Assert.IsNotNull(sum_text.Text); //подсчет кол-ва месяцев кредитования
        }
    }
}
