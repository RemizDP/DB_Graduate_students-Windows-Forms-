using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KR_Interface
{
    public partial class ReportDialog : Form
    {
        public string qString1 ="";
        public string qString2="";
        public string qString3 = "%'";
        public ReportDialog()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            qString2 = "where Direction.category like '";
            QueryWindow qw = new QueryWindow();
            qw.QueryLabel.Text = "По категории";
            qw.report = this;
            qw.Show();
            Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            qString2 = $"where Direction.direction_name like '";
            QueryWindow qw = new QueryWindow();
            qw.QueryLabel.Text = "По направлению";
            qw.report = this;
            qw.Show();
            Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            qString2 = $"where Direction.direction_department like '";
            QueryWindow qw = new QueryWindow();
            qw.QueryLabel.Text = "По кафедре";
            qw.report = this;
            qw.Show();
            Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            qString2 = $"where Scientific_director.director_name like '";
            QueryWindow qw = new QueryWindow();
            qw.QueryLabel.Text = "По научному руководителю";
            qw.report = this;
            qw.Show();
            Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            qString1 = $"declare @d DATE = Convert(DATE, '";
            qString2 = $"where Defending.defending_date =";
            QueryWindow qw = new QueryWindow();
            qw.QueryLabel.Text = "По дате защиты";
            qw.report = this;
            qw.Show();
            Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            qString2 = $"where Defending.council_decision like '";
            QueryWindow qw = new QueryWindow();
            qw.QueryLabel.Text = "По решению совета";
            qw.report = this;
            qw.Show();
            Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            qString2 = $"where Science_council.composition like '";
            QueryWindow qw = new QueryWindow();
            qw.QueryLabel.Text = "По составу совета";
            qw.report = this;
            qw.Show();
            Hide();
        }
    }
}
