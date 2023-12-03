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
using System.Data.SqlClient;

namespace KR_Interface
{
    public partial class SignUp : Form
    {
        public LogIn frm_logIn;
        DataBase database = new DataBase();
        public SignUp()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string loginUser = LoginBox.Text;
            string passwordUser = PasswordBox1.Text;
            

            if ((PasswordBox1.Text == PasswordBox2.Text) && !CheckUser(loginUser))
            {
                string querystring = $"insert into register (login_user, password_user) values ('{loginUser}', '{passwordUser}');";

                SqlCommand command = new SqlCommand(querystring, database.GetConnection());
                database.OpenConnection();
                if (command.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Аккаунт успешно создан!", "Успех!");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Аккааунт не создан!");
                }
                database.CloseConnection();
            }
            else { MessageBox.Show($"Проверьте введенные данные!", $"Неверные данные"); }
        }
        private bool CheckUser(string loginUser)
        {
            string querystring = $"select id_user, login_user, password_user from register where login_user = '{loginUser}'";

            DataTable table = new DataTable();
            SqlCommand command = new SqlCommand(querystring, database.GetConnection());

            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = command;
            adapter.Fill(table);
            if (table.Rows.Count != 0)
            {
                MessageBox.Show("Пользователь уже существует!");
                return true;
            }
            return false;
        }

        private void SignUp_FormClosing(object sender, FormClosingEventArgs e)
        {

            frm_logIn.Show();
        }
    }
}
