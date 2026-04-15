using Giling_Padi;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace AplikasiGilinganPadi
{
    public partial class FormUtama : Form
    {
        private SqlConnection conn;
        private readonly string connectionString =
            "Data Source=localhost;Initial Catalog=GilinganPadi;Integrated Security=True";

        public FormUtama()
        {
            InitializeComponent();
            conn = new SqlConnection(connectionString);
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                conn.Open();
                string query = "SELECT id_antrian, nama_petani, alamat, no_telepon, berat_gabah, status FROM Antrian";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvAntrian.DataSource = dt;
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnTambah_Click(object sender, EventArgs e)
        {
            FormAntrian form = new FormAntrian();
            form.ShowDialog();
            LoadData();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            FormLogin login = new FormLogin();
            login.Show();
            this.Close();
        }
    }
}