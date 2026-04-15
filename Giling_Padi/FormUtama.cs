using System;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace AplikasiGilinganPadi
{
    public partial class FormUtama : Form
    {
        // ========== KONEKSI DATABASE ==========
        private SqlConnection conn;
        private string connectionString;

        private int idAdmin;
        private string namaAdmin;

        public FormUtama(int idAdmin, string namaAdmin, string connString)
        {
            InitializeComponent();
            this.idAdmin = idAdmin;
            this.namaAdmin = namaAdmin;
            this.connectionString = connString;

            // Inisialisasi koneksi database
            conn = new SqlConnection(connectionString);

            // BUAT LOGO BENTUK BULAT DENGAN BORDER/SCOPE (SAMA SEPERTI LOGIN)
            MakeLogoCircular();

            // Set welcome message
            SetWelcomeMessage(namaAdmin);

            // Setup DataGridView
            SetupDataGridView();

            // Load data langsung
            LoadDataAntrian();

            // Aktifkan semua tombol
            EnableAllButtons();

            // Sembunyikan submenu antrian di awal
            if (panelSubmenuAntrian != null)
                panelSubmenuAntrian.Visible = false;
        }

        // ========== MEMBUAT LOGO BENTUK BULAT DENGAN BORDER/SCOPE ==========
        private void MakeLogoCircular()
        {
            try
            {
                // Ambil gambar dari Resources (sama seperti di FormLogin)
                Image originalImage = Giling_Padi.Properties.Resources.logo;

                if (originalImage != null)
                {
                    // Buat gambar baru dengan border lingkaran
                    Bitmap bmp = new Bitmap(pictureBoxLogo.Width, pictureBoxLogo.Height);

                    using (Graphics g = Graphics.FromImage(bmp))
                    {
                        g.SmoothingMode = SmoothingMode.AntiAlias;
                        g.Clear(Color.Transparent);

                        // Buat lingkaran clipping (biar gambar jadi bulat)
                        GraphicsPath clipPath = new GraphicsPath();
                        clipPath.AddEllipse(3, 3, pictureBoxLogo.Width - 6, pictureBoxLogo.Height - 6);
                        g.SetClip(clipPath);

                        // Gambar image di dalam lingkaran
                        g.DrawImage(originalImage, 0, 0, pictureBoxLogo.Width, pictureBoxLogo.Height);

                        // Reset clipping
                        g.ResetClip();

                        // Border putih tebal (scope dalam)
                        using (Pen pen = new Pen(Color.White, 3))
                        {
                            g.DrawEllipse(pen, 3, 3, pictureBoxLogo.Width - 6, pictureBoxLogo.Height - 6);
                        }

                        // Border luar warna kuning (scope luar)
                        using (Pen pen = new Pen(Color.FromArgb(241, 196, 15), 2))
                        {
                            g.DrawEllipse(pen, 1, 1, pictureBoxLogo.Width - 2, pictureBoxLogo.Height - 2);
                        }
                    }

                    pictureBoxLogo.Image = bmp;
                }
                else
                {
                    CreateDefaultLogo();
                }
            }
            catch
            {
                CreateDefaultLogo();
            }

            pictureBoxLogo.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxLogo.BackColor = Color.Transparent;
        }

        // ========== LOGO DEFAULT (JIKA GAMBAR TIDAK ADA) ==========
        private void CreateDefaultLogo()
        {
            Bitmap bmp = new Bitmap(pictureBoxLogo.Width, pictureBoxLogo.Height);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.Clear(Color.Transparent);

                // Lingkaran background
                using (SolidBrush brush = new SolidBrush(Color.FromArgb(241, 196, 15)))
                {
                    g.FillEllipse(brush, 3, 3, pictureBoxLogo.Width - 6, pictureBoxLogo.Height - 6);
                }

                // Teks "🌾" di tengah
                using (Font font = new Font("Segoe UI", pictureBoxLogo.Width / 2, FontStyle.Bold))
                using (SolidBrush brush = new SolidBrush(Color.White))
                {
                    SizeF textSize = g.MeasureString("🌾", font);
                    float x = (pictureBoxLogo.Width - textSize.Width) / 2;
                    float y = (pictureBoxLogo.Height - textSize.Height) / 2;
                    g.DrawString("🌾", font, brush, x, y);
                }

                // Border putih
                using (Pen pen = new Pen(Color.White, 3))
                {
                    g.DrawEllipse(pen, 3, 3, pictureBoxLogo.Width - 6, pictureBoxLogo.Height - 6);
                }

                // Border luar kuning
                using (Pen pen = new Pen(Color.FromArgb(241, 196, 15), 2))
                {
                    g.DrawEllipse(pen, 1, 1, pictureBoxLogo.Width - 2, pictureBoxLogo.Height - 2);
                }
            }
            pictureBoxLogo.Image = bmp;
        }

        // ========== AKTIFKAN SEMUA TOMBOL ==========
        private void EnableAllButtons()
        {
            btnKelolaAntrian.Enabled = true;
            btnProsesGiling.Enabled = true;
            btnCatatHasil.Enabled = true;
            btnLaporan.Enabled = true;
            btnRefresh.Enabled = true;
            btnSearch.Enabled = true;
            txtSearch.Enabled = true;

            btnTambahAntrian.Enabled = true;
            btnEditAntrian.Enabled = true;
            btnHapusAntrian.Enabled = true;
        }

        // ========== TOGGLE SUBMENU KELOLA ANTRIAN ==========
        private void btnKelolaAntrian_Click(object sender, EventArgs e)
        {
            if (panelSubmenuAntrian != null)
            {
                panelSubmenuAntrian.Visible = !panelSubmenuAntrian.Visible;
                btnKelolaAntrian.BackColor = panelSubmenuAntrian.Visible ?
                    System.Drawing.Color.FromArgb(52, 152, 219) :
                    System.Drawing.Color.FromArgb(41, 128, 185);
            }
        }

        // ========== SETUP DATA GRID VIEW ==========
        private void SetupDataGridView()
        {
            dgvAntrian.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAntrian.MultiSelect = false;
            dgvAntrian.ReadOnly = true;
            dgvAntrian.AllowUserToAddRows = false;
            dgvAntrian.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvAntrian.RowHeadersVisible = false;
        }

        // ========== LOAD DATA ANTRIAN ==========
        private void LoadDataAntrian()
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                string query = @"SELECT 
                                    id_antrian, 
                                    nomor_antrian, 
                                    nama_petani, 
                                    alamat, 
                                    no_telepon, 
                                    berat_gabah, 
                                    tanggal_antrian, 
                                    status 
                                FROM Antrian 
                                ORDER BY nomor_antrian";

                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvAntrian.DataSource = dt;

                if (dgvAntrian.Columns["id_antrian"] != null)
                    dgvAntrian.Columns["id_antrian"].Visible = false;

                if (dgvAntrian.Columns["nomor_antrian"] != null)
                    dgvAntrian.Columns["nomor_antrian"].HeaderText = "No Antrian";
                if (dgvAntrian.Columns["nama_petani"] != null)
                    dgvAntrian.Columns["nama_petani"].HeaderText = "Nama Petani";
                if (dgvAntrian.Columns["alamat"] != null)
                    dgvAntrian.Columns["alamat"].HeaderText = "Alamat";
                if (dgvAntrian.Columns["no_telepon"] != null)
                    dgvAntrian.Columns["no_telepon"].HeaderText = "No Telepon";
                if (dgvAntrian.Columns["berat_gabah"] != null)
                    dgvAntrian.Columns["berat_gabah"].HeaderText = "Berat Gabah (kg)";
                if (dgvAntrian.Columns["tanggal_antrian"] != null)
                    dgvAntrian.Columns["tanggal_antrian"].HeaderText = "Tanggal Antrian";
                if (dgvAntrian.Columns["status"] != null)
                    dgvAntrian.Columns["status"].HeaderText = "Status";

                UpdateTotalRecord();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saat memuat data: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ========== UPDATE TOTAL RECORD ==========
        private void UpdateTotalRecord()
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                string queryTotal = "SELECT COUNT(*) FROM Antrian";
                SqlCommand cmdTotal = new SqlCommand(queryTotal, conn);
                int totalAntrian = Convert.ToInt32(cmdTotal.ExecuteScalar());
                lblTotalRecord.Text = $"📊 Total Antrian: {totalAntrian}";

                string queryMenunggu = "SELECT COUNT(*) FROM Antrian WHERE status = 'menunggu'";
                SqlCommand cmdMenunggu = new SqlCommand(queryMenunggu, conn);
                int menunggu = Convert.ToInt32(cmdMenunggu.ExecuteScalar());

                string queryDiproses = "SELECT COUNT(*) FROM Antrian WHERE status = 'sedang diproses'";
                SqlCommand cmdDiproses = new SqlCommand(queryDiproses, conn);
                int diproses = Convert.ToInt32(cmdDiproses.ExecuteScalar());

                string querySelesai = "SELECT COUNT(*) FROM Antrian WHERE status = 'selesai'";
                SqlCommand cmdSelesai = new SqlCommand(querySelesai, conn);
                int selesai = Convert.ToInt32(cmdSelesai.ExecuteScalar());

                lblMenunggu.Text = $"⏳ Menunggu: {menunggu}";
                lblDiproses.Text = $"⚙ Diproses: {diproses}";
                lblSelesai.Text = $"✅ Selesai: {selesai}";

                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error update total: " + ex.Message);
            }
        }

        // ========== SET WELCOME MESSAGE ==========
        private void SetWelcomeMessage(string nama)
        {
            lblWelcome.Text = $"Selamat Datang, {nama}";
            lblDateTime.Text = DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss");

            Timer timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += (s, e) =>
                lblDateTime.Text = DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss");
            timer.Start();
        }

        // ========== PENCARIAN DATA ==========
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim();

            if (string.IsNullOrEmpty(keyword))
            {
                LoadDataAntrian();
                return;
            }

            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                string query = @"SELECT 
                                    id_antrian, 
                                    nomor_antrian, 
                                    nama_petani, 
                                    alamat, 
                                    no_telepon, 
                                    berat_gabah, 
                                    tanggal_antrian, 
                                    status 
                                FROM Antrian 
                                WHERE nama_petani LIKE @keyword 
                                   OR CAST(nomor_antrian AS VARCHAR) LIKE @keyword
                                   OR no_telepon LIKE @keyword
                                ORDER BY nomor_antrian";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@keyword", "%" + keyword + "%");

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvAntrian.DataSource = dt;

                if (dgvAntrian.Columns["id_antrian"] != null)
                    dgvAntrian.Columns["id_antrian"].Visible = false;

                conn.Close();

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Data tidak ditemukan!", "Info",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    lblSelectedInfo.Text = $"🔍 Menampilkan {dt.Rows.Count} hasil pencarian untuk '{keyword}'";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saat mencari data: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ========== TAMBAH ANTRIAN ==========
        private void btnTambahAntrian_Click(object sender, EventArgs e)
        {
            FormAntrian formAntrian = new FormAntrian(connectionString, 0);
            formAntrian.ShowDialog();
            LoadDataAntrian();
        }

        // ========== EDIT ANTRIAN ==========
        private void btnEditAntrian_Click(object sender, EventArgs e)
        {
            if (dgvAntrian.SelectedRows.Count > 0)
            {
                int idAntrian = Convert.ToInt32(dgvAntrian.SelectedRows[0].Cells["id_antrian"].Value);
                FormAntrian formAntrian = new FormAntrian(connectionString, idAntrian);
                formAntrian.ShowDialog();
                LoadDataAntrian();
            }
            else
            {
                MessageBox.Show("Silakan pilih antrian yang akan diedit!", "Peringatan",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // ========== HAPUS ANTRIAN ==========
        private void btnHapusAntrian_Click(object sender, EventArgs e)
        {
            if (dgvAntrian.SelectedRows.Count > 0)
            {
                int idAntrian = Convert.ToInt32(dgvAntrian.SelectedRows[0].Cells["id_antrian"].Value);
                string namaPetani = dgvAntrian.SelectedRows[0].Cells["nama_petani"].Value.ToString();
                string nomorAntrian = dgvAntrian.SelectedRows[0].Cells["nomor_antrian"].Value.ToString();

                DialogResult confirm = MessageBox.Show(
                    $"Yakin ingin menghapus antrian atas nama '{namaPetani}' (No. {nomorAntrian})?\n\nData yang dihapus tidak dapat dikembalikan!",
                    "Konfirmasi Hapus",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (confirm == DialogResult.Yes)
                {
                    try
                    {
                        if (conn.State == ConnectionState.Closed)
                            conn.Open();

                        string deleteHasilQuery = "DELETE FROM HasilGiling WHERE id_antrian = @id";
                        SqlCommand cmdHasil = new SqlCommand(deleteHasilQuery, conn);
                        cmdHasil.Parameters.AddWithValue("@id", idAntrian);
                        cmdHasil.ExecuteNonQuery();

                        string query = "DELETE FROM Antrian WHERE id_antrian = @id";
                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@id", idAntrian);
                        int result = cmd.ExecuteNonQuery();

                        conn.Close();

                        if (result > 0)
                        {
                            MessageBox.Show("Data antrian berhasil dihapus!", "Sukses",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadDataAntrian();
                        }
                        else
                        {
                            MessageBox.Show("Gagal menghapus data!", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error saat menghapus data: " + ex.Message, "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Silakan pilih antrian yang akan dihapus!", "Peringatan",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // ========== PROSES GILING ==========
        private void btnProsesGiling_Click(object sender, EventArgs e)
        {
            if (dgvAntrian.SelectedRows.Count > 0)
            {
                int idAntrian = Convert.ToInt32(dgvAntrian.SelectedRows[0].Cells["id_antrian"].Value);
                string statusSaatIni = dgvAntrian.SelectedRows[0].Cells["status"].Value.ToString();
                string namaPetani = dgvAntrian.SelectedRows[0].Cells["nama_petani"].Value.ToString();

                string statusBaru = "";
                string pesan = "";

                if (statusSaatIni == "menunggu")
                {
                    statusBaru = "sedang diproses";
                    pesan = $"Memproses antrian '{namaPetani}'?\n\nStatus akan diubah menjadi 'SEDANG DIPROSES'.";
                }
                else if (statusSaatIni == "sedang diproses")
                {
                    statusBaru = "selesai";
                    pesan = $"Menyelesaikan proses gilingan '{namaPetani}'?\n\nStatus akan diubah menjadi 'SELESAI'.";
                }
                else
                {
                    MessageBox.Show("Antrian sudah selesai diproses!", "Info",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                DialogResult confirm = MessageBox.Show(pesan, "Konfirmasi Proses",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirm == DialogResult.Yes)
                {
                    try
                    {
                        if (conn.State == ConnectionState.Closed)
                            conn.Open();

                        string query = "UPDATE Antrian SET status = @status WHERE id_antrian = @id";
                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@status", statusBaru);
                        cmd.Parameters.AddWithValue("@id", idAntrian);
                        cmd.ExecuteNonQuery();

                        conn.Close();

                        MessageBox.Show($"Status antrian berhasil diubah menjadi '{statusBaru}'!",
                            "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        LoadDataAntrian();

                        if (statusBaru == "selesai")
                        {
                            DialogResult hasil = MessageBox.Show(
                                "Apakah ingin mencatat hasil giling sekarang?",
                                "Catat Hasil Giling",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question);

                            if (hasil == DialogResult.Yes)
                            {
                                FormHasilGiling formHasil = new FormHasilGiling(connectionString, idAntrian);
                                formHasil.ShowDialog();
                                LoadDataAntrian();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error saat memproses: " + ex.Message, "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Silakan pilih antrian yang akan diproses!", "Peringatan",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // ========== CATAT HASIL GILING ==========
        private void btnCatatHasil_Click(object sender, EventArgs e)
        {
            if (dgvAntrian.SelectedRows.Count > 0)
            {
                int idAntrian = Convert.ToInt32(dgvAntrian.SelectedRows[0].Cells["id_antrian"].Value);
                string status = dgvAntrian.SelectedRows[0].Cells["status"].Value.ToString();

                if (status != "selesai")
                {
                    MessageBox.Show("Antrian harus selesai diproses terlebih dahulu sebelum mencatat hasil giling!",
                        "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                FormHasilGiling formHasil = new FormHasilGiling(connectionString, idAntrian);
                formHasil.ShowDialog();
                LoadDataAntrian();
            }
            else
            {
                MessageBox.Show("Silakan pilih antrian yang akan dicatat hasilnya!", "Peringatan",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // ========== LAPORAN ==========
        private void btnLaporan_Click(object sender, EventArgs e)
        {
            FormLaporan formLaporan = new FormLaporan(connectionString);
            formLaporan.ShowDialog();
        }

        // ========== REFRESH ==========
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadDataAntrian();
            txtSearch.Clear();
            MessageBox.Show("Data berhasil direfresh!", "Info",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // ========== LOGOUT ==========
        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult confirm = MessageBox.Show("Yakin ingin logout dari sistem?",
                "Konfirmasi Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();

                FormLogin formLogin = new FormLogin();
                formLogin.Show();
                this.Close();
            }
        }

        // ========== CELL CLICK ==========
        private void dgvAntrian_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string namaPetani = dgvAntrian.Rows[e.RowIndex].Cells["nama_petani"].Value.ToString();
                string nomorAntrian = dgvAntrian.Rows[e.RowIndex].Cells["nomor_antrian"].Value.ToString();
                string status = dgvAntrian.Rows[e.RowIndex].Cells["status"].Value.ToString();
                string beratGabah = dgvAntrian.Rows[e.RowIndex].Cells["berat_gabah"].Value.ToString();

                lblSelectedInfo.Text = $"📌 Terpilih: {namaPetani} | No Antrian: {nomorAntrian} | Berat: {beratGabah} kg | Status: {status}";
            }
        }

        // ========== FORM CLOSING ==========
        private void FormUtama_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (conn != null && conn.State == ConnectionState.Open)
            {
                conn.Close();
                conn.Dispose();
            }
        }
    }
}