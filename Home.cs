using System.Data;
using System.Data.SqlClient;

namespace PayRoll
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
            CountEmployee();
            CountManagers();
            SumBonus();
            SumSalary();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\deeks\OneDrive\Documents\EmpPay.mdf;Integrated Security=True;Connect Timeout=30 ");
        private void CountEmployee()
        {
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("Select Count(*) from EmployeeTbl", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            EmpLbl.Text = dt.Rows[0][0].ToString();
            Con.Close();
        }
        private void CountManagers()
        {
            string Pos = "Manager";
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("Select Count(*) from EmployeeTbl where EmpPos='" + Pos + "'", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            ManagerLb.Text = dt.Rows[0][0].ToString();
            Con.Close();
        }
        private void SumSalary()
        {

            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("Select Sum(EmpBalance) from SalaryTbl", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            SalaryLbl.Text = "Rs " + dt.Rows[0][0].ToString();
            Con.Close();
        }
        private void SumBonus()
        {

            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("Select Sum(EmpBonus) from SalaryTbl", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            BonusLbl.Text = "Rs " + dt.Rows[0][0].ToString();
            Con.Close();
        }
        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            Employee Obj = new Employee();
            Obj.Show();
            this.Hide();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {
            Attendences Obj = new Attendences();
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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
        }

        private void panel2_Paint_1(object sender, PaintEventArgs e)
        {
        }

        private void label7_Click(object sender, EventArgs e)
        {
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
        }

        private void Home_Load(object sender, EventArgs e)
        {
        }

        private void panel1_Paint_2(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click_2(object sender, EventArgs e)
        {
        }

        private void Home_Load_1(object sender, EventArgs e)
        {
        }

        private void pictureBox4_Click_1(object sender, EventArgs e)
        {
        }

        private void pictureBox5_Click_1(object sender, EventArgs e)
        {
        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
        }

        private void panel2_Paint_2(object sender, PaintEventArgs e)
        {
        }
    }
}