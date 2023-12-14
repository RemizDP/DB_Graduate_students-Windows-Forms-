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
            dgv.Rows.Add(record.GetInt32(0), record.GetString(1), record.GetString(2), record.GetString(3), record.GetDateTime(4), record.GetInt32(5), record.GetString(6), record.GetString(7));
        }
        public void ReadSingleRow_Query4(DataGridView dgv, IDataRecord record)
        {
            dgv.Rows.Add(record.GetInt32(0), record.GetString(1), record.GetString(2), record.GetString(3), record.GetDateTime(4), record.GetString(5));
        }
        public void ReadSingleRow_Query6(DataGridView dgv, IDataRecord record)
        {
            dgv.Rows.Add(record.GetInt32(0), record.GetString(1), record.GetInt32(2), record.GetInt32(3), record.GetDateTime(4));
        }

        public static void CreateColums_Query4(DataGridView dgv)
        {
            dgv.Columns.Add("ID", "id");
            dgv.Columns.Add("Publication_name", "Название");
            dgv.Columns.Add("Student", "ФИО аспиранта");
            dgv.Columns.Add("Publication_resource", "Ресурс публикации");
            dgv.Columns.Add("Publication_date", "Дата публикации");
            dgv.Columns.Add("Director", "ФИО руководителя");
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
            dgv.Rows.Add(record.GetInt32(0), record.GetString(1), record.GetDateTime(2), record.GetString(3), record.GetString(4), record.GetString(5), record.GetString(6), record.GetString(7), record.GetString(8));
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
                                $" where Direction.category like '" + textBox1.Text + "%'";//*/
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
                                $" where Direction.direction_department like '" + textBox1.Text + "%'" +
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
                                $" where Scientific_director.director_name like '" + textBox1.Text + "%'" +
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
                                CreateColums_Query4(dgv);
                            created = true;
                            string search =
                                $"select Publication.publication_id, Publication.publication_name, Graduate_student.student_name, Publication.publication_resource, Publication.publication_date, Scientific_director.director_name" +
                                $" from Publication" +
                                $" inner join Graduate_student on Publication.student_id = Graduate_student.student_id" +
                                $" inner join Scientific_director on Graduate_student.director_id = Scientific_director.director_id" +
                                $" where Graduate_student.student_name like '" + textBox1.Text + "%'" +
                                $" group by Publication.publication_name, Publication.publication_id, Graduate_student.student_name, Publication.publication_resource, " +
                                $"Publication.publication_date, Scientific_director.director_name";//*/
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
                                CreateColums_Query4(dgv);
                            created = true;
                            string search =
                                $"select Publication.publication_id, Publication.publication_name, Graduate_student.student_name, Publication.publication_resource, Publication.publication_date, Scientific_director.director_name" +
                                $" from Publication" +
                                $" inner join Graduate_student on Publication.student_id = Graduate_student.student_id" +
                                $" inner join Scientific_director on Graduate_student.director_id = Scientific_director.director_id" +
                                $" where Scientific_director.director_name like '" + textBox1.Text + "%'" +
                                $" group by Publication.publication_name, Publication.publication_id, Graduate_student.student_name, Publication.publication_resource, " +
                                $"Publication.publication_date, Scientific_director.director_name";//*/
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
                                $"EXECUTE council_defendings_by_date '" + textBox1.Text+"'";//*/
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
                string buf="";
                if (report.qString1 != "")
                {
                    report.qString1 += textBox1.Text + "', 104) ";
                    buf = $"@d";
                }
                else
                    buf = textBox1.Text + report.qString3;
                string search =report.qString1 +
                    $"select Defending.defending_id, Graduate_student.student_name, Defending.defending_date, Scientific_director.director_name, Science_council.composition, Direction.direction_department," +
                    $" Direction.direction_name, Direction.category, Defending.council_decision" +
                    $" from Defending" +
                    $" inner join Science_council on Defending.council_id = Science_council.council_id" +
                    $" inner join Graduate_student on Defending.student_id = Graduate_student.student_id" +
                    $" inner join Direction on Graduate_student.direction_id = Direction.direction_id" +
                    $" inner join Scientific_director on Graduate_student.director_id = Scientific_director.director_id " +
                    report.qString2 + buf;//*/
                SqlCommand com = new SqlCommand(search, database.GetConnection());

                database.OpenConnection();
                SqlDataReader read = com.ExecuteReader();
                while (read.Read())
                {
                    ReadSingleRow_Report(dgv, read);
                }
                read.Close();
                report.qString1 = "";
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
