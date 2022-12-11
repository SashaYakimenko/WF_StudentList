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
    public partial class Form6 : Form
    {
        public Student st = new Student();
        public Form6()
        {
            InitializeComponent();
        }

        public Student Data { get { return st; } }
        public bool Search_mode 
        { 
            get 
            {
                return checkBox5.Checked; 
            } 
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (checkBox5.Checked && checkBox1.Checked)
            {
                DialogResult result = MessageBox.Show("Выберите один из двух пунктов .\n",
                                                          "Ошибка", MessageBoxButtons.OK);
            }
            else 
            {
                st.SetGrade(-1, 0);
                st.SetGrade(-1, 1);
                st.SetGrade(-1, 2);
                if (textBox3.TextLength != 0) st.SetGrade(int.Parse(textBox3.Text), 0);
                if (textBox1.TextLength != 0) st.SetGrade(int.Parse(textBox1.Text), 1);
                if (textBox2.TextLength != 0) st.SetGrade(int.Parse(textBox2.Text), 2);
            }
        }
    }
}
