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
    public partial class Form2 : Form
    {
        public Group gr = new Group();
        public Form2()
        {
            InitializeComponent();
        }

        public Group Data
        {
            get
            {
                return gr;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            gr.Name = textBox1.Text;
            gr.Spec = textBox2.Text;
            gr.Num_stud = Convert.ToInt32(textBox3.Text);
        }
    }
}
