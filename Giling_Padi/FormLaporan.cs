using System;
using System.Data.SqlClient;
using System.Data;
using System.Globalization;
using System.Windows.Forms;

namespace AplikasiGilinganPadi
{
    public partial class FormLaporan : Form
    {
        private SqlConnection conn;
        private string connectionString;

        public FormLaporan(string connString)
        {
            InitializeComponent();
            connectionString = connString;
            conn = new SqlConnection(connectionString);
            LoadLaporan();
        }

        private void LoadLaporan()
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                // ========== LAPORAN ANTRIAN (JOIN DENGAN PETANI) ==========
                string queryAntrian = @"
                    SELECT 
                        a.nomor_antrian, 
                        p.nama AS nama_petani, 
                        p.alamat, 
                        p.no_telepon, 
                        a.berat_gabah, 
                        a.tanggal_giling, 
                        a.status 
                    FROM Antrian a
                    JOIN Petani p ON a.id_petani = p.id_petani
                    ORDER BY a.tanggal_giling DESC";

                SqlDataAdapter daAntrian = new SqlDataAdapter(queryAntrian, conn);
                DataTable dtAntrian = new DataTable();
                daAntrian.Fill(dtAntrian);
                dgvLaporanAntrian.DataSource = dtAntrian;

                // Format kolom berat_gabah di DataGridView dengan koma
                if (dgvLaporanAntrian.Columns["berat_gabah"] != null)
                {
                    dgvLaporanAntrian.Columns["berat_gabah"].DefaultCellStyle.Format = "#,0.##";
                    dgvLaporanAntrian.Columns["berat_gabah"].DefaultCellStyle.FormatProvider = new CultureInfo("id-ID");
                }

                // Atur header kolom
                if (dgvLaporanAntrian.Columns["nomor_antrian"] != null)
                    dgvLaporanAntrian.Columns["nomor_antrian"].HeaderText = "No Antrian";
                if (dgvLaporanAntrian.Columns["nama_petani"] != null)
                    dgvLaporanAntrian.Columns["nama_petani"].HeaderText = "Nama Petani";
                if (dgvLaporanAntrian.Columns["alamat"] != null)
                    dgvLaporanAntrian.Columns["alamat"].HeaderText = "Alamat";
                if (dgvLaporanAntrian.Columns["no_telepon"] != null)
                    dgvLaporanAntrian.Columns["no_telepon"].HeaderText = "No Telepon";
                if (dgvLaporanAntrian.Columns["berat_gabah"] != null)
                    dgvLaporanAntrian.Columns["berat_gabah"].HeaderText = "Berat Gabah (kg)";
                if (dgvLaporanAntrian.Columns["tanggal_giling"] != null)
                    dgvLaporanAntrian.Columns["tanggal_giling"].HeaderText = "Tanggal Giling";
                if (dgvLaporanAntrian.Columns["status"] != null)
                    dgvLaporanAntrian.Columns["status"].HeaderText = "Status";

                dgvLaporanAntrian.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

                // ========== LAPORAN HASIL GILING (JOIN DENGAN ANTRIAN & PETANI) ==========
                string queryHasil = @"
                    SELECT 
                        h.id_hasil,
                        a.nomor_antrian,
                        p.nama AS nama_petani,
                        p.alamat,
                        p.no_telepon,
                        a.berat_gabah,
                        h.beras_dihasilkan,
                        h.dedak,
                        h.tanggal_proses
                    FROM HasilGiling h
                    JOIN Antrian a ON h.id_antrian = a.id_antrian
                    JOIN Petani p ON a.id_petani = p.id_petani
                    ORDER BY h.tanggal_proses DESC";

                SqlDataAdapter daHasil = new SqlDataAdapter(queryHasil, conn);
                DataTable dtHasil = new DataTable();
                daHasil.Fill(dtHasil);
                dgvLaporanHasil.DataSource = dtHasil;

                // Format kolom angka di DataGridView dengan koma
                if (dgvLaporanHasil.Columns["berat_gabah"] != null)
                {
                    dgvLaporanHasil.Columns["berat_gabah"].DefaultCellStyle.Format = "#,0.##";
                    dgvLaporanHasil.Columns["berat_gabah"].DefaultCellStyle.FormatProvider = new CultureInfo("id-ID");
                }
                if (dgvLaporanHasil.Columns["beras_dihasilkan"] != null)
                {
                    dgvLaporanHasil.Columns["beras_dihasilkan"].DefaultCellStyle.Format = "#,0.##";
                    dgvLaporanHasil.Columns["beras_dihasilkan"].DefaultCellStyle.FormatProvider = new CultureInfo("id-ID");
                }
                if (dgvLaporanHasil.Columns["dedak"] != null)
                {
                    dgvLaporanHasil.Columns["dedak"].DefaultCellStyle.Format = "#,0.##";
                    dgvLaporanHasil.Columns["dedak"].DefaultCellStyle.FormatProvider = new CultureInfo("id-ID");
                }

                // Sembunyikan kolom id_hasil
                if (dgvLaporanHasil.Columns["id_hasil"] != null)
                    dgvLaporanHasil.Columns["id_hasil"].Visible = false;

