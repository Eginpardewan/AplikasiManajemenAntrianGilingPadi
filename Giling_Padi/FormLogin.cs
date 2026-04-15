using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace AplikasiGilinganPadi
{
    public partial class FormLogin : Form
    {
        // ========== KONEKSI DATABASE ==========
        private readonly string connectionString =
            "Data Source=LAPTOP-SDC5DOB7\\EGIN;Initial Catalog=GilinganPadi;Integrated Security=True";

        // ========== STATUS KONEKSI ==========
        private bool isDatabaseConnected = false;

        public FormLogin()
        {
            InitializeComponent();

            // BUAT LOGO BENTUK BULAT DENGAN BORDER
            MakeLogoCircular();

            // Set password char
            txtPassword.PasswordChar = '*';

            // Set status awal
            SetStatusAwal();
        }

        // ========== MEMBUAT LOGO BENTUK BULAT DENGAN BORDER ==========
        private void MakeLogoCircular()
        {
            try
            {
                // PERBAIKAN: Gunakan namespace yang benar
                Image originalImage = Giling_Padi.Properties.Resources.logo;

                if (originalImage != null)
                {
                    // Buat gambar baru dengan ukuran yang diinginkan
                    Bitmap bmp = new Bitmap(pictureBoxIcon.Width, pictureBoxIcon.Height);

                    using (Graphics g = Graphics.FromImage(bmp))
                    {
                        g.SmoothingMode = SmoothingMode.AntiAlias;
                        g.Clear(Color.Transparent);

                        // Buat lingkaran clipping
                        GraphicsPath clipPath = new GraphicsPath();
                        clipPath.AddEllipse(5, 5, pictureBoxIcon.Width - 10, pictureBoxIcon.Height - 10);
                        g.SetClip(clipPath);

                        // Gambar image di dalam lingkaran (dengan ukuran yang pas)
                        Rectangle destRect = new Rectangle(5, 5, pictureBoxIcon.Width - 10, pictureBoxIcon.Height - 10);
                        g.DrawImage(originalImage, destRect);

                        // Reset clipping
                        g.ResetClip();

                        // Border putih tebal
                        using (Pen pen = new Pen(Color.White, 4))
                        {
                            g.DrawEllipse(pen, 5, 5, pictureBoxIcon.Width - 10, pictureBoxIcon.Height - 10);
                        }

                        // Border kuning tipis
                        using (Pen pen = new Pen(Color.FromArgb(241, 196, 15), 2))
                        {
                            g.DrawEllipse(pen, 3, 3, pictureBoxIcon.Width - 6, pictureBoxIcon.Height - 6);
                        }
                    }

                    pictureBoxIcon.Image = bmp;
                }
                else
                {
                    CreateDefaultLogo();
                }
            }
            catch (Exception ex)
            {
                // Jika error, buat logo default
                CreateDefaultLogo();
            }

            pictureBoxIcon.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBoxIcon.BackColor = Color.Transparent;
        }

        // ========== LOGO DEFAULT (JIKA GAMBAR TIDAK ADA) ==========
        private void CreateDefaultLogo()
        {
            Bitmap bmp = new Bitmap(pictureBoxIcon.Width, pictureBoxIcon.Height);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.Clear(Color.Transparent);

                // Lingkaran background kuning
                using (SolidBrush brush = new SolidBrush(Color.FromArgb(241, 196, 15)))
                {
                    g.FillEllipse(brush, 5, 5, pictureBoxIcon.Width - 10, pictureBoxIcon.Height - 10);
                }

                // Teks "🌾" di tengah
                using (Font font = new Font("Segoe UI", pictureBoxIcon.Width / 2, FontStyle.Bold))
                using (SolidBrush brush = new SolidBrush(Color.White))
                {
                    SizeF textSize = g.MeasureString("🌾", font);
                    float x = (pictureBoxIcon.Width - textSize.Width) / 2;
                    float y = (pictureBoxIcon.Height - textSize.Height) / 2;
                    g.DrawString("🌾", font, brush, x, y);
                }

                // Border putih
                using (Pen pen = new Pen(Color.White, 3))
                {
                    g.DrawEllipse(pen, 5, 5, pictureBoxIcon.Width - 10, pictureBoxIcon.Height - 10);
                }
            }
            pictureBoxIcon.Image = bmp;
            pictureBoxIcon.SizeMode = PictureBoxSizeMode.CenterImage;
        }

        // ========== SET STATUS AWAL ==========
        private void SetStatusAwal()
        {
            isDatabaseConnected = false;
            lblStatusKoneksi.Text = "● BELUM TERKONEKSI";
            lblStatusKoneksi.ForeColor = System.Drawing.Color.FromArgb(149, 165, 166);
            lblStatusDetail.Text = "Klik tombol 'Test Koneksi' untuk cek koneksi ke database.";

            // Nonaktifkan tombol login sampai koneksi berhasil
            btnLogin.Enabled = false;
            btnLogin.BackColor = System.Drawing.Color.FromArgb(149, 165, 166);
            btnLogin.Text = "🔒 Login (Koneksi Database Dulu)";
        }

        // ========== UPDATE STATUS KONEKSI ==========
        private void UpdateStatusKoneksi(bool isConnected, string message, string detail)
        {
            isDatabaseConnected = isConnected;

            if (isConnected)
            {
                lblStatusKoneksi.Text = "● DATABASE TERKONEKSI";
                lblStatusKoneksi.ForeColor = System.Drawing.Color.LightGreen;
                lblStatusDetail.Text = detail;

                // Aktifkan tombol login
                btnLogin.Enabled = true;
                btnLogin.BackColor = System.Drawing.Color.FromArgb(39, 174, 96);
                btnLogin.Text = "🔓 Login";
            }
            else
            {
                lblStatusKoneksi.Text = "● DATABASE TIDAK TERKONEKSI";
                lblStatusKoneksi.ForeColor = System.Drawing.Color.LightCoral;
                lblStatusDetail.Text = detail;

                // Nonaktifkan tombol login
                btnLogin.Enabled = false;
                btnLogin.BackColor = System.Drawing.Color.FromArgb(149, 165, 166);
                btnLogin.Text = "🔒 Login (Koneksi Database Dulu)";
            }
        }

        // ========== TOMBOL TEST KONEKSI ==========
        private void btnTestKoneksi_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection testConn = new SqlConnection(connectionString))
                {
                    testConn.Open();
                    UpdateStatusKoneksi(true, "Koneksi berhasil",
                        "Koneksi ke database GilinganPadi berhasil! Silakan login.");
                }

                MessageBox.Show("Koneksi ke database BERHASIL!\n\nSekarang Anda bisa login.",
                    "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                UpdateStatusKoneksi(false, "Koneksi gagal",
                    "Error: " + ex.Message);

                MessageBox.Show("❌ Koneksi ke database GAGAL!\n\n" +
                    "Pastikan:\n" +
                    "1. SQL Server sedang berjalan\n" +
                    "2. Database 'GilinganPadi' sudah dibuat\n" +
                    "3. Connection string sudah benar\n\n" +
                    "Error Detail: " + ex.Message,
                    "Error Koneksi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ========== TOMBOL LOGIN ==========
        private void btnLogin_Click(object sender, EventArgs e)
        {
            // VALIDASI: Pastikan database sudah terkoneksi
            if (!isDatabaseConnected)
            {
                MessageBox.Show("❌ Database belum terkoneksi!\n\n" +
                    "Silakan klik tombol 'Test Koneksi' terlebih dahulu untuk\n" +
                    "memastikan koneksi ke database berhasil sebelum login.",
                    "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrEmpty(email))
            {
                MessageBox.Show("Email harus diisi!", "Peringatan",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return;
            }

            if (string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Password harus diisi!", "Peringatan",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                return;
            }

            try
            {
                using (SqlConnection loginConn = new SqlConnection(connectionString))
                {
                    loginConn.Open();

                    string query = "SELECT id_admin, nama FROM Admin WHERE email = @email AND password = @password";
                    SqlCommand cmd = new SqlCommand(query, loginConn);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@password", password);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        int idAdmin = reader.GetInt32(0);
                        string namaAdmin = reader.GetString(1);

                        MessageBox.Show($"Selamat datang, {namaAdmin}!", "Login Berhasil",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        reader.Close();

                        FormUtama formUtama = new FormUtama(idAdmin, namaAdmin, connectionString);
                        formUtama.Show();
                        this.Hide();
                    }
                    else
                    {
                        reader.Close();
                        MessageBox.Show("Email atau password salah!", "Login Gagal",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtPassword.Clear();
                        txtPassword.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saat login: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ========== TOMBOL EXIT ==========
        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult confirm = MessageBox.Show("Yakin ingin keluar dari aplikasi?",
                "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        // ========== EVENT FORM CLOSING ==========
        private void FormLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Tidak ada koneksi yang perlu ditutup
        }

        // ========== EVENT ENTER DI TEXTBOX ==========
        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnLogin_Click(sender, e);
            }
        }

        private void txtEmail_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtPassword.Focus();
            }
        }

        private void pictureBoxIcon_Click(object sender, EventArgs e)
        {

        }
    }
}