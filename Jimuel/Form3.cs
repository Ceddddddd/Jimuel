﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jimuel
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "jim" && textBox2.Text == "jim")
            {
                this.Hide();
                Form1 form1 = new Form1();
                form1.ShowDialog();
            }
            else if (textBox1.Text == "jim" && textBox2.Text != "jim") {
                MessageBox.Show("Wrong Password");
            }
            else if (textBox1.Text != "jim" && textBox2.Text == "jim")
            {
                MessageBox.Show("Wrong Username");
            }
            else
            {
                MessageBox.Show("Wrong Username and password");

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
        }
    }
}
