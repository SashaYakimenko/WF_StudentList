using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PR_18._02_List
{
    public partial class Form5 : Form
    {
        public Student st_pattern = new Student();
        public Form5()
        {
            InitializeComponent();
        }

        public Student Data { get { return st_pattern; } }
        public string[] StudentForChanging 
        {
            get 
            {
                string[] str = { textBox4.Text, textBox7.Text };
                return str;
            } 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            st_pattern.Name = textBox1.Text;
            st_pattern.Group = textBox2.Text;
            st_pattern.SetGrade(int.Parse(textBox3.Text), 0);
            st_pattern.SetGrade(int.Parse(textBox5.Text), 1);
            st_pattern.SetGrade(int.Parse(textBox6.Text), 2);
        }
    }
}
