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
using static System.Windows.Forms.AxHost;

namespace PayRoll
{
    public partial class Attendences : Form
    {
        public Attendences()
        {
            InitializeComponent();
            ShowAttendence();
            GetEmployee();

        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\deeks\OneDrive\Documents\EmpPay.mdf;Integrated Security=True;Connect Timeout=30");

        private void Clear()
        {
            EmpNameTb.Text = "";
            PresenceTb.Text = "";
            AbsTb.Text = "";
            ExcusedTb.Text = "";
            Key = 0;



        }
        private void ShowAttendence()
        {
            Con.Open();
            string Query = "Select * from AttendenceTbl";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder Builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            AttendenceDGV.DataSource = ds.Tables[0];
            Con.Close();

        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            Home Obj = new Home();
            Obj.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Employee Obj = new Employee();
            Obj.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Bonus Obj = new Bonus();
            Obj.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Salary Obj = new Salary();
            Obj.Show();
            this.Hide();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void GetEmployee()
        {
            Con.Open();
            SqlCommand cmd = new SqlCommand("Select *  from EmployeeTbl", Con);
            SqlDataReader Rdr;
            Rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("EmpId", typeof(int));
            dt.Load(Rdr);
            EmpIdCb.ValueMember = "EmpID";
            EmpIdCb.DataSource = dt;
            Con.Close();
        }
        private void GetEmployeeName()
        {
            Con.Open();
            string Query = "Select * from EmployeeTbl where EmpId=" + EmpIdCb.SelectedValue.ToString();
            SqlCommand cmd = new SqlCommand(Query, Con);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                EmpNameTb.Text = dr["EmpName"].ToString();
            }
            Con.Close();

        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (EmpNameTb.Text == " " || PresenceTb.Text == " " || ExcusedTb.Text == "" || AbsTb.Text == " ")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    string Period = this.AttDate.Value.Month + " - " + this.AttDate.Value.Year;
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("insert into AttendenceTbl(EmpId,EmpName,DayPres,DayAbs,DayExcused,Period)values(@EI,@EN,@DP,@DA,@DE,@Per)", Con);
                    cmd.Parameters.AddWithValue("@EI", EmpIdCb.Text);
                    cmd.Parameters.AddWithValue("@EN", EmpNameTb.Text);
                    cmd.Parameters.AddWithValue("@DP", PresenceTb.Text);
                    cmd.Parameters.AddWithValue("@DA", AbsTb.Text);
                    cmd.Parameters.AddWithValue("@DE", ExcusedTb.Text);
                    cmd.Parameters.AddWithValue("@Per", Period);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Attendance Details Saved");
                    Con.Close();
                    ShowAttendence();
                    Clear();

                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void EmpIdCb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            GetEmployeeName();
        }

        private void EditBtn_Click(object sender, EventArgs e)
        {
            if (EmpNameTb.Text == "" || PresenceTb.Text == "" || ExcusedTb.Text == "" || AbsTb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    string Period = this.AttDate.Value.Month + " - " + this.AttDate.Value.Year;
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("Update AttendenceTbl Set DayPres=@DP,DayAbs=@DA,DayExcused=@DE,Period=@Per where AttaNum=@EmpKey", Con);

                    cmd.Parameters.AddWithValue("@DP", PresenceTb.Text);
                    cmd.Parameters.AddWithValue("@DA", AbsTb.Text);
                    cmd.Parameters.AddWithValue("@DE", ExcusedTb.Text);
                    cmd.Parameters.AddWithValue("@Per", Period);
                    cmd.Parameters.AddWithValue("@EmpKey", Key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Attendance Details Updated");
                    Con.Close();
                    ShowAttendence();
                    Clear();

                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (Key == 0)
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("Delete from AttendenceTbl Where AttaNum =@EmpKey", Con);
                    cmd.Parameters.AddWithValue("@EmpKey", Key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Employee Details Deleted");
                    Con.Close();
                    ShowAttendence();

                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }
        int Key = 0;
        private void AttendenceDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            EmpIdCb.Text = AttendenceDGV.SelectedRows[0].Cells[1].Value.ToString();
            EmpNameTb.Text = AttendenceDGV.SelectedRows[0].Cells[2].Value.ToString();
            PresenceTb.Text = AttendenceDGV.SelectedRows[0].Cells[3].Value.ToString();
            AbsTb.Text = AttendenceDGV.SelectedRows[0].Cells[4].Value.ToString();
            ExcusedTb.Text = AttendenceDGV.SelectedRows[0].Cells[5].Value.ToString();
            AttDate.Text = AttendenceDGV.SelectedRows[0].Cells[6].Value.ToString();

            if (EmpIdCb.Text == " ")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(AttendenceDGV.SelectedRows[0].Cells[0].Value.ToString());
            }

        }

        private void AttDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
