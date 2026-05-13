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

        // ========== BINDING SOURCE (STEP 2) ==========
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

            // ========== INISIALISASI BINDING SOURCE (STEP 2) ==========
            bsAntrian = new BindingSource();
            bsPetani = new BindingSource();

            MakeLogoCircular();
            SetWelcomeMessage(namaAdmin);

            SetupDataGridView();
            SetupDataGridViewPetani();

            LoadDataAntrian();
            LoadDataPetani();

            EnableAllButtons();

            if (panelSubmenuAntrian != null)
                panelSubmenuAntrian.Visible = false;
            if (panelSubmenuPetani != null)
                panelSubmenuPetani.Visible = false;
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

        private void SetupDataGridView()
        {
            dgvAntrian.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAntrian.MultiSelect = false;
            dgvAntrian.ReadOnly = true;
            dgvAntrian.AllowUserToAddRows = false;
            dgvAntrian.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvAntrian.RowHeadersVisible = false;
        }

        private void SetupDataGridViewPetani()
        {
            dgvPetani.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPetani.MultiSelect = false;
            dgvPetani.ReadOnly = true;
            dgvPetani.AllowUserToAddRows = false;
            dgvPetani.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvPetani.RowHeadersVisible = false;
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
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvPetani.DataSource = dt;

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