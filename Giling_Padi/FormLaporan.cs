using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace AplikasiGilinganPadi
{
    public partial class FormLaporan : Form
    {
        private SqlConnection conn;
        private string connectionString;  // TAMBAHKAN

        // ========== PERBAIKAN CONSTRUCTOR ==========
        public FormLaporan(string connString)
        {
            InitializeComponent();
            connectionString = connString;  // Simpan connection string
            conn = new SqlConnection(connectionString);  // Buat koneksi baru
            LoadLaporan();
        }

        private void LoadLaporan()
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                // Laporan Antrian
                string queryAntrian = @"
                    SELECT 
                        nomor_antrian, 
                        nama_petani, 
                        alamat, 
                        no_telepon, 
                        berat_gabah, 
                        tanggal_antrian, 
                        status 
                    FROM Antrian 
                    ORDER BY tanggal_antrian DESC";

                SqlDataAdapter daAntrian = new SqlDataAdapter(queryAntrian, conn);
                DataTable dtAntrian = new DataTable();
                daAntrian.Fill(dtAntrian);
                dgvLaporanAntrian.DataSource = dtAntrian;

                // Atur lebar kolom otomatis
                dgvLaporanAntrian.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

                // Laporan Hasil Giling
                string queryHasil = @"
                    SELECT 
                        h.id_hasil,
                        a.nomor_antrian,
                        h.nama_petani,
                        h.alamat,
                        h.no_telepon,
                        a.berat_gabah,
                        h.beras_dihasilkan,
                        h.dedak,
                        h.tanggal_proses
                    FROM HasilGiling h
                    JOIN Antrian a ON h.id_antrian = a.id_antrian
                    ORDER BY h.tanggal_proses DESC";

                SqlDataAdapter daHasil = new SqlDataAdapter(queryHasil, conn);
                DataTable dtHasil = new DataTable();
                daHasil.Fill(dtHasil);
                dgvLaporanHasil.DataSource = dtHasil;

                // Atur lebar kolom otomatis
                dgvLaporanHasil.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

                // Sembunyikan kolom id_hasil
                if (dgvLaporanHasil.Columns["id_hasil"] != null)
                    dgvLaporanHasil.Columns["id_hasil"].Visible = false;

                // Summary menggunakan ExecuteScalar (lebih efisien)
                string queryTotalAntrian = "SELECT COUNT(*) FROM Antrian";
                SqlCommand cmdTotalAntrian = new SqlCommand(queryTotalAntrian, conn);
                int totalAntrian = Convert.ToInt32(cmdTotalAntrian.ExecuteScalar());

                string queryMenunggu = "SELECT COUNT(*) FROM Antrian WHERE status = 'menunggu'";
                SqlCommand cmdMenunggu = new SqlCommand(queryMenunggu, conn);
                int menunggu = Convert.ToInt32(cmdMenunggu.ExecuteScalar());

                string queryDiproses = "SELECT COUNT(*) FROM Antrian WHERE status = 'sedang diproses'";
                SqlCommand cmdDiproses = new SqlCommand(queryDiproses, conn);
                int diproses = Convert.ToInt32(cmdDiproses.ExecuteScalar());

                string querySelesai = "SELECT COUNT(*) FROM Antrian WHERE status = 'selesai'";
                SqlCommand cmdSelesai = new SqlCommand(querySelesai, conn);
                int selesai = Convert.ToInt32(cmdSelesai.ExecuteScalar());

                string queryTotalBeras = "SELECT ISNULL(SUM(beras_dihasilkan), 0) FROM HasilGiling";
                SqlCommand cmdTotalBeras = new SqlCommand(queryTotalBeras, conn);
                decimal totalBeras = Convert.ToDecimal(cmdTotalBeras.ExecuteScalar());

                string queryTotalDedak = "SELECT ISNULL(SUM(dedak), 0) FROM HasilGiling";
                SqlCommand cmdTotalDedak = new SqlCommand(queryTotalDedak, conn);
                decimal totalDedak = Convert.ToDecimal(cmdTotalDedak.ExecuteScalar());

                // Update labels
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