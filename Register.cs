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
using BCryptNet = BCrypt.Net.BCrypt;

namespace PayRollPor
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
            Clear();

            ShowPasswordCb.Checked = false;
            PasswordTb.PasswordChar = '*';
            ConfirmPassTb.PasswordChar = '*';   
        }

        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\lobin\OneDrive\Documentos\PayRollProDB.mdf;Integrated Security=True;Connect Timeout=30");

        private void Clear()
        {
            UserTb.Text = "";
            PasswordTb.Text = "";
            ConfirmPassTb.Text = "";
        }

        private string HashPassword(string password, out string salt)
        {
            salt = BCryptNet.GenerateSalt(12);
            string hashedPassword = BCryptNet.HashPassword(password, salt);
            return hashedPassword;
        }



        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Login Obj = new Login();
            Obj.Show();
            this.Hide();    
        }

        private void Close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BackLoginLbl_Click(object sender, EventArgs e)
        {
            Login Obj = new Login();
            Obj.Show();
            this.Hide();
        }

        private void RegisterBtn_Click(object sender, EventArgs e)
        {
            // Verificar se todos os campos obrigatórios estão preenchidos
            if (UserTb.Text == "" || PasswordTb.Text == "" || ConfirmPassTb.Text == "")
            {
                // Exibir uma mensagem se houver campos vazios
                MessageBox.Show("Faltam Informações");
            }
            else
            {
                if (PasswordTb.Text == ConfirmPassTb.Text)
                {
                    try
                    {
                        Con.Open();
                        // Use hashing de senha para maior segurança
                        string salt;
                        string hashedPassword = HashPassword(PasswordTb.Text, out salt);

                        SqlCommand cmd = new SqlCommand("INSERT INTO UsersTbl([User], [Password], [Salt]) VALUES(@Us, @Pw, @Salt)", Con);
                        // Adicionar parâmetros ao comando para evitar SQL Injection
                        cmd.Parameters.AddWithValue("@Us", UserTb.Text);
                        cmd.Parameters.AddWithValue("@Pw", hashedPassword);
                        cmd.Parameters.AddWithValue("@Salt", salt);
                        // Executar a consulta SQL para inserir o registro
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Usuário Salvo");

                        Con.Close();
                        Clear();
                        Login Obj = new Login();
                        Obj.Show();
                        this.Hide();
                    }
                    catch (Exception Ex)
                    {
                        MessageBox.Show(Ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("As senhas não coincidem");
                }
            }
        }

        private void ClearBtn_Click(object sender, EventArgs e)
        {
           Clear();
        }

        private void ShowPasswordCb_CheckedChanged(object sender, EventArgs e)
        {
            PasswordTb.PasswordChar = ShowPasswordCb.Checked ? '\0' : '*';
            ConfirmPassTb.PasswordChar=ShowPasswordCb.Checked ? '\0' : '*';
        }
    }
}
