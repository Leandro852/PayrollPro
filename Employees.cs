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
    public partial class Employees : Form
    {
        public Employees()
        {
            InitializeComponent();
            ShowEmployee();

        }
        private void Clear()
        {
            EmpNameTb.Text = "";
            EmpAddTb.Text = "";
            EmpPhoneTb.Text = "";
            EmpSalTb.Text = "";
            EmpGenCb.SelectedIndex = 0;
            EmpPosCb.SelectedIndex = 0; 
            EmpQualCb.SelectedIndex = 0;
            Key = 0;
        }
        private void ShowEmployee()
        {
            Con.Open();
            // Construir a consulta SQL para selecionar todos os campos da tabela EmployeeTbl
            string Query = "Select * from EmployeeTbl";
            // Criar um objeto SqlDataAdapter para executar a consulta SQL na conexão atual
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            // Criar um construtor de comando (CommandBuilder) para gerar comandos SQL automaticamente
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            // Criar um DataSet para armazenar os resultados da consulta
            var ds = new DataSet();
            // Preencher o DataSet com os dados do SqlDataAdapter
            sda.Fill(ds);
            // Configurar o controle DataGridView (EmployeeDGV) para exibir a primeira tabela do DataSet
            EmployeeDGV.DataSource = ds.Tables[0];
            Con.Close();
        }

        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\lobin\OneDrive\Documentos\PayRollProDB.mdf;Integrated Security=True;Connect Timeout=30");
        private void SaveBtn_Click(object sender, EventArgs e)
        {    // Verificar se todos os campos obrigatórios estão preenchidos
            if (EmpNameTb.Text == "" || EmpPhoneTb.Text == "" || EmpGenCb.SelectedIndex == -1 || EmpAddTb.Text == "" || EmpSalTb.Text == "" || EmpQualCb.SelectedIndex == -1)
            {
                // Exibir uma mensagem se houver campos vazios
                MessageBox.Show("Faltam Informações");
            }
            else
            {
                try
                {
                    Con.Open();
                    // Criar um objeto SqlCommand para inserir um novo registro na tabela EmployeeTbl
                    SqlCommand cmd = new SqlCommand("insert into EmployeeTbl(EmpName,EmpGen, EmpDOB, EmpPhone, EmpAdd, EmpPos, JoinDate, EmpQual, EmpBasSal)values(@EN, @EG, @ED, @EP, @EA, @EPos, @JD, @EQ, @EBS)", Con);
                    // Adicionar parâmetros ao comando para evitar SQL Injection
                    cmd.Parameters.AddWithValue("@EN", EmpNameTb.Text);
                    cmd.Parameters.AddWithValue("@EG", EmpGenCb.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@ED", EmpDOB.Value.Date);
                    cmd.Parameters.AddWithValue("@EP", EmpPhoneTb.Text);
                    cmd.Parameters.AddWithValue("@EA", EmpAddTb.Text);
                    cmd.Parameters.AddWithValue("@EPos", EmpPosCb.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@JD", JDate.Value.Date);
                    cmd.Parameters.AddWithValue("@EQ", EmpQualCb.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@EBS", EmpSalTb.Text);
                    // Executar a consulta SQL para inserir o registro
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Empregado Salvo");

                    Con.Close();
                    ShowEmployee();
                    Clear();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }
        int Key = 0;
        private void EmployeeDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Preencher os campos do formulário com os valores da linha selecionada no DataGridView
            EmpNameTb.Text = EmployeeDGV.SelectedRows[0].Cells[1].Value.ToString();
            EmpGenCb.SelectedItem = EmployeeDGV.SelectedRows[0].Cells[2].Value.ToString();
            EmpDOB.Text = EmployeeDGV.SelectedRows[0].Cells[3].Value.ToString();
            EmpPhoneTb.Text = EmployeeDGV.SelectedRows[0].Cells[4].Value.ToString();
            EmpAddTb.Text = EmployeeDGV.SelectedRows[0].Cells[5].Value.ToString();
            EmpPosCb.SelectedItem = EmployeeDGV.SelectedRows[0].Cells[6].Value.ToString();
            JDate.Text = EmployeeDGV.SelectedRows[0].Cells[7].Value.ToString();
            EmpQualCb.SelectedItem = EmployeeDGV.SelectedRows[0].Cells[8].Value.ToString();
            EmpSalTb.Text = EmployeeDGV.SelectedRows[0].Cells[9].Value.ToString();
            // Verificar se o campo de nome do funcionário está vazio
            if (EmpNameTb.Text=="")
            {
                // Se estiver vazio, definir a variável Key como 0
                Key = 0;
            }
            else
            {
                // Se não estiver vazio, obter o valor da célula 0 e converter para inteiro, atribuindo à variável Key
                Key = Convert.ToInt32(EmployeeDGV.SelectedRows[0].Cells[0].Value.ToString());  
            }

        }

        private void EditBtn_Click(object sender, EventArgs e)
        {
            // Verificar se todos os campos obrigatórios estão preenchidos
            if (EmpNameTb.Text == "" || EmpPhoneTb.Text == "" || EmpGenCb.SelectedIndex == -1 || EmpAddTb.Text == "" || EmpSalTb.Text == "" || EmpQualCb.SelectedIndex == -1)
            {
                MessageBox.Show("Faltam Informações");
            }
            else
            {
                try
                {
                    Con.Open();

                    // Criar um objeto SqlCommand para atualizar as informações do funcionário na tabela EmployeeTbl
                    SqlCommand cmd = new SqlCommand("Update EmployeeTbl Set EmpName=@EN,EmpGen=@EG, EmpDOB=@ED, EmpPhone=@EP, EmpAdd=@EA, EmpPos=@EPos, JoinDate=@JD, EmpQual=@EQ, EmpBasSal=@EBS where EmpID=@EmpKey", Con);
                    
                    // Adicionar parâmetros ao comando para evitar SQL Injection
                    cmd.Parameters.AddWithValue("@EN", EmpNameTb.Text);
                    cmd.Parameters.AddWithValue("@EG", EmpGenCb.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@ED", EmpDOB.Value.Date);
                    cmd.Parameters.AddWithValue("@EP", EmpPhoneTb.Text);
                    cmd.Parameters.AddWithValue("@EA", EmpAddTb.Text);
                    cmd.Parameters.AddWithValue("@EPos", EmpPosCb.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@JD", JDate.Value.Date);
                    cmd.Parameters.AddWithValue("@EQ", EmpQualCb.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@EBS", EmpSalTb.Text);

                    // Adicionar o parâmetro da chave primária (ID) para identificar o funcionário a ser atualizado
                    cmd.Parameters.AddWithValue("@EmpKey", Key);

                    // Executar a consulta SQL para atualizar as informações do funcionário
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Empregado Atualizado");

                    Con.Close();
                    ShowEmployee();
                    Clear();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void DelBtn_Click(object sender, EventArgs e)
        {
            // Verificar se a chave primária (ID) é válida
            if (Key == 0)
            {
                MessageBox.Show("Faltam Informações");
            }
            else
            {
                try
                {
                    Con.Open();

                    // Criar um objeto SqlCommand para excluir um funcionário da tabela EmployeeTbl 
                    SqlCommand cmd = new SqlCommand("Delete From EmployeeTbl Where EmpId=@EmpKey", Con);

                    // Adicionar o parâmetro da chave primária (ID) para identificar o funcionário a ser deletado
                    cmd.Parameters.AddWithValue("@EmpKey", Key);

                    // Executar a consulta SQL para excluir o funcionário
                    cmd.ExecuteNonQuery();
                    // Exibir mensagem de sucesso
                    MessageBox.Show("Empregado Deletado");

                    Con.Close();
                    ShowEmployee();
                    Clear() ;
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void BonusBtn_Click(object sender, EventArgs e)
        {
            Bonus Obj = new Bonus();
            Obj.Show();
        }

        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {

        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
        }

        private void EmpAddTb_TextChanged(object sender, EventArgs e)
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
            MessageBox.Show("Você já está na categoria selecionada!");
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

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Home Obj = new Home();
            Obj.Show();
            this.Hide();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Você já está na categoria selecionada!");
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

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Advances Obj = new Advances();
            Obj.Show();
        }

        private void EmpCpfTb_TextChanged(object sender, EventArgs e)
        {

        }

        private void EmpNameTb_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
