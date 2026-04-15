using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace AplikasiGilinganPadi
{
    public partial class FormHasilGiling : Form
    {
        private SqlConnection conn;
        private string connectionString;
        private int idAntrian;
        private decimal beratGabah = 0;

        public FormHasilGiling(string connString, int id)
        {
            InitializeComponent();
            connectionString = connString;
            conn = new SqlConnection(connectionString);
            idAntrian = id;
            LoadDataAntrian();
        }

        private void LoadDataAntrian()
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                string query = "SELECT nomor_antrian, nama_petani, alamat, no_telepon, berat_gabah FROM Antrian WHERE id_antrian = @id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", idAntrian);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    // Isi data antrian (readonly)
                    txtNomorAntrian.Text = reader["nomor_antrian"].ToString();
                    txtNamaPetani.Text = reader["nama_petani"].ToString();
                    txtAlamat.Text = reader["alamat"].ToString();
                    txtNoTelepon.Text = reader["no_telepon"].ToString();
                    beratGabah = Convert.ToDecimal(reader["berat_gabah"]);
                    txtBeratGabah.Text = beratGabah.ToString("F2");

                    // FORM KOSONG - Tidak ada estimasi otomatis
                    txtBerasDihasilkan.Clear();
                    txtDedak.Clear();

                    // Set label info maksimal
                    lblInfoMaksimal.Text = $"⚠️ Maksimal total beras + dedak = {beratGabah:F2} kg";
                    lblInfoBatasBeras.Text = $"Max: {beratGabah:F2} kg";
                    lblInfoBatasDedak.Text = $"Max: {beratGabah:F2} kg";

                    // Set focus ke field beras dihasilkan
                    txtBerasDihasilkan.Focus();
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

        // ========== BATASI NILAI AGAR TIDAK MELEBIHI BATAS ==========
        private void BatasiNilai(TextBox textBox, decimal batasMaksimal)
        {
            if (string.IsNullOrEmpty(textBox.Text))
                return;

            if (decimal.TryParse(textBox.Text, out decimal nilai))
            {
                if (nilai > batasMaksimal)
                {
                    textBox.Text = batasMaksimal.ToString("F2");
                    textBox.Select(textBox.Text.Length, 0);
                    MessageBox.Show($"⚠️ Nilai tidak boleh melebihi {batasMaksimal:F2} kg!",
                        "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (nilai < 0)
                {
                    textBox.Text = "0";
                    textBox.Select(textBox.Text.Length, 0);
                }
            }
        }

        // ========== UPDATE STATUS WARNA ==========
        private void UpdateStatusWarna()
        {
            // Cek Beras
            if (!string.IsNullOrEmpty(txtBerasDihasilkan.Text))
            {
                if (decimal.TryParse(txtBerasDihasilkan.Text, out decimal beras))
                {
                    if (beras > beratGabah)
                    {
                        txtBerasDihasilkan.BackColor = Color.LightCoral;
                        lblStatusBeras.Text = "❌ Melebihi batas!";
                        lblStatusBeras.ForeColor = Color.Red;
                    }
                    else
                    {
                        txtBerasDihasilkan.BackColor = Color.White;
                        lblStatusBeras.Text = "✅ OK";
                        lblStatusBeras.ForeColor = Color.Green;
                    }
                }
            }
            else
            {
                txtBerasDihasilkan.BackColor = Color.White;
                lblStatusBeras.Text = "";
            }

            // Cek Dedak
            if (!string.IsNullOrEmpty(txtDedak.Text))
            {
                if (decimal.TryParse(txtDedak.Text, out decimal dedak))
                {
                    if (dedak > beratGabah)
                    {
                        txtDedak.BackColor = Color.LightCoral;
                        lblStatusDedak.Text = "❌ Melebihi batas!";
                        lblStatusDedak.ForeColor = Color.Red;
                    }
                    else
                    {
                        txtDedak.BackColor = Color.White;
                        lblStatusDedak.Text = "✅ OK";
                        lblStatusDedak.ForeColor = Color.Green;
                    }
                }
            }
            else
            {
                txtDedak.BackColor = Color.White;
                lblStatusDedak.Text = "";
            }

            // Cek Total
            if (!string.IsNullOrEmpty(txtBerasDihasilkan.Text) && !string.IsNullOrEmpty(txtDedak.Text))
            {
                if (decimal.TryParse(txtBerasDihasilkan.Text, out decimal beras) &&
                    decimal.TryParse(txtDedak.Text, out decimal dedak))
                {
                    decimal total = beras + dedak;
                    if (total > beratGabah)
                    {
                        lblStatusTotal.Text = $"❌ Total {total:F2} kg melebihi {beratGabah:F2} kg!";
                        lblStatusTotal.ForeColor = Color.Red;
                    }
                    else
                    {
                        lblStatusTotal.Text = $"✅ Total {total:F2} kg (OK)";
                        lblStatusTotal.ForeColor = Color.Green;
                    }
                }
            }
            else
            {
                lblStatusTotal.Text = "";
            }
        }

        // ========== VALIDASI SAAT TEXT BERUBAH ==========
        private void txtBerasDihasilkan_TextChanged(object sender, EventArgs e)
        {
            BatasiNilai(txtBerasDihasilkan, beratGabah);
            UpdateStatusWarna();
        }

        private void txtDedak_TextChanged(object sender, EventArgs e)
        {
            BatasiNilai(txtDedak, beratGabah);
            UpdateStatusWarna();
        }

        // ========== VALIDASI INPUT HANYA ANGKA ==========
        private void txtBerasDihasilkan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar))
                return;

            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
                return;
            }

            if (e.KeyChar == '.' && txtBerasDihasilkan.Text.Contains("."))
            {
                e.Handled = true;
                return;
            }

            if (e.KeyChar == '.' && string.IsNullOrEmpty(txtBerasDihasilkan.Text))
            {
                e.Handled = true;
                return;
            }
        }

        private void txtDedak_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar))
                return;

            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
                return;
            }

            if (e.KeyChar == '.' && txtDedak.Text.Contains("."))
            {
                e.Handled = true;
                return;
            }

            if (e.KeyChar == '.' && string.IsNullOrEmpty(txtDedak.Text))
            {
                e.Handled = true;
                return;
            }
        }

        // ========== TOMBOL SIMPAN ==========
        private void btnSimpan_Click(object sender, EventArgs e)
        {
            // Validasi input Beras Dihasilkan
            if (string.IsNullOrEmpty(txtBerasDihasilkan.Text))
            {
                MessageBox.Show("❌ Beras yang dihasilkan harus diisi!", "Validasi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtBerasDihasilkan.Focus();
                return;
            }

            // Validasi input Dedak
            if (string.IsNullOrEmpty(txtDedak.Text))
            {
                MessageBox.Show("❌ Dedak yang dihasilkan harus diisi!", "Validasi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDedak.Focus();
                return;
            }

            decimal berasDihasilkan, dedak;

            // Validasi format angka Beras
            if (!decimal.TryParse(txtBerasDihasilkan.Text, out berasDihasilkan))
            {
                MessageBox.Show("❌ Format Beras yang dihasilkan tidak valid! Masukkan angka yang benar.\nContoh: 65.5",
                    "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtBerasDihasilkan.Focus();
                return;
            }

            // Validasi format angka Dedak
            if (!decimal.TryParse(txtDedak.Text, out dedak))
            {
                MessageBox.Show("❌ Format Dedak tidak valid! Masukkan angka yang benar.\nContoh: 30.5",
                    "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDedak.Focus();
                return;
            }

            // Validasi tidak boleh negatif
            if (berasDihasilkan < 0)
            {
                MessageBox.Show("❌ Beras yang dihasilkan tidak boleh negatif!", "Validasi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtBerasDihasilkan.Focus();
                return;
            }

            if (dedak < 0)
            {
                MessageBox.Show("❌ Dedak tidak boleh negatif!", "Validasi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDedak.Focus();
                return;
            }

            // Validasi Beras tidak boleh melebihi Berat Gabah
            if (berasDihasilkan > beratGabah)
            {
                MessageBox.Show($"❌ Beras yang dihasilkan ({berasDihasilkan:F2} kg) tidak boleh melebihi Berat Gabah ({beratGabah:F2} kg)!",
                    "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtBerasDihasilkan.Focus();
                return;
            }

            // Validasi Dedak tidak boleh melebihi Berat Gabah
            if (dedak > beratGabah)
            {
                MessageBox.Show($"❌ Dedak ({dedak:F2} kg) tidak boleh melebihi Berat Gabah ({beratGabah:F2} kg)!",
                    "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDedak.Focus();
                return;
            }

            // Validasi total tidak melebihi berat gabah
            if (berasDihasilkan + dedak > beratGabah)
            {
                MessageBox.Show($"❌ Total Beras + Dedak ({berasDihasilkan + dedak:F2} kg) melebihi Berat Gabah ({beratGabah:F2} kg)!",
                    "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtBerasDihasilkan.Focus();
                return;
            }

            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                // Cek apakah sudah ada hasil giling untuk antrian ini
                string cekQuery = "SELECT COUNT(*) FROM HasilGiling WHERE id_antrian = @id";
                SqlCommand cekCmd = new SqlCommand(cekQuery, conn);
                cekCmd.Parameters.AddWithValue("@id", idAntrian);
                int exists = Convert.ToInt32(cekCmd.ExecuteScalar());

                if (exists > 0)
                {
                    // Update data yang sudah ada
                    string query = @"UPDATE HasilGiling SET 
                                    beras_dihasilkan = @beras, 
                                    dedak = @dedak 
                                    WHERE id_antrian = @id";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@beras", berasDihasilkan);
                    cmd.Parameters.AddWithValue("@dedak", dedak);
                    cmd.Parameters.AddWithValue("@id", idAntrian);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("✅ Hasil giling berhasil diupdate!", "Sukses",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // Insert data baru
                    string query = @"INSERT INTO HasilGiling 
                                    (id_antrian, nama_petani, alamat, no_telepon, beras_dihasilkan, dedak) 
                                    VALUES 
                                    (@id, @nama, @alamat, @telp, @beras, @dedak)";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", idAntrian);
                    cmd.Parameters.AddWithValue("@nama", txtNamaPetani.Text);
                    cmd.Parameters.AddWithValue("@alamat", txtAlamat.Text);
                    cmd.Parameters.AddWithValue("@telp", txtNoTelepon.Text);
                    cmd.Parameters.AddWithValue("@beras", berasDihasilkan);
                    cmd.Parameters.AddWithValue("@dedak", dedak);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("✅ Hasil giling berhasil dicatat!", "Sukses",
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
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }

        // ========== TOMBOL BATAL ==========
        private void btnBatal_Click(object sender, EventArgs e)
        {
            DialogResult confirm = MessageBox.Show("Yakin ingin membatalkan pencatatan hasil giling?",
                "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                this.Close();
            }
        }

        // ========== FORM CLOSING ==========
        private void FormHasilGiling_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (conn != null && conn.State == ConnectionState.Open)
            {
                conn.Close();
                conn.Dispose();
            }
        }
    }
}