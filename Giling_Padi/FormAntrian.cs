using System;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
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
        private int idPetaniTerpilih = 0;
        private DataTable dtPetani;

        public FormAntrian(string connString, int id)
        {
            InitializeComponent();
            connectionString = connString;
            conn = new SqlConnection(connectionString);
            idAntrian = id;
            isEdit = (id > 0);

            LoadPetaniToComboBox();

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
                dtpTanggal.Value = DateTime.Today;
                minDate = DateTime.Today;
                maxDate = DateTime.Today.AddDays(7);
                cmbStatus.SelectedIndex = 0; // Default "menunggu"
            }
        }

        // ========== LOAD PETANI KE COMBOBOX ==========
        private void LoadPetaniToComboBox()
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                string query = "SELECT id_petani, nama, alamat, no_telepon FROM Petani ORDER BY nama";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                dtPetani = new DataTable();
                da.Fill(dtPetani);

                cmbNamaPetani.DataSource = dtPetani;
                cmbNamaPetani.DisplayMember = "nama";
                cmbNamaPetani.ValueMember = "id_petani";
                cmbNamaPetani.SelectedIndex = -1;

                cmbNamaPetani.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                cmbNamaPetani.AutoCompleteSource = AutoCompleteSource.ListItems;

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading petani: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ========== EVENT SELECTION CHANGE COMBOBOX ==========
        private void cmbNamaPetani_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbNamaPetani.SelectedValue != null && cmbNamaPetani.SelectedValue is int)
            {
                idPetaniTerpilih = (int)cmbNamaPetani.SelectedValue;

                foreach (DataRow row in dtPetani.Rows)
                {
                    if (Convert.ToInt32(row["id_petani"]) == idPetaniTerpilih)
                    {
                        txtAlamat.Text = row["alamat"].ToString();
                        txtNoTelepon.Text = row["no_telepon"].ToString();
                        break;
                    }
                }
            }
        }

        // ========== GENERATE NOMOR ANTRIAN ==========
        private void GenerateNomorAntrian()
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                string query = "SELECT ISNULL(MAX(nomor_antrian), 0) + 1 FROM Antrian";
                SqlCommand cmd = new SqlCommand(query, conn);
                int nomor = Convert.ToInt32(cmd.ExecuteScalar());
                txtNomorAntrian.Text = nomor.ToString();

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error generate nomor: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ========== CEK DUPLIKAT NOMOR ANTRIAN ==========
        private bool IsNomorAntrianExist(int nomor, int excludeId = 0)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                string query = "SELECT COUNT(*) FROM Antrian WHERE nomor_antrian = @nomor AND id_antrian != @excludeId";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@nomor", nomor);
                cmd.Parameters.AddWithValue("@excludeId", excludeId);
                int count = (int)cmd.ExecuteScalar();
                conn.Close();
                return count > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error cek duplikat: " + ex.Message);
                return false;
            }
        }

        // ========== CEK PETANI SUDAH MEMILIKI ANTRIAN AKTIF ==========
        private bool IsPetaniSudahAntri(int idPetani, int excludeId = 0)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                string query = @"SELECT COUNT(*) FROM Antrian 
                                WHERE id_petani = @idPetani 
                                AND status IN ('menunggu', 'proses')
                                AND id_antrian != @excludeId";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@idPetani", idPetani);
                cmd.Parameters.AddWithValue("@excludeId", excludeId);
                int count = (int)cmd.ExecuteScalar();
                conn.Close();
                return count > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error cek petani antri: " + ex.Message);
                return false;
            }
        }

        // ========== LOAD DATA UNTUK EDIT ==========
        private void LoadData()
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                string query = @"SELECT a.id_antrian, a.id_petani, a.nomor_antrian, 
                                        a.berat_gabah, a.tanggal_giling, a.status,
                                        p.nama, p.alamat, p.no_telepon
                                 FROM Antrian a
                                 JOIN Petani p ON a.id_petani = p.id_petani
                                 WHERE a.id_antrian = @id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", idAntrian);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    idPetaniTerpilih = reader.GetInt32(1);
                    txtNomorAntrian.Text = reader["nomor_antrian"].ToString();

                    // Format angka dengan koma
                    decimal beratGabah = Convert.ToDecimal(reader["berat_gabah"]);
                    txtBeratGabah.Text = FormatDecimalWithComma(beratGabah);

                    tanggalAwal = Convert.ToDateTime(reader["tanggal_giling"]);
                    dtpTanggal.Value = tanggalAwal;
                    cmbStatus.SelectedItem = reader["status"].ToString();

                    // PERBAIKAN: Coba set SelectedValue, jika gagal gunakan loop
                    try
                    {
                        cmbNamaPetani.SelectedValue = idPetaniTerpilih;
                    }
                    catch
                    {
                        // Fallback: cari secara manual
                        foreach (DataRow row in dtPetani.Rows)
                        {
                            if (Convert.ToInt32(row["id_petani"]) == idPetaniTerpilih)
                            {
                                cmbNamaPetani.Text = row["nama"].ToString();
                                break;
                            }
                        }
                    }

                    minDate = tanggalAwal;
                    maxDate = tanggalAwal.AddDays(7);
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

        // ========== VALIDASI TANGGAL ==========
        private bool ValidateTanggal()
        {
            DateTime selectedDate = dtpTanggal.Value.Date;

            if (!isEdit)
            {
                if (selectedDate < minDate)
                {
                    MessageBox.Show($"❌ Tanggal tidak boleh kurang dari {minDate:dd/MM/yyyy}!", "Validasi",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dtpTanggal.Value = minDate;
                    return false;
                }
                if (selectedDate > maxDate)
                {
                    MessageBox.Show($"❌ Tanggal tidak boleh lebih dari {maxDate:dd/MM/yyyy}!", "Validasi",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dtpTanggal.Value = maxDate;
                    return false;
                }
            }
            else
            {
                if (selectedDate < minDate)
                {
                    MessageBox.Show($"❌ Tanggal tidak boleh kurang dari {minDate:dd/MM/yyyy}!", "Validasi",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dtpTanggal.Value = minDate;
                    return false;
                }
                if (selectedDate > maxDate)
                {
                    MessageBox.Show($"❌ Tanggal tidak boleh lebih dari {maxDate:dd/MM/yyyy}!", "Validasi",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dtpTanggal.Value = maxDate;
                    return false;
                }
            }
            return true;
        }

        // ========== TOMBOL SIMPAN ==========
        private void btnSimpan_Click(object sender, EventArgs e)
        {
            // ========== VALIDASI PETANI ==========
            if (cmbNamaPetani.SelectedIndex == -1)
            {
                MessageBox.Show("❌ Pilih Nama Petani terlebih dahulu!", "Validasi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbNamaPetani.Focus();
                return;
            }

            // ========== VALIDASI BERAT GABAH ==========
            if (string.IsNullOrWhiteSpace(txtBeratGabah.Text))
            {
                MessageBox.Show("❌ Berat Gabah harus diisi!", "Validasi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtBeratGabah.Focus();
                return;
            }

            // Parse angka dengan dukungan koma
            decimal beratGabah = ParseDecimalWithComma(txtBeratGabah.Text);

            if (beratGabah <= 0)
            {
                MessageBox.Show("❌ Berat Gabah harus berupa angka positif!\nContoh: 100,5 atau 100.5", "Validasi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtBeratGabah.Focus();
                return;
            }

            // ========== VALIDASI STATUS ==========
            if (cmbStatus.SelectedItem == null)
            {
                MessageBox.Show("❌ Pilih Status Antrian terlebih dahulu!", "Validasi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbStatus.Focus();
                return;
            }

            // ========== VALIDASI TANGGAL ==========
            if (!ValidateTanggal())
                return;

            // ========== VALIDASI DUPLIKAT NOMOR ANTRIAN ==========
            int nomorAntrian = Convert.ToInt32(txtNomorAntrian.Text);
            if (IsNomorAntrianExist(nomorAntrian, isEdit ? idAntrian : 0))
            {
                MessageBox.Show($"❌ Nomor Antrian {nomorAntrian} sudah digunakan!\n\nSilakan refresh untuk mendapatkan nomor baru.",
                    "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                GenerateNomorAntrian();
                return;
            }

            // ========== VALIDASI PETANI SUDAH ANTRI (HANYA UNTUK TAMBAH BARU) ==========
            if (!isEdit && IsPetaniSudahAntri(idPetaniTerpilih, 0))
            {
                string namaPetani = cmbNamaPetani.Text;
                DialogResult confirm = MessageBox.Show(
                    $"⚠️ Petani '{namaPetani}' masih memiliki antrian aktif (menunggu/proses).\n\n" +
                    "Apakah Anda tetap ingin menambahkan antrian baru untuk petani ini?",
                    "Konfirmasi Tambah Antrian",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (confirm == DialogResult.No)
                    return;
            }

            // ========== SIMPAN DATA ==========
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                if (isEdit)
                {
                    // CEK STATUS SEBELUM DIUPDATE UNTUK DETEKSI PERUBAHAN
                    string statusLama = "";
                    string cekStatusQuery = "SELECT status FROM Antrian WHERE id_antrian = @id";
                    SqlCommand cekStatusCmd = new SqlCommand(cekStatusQuery, conn);
                    cekStatusCmd.Parameters.AddWithValue("@id", idAntrian);
                    statusLama = cekStatusCmd.ExecuteScalar()?.ToString() ?? "";

                    string query = @"UPDATE Antrian 
                                    SET id_petani = @id_petani, 
                                        berat_gabah = @berat, 
                                        tanggal_giling = @tanggal, 
                                        status = @status 
                                    WHERE id_antrian = @id";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id_petani", idPetaniTerpilih);
                    cmd.Parameters.AddWithValue("@berat", beratGabah);
                    cmd.Parameters.AddWithValue("@tanggal", dtpTanggal.Value);
                    cmd.Parameters.AddWithValue("@status", cmbStatus.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@id", idAntrian);
                    cmd.ExecuteNonQuery();

                    // CEK APAKAH STATUS BERUBAH MENJADI SELESAI
                    string statusBaru = cmbStatus.SelectedItem.ToString();
                    if (statusBaru == "selesai" && statusLama != "selesai")
                    {
                        // CEK APAKAH SUDAH ADA HASIL GILING
                        string cekHasilQuery = "SELECT COUNT(*) FROM HasilGiling WHERE id_antrian = @id";
                        SqlCommand cekHasilCmd = new SqlCommand(cekHasilQuery, conn);
                        cekHasilCmd.Parameters.AddWithValue("@id", idAntrian);
                        int sudahAdaHasil = Convert.ToInt32(cekHasilCmd.ExecuteScalar());

                        if (sudahAdaHasil == 0)
                        {
                            conn.Close();
                            DialogResult hasil = MessageBox.Show(
                                "Status antrian telah diubah menjadi SELESAI.\n\nApakah ingin mencatat hasil giling sekarang?",
                                "Catat Hasil Giling",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question);

                            if (hasil == DialogResult.Yes)
                            {
                                FormHasilGiling formHasil = new FormHasilGiling(connectionString, idAntrian);
                                formHasil.ShowDialog();
                            }
                            MessageBox.Show("✅ Data antrian berhasil diupdate!", "Sukses",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                            return;
                        }
                    }

                    conn.Close();
                    MessageBox.Show("✅ Data antrian berhasil diupdate!", "Sukses",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    string query = @"INSERT INTO Antrian 
                                    (id_petani, nomor_antrian, berat_gabah, tanggal_giling, status) 
                                    VALUES (@id_petani, @nomor, @berat, @tanggal, @status)";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id_petani", idPetaniTerpilih);
                    cmd.Parameters.AddWithValue("@nomor", nomorAntrian);
                    cmd.Parameters.AddWithValue("@berat", beratGabah);
                    cmd.Parameters.AddWithValue("@tanggal", dtpTanggal.Value);
                    cmd.Parameters.AddWithValue("@status", cmbStatus.SelectedItem.ToString());
                    cmd.ExecuteNonQuery();
                    conn.Close();
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

        // ========== TOMBOL BATAL ==========
        private void btnBatal_Click(object sender, EventArgs e)
        {
            DialogResult confirm = MessageBox.Show("Yakin ingin membatalkan?",
                "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
                this.Close();
        }

        // ========== TOMBOL REFRESH NOMOR ANTRIAN ==========
        private void btnRefreshNomor_Click(object sender, EventArgs e)
        {
            GenerateNomorAntrian();
            MessageBox.Show("✅ Nomor antrian telah direfresh!", "Info",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // ========== KONVERSI ANGKA DENGAN DUKUNGAN KOMA ==========
        private decimal ParseDecimalWithComma(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return 0;

            // Ganti koma dengan titik untuk parsing
            string normalized = input.Trim().Replace(',', '.');

            if (decimal.TryParse(normalized, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal result))
                return result;

            return 0;
        }

        private string FormatDecimalWithComma(decimal value)
        {
            // Format dengan koma sebagai pemisah desimal
            return value.ToString("#,0.##", new CultureInfo("id-ID"));
        }

        // ========== KEYPRESS UNTUK BERAT (DENGAN KOMA) ==========
        private void txtBeratGabah_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Izinkan backspace, delete, enter, tab
            if (char.IsControl(e.KeyChar))
                return;

            // Izinkan angka, koma, dan titik
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != ',' && e.KeyChar != '.')
            {
                e.Handled = true;
                return;
            }

            // Cegah lebih dari satu koma atau titik
            TextBox txt = sender as TextBox;
            if ((e.KeyChar == ',' || e.KeyChar == '.') && (txt.Text.Contains(",") || txt.Text.Contains(".")))
            {
                e.Handled = true;
                return;
            }
        }

        // ========== EVENT FORM CLOSING ==========
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