using Giling_Padi;
using System;
using System.Data;
using System.Data.SqlClient;
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

        // ========== BINDING SOURCE ==========
        private BindingSource bsAntrian;
        private BindingSource bsPetani;
        private DataTable dtAntrian;
        private DataTable dtPetani;

        public FormUtama(int idAdmin, string namaAdmin, string connString)
        {
            InitializeComponent();
            this.idAdmin = idAdmin;
            this.namaAdmin = namaAdmin;
            this.connectionString = connString;

            conn = new SqlConnection(connectionString);

            // Inisialisasi BindingSource
            bsAntrian = new BindingSource();
            bsPetani = new BindingSource();

            MakeLogoCircular();
            SetWelcomeMessage(namaAdmin);

            SetupDataGridView();
            SetupDataGridViewPetani();

            // Setup Binding Navigator (SATU UNTUK SEMUA)
            bindingNavigator1.BindingSource = bsAntrian; // Default ke antrian
            bindingNavigator1.Visible = true;

            // Event untuk TabControl
            tabControlMain.SelectedIndexChanged += TabControlMain_SelectedIndexChanged;

            LoadDataAntrian();
            LoadDataPetani();

            EnableAllButtons();

            if (panelSubmenuAntrian != null)
                panelSubmenuAntrian.Visible = false;
            if (panelSubmenuPetani != null)
                panelSubmenuPetani.Visible = false;
        }

        // ========== EVENT KETIKA TAB BERUBAH ==========
        private void TabControlMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControlMain.SelectedTab == tabPageAntrian)
            {
                // Tab Antrian dipilih
                bindingNavigator1.BindingSource = bsAntrian;
                bindingNavigator1.Text = "bindingNavigator1 - Data Antrian";
            }
            else if (tabControlMain.SelectedTab == tabPagePetani)
            {
                // Tab Petani dipilih
                bindingNavigator1.BindingSource = bsPetani;
                bindingNavigator1.Text = "bindingNavigator1 - Data Petani";
            }
        }

        private void SetupDataGridView()
        {
            dgvAntrian.DataSource = bsAntrian;

            dgvAntrian.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAntrian.MultiSelect = false;
            dgvAntrian.ReadOnly = true;
            dgvAntrian.AllowUserToAddRows = false;
            dgvAntrian.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvAntrian.RowHeadersVisible = false;
        }

        private void SetupDataGridViewPetani()
        {
            dgvPetani.DataSource = bsPetani;

            dgvPetani.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPetani.MultiSelect = false;
            dgvPetani.ReadOnly = true;
            dgvPetani.AllowUserToAddRows = false;
            dgvPetani.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvPetani.RowHeadersVisible = false;
        }

        private void MakeLogoCircular()
        {
            try
            {
                Image originalImage = Giling_Padi.Properties.Resources.logo;

                if (originalImage != null)
                {
                    Bitmap bmp = new Bitmap(pictureBoxLogo.Width, pictureBoxLogo.Height);

                    using (Graphics g = Graphics.FromImage(bmp))
                    {
                        g.SmoothingMode = SmoothingMode.AntiAlias;
                        g.Clear(Color.Transparent);

                        GraphicsPath clipPath = new GraphicsPath();
                        clipPath.AddEllipse(3, 3, pictureBoxLogo.Width - 6, pictureBoxLogo.Height - 6);
                        g.SetClip(clipPath);

                        g.DrawImage(originalImage, 0, 0, pictureBoxLogo.Width, pictureBoxLogo.Height);
                        g.ResetClip();

                        using (Pen pen = new Pen(Color.White, 3))
                        {
                            g.DrawEllipse(pen, 3, 3, pictureBoxLogo.Width - 6, pictureBoxLogo.Height - 6);
                        }

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

        private void CreateDefaultLogo()
        {
            Bitmap bmp = new Bitmap(pictureBoxLogo.Width, pictureBoxLogo.Height);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.Clear(Color.Transparent);

                using (SolidBrush brush = new SolidBrush(Color.FromArgb(241, 196, 15)))
                {
                    g.FillEllipse(brush, 3, 3, pictureBoxLogo.Width - 6, pictureBoxLogo.Height - 6);
                }

                using (Font font = new Font("Segoe UI", pictureBoxLogo.Width / 2, FontStyle.Bold))
                using (SolidBrush brush = new SolidBrush(Color.White))
                {
                    SizeF textSize = g.MeasureString("🌾", font);
                    float x = (pictureBoxLogo.Width - textSize.Width) / 2;
                    float y = (pictureBoxLogo.Height - textSize.Height) / 2;
                    g.DrawString("🌾", font, brush, x, y);
                }

                using (Pen pen = new Pen(Color.White, 3))
                {
                    g.DrawEllipse(pen, 3, 3, pictureBoxLogo.Width - 6, pictureBoxLogo.Height - 6);
                }

                using (Pen pen = new Pen(Color.FromArgb(241, 196, 15), 2))
                {
                    g.DrawEllipse(pen, 1, 1, pictureBoxLogo.Width - 2, pictureBoxLogo.Height - 2);
                }
            }
            pictureBoxLogo.Image = bmp;
        }

        private void EnableAllButtons()
        {
            btnKelolaAntrian.Enabled = true;
            btnKelolaPetani.Enabled = true;
            btnProsesGiling.Enabled = true;
            btnCatatHasil.Enabled = true;
            btnLaporan.Enabled = true;
            btnRefresh.Enabled = true;
            btnSearch.Enabled = true;
            btnSearchPetani.Enabled = true;
            txtSearch.Enabled = true;
            txtSearchPetani.Enabled = true;

            btnTambahAntrian.Enabled = true;
            btnEditAntrian.Enabled = true;
            btnHapusAntrian.Enabled = true;
        }

        private void btnKelolaAntrian_Click(object sender, EventArgs e)
        {
            if (panelSubmenuAntrian != null)
            {
                panelSubmenuAntrian.Visible = !panelSubmenuAntrian.Visible;
                if (panelSubmenuPetani != null)
                    panelSubmenuPetani.Visible = false;
                btnKelolaAntrian.BackColor = panelSubmenuAntrian.Visible ?
                    Color.FromArgb(52, 152, 219) : Color.FromArgb(41, 128, 185);
                btnKelolaPetani.BackColor = Color.FromArgb(41, 128, 185);
            }
        }

        private void btnKelolaPetani_Click(object sender, EventArgs e)
        {
            if (panelSubmenuPetani != null)
            {
                panelSubmenuPetani.Visible = !panelSubmenuPetani.Visible;
                if (panelSubmenuAntrian != null)
                    panelSubmenuAntrian.Visible = false;
                btnKelolaPetani.BackColor = panelSubmenuPetani.Visible ?
                    Color.FromArgb(52, 152, 219) : Color.FromArgb(41, 128, 185);
                btnKelolaAntrian.BackColor = Color.FromArgb(41, 128, 185);
            }
        }

        private void LoadDataAntrian()
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                string query = @"SELECT 
                                    a.id_antrian, 
                                    a.nomor_antrian, 
                                    p.nama AS nama_petani, 
                                    p.alamat, 
                                    p.no_telepon, 
                                    a.berat_gabah, 
                                    a.tanggal_giling, 
                                    a.status 
                                FROM Antrian a
                                JOIN Petani p ON a.id_petani = p.id_petani
                                ORDER BY a.nomor_antrian";

                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                dtAntrian = new DataTable();
                da.Fill(dtAntrian);

                bsAntrian.DataSource = dtAntrian;

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
                if (dgvAntrian.Columns["tanggal_giling"] != null)
                    dgvAntrian.Columns["tanggal_giling"].HeaderText = "Tanggal Giling";
                if (dgvAntrian.Columns["status"] != null)
                    dgvAntrian.Columns["status"].HeaderText = "Status";

                UpdateTotalRecord();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saat memuat data antrian: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadDataPetani()
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                string query = "SELECT id_petani, nama, alamat, no_telepon, created_at FROM Petani ORDER BY nama";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                dtPetani = new DataTable();
                da.Fill(dtPetani);

                bsPetani.DataSource = dtPetani;

                if (dgvPetani.Columns["id_petani"] != null)
                    dgvPetani.Columns["id_petani"].Visible = false;
                if (dgvPetani.Columns["nama"] != null)
                    dgvPetani.Columns["nama"].HeaderText = "Nama Petani";
                if (dgvPetani.Columns["alamat"] != null)
                    dgvPetani.Columns["alamat"].HeaderText = "Alamat";
                if (dgvPetani.Columns["no_telepon"] != null)
                    dgvPetani.Columns["no_telepon"].HeaderText = "No Telepon";
                if (dgvPetani.Columns["created_at"] != null)
                    dgvPetani.Columns["created_at"].HeaderText = "Tanggal Daftar";

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saat memuat data petani: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTambahPetani_Click(object sender, EventArgs e)
        {
            FormPetani formPetani = new FormPetani(connectionString, 0);
            if (formPetani.ShowDialog() == DialogResult.OK)
            {
                LoadDataPetani();
            }
        }

        private void btnEditPetani_Click(object sender, EventArgs e)
        {
            if (bsPetani.Current != null)
            {
                DataRowView currentRow = (DataRowView)bsPetani.Current;
                int idPetani = Convert.ToInt32(currentRow["id_petani"]);

                FormPetani formPetani = new FormPetani(connectionString, idPetani);
                if (formPetani.ShowDialog() == DialogResult.OK)
                {
                    LoadDataPetani();
                }
            }
            else
            {
                MessageBox.Show("Silakan pilih petani yang akan diedit!", "Peringatan",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnHapusPetani_Click(object sender, EventArgs e)
        {
            if (bsPetani.Current != null)
            {
                DataRowView currentRow = (DataRowView)bsPetani.Current;
                int idPetani = Convert.ToInt32(currentRow["id_petani"]);
                string namaPetani = currentRow["nama"].ToString();

                DialogResult confirm = MessageBox.Show(
                    $"Yakin ingin menghapus petani '{namaPetani}'?\n\nData petani yang memiliki antrian tidak dapat dihapus!",
                    "Konfirmasi Hapus",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (confirm == DialogResult.Yes)
                {
                    try
                    {
                        if (conn.State == ConnectionState.Closed)
                            conn.Open();

                        string query = "DELETE FROM Petani WHERE id_petani = @id";
                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@id", idPetani);
                        int result = cmd.ExecuteNonQuery();

                        conn.Close();

                        if (result > 0)
                        {
                            MessageBox.Show("Data petani berhasil dihapus!", "Sukses",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadDataPetani();
                        }
                        else
                        {
                            MessageBox.Show("Gagal menghapus data! Pastikan petani tidak memiliki antrian.", "Error",
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
                MessageBox.Show("Silakan pilih petani yang akan dihapus!", "Peringatan",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

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

                string queryDiproses = "SELECT COUNT(*) FROM Antrian WHERE status = 'proses'";
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
                                    a.id_antrian, 
                                    a.nomor_antrian, 
                                    p.nama AS nama_petani, 
                                    p.alamat, 
                                    p.no_telepon, 
                                    a.berat_gabah, 
                                    a.tanggal_giling, 
                                    a.status 
                                FROM Antrian a
                                JOIN Petani p ON a.id_petani = p.id_petani
                                WHERE p.nama LIKE @keyword 
                                   OR CAST(a.nomor_antrian AS VARCHAR) LIKE @keyword
                                   OR p.no_telepon LIKE @keyword
                                ORDER BY a.nomor_antrian";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@keyword", "%" + keyword + "%");

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                bsAntrian.DataSource = dt;

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

        private void btnSearchPetani_Click(object sender, EventArgs e)
        {
            string keyword = txtSearchPetani.Text.Trim();

            if (string.IsNullOrEmpty(keyword))
            {
                LoadDataPetani();
                return;
            }

            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                string query = @"SELECT id_petani, nama, alamat, no_telepon, created_at 
                                FROM Petani 
                                WHERE nama LIKE @keyword 
                                   OR no_telepon LIKE @keyword
                                   OR alamat LIKE @keyword
                                ORDER BY nama";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@keyword", "%" + keyword + "%");

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                bsPetani.DataSource = dt;

                if (dgvPetani.Columns["id_petani"] != null)
                    dgvPetani.Columns["id_petani"].Visible = false;

                conn.Close();

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Data petani tidak ditemukan!", "Info",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saat mencari data petani: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ========== BINDING NAVIGATOR EVENT HANDLER (SATU UNTUK SEMUA) ==========
        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            // Cek tab mana yang aktif
            if (tabControlMain.SelectedTab == tabPageAntrian)
            {
                btnTambahAntrian_Click(sender, e);
            }
            else if (tabControlMain.SelectedTab == tabPagePetani)
            {
                btnTambahPetani_Click(sender, e);
            }
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            // Cek tab mana yang aktif
            if (tabControlMain.SelectedTab == tabPageAntrian)
            {
                if (bsAntrian.Current != null)
                {
                    DialogResult confirm = MessageBox.Show(
                        "⚠️ Yakin ingin menghapus data antrian yang dipilih?\n\nData yang dihapus tidak dapat dikembalikan!",
                        "Konfirmasi Hapus",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (confirm == DialogResult.Yes)
                    {
                        btnHapusAntrian_Click(sender, e);
                    }
                }
                else
                {
                    MessageBox.Show("❌ Tidak ada data antrian yang dipilih untuk dihapus!",
                        "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else if (tabControlMain.SelectedTab == tabPagePetani)
            {
                if (bsPetani.Current != null)
                {
                    DialogResult confirm = MessageBox.Show(
                        "⚠️ Yakin ingin menghapus data petani yang dipilih?\n\nData yang dihapus tidak dapat dikembalikan!",
                        "Konfirmasi Hapus Petani",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (confirm == DialogResult.Yes)
                    {
                        btnHapusPetani_Click(sender, e);
                    }
                }
                else
                {
                    MessageBox.Show("❌ Tidak ada data petani yang dipilih untuk dihapus!",
                        "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnTambahAntrian_Click(object sender, EventArgs e)
        {
            FormAntrian formAntrian = new FormAntrian(connectionString, 0);
            if (formAntrian.ShowDialog() == DialogResult.OK)
            {
                LoadDataAntrian();
            }
        }

        private void btnEditAntrian_Click(object sender, EventArgs e)
        {
            if (bsAntrian.Current != null)
            {
                DataRowView currentRow = (DataRowView)bsAntrian.Current;
                int idAntrian = Convert.ToInt32(currentRow["id_antrian"]);
                string statusLama = currentRow["status"].ToString();

                FormAntrian formAntrian = new FormAntrian(connectionString, idAntrian);
                if (formAntrian.ShowDialog() == DialogResult.OK)
                {
                    LoadDataAntrian();

                    string statusBaru = "";
                    try
                    {
                        if (conn.State == ConnectionState.Closed)
                            conn.Open();
                        string queryStatus = "SELECT status FROM Antrian WHERE id_antrian = @id";
                        SqlCommand cmdStatus = new SqlCommand(queryStatus, conn);
                        cmdStatus.Parameters.AddWithValue("@id", idAntrian);
                        statusBaru = cmdStatus.ExecuteScalar()?.ToString();
                        conn.Close();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error ambil status: " + ex.Message);
                    }

                    if (statusBaru == "selesai" && statusLama != "selesai")
                    {
                        CekDanBukaFormHasilGiling(idAntrian);
                    }
                }
            }
            else
            {
                MessageBox.Show("Silakan pilih antrian yang akan diedit!", "Peringatan",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnHapusAntrian_Click(object sender, EventArgs e)
        {
            if (bsAntrian.Current != null)
            {
                DataRowView currentRow = (DataRowView)bsAntrian.Current;
                int idAntrian = Convert.ToInt32(currentRow["id_antrian"]);
                string namaPetani = currentRow["nama_petani"].ToString();
                string nomorAntrian = currentRow["nomor_antrian"].ToString();

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

        private void btnProsesGiling_Click(object sender, EventArgs e)
        {
            if (bsAntrian.Current != null)
            {
                DataRowView currentRow = (DataRowView)bsAntrian.Current;
                int idAntrian = Convert.ToInt32(currentRow["id_antrian"]);
                string statusSaatIni = currentRow["status"].ToString();
                string namaPetani = currentRow["nama_petani"].ToString();

                if (statusSaatIni == "menunggu")
                {
                    DialogResult confirm = MessageBox.Show(
                        $"Memproses antrian '{namaPetani}'?\n\nStatus akan diubah menjadi 'PROSES'.",
                        "Konfirmasi Proses",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (confirm == DialogResult.Yes)
                    {
                        try
                        {
                            if (conn.State == ConnectionState.Closed)
                                conn.Open();

                            string query = "UPDATE Antrian SET status = 'proses' WHERE id_antrian = @id";
                            SqlCommand cmd = new SqlCommand(query, conn);
                            cmd.Parameters.AddWithValue("@id", idAntrian);
                            cmd.ExecuteNonQuery();

                            conn.Close();

                            MessageBox.Show("Status antrian berhasil diubah menjadi 'PROSES'!",
                                "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            LoadDataAntrian();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error saat memproses: " + ex.Message, "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else if (statusSaatIni == "proses")
                {
                    int sudahAda = 0;
                    try
                    {
                        if (conn.State == ConnectionState.Closed)
                            conn.Open();
                        string cekQuery = "SELECT COUNT(*) FROM HasilGiling WHERE id_antrian = @id";
                        SqlCommand cekCmd = new SqlCommand(cekQuery, conn);
                        cekCmd.Parameters.AddWithValue("@id", idAntrian);
                        sudahAda = Convert.ToInt32(cekCmd.ExecuteScalar());
                        conn.Close();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error: " + ex.Message);
                    }

                    if (sudahAda > 0)
                    {
                        DialogResult confirm = MessageBox.Show(
                            $"Antrian '{namaPetani}' sudah memiliki catatan hasil giling.\n\nApakah ingin mengubah status menjadi 'SELESAI'?",
                            "Konfirmasi Selesai",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question);

                        if (confirm == DialogResult.Yes)
                        {
                            try
                            {
                                if (conn.State == ConnectionState.Closed)
                                    conn.Open();

                                string query = "UPDATE Antrian SET status = 'selesai' WHERE id_antrian = @id";
                                SqlCommand cmd = new SqlCommand(query, conn);
                                cmd.Parameters.AddWithValue("@id", idAntrian);
                                cmd.ExecuteNonQuery();

                                conn.Close();

                                MessageBox.Show("Status antrian berhasil diubah menjadi 'SELESAI'!",
                                    "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                LoadDataAntrian();
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
                        DialogResult confirm = MessageBox.Show(
                            $"Menyelesaikan proses gilingan '{namaPetani}'?\n\nAnda akan diminta mencatat hasil giling.",
                            "Konfirmasi Selesai",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question);

                        if (confirm == DialogResult.Yes)
                        {
                            FormHasilGiling formHasil = new FormHasilGiling(connectionString, idAntrian);
                            DialogResult hasilForm = formHasil.ShowDialog();

                            if (hasilForm == DialogResult.OK)
                            {
                                try
                                {
                                    if (conn.State == ConnectionState.Closed)
                                        conn.Open();

                                    string query = "UPDATE Antrian SET status = 'selesai' WHERE id_antrian = @id";
                                    SqlCommand cmd = new SqlCommand(query, conn);
                                    cmd.Parameters.AddWithValue("@id", idAntrian);
                                    cmd.ExecuteNonQuery();

                                    conn.Close();

                                    MessageBox.Show("Hasil giling berhasil dicatat!\nStatus antrian berubah menjadi 'SELESAI'.",
                                        "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                    LoadDataAntrian();
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("Error saat update status: " + ex.Message, "Error",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Status antrian tetap 'PROSES'.\nSilakan catat hasil giling nanti melalui menu 'Catat Hasil Giling'.",
                                    "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Antrian sudah selesai diproses!", "Info",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Silakan pilih antrian yang akan diproses!", "Peringatan",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void CekDanBukaFormHasilGiling(int idAntrian)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                string cekQuery = "SELECT COUNT(*) FROM HasilGiling WHERE id_antrian = @id";
                SqlCommand cekCmd = new SqlCommand(cekQuery, conn);
                cekCmd.Parameters.AddWithValue("@id", idAntrian);
                int sudahAda = Convert.ToInt32(cekCmd.ExecuteScalar());
                conn.Close();

                if (sudahAda == 0)
                {
                    DialogResult hasil = MessageBox.Show(
                        "Status antrian telah diubah menjadi SELESAI.\n\nApakah ingin mencatat hasil giling sekarang?",
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
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        private void btnCatatHasil_Click(object sender, EventArgs e)
        {
            if (bsAntrian.Current != null)
            {
                DataRowView currentRow = (DataRowView)bsAntrian.Current;
                int idAntrian = Convert.ToInt32(currentRow["id_antrian"]);
                string status = currentRow["status"].ToString();

                if (status != "selesai")
                {
                    MessageBox.Show("Antrian harus selesai diproses terlebih dahulu sebelum mencatat hasil giling!",
                        "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                string cekQuery = "SELECT COUNT(*) FROM HasilGiling WHERE id_antrian = @id";
                SqlCommand cekCmd = new SqlCommand(cekQuery, conn);
                cekCmd.Parameters.AddWithValue("@id", idAntrian);
                int sudahAda = Convert.ToInt32(cekCmd.ExecuteScalar());
                conn.Close();

                if (sudahAda > 0)
                {
                    MessageBox.Show("Hasil giling untuk antrian ini sudah pernah dicatat!",
                        "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void btnLaporan_Click(object sender, EventArgs e)
        {
            FormLaporan formLaporan = new FormLaporan(connectionString);
            formLaporan.ShowDialog();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadDataAntrian();
            LoadDataPetani();
            txtSearch.Clear();
            txtSearchPetani.Clear();
            MessageBox.Show("Data berhasil direfresh!", "Info",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

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

        private void dgvAntrian_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataRowView row = (DataRowView)bsAntrian[e.RowIndex];
                string namaPetani = row["nama_petani"].ToString();
                string nomorAntrian = row["nomor_antrian"].ToString();
                string status = row["status"].ToString();
                string beratGabah = row["berat_gabah"].ToString();

                lblSelectedInfo.Text = $"📌 Terpilih: {namaPetani} | No Antrian: {nomorAntrian} | Berat: {beratGabah} kg | Status: {status}";
            }
        }

        private void dgvPetani_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataRowView row = (DataRowView)bsPetani[e.RowIndex];
                string namaPetani = row["nama"].ToString();
                lblSelectedPetaniInfo.Text = $"👨‍🌾 Terpilih: {namaPetani}";
            }
        }

        private void FormUtama_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (conn != null && conn.State == ConnectionState.Open)
            {
                conn.Close();
                conn.Dispose();
            }
        }

        private void panelSubmenuPetani_VisibleChanged(object sender, EventArgs e)
        {
            if (panelSubmenuPetani.Visible)
            {
                LoadDataPetani();
            }
        }

        private void btnLihatPetani_Click(object sender, EventArgs e)
        {
            LoadDataPetani();
        }
    }
}