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
    public partial class Form7 : Form
    {
        public Student st = new Student();
        public Form7()
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
                st.Name = textBox4.Text;
            }
        }
    }
}
