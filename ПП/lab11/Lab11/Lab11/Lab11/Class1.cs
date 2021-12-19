using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Printing;
using System;

namespace Lab11
{
    public class TextFile
    {
        string filename; //имя файла на диске
        string text; //текст файла

        public TextFile(string fileName) //Конструктор
        {
            filename = fileName;
            text = "";
        }

        public string SetGetFile
        {
            get { return filename; }
            set { text = value; }
        }

        public string MyText //записываем текст
        {
            get { return text; }
            set { text = value; }
        }
        //Чтение текстового файла
        //Результат: прочитанный текст из файл
        public bool ReadFile()
        {
            try
            {
                StreamReader sr = new StreamReader(filename);
                Encoding.GetEncoding(1251);
                text = sr.ReadToEnd();
                sr.Close();
                return true;
            }
            catch
            {
                MessageBox.Show("Ошибка чтения файла!");
                return false;
            }
        }

        //Сохранение файла
        //Результат: запись файла на диск
        public bool SaveFile()
        {
            try
            {
                Encoding en = Encoding.Unicode;
                StreamWriter sf = new StreamWriter(filename, false, en); //если файл существует, то он будет перезаписан
                string[] str = text.Split('\n');
                string[] buf = new string[str.Length];
                for (int i = 0; i < str.Length; i++)
                {
                    buf[i] = str[i];
                }
                for (int i = 0; i < str.Length; i++)
                    sf.WriteLine(buf[i]);
                sf.Close();
                return true;
            }
            catch
            {
                MessageBox.Show("Ошибка сохранения файла!");
                return false;
            }
        }
        //Поиск слов
        public void SearchWords(string slog, RichTextBox rtb)
        {
            var m = 
                text
                .Split(new char[]{'\n', '.', '\r', '!', '?'},StringSplitOptions.RemoveEmptyEntries)
                .Select(s=>s.Trim())
               // .Where(x => x != "")
              .Where(x => x.StartsWith(slog))
              .Select(p => p.Split(' ', ',', ';', '.').First());
            rtb.Text = string.Join("\n", m);
        }
        int find(string s, int istart, char c)
        {
            for (int i = istart; i < s.Length; i++)
            {
                if (c == s[i])
                    return i;
            }
            return -1;
        }
        bool isgood(string x, string slog)
        {
            int res = -1;
            for (int i = 0; i < slog.Length; i++)
            {
                res = find(x, res + 1, slog[i]);
                if (res == -1)
                    return false;
            }
            return true;
        }

        StreamReader streamToPrint; //поток для принтера
        Font printFont; //шрифт

        //Метод печати файла
        //Входные параметры: передаются параметры шрифта
        //Результат: переданный текст выводится на печать, 
        //если нет ошибки, передается результат true
        public bool PrintResult(Font pF)
        {
            try
            {
                streamToPrint = new StreamReader(filename, Encoding.UTF8);
                try
                {
                    printFont = pF;
                    PrintDocument pd = new PrintDocument();
                    pd.PrintPage += new PrintPageEventHandler(pd_PrintPage);
                    pd.Print();
                    return true;
                }
                finally
                {
                    streamToPrint.Close();
                }
            }
            catch
            {
                MessageBox.Show("Ошибка печати файла!");
                return false;
            }
        }

        private void pd_PrintPage(object sender, PrintPageEventArgs ev) //Событие PrintPage вызывается для каждой страницы, которая будет напечатана
        {
            float linesPerPage = 0;
            float yPos = 0;
            int count = 0;
            float leftMargin = ev.MarginBounds.Left;
            float topMargin = ev.MarginBounds.Top;
            string line = null;
            linesPerPage = ev.MarginBounds.Height / printFont.GetHeight(ev.Graphics); //Чтобы вычислить количество строк на странице
            while (count < linesPerPage && ((line = streamToPrint.ReadLine()) != null)) //Печатаем каждую строку файла
            {
                yPos = topMargin + (count * printFont.GetHeight(ev.Graphics));
                ev.Graphics.DrawString(line, printFont, Brushes.Black, leftMargin, yPos, new StringFormat());
                count++;
            }
            if (line != null) //если строки не закончились, распечатаем еще одну страницу
                ev.HasMorePages = true;
            else
                ev.HasMorePages = false;
        }
        public void SAVE(RichTextBox rtb)
        {
            FileStream f = new FileStream(filename, FileMode.Create);
            StreamWriter writer = new StreamWriter(f, Encoding.GetEncoding(1251));
            writer.Write(rtb.Text);
            writer.Close();
        }
    }
}