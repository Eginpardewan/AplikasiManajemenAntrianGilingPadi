using Giling_Padi;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace AplikasiGilinganPadi
{
    public partial class FormLogin : Form
    {
        private readonly string connectionString =
            "Data Source=localhost;Initial Catalog=GilinganPadi;Integrated Security=True";

        public FormLogin()
        {
            InitializeComponent();
            txtPassword.PasswordChar = '*';
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Email dan Password harus diisi!", "Peringatan",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT id_admin, nama FROM Admin WHERE email = @email AND password = @password";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@password", password);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        int idAdmin = reader.GetInt32(0);
                        string namaAdmin = reader.GetString(1);

                        MessageBox.Show($"Selamat datang, {namaAdmin}!", "Login Berhasil",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        FormUtama formUtama = new FormUtama();
                        formUtama.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Email atau password salah!", "Login Gagal",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}