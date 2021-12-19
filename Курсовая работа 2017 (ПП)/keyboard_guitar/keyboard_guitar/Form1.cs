using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using NAudio.Wave;
using SoundAnalysis;
using NAudio.CoreAudioApi;

namespace keyboard_guitar
{

    public partial class Form1 : Form
    {
        public List<int> note = new List<int>();
        public bool f = false;
        public string[] keys = new string[250];
        public int temp_note = 0;
        public BufferedWaveProvider bwp;
        public WaveIn waveIn = null;
        int hz;


        public Form1()
        {
            InitializeComponent();
            MMDeviceEnumerator enumirator = new MMDeviceEnumerator();
            var devices = enumirator.EnumerateAudioEndPoints(DataFlow.All, DeviceState.Active);
            comboBox1.Items.AddRange(devices.ToArray());
            comboBox3.Items.AddRange(devices.ToArray());
            label3.Text = "\u266B";
            button1.ForeColor = Color.Red;
            button2.ForeColor = Color.Red;
            button4.Enabled = false;
            button5.Enabled = false;
        }

        public delegate void lblDelegate(string message);

        public void main_func()
        {

            waveIn = new WaveIn();
            waveIn.DataAvailable += WaveOnDataAvailable;
            waveIn.RecordingStopped += new EventHandler<StoppedEventArgs>(waveIn_RecordingStopped); //объявление события об окончании записи
            waveIn.DeviceNumber = 0;
            waveIn.WaveFormat = new WaveFormat(44100, 1); //определение формата входной волны - по стандарту 44100 hrz
            bwp = new BufferedWaveProvider(waveIn.WaveFormat);
            bwp.BufferLength = 2048; //длина буфера для записи
            waveIn.StartRecording(); //запуск считывания

        }
        void waveIn_RecordingStopped(object sender, StoppedEventArgs e) //событие об окончании записи
        {
            if (waveIn != null)
            {
                waveIn.Dispose();
                waveIn = null;
            }
        }

