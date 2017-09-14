using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.IO;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public List<Book> Books;
        public void TableCreate()
        {
            var i = 0;
            tableLayoutPanel1.Controls.Clear();
            foreach (var item in Books)
            {
                tableLayoutPanel1.Controls.Add(AddBookToPanel(item, i), 0, i++);
            }
        }
        public void ClearTable()
        {
            tableLayoutPanel1.Controls.Clear();

        }
        public void FindElementCreate(int n)
        {
            tableLayoutPanel1.Controls.Add(AddBookToPanel(Books[n], n), 0, n);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            

            
            XmlSerializer mySerializer = new XmlSerializer(typeof(List<Book>));
            FileStream myFileStream =new FileStream("myFileName.xml", FileMode.Open);
            Books = (List<Book>)mySerializer.Deserialize(myFileStream);
            myFileStream.Close();
            var i = 0;
            foreach (var item in Books)
            {
                tableLayoutPanel1.Controls.Add(AddBookToPanel(item, i),0,i++);
            }
            tableLayoutPanel1.HorizontalScroll.Maximum = 0;
            tableLayoutPanel1.AutoScroll = false;
            tableLayoutPanel1.VerticalScroll.Visible = false;
            tableLayoutPanel1.AutoScroll = true;

        }
        public Panel AddBookToPanel(Book a,int n)
        {
            Panel panel = new Panel();
            PictureBox picture=new PictureBox();
            Label name = new Label();
            Label annotation = new Label();
            Label reldate=new Label();
            Label autor= new Label();
            Label gener = new Label();
            // 
            // picture
            // 
            picture.Location = new System.Drawing.Point(5, 5);
            picture.Size = new System.Drawing.Size(100, 140);
            picture.Image = a.Image;
            picture.SizeMode = PictureBoxSizeMode.StretchImage;
            // 
            // name
            // 
            name.AutoSize = true;
            name.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            name.Location = new System.Drawing.Point(111, 5);
            name.Text = a.Name;
            // 
            // gener
            // 
            gener.AutoSize = true;
            gener.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            gener.Location = new System.Drawing.Point(113, 31);
            gener.Text = a.Categuro+", "+a.Genre;
            // 
            // autor
            // 
            autor.AutoSize = true;
            autor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            autor.Location = new System.Drawing.Point(112, 51);
            autor.Text = a.Authors;
            // 
            // reldate
            // 
            reldate.AutoSize = true;
            reldate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            reldate.Location = new System.Drawing.Point(113, 71);
            reldate.Text = a.GetRealiseDate;
            // 
            // annotation
            // 
            annotation.AutoSize = true;
            annotation.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            annotation.Location = new System.Drawing.Point(113, 91);
            annotation.MaximumSize = new Size(300,0);

            annotation.Text = a.Annotation;
            //
            //panel
            //
            panel.Controls.Add(annotation);
            panel.Controls.Add(reldate);
            panel.Controls.Add(autor);
            panel.Controls.Add(gener);
            panel.Controls.Add(name);
            panel.Controls.Add(picture);
            panel.TabIndex = n;
            panel.Location = new System.Drawing.Point(3, 3);
            panel.Padding = new System.Windows.Forms.Padding(2);
            panel.MinimumSize = new System.Drawing.Size(450, 150);
            panel.AutoSize = true;
            panel.Click += (sn,ea)=>
            {
                foreach (var item in tableLayoutPanel1.Controls)
                {
                    ((Panel)item).BackColor = tableLayoutPanel1.BackColor;
                }
               ((Control)sn).BackColor = Color.Silver;
               
            };

            return panel;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void добавитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var a = new AddChange(this);
            a.Show();
        }

        private void changeInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int n =-1;
            foreach (var item in tableLayoutPanel1.Controls)
            {
                if (((Control)item).BackColor == Color.Silver)
                    n = ((Control)item).TabIndex;
            }
            if (n != -1)
            {
                var a = new AddChange(this, n);
                a.Show();
            }

        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int n = -1;
            foreach (var item in tableLayoutPanel1.Controls)
            {
                if (((Control)item).BackColor == Color.Silver)
                    n = ((Control)item).TabIndex;
            }
            if (n != -1)
            {
                Books.RemoveAt(n);
                TableCreate();
            }
        }

        private void findeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var a = new Booksearcher(this);
            a.Show();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            XmlSerializer mySerializer = new XmlSerializer(typeof(List<Book>));

            StreamWriter myWriter = new StreamWriter("myFileName.xml");
            mySerializer.Serialize(myWriter, Books);

            myWriter.Close();
        }

        private void outputToAFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //FileInfo file = new FileInfo("Output.txt");
            //if (file.Exists == false)
            //{
            //    File.Create("Output.txt");
            //}
            //else MessageBox.Show("file already exist");

            //StreamWriter write_text;
            //FileInfo file = new FileInfo("Output.txt");
            string wText = string.Empty;
            //write_text = file.AppendText();
            for (int i = 0; i < tableLayoutPanel1.Controls.Count; i++)
            {
                //write_text.WriteLine(Books[i].Name);
                //write_text.WriteLine(Books[i].Genre + ", " + Books[i].Categuro);
                //write_text.WriteLine(Books[i].Authors);
                //write_text.WriteLine(Books[i].GetRealiseDate);
                //write_text.WriteLine(Books[i].Annotation);
                //write_text.WriteLine("\n\n\n");
                if (tableLayoutPanel1.Controls[i].GetType() == typeof(Panel))
                {
                    for (var j = ((Panel)tableLayoutPanel1.Controls[i]).Controls.Count-1; j >= 0; j--)

                    {
                        var item = ((Panel)tableLayoutPanel1.Controls[i]).Controls[j];
                        if (item.GetType() == typeof(Label))
                        {
                            wText += (((Label)item).Text + "\r\n");
                        }
                        
                    }
                    wText += "\r\n";
                }
                File.WriteAllText("Output.txt", wText);
            }
            MessageBox.Show("file already exit");

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 a = new AboutBox1();
            a.Show();
        }
    }
}