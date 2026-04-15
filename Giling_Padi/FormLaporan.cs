using System;
using System.Data;
using System.Data.SqlClient;
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

                // ========== LAPORAN ANTRIAN ==========
                string queryAntrian = @"
                    SELECT 
                        nomor_antrian, 
                        nama_petani, 
                        alamat, 
                        no_telepon, 
                        berat_gabah, 
                        CONVERT(VARCHAR, tanggal_antrian, 103) AS tanggal_antrian, 
                        status 
                    FROM Antrian 
                    ORDER BY tanggal_antrian DESC";

                SqlDataAdapter daAntrian = new SqlDataAdapter(queryAntrian, conn);
                DataTable dtAntrian = new DataTable();
                daAntrian.Fill(dtAntrian);
                dgvLaporanAntrian.DataSource = dtAntrian;

                // Atur lebar kolom otomatis
                dgvLaporanAntrian.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

                // ========== LAPORAN HASIL GILING ==========
                string queryHasil = @"
                    SELECT 
                        a.nomor_antrian,
                        h.nama_petani,
                        h.alamat,
                        h.no_telepon,
                        a.berat_gabah,
                        h.beras_dihasilkan,
                        h.dedak,
                        CONVERT(VARCHAR, h.tanggal_proses, 103) AS tanggal_proses
                    FROM HasilGiling h
                    JOIN Antrian a ON h.id_antrian = a.id_antrian
                    ORDER BY h.tanggal_proses DESC";

                SqlDataAdapter daHasil = new SqlDataAdapter(queryHasil, conn);
                DataTable dtHasil = new DataTable();
                daHasil.Fill(dtHasil);
                dgvLaporanHasil.DataSource = dtHasil;

                // Atur lebar kolom otomatis
                dgvLaporanHasil.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

                // ========== SUMMARY MENGGUNAKAN EXECUTESCALAR ==========
                // Total Antrian
                string queryTotalAntrian = "SELECT COUNT(*) FROM Antrian";
                SqlCommand cmdTotalAntrian = new SqlCommand(queryTotalAntrian, conn);
                int totalAntrian = Convert.ToInt32(cmdTotalAntrian.ExecuteScalar());

                // Menunggu
                string queryMenunggu = "SELECT COUNT(*) FROM Antrian WHERE status = 'menunggu'";
                SqlCommand cmdMenunggu = new SqlCommand(queryMenunggu, conn);
                int menunggu = Convert.ToInt32(cmdMenunggu.ExecuteScalar());

                // Sedang Diproses
                string queryDiproses = "SELECT COUNT(*) FROM Antrian WHERE status = 'sedang diproses'";
                SqlCommand cmdDiproses = new SqlCommand(queryDiproses, conn);
                int diproses = Convert.ToInt32(cmdDiproses.ExecuteScalar());

                // Selesai
                string querySelesai = "SELECT COUNT(*) FROM Antrian WHERE status = 'selesai'";
                SqlCommand cmdSelesai = new SqlCommand(querySelesai, conn);
                int selesai = Convert.ToInt32(cmdSelesai.ExecuteScalar());

                // Total Beras
                string queryTotalBeras = "SELECT ISNULL(SUM(beras_dihasilkan), 0) FROM HasilGiling";
                SqlCommand cmdTotalBeras = new SqlCommand(queryTotalBeras, conn);
                decimal totalBeras = Convert.ToDecimal(cmdTotalBeras.ExecuteScalar());

                // Total Dedak
                string queryTotalDedak = "SELECT ISNULL(SUM(dedak), 0) FROM HasilGiling";
                SqlCommand cmdTotalDedak = new SqlCommand(queryTotalDedak, conn);
                decimal totalDedak = Convert.ToDecimal(cmdTotalDedak.ExecuteScalar());

                // Update Labels
                lblTotalAntrian.Text = $"📊 Total Antrian: {totalAntrian}";
                lblMenunggu.Text = $"⏳ Menunggu: {menunggu}";
                lblDiproses.Text = $"⚙ Sedang Diproses: {diproses}";
                lblSelesai.Text = $"✅ Selesai: {selesai}";
                lblTotalBeras.Text = $"🍚 Total Beras: {totalBeras:F2} kg";
                lblTotalDedak.Text = $"🌾 Total Dedak: {totalDedak:F2} kg";

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

        // ========== TOMBOL REFRESH ==========
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadLaporan();
            MessageBox.Show("Laporan berhasil direfresh!", "Info",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // ========== TOMBOL CETAK (Opsional) ==========
        private void btnCetak_Click(object sender, EventArgs e)
        {
            MessageBox.Show("📄 Fitur cetak laporan akan ditambahkan pada pengembangan selanjutnya.",
                "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // ========== TOMBOL TUTUP ==========
        private void btnTutup_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // ========== FORM CLOSING ==========
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