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
using System.Windows.Input;

namespace PayRollPor
{
    public partial class Attendances : Form
    {
        public Attendances()
        {
            InitializeComponent();
            ShowAttendance(); 
            GetEmployees();
        }
        private void Clear()
        {
            EmpNameTb.Text = "";
            PresenceTb.Text = "";
            AbsentTb.Text = "";
            ExcusedTb.Text = "";
            Key = 0;

        }
        private void ShowAttendance()
        {
            Con.Open();
            string Query = "Select * from AttendanceTbl";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            AttendanceDGV.DataSource = ds.Tables[0];
            Con.Close();
        }

        private void GetEmployees()
        {
            Con.Open();
            SqlCommand cmd = new SqlCommand("Select * from EmployeeTbl", Con);
            SqlDataReader Rdr;
            Rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("EmpID", typeof(int));
            dt.Load(Rdr);
            EmpIdCb.ValueMember = "EmpID";
            EmpIdCb.DataSource = dt;

            Con.Close();
        }
        private void GetEmployeeName()
        {
            Con.Open();
            string Query = "Select * from EmployeeTbl where EmpID=" + EmpIdCb.SelectedValue.ToString() + "";
            SqlCommand cmd = new SqlCommand(Query, Con);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            foreach(DataRow dr in dt.Rows)
            {
                EmpNameTb.Text = dr["EmpName"].ToString();
            }
            Con.Close() ;
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\lobin\OneDrive\Documentos\PayRollProDB.mdf;Integrated Security=True;Connect Timeout=30");
        
        int Key = 0;

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (EmpNameTb.Text == "" || PresenceTb.Text == "" || ExcusedTb.Text == "" || AbsentTb.Text == "")
            {
                MessageBox.Show("Faltam Informações");
            }
            else
            {
                try
                {
                    string Period = AttDate.Value.Month + "-" + AttDate.Value.Year;


                    Con.Open();
                    SqlCommand cmd = new SqlCommand("insert into AttendanceTbl(EmpID,EmpName,DayPres, DayAbs, DayExcused, Period)values(@EI,@EN, @DP, @DA, @DE, @PER)", Con);
                    cmd.Parameters.AddWithValue("@EN", EmpNameTb.Text);
                    cmd.Parameters.AddWithValue("@EI", EmpIdCb.Text);
                    cmd.Parameters.AddWithValue("@DP", PresenceTb.Text);
                    cmd.Parameters.AddWithValue("@DA", AbsentTb.Text);
                    cmd.Parameters.AddWithValue("@DE", ExcusedTb.Text);
                    cmd.Parameters.AddWithValue("@PER", Period);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Registro de Presença Salvo");
                    Con.Close();
                    ShowAttendance();
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
            if (EmpNameTb.Text == "" || PresenceTb.Text == "" || ExcusedTb.Text == "" || AbsentTb.Text == "")
            {
                MessageBox.Show("Faltam Informações");
            }
            else
            {
                try
                {
                    string Period = AttDate.Value.Month + "-" + AttDate.Value.Year;


                    Con.Open();
                    SqlCommand cmd = new SqlCommand("Update AttendanceTbl Set EmpID=@EI, EmpName=@EN, DayPres=@DP, DayAbs=@DA, DayExcused=@DE, Period=@PER where AttNum=@AttKey", Con); 
                    cmd.Parameters.AddWithValue("@EI", EmpIdCb.Text);
                    cmd.Parameters.AddWithValue("@EN", EmpNameTb.Text);
                    cmd.Parameters.AddWithValue("@DP", PresenceTb.Text);
                    cmd.Parameters.AddWithValue("@DA", AbsentTb.Text);
                    cmd.Parameters.AddWithValue("@DE", ExcusedTb.Text);
                    cmd.Parameters.AddWithValue("@PER", Period);
                    cmd.Parameters.AddWithValue("@AttKey", Key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Registro de Presença Salvo");
                    Con.Close();
                    ShowAttendance();
                    Clear();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }
        private void AttendanceDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            EmpIdCb.Text = AttendanceDGV.SelectedRows[0].Cells[1].Value.ToString();
            EmpNameTb.Text = AttendanceDGV.SelectedRows[0].Cells[2].Value.ToString();
            PresenceTb.Text = AttendanceDGV.SelectedRows[0].Cells[3].Value.ToString();
            AbsentTb.Text = AttendanceDGV.SelectedRows[0].Cells[4].Value.ToString();
            ExcusedTb.Text = AttendanceDGV.SelectedRows[0].Cells[5].Value.ToString();
            AttDate.Text = AttendanceDGV.SelectedRows[0].Cells[6].Value.ToString();

            if (EmpNameTb.Text == "")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(AttendanceDGV.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Home Obj = new Home();
            Obj.Show();
            this.Hide();

        }

        private void label2_Click(object sender, EventArgs e)
        {
            Employees Obj = new Employees();
            Obj.Show();
            this.Hide();

        }

        private void label4_Click(object sender, EventArgs e)
        {
            Bonus Obj = new Bonus();
            Obj.Show();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Advances Obj = new Advances();
            Obj.Show();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Salary Obj = new Salary();
            Obj.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Você já está na categoria selecionada!");
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Home Obj = new Home();
            Obj.Show();
            this.Hide();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Employees Obj = new Employees();
            Obj.Show();
            this.Hide();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Salary Obj = new Salary();
            Obj.Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Você já está na categoria selecionada!");
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Funcão Indisponível nesta versão do Software");
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Bonus Obj = new Bonus();
            Obj.Show();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Advances Obj = new Advances();
            Obj.Show();
        }
    }
}
