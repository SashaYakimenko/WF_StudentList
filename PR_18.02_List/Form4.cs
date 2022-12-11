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
    public partial class Form4 : Form
    {
        public Group gr_pattern = new Group();
        public Form4()
        {
            InitializeComponent();
        }

        public Group Data { get { return gr_pattern; } }
        public string GroupForChanging { get { return textBox4.Text; } }
        private void button1_Click(object sender, EventArgs e)
        {
            gr_pattern.Name = textBox1.Text;
            gr_pattern.Spec = textBox2.Text;
            gr_pattern.Num_stud = int.Parse(textBox3.Text);
        }
    }
}
