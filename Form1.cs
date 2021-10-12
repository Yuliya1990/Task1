using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Triangle1
{
    public partial class Form1 : Form
    {
        Triangle tr = null;
        public Form1()
        {
            InitializeComponent();
        }
        
        private void CreateTriangle_Click(object sender, EventArgs e)
        {
            try
            {
                label1.Text = "";
                tr = new Triangle(Double.Parse(Side1.Text), Double.Parse(Side2.Text), Double.Parse(Side3.Text));
                label1.Text = "Congradulations!";
            }
            catch(Exception ex)
            {
                //label1.Text = ex.Message;
                MessageBox.Show(ex.Message);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (tr != null)
            {
                if (tr.ChangeSide(int.Parse(index.Text)-1, Double.Parse(side.Text)))
                {
                    Res.Text = "Successfully changed";
                }
                else
                {
                    Res.Text = "Change failed";
                }
            }
            else MessageBox.Show("Create triangle first!");
        }
    }
}
