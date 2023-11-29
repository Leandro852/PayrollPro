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
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
            CountEmployees();
            CountMenagers();
            SumBonus();
            SumSalary();
        }

        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\lobin\OneDrive\Documentos\PayRollProDB.mdf;Integrated Security=True;Connect Timeout=30");
        private void CountEmployees()
        {
            Con.Open();

            // Criar um objeto SqlDataAdapter para executar a consulta SQL que conta o número de registros na tabela EmployeeTbl
            SqlDataAdapter sda = new SqlDataAdapter("Select Count(*) from EmployeeTbl", Con);

            // Criar um objeto DataTable para armazenar os resultados da consulta
            DataTable dt = new DataTable();

            // Preencher o DataTable com os resultados do SqlDataAdapter
            sda.Fill(dt);

            // Exibir o resultado (número de funcionários) no rótulo EmpLbl
            EmpLbl.Text = dt.Rows[0][0].ToString();
            Con.Close();
        }

        private void CountMenagers()
        {
            string Pos = "Gerente";
            Con.Open();
            // Criar um objeto SqlDataAdapter para executar a consulta SQL que conta o número de registros na tabela EmployeeTbl nos quais a posição seja igual a Gerente
            SqlDataAdapter sda = new SqlDataAdapter("Select Count(*) from EmployeeTbl Where EmpPos= '"+Pos+"'", Con);

            // Criar um objeto DataTable para armazenar os resultados da consulta
            DataTable dt = new DataTable();

            // Preencher o DataTable com os resultados do SqlDataAdapter
            sda.Fill(dt);

            // Exibir o número de gerentes no rótulo respectivo para a contagem de gerentes
            MenagerLbl.Text = dt.Rows[0][0].ToString();
            Con.Close();
        }

        private void SumSalary()
        {
            Con.Open();
            // Criar um objeto SqlDataAdapter para executar a consulta SQL que conta soma o balanço de todos os empregados na tabela SalaryTbl
            SqlDataAdapter sda = new SqlDataAdapter("Select Sum(EmpBalance) from SalaryTbl", Con);

            // Criar um objeto DataTable para armazenar os resultados da consulta
            DataTable dt = new DataTable();

            // Preencher o DataTable com os resultados do SqlDataAdapter
            sda.Fill(dt);

            // Exibir o valor total pago no rótulo respectivo para a contagem total de pagamentos
            SalaryLbl.Text = "R$ "+ dt.Rows[0][0].ToString();

            Con.Close();
        }

        private void SumBonus()
        {
            Con.Open();
            // Criar um objeto SqlDataAdapter para executar a consulta SQL que conta soma o bonus de todos os empregados na tabela SalaryTbl
            SqlDataAdapter sda = new SqlDataAdapter("Select Sum(EmpBonus) from SalaryTbl", Con);
            // Criar um objeto DataTable para armazenar os resultados da consulta
            DataTable dt = new DataTable();
            // Preencher o DataTable com os resultados do SqlDataAdapter
            sda.Fill(dt);
            // Exibir o valor total pago no rótulo respectivo para a contagem total de bonus dados
            BonusLbl.Text = "R$ "+dt.Rows[0][0].ToString();
            Con.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Você já está na categoria selecionada!");
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void Home_Load(object sender, EventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            Application.Exit(); 
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

        private void label5_Click(object sender, EventArgs e)
        {
            Attendances Obj = new Attendances();
            Obj.Show();
            this.Hide();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Salary Obj = new Salary();
            Obj.Show();
            this.Hide();
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void MenagerLbl_Click(object sender, EventArgs e)
        {

        }

        private void panel8_Paint(object sender, PaintEventArgs e)
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

        private void pictureBox5_Click_1(object sender, EventArgs e)
        {
            Advances Obj = new Advances();
            Obj.Show();
        }
    }
}
