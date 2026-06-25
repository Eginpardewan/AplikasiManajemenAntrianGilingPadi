using System;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Windows.Forms;

namespace AplikasiGilinganPadi
{
    public partial class FormHasilGiling : Form
    {
        private SqlConnection conn;
        private string connectionString;
        private int idAntrian;
        private decimal beratGabah = 0;
        private bool isEditMode = false;

        public FormHasilGiling(string connString, int id)
        {
            InitializeComponent();
            connectionString = connString;
            conn = new SqlConnection(connectionString);
            idAntrian = id;
            LoadDataAntrian();
            CekDataExist();
        }

        // ========== CEK APAKAH DATA SUDAH ADA ==========
        private void CekDataExist()
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                string query = "SELECT beras_dihasilkan, dedak FROM HasilGiling WHERE id_antrian = @id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", idAntrian);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    isEditMode = true;
                    this.Text = "✏️ Edit Hasil Giling";
                    btnSimpan.Text = "✅ Update";

                    decimal beras = Convert.ToDecimal(reader["beras_dihasilkan"]);
                    decimal dedak = Convert.ToDecimal(reader["dedak"]);
                    txtBerasDihasilkan.Text = FormatDecimalWithComma(beras);
                    txtDedak.Text = FormatDecimalWithComma(dedak);

                    UpdateStatusWarna();
                }
                else
                {
                    isEditMode = false;
                    this.Text = "📝 Catat Hasil Giling";
                    btnSimpan.Text = "💾 Simpan";
                }
                reader.Close();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error cek data: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ========== LOAD DATA ANTRIAN (JOIN DENGAN PETANI) ==========
        private void LoadDataAntrian()
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                string query = @"SELECT 
                                    a.nomor_antrian, 
                                    p.nama AS nama_petani, 
                                    p.alamat, 
                                    p.no_telepon, 
                                    a.berat_gabah,
                                    a.status
                                FROM Antrian a
                                INNER JOIN Petani p ON a.id_petani = p.id_petani
                                WHERE a.id_antrian = @id";
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

                    string status = reader["status"].ToString();
                    lblStatusAntrian.Text = $"Status: {status.ToUpper()}";

                    // Warna status
                    if (status == "selesai")
                        lblStatusAntrian.ForeColor = System.Drawing.Color.Green;
                    else if (status == "proses")
                        lblStatusAntrian.ForeColor = System.Drawing.Color.FromArgb(52, 152, 219);
                    else
                        lblStatusAntrian.ForeColor = System.Drawing.Color.FromArgb(241, 196, 15);

                    // Format dengan koma
                    txtBeratGabah.Text = FormatDecimalWithComma(beratGabah);

                    lblInfoMaksimal.Text = $"⚠️ Maksimal total beras + dedak = {FormatDecimalWithComma(beratGabah)} kg";
                    lblInfoBatasBeras.Text = $"Max: {FormatDecimalWithComma(beratGabah)} kg";
                    lblInfoBatasDedak.Text = $"Max: {FormatDecimalWithComma(beratGabah)} kg";

                    // Enable/disable berdasarkan status
                    if (status == "selesai" && !isEditMode)
                    {
                        txtBerasDihasilkan.Enabled = false;
                        txtDedak.Enabled = false;
                        btnSimpan.Enabled = false;
                        lblInfoMaksimal.Text = "⚠️ Antrian sudah selesai, tidak dapat mencatat hasil lagi!";
                        lblInfoMaksimal.ForeColor = System.Drawing.Color.Red;
                    }
                    else
                    {
                        txtBerasDihasilkan.Enabled = true;
                        txtDedak.Enabled = true;
                        btnSimpan.Enabled = true;
                        txtBerasDihasilkan.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Data antrian tidak ditemukan!", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
                reader.Close();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error load data: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ========== CEK DAN BATASI NILAI (DENGAN KOMA) ==========
        private void BatasiNilai(TextBox textBox, decimal batasMaksimal)
        {
            if (string.IsNullOrEmpty(textBox.Text))
                return;

            decimal nilai = ParseDecimalWithComma(textBox.Text);

            if (nilai > batasMaksimal)
            {
                textBox.Text = FormatDecimalWithComma(batasMaksimal);
                textBox.Select(textBox.Text.Length, 0);
                MessageBox.Show($"⚠️ Nilai tidak boleh melebihi {FormatDecimalWithComma(batasMaksimal)} kg!",
                    "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (nilai < 0)
            {
                textBox.Text = "0";
                textBox.Select(textBox.Text.Length, 0);
            }
        }

        // ========== UPDATE STATUS WARNA (DENGAN KOMA) ==========
        private void UpdateStatusWarna()
        {
            // Cek Beras
            if (!string.IsNullOrEmpty(txtBerasDihasilkan.Text))
            {
                decimal beras = ParseDecimalWithComma(txtBerasDihasilkan.Text);
                if (beras > beratGabah)
                {
                    txtBerasDihasilkan.BackColor = System.Drawing.Color.LightCoral;
                    lblStatusBeras.Text = "❌ Melebihi batas!";
                    lblStatusBeras.ForeColor = System.Drawing.Color.Red;
                }
                else if (beras < 0)
                {
                    txtBerasDihasilkan.BackColor = System.Drawing.Color.LightCoral;
                    lblStatusBeras.Text = "❌ Negatif!";
                    lblStatusBeras.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    txtBerasDihasilkan.BackColor = System.Drawing.Color.White;
                    lblStatusBeras.Text = "✅ OK";
                    lblStatusBeras.ForeColor = System.Drawing.Color.Green;
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
                decimal dedak = ParseDecimalWithComma(txtDedak.Text);
                if (dedak > beratGabah)
                {
                    txtDedak.BackColor = System.Drawing.Color.LightCoral;
                    lblStatusDedak.Text = "❌ Melebihi batas!";
                    lblStatusDedak.ForeColor = System.Drawing.Color.Red;
                }
                else if (dedak < 0)
                {
                    txtDedak.BackColor = System.Drawing.Color.LightCoral;
                    lblStatusDedak.Text = "❌ Negatif!";
                    lblStatusDedak.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    txtDedak.BackColor = System.Drawing.Color.White;
                    lblStatusDedak.Text = "✅ OK";
                    lblStatusDedak.ForeColor = System.Drawing.Color.Green;
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
                decimal beras = ParseDecimalWithComma(txtBerasDihasilkan.Text);
                decimal dedak = ParseDecimalWithComma(txtDedak.Text);
                decimal total = beras + dedak;

                if (total > beratGabah)
                {
                    lblStatusTotal.Text = $"❌ Total {FormatDecimalWithComma(total)} kg melebihi {FormatDecimalWithComma(beratGabah)} kg!";
                    lblStatusTotal.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    lblStatusTotal.Text = $"✅ Total {FormatDecimalWithComma(total)} kg dari {FormatDecimalWithComma(beratGabah)} kg gabah";
                    lblStatusTotal.ForeColor = System.Drawing.Color.Green;
                }
            }
            else
            {
                lblStatusTotal.Text = "";
            }

            // Update label Info Maksimal
            if (!string.IsNullOrEmpty(txtBerasDihasilkan.Text) || !string.IsNullOrEmpty(txtDedak.Text))
            {
                decimal beras = ParseDecimalWithComma(txtBerasDihasilkan.Text);
                decimal dedak = ParseDecimalWithComma(txtDedak.Text);
                decimal total = beras + dedak;
                decimal sisa = beratGabah - total;

                if (sisa >= 0)
                {
                    lblSisaGabah.Text = $"📊 Sisa gabah: {FormatDecimalWithComma(sisa)} kg";
                    lblSisaGabah.ForeColor = System.Drawing.Color.FromArgb(39, 174, 96);
                }
                else
                {
                    lblSisaGabah.Text = $"❌ Kelebihan: {FormatDecimalWithComma(Math.Abs(sisa))} kg";
                    lblSisaGabah.ForeColor = System.Drawing.Color.Red;
                }
            }
            else
            {
                lblSisaGabah.Text = $"📊 Sisa gabah: {FormatDecimalWithComma(beratGabah)} kg";
                lblSisaGabah.ForeColor = System.Drawing.Color.FromArgb(52, 152, 219);
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

        // ========== KEYPRESS DENGAN DUKUNGAN KOMA ==========
        private void txtBerasDihasilkan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar))
                return;

            if (!char.IsDigit(e.KeyChar) && e.KeyChar != ',' && e.KeyChar != '.')
            {
                e.Handled = true;
                return;
            }

            TextBox txt = sender as TextBox;
            if ((e.KeyChar == ',' || e.KeyChar == '.') && (txt.Text.Contains(",") || txt.Text.Contains(".")))
            {
                e.Handled = true;
                return;
            }
        }

        private void txtDedak_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar))
                return;

            if (!char.IsDigit(e.KeyChar) && e.KeyChar != ',' && e.KeyChar != '.')
            {
                e.Handled = true;
                return;
            }

            TextBox txt = sender as TextBox;
            if ((e.KeyChar == ',' || e.KeyChar == '.') && (txt.Text.Contains(",") || txt.Text.Contains(".")))
            {
                e.Handled = true;
                return;
            }
        }

        // ========== PASTE (CTRL+V) DENGAN DUKUNGAN KOMA ==========
        private void txtBerasDihasilkan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.V)
            {
                e.SuppressKeyPress = true;
                string clipboardText = Clipboard.GetText();

                decimal nilai = ParseDecimalWithComma(clipboardText);

                if (nilai <= beratGabah && nilai >= 0)
                {
                    txtBerasDihasilkan.Text = FormatDecimalWithComma(nilai);
                }
                else
                {
                    MessageBox.Show($"❌ Nilai tidak valid! Maksimal {FormatDecimalWithComma(beratGabah)} kg",
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

                decimal nilai = ParseDecimalWithComma(clipboardText);

                if (nilai <= beratGabah && nilai >= 0)
                {
                    txtDedak.Text = FormatDecimalWithComma(nilai);
                }
                else
                {
                    MessageBox.Show($"❌ Nilai tidak valid! Maksimal {FormatDecimalWithComma(beratGabah)} kg",
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

            decimal berasDihasilkan = ParseDecimalWithComma(txtBerasDihasilkan.Text);
            decimal dedak = ParseDecimalWithComma(txtDedak.Text);

            if (berasDihasilkan < 0 || dedak < 0)
            {
                MessageBox.Show("❌ Nilai tidak boleh negatif!", "Validasi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (berasDihasilkan == 0 && dedak == 0)
            {
                MessageBox.Show("❌ Beras atau dedak harus diisi dengan nilai lebih dari 0!", "Validasi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (berasDihasilkan > beratGabah)
            {
                MessageBox.Show($"❌ Beras tidak boleh melebihi {FormatDecimalWithComma(beratGabah)} kg!", "Validasi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtBerasDihasilkan.Focus();
                return;
            }

            if (dedak > beratGabah)
            {
                MessageBox.Show($"❌ Dedak tidak boleh melebihi {FormatDecimalWithComma(beratGabah)} kg!", "Validasi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDedak.Focus();
                return;
            }

            if (berasDihasilkan + dedak > beratGabah)
            {
                MessageBox.Show($"❌ Total Beras + Dedak ({FormatDecimalWithComma(berasDihasilkan + dedak)} kg) melebihi Berat Gabah ({FormatDecimalWithComma(beratGabah)} kg)!",
                    "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // ========== KONFIRMASI SEBELUM SIMPAN ==========
            DialogResult confirm = MessageBox.Show(
                $"📊 Ringkasan Hasil Giling:\n\n" +
                $"• Berat Gabah: {FormatDecimalWithComma(beratGabah)} kg\n" +
                $"• Beras: {FormatDecimalWithComma(berasDihasilkan)} kg\n" +
                $"• Dedak: {FormatDecimalWithComma(dedak)} kg\n" +
                $"• Total: {FormatDecimalWithComma(berasDihasilkan + dedak)} kg\n" +
                $"• Sisa: {FormatDecimalWithComma(beratGabah - (berasDihasilkan + dedak))} kg\n\n" +
                $"Apakah data sudah benar?",
                "Konfirmasi Simpan",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm == DialogResult.No)
                return;

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
                    // UPDATE
                    string query = @"UPDATE HasilGiling SET 
                                    beras_dihasilkan = @beras, 
                                    dedak = @dedak,
                                    tanggal_proses = GETDATE()
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
                    // INSERT
                    string query = @"INSERT INTO HasilGiling 
                                    (id_antrian, beras_dihasilkan, dedak, tanggal_proses) 
                                    VALUES 
                                    (@id, @beras, @dedak, GETDATE())";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", idAntrian);
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

        // ========== KONVERSI ANGKA DENGAN DUKUNGAN KOMA ==========
        private decimal ParseDecimalWithComma(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return 0;

            string normalized = input.Trim().Replace(',', '.');

            if (decimal.TryParse(normalized, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal result))
                return result;

            return 0;
        }

        private string FormatDecimalWithComma(decimal value)
        {
            return value.ToString("#,0.##", new CultureInfo("id-ID"));
        }

        // ========== EVENT FORM CLOSING ==========
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