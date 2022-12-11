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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public Form2 form2 = new Form2();
        public Form3 form3 = new Form3();
        public Form4 form4 = new Form4();
        public Form5 form5 = new Form5();
        public Form6 form6 = new Form6();
        public Form7 form7 = new Form7();
        public List<Group> Spis = new List<Group>();
        private void OpenSecondForm_Click(object sender, EventArgs e)
        {
            form2 = new Form2();
            form2.Show();
            if (form2.Visible == true) OpenSecondForm.Enabled = false;
        }

        private void Form1_Activated(object sender, EventArgs e)
        {
            if (form2.Visible == false) OpenSecondForm.Enabled = true;
            if (form3.Visible == false) button2.Enabled = true;
            if (form4.Visible == false)
            {
                Changing.Enabled = true;
                checkBox1.Enabled = true;
            }
            if (form5.Visible == false)
            {
                Changing.Enabled = true;
                checkBox2.Enabled = true;
            }
            if (form6.Visible == false)
            {
                button6.Enabled = true;
                checkBox6.Enabled = true;
            }
            if (form6.Visible == false)
            {
                button6.Enabled = true;
                checkBox6.Enabled = true;
            }
        }

        private void Form1_MouseEnter(object sender, EventArgs e)
        {
            if (form2.Visible == false) OpenSecondForm.Enabled = true;
            if (form3.Visible == false) button2.Enabled = true;
            if (form4.Visible == false)
            {
                Changing.Enabled = true;
                checkBox1.Enabled = true;
            }
            if (form5.Visible == false)
            {
                Changing.Enabled = true;
                checkBox2.Enabled = true;
            }
            if (form6.Visible == false)
            {
                button6.Enabled = true;
                checkBox6.Enabled = true;
            }
            if (form7.Visible == false)
            {
                button6.Enabled = true;
                checkBox5.Enabled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (form2.gr.Name.Length > 0)
            {
                Spis.Add(form2.Data);
                listBox1.Items.Clear();
                listBox1.Items.Add("Имя группы       Математика   Программирование   Физ-ра ");
                for (int i = 0; i < Spis.Count; i++)
                {
                    listBox1.Items.Add($"{Spis[i].Spec}=>{Spis[i].Name}:");
                    if (Spis[i].Students.Count == 0) listBox1.Items.Add($"[{Spis[i].Num_stud - Spis[i].Students.Count}]");
                    else
                    {
                        for (int j = 0; j < Spis[i].Students.Count; j++)
                        {
                            listBox1.Items.Add($"[{j + 1}]{string.Concat<string>(Spis[i].Students[j].Name_yourself())}\n");
                            if (j == Spis[i].Students.Count - 1) listBox1.Items.Add($"[{Spis[i].Num_stud - Spis[i].Students.Count}]");
                        }
                    }
                }
                form2.gr = new Group();
            }
            else
            {
                MessageBox.Show("Введите коректные данные группы", "Ошибка", MessageBoxButtons.OK);
                form2.gr = new Group();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            form3 = new Form3();
            form3.Show();
            if (form3.Visible == true) button2.Enabled = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string group = form3.Data.Group;
            int pos = -1;
            for (int i = 0; i < Spis.Count; i++) if (group == Spis[i].Name) pos = i;

            if (pos == -1)
            {
                DialogResult result = MessageBox.Show("Группа студента не соответствует, ни одной из существующих.\n" +
                                                      "Введите существующее значение.",
                                                      "Ошибка", MessageBoxButtons.OK);
            }
            else 
            { 
                Spis[pos].Students.Add(form3.Data);
                listBox1.Items.Clear();
                listBox1.Items.Add("Имя группы       Математика   Программирование   Физ-ра ");

                for (int i = 0; i < Spis.Count; i++)
                {
                    listBox1.Items.Add($"{Spis[i].Spec}=>{Spis[i].Name}:");
                    if (Spis[i].Students.Count == 0) listBox1.Items.Add($"[{Spis[i].Num_stud - Spis[i].Students.Count}]");
                    for (int j = 0; j < Spis[i].Students.Count; j++)
                    {
                        listBox1.Items.Add($"[{j + 1}]{Spis[i].Students[j].Name_yourself()[0] + Spis[i].Students[j].Name_yourself()[1]}\n");
                        if (j == Spis[i].Students.Count - 1) listBox1.Items.Add($"[{Spis[i].Num_stud - Spis[i].Students.Count}]");
                    }
                }
            }
            form3.st = new Student();
        }

        private void Changing_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked && checkBox2.Checked)
            {
                DialogResult result = MessageBox.Show("Выберите один из двух пунктов .\n",
                                                          "Ошибка", MessageBoxButtons.OK);
            }
            else if (checkBox1.Checked)
            {
                form4 = new Form4();
                form4.Show();
                if (form4.Visible == true)
                {
                    Changing.Enabled = false;
                    checkBox1.Enabled = false;
                }
            }
            else if(checkBox2.Checked)
            {
                form5 = new Form5();
                form5.Show();
                if (form5.Visible == true)
                {
                    Changing.Enabled = false;
                    checkBox2.Enabled = false;
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked && checkBox2.Checked)
            {
                DialogResult result = MessageBox.Show("Выберите один из двух пунктов .\n",
                                                          "Ошибка", MessageBoxButtons.OK);
            }
            else if (checkBox1.Checked)
            {
                string group = form4.GroupForChanging;
                int pos = -1;
                for (int i = 0; i < Spis.Count; i++) if (group == Spis[i].Name) pos = i;

                if (pos == -1)
                {
                    DialogResult result = MessageBox.Show("Группа для редактирования не соответствует, ни одной из существующих.\n" +
                                                          "Введите существующее значение.",
                                                          "Ошибка", MessageBoxButtons.OK);
                }
                else
                {
                    Spis[pos].Name = form4.Data.Name;
                    Spis[pos].Spec = form4.Data.Spec;
                    Spis[pos].Num_stud = form4.Data.Num_stud;

                    listBox1.Items.Clear();
                    listBox1.Items.Add("Имя группы       Математика   Программирование   Физ-ра ");

                    for (int i = 0; i < Spis.Count; i++)
                    {
                        listBox1.Items.Add($"{Spis[i].Spec}=>{Spis[i].Name}:");
                        if (Spis[i].Students.Count == 0) listBox1.Items.Add($"[{Spis[i].Num_stud - Spis[i].Students.Count}]");
                        for (int j = 0; j < Spis[i].Students.Count; j++)
                        {
                            if (Spis[i].Students[j].Group != Spis[i].Name)listBox1.Items.Add(
                               $"[{j + 1}]{Spis[i].Students[j].Name_yourself()[0] + Spis[i].Students[j].Name_yourself()[1]}[X]\n");
                            else if (Spis[i].Students[j].Group == Spis[i].Name) listBox1.Items.Add(
                               $"[{j + 1}]{Spis[i].Students[j].Name_yourself()[0] + Spis[i].Students[j].Name_yourself()[1]}\n");
                            if (j == Spis[i].Students.Count - 1) listBox1.Items.Add($"[{Spis[i].Num_stud - Spis[i].Students.Count}]");
                        }
                    }
                }
                form4.gr_pattern = new Group();
                checkBox1.Enabled = true;
            }
            else if(checkBox2.Checked)
            {
                string group = form5.Data.Group;
                int posgr = -1;
                for (int i = 0; i < Spis.Count; i++) if (group == Spis[i].Name) posgr = i;
                if (posgr == -1)
                {
                    DialogResult result = MessageBox.Show("Группа для редактирования в ней студента не соответствует, ни одной из существующих.\n" +
                                                          "Введите существующее значение.",
                                                          "Ошибка", MessageBoxButtons.OK);
                }
                else
                {

                    string name = form5.StudentForChanging[0];
                    int posnm = -1;
                    for (int i = 0; i < Spis[posgr].Students.Count; i++) if (name == Spis[posgr].Students[i].Name) posnm = i;

                    if (posnm == -1)
                    {
                        DialogResult result = MessageBox.Show("В данной группе не существует студента с таким именем.\n" +
                                                          "Введите существующее значение.",
                                                          "Ошибка", MessageBoxButtons.OK);
                    }
                    else
                    {
                        Spis[posgr].Students[posnm].Name = form5.Data.Name;
                        Spis[posgr].Students[posnm].Group = form5.Data.Group;
                        Spis[posgr].Students[posnm].SetGrade(form5.Data.GradesInInt(0), 0);
                        Spis[posgr].Students[posnm].SetGrade(form5.Data.GradesInInt(1), 1);
                        Spis[posgr].Students[posnm].SetGrade(form5.Data.GradesInInt(2), 2);

                        listBox1.Items.Clear();
                        listBox1.Items.Add("Имя группы       Математика   Программирование   Физ-ра ");

                        for (int i = 0; i < Spis.Count; i++)
                        {
                            listBox1.Items.Add($"{Spis[i].Spec}=>{Spis[i].Name}:");
                            if (Spis[i].Students.Count == 0) listBox1.Items.Add($"[{Spis[i].Num_stud - Spis[i].Students.Count}]");
                            for (int j = 0; j < Spis[i].Students.Count; j++)
                            {
                                if (Spis[i].Students[j].Group != Spis[i].Name) listBox1.Items.Add(
                                    $"[{j + 1}]{Spis[i].Students[j].Name_yourself()[0] + Spis[i].Students[j].Name_yourself()[1]}[X]\n");
                                else if (Spis[i].Students[j].Group == Spis[i].Name) listBox1.Items.Add(
                                   $"[{j + 1}]{Spis[i].Students[j].Name_yourself()[0] + Spis[i].Students[j].Name_yourself()[1]}\n");
                                if (j == Spis[i].Students.Count - 1) listBox1.Items.Add($"[{Spis[i].Num_stud - Spis[i].Students.Count}]");
                            }
                        }
                        form5.st_pattern = new Student();
                        checkBox2.Enabled = true;
                    }
                }

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if(checkBox3.Checked && checkBox4.Checked)
            {
                DialogResult result = MessageBox.Show("Выберите один из двух пунктов .\n",
                                                          "Ошибка", MessageBoxButtons.OK);
            }
            else if (checkBox3.Checked)
            {
                button5.Enabled = false;
                checkBox3.Enabled = false;
                string gr = textBox4.Text;
                int posgr = -1;
                for (int i = 0; i < Spis.Count; i++) if (gr == Spis[i].Name) posgr = i;
                if (posgr == -1)
                {
                    DialogResult result = MessageBox.Show("Группа для редактирования в ней студента не соответствует, ни одной из существующих.\n" +
                                      "Введите существующее значение.",
                                      "Ошибка", MessageBoxButtons.OK);
                }
                else
                {
                    string nm = textBox1.Text;
                    int posnm = -1;
                    for (int i = 0; i < Spis[posgr].Students.Count; i++) if (nm == Spis[posgr].Students[i].Name) posnm = i;
                    if (posnm == -1)
                    {
                        DialogResult result = MessageBox.Show("В группе не существует студента с таким именем.\n" +
                                      "Введите существующее значение.",
                                      "Ошибка", MessageBoxButtons.OK);
                    }
                    else
                    {
                        string grN = textBox2.Text;
                        int posgrN = -1;
                        for (int i = 0; i < Spis.Count; i++) if (grN == Spis[i].Name) posgrN = i;
                        if (posgrN == -1)
                        {
                            DialogResult result = MessageBox.Show("Группа в которую необходимо переместить студента не существует.\n" +
                                          "Введите существующее значение.",
                                          "Ошибка", MessageBoxButtons.OK);
                        }
                        else
                        {
                            Spis[posgrN].Students.Add(Spis[posgr].Students[posnm]);
                            Spis[posgr].Students.RemoveAt(posnm);

                            listBox1.Items.Clear();
                            listBox1.Items.Add("Имя группы       Математика   Программирование   Физ-ра ");

                            for (int i = 0; i < Spis.Count; i++)
                            {
                                listBox1.Items.Add($"{Spis[i].Spec}=>{Spis[i].Name}:");
                                if (Spis[i].Students.Count == 0) listBox1.Items.Add($"[{Spis[i].Num_stud - Spis[i].Students.Count}]");
                                for (int j = 0; j < Spis[i].Students.Count; j++)
                                {
                                    if (Spis[i].Students[j].Group != Spis[i].Name) listBox1.Items.Add(
                                        $"[{j + 1}]{Spis[i].Students[j].Name_yourself()[0] + Spis[i].Students[j].Name_yourself()[1]}[X]\n");
                                    else if (Spis[i].Students[j].Group == Spis[i].Name) listBox1.Items.Add(
                                       $"[{j + 1}]{Spis[i].Students[j].Name_yourself()[0] + Spis[i].Students[j].Name_yourself()[1]}\n");
                                    if (j == Spis[i].Students.Count - 1) listBox1.Items.Add($"[{Spis[i].Num_stud - Spis[i].Students.Count}]");
                                }
                            }
                        }
                    }
                }
                button5.Enabled = true;
                checkBox3.Enabled = true;
            }
            else if(checkBox4.Checked)
            {
                button5.Enabled = false;
                checkBox3.Enabled = false;
                string gr = textBox4.Text;
                int posgr = -1;
                for (int i = 0; i < Spis.Count; i++) if (gr == Spis[i].Name) posgr = i;
                if (posgr == -1)
                {
                    DialogResult result = MessageBox.Show("Группа не соответствует, ни одной из существующих.\n" +
                                      "Введите существующее значение.",
                                      "Ошибка", MessageBoxButtons.OK);
                }
                else
                {
                    int posnm = int.Parse(textBox1.Text);
                    if (posnm <= 0 && posnm > Spis[posgr].Students.Count)
                    {
                        DialogResult result = MessageBox.Show("Такого студента не существует в данной группе.\n" +
                                      "Введите существующее значение.",
                                      "Ошибка", MessageBoxButtons.OK);
                    }
                    else
                    {
                        string grN = textBox2.Text;
                        int posgrN = -1;
                        for (int i = 0; i < Spis.Count; i++) if (grN == Spis[i].Name) posgrN = i;
                        if (posgrN == -1)
                        {
                            DialogResult result = MessageBox.Show("Группа в которую необходимо переместить студента не существует.\n" +
                                          "Введите существующее значение.",
                                          "Ошибка", MessageBoxButtons.OK);
                        }
                        else
                        {
                            Spis[posgrN].Students.Add(Spis[posgr].Students[posnm - 1]);
                            Spis[posgr].Students.RemoveAt(posnm - 1);

                            listBox1.Items.Clear();
                            listBox1.Items.Add("Имя группы       Математика   Программирование   Физ-ра ");

                            for (int i = 0; i < Spis.Count; i++)
                            {
                                listBox1.Items.Add($"{Spis[i].Spec}=>{Spis[i].Name}:");
                                if (Spis[i].Students.Count == 0) listBox1.Items.Add($"[{Spis[i].Num_stud - Spis[i].Students.Count}]");
                                for (int j = 0; j < Spis[i].Students.Count; j++)
                                {
                                    if (Spis[i].Students[j].Group != Spis[i].Name) listBox1.Items.Add(
                                        $"[{j + 1}]{Spis[i].Students[j].Name_yourself()[0] + Spis[i].Students[j].Name_yourself()[1]}[X]\n");
                                    else if (Spis[i].Students[j].Group == Spis[i].Name) listBox1.Items.Add(
                                       $"[{j + 1}]{Spis[i].Students[j].Name_yourself()[0] + Spis[i].Students[j].Name_yourself()[1]}\n");
                                    if (j == Spis[i].Students.Count - 1) listBox1.Items.Add($"[{Spis[i].Num_stud - Spis[i].Students.Count}]");
                                }
                            }
                        }
                    }
                }
                button5.Enabled = true;
                checkBox3.Enabled = true;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if(checkBox6.Checked && checkBox5.Checked)
            {
                DialogResult result = MessageBox.Show("Выберите один из двух пунктов .\n",
                                                              "Ошибка", MessageBoxButtons.OK);
            }
            else if(checkBox6.Checked)
            {
                button6.Enabled = false;
                checkBox6.Enabled = false;
                form6 = new Form6();
                form6.Show();
            }
            else if(checkBox5.Checked)
            {
                button6.Enabled = false;
                checkBox5.Enabled = false;
                form7 = new Form7();
                form7.Show();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            if (checkBox6.Checked && checkBox5.Checked)
            {
                    DialogResult result = MessageBox.Show("Выберите один из двух пунктов .\n",
                                                              "Ошибка", MessageBoxButtons.OK);
            }
            else if (checkBox6.Checked)
            {
                if (form6.Search_mode == true) listBox2.Items.Add("Имя группы                  Математика   Программирование   Физ-ра ");
                else listBox2.Items.Add("Имя группы");

                int DeepOfSearching = 0;
                bool finded = false;
                for (int i = 0; i < 3; i++)
                {
                    if (form6.Data.GradesInInt(i) != -1) DeepOfSearching++;
                }

                for (int i = 0; i < Spis.Count; i++)
                {
                    for (int j = 0; j < Spis[i].Students.Count; j++)
                    {
                        for (int k = 0, n = 0; k < DeepOfSearching && n < 3; n++ )
                        {
                            if (Spis[i].Students[j].GradesInInt(n) == form6.Data.GradesInInt(n))
                            {
                                k++;
                                if (k == DeepOfSearching) finded = true;
                            }
                        }
                        if (finded)
                        {
                            if (form6.Search_mode == true)
                            {
                                listBox2.Items.Add($"[{i + 1}]->{Spis[i].Students[j].Group}:" +
                                    $"{Spis[i].Students[j].Name_yourself()[0],-16}" +
                                    $"{Spis[i].Students[j].GradesInInt(0),2}" +
                                    $"{Spis[i].Students[j].GradesInInt(1),15}" +
                                    $"{Spis[i].Students[j].GradesInInt(2),15}]");
                            }
                            else if (form6.Search_mode == false)
                            {
                                listBox2.Items.Add($"[{i + 1}]->{Spis[i].Students[j].Group}:{Spis[i].Students[j].Name}]");
                            }
                            finded = false;
                        }
                    }
                }
            }
            else if(checkBox5.Checked)
            {
                if (form7.Search_mode == true) listBox2.Items.Add("Имя группы                  Математика   Программирование   Физ-ра ");
                else listBox2.Items.Add("Имя группы");

                for(int i = 0; i < Spis.Count; i++)
                {
                    for(int j = 0; j < Spis[i].Students.Count; j++)
                    {
                        if (Spis[i].Students[j].Name.Equals(form7.Data.Name,StringComparison.OrdinalIgnoreCase))
                        {
                            if (form7.Search_mode == true)
                            {
                                listBox2.Items.Add($"[{i + 1}]->{Spis[i].Students[j].Group}:" +
                                    $"{Spis[i].Students[j].Name_yourself()[0],-16}" +
                                    $"{Spis[i].Students[j].GradesInInt(0),2}" +
                                    $"{Spis[i].Students[j].GradesInInt(1),15}" +
                                    $"{Spis[i].Students[j].GradesInInt(2),15}]");
                            }
                            else if (form7.Search_mode == false)
                            {
                                listBox2.Items.Add($"[{i + 1}]->{Spis[i].Students[j].Group}:{Spis[i].Students[j].Name}]");
                            }
                        }
                    }
                }
            }
            form6.st = new Student();
            form7.st = new Student();
        }
    }
}
