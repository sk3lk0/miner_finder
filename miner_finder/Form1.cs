using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Threading;

namespace miner_finder
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        void joinandfind()
        {
            string line;
            for (int i = 0; i < richTextBox1.Lines.Length; i++)
            {
                line = richTextBox1.Lines[i];
                Uri url = new Uri(line);
                try
                {
                    string otvet = new WebClient().DownloadString(url);

                    for (int ai = 0; ai < richTextBox3.Lines.Length; ai++)
                    {
                        if (otvet.Contains(richTextBox3.Lines[ai]))
                        {
                            richTextBox2.Text += line + "\n";
                            richTextBox2.Text += "Нашлось слово: "+ richTextBox3.Lines[ai] + "\n";
                            richTextBox2.Select(0, richTextBox3.Lines[ai].Length + 1);
                            richTextBox2.SelectionColor = Color.Green;
                        }
                        else { ai++; }
                    }
                }
                catch 
                { 
                    i++;
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog path = new OpenFileDialog();
            if (path.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.Lines = File.ReadAllLines(path.FileName);
               //MessageBox.Show(Convert.ToString(richTextBox1.Lines.Length)); 
            }
            else 
            {
 
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog pathtowords = new OpenFileDialog();
            if (pathtowords.ShowDialog() == DialogResult.OK)
            {
                richTextBox3.Lines = File.ReadAllLines(pathtowords.FileName);
            }
            else
            {

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            joinandfind();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Нажимаем кнопку Sites, выбираем путь к файлу с сайтами\nНажимаем кнопку Words, выбираем путь к файлу с \"словами\"\nНажимаем кнопку Start");
        }
    }
}
