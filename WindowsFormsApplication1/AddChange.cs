using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApplication1
{
    public partial class AddChange : Form
    {
        private Form1 Mainform;
        private int IndexBook=-1;

        public AddChange()
        {
            InitializeComponent();
        }

        public AddChange(Form1 a)
        {
            Mainform = a;
            InitializeComponent();
            openFileDialog1.FileName = "Default.png";
            pictureBox1.Image = new Bitmap("Default.png");
        }
        public AddChange(Form1 a, int n)
        {
            Mainform = a;
            IndexBook = n;
            InitializeComponent();
            textBox1.Text = Mainform.Books[IndexBook].Authors;
            textBox2.Text = Mainform.Books[IndexBook].Name;
            dateTimePicker1.Value = Mainform.Books[IndexBook].RealiseDate;
            textBox3.Text = Mainform.Books[IndexBook].Categuro;
            textBox4.Text = Mainform.Books[IndexBook].Genre;
            textBox5.Text = Mainform.Books[IndexBook].Annotation;
            pictureBox1.Image = Mainform.Books[IndexBook].Image;
            openFileDialog1.FileName = Mainform.Books[IndexBook].ImagePath;



        }


        private void button1_Click(object sender, EventArgs e)
        {
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = new Bitmap(openFileDialog1.FileName);
            }
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            if (!(textBox1.Text == string.Empty || textBox2.Text == string.Empty || textBox3.Text == string.Empty || textBox4.Text == string.Empty)) {
                if (IndexBook == -1) {
                    Mainform.Books.Add((new Book(textBox1.Text.Split(','), textBox2.Text, dateTimePicker1.Value, textBox5.Text, openFileDialog1.FileName, textBox4.Text, textBox3.Text)));
                    Mainform.TableCreate();
                    this.Close();
                }
                else
                {
                    Mainform.Books[IndexBook].BookChanged(textBox1.Text.Split(','), textBox2.Text, dateTimePicker1.Value, textBox5.Text, openFileDialog1.FileName, textBox4.Text, textBox3.Text);
                    Mainform.TableCreate();
                    this.Close();

                }
            }
            else
            {
                MessageBox.Show("Dоne");
            }
        }


    }
}
