using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniBankAccountAppplication
{
    public partial class Form1 : Form
    {

            List<BankAccount> allData = new List<BankAccount>();
        public Form1()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
                return;
            BankAccount abccc = new BankAccount(textBox1.Text);
            allData.Add(abccc);

            RefreshGuid();
            MessageBox.Show("Account created successfully");
        }


        private void RefreshGuid()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = allData;
            textBox1.Text = "";
           

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an account first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            BankAccount selectAccount = dataGridView1.SelectedRows[0].DataBoundItem as BankAccount;

            try
            {
                selectAccount.Deposit(numericUpDown1.Value); // Use Deposit method
                RefreshGuid();   // Refresh DataGridView
                numericUpDown1.Value = 0;
                MessageBox.Show("Deposit successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }



        private void button3_Click(object sender, EventArgs e)

        { 

            BankAccount selectAccount = dataGridView1.SelectedRows[0].DataBoundItem as BankAccount;
            decimal withdrawalAmount = numericUpDown1.Value;


            if (selectAccount.Balance < withdrawalAmount)
            {
                MessageBox.Show($"Insufficient funds. Only");
            }


            selectAccount.Balance -= numericUpDown1.Value;
            RefreshGuid();
            numericUpDown1.Value = 0;
        }

    }

}