                // Atur header kolom
                if (dgvLaporanHasil.Columns["nomor_antrian"] != null)
                    dgvLaporanHasil.Columns["nomor_antrian"].HeaderText = "No Antrian";
                if (dgvLaporanHasil.Columns["nama_petani"] != null)
                    dgvLaporanHasil.Columns["nama_petani"].HeaderText = "Nama Petani";
                if (dgvLaporanHasil.Columns["alamat"] != null)
                    dgvLaporanHasil.Columns["alamat"].HeaderText = "Alamat";
                if (dgvLaporanHasil.Columns["no_telepon"] != null)
                    dgvLaporanHasil.Columns["no_telepon"].HeaderText = "No Telepon";
                if (dgvLaporanHasil.Columns["berat_gabah"] != null)
                    dgvLaporanHasil.Columns["berat_gabah"].HeaderText = "Berat Gabah (kg)";
                if (dgvLaporanHasil.Columns["beras_dihasilkan"] != null)
                    dgvLaporanHasil.Columns["beras_dihasilkan"].HeaderText = "Beras Dihasilkan (kg)";
                if (dgvLaporanHasil.Columns["dedak"] != null)
                    dgvLaporanHasil.Columns["dedak"].HeaderText = "Dedak (kg)";
                if (dgvLaporanHasil.Columns["tanggal_proses"] != null)
                    dgvLaporanHasil.Columns["tanggal_proses"].HeaderText = "Tanggal Proses";

                dgvLaporanHasil.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

                // ========== SUMMARY (STATISTIK) ==========
                string queryTotalAntrian = "SELECT COUNT(*) FROM Antrian";
                SqlCommand cmdTotalAntrian = new SqlCommand(queryTotalAntrian, conn);
                int totalAntrian = Convert.ToInt32(cmdTotalAntrian.ExecuteScalar());

                string queryMenunggu = "SELECT COUNT(*) FROM Antrian WHERE status = 'menunggu'";
                SqlCommand cmdMenunggu = new SqlCommand(queryMenunggu, conn);
                int menunggu = Convert.ToInt32(cmdMenunggu.ExecuteScalar());

                string queryDiproses = "SELECT COUNT(*) FROM Antrian WHERE status = 'proses'";
                SqlCommand cmdDiproses = new SqlCommand(queryDiproses, conn);
                int diproses = Convert.ToInt32(cmdDiproses.ExecuteScalar());

                string querySelesai = "SELECT COUNT(*) FROM Antrian WHERE status = 'selesai'";
                SqlCommand cmdSelesai = new SqlCommand(querySelesai, conn);
                int selesai = Convert.ToInt32(cmdSelesai.ExecuteScalar());

                string queryTotalGabah = "SELECT ISNULL(SUM(berat_gabah), 0) FROM Antrian";
                SqlCommand cmdTotalGabah = new SqlCommand(queryTotalGabah, conn);
                decimal totalGabah = Convert.ToDecimal(cmdTotalGabah.ExecuteScalar());

                string queryTotalBeras = "SELECT ISNULL(SUM(beras_dihasilkan), 0) FROM HasilGiling";
                SqlCommand cmdTotalBeras = new SqlCommand(queryTotalBeras, conn);
                decimal totalBeras = Convert.ToDecimal(cmdTotalBeras.ExecuteScalar());

                string queryTotalDedak = "SELECT ISNULL(SUM(dedak), 0) FROM HasilGiling";
                SqlCommand cmdTotalDedak = new SqlCommand(queryTotalDedak, conn);
                decimal totalDedak = Convert.ToDecimal(cmdTotalDedak.ExecuteScalar());

                // Update labels dengan format koma
                lblTotalAntrian.Text = $"📊 Total Antrian: {totalAntrian}";
                lblMenunggu.Text = $"⏳ Menunggu: {menunggu}";
                lblDiproses.Text = $"⚙ Diproses: {diproses}";
                lblSelesai.Text = $"✅ Selesai: {selesai}";
                lblTotalGabah.Text = $"🌾 Total Gabah: {FormatDecimalWithComma(totalGabah)} kg";
                lblTotalBeras.Text = $"🍚 Total Beras: {FormatDecimalWithComma(totalBeras)} kg";
                lblTotalDedak.Text = $"📦 Total Dedak: {FormatDecimalWithComma(totalDedak)} kg";

                // Hitung persentase konversi (jika ada gabah)
                if (totalGabah > 0)
                {
                    decimal persentase = (totalBeras / totalGabah) * 100;
                    lblKonversi.Text = $"📈 Konversi Beras/Gabah: {FormatDecimalWithComma(persentase)}%";
                }
                else
                {
                    lblKonversi.Text = $"📈 Konversi Beras/Gabah: 0%";
                }

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saat memuat laporan: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }

        // ========== FORMAT ANGKA DENGAN KOMA ==========
        private string FormatDecimalWithComma(decimal value)
        {
            return value.ToString("#,0.##", new CultureInfo("id-ID"));
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadLaporan();
            MessageBox.Show("Laporan berhasil direfresh!", "Info",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnCetak_Click(object sender, EventArgs e)
        {
            MessageBox.Show("📄 Fitur cetak laporan akan ditambahkan pada pengembangan selanjutnya.",
                "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnTutup_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormLaporan_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (conn != null && conn.State == ConnectionState.Open)
            {
                conn.Close();
                conn.Dispose();
            }
        }
    }
}