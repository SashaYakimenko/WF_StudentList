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
    public partial class Form3 : Form
    {
        public Student st = new Student();
        public Student Data
        {
            get { return st; }
        }
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            st.Name = textBox1.Text;
            st.Group = textBox2.Text;
            st.SetGrade(Convert.ToInt32(textBox3.Text), 0);
            st.SetGrade(Convert.ToInt32(textBox4.Text), 1);
            st.SetGrade(Convert.ToInt32(textBox5.Text), 2);
        }
    }
}
