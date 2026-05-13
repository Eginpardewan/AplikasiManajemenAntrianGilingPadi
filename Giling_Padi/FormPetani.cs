using System;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Giling_Padi
{
    public partial class FormPetani : Form
    {
        private string connectionString;
        private int idPetani; // 0 untuk tambah, >0 untuk edit
        private bool isEdit = false;

        public FormPetani(string connString, int id = 0)
        {
            InitializeComponent();
            this.connectionString = connString;
            this.idPetani = id;
            this.isEdit = (id > 0);

            if (isEdit)
            {
                this.Text = "✏️ Edit Petani";
                btnSimpan.Text = "✅ Update";
                LoadData();
            }
            else
            {
                this.Text = "➕ Tambah Petani Baru";
                btnSimpan.Text = "💾 Simpan";
            }
        }

        private void LoadData()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT nama, alamat, no_telepon FROM Petani WHERE id_petani = @id";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", idPetani);
                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.Read())
                    {
                        txtNama.Text = dr["nama"].ToString();
                        txtAlamat.Text = dr["alamat"].ToString();
                        txtNoTelepon.Text = dr["no_telepon"].ToString();
                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error load data: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateInput()
        {
            // Validasi Nama
            if (string.IsNullOrWhiteSpace(txtNama.Text))
            {
                MessageBox.Show("❌ Nama Petani harus diisi!", "Validasi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNama.Focus();
                return false;
            }

            if (txtNama.Text.Trim().Length < 3)
            {
                MessageBox.Show("❌ Nama Petani minimal 3 karakter!", "Validasi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNama.Focus();
                return false;
            }

            // Validasi Alamat
            if (string.IsNullOrWhiteSpace(txtAlamat.Text))
            {
                MessageBox.Show("❌ Alamat harus diisi!", "Validasi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAlamat.Focus();
                return false;
            }

            if (txtAlamat.Text.Trim().Length < 5)
            {
                MessageBox.Show("❌ Alamat minimal 5 karakter!", "Validasi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAlamat.Focus();
                return false;
            }

            // Validasi No Telepon
            if (string.IsNullOrWhiteSpace(txtNoTelepon.Text))
            {
                MessageBox.Show("❌ No Telepon harus diisi!", "Validasi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNoTelepon.Focus();
                return false;
            }

            string noTelepon = txtNoTelepon.Text.Trim();
            if (!Regex.IsMatch(noTelepon, @"^[0-9]{10,15}$"))
            {
                MessageBox.Show("❌ No Telepon harus berisi 10-15 digit angka!\nContoh: 081234567890",
                    "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNoTelepon.Focus();
                return false;
            }

            return true;
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
                return;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    if (isEdit) // UPDATE
                    {
                        string query = @"UPDATE Petani 
                                        SET nama = @nama, 
                                            alamat = @alamat, 
                                            no_telepon = @no_telepon 
                                        WHERE id_petani = @id";
                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@nama", txtNama.Text.Trim());
                        cmd.Parameters.AddWithValue("@alamat", txtAlamat.Text.Trim());
                        cmd.Parameters.AddWithValue("@no_telepon", txtNoTelepon.Text.Trim());
                        cmd.Parameters.AddWithValue("@id", idPetani);
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("✅ Data petani berhasil diupdate!", "Sukses",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else // INSERT
                    {
                        string query = @"INSERT INTO Petani (nama, alamat, no_telepon) 
                                        VALUES (@nama, @alamat, @no_telepon)";
                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@nama", txtNama.Text.Trim());
                        cmd.Parameters.AddWithValue("@alamat", txtAlamat.Text.Trim());
                        cmd.Parameters.AddWithValue("@no_telepon", txtNoTelepon.Text.Trim());
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("✅ Petani baru berhasil ditambahkan!", "Sukses",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    conn.Close();
                }
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error menyimpan data: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBatal_Click(object sender, EventArgs e)
        {
            DialogResult confirm = MessageBox.Show("Yakin ingin membatalkan?",
                "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                this.Close();
            }
        }

        // ========== HANYA ANGKA UNTUK NO TELEPON ==========
        private void txtNoTelepon_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        // ========== HANYA HURUF UNTUK NAMA ==========
        private void txtNama_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}