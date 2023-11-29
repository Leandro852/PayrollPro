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
using BCryptNet = BCrypt.Net.BCrypt;

namespace PayRollPor
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            ShowPasswordCb.Checked = false;
            PasswordTb.PasswordChar = '*';
        }

        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\lobin\OneDrive\Documentos\PayRollProDB.mdf;Integrated Security=True;Connect Timeout=30");
        private string HashPassword(string password, string salt)
        {
            string hashedPassword = BCryptNet.HashPassword(password, salt);
            return hashedPassword;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void LoginBtn_Click(object sender, EventArgs e)
        {
            if (UserTb.Text == "" || PasswordTb.Text == "")
            {
                MessageBox.Show("Faltam informações");
            }
            else
            {
                try
                {
                    Con.Open();

                    SqlCommand cmd = new SqlCommand("SELECT * FROM UsersTbl WHERE [User] = @UserName", Con);
                    cmd.Parameters.AddWithValue("@UserName", UserTb.Text);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        reader.Read(); // Ler o primeiro (e esperado único) resultado

                        string storedHash = reader["Password"].ToString();
                        string storedSalt = reader["Salt"].ToString();

                        // Use o mesmo sal para gerar o hash da senha inserida durante o login
                        string hashedPassword = HashPassword(PasswordTb.Text, storedSalt);

                        // Comparar os hashes
                        if (string.Equals(storedHash, hashedPassword, StringComparison.OrdinalIgnoreCase))
                        {
                            MessageBox.Show("Login realizado com sucesso");
                            Home Obj = new Home();
                            Obj.Show();
                            this.Hide();

                        }
                        else
                        {
                            MessageBox.Show("Credenciais inválidas. Falha no login.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Usuário não encontrado.");
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao tentar realizar o login: " + ex.Message);
                }
                finally
                {
                    Con.Close();
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void PasswordTb_TextChanged(object sender, EventArgs e)
        {

        }

        private void ShowPasswordCb_CheckedChanged(object sender, EventArgs e)
        {
            PasswordTb.PasswordChar = ShowPasswordCb.Checked ? '\0' : '*';

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void UserTb_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void BackLoginLbl_Click(object sender, EventArgs e)
        {
            Register Obj = new Register();
            Obj.Show();
            this.Hide();
        }
    }
}
