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
    public partial class QueryWindow : Form
    {
        DataBase database = new DataBase();
        public Form1 form1;
        public ReportDialog report = null;
        bool created = false;
        public QueryWindow()
        {
            InitializeComponent();
        }
        public void ReadSingleRow_Query1(DataGridView dgv, IDataRecord record)
        {
            dgv.Rows.Add(record.GetInt32(0), record.GetString(1), record.GetString(2), record.GetString(3), record.GetString(4), record.GetInt32(5), record.GetString(6), record.GetString(7));
        }
        public void ReadSingleRow_Query4(DataGridView dgv, IDataRecord record)
        {
            dgv.Rows.Add(record.GetInt32(0), record.GetString(1), record.GetString(2), record.GetString(3), record.GetString(4), record.GetString(5));
        }
        public void ReadSingleRow_Query6(DataGridView dgv, IDataRecord record)
        {
            dgv.Rows.Add(record.GetInt32(0), record.GetString(1), record.GetInt32(2), record.GetInt32(3), record.GetString(4));
        }
        public static void CreateColums_DefReport(DataGridView dgv)
        {
            dgv.Columns.Add("ID", "id");
            dgv.Columns.Add("Student", "ФИО аспиранта");
            dgv.Columns.Add("Date", "Дата защиты");
            dgv.Columns.Add("Director", "ФИО научного руководителя");
            dgv.Columns.Add("Council composition", "Состав совета");
            dgv.Columns.Add("Department", "Кафедра");
            dgv.Columns.Add("Direction", "Направление");
            dgv.Columns.Add("Category", "Категория направления");
            dgv.Columns.Add("Council decision", "Решение совета");
        }
        public void ReadSingleRow_Report(DataGridView dgv, IDataRecord record)
        {
            dgv.Rows.Add(record.GetInt32(0), record.GetString(1), record.GetString(2), record.GetString(3), record.GetString(4), record.GetString(5), record.GetString(6), record.GetString(7), record.GetString(8));
        }
        private void button1_Click(object sender, EventArgs e)
        {
            DataGridView dgv = dataGridView1;
            if (report == null)
            {
                switch (QueryLabel.Text)
                {
                    case "Поиск аспирантов по категории":
                        {
                            dgv.Rows.Clear();
                            if(!created)
                                Form1.CreateColums_Students(dgv);
                            created = true;
                            string search =
                                $"select Graduate_student.student_id, Scientific_director.director_name, Direction.direction_name, Graduate_student.student_name, Graduate_student.date_of_birth, Graduate_student.awards, Graduate_student.diploms, Direction.category" +
                                $" from Graduate_student" +
                                $" inner join Scientific_director on Graduate_student.director_id = Scientific_director.director_id" +
                                $" inner join Direction on Graduate_student.direction_id = Direction.direction_id" +
                                $" where Direction.category like '%" + textBox1.Text + "%'";//*/
                            SqlCommand com = new SqlCommand(search, database.GetConnection());

                            database.OpenConnection();
                            SqlDataReader read = com.ExecuteReader();
                            while (read.Read())
                            {
                                ReadSingleRow_Query1(dgv, read);
                            }
                            read.Close();
                        }
                        break;
                    case "Поиск аспирантов по кафедрам":
                        {
                            dgv.Rows.Clear();
                            if (!created)
                                Form1.CreateColums_Students(dgv);
                            created = true;
                            string search =
                                $"select Graduate_student.student_id, Scientific_director.director_name, Direction.direction_name, Graduate_student.student_name, Graduate_student.date_of_birth, Graduate_student.awards, Graduate_student.diploms, Direction.direction_department" +
                                $" from Graduate_student" +
                                $" inner join Scientific_director on Graduate_student.director_id = Scientific_director.director_id" +
                                $" inner join Direction on Graduate_student.direction_id = Direction.direction_id" +
                                $" where Direction.direction_department like '%" + textBox1.Text + "%'" +
                                $" order by Scientific_director.director_name";
                            SqlCommand com = new SqlCommand(search, database.GetConnection());

                            database.OpenConnection();
                            SqlDataReader read = com.ExecuteReader();
                            while (read.Read())
                            {
                                ReadSingleRow_Query1(dgv, read);
                            }
                            read.Close();
                        }
                        break;
                    case "Поиск аспирантов по руководителям":
                        {
                            dgv.Rows.Clear();
                            if (!created)
                                Form1.CreateColums_Students(dgv);
                            created = true;
                            string search =
                                $"select Graduate_student.student_id, Scientific_director.director_name, Direction.direction_name, Graduate_student.student_name, Graduate_student.date_of_birth, Graduate_student.awards, Graduate_student.diploms, Direction.direction_department" +
                                $" from Graduate_student" +
                                $" inner join Scientific_director on Graduate_student.director_id = Scientific_director.director_id" +
                                $" inner join Direction on Graduate_student.direction_id = Direction.direction_id" +
                                $" where Scientific_director.director_name like '%" + textBox1.Text + "%'" +
                                $" order by Direction.direction_department";
                            SqlCommand com = new SqlCommand(search, database.GetConnection());

                            database.OpenConnection();
                            SqlDataReader read = com.ExecuteReader();
                            while (read.Read())
                            {
                                ReadSingleRow_Query1(dgv, read);
                            }
                            read.Close();
                        }
                        break;
                    case "Поиск публикаций аспиранта":
                        {
                            dgv.Rows.Clear();
                            if (!created)
                                Form1.CreateColums_Publications(dgv);
                            created = true;
                            string search =
                                $"select Publication.publication_id, Graduate_student.student_name, Publication.publication_resource, Publication.publication_date" +
                                $" from Publication" +
                                $" inner join Graduate_student on Publication.student_id = Graduate_student.student_id" +
                                $" where Graduate_student.student_name like '%" + textBox1.Text + "%'" +
                                $" group by Publication.publication_name";//*/
                            SqlCommand com = new SqlCommand(search, database.GetConnection());

                            database.OpenConnection();
                            SqlDataReader read = com.ExecuteReader();
                            while (read.Read())
                            {
                                ReadSingleRow_Query4(dgv, read);
                            }
                            read.Close();
                        }
                        break;
                    case "Поиск публикаций по научному руководителю":
                        {
                            dgv.Rows.Clear();
                            if (!created)
                                Form1.CreateColums_Publications(dgv);
                            created = true;
                            string search =
                                $"select Publication.publication_id, Graduate_student.student_name, Publication.publication_resource, Publication.publication_date, Scientific_director.director_name" +
                                $" from Publication" +
                                $" inner join Graduate_student on Publication.student_id = Graduate_student.student_id" +
                                $" inner join Scientific_director on Graduate_student.director_id = Scientific_director.director_id" +
                                $" where Scientific_director.student_name like '%" + textBox1.Text + "%'" +
                                $" group by Publication.publication_name";//*/
                            SqlCommand com = new SqlCommand(search, database.GetConnection());

                            database.OpenConnection();
                            SqlDataReader read = com.ExecuteReader();
                            while (read.Read())
                            {
                                ReadSingleRow_Query4(dgv, read);
                            }
                            read.Close();
                        }
                        break;
                    case "Учет работы научных советов":
                        {
                            dgv.Rows.Clear();
                            if (!created)
                                Form1.CreateColums_Councils(dgv);
                            created = true;
                            string search =
                                $"select Science_council.council_id, Science_council.composition, Science_council.number_of_successfull_defendings, Science_council.total_number_of_defendings, Defending.defending_date" +
                                $" from Science_council" +
                                $" inner join Defending on Science_council.council_id = Defending.council_id" +
                                $" where Defending.defending_date = '%" + textBox1.Text + "%'";//*/
                            SqlCommand com = new SqlCommand(search, database.GetConnection());

                            database.OpenConnection();
                            SqlDataReader read = com.ExecuteReader();
                            while (read.Read())
                            {
                                ReadSingleRow_Query6(dgv, read);
                            }
                            read.Close();
                        }
                        break;
                }
            }
            else
            {
                dgv.Rows.Clear();
                if (!created)
                    CreateColums_DefReport(dgv);
                created = true;
                string search =
                    $"select Defending.defending_id, Graduate_student.student_name, Defending.defending_date, Scientific_director.director_name, Science_council.composition, Direction.direction_department," +
                    $" Direction.direction_name, Direction.category, Defending.council_decision" +
                    $" from Defending" +
                    $" inner join Science_council on Defending.council_id = Science_council.council_id" +
                    $" inner join Graduate_student on Defending.student_id = Graduate_student.student_id" +
                    $" inner join Direction on Graduate_student.direction_id = Direction.direction_id" +
                    $" inner join Scientific_director on Graduate_student.director_id = Scientific_director.director_id " +
                    report.qString + textBox1.Text + report.qString2 +"'";//*/
                SqlCommand com = new SqlCommand(search, database.GetConnection());

                database.OpenConnection();
                SqlDataReader read = com.ExecuteReader();
                while (read.Read())
                {
                    ReadSingleRow_Report(dgv, read);
                }
                read.Close();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void QueryWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (report != null)
                report.Show();
        }
    }
}
