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

namespace PayRollPor
{
    public partial class Salary : Form
    {
        public Salary()
        {
            InitializeComponent();
            GetEmployees();
            GetAttendance();
            GetBonus();
            ShowSalary();
        }
        private void Clear()
        {
            EmpNameTb.Text = "";
            PresenceTb.Text = "";
            AbsentTb.Text = "";
            ExcusedTb.Text = "";
            Key = 0;

        }
        // Método para exibir os dados da tabela SalaryTbl no DataGridView
        private void ShowSalary()
        {
            Con.Open();
            string Query = "Select * from SalaryTbl";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            SalaryDGV.DataSource = ds.Tables[0];
            Con.Close();
        }

        // Método para obter os funcionários e preencher o ComboBox de Funcionários com seus IDs
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

        // Método para obter os bônus e preencher um ComboBox com um dos bonus já cadastrados
        private void GetBonus()
        {
            Con.Open();
            SqlCommand cmd = new SqlCommand("Select * from BonusTbl", Con);
            SqlDataReader Rdr;
            Rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("BName", typeof(string));
            dt.Load(Rdr);
            BonusIdCb.ValueMember = "BName";
            BonusIdCb.DataSource = dt;

            Con.Close();
        }

        // Método para obter os registros de presença e preencher um ComboBox as presenças, faltas e faltas justificadas
        private void GetAttendance()
        {
            Con.Open();
            SqlCommand cmd = new SqlCommand("Select * from AttendanceTbl where EmpId="+EmpIdCb.SelectedValue.ToString()+"", Con);
            SqlDataReader Rdr;
            Rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("AttNum", typeof(int));
            dt.Load(Rdr);
            AttNumCb.ValueMember = "AttNum";
            AttNumCb.DataSource = dt;

            Con.Close();
        }

        // Método para obter os dados de presença selecionados e exibi-los em TextBoxes travados
        private void GetAttendanceData()
        {
            Con.Open();
            string Query = "Select * from AttendanceTbl where AttNum=" + AttNumCb.SelectedValue.ToString() + "";
            SqlCommand cmd = new SqlCommand(Query, Con);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                PresenceTb.Text = dr["DayPres"].ToString();
                AbsentTb.Text = dr["DayAbs"].ToString();
                ExcusedTb.Text = dr["DayExcused"].ToString();
            }
            Con.Close();
        }

