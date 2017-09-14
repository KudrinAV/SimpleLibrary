using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Booksearcher : Form
    {
        private Form1 Mainform;

        public Booksearcher(Form1 a)
        {
            Mainform = a;

            InitializeComponent();
        }
        public Booksearcher()
        {
            InitializeComponent();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            Mainform.ClearTable();
            var i = 0;
            foreach (var item in Mainform.Books)
            {
                
                bool a = textBox1.Text == string.Empty || item.Authors.Contains(textBox1.Text);
                bool b = textBox2.Text == string.Empty || item.Name.Contains(textBox2.Text);
                bool c = (dateTimePicker1.Value.Day == DateTime.Today.Day && dateTimePicker1.Value.Month == DateTime.Today.Month && dateTimePicker1.Value.Year == DateTime.Today.Year)
                    || (dateTimePicker1.Value.Day == item.RealiseDate.Day && dateTimePicker1.Value.Month == item.RealiseDate.Month && dateTimePicker1.Value.Year == item.RealiseDate.Year);
                bool d = textBox4.Text == string.Empty || item.Genre.Contains(textBox4.Text);
                bool f = textBox3.Text == string.Empty || item.Categuro.Contains(textBox3.Text);
                if (a && b && c && d && f)
                {
                    Mainform.FindElementCreate(i);
                }
                i++;
            }
            Close();
        }
    }
}