        public void WaveOnDataAvailable(object sender, WaveInEventArgs e)
        {

            float[] sampleAggregator = FFT.FillSampleAgr(e.Buffer, e.BytesRecorded);
            hz = FFT.Generative(sampleAggregator);
            //здесь мы нажимаем кнопку
            if (hz > 0 && hz != int.Parse(label2.Text)) SendKeys.Send(keys[hz]);
            //выводим число, на которое ориентируемся
            label2.Text = hz + "";
            circularProgressBar2.Value = hz; //заполнение прогрессбара числом частоты
            if (button5.Enabled == true)
            {
                label6.Text = hz + "";
                circularProgressBar3.Value = hz;
            }
            int s = (int)(FFT.Level(sampleAggregator)); //определение уровня громкости
            label1.Text = s + "%";

        }
        private void button1_Click(object sender, EventArgs e)
        {
            {

                if (comboBox1.SelectedIndex == -1)
                {
                    label4.ForeColor = Color.Red;
                    return;
                }
                if (radioButton7.Checked == false && radioButton8.Checked == false)
                {
                    radioButton7.ForeColor = Color.Red;
                    radioButton8.ForeColor = Color.Red;
                    return;
                }
                radioButton7.ForeColor = Color.White;
                radioButton8.ForeColor = Color.White;
                button4.Enabled = true;
                button4.ForeColor = Color.Red;
                button1.ForeColor = Color.Green;
                main_func();

                if (radioButton8.Checked == true)
                {
                    keys[15] = "{BACKSPACE}";
                    keys[8] = "a";
                    keys[9] = "b";
                    keys[10] = "c";
                    keys[11] = "d";
                    keys[12] = "e";
                    keys[13] = "f";
                    keys[14] = "g";
                    keys[15] = "h";
                    keys[17] = "i";
                    keys[19] = "j";
                    keys[21] = "k";
                    keys[23] = "l";
                    keys[25] = "m";
                    keys[27] = "n";
                    keys[29] = "o";
                    keys[31] = "p";
                    keys[33] = "q";
                    keys[35] = "r";
                    keys[37] = "s";
                    keys[39] = "t";
                    keys[41] = "u";
                    keys[43] = "v";
                    keys[45] = "w";
                    keys[47] = "x";
                    keys[49] = "y";
                    keys[51] = "z";
                    keys[90] = "{ENTER}";
                }
                else
                    if (radioButton7.Checked == true)
                {
                    keys[15] = "{BACKSPACE}";
                    keys[8] = "а";
                    keys[9] = "б";
                    keys[10] = "в";
                    keys[11] = "г";
                    keys[12] = "д";
                    keys[13] = "е";
                    keys[14] = "ж";
                    keys[15] = "ж";
                    keys[17] = "и";
                    keys[19] = "к";
                    keys[21] = "л";
                    keys[23] = "м";
                    keys[25] = "н";
                    keys[27] = "о";
                    keys[29] = "п";
                    keys[31] = "р";
                    keys[33] = "с";
                    keys[35] = "т";
                    keys[37] = "у";
                    keys[39] = "ф";
                    keys[41] = "х";
                    keys[43] = "ц";
                    keys[45] = "ч";
                    keys[47] = "ш";
                    keys[49] = "щ";
                    keys[51] = "ъ";
                    keys[53] = "ы";
                    keys[55] = "ь";
                    keys[57] = "э";
                    keys[59] = "ю";
                    keys[61] = "я";
                    keys[90] = "{ENTER}";

                }
                //задаём клавиши

            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                var device = (MMDevice)comboBox1.SelectedItem;
                circularProgressBar1.Value = (int)(Math.Round(device.AudioMeterInformation.MasterPeakValue * 100));
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox3.SelectedIndex == -1)
            {
                label8.ForeColor = Color.Red;
                return;
            }
            if (comboBox2.SelectedIndex == -1)
            {
                comboBox2.BackColor = Color.Red;
                return;
            }
            comboBox2.ForeColor = Color.Black;
            button5.Enabled = true;
            button5.ForeColor = Color.Red;
            button2.ForeColor = Color.Green;
            timer2.Enabled = !timer2.Enabled;
            main_func();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {

            string s = comboBox2.SelectedItem.ToString();
            switch (s)
            {
                case "E":
                    if (radioButton6.Checked == true)
                    {
                        label3.Text = "E";
                        switch (hz)
                        {

                            case 0: label3.ForeColor = Color.White;
                                break;
                            case 22: label3.ForeColor = Color.Yellow;
                                break;
                            case 23: label3.ForeColor = Color.Green;
                                break;
                            case 24: label3.ForeColor = Color.Red;
                                break;
                        }

                    }
                    if (radioButton5.Checked == true)
                    {
                        label3.Text = "A";
                        switch (hz)
                        {

                            case 0: label3.ForeColor = Color.White;
                                break;
                            case 19: label3.ForeColor = Color.Yellow;
                                break;
                            case 20: label3.ForeColor = Color.Green;
                                break;
                            case 21: label3.ForeColor = Color.Red;
                                break;
                        }

                    }
                    if (radioButton4.Checked == true)
                    {
                        label3.Text = "D";
                        switch (hz)
                        {

                            case 0: label3.ForeColor = Color.White;
                                break;
                            case 26: label3.ForeColor = Color.Yellow;
                                break;
                            case 27: label3.ForeColor = Color.Green;
                                break;
                            case 28: label3.ForeColor = Color.Red;
                                break;
                        }

                    }
                    if (radioButton3.Checked == true)
                    {
                        label3.Text = "G";
                        switch (hz)
                        {

                            case 0: label3.ForeColor = Color.White;
                                break;
                            case 53: label3.ForeColor = Color.Yellow;
                                break;
                            case 54: label3.ForeColor = Color.Green;
                                break;
                            case 55: label3.ForeColor = Color.Red;
                                break;
                        }

                    }
                    if (radioButton2.Checked == true)
                    {
                        label3.Text = "B";
                        switch (hz)
                        {

                            case 0: label3.ForeColor = Color.White;
                                break;
                            case 68: label3.ForeColor = Color.Yellow;
                                break;
                            case 69: label3.ForeColor = Color.Green;
                                break;
                            case 70: label3.ForeColor = Color.Red;
                                break;
                        }

                    }
                    if (radioButton1.Checked == true)
                    {
                        label3.Text = "e";
                        switch (hz)
                        {

                            case 0: label3.ForeColor = Color.White;
                                break;
                            case 91: label3.ForeColor = Color.Yellow;
                                break;
                            case 92: label3.ForeColor = Color.Green;
                                break;
                            case 93: label3.ForeColor = Color.Red;
                                break;
                        }

                    }
                    break;

            }

        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void русскийToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button1.Text = "Включить";
            button2.Text = "Включить";
            button3.Text = "Таблица символов";
            button4.Text = "Выключить";
            button5.Text = "Выключить";
            label4.Text = "Выбор устройства";
            label8.Text = "Выбор устройства";
            circularProgressBar2.Text = "Частота";
            circularProgressBar3.Text = "Частота";
            circularProgressBar1.Text = "Громкость";
            label7.Text = "Тюнер";
            настройкиToolStripMenuItem.Text = "Настройки";
            языкlanguageToolStripMenuItem.Text = "Язык (language)";
            справкаToolStripMenuItem.Text = "Справка";
            выходToolStripMenuItem.Text = "Выход";
            comboBox2.Text = "Дроп";
        }

        private void englishToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button1.Text = "Power on";
            button2.Text = "Power on";
            button4.Text = "Power off";
            button5.Text = "Power off";
            button3.Text = "Table of symbols";
            label4.Text = "Choose the device";
            label8.Text = "Choose the device";
            circularProgressBar2.Text = "Frequency";
            circularProgressBar3.Text = "Frequency";
            circularProgressBar1.Text = "Volume";
            label7.Text = "Tuner";
            настройкиToolStripMenuItem.Text = "Settings";
            языкlanguageToolStripMenuItem.Text = "Language (язык)";
            справкаToolStripMenuItem.Text = "Info";
            выходToolStripMenuItem.Text = "Exit";
            comboBox2.Text = "Drop";
        }

        private void справкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("lol");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex >= 0)
            {
                label4.ForeColor = Color.Green;
            }
        }
        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox3.SelectedIndex >= 0)
            {
                label8.ForeColor = Color.Green;
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("sas");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            waveIn.StopRecording();
            button4.Enabled = false;
        }

        private void button5_Click(object sender, EventArgs e) { 
        waveIn.StopRecording();
        button5.Enabled = false;        
        }
    }
}