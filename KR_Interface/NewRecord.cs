using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using KR_Interface.Properties;

namespace KR_Interface
{
    public partial class NewRecord : Form
    {
        DataBase database = new DataBase();
        public NewRecord()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            database.OpenConnection();
            switch (RecordTypeLabel.Text)
            {
                case "Новая запись: Направление":
                    {
                        var name = (string)dataGridView1.Rows[0].Cells[1].Value;
                        var category = (string)dataGridView1.Rows[0].Cells[2].Value;
                        var department = (string)dataGridView1.Rows[0].Cells[3].Value;

                        //if (int.TryParse(, out)) {
                            var addQuery = $"insert into Direction (direction_name, category, direction_department) values('{name}','{category}','{department}')";
                            var command = new SqlCommand(addQuery, database.GetConnection());
                            command.ExecuteNonQuery();

                            MessageBox.Show("Запись успешно добавлена!");
                        /*}
                        else
                            MessageBox.Show("Проверьте числовые значения");//*/
                    }
                    break;
                case "Новая запись: Научный руководитель":
                    {
                        var name = (string)dataGridView1.Rows[0].Cells[1].Value;
                        var department = (string)dataGridView1.Rows[0].Cells[2].Value;

                        //if (int.TryParse(, out)) {
                        var addQuery = $"insert into Scientific_director (director_name, director_department) values('{name}','{department}')";
                        var command = new SqlCommand(addQuery, database.GetConnection());
                        command.ExecuteNonQuery();

                        MessageBox.Show("Запись успешно добавлена!");
                        /*}
                        else
                            MessageBox.Show("Проверьте числовые значения");//*/
                    }
                    break;
                case "Новая запись: Научный руководитель и направление ":
                    {
                        int director_id; 
                        int direction_id;

                        if (int.TryParse((string)dataGridView1.Rows[0].Cells[1].Value, out director_id) && int.TryParse((string)dataGridView1.Rows[0].Cells[2].Value, out direction_id)) {
                        var addQuery = $"insert into Scientific_director_Direction (director_id, direction_id) values({director_id},{direction_id})";
                        var command = new SqlCommand(addQuery, database.GetConnection());
                        command.ExecuteNonQuery();

                        MessageBox.Show("Запись успешно добавлена!");
                        }
                        else
                            MessageBox.Show("Проверьте числовые значения!");//*/
                    }
                    break;
                case "Новая запись: Научный совет":
                    {
                        var composition = (string)dataGridView1.Rows[0].Cells[1].Value;
                        int number_of_successfull_defendings;
                        int total_number_of_successfull_defendings;

                        if (int.TryParse((string)dataGridView1.Rows[0].Cells[2].Value, out number_of_successfull_defendings) && int.TryParse((string)dataGridView1.Rows[0].Cells[3].Value, out total_number_of_successfull_defendings))
                        {
                            var addQuery = $"insert into Science_council (composition, number_of_successfull_defendings, total_number_of_defendings)" +
                                $" values('{composition}',{number_of_successfull_defendings}, {total_number_of_successfull_defendings})";
                            var command = new SqlCommand(addQuery, database.GetConnection());
                            command.ExecuteNonQuery();

                            MessageBox.Show("Запись успешно добавлена!");
                        }
                        else
                            MessageBox.Show("Проверьте числовые значения");//*/
                    }
                    break;
                case "Новая запись: Научный совет и направление":
                    {
                        int council_id;
                        int direction_id;

                        if (int.TryParse((string)dataGridView1.Rows[0].Cells[1].Value, out council_id) && int.TryParse((string)dataGridView1.Rows[0].Cells[2].Value, out direction_id))
                        {
                            var addQuery = $"insert into Scientific_director_Direction (director_id, direction_id) values({council_id},{direction_id})";
                            var command = new SqlCommand(addQuery, database.GetConnection());
                            command.ExecuteNonQuery();

                            MessageBox.Show("Запись успешно добавлена!");
                        }
                        else
                            MessageBox.Show("Проверьте числовые значения!");//*/
                    }
                    break;
                case "Новая запись: Аспирант":
                    {
                        int director_id;
                        int direction_id;
                        var name = (string)dataGridView1.Rows[0].Cells[3].Value;
                        var date_of_birth = (string)dataGridView1.Rows[0].Cells[4].Value;
                        int awards;
                        var diploms = (string)dataGridView1.Rows[0].Cells[6].Value; 

                        if (int.TryParse((string)dataGridView1.Rows[0].Cells[1].Value, out director_id) && int.TryParse((string)dataGridView1.Rows[0].Cells[2].Value, out direction_id) &&
                            int.TryParse((string)dataGridView1.Rows[0].Cells[5].Value, out awards))
                        {
                            var addQuery = $"insert into Graduate_student (director_id, direction_id, student_name, date_of_birth, awards, diploms)" +
                                $" values({director_id},{direction_id}, '{name}','{date_of_birth}',{awards}, '{diploms}' )";
                            var command = new SqlCommand(addQuery, database.GetConnection());
                            command.ExecuteNonQuery();

                            MessageBox.Show("Запись успешно добавлена!");
                        }
                        else
                            MessageBox.Show("Проверьте числовые значения");//*/
                    }
                    break;
                case "Новая запись: Публикация":
                    {
                        int student_id;
                        var name = (string)dataGridView1.Rows[0].Cells[2].Value;
                        var resource = (string)dataGridView1.Rows[0].Cells[3].Value; 
                        var date = (string)dataGridView1.Rows[0].Cells[4].Value;

                        if (int.TryParse((string)dataGridView1.Rows[0].Cells[1].Value, out student_id))
                        {
                            var addQuery = $"insert into Publication (student_id, publication_name, publication_resource, publication_date)" +
                                $" values({student_id},'{name}', '{resource}', '{date}')";
                            var command = new SqlCommand(addQuery, database.GetConnection());
                            command.ExecuteNonQuery();

                            MessageBox.Show("Запись успешно добавлена!");
                        }
                        else
                            MessageBox.Show("Проверьте числовые значения");//*/
                    }
                    break;
                case "Новая запись: Защита":
                    {
                        int council_id;
                        int student_id;
                        var date = (string)dataGridView1.Rows[0].Cells[3].Value;
                        var decision = (string)dataGridView1.Rows[0].Cells[4].Value;

                        if (int.TryParse((string)dataGridView1.Rows[0].Cells[2].Value, out council_id) && int.TryParse((string)dataGridView1.Rows[0].Cells[2].Value, out student_id))
                        {
                            var addQuery = $"insert into Defending (council_id, student_id, defending_date, council_decision)" +
                                $" values({council_id},{student_id}, '{date}', '{decision}')";
                            var command = new SqlCommand(addQuery, database.GetConnection());
                            command.ExecuteNonQuery();

                            MessageBox.Show("Запись успешно добавлена!");
                        }
                        else
                            MessageBox.Show("Проверьте числовые значения");//*/
                    }
                    break;

            }
        }
    }
}
