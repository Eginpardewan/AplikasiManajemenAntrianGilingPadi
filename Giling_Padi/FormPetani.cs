using System;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace AplikasiGilinganPadi
{
    public partial class FormPetani : Form
    {
        private string connectionString;
        private int idPetani;
        private bool isEdit = false;

        // BindingSource untuk navigasi data
        private BindingSource bsPetani;
        private DataTable dtPetani;

        public FormPetani(string connString, int id = 0)
        {
            InitializeComponent();
            this.connectionString = connString;
            this.idPetani = id;
            this.isEdit = (id > 0);

            // Inisialisasi BindingSource
            bsPetani = new BindingSource();

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

        // ========== LOAD DATA ==========
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
                MessageBox.Show("Error load data: " + ex.Message);
            }
        }

        // ========== TOMBOL TEST SQL INJECTION ==========
        private void btnTestInjection_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNama.Text))
            {
                MessageBox.Show("❌ Masukkan Nama Petani untuk uji injection!\nContoh: ' OR 1=1 --",
                    "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // ⚠️ RENTAN SQL INJECTION! ⚠️
                    string query = "UPDATE Petani SET alamat = 'HACKED BY SQL INJECTION' WHERE nama = '" + txtNama.Text + "'";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        int result = cmd.ExecuteNonQuery();
                        MessageBox.Show(result + " baris terupdate! Data mungkin telah berubah!\n\n" +
                            "Cek tab Data Petani di Form Utama untuk melihat perubahan.",
                            "⚠️ Hasil SQL Injection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ========== RESET DATA (HANYA PETANI - TIDAK MENGHAPUS ANTRIAN) ==========
        private void btnResetData_Click(object sender, EventArgs e)
        {
            DialogResult confirm = MessageBox.Show(
                "⚠️ PERINGATAN!\n\n" +
                "Reset data akan menghapus SEMUA data PETANI dan mengembalikannya ke data awal.\n\n" +
                "Data ANTRIAN dan HASIL GILING akan TETAP ADA (tidak dihapus).\n\n" +
                "Apakah Anda yakin?",
                "Konfirmasi Reset Data Petani",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();

                        // Hanya hapus data Petani (TIDAK menyentuh Antrian dan HasilGiling)
                        string query = @"
                            -- Hapus semua data petani
                            DELETE FROM Petani;
                            
                            -- Reset identity petani ke 0 agar id dimulai dari 1 lagi
                            DBCC CHECKIDENT ('Petani', RESEED, 0);
                            
                            -- Insert data default petani (5 data awal)
                            INSERT INTO Petani (nama, alamat, no_telepon) VALUES
                            ('Ahmad Supriyadi', 'Ds. Sukamakmur RT 01 RW 02', '081234567890'),
                            ('Siti Aminah', 'Ds. Sukamakmur RT 03 RW 02', '081234567891'),
                            ('Joko Widodo', 'Ds. Sukamaju RT 02 RW 01', '081234567892'),
                            ('Umi Kalsum', 'Ds. Sukamakmur RT 02 RW 01', '081234567893'),
                            ('Bambang Suprapto', 'Ds. Sukamaju RT 05 RW 02', '081234567894');";

                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.ExecuteNonQuery();
                        }

                        MessageBox.Show("✅ Data PETANI berhasil direset ke kondisi awal!\n\n" +
                            "Data Antrian dan Hasil Giling tetap ada.\n\n" +
                            "Data Petani: 5 data",
                            "Reset Berhasil",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);

                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("❌ Reset gagal: " + ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // ========== VALIDASI INPUT ==========
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

        // ========== SIMPAN (Menggunakan Stored Procedure) ==========
        private void btnSimpan_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
                return;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    if (isEdit)
                    {
                        // UPDATE via Stored Procedure
                        SqlCommand cmd = new SqlCommand("sp_UpdatePetani", conn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id_petani", idPetani);
                        cmd.Parameters.AddWithValue("@nama", txtNama.Text.Trim());
                        cmd.Parameters.AddWithValue("@alamat", txtAlamat.Text.Trim());
                        cmd.Parameters.AddWithValue("@no_telepon", txtNoTelepon.Text.Trim());
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("✅ Data petani berhasil diupdate!", "Sukses",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        // INSERT via Stored Procedure
                        SqlCommand cmd = new SqlCommand("sp_InsertPetani", conn);
                        cmd.CommandType = CommandType.StoredProcedure;
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
            catch (SqlException ex)
            {
                // Tangani error dari stored procedure
                MessageBox.Show("Error: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
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
    }
}