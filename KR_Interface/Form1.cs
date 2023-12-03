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
using System.Windows.Forms.VisualStyles;
using System.Security.Cryptography;

namespace KR_Interface
{
    enum RowState
    {
        Existed,
        New,
        Modified,
        ModifiedNew,
        Deleted
    }
    public partial class Form1 : Form
    {
        public string userName;
        public LogIn logInWnd;
        DataBase database = new DataBase();
        int selectedRow;
        public Form1(string userName)
        {
            this.userName = userName;
            InitializeComponent();

        }
        public static void CreateColums_Directions(DataGridView dgv)
        {
            dgv.Columns.Add("ID", "id");
            dgv.Columns.Add("Name", "Название");
            dgv.Columns.Add("Category", "Категория");
            dgv.Columns.Add("Department", "Кафедра");
            dgv.Columns.Add("IsNew", String.Empty);

        }
        public static void CreateColums_Directors(DataGridView dgv)
        {
            dgv.Columns.Add("ID", "id");
            dgv.Columns.Add("Name", "ФИО");
            dgv.Columns.Add("Department", "Кафедра");
            dgv.Columns.Add("IsNew", String.Empty);
        }
        public static void CreateColums_Directors_Directions(DataGridView dgv)
        {
            dgv.Columns.Add("ID", "id");
            dgv.Columns.Add("Director_id", "id научного руководителя");
            dgv.Columns.Add("Direction_id", "id направления");
            dgv.Columns.Add("IsNew", String.Empty);
        }
        public static void CreateColums_Councils(DataGridView dgv)
        {
            dgv.Columns.Add("ID", "id");
            dgv.Columns.Add("Composition", "Состав");
            dgv.Columns.Add("Successfull_defs", "Успешные защиты");
            dgv.Columns.Add("Total_defs", "Все защиты");
            dgv.Columns.Add("IsNew", String.Empty);
        }
        public static void CreateColums_Councils_Directions(DataGridView dgv)
        {
            dgv.Columns.Add("ID", "id");
            dgv.Columns.Add("Council_id", "id совета");
            dgv.Columns.Add("Direction_id", "id направления");
            dgv.Columns.Add("IsNew", String.Empty);
        }
        public static void CreateColums_Students(DataGridView dgv)
        {
            dgv.Columns.Add("ID", "id");
            dgv.Columns.Add("Director_id", "id научного руководителя");
            dgv.Columns.Add("Direction_id", "id направления");
            dgv.Columns.Add("Name", "ФИО");
            dgv.Columns.Add("Date_of_birth", "Дата рождения");
            dgv.Columns.Add("Awards", "Награды");
            dgv.Columns.Add("Diploms", "Дипломы");
            dgv.Columns.Add("IsNew", String.Empty);
        }
        public static void CreateColums_Publications(DataGridView dgv)
        {
            dgv.Columns.Add("ID", "id");
            dgv.Columns.Add("Student_id", "id аспиранта");
            dgv.Columns.Add("Publication_name", "Название");
            dgv.Columns.Add("Publication_resource", "Ресурс публикации");
            dgv.Columns.Add("Publication_date", "Дата публикации");
            dgv.Columns.Add("IsNew", String.Empty);
        }
        public static void CreateColums_Defendings(DataGridView dgv)
        {
            dgv.Columns.Add("ID", "id");
            dgv.Columns.Add("Council_id", "id совета");
            dgv.Columns.Add("Student_id", "id аспиранта");
            dgv.Columns.Add("Date", "Дата");
            dgv.Columns.Add("Council_decision", "Решение совета");
            dgv.Columns.Add("IsNew", String.Empty);
        }

        public void ReadSingleRow_Directions(DataGridView dgv, IDataRecord record)
        {
            dgv.Rows.Add(record.GetInt32(0), record.GetString(1), record.GetString(2), record.GetString(3), RowState.ModifiedNew);
        }
        public void ReadSingleRow_Directors(DataGridView dgv, IDataRecord record)
        {
            dgv.Rows.Add(record.GetInt32(0), record.GetString(1), record.GetString(2), RowState.ModifiedNew);
        }
        public void ReadSingleRow_Directors_Directions(DataGridView dgv, IDataRecord record)
        {
            dgv.Rows.Add(record.GetInt32(0), record.GetInt32(1), record.GetInt32(2), RowState.ModifiedNew);
        }
        public void ReadSingleRow_Councils(DataGridView dgv, IDataRecord record)
        {
            dgv.Rows.Add(record.GetInt32(0), record.GetString(1), record.GetInt32(2), record.GetInt32(3), RowState.ModifiedNew);
        }
        public void ReadSingleRow_Councils_Directions(DataGridView dgv, IDataRecord record)
        {
            dgv.Rows.Add(record.GetInt32(0), record.GetInt32(1), record.GetInt32(2), RowState.ModifiedNew);
        }
        public void ReadSingleRow_Students(DataGridView dgv, IDataRecord record)
        {
            dgv.Rows.Add(record.GetInt32(0), record.GetInt32(1), record.GetInt32(2), record.GetString(3), record.GetString(4), record.GetInt32(5), record.GetString(6), RowState.ModifiedNew);
        }
        
        public void ReadSingleRow_Publications(DataGridView dgv, IDataRecord record)
        {
            dgv.Rows.Add(record.GetInt32(0), record.GetInt32(1), record.GetString(2), record.GetString(3), record.GetString(4), RowState.ModifiedNew);
        }
        private void ReadSingleRow_Defendings(DataGridView dgv, IDataRecord record)
        {
            dataGridView8.Rows.Add(record.GetInt32(0), record.GetInt32(1), record.GetInt32(2), record.GetString(3), record.GetString(4), RowState.ModifiedNew);
        }

        private void RefreshDataGrid_Directions()
        {
            dataGridView1.Rows.Clear();
            string queryString = $"select * from Direction";
            SqlCommand command = new SqlCommand(queryString, database.GetConnection());
            database.OpenConnection();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                ReadSingleRow_Directions(dataGridView1,reader);
            }
            reader.Close();
        }
        private void RefreshDataGrid_Directors()
        {
            dataGridView2.Rows.Clear();
            string queryString = $"select * from Scientific_Director";
            SqlCommand command = new SqlCommand(queryString, database.GetConnection());
            database.OpenConnection();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                ReadSingleRow_Directors(dataGridView2, reader);
            }
            reader.Close();
        }
        private void RefreshDataGrid_Directors_Directions()
        {
            dataGridView3.Rows.Clear();
            string queryString = $"select * from Scientific_director_Direction";
            SqlCommand command = new SqlCommand(queryString, database.GetConnection());
            database.OpenConnection();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                ReadSingleRow_Directors_Directions(dataGridView3, reader);
            }
            reader.Close();
        }
        private void RefreshDataGrid_Councils()
        {
            dataGridView4.Rows.Clear();
            string queryString = $"select * from Science_council";
            SqlCommand command = new SqlCommand(queryString, database.GetConnection());
            database.OpenConnection();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                ReadSingleRow_Councils(dataGridView4, reader);
            }
            reader.Close();
        }
        private void RefreshDataGrid_Councils_Directions()
        {
            dataGridView5.Rows.Clear();
            string queryString = $"select * from Science_council_Direction";
            SqlCommand command = new SqlCommand(queryString, database.GetConnection());
            database.OpenConnection();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                ReadSingleRow_Councils_Directions(dataGridView5,reader);
            }
            reader.Close();
        }
        private void RefreshDataGrid_Students()
        {
            dataGridView6.Rows.Clear();
            string queryString = $"select * from Graduate_student";
            SqlCommand command = new SqlCommand(queryString, database.GetConnection());
            database.OpenConnection();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                ReadSingleRow_Students(dataGridView6, reader);
            }
            reader.Close();
        }
        private void RefreshDataGrid_Publications()
        {
            dataGridView7.Rows.Clear();
            string queryString = $"select * from Publication";
            SqlCommand command = new SqlCommand(queryString, database.GetConnection());
            database.OpenConnection();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                ReadSingleRow_Publications(dataGridView7,reader);
            }
            reader.Close();
        }
        private void RefreshDataGrid_Defendings()
        {
            dataGridView8.Rows.Clear();
            string queryString = $"select * from Defending";
            SqlCommand command = new SqlCommand(queryString, database.GetConnection());
            database.OpenConnection();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                ReadSingleRow_Defendings(dataGridView8, reader);
            }
            reader.Close();

        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void помощьToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            logInWnd.Show();
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 aboutWnd = new AboutBox1();
            aboutWnd.ShowDialog();
        }

        private void рекомендацииToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Заполнение базы данных рекомендуется в том же порядке, в котором они идут в меню выбора таблицы");
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            CreateColums_Directions(dataGridView1);
            CreateColums_Directors(dataGridView2);
            CreateColums_Directors_Directions(dataGridView3);
            CreateColums_Councils(dataGridView4);
            CreateColums_Councils_Directions(dataGridView5);
            CreateColums_Students(dataGridView6);
            CreateColums_Publications(dataGridView7);
            CreateColums_Defendings(dataGridView8);

            RefreshDataGrid_Directions();
            RefreshDataGrid_Directors();
            RefreshDataGrid_Directors_Directions();
            RefreshDataGrid_Councils();
            RefreshDataGrid_Councils_Directions();
            RefreshDataGrid_Students();
            RefreshDataGrid_Publications();
            RefreshDataGrid_Defendings();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox13_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[selectedRow];

                ID_TextBox1.Text = row.Cells[0].Value.ToString();
                Name_TextBox1.Text = row.Cells[1].Value.ToString();
                Category_TextBox1.Text = row.Cells[2].Value.ToString();
                Department_TextBox1.Text = row.Cells[3].Value.ToString();

            }
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView2.Rows[selectedRow];

                ID_TextBox2.Text = row.Cells[0].Value.ToString();
                Name_TextBox2.Text = row.Cells[1].Value.ToString();
                Department_TextBox2.Text = row.Cells[2].Value.ToString();

            }
        }
        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView3.Rows[selectedRow];

                ID_TextBox3.Text = row.Cells[0].Value.ToString();

                Director_id_TextBox3.Text = row.Cells[1].Value.ToString();
                Direction_id_TextBox3.Text = row.Cells[2].Value.ToString();

            }
        }
        private void dataGridView4_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView4.Rows[selectedRow];

                ID_TextBox4.Text = row.Cells[0].Value.ToString();
                Composition_TextBox4.Text = row.Cells[1].Value.ToString();
                Successfull_defs_TextBox4.Text = row.Cells[2].Value.ToString();
                Total_defs_TextBox4.Text = row.Cells[3].Value.ToString();
            }
        }
        private void dataGridView5_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView5.Rows[selectedRow];

                ID_TextBox5.Text = row.Cells[0].Value.ToString();
                Council_id_TextBox5.Text = row.Cells[2].Value.ToString();
                Direction_id_TextBox5.Text = row.Cells[1].Value.ToString();
            }
        }
        private void dataGridView6_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView6.Rows[selectedRow];

                ID_TextBox6.Text = row.Cells[0].Value.ToString();
                Director_id_TextBox6.Text = row.Cells[1].Value.ToString();
                Direction_id_TextBox6.Text = row.Cells[2].Value.ToString();
                Name_TextBox6.Text = row.Cells[3].Value.ToString();
                Date_of_birth_TextBox6.Text = row.Cells[4].Value.ToString();
                Awards_TextBox6.Text = row.Cells[5].Value.ToString();
                Diploms_TextBox6.Text = row.Cells[6].Value.ToString();
            }
        }
        private void dataGridView7_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView7.Rows[selectedRow];

                ID_TextBox7.Text = row.Cells[0].Value.ToString();
                Student_id_TextBox7.Text = row.Cells[1].Value.ToString();
                Publication_name_TextBox7.Text = row.Cells[2].Value.ToString();
                Publication_resource_TextBox7.Text = row.Cells[3].Value.ToString();
                Publication_date_TextBox7.Text = row.Cells[4].Value.ToString();

            }
        }
        private void dataGridView8_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView8.Rows[selectedRow];

                ID_TextBox8.Text = row.Cells[0].Value.ToString();
                Council_id_TextBox8.Text = row.Cells[1].Value.ToString();
                Student_id_TextBox8.Text = row.Cells[2].Value.ToString();
                Date_TextBox8.Text = row.Cells[3].Value.ToString();
                Council_decision_TextBox8.Text = row.Cells[4].Value.ToString();

            }
        }

        private void обновитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }



        private void NewRecordButton1_Click(object sender, EventArgs e)
        {
            NewRecord NR = new NewRecord();
            NR.RecordTypeLabel.Text = "Новая запись: Направление";
            CreateColums_Directions(NR.dataGridView1);
            NR.dataGridView1.RowCount = 1;
            int n = NR.dataGridView1.Columns.Count;
            NR.dataGridView1.Columns[0].Visible = false;
            NR.dataGridView1.Columns[n - 1].Visible = false;
            NR.ShowDialog();

        }

        private void NewRecordButton2_Click(object sender, EventArgs e)
        {
            NewRecord NR = new NewRecord();
            NR.RecordTypeLabel.Text = "Новая запись: Научный руководитель";
            CreateColums_Directors(NR.dataGridView1);
            NR.dataGridView1.RowCount = 1;
            int n = NR.dataGridView1.Columns.Count;
            NR.dataGridView1.Columns[0].Visible = false;
            NR.dataGridView1.Columns[n - 1].Visible = false;
            NR.ShowDialog();
        }
        private void NewRecordButton3_Click(object sender, EventArgs e)
        {
            NewRecord NR = new NewRecord();
            NR.RecordTypeLabel.Text = "Новая запись: Научный руководитель и направление ";
            CreateColums_Directors_Directions(NR.dataGridView1);
            NR.dataGridView1.RowCount = 1;
            int n = NR.dataGridView1.Columns.Count;
            NR.dataGridView1.Columns[0].Visible = false;
            NR.dataGridView1.Columns[n - 1].Visible = false;
            NR.ShowDialog();
        }

        private void NewRecordButton4_Click(object sender, EventArgs e)
        {
            NewRecord NR = new NewRecord();
            NR.RecordTypeLabel.Text = "Новая запись: Научный совет";
            CreateColums_Councils(NR.dataGridView1);
            NR.dataGridView1.RowCount = 1;
            int n = NR.dataGridView1.Columns.Count;
            NR.dataGridView1.Columns[0].Visible = false;
            NR.dataGridView1.Columns[n - 1].Visible = false; ;
            NR.ShowDialog();
        }

        private void NewRecordButton5_Click(object sender, EventArgs e)
        {
            NewRecord NR = new NewRecord();
            NR.RecordTypeLabel.Text = "Новая запись: Научный совет и направление";
            CreateColums_Councils_Directions(NR.dataGridView1);
            NR.dataGridView1.RowCount = 1;
            int n = NR.dataGridView1.Columns.Count;
            NR.dataGridView1.Columns[0].Visible = false;
            NR.dataGridView1.Columns[n - 1].Visible = false;
            NR.ShowDialog();
        }

        private void NewRecordButton6_Click(object sender, EventArgs e)
        {
            NewRecord NR = new NewRecord();
            NR.RecordTypeLabel.Text = "Новая запись: Аспирант";
            CreateColums_Students(NR.dataGridView1);
            NR.dataGridView1.RowCount = 1;
            int n = NR.dataGridView1.Columns.Count;
            NR.dataGridView1.Columns[0].Visible = false;
            NR.dataGridView1.Columns[n - 1].Visible = false;
            NR.ShowDialog();
        }

        private void NewRecordButton7_Click(object sender, EventArgs e)
        {
            NewRecord NR = new NewRecord();
            NR.RecordTypeLabel.Text = "Новая запись: Публикация";
            CreateColums_Publications(NR.dataGridView1);
            NR.dataGridView1.RowCount = 1;
            int n = NR.dataGridView1.Columns.Count;
            NR.dataGridView1.Columns[0].Visible = false;
            NR.dataGridView1.Columns[n - 1].Visible = false;
            NR.ShowDialog();
        }

        private void NewRecordButton8_Click(object sender, EventArgs e)
        {
            NewRecord NR = new NewRecord();
            NR.RecordTypeLabel.Text = "Новая запись: Защита";
            CreateColums_Defendings(NR.dataGridView1);
            NR.dataGridView1.RowCount = 1;
            int n = NR.dataGridView1.Columns.Count;
            NR.dataGridView1.Columns[0].Visible = false;
            NR.dataGridView1.Columns[n - 1].Visible = false;
            NR.ShowDialog();
        }

        private void обновитьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            RefreshDataGrid_Directions();
            RefreshDataGrid_Directors();
            RefreshDataGrid_Directors_Directions();
            RefreshDataGrid_Councils();
            RefreshDataGrid_Councils_Directions();
            RefreshDataGrid_Students();
            RefreshDataGrid_Publications();
            RefreshDataGrid_Defendings();
        }

        private void DeleteRow(DataGridView dgv)
        {
            int index = dgv.CurrentCell.RowIndex;
            dgv.Rows[index].Visible = false;
            if (dgv.Rows[index].Cells[0].Value.ToString() == string.Empty)
            {
                dgv.Rows[index].Cells[dgv.ColumnCount - 1].Value = RowState.Deleted;
                return;
            }
            dgv.Rows[index].Cells[5].Value = RowState.Deleted;

        }
        private void Update(DataGridView dgv, string tableName)
        {
            database.OpenConnection();
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                var rowState = (RowState)dgv.Rows[i].Cells[dgv.ColumnCount - 1].Value;
                if (rowState == RowState.Existed) { }
                else if (rowState == RowState.Deleted)
                {
                    var id = Convert.ToInt32(dgv.Rows[i].Cells[0].Value);
                    var deleteQuery = $"delete from {tableName} where id = {id}";
                    var command = new SqlCommand(deleteQuery, database.GetConnection());
                    command.ExecuteNonQuery();
                }
                else if (rowState == RowState.Modified)
                {

                }
            }
            database.CloseConnection();
        }
        

        private void Edit1(DataGridView dgv)
        {
            int index = dgv.CurrentCell.RowIndex;

            int id;
            var name = Name_TextBox1.Text;
            var category = Category_TextBox1.Text;
            var department = Department_TextBox1;
            if (dgv.Rows[index].Cells[0].Value.ToString()!= string.Empty)
            {
                if (int.TryParse(ID_TextBox1.Text, out id)){
                
                    dgv.Rows[index].SetValues(id, name, category, department);
                    dgv.Rows[index].Cells[dgv.ColumnCount - 1].Value = RowState.Modified;
                }
                else
                    MessageBox.Show("Проверьте числовые значения");//*/
            }
        }
        private void Edit2(DataGridView dgv)
        {
            int index = dgv.CurrentCell.RowIndex;

            int id ;
            var name = Name_TextBox2.Text;
            var department = Department_TextBox2.Text;

            if (dgv.Rows[index].Cells[0].Value.ToString() != string.Empty)
            {
                if (int.TryParse( ID_TextBox2.Text, out id)){

                dgv.Rows[index].SetValues(id,name, department);
                dgv.Rows[index].Cells[dgv.ColumnCount - 1].Value = RowState.Modified;
                }
                else
                    MessageBox.Show("Проверьте числовые значения");//*/
            }
        }
        private void Edit3(DataGridView dgv)
        {
            int index = dgv.CurrentCell.RowIndex;

            int id;
            int director_id;
            int direction_id;

            if (dgv.Rows[index].Cells[0].Value.ToString() != string.Empty)
            {
                if (int.TryParse(ID_TextBox3.Text, out id) && int.TryParse(Director_id_TextBox3.Text, out director_id) && int.TryParse(Direction_id_TextBox3.Text, out direction_id))
                {

                    dgv.Rows[index].SetValues(id, director_id, direction_id);
                    dgv.Rows[index].Cells[dgv.ColumnCount - 1].Value = RowState.Modified;
                }
                else
                    MessageBox.Show("Проверьте числовые значения");//*/
            }
        }
        private void Edit4(DataGridView dgv)
        {
            int index = dgv.CurrentCell.RowIndex;

            int id;
            var composition = Composition_TextBox4.Text;
            int number_of_successfull_defendings;
            int total_number_of_successfull_defendings;

            if (dgv.Rows[index].Cells[0].Value.ToString() != string.Empty)
            {
                if (int.TryParse(ID_TextBox4.Text, out id) && int.TryParse(Successfull_defs_TextBox4.Text, out number_of_successfull_defendings) 
                    && int.TryParse(Total_defs_TextBox4.Text, out total_number_of_successfull_defendings))
                {
                    dgv.Rows[index].SetValues(id, number_of_successfull_defendings, total_number_of_successfull_defendings);
                    dgv.Rows[index].Cells[dgv.ColumnCount - 1].Value = RowState.Modified;
                }
                else
                    MessageBox.Show("Проверьте числовые значения");//*/
            }
        }
        private void Edit5(DataGridView dgv)
        {
            int index = dgv.CurrentCell.RowIndex;

            int id;
            int council_id;
            int direction_id;

            if (dgv.Rows[index].Cells[0].Value.ToString() != string.Empty)
            {
                if (int.TryParse(ID_TextBox5.Text, out id) && int.TryParse(Council_id_TextBox5.Text, out council_id)
                    && int.TryParse(Direction_id_TextBox5.Text, out direction_id))
                {
                    dgv.Rows[index].SetValues(id, council_id, direction_id);
                    dgv.Rows[index].Cells[dgv.ColumnCount - 1].Value = RowState.Modified;
                }
                else
                    MessageBox.Show("Проверьте числовые значения");//*/
            }
        }
        private void Edit6(DataGridView dgv)
        {
            int index = dgv.CurrentCell.RowIndex;

            int id;
            int director_id;
            int direction_id;
            var name = Name_TextBox6.Text;
            var date_of_birth = Date_of_birth_TextBox6.Text;
            int awards;
            var diploms = Diploms_TextBox6.Text;

            if (dgv.Rows[index].Cells[0].Value.ToString() != string.Empty)
            {
                if (int.TryParse(ID_TextBox6.Text, out id) && int.TryParse(Director_id_TextBox6.Text, out director_id) 
                    && int.TryParse(Direction_id_TextBox6.Text, out direction_id) && int.TryParse(Awards_TextBox6.Text, out awards))
                {
                    dgv.Rows[index].SetValues(id, director_id, direction_id, name, date_of_birth, awards, diploms);
                    dgv.Rows[index].Cells[dgv.ColumnCount - 1].Value = RowState.Modified;
                }
                else
                    MessageBox.Show("Проверьте числовые значения");//*/
            }
        }
        private void Edit7(DataGridView dgv)
        {
            int index = dgv.CurrentCell.RowIndex;

            int id;
            int student_id;
            var name = Publication_name_TextBox7.Text;
            var resource = Publication_resource_TextBox7.Text;
            var date = Publication_date_TextBox7.Text;

            if (dgv.Rows[index].Cells[0].Value.ToString() != string.Empty)
            {
                if (int.TryParse(ID_TextBox7.Text, out id) && int.TryParse(Student_id_TextBox7.Text, out student_id))
                {
                    dgv.Rows[index].SetValues(id, student_id, name, resource, date);
                    dgv.Rows[index].Cells[dgv.ColumnCount - 1].Value = RowState.Modified;
                }
                else
                    MessageBox.Show("Проверьте числовые значения");//*/
            }
        }
        private void Edit8(DataGridView dgv)
        {
            int index = dgv.CurrentCell.RowIndex;

            int id;
            int council_id;
            int student_id;
            var date = Date_TextBox8.Text;
            var decision = Council_decision_TextBox8;

            if (dgv.Rows[index].Cells[0].Value.ToString() != string.Empty)
            {
                if (int.TryParse(ID_TextBox8.Text, out id) && int.TryParse(Council_id_TextBox8.Text, out council_id) && int.TryParse(Student_id_TextBox8.Text, out student_id))
                {
                    dgv.Rows[index].SetValues(id, student_id, council_id, student_id, date, decision);
                    dgv.Rows[index].Cells[dgv.ColumnCount - 1].Value = RowState.Modified;
                }
                else
                    MessageBox.Show("Проверьте числовые значения");//*/
            }
        }

        private void DeleteButton1_Click(object sender, EventArgs e)
        {
            DeleteRow(dataGridView1);
        }
        private void SaveButton1_Click(object sender, EventArgs e)
        {
            Update(dataGridView1, "Direction");
        }

        private void DeleteButton2_Click(object sender, EventArgs e)
        {
            DeleteRow(dataGridView2);
        }

        private void SaveButton2_Click(object sender, EventArgs e)
        {
            Update(dataGridView2, "Scientific_director");
        }

        private void DeleteButton3_Click(object sender, EventArgs e)
        {
            DeleteRow(dataGridView3);
        }

        private void SaveButton3_Click(object sender, EventArgs e)
        {
            Update(dataGridView3, "Scientific_director_Direction");
        }

        private void DeleteButton4_Click(object sender, EventArgs e)
        {
            DeleteRow(dataGridView4);
        }

        private void SaveButton4_Click(object sender, EventArgs e)
        {
            Update(dataGridView4, "Science_council");
        }

        private void DeleteButton5_Click(object sender, EventArgs e)
        {

            DeleteRow(dataGridView5);
        }

        private void SaveButton5_Click(object sender, EventArgs e)
        {
            Update(dataGridView5, "Science_council_Direction");
        }

        private void DeleteButton6_Click(object sender, EventArgs e)
        {
            DeleteRow(dataGridView6);
        }

        private void SaveButton6_Click(object sender, EventArgs e)
        {
            Update(dataGridView6, "Graduate_student");
        }

        private void DeleteButton7_Click(object sender, EventArgs e)
        {
            DeleteRow(dataGridView7);
        }

        private void SaveButton7_Click(object sender, EventArgs e)
        {
            Update(dataGridView7, "Publication");
        }

        private void DeleteButton8_Click(object sender, EventArgs e)
        {
            DeleteRow(dataGridView8);
        }

        private void SaveButton8_Click(object sender, EventArgs e)
        {
            Update(dataGridView7, "Defending");
        }

        private void EditButton1_Click(object sender, EventArgs e)
        {
            Edit1(dataGridView1);
        }
        private void EditButton2_Click(object sender, EventArgs e)
        {
            Edit2(dataGridView2);
        }
        private void EditButton3_Click(object sender, EventArgs e)
        {
            Edit3(dataGridView3);
        }
        private void EditButton4_Click(object sender, EventArgs e)
        {
            Edit4(dataGridView4);
        }
        private void EditButton5_Click(object sender, EventArgs e)
        {
            Edit5(dataGridView5);
        }
        private void EditButton6_Click(object sender, EventArgs e)
        {
            Edit6(dataGridView6);
        }
        private void EditButton7_Click(object sender, EventArgs e)
        {
            Edit7(dataGridView7);
        }
        private void EditButton8_Click(object sender, EventArgs e)
        {
            Edit8(dataGridView8);
        }

        private void поискАспирантаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QueryWindow qw = new QueryWindow();
            qw.QueryLabel.Text = "Поиск аспирантов по категории";
            qw.form1 = this;
            qw.Show();
        }

        private void поискАспирантовПоКафедрамToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QueryWindow qw = new QueryWindow();
            qw.QueryLabel.Text = "Поиск аспирантов по кафедрам";
            qw.form1 = this;
            qw.Show();
        }

        private void поискАспирантовПоРуководителямToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QueryWindow qw = new QueryWindow();
            qw.QueryLabel.Text = "Поиск аспирантов по руководителям";
            qw.form1 = this;
            qw.Show();
        }        

        private void поискПубликацийАспирантаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QueryWindow qw = new QueryWindow();
            qw.QueryLabel.Text = "Поиск публикаций аспиранта";
            qw.form1 = this;
            qw.Show();
        }

        private void поискПубликацийПоНаучномуРуководителюToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QueryWindow qw = new QueryWindow();
            qw.QueryLabel.Text = "Поиск публикаций по научному руководителю";
            qw.form1 = this;
            qw.Show();
        }

        private void учетРаботыНаучныхСоветовToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QueryWindow qw = new QueryWindow();
            qw.QueryLabel.Text = "Учет работы научных советов";
            qw.form1 = this;
            qw.Show();
        }

        private void отчетПоЗащитеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReportDialog rd = new ReportDialog();
            rd.Show();
        }
    }
}