        // Método para obter o nome e salário-base do funcionário selecionado
        private void GetEmployeeName()
        {
            Con.Open();
            string Query = "Select * from EmployeeTbl where EmpID=" + EmpIdCb.SelectedValue.ToString() + "";
            SqlCommand cmd = new SqlCommand(Query, Con);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                EmpNameTb.Text = dr["EmpName"].ToString();
                BaseSalaryTb.Text = dr["EmpBasSal"].ToString();
            }
            Con.Close();
        }

        

        // Método para obter o valor do bônus selecionado
        private void GetBonusAmt()
        {
            Con.Open();
            string Query = "Select * from BonusTbl where BName='" + BonusIdCb.SelectedValue.ToString() + "'";
            SqlCommand cmd = new SqlCommand(Query, Con);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                BonusTb.Text = dr["BAmt"].ToString();
                BonusTb.Text = dr["BAmt"].ToString();
            }
            Con.Close();
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
                    string Period = SalDate.Value.Month + "-" + SalDate.Value.Year;

                    Con.Open();

                    SqlCommand cmd = new SqlCommand("insert into SalaryTbl(EmpID,EmpName, SalPeriod, EmpBasSal, EmpBonus, EmpAdvance, EmpTax, EmpBalance)values(@EI,@EN, @SPER,@EBS,@EB,@EA,@ET,@EBa)", Con);
                    cmd.Parameters.AddWithValue("@EN", EmpNameTb.Text);
                    cmd.Parameters.AddWithValue("@EI", EmpIdCb.SelectedValue.ToString());
                    cmd.Parameters.AddWithValue("@SPER", Period);
                    cmd.Parameters.AddWithValue("@EBS", BaseSalaryTb.Text);
                    cmd.Parameters.AddWithValue("@EB", BonusTb.Text);
                    cmd.Parameters.AddWithValue("@EA", AdvanceTb.Text);
                    cmd.Parameters.AddWithValue("@ET", TotTax);
                    cmd.Parameters.AddWithValue("@EBa", GrdTot);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Salario Registrado");
                    Con.Close();
                    ShowSalary();
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
            GetAttendance();
        }

        private void BonusIdCb_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void BonusIdCb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            GetBonusAmt();
        }

        private void AttNumCb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            GetAttendanceData();
        }
        int Pres=0, Abs=0, Exc=0;
        Double DailyBase = 0;

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            // Configurações para desenhar o cabeçalho
            e.Graphics.DrawString("PIM LTDA", new Font("Arial", 12, FontStyle.Bold), Brushes.Red, new Point(160, 25));
            e.Graphics.DrawString("PayRollPro - Managemente System 1.0", new Font("Arial", 10, FontStyle.Bold), Brushes.Blue, new Point(125, 45));

            // Obtenção dos dados da linha selecionada no DataGridView
            String SalNum = SalaryDGV.SelectedRows[0].Cells[0].Value.ToString();
            String EmpId = SalaryDGV.SelectedRows[0].Cells[1].Value.ToString();
            String EmpName = SalaryDGV.SelectedRows[0].Cells[2].Value.ToString();
            String BasSal = SalaryDGV.SelectedRows[0].Cells[3].Value.ToString();
            String Bonus = SalaryDGV.SelectedRows[0].Cells[4].Value.ToString();
            String Advance = SalaryDGV.SelectedRows[0].Cells[5].Value.ToString();
            String Tax = SalaryDGV.SelectedRows[0].Cells[6].Value.ToString();
            String Balance = SalaryDGV.SelectedRows[0].Cells[8].Value.ToString();
            String Period = SalaryDGV.SelectedRows[0].Cells[7].Value.ToString();

            // Configurações para desenhar os detalhes do salário
            e.Graphics.DrawString("Salary Number: " + SalNum, new Font("Bellota", 10, FontStyle.Bold), Brushes.Blue, new Point(50, 100));
            e.Graphics.DrawString("Identificação do Funcionário: " + EmpId, new Font("Bellota", 10, FontStyle.Bold), Brushes.Blue, new Point(50, 150));
            e.Graphics.DrawString("Nome Do Funcionário: " + EmpName, new Font("Bellota", 10, FontStyle.Bold), Brushes.Blue, new Point(50, 180));
            e.Graphics.DrawString("Salário Base: R$ " + BasSal, new Font("Bellota", 10, FontStyle.Bold), Brushes.Blue, new Point(50, 210));
            e.Graphics.DrawString("Bonus: R$ " + Bonus, new Font("Bellota", 10, FontStyle.Bold), Brushes.Blue, new Point(50, 240));
            e.Graphics.DrawString("Adiantamento: R$ " + Advance, new Font("Bellota", 10, FontStyle.Bold), Brushes.Blue, new Point(50, 270));
            e.Graphics.DrawString("Descontos por faltas: R$ " + DescountAbs, new Font("Bellota", 10, FontStyle.Bold), Brushes.Blue, new Point(50, 300));
            e.Graphics.DrawString("Impostos: R$ " + Tax, new Font("Bellota", 10, FontStyle.Bold), Brushes.Blue, new Point(50, 330));
            e.Graphics.DrawString("Total: R$ " + Balance, new Font("Bellota", 10, FontStyle.Bold), Brushes.Blue, new Point(50, 360));
            e.Graphics.DrawString("Periodo: " + Period, new Font("Bellota", 10, FontStyle.Bold), Brushes.Blue, new Point(50, 390));

            // Configurações para desenhar o rodapé
            e.Graphics.DrawString("PIM LTDA", new Font("Bellota", 12, FontStyle.Bold), Brushes.Crimson, new Point(150, 450));
            e.Graphics.DrawString("PayRollPro - Management System 1.0", new Font("Bellota", 10, FontStyle.Bold), Brushes.Crimson, new Point(100, 480));
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
            Bonus Obj = new Bonus();
            Obj.Show();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Attendances Obj = new Attendances();
            Obj.Show();
            this.Hide();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Você já está na categoria selecionada!");
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
            MessageBox.Show("Você já está na categoria selecionada!");
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Attendances Obj = new Attendances();
            Obj.Show();
            this.Hide();
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

        private void BonusTb_TextChanged(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void SalaryDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            printDocument1.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("pprnm", 500, 800);
            if (printPreviewDialog1.ShowDialog()== DialogResult.OK)
            {
                printDocument1.Print();
            }
        }

        private void BaseSalaryTb_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        double GrdTot = 0, TotTax=0, Total = 0, DescountAbs = 0;
        private void ComputeBtn_Click(object sender, EventArgs e)
        {
            if (BaseSalaryTb.Text == "" || BonusTb.Text == "" || AdvanceTb.Text == "")
            {
                MessageBox.Show("Selecione o Empregado");
            }
            else
            {
                Pres = Convert.ToInt32(PresenceTb.Text);
                Abs = Convert.ToInt32(AbsentTb.Text);
                Exc = Convert.ToInt32(ExcusedTb.Text);

                if (Pres + Abs == 0)
                {
                    MessageBox.Show("Presença e Ausência não podem ser ambas zero");
                    return;
                }

                // Calcula do salário diário base
                DailyBase = Convert.ToInt32(BaseSalaryTb.Text) / (Pres + Abs);
                int Bns = Convert.ToInt32(BonusTb.Text);

                // Calculo do salário total antes dos descontos
                Total = (DailyBase * (Pres + Exc));

                // Calcular o imposto (28% do total)
                double Tax = Total * 0.28;

                // Calculo do desconto por faltas
                DescountAbs = ((Abs) * DailyBase) - (DailyBase * Exc);

                // Calcular o total de descontos
                TotTax = Tax + DescountAbs;

                // Calcular o salário líquido
                GrdTot = Total - TotTax - Convert.ToInt32(AdvanceTb.Text) + Bns;

                BalanceTb.Text = "R$" + GrdTot;
            }
        }
    }
}
