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
        string filename;
        string text;

        public TextFile(string fileName)
        {
            filename = fileName;
            text = "";
        }

        public string SetGetFile
        {
            get { return filename; }
            set { text = value; }
        }

        public string MyText
        {
            get { return text; }
            set { text = value; }
        }

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
                MessageBox.Show("File read error!");
                return false;
            }
        }

        public bool SaveFile()
        {
            try
            {
                Encoding en = Encoding.Unicode;
                StreamWriter sf = new StreamWriter(filename, false, en);
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
                MessageBox.Show("File save error!");
                return false;
            }
        }

        public void SearchWords(string slog, RichTextBox rtb)
        {
            var m =
                text
                    .Split(new char[] { '\n', '.', '\r', '!', '?' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(s => s.Trim())
                    // .Where(x => x != "")
                    .Where(x => x.StartsWith(slog))
                    .Select(p => p.Split(' ', ',', ';', '.').First());
            rtb.Text = string.Join("\n", m);
        }

        int find(string s, int istart, char c)
        {
            for (int i = istart; i < s.Length; i++)
                if (c == s[i])
                    return i;

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

        StreamReader streamToPrint;
        Font printFont;

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
                MessageBox.Show("File printing error!");
                return false;
            }
        }

        private void pd_PrintPage(object sender, PrintPageEventArgs ev)
        {
            float linesPerPage = ev.MarginBounds.Height / printFont.GetHeight(ev.Graphics);
            float yPos = 0;
            int count = 0;
            float leftMargin = ev.MarginBounds.Left;
            float topMargin = ev.MarginBounds.Top;
            string line = null;

            while (count < linesPerPage && ((line = streamToPrint.ReadLine()) != null))
            {
                yPos = topMargin + (count * printFont.GetHeight(ev.Graphics));
                ev.Graphics.DrawString(line, printFont, Brushes.Black, leftMargin, yPos, new StringFormat());
                count++;
            }

            if (line != null)
                ev.HasMorePages = true;
            else
                ev.HasMorePages = false;
        }

        public void Save(RichTextBox rtb)
        {
            FileStream f = new FileStream(filename, FileMode.Create);
            StreamWriter writer = new StreamWriter(f, Encoding.GetEncoding(1251));
            writer.Write(rtb.Text);
            writer.Close();
        }
    }
}