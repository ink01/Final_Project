using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Final_Project
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        int AsSum;
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (textBox1.Text == "")
                {
                    MessageBox.Show("กรุณาใส่ชื่อผู้ซื้อ", "ระบบผิดพลาด");
                }
                else
                {
                    maskedTextBox1.Focus();

                }
            }

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            //items for comboBox1
            comboBox1.Items.Add("รุ่น Yamaha");
            comboBox1.Items.Add("รุ่น Epiphone");
            comboBox1.Items.Add("รุ่น Taylor");
            comboBox1.Items.Add("รุ่น Gibson");
            comboBox1.Items.Add("รุ่น Martin");

            //items for comboBox2
            comboBox2.Items.Add("1");
            comboBox2.Items.Add("2");
            comboBox2.Items.Add("3");
            comboBox2.Items.Add("4");
            comboBox2.Items.Add("5");
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "รุ่น Yamaha") textBox3.Text = "3100";
            if (comboBox1.Text == "รุ่น Epiphone") textBox3.Text = "4950";
            if (comboBox1.Text == "รุ่น Taylor") textBox3.Text = "13000";
            if (comboBox1.Text == "รุ่น Gibson") textBox3.Text = "9800";
            if (comboBox1.Text == "รุ่น Martin") textBox3.Text = "6000";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            int P1, A1, Sum, Total ;
            int As1, As2, As3, As4, As5;
            P1 = int.Parse(textBox3.Text);
            A1 = int.Parse(comboBox2.Text);
            Sum = P1 * A1;
            
            if (checkBox1.Checked == true)
            {
                As1 = 50;
                AsSum += As1;
            }
            if (checkBox2.Checked == true)
            {
                As2 = 135;
                AsSum += As2;
            }
            if (checkBox5.Checked == true)
            {
                As3 = 1200;
                AsSum += As3;
            }
            if (checkBox3.Checked == true)
            {
                As4 = 3000;
                AsSum += As4;
            }
            if (checkBox4.Checked == true)
            {
                As5 = 10;
                AsSum += As5;
            }

            Total = Sum + AsSum;
            textBox4.Text = Total.ToString();

        }

        private void textBox5_KeyDown(object sender, KeyEventArgs e)
        {
            int K, B, T;

            if (e.KeyCode == Keys.Enter)
            {
                if (textBox5.Text == "")
                {
                    MessageBox.Show("กรุณาใส่จำนวนเงิน", "ระบบผิดพลาด");
                }
                else
                {
                    K = int.Parse(textBox4.Text);
                    B = int.Parse(textBox5.Text);
                    if (B < K)
                    {
                        MessageBox.Show("ยอดเงินไม่พอ", "ระบบผิดพลาด");
                        textBox5.SelectAll();
                    }
                    else
                    {
                        T = B - K;
                        textBox6.Text = T.ToString();
                    }
                }
            }            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();

            maskedTextBox1.Text = "___-___ ____";

            comboBox1.Text = "-กรุณาเลือกรุ่นกีต้าร์-";
            comboBox2.Text = "";

            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            checkBox4.Checked = false;
            checkBox5.Checked = false;

            textBox1.Focus();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "CSV (*.csv)|*.csv";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string[] readAllLine = File.ReadAllLines(openFileDialog.FileName);
                string readAllText = File.ReadAllText(openFileDialog.FileName);

                for (int i = 0; i < readAllLine.Length; i++)
                {
                    string BBgunRAW = readAllLine[i];
                    string[] BBgunSplited = BBgunRAW.Split(',');
                    Guitar bbgunSweet = new Guitar(BBgunSplited[0], BBgunSplited[1], BBgunSplited[2], 
                        BBgunSplited[3], BBgunSplited[4], BBgunSplited[5], BBgunSplited[6]);
                    addDataToGridView("name", "number", "type", "amount","price","date", "accessories");
                }
            }
        }
        void addDataToGridView(string name, string num, string type, 
            string amount, string price, string date, string accessories)
        {
            this.dataGridView1.Rows.Add(new string[] { name, num, type, amount, price, date, accessories });
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string filepath = string.Empty;
            if (dataGridView1.Rows.Count > 0)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "CSV(*.csv)|*.csv";
                bool fileError = false;
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    if (!fileError)
                    {
                        try
                        {
                            int columnCount = dataGridView1.Columns.Count;
                            string columnNames = "";
                            string[] outputCSV = new string[dataGridView1.Rows.Count + 1];
                            for (int i = 0; i < columnCount; i++)
                            {
                                columnNames += dataGridView1.Columns[i].HeaderText.ToString() + ",";
                            }
                            outputCSV[0] += columnNames;
                            for (int i = 1; (i - 1) < dataGridView1.Rows.Count; i++)
                            {
                                for (int j = 0; j < columnCount; j++)
                                {
                                    outputCSV[i] += dataGridView1.Rows[i - 1].Cells[j].Value.ToString() + ",";
                                }
                            }
                            File.WriteAllLines(sfd.FileName, outputCSV, Encoding.UTF8);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error :" + ex.Message);
                        }
                    }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int n = dataGridView1.Rows.Add();
            dataGridView1.Rows[n].Cells[0].Value = textBox1.Text;
            dataGridView1.Rows[n].Cells[1].Value = maskedTextBox1.Text;
            dataGridView1.Rows[n].Cells[2].Value = comboBox1.Text;
            dataGridView1.Rows[n].Cells[3].Value = comboBox2.Text;
            dataGridView1.Rows[n].Cells[4].Value = textBox4.Text;
            dataGridView1.Rows[n].Cells[5].Value = DateTime.Now.ToString();
            dataGridView1.Rows[n].Cells[6].Value = AsSum.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("ขอบคุณครับ", "ปิดโปรแกรม");
            Close();
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
