using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KR_Interface
{
    public partial class LogIn : Form
    {
        DataBase database = new DataBase();
        public LogIn()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void LogIn_Load(object sender, EventArgs e)
        {
            LoginBox.MaxLength = 50;
            PasswordBox.MaxLength = 50;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string loginUser = LoginBox.Text;
            string passwordUser = PasswordBox.Text;

            SqlDataAdapter adapter= new SqlDataAdapter();
            DataTable table = new DataTable();

            string querystring = $"select id_user, password_user from register where login_user = '{loginUser}' and password_user = '{passwordUser}'";

            SqlCommand command = new SqlCommand(querystring, database.GetConnection());

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count == 1)
            {
                MessageBox.Show("Вы успешно вошли!", "Успешно!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Form1 frm1 = new Form1(loginUser);
                frm1.logInWnd = this;
                frm1.Show();
                LoginBox.Text = "";
                PasswordBox.Text = "";
                this.Hide();
            }
            else
                MessageBox.Show("Введены неверные данные!", "Неверные данные!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SignUp frm_sign = new SignUp();
            frm_sign.frm_logIn = this;
            frm_sign.Show();
            this.Hide();
        }
    }
}
