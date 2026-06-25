using ExcelDataReader;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace AplikasiGilinganPadi
{
    public partial class FormPetani : Form
    {
        private string connectionString;
        private int idPetani;
        private bool isEdit = false;
        private DataTable dtExcel;

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

            // Set status tombol awal
            btnImpDb.Enabled = false;

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
                // Set default status untuk tambah baru
                cmbStatusImport.SelectedIndex = 0; // "Tambah Baru"
            }

            // Setup DataGridView untuk Excel
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.ReadOnly = true;

            // Setup ComboBox Status Import
            cmbStatusImport.Items.Clear();
            cmbStatusImport.Items.AddRange(new object[] { "Tambah Baru", "Update Data" });
            cmbStatusImport.SelectedIndex = 0;
            cmbStatusImport.Visible = false; // Sembunyikan dulu
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

        // ========== CEK DUPLIKAT DATA ==========
        private bool IsDataExist(string nama, string noTelepon, int excludeId = 0)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"SELECT COUNT(*) FROM Petani 
                                   WHERE (nama = @nama OR no_telepon = @noTelp) 
                                   AND id_petani != @excludeId";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@nama", nama);
                    cmd.Parameters.AddWithValue("@noTelp", noTelepon);
                    cmd.Parameters.AddWithValue("@excludeId", excludeId);
                    int count = (int)cmd.ExecuteScalar();
                    conn.Close();
                    return count > 0;
                }
            }
            catch
            {
                return false;
            }
        }

        // ========== CEK DUPLIKAT NAMA SAJA ==========
        private bool IsNamaExist(string nama, int excludeId = 0)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT COUNT(*) FROM Petani WHERE nama = @nama AND id_petani != @excludeId";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@nama", nama);
                    cmd.Parameters.AddWithValue("@excludeId", excludeId);
                    int count = (int)cmd.ExecuteScalar();
                    conn.Close();
                    return count > 0;
                }
            }
            catch
            {
                return false;
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

            // ========== VALIDASI DUPLIKAT ==========
            if (IsDataExist(txtNama.Text.Trim(), txtNoTelepon.Text.Trim(), isEdit ? idPetani : 0))
            {
                MessageBox.Show("❌ Nama atau No Telepon sudah terdaftar!\n\nGunakan data yang berbeda.",
                    "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                MessageBox.Show("Error: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error menyimpan data: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ========== TOMBOL IMPORT EXCEL ==========
        private void btnImportExcel_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog { Filter = "Excel Workbook|*.xlsx;*.xls" })
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string filePath = openFileDialog.FileName;

                        // Register encoding provider untuk ExcelDataReader
                        System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

                        using (var stream = File.Open(filePath, FileMode.Open, FileAccess.Read))
                        {
                            using (var reader = ExcelReaderFactory.CreateReader(stream))
                            {
                                var result = reader.AsDataSet(new ExcelDataSetConfiguration()
                                {
                                    ConfigureDataTable = (_) => new ExcelDataTableConfiguration()
                                    {
                                        UseHeaderRow = true  // Baris pertama sebagai header
                                    }
                                });

                                dtExcel = result.Tables[0];

                                // Cek apakah kolom sesuai
                                if (!dtExcel.Columns.Contains("Nama") ||
                                    !dtExcel.Columns.Contains("Alamat") ||
                                    !dtExcel.Columns.Contains("No_Telepon"))
                                {
                                    MessageBox.Show("Format Excel tidak sesuai!\n" +
                                        "Harus memiliki kolom: Nama, Alamat, No_Telepon",
                                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }

                                // Tampilkan data di DataGridView
                                dataGridView1.DataSource = dtExcel;
                                dataGridView1.Enabled = true;
                                btnImpDb.Enabled = true;
                                cmbStatusImport.Visible = true;

                                // Nonaktifkan tombol lain
                                btnSimpan.Enabled = false;
                                btnBatal.Enabled = false;
                                btnTestInjection.Enabled = false;
                                btnResetData.Enabled = false;

                                lblStatus.Text = $"📊 {dtExcel.Rows.Count} data siap diimport ke database";
                                lblStatus.ForeColor = System.Drawing.Color.Blue;

                                // Tampilkan opsi status import
                                cmbStatusImport.Visible = true;
                                cmbStatusImport.SelectedIndex = 0;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Gagal import Excel: " + ex.Message, "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        // ========== TOMBOL IMPORT KE DATABASE (DIPERBAIKI) ==========
        private void btnImpDb_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtExcel == null || dtExcel.Rows.Count == 0)
                {
                    MessageBox.Show("Tidak ada data untuk diimport.", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DialogResult confirm = MessageBox.Show(
                    $"Yakin ingin mengimport {dtExcel.Rows.Count} data petani ke database?\n\n" +
                    $"Mode: {cmbStatusImport.SelectedItem}",
                    "Konfirmasi Import",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (confirm != DialogResult.Yes)
                    return;

                int sukses = 0;
                int gagal = 0;
                int update = 0;

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    foreach (DataRow row in dtExcel.Rows)
                    {
                        try
                        {
                            string nama = row["Nama"].ToString().Trim();
                            string alamat = row["Alamat"].ToString().Trim();
                            string noTelp = row["No_Telepon"].ToString().Trim();

                            if (string.IsNullOrEmpty(nama) || string.IsNullOrEmpty(alamat) || string.IsNullOrEmpty(noTelp))
                            {
                                gagal++;
                                continue;
                            }

                            // Validasi No Telepon
                            if (!Regex.IsMatch(noTelp, @"^[0-9]{10,15}$"))
                            {
                                gagal++;
                                continue;
                            }

                            // Cek apakah data sudah ada (berdasarkan nama)
                            string checkQuery = "SELECT COUNT(*) FROM Petani WHERE nama = @nama";
                            using (SqlCommand checkCmd = new SqlCommand(checkQuery, conn))
                            {
                                checkCmd.Parameters.AddWithValue("@nama", nama);
                                int exists = (int)checkCmd.ExecuteScalar();

                                if (exists > 0 && cmbStatusImport.SelectedIndex == 0) // Tambah Baru
                                {
                                    gagal++;
                                    continue;
                                }
                                else if (exists > 0 && cmbStatusImport.SelectedIndex == 1) // Update Data
                                {
                                    // UPDATE
                                    string updateQuery = @"UPDATE Petani 
                                                          SET alamat = @alamat, no_telepon = @noTelp 
                                                          WHERE nama = @nama";
                                    using (SqlCommand updateCmd = new SqlCommand(updateQuery, conn))
                                    {
                                        updateCmd.Parameters.AddWithValue("@nama", nama);
                                        updateCmd.Parameters.AddWithValue("@alamat", alamat);
                                        updateCmd.Parameters.AddWithValue("@noTelp", noTelp);
                                        updateCmd.ExecuteNonQuery();
                                        update++;
                                    }
                                }
                                else // Insert baru
                                {
                                    string insertQuery = "INSERT INTO Petani (nama, alamat, no_telepon) VALUES (@nama, @alamat, @noTelp)";
                                    using (SqlCommand insertCmd = new SqlCommand(insertQuery, conn))
                                    {
                                        insertCmd.Parameters.AddWithValue("@nama", nama);
                                        insertCmd.Parameters.AddWithValue("@alamat", alamat);
                                        insertCmd.Parameters.AddWithValue("@noTelp", noTelp);
                                        insertCmd.ExecuteNonQuery();
                                        sukses++;
                                    }
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            gagal++;
                            // Log error (bisa ditambahkan ke LogError)
                        }
                    }
                }

                MessageBox.Show($"✅ Berhasil mengimport data petani!\n\n" +
                    $"📝 Data baru: {sukses}\n" +
                    $"🔄 Data diupdate: {update}\n" +
                    $"❌ Gagal: {gagal} data",
                    "Hasil Import", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // ========== PERBAIKAN: RESET FORM TANPA MENUTUP ==========
                btnImpDb.Enabled = false;
                btnSimpan.Enabled = true;
                btnBatal.Enabled = true;
                btnTestInjection.Enabled = true;
                btnResetData.Enabled = true;
                dataGridView1.DataSource = null;
                dtExcel = null;
                cmbStatusImport.Visible = false;

                lblStatus.Text = "✅ Data berhasil diimport!";
                lblStatus.ForeColor = System.Drawing.Color.Green;

                // ========== HAPUS this.Close() AGAR FORM TIDAK TERTUTUP ==========
                // this.DialogResult = DialogResult.OK;
                // this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ========== EXPORT DATA KE EXCEL ==========
        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            try
            {
                // Ambil data petani dari database
                DataTable dtPetani = new DataTable();
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT id_petani, nama, alamat, no_telepon, created_at FROM Petani ORDER BY nama";
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    da.Fill(dtPetani);
                    conn.Close();
                }

                if (dtPetani.Rows.Count == 0)
                {
                    MessageBox.Show("Tidak ada data petani untuk diexport!", "Info",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "CSV Files (*.csv)|*.csv|Excel Files (*.xlsx)|*.xlsx";
                saveFileDialog.FileName = $"Data_Petani_{DateTime.Now:yyyyMMdd_HHmmss}";
                saveFileDialog.DefaultExt = "csv";
                saveFileDialog.AddExtension = true;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    if (saveFileDialog.FileName.EndsWith(".csv"))
                    {
                        // Export ke CSV
                        using (StreamWriter sw = new StreamWriter(saveFileDialog.FileName, false, Encoding.UTF8))
                        {
                            // Header
                            sw.WriteLine("ID,Nama,Alamat,No Telepon,Tanggal Daftar");

                            // Data
                            foreach (DataRow row in dtPetani.Rows)
                            {
                                sw.WriteLine($"{row["id_petani"]},{row["nama"]},{row["alamat"]},{row["no_telepon"]},{row["created_at"]}");
                            }
                        }
                    }
                    else
                    {
                        // Export ke Excel (menggunakan CSV sederhana)
                        using (StreamWriter sw = new StreamWriter(saveFileDialog.FileName, false, Encoding.UTF8))
                        {
                            // Header
                            sw.WriteLine("ID,Nama,Alamat,No Telepon,Tanggal Daftar");

                            // Data
                            foreach (DataRow row in dtPetani.Rows)
                            {
                                sw.WriteLine($"{row["id_petani"]},\"{row["nama"]}\",\"{row["alamat"]}\",{row["no_telepon"]},{row["created_at"]}");
                            }
                        }
                    }

                    MessageBox.Show($"✅ Data petani berhasil diexport ke:\n{saveFileDialog.FileName}",
                        "Sukses Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error export data: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ========== TOMBOL BATAL ==========
        private void btnBatal_Click(object sender, EventArgs e)
        {
            // Cek apakah dalam mode import Excel
            if (dtExcel != null && dtExcel.Rows.Count > 0)
            {
                DialogResult confirm = MessageBox.Show(
                    "Data Excel belum diimport ke database.\n\nYakin ingin membatalkan dan keluar?",
                    "Konfirmasi Batal",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (confirm == DialogResult.Yes)
                {
                    // Reset form
                    btnImpDb.Enabled = false;
                    btnSimpan.Enabled = true;
                    btnBatal.Enabled = true;
                    btnTestInjection.Enabled = true;
                    btnResetData.Enabled = true;
                    dataGridView1.DataSource = null;
                    dtExcel = null;
                    cmbStatusImport.Visible = false;
                    lblStatus.Text = "";
                    this.Close();
                }
            }
            else
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
}