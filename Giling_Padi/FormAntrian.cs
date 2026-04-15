using System;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace AplikasiGilinganPadi
{
    public partial class FormAntrian : Form
    {
        private SqlConnection conn;
        private string connectionString;
        private int idAntrian;
        private bool isEdit = false;
        private DateTime tanggalAwal;
        private DateTime minDate;
        private DateTime maxDate;

        public FormAntrian(string connString, int id)
        {
            InitializeComponent();
            connectionString = connString;
            conn = new SqlConnection(connectionString);
            idAntrian = id;
            isEdit = (id > 0);

            if (isEdit)
            {
                this.Text = "✏️ Edit Antrian";
                btnSimpan.Text = "✅ Update";
                LoadData();
            }
            else
            {
                this.Text = "➕ Tambah Antrian Baru";
                btnSimpan.Text = "💾 Simpan";
                GenerateNomorAntrian();

                // Hanya set value, TIDAK set MinDate/MaxDate agar semua tanggal terlihat
                dtpTanggal.Value = DateTime.Today;

                // Simpan range untuk validasi (tidak mempengaruhi tampilan kalender)
                minDate = DateTime.Today;
                maxDate = DateTime.Today.AddDays(7);
            }
        }

        private void GenerateNomorAntrian()
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                SqlCommand cmd = new SqlCommand("GenerateNomorAntrian", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                int nomor = Convert.ToInt32(cmd.ExecuteScalar());
                txtNomorAntrian.Text = nomor.ToString();

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadData()
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                string query = "SELECT * FROM Antrian WHERE id_antrian = @id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", idAntrian);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    txtNomorAntrian.Text = reader["nomor_antrian"].ToString();
                    txtNamaPetani.Text = reader["nama_petani"].ToString();
                    txtAlamat.Text = reader["alamat"].ToString();
                    txtNoTelepon.Text = reader["no_telepon"].ToString();
                    txtBeratGabah.Text = reader["berat_gabah"].ToString();
                    tanggalAwal = Convert.ToDateTime(reader["tanggal_antrian"]);
                    dtpTanggal.Value = tanggalAwal;
                    cmbStatus.Text = reader["status"].ToString();

                    // Simpan range untuk validasi (tidak mempengaruhi tampilan kalender)
                    minDate = tanggalAwal;
                    maxDate = tanggalAwal.AddDays(7);
                }
                reader.Close();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ========== VALIDASI TANGGAL (MANUAL, TIDAK MEMPENGARUHI TAMPILAN) ==========
        private bool ValidateTanggal()
        {
            DateTime selectedDate = dtpTanggal.Value.Date;

            if (!isEdit) // Mode Tambah
            {
                if (selectedDate < minDate)
                {
                    MessageBox.Show($"❌ Tanggal tidak boleh kurang dari {minDate:dd/MM/yyyy}!\n\n" +
                        $"Silakan pilih tanggal antara {minDate:dd/MM/yyyy} - {maxDate:dd/MM/yyyy}.",
                        "Validasi Tanggal", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dtpTanggal.Value = minDate;
                    return false;
                }

                if (selectedDate > maxDate)
                {
                    MessageBox.Show($"❌ Tanggal tidak boleh lebih dari {maxDate:dd/MM/yyyy}!\n\n" +
                        $"Silakan pilih tanggal antara {minDate:dd/MM/yyyy} - {maxDate:dd/MM/yyyy}.",
                        "Validasi Tanggal", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dtpTanggal.Value = maxDate;
                    return false;
                }
            }
            else // Mode Edit
            {
                if (selectedDate < minDate)
                {
                    MessageBox.Show($"❌ Tanggal tidak boleh kurang dari {minDate:dd/MM/yyyy}!\n\n" +
                        $"Tanggal awal antrian: {tanggalAwal:dd/MM/yyyy}\n" +
                        $"Silakan pilih tanggal antara {minDate:dd/MM/yyyy} - {maxDate:dd/MM/yyyy}.",
                        "Validasi Tanggal", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dtpTanggal.Value = minDate;
                    return false;
                }

                if (selectedDate > maxDate)
                {
                    MessageBox.Show($"❌ Tanggal tidak boleh lebih dari {maxDate:dd/MM/yyyy}!\n\n" +
                        $"Tanggal awal antrian: {tanggalAwal:dd/MM/yyyy}\n" +
                        $"Silakan pilih tanggal antara {minDate:dd/MM/yyyy} - {maxDate:dd/MM/yyyy}.",
                        "Validasi Tanggal", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dtpTanggal.Value = maxDate;
                    return false;
                }
            }

            return true;
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            // ========== VALIDASI SEMUA FIELD ==========

            // Validasi Nama Petani
            if (string.IsNullOrWhiteSpace(txtNamaPetani.Text))
            {
                MessageBox.Show("❌ Nama Petani harus diisi!", "Validasi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNamaPetani.Focus();
                return;
            }

            // Validasi Alamat
            if (string.IsNullOrWhiteSpace(txtAlamat.Text))
            {
                MessageBox.Show("❌ Alamat harus diisi!", "Validasi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAlamat.Focus();
                return;
            }

            // Validasi No Telepon
            if (string.IsNullOrWhiteSpace(txtNoTelepon.Text))
            {
                MessageBox.Show("❌ No Telepon harus diisi!", "Validasi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNoTelepon.Focus();
                return;
            }

            // Validasi Format No Telepon
            string noTelepon = txtNoTelepon.Text.Trim();
            if (!Regex.IsMatch(noTelepon, @"^[0-9]{10,15}$"))
            {
                MessageBox.Show("❌ No Telepon harus berisi 10-15 digit angka!\nContoh: 081234567890",
                    "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNoTelepon.Focus();
                return;
            }

            // Validasi Berat Gabah
            if (string.IsNullOrWhiteSpace(txtBeratGabah.Text))
            {
                MessageBox.Show("❌ Berat Gabah harus diisi!", "Validasi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtBeratGabah.Focus();
                return;
            }

            // Validasi Format Berat Gabah
            decimal beratGabah;
            if (!decimal.TryParse(txtBeratGabah.Text, out beratGabah))
            {
                MessageBox.Show("❌ Berat Gabah harus berupa angka yang valid!\nContoh: 100.5",
                    "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtBeratGabah.Focus();
                return;
            }

            // Validasi Berat Gabah > 0
            if (beratGabah <= 0)
            {
                MessageBox.Show("❌ Berat Gabah harus lebih dari 0 kg!",
                    "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtBeratGabah.Focus();
                return;
            }

            // Validasi Nama Petani minimal 3 karakter
            if (txtNamaPetani.Text.Trim().Length < 3)
            {
                MessageBox.Show("❌ Nama Petani minimal 3 karakter!",
                    "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNamaPetani.Focus();
                return;
            }

            // Validasi Alamat minimal 5 karakter
            if (txtAlamat.Text.Trim().Length < 5)
            {
                MessageBox.Show("❌ Alamat minimal 5 karakter!",
                    "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAlamat.Focus();
                return;
            }

            // ========== VALIDASI TANGGAL (MANUAL) ==========
            if (!ValidateTanggal())
            {
                return;
            }

            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                if (isEdit)
                {
                    // UPDATE
                    string query = @"UPDATE Antrian SET 
                                    nama_petani = @nama, 
                                    alamat = @alamat, 
                                    no_telepon = @telp, 
                                    berat_gabah = @berat, 
                                    tanggal_antrian = @tanggal, 
                                    status = @status 
                                    WHERE id_antrian = @id";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@nama", txtNamaPetani.Text.Trim());
                    cmd.Parameters.AddWithValue("@alamat", txtAlamat.Text.Trim());
                    cmd.Parameters.AddWithValue("@telp", txtNoTelepon.Text.Trim());
                    cmd.Parameters.AddWithValue("@berat", beratGabah);
                    cmd.Parameters.AddWithValue("@tanggal", dtpTanggal.Value);
                    cmd.Parameters.AddWithValue("@status", cmbStatus.Text);
                    cmd.Parameters.AddWithValue("@id", idAntrian);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("✅ Data antrian berhasil diupdate!", "Sukses",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // INSERT
                    string query = @"INSERT INTO Antrian 
                                    (nomor_antrian, nama_petani, alamat, no_telepon, berat_gabah, tanggal_antrian, status) 
                                    VALUES 
                                    (@nomor, @nama, @alamat, @telp, @berat, @tanggal, @status)";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@nomor", Convert.ToInt32(txtNomorAntrian.Text));
                    cmd.Parameters.AddWithValue("@nama", txtNamaPetani.Text.Trim());
                    cmd.Parameters.AddWithValue("@alamat", txtAlamat.Text.Trim());
                    cmd.Parameters.AddWithValue("@telp", txtNoTelepon.Text.Trim());
                    cmd.Parameters.AddWithValue("@berat", beratGabah);
                    cmd.Parameters.AddWithValue("@tanggal", dtpTanggal.Value);
                    cmd.Parameters.AddWithValue("@status", "menunggu");
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("✅ Antrian baru berhasil ditambahkan!", "Sukses",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                conn.Close();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (conn.State == ConnectionState.Open)
                    conn.Close();
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

        private void txtNoTelepon_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtBeratGabah_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }
            if (e.KeyChar == '.' && (sender as TextBox).Text.Contains("."))
            {
                e.Handled = true;
            }
        }

        private void txtNamaPetani_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void FormAntrian_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (conn != null && conn.State == ConnectionState.Open)
            {
                conn.Close();
                conn.Dispose();
            }
        }
    }
}