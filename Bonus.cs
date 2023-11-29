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
    public partial class Bonus : Form
    {
        public Bonus()
        {
            InitializeComponent();
            ShowBonus();
        }
        private void Clear()
        {
            BNameTb.Text = "";
            BAmountTb.Text = "";
            
            Key = 0;

        }
        private void ShowBonus()
        {
            Con.Open();
            string Query = "Select * from BonusTbl";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            BonusDGV.DataSource = ds.Tables[0];
            Con.Close();
        }

        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\lobin\OneDrive\Documentos\PayRollProDB.mdf;Integrated Security=True;Connect Timeout=30");
        int Key = 0;

        //Mostra no DGV os bonus já cadastrados
        private void bunifuDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            BNameTb.Text = BonusDGV.SelectedRows[0].Cells[1].Value.ToString();
            BAmountTb.Text = BonusDGV.SelectedRows[0].Cells[2].Value.ToString();
            if (BNameTb.Text =="")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(BonusDGV.SelectedRows[0].Cells[0].Value.ToString());
            }

        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (BNameTb.Text=="" || BAmountTb.Text=="")
            {
                MessageBox.Show("Faltam Informações");
            }
            else
            {
                try
                {
                    Con.Open();

                    // Criar um objeto SqlCommand para inserir um novo registro na tabela BonusTbl
                    SqlCommand cmd = new SqlCommand("insert into BonusTbl(BName, BAmt)values(@BN, @BA)", Con);

                    // Adicionar parâmetros ao comando para evitar SQL Injection
                    cmd.Parameters.AddWithValue("@BN", BNameTb.Text);
                    cmd.Parameters.AddWithValue("@BA", BAmountTb.Text);

                    // Executar a consulta SQL para inserir o registro
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Bonus Registrado");
                    Con.Close();
                    ShowBonus();
                    Clear();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void EditBtn_Click(object sender, EventArgs e)
        {
            if (BNameTb.Text=="" || BAmountTb.Text=="")
            {
                MessageBox.Show("Faltam Informações");
            }
            else
            {
                try
                {
                    Con.Open();

                    // Criar um objeto SqlCommand para atualizar as informações do bônus na tabela BonusTbl
                    SqlCommand cmd = new SqlCommand("Update BonusTbl Set BName=@BN, BAmt=@BA where BId=@BKey", Con);
                    // Adicionar parâmetros ao comando para evitar SQL Injection
                    cmd.Parameters.AddWithValue("@BN", BNameTb.Text);
                    cmd.Parameters.AddWithValue("@BA", BAmountTb.Text);
                    cmd.Parameters.AddWithValue("@BKey", Key);
                    // Executar a consulta SQL para atualizar as informações do bônus
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Bonus Atualizado");
                    Con.Close();
                    ShowBonus();
                    Clear();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void Close_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (Key == 0)
            {
                MessageBox.Show("Selecione o Bonus");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("Delete From BonusTbl Where BId=@BKey", Con);
                    cmd.Parameters.AddWithValue("@BKey", Key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Bonus Deletado");
                    Con.Close();
                    ShowBonus();
                    Clear();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }
    }
}
