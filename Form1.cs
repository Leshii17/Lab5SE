using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace Lab1
{
    public partial class Form1 : Form
    {
        private DataGridViewColumn dataGridViewColumn1 = null;
        private DataGridViewColumn dataGridViewColumn2 = null;
        private DataGridViewColumn dataGridViewColumn3 = null;
        private DataGridViewColumn dataGridViewColumn4 = null;
        private DataGridViewColumn dataGridViewColumn5 = null;

        private LinkedList<Citizen> citizenList = new LinkedList<Citizen>();

        public Form1()
        {
            InitializeComponent();
            initDataGridView();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String gender;
            if (radioButton1.Checked)
            {
                gender = "Мужской";
            }
            else
            {
                gender = "Женский";
            }
            addCitizen(textBox1.Text, textBox2.Text, gender, Int32.Parse(textBox4.Text), textBox5.Text);
        }

        private void addCitizen(string name, string surname, string gender, int age, string identNumber)
        {
            if (age < 18 || age > 110)
            {
                DialogResult dr = MessageBox.Show("Указан неверный возраст", "Ошибка", MessageBoxButtons.OK);
                return;
            }
            citizenList.AddLast(new Citizen(name, surname, gender, age, identNumber));
            textBox1.Text = "";
            textBox2.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            showListInGrid();
        }

        private void deleteCitizen(int elemIndex)
        {
            LinkedListNode<Citizen> tmp;
            tmp = citizenList.First;
            for (int i = 0; i != elemIndex; i++)
            {
                tmp = tmp.Next;
            }
            citizenList.Remove(tmp);
            showListInGrid();
        }

        private void showListInGrid()
        {
            dataGridView1.Rows.Clear();
            foreach (Citizen s in citizenList)
            {
                DataGridViewRow row = new DataGridViewRow();
                DataGridViewTextBoxCell cell1 = new DataGridViewTextBoxCell();
                DataGridViewTextBoxCell cell2 = new DataGridViewTextBoxCell();
                DataGridViewTextBoxCell cell3 = new DataGridViewTextBoxCell();
                DataGridViewTextBoxCell cell4 = new DataGridViewTextBoxCell();
                DataGridViewTextBoxCell cell5 = new DataGridViewTextBoxCell();
                cell1.ValueType = typeof(string);
                cell1.Value = s.Name_;
                cell2.ValueType = typeof(string);
                cell2.Value = s.Surname_;
                cell3.ValueType = typeof(string);
                cell3.Value = s.Gender_;
                cell4.ValueType = typeof(uint);
                cell4.Value = s.Age_;
                cell5.ValueType = typeof(string);
                cell5.Value = s.IdentNumer_;
                row.Cells.Add(cell1);
                row.Cells.Add(cell2);
                row.Cells.Add(cell3);
                row.Cells.Add(cell4);
                row.Cells.Add(cell5);
                dataGridView1.Rows.Add(row);
            }
        }


        //Инициализация таблицы
        private void initDataGridView()
        {
            dataGridView1.DataSource = null;
            dataGridView1.Columns.Add(getDataGridViewColumn1());
            dataGridView1.Columns.Add(getDataGridViewColumn2());
            dataGridView1.Columns.Add(getDataGridViewColumn3());
            dataGridView1.Columns.Add(getDataGridViewColumn4());
            dataGridView1.Columns.Add(getDataGridViewColumn5());
            dataGridView1.AutoResizeColumns();
        }

        //Динамическое создание первой колонки в таблице
        private DataGridViewColumn getDataGridViewColumn1()
        {
            if (dataGridViewColumn1 == null)
            {
                dataGridViewColumn1 = new DataGridViewTextBoxColumn();
                dataGridViewColumn1.Name = "";
                dataGridViewColumn1.HeaderText = "Имя";
                dataGridViewColumn1.ValueType = typeof(string);
                dataGridViewColumn1.Width = dataGridView1.Width / 5;
            }
            return dataGridViewColumn1;
        }

        //Динамическое создание второй колонки в таблице
        private DataGridViewColumn getDataGridViewColumn2()
        {
            if (dataGridViewColumn2 == null)
            {
                dataGridViewColumn2 = new DataGridViewTextBoxColumn();
                dataGridViewColumn2.Name = "";
                dataGridViewColumn2.HeaderText = "Фамилия";
                dataGridViewColumn2.ValueType = typeof(string);
                dataGridViewColumn2.Width = dataGridView1.Width / 5;
            }
            return dataGridViewColumn2;
        }

        //Динамическое создание третей колонки в таблице
        private DataGridViewColumn getDataGridViewColumn3()
        {
            if (dataGridViewColumn3 == null)
            {
                dataGridViewColumn3 = new DataGridViewTextBoxColumn();
                dataGridViewColumn3.Name = "";
                dataGridViewColumn3.HeaderText = "Пол";
                dataGridViewColumn3.ValueType = typeof(string);
                dataGridViewColumn3.Width = dataGridView1.Width / 5;
            }
            return dataGridViewColumn3;
        }

        private DataGridViewColumn getDataGridViewColumn4()
        {
            if (dataGridViewColumn4 == null)
            {
                dataGridViewColumn4 = new DataGridViewTextBoxColumn();
                dataGridViewColumn4.Name = "";
                dataGridViewColumn4.HeaderText = "Возраст";
                dataGridViewColumn4.ValueType = typeof(uint);
                dataGridViewColumn4.Width = dataGridView1.Width / 5;
            }
            return dataGridViewColumn4;
        }

        private DataGridViewColumn getDataGridViewColumn5()
        {
            if (dataGridViewColumn5 == null)
            {
                dataGridViewColumn5 = new DataGridViewTextBoxColumn();
                dataGridViewColumn5.Name = "";
                dataGridViewColumn5.HeaderText = "Идентификационный номер";
                dataGridViewColumn5.ValueType = typeof(string);
                dataGridViewColumn5.Width = dataGridView1.Width / 5;
            }
            return dataGridViewColumn5;
        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int selectedRow = dataGridView1.SelectedCells[0].RowIndex;
            DialogResult dr = MessageBox.Show("Удалить гражданина?", "",
            MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                try
                {
                    deleteCitizen(selectedRow);
                }
                catch (Exception)
                {
                }
            }

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                radioButton2.Checked = false;
                radioButton1.Checked = true;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                radioButton1.Checked = false;
                radioButton2.Checked = true;
            }
        }
    }
}
