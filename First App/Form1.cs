using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace First_App
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var name = textBox1.Text;
            using(Form2 cform = new Form2()){
                Hide();     // hides current
                cform.Show();     //shows new form
                
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Show();
        }
    }
}
