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
        public string qString;
        public string qString2 = "%";
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
            qString = "where Direction.category like '%";
            QueryWindow qw = new QueryWindow();
            qw.QueryLabel.Text = "По категории";
            qw.report = this;
            qw.Show();
            Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            qString = $"where Direction.direction_name like '%";
            QueryWindow qw = new QueryWindow();
            qw.QueryLabel.Text = "По направлению";
            qw.report = this;
            qw.Show();
            Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            qString = $"where Direction.direction_department like '%";
            QueryWindow qw = new QueryWindow();
            qw.QueryLabel.Text = "По кафедре";
            qw.report = this;
            qw.Show();
            Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            qString = $"where Scietific_director.director_name like '%";
            QueryWindow qw = new QueryWindow();
            qw.QueryLabel.Text = "По научному руководителю";
            qw.report = this;
            qw.Show();
            Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            qString = $"where Defending.defending_date ='";
            QueryWindow qw = new QueryWindow();
            qw.QueryLabel.Text = "По дате защиты";
            qw.report = this;
            qw.Show();
            Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            qString = $"where Defending.council_decision = '";
            QueryWindow qw = new QueryWindow();
            qw.QueryLabel.Text = "По решению совета";
            qw.report = this;
            qw.Show();
            Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            qString = $"where Science_council.composition like '%";
            QueryWindow qw = new QueryWindow();
            qw.QueryLabel.Text = "По составу совета";
            qw.report = this;
            qw.Show();
            Hide();
        }
    }
}
