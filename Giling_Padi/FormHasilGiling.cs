using System;
using System.Data;
using System.Data.SqlClient;
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
                    txtNomorAntrian.Text = reader["nomor_antrian"].ToString();
                    txtNamaPetani.Text = reader["nama_petani"].ToString();
                    txtAlamat.Text = reader["alamat"].ToString();
                    txtNoTelepon.Text = reader["no_telepon"].ToString();
                    beratGabah = Convert.ToDecimal(reader["berat_gabah"]);
                    txtBeratGabah.Text = beratGabah.ToString("F2");

                    txtBerasDihasilkan.Clear();
                    txtDedak.Clear();

                    lblInfoMaksimal.Text = $"⚠️ Maksimal total beras + dedak = {beratGabah:F2} kg";
                    lblInfoBatasBeras.Text = $"Max: {beratGabah:F2} kg";
                    lblInfoBatasDedak.Text = $"Max: {beratGabah:F2} kg";

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

        // ========== CEK DAN BATASI NILAI ==========
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
                        txtBerasDihasilkan.BackColor = System.Drawing.Color.LightCoral;
                        lblStatusBeras.Text = "❌ Melebihi batas!";
                        lblStatusBeras.ForeColor = System.Drawing.Color.Red;
                    }
                    else
                    {
                        txtBerasDihasilkan.BackColor = System.Drawing.Color.White;
                        lblStatusBeras.Text = "OK";
                        lblStatusBeras.ForeColor = System.Drawing.Color.Green;
                    }
                }
            }
            else
            {
                txtBerasDihasilkan.BackColor = System.Drawing.Color.White;
                lblStatusBeras.Text = "";
            }

            // Cek Dedak
            if (!string.IsNullOrEmpty(txtDedak.Text))
            {
                if (decimal.TryParse(txtDedak.Text, out decimal dedak))
                {
                    if (dedak > beratGabah)
                    {
                        txtDedak.BackColor = System.Drawing.Color.LightCoral;
                        lblStatusDedak.Text = "❌ Melebihi batas!";
                        lblStatusDedak.ForeColor = System.Drawing.Color.Red;
                    }
                    else
                    {
                        txtDedak.BackColor = System.Drawing.Color.White;
                        lblStatusDedak.Text = "OK";
                        lblStatusDedak.ForeColor = System.Drawing.Color.Green;
                    }
                }
            }
            else
            {
                txtDedak.BackColor = System.Drawing.Color.White;
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
                        lblStatusTotal.ForeColor = System.Drawing.Color.Red;
                    }
                    else
                    {
                        lblStatusTotal.Text = $"Total {total:F2} kg (OK)";
                        lblStatusTotal.ForeColor = System.Drawing.Color.Green;
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

        // ========== MENCEGAH INPUT TIDAK VALID ==========
        private void txtBerasDihasilkan_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Izinkan backspace, delete, enter, tab
            if (char.IsControl(e.KeyChar))
                return;

            // Izinkan angka dan titik
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
                return;
            }

            // Cegah titik jika sudah ada titik
            if (e.KeyChar == '.' && txtBerasDihasilkan.Text.Contains("."))
            {
                e.Handled = true;
                return;
            }

            // Cegah titik di awal
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

        // ========== MENCEGAH PASTE (CTRL+V) YANG TIDAK VALID ==========
        private void txtBerasDihasilkan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.V)
            {
                e.SuppressKeyPress = true;
                string clipboardText = Clipboard.GetText();

                if (decimal.TryParse(clipboardText, out decimal nilai))
                {
                    if (nilai <= beratGabah && nilai >= 0)
                    {
                        txtBerasDihasilkan.Text = nilai.ToString("F2");
                    }
                    else
                    {
                        MessageBox.Show($"❌ Nilai tidak valid! Maksimal {beratGabah:F2} kg",
                            "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("❌ Harap masukkan angka yang valid!",
                        "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void txtDedak_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.V)
            {
                e.SuppressKeyPress = true;
                string clipboardText = Clipboard.GetText();

                if (decimal.TryParse(clipboardText, out decimal nilai))
                {
                    if (nilai <= beratGabah && nilai >= 0)
                    {
                        txtDedak.Text = nilai.ToString("F2");
                    }
                    else
                    {
                        MessageBox.Show($"❌ Nilai tidak valid! Maksimal {beratGabah:F2} kg",
                            "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("❌ Harap masukkan angka yang valid!",
                        "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        // ========== TOMBOL SIMPAN ==========
        private void btnSimpan_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtBerasDihasilkan.Text))
            {
                MessageBox.Show("❌ Beras yang dihasilkan harus diisi!", "Validasi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtBerasDihasilkan.Focus();
                return;
            }

            if (string.IsNullOrEmpty(txtDedak.Text))
            {
                MessageBox.Show("❌ Dedak yang dihasilkan harus diisi!", "Validasi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDedak.Focus();
                return;
            }

            decimal berasDihasilkan, dedak;

            if (!decimal.TryParse(txtBerasDihasilkan.Text, out berasDihasilkan))
            {
                MessageBox.Show("❌ Format Beras tidak valid!", "Validasi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtBerasDihasilkan.Focus();
                return;
            }

            if (!decimal.TryParse(txtDedak.Text, out dedak))
            {
                MessageBox.Show("❌ Format Dedak tidak valid!", "Validasi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDedak.Focus();
                return;
            }

            if (berasDihasilkan < 0 || dedak < 0)
            {
                MessageBox.Show("❌ Nilai tidak boleh negatif!", "Validasi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (berasDihasilkan > beratGabah)
            {
                MessageBox.Show($"❌ Beras tidak boleh melebihi {beratGabah:F2} kg!", "Validasi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtBerasDihasilkan.Focus();
                return;
            }

            if (dedak > beratGabah)
            {
                MessageBox.Show($"❌ Dedak tidak boleh melebihi {beratGabah:F2} kg!", "Validasi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDedak.Focus();
                return;
            }

            if (berasDihasilkan + dedak > beratGabah)
            {
                MessageBox.Show($"❌ Total Beras + Dedak ({berasDihasilkan + dedak:F2} kg) melebihi Berat Gabah ({beratGabah:F2} kg)!",
                    "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                string cekQuery = "SELECT COUNT(*) FROM HasilGiling WHERE id_antrian = @id";
                SqlCommand cekCmd = new SqlCommand(cekQuery, conn);
                cekCmd.Parameters.AddWithValue("@id", idAntrian);
                int exists = Convert.ToInt32(cekCmd.ExecuteScalar());

                if (exists > 0)
                {
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

        private void btnBatal_Click(object sender, EventArgs e)
        {
            DialogResult confirm = MessageBox.Show("Yakin ingin membatalkan?",
                "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                this.Close();
            }
        }

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