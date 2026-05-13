using System;
using System.Drawing;
using System.Windows.Forms;

namespace AplikasiGilinganPadi
{
    partial class FormUtama
    {
        private System.ComponentModel.IContainer components = null;

        // Panel Utama
        private Panel panelHeader;
        private Panel panelSidebar;
        private Panel panelMain;
        private Panel panelStatus;
        private Panel panelStats;

        // Header Controls
        private PictureBox pictureBoxLogo;
        private Label lblTitle;
        private Label lblWelcome;
        private Label lblDateTime;

        // Sidebar Buttons - Menu Utama
        private Button btnKelolaAntrian;
        private Button btnKelolaPetani;
        private Button btnProsesGiling;
        private Button btnCatatHasil;
        private Button btnLaporan;
        private Button btnRefresh;
        private Button btnLogout;

        // Submenu Kelola Antrian
        private Panel panelSubmenuAntrian;
        private Button btnTambahAntrian;
        private Button btnEditAntrian;
        private Button btnHapusAntrian;

        // Submenu Kelola Petani
        private Panel panelSubmenuPetani;
        private Button btnTambahPetani;
        private Button btnEditPetani;
        private Button btnHapusPetani;

        // Main Area Controls - Tab Control
        private TabControl tabControlMain;
        private TabPage tabPageAntrian;
        private TabPage tabPagePetani;

        // Antrian Tab Controls
        private GroupBox groupBoxSearch;
        private TextBox txtSearch;
        private Button btnSearch;
        private DataGridView dgvAntrian;

        // Petani Tab Controls
        private GroupBox groupBoxSearchPetani;
        private TextBox txtSearchPetani;
        private Button btnSearchPetani;
        private DataGridView dgvPetani;

        // Status Panel Controls
        private Label lblTotalRecord;
        private Label lblMenunggu;
        private Label lblDiproses;
        private Label lblSelesai;
        private Label lblSelectedInfo;
        private Label lblSelectedPetaniInfo;

        // Separators
        private Label separator1;
        private Label separator2;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.panelHeader = new System.Windows.Forms.Panel();
            this.pictureBoxLogo = new System.Windows.Forms.PictureBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.lblDateTime = new System.Windows.Forms.Label();
            this.panelSidebar = new System.Windows.Forms.Panel();
            this.btnKelolaAntrian = new System.Windows.Forms.Button();
            this.panelSubmenuAntrian = new System.Windows.Forms.Panel();
            this.btnTambahAntrian = new System.Windows.Forms.Button();
            this.btnEditAntrian = new System.Windows.Forms.Button();
            this.btnHapusAntrian = new System.Windows.Forms.Button();
            this.btnKelolaPetani = new System.Windows.Forms.Button();
            this.panelSubmenuPetani = new System.Windows.Forms.Panel();
            this.btnTambahPetani = new System.Windows.Forms.Button();
            this.btnEditPetani = new System.Windows.Forms.Button();
            this.btnHapusPetani = new System.Windows.Forms.Button();
            this.separator1 = new System.Windows.Forms.Label();
            this.btnProsesGiling = new System.Windows.Forms.Button();
            this.btnCatatHasil = new System.Windows.Forms.Button();
            this.separator2 = new System.Windows.Forms.Label();
            this.btnLaporan = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.panelMain = new System.Windows.Forms.Panel();
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tabPageAntrian = new System.Windows.Forms.TabPage();
            this.dgvAntrian = new System.Windows.Forms.DataGridView();
            this.groupBoxSearch = new System.Windows.Forms.GroupBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.tabPagePetani = new System.Windows.Forms.TabPage();
            this.dgvPetani = new System.Windows.Forms.DataGridView();
            this.groupBoxSearchPetani = new System.Windows.Forms.GroupBox();
            this.txtSearchPetani = new System.Windows.Forms.TextBox();
            this.btnSearchPetani = new System.Windows.Forms.Button();
            this.panelStatus = new System.Windows.Forms.Panel();
            this.panelStats = new System.Windows.Forms.Panel();
            this.lblTotalRecord = new System.Windows.Forms.Label();
            this.lblMenunggu = new System.Windows.Forms.Label();
            this.lblDiproses = new System.Windows.Forms.Label();
            this.lblSelesai = new System.Windows.Forms.Label();
            this.lblSelectedInfo = new System.Windows.Forms.Label();
            this.lblSelectedPetaniInfo = new System.Windows.Forms.Label();
            this.panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).BeginInit();
            this.panelSidebar.SuspendLayout();
            this.panelSubmenuAntrian.SuspendLayout();
            this.panelSubmenuPetani.SuspendLayout();
            this.panelMain.SuspendLayout();
            this.tabControlMain.SuspendLayout();
            this.tabPageAntrian.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAntrian)).BeginInit();
            this.groupBoxSearch.SuspendLayout();
            this.tabPagePetani.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPetani)).BeginInit();
            this.groupBoxSearchPetani.SuspendLayout();
            this.panelStatus.SuspendLayout();
            this.panelStats.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.panelHeader.Controls.Add(this.pictureBoxLogo);
            this.panelHeader.Controls.Add(this.lblTitle);
            this.panelHeader.Controls.Add(this.lblWelcome);
            this.panelHeader.Controls.Add(this.lblDateTime);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Padding = new System.Windows.Forms.Padding(10, 5, 20, 5);
            this.panelHeader.Size = new System.Drawing.Size(1100, 70);
            this.panelHeader.TabIndex = 2;
            // 
            // pictureBoxLogo
            // 
            this.pictureBoxLogo.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxLogo.Location = new System.Drawing.Point(15, 10);
            this.pictureBoxLogo.Name = "pictureBoxLogo";
            this.pictureBoxLogo.Size = new System.Drawing.Size(50, 50);
            this.pictureBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxLogo.TabIndex = 0;
            this.pictureBoxLogo.TabStop = false;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(75, 12);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(397, 32);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "🌾 Aplikasi Antrian Gilingan Padi";
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblWelcome.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.lblWelcome.Location = new System.Drawing.Point(75, 40);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(152, 20);
            this.lblWelcome.TabIndex = 2;
            this.lblWelcome.Text = "Selamat Datang, User";
            // 
            // lblDateTime
            // 
            this.lblDateTime.AutoSize = true;
            this.lblDateTime.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDateTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.lblDateTime.Location = new System.Drawing.Point(800, 40);
            this.lblDateTime.Name = "lblDateTime";
            this.lblDateTime.Size = new System.Drawing.Size(234, 20);
            this.lblDateTime.TabIndex = 3;
            this.lblDateTime.Text = "Wednesday, 13 May 2026 19:04:10";
            this.lblDateTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panelSidebar
            // 
            this.panelSidebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.panelSidebar.Controls.Add(this.btnKelolaAntrian);
            this.panelSidebar.Controls.Add(this.panelSubmenuAntrian);
            this.panelSidebar.Controls.Add(this.btnKelolaPetani);
            this.panelSidebar.Controls.Add(this.panelSubmenuPetani);
            this.panelSidebar.Controls.Add(this.separator1);
            this.panelSidebar.Controls.Add(this.btnProsesGiling);
            this.panelSidebar.Controls.Add(this.btnCatatHasil);
            this.panelSidebar.Controls.Add(this.separator2);
            this.panelSidebar.Controls.Add(this.btnLaporan);
            this.panelSidebar.Controls.Add(this.btnRefresh);
            this.panelSidebar.Controls.Add(this.btnLogout);
            this.panelSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSidebar.Location = new System.Drawing.Point(0, 70);
            this.panelSidebar.Name = "panelSidebar";
            this.panelSidebar.Padding = new System.Windows.Forms.Padding(5);
            this.panelSidebar.Size = new System.Drawing.Size(200, 565);
            this.panelSidebar.TabIndex = 1;
            // 
            // btnKelolaAntrian
            // 
            this.btnKelolaAntrian.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.btnKelolaAntrian.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnKelolaAntrian.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKelolaAntrian.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnKelolaAntrian.ForeColor = System.Drawing.Color.White;
            this.btnKelolaAntrian.Location = new System.Drawing.Point(5, 10);
            this.btnKelolaAntrian.Name = "btnKelolaAntrian";
            this.btnKelolaAntrian.Size = new System.Drawing.Size(185, 35);
            this.btnKelolaAntrian.TabIndex = 0;
            this.btnKelolaAntrian.Text = "📋 Kelola Antrian";
            this.btnKelolaAntrian.UseVisualStyleBackColor = false;
            this.btnKelolaAntrian.Click += new System.EventHandler(this.btnKelolaAntrian_Click);
            // 
            // panelSubmenuAntrian
            // 
            this.panelSubmenuAntrian.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.panelSubmenuAntrian.Controls.Add(this.btnTambahAntrian);
            this.panelSubmenuAntrian.Controls.Add(this.btnEditAntrian);
            this.panelSubmenuAntrian.Controls.Add(this.btnHapusAntrian);
            this.panelSubmenuAntrian.Location = new System.Drawing.Point(5, 45);
            this.panelSubmenuAntrian.Name = "panelSubmenuAntrian";
            this.panelSubmenuAntrian.Size = new System.Drawing.Size(185, 100);
            this.panelSubmenuAntrian.TabIndex = 1;
            this.panelSubmenuAntrian.Visible = false;
            // 
            // btnTambahAntrian
            // 
            this.btnTambahAntrian.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.btnTambahAntrian.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTambahAntrian.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTambahAntrian.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.btnTambahAntrian.ForeColor = System.Drawing.Color.White;
            this.btnTambahAntrian.Location = new System.Drawing.Point(5, 5);
            this.btnTambahAntrian.Name = "btnTambahAntrian";
            this.btnTambahAntrian.Size = new System.Drawing.Size(175, 28);
            this.btnTambahAntrian.TabIndex = 0;
            this.btnTambahAntrian.Text = "➕ Tambah Antrian";
            this.btnTambahAntrian.UseVisualStyleBackColor = false;
            this.btnTambahAntrian.Click += new System.EventHandler(this.btnTambahAntrian_Click);
            // 
            // btnEditAntrian
            // 
            this.btnEditAntrian.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(196)))), ((int)(((byte)(15)))));
            this.btnEditAntrian.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditAntrian.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditAntrian.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.btnEditAntrian.ForeColor = System.Drawing.Color.White;
            this.btnEditAntrian.Location = new System.Drawing.Point(5, 37);
            this.btnEditAntrian.Name = "btnEditAntrian";
            this.btnEditAntrian.Size = new System.Drawing.Size(175, 28);
            this.btnEditAntrian.TabIndex = 1;
            this.btnEditAntrian.Text = "✏️ Edit Antrian";
            this.btnEditAntrian.UseVisualStyleBackColor = false;
            this.btnEditAntrian.Click += new System.EventHandler(this.btnEditAntrian_Click);
            // 
            // btnHapusAntrian
            // 
            this.btnHapusAntrian.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnHapusAntrian.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHapusAntrian.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHapusAntrian.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.btnHapusAntrian.ForeColor = System.Drawing.Color.White;
            this.btnHapusAntrian.Location = new System.Drawing.Point(5, 69);
            this.btnHapusAntrian.Name = "btnHapusAntrian";
            this.btnHapusAntrian.Size = new System.Drawing.Size(175, 28);
            this.btnHapusAntrian.TabIndex = 2;
            this.btnHapusAntrian.Text = "🗑️ Hapus Antrian";
            this.btnHapusAntrian.UseVisualStyleBackColor = false;
            this.btnHapusAntrian.Click += new System.EventHandler(this.btnHapusAntrian_Click);
            // 
            // btnKelolaPetani
            // 
            this.btnKelolaPetani.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.btnKelolaPetani.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnKelolaPetani.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKelolaPetani.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnKelolaPetani.ForeColor = System.Drawing.Color.White;
            this.btnKelolaPetani.Location = new System.Drawing.Point(5, 155);
            this.btnKelolaPetani.Name = "btnKelolaPetani";
            this.btnKelolaPetani.Size = new System.Drawing.Size(185, 35);
            this.btnKelolaPetani.TabIndex = 2;
            this.btnKelolaPetani.Text = "👨‍🌾 Kelola Petani";
            this.btnKelolaPetani.UseVisualStyleBackColor = false;
            this.btnKelolaPetani.Click += new System.EventHandler(this.btnKelolaPetani_Click);
            // 
            // panelSubmenuPetani
            // 
            this.panelSubmenuPetani.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.panelSubmenuPetani.Controls.Add(this.btnTambahPetani);
            this.panelSubmenuPetani.Controls.Add(this.btnEditPetani);
            this.panelSubmenuPetani.Controls.Add(this.btnHapusPetani);
            this.panelSubmenuPetani.Location = new System.Drawing.Point(5, 190);
            this.panelSubmenuPetani.Name = "panelSubmenuPetani";
            this.panelSubmenuPetani.Size = new System.Drawing.Size(185, 100);
            this.panelSubmenuPetani.TabIndex = 3;
            this.panelSubmenuPetani.Visible = false;
            // 
            // btnTambahPetani
            // 
            this.btnTambahPetani.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.btnTambahPetani.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTambahPetani.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTambahPetani.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.btnTambahPetani.ForeColor = System.Drawing.Color.White;
            this.btnTambahPetani.Location = new System.Drawing.Point(5, 5);
            this.btnTambahPetani.Name = "btnTambahPetani";
            this.btnTambahPetani.Size = new System.Drawing.Size(175, 28);
            this.btnTambahPetani.TabIndex = 0;
            this.btnTambahPetani.Text = "➕ Tambah Petani";
            this.btnTambahPetani.UseVisualStyleBackColor = false;
            this.btnTambahPetani.Click += new System.EventHandler(this.btnTambahPetani_Click);
            // 
            // btnEditPetani
            // 
            this.btnEditPetani.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(196)))), ((int)(((byte)(15)))));
            this.btnEditPetani.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditPetani.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditPetani.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.btnEditPetani.ForeColor = System.Drawing.Color.White;
            this.btnEditPetani.Location = new System.Drawing.Point(5, 37);
            this.btnEditPetani.Name = "btnEditPetani";
            this.btnEditPetani.Size = new System.Drawing.Size(175, 28);
            this.btnEditPetani.TabIndex = 1;
            this.btnEditPetani.Text = "✏️ Edit Petani";
            this.btnEditPetani.UseVisualStyleBackColor = false;
            this.btnEditPetani.Click += new System.EventHandler(this.btnEditPetani_Click);
            // 
            // btnHapusPetani
            // 
            this.btnHapusPetani.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnHapusPetani.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHapusPetani.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHapusPetani.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.btnHapusPetani.ForeColor = System.Drawing.Color.White;
            this.btnHapusPetani.Location = new System.Drawing.Point(5, 69);
            this.btnHapusPetani.Name = "btnHapusPetani";
            this.btnHapusPetani.Size = new System.Drawing.Size(175, 28);
            this.btnHapusPetani.TabIndex = 2;
            this.btnHapusPetani.Text = "🗑️ Hapus Petani";
            this.btnHapusPetani.UseVisualStyleBackColor = false;
            this.btnHapusPetani.Click += new System.EventHandler(this.btnHapusPetani_Click);
            // 
            // separator1
            // 
            this.separator1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.separator1.Location = new System.Drawing.Point(5, 300);
            this.separator1.Name = "separator1";
            this.separator1.Size = new System.Drawing.Size(185, 2);
            this.separator1.TabIndex = 4;
            // 
            // btnProsesGiling
            // 
            this.btnProsesGiling.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnProsesGiling.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnProsesGiling.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProsesGiling.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnProsesGiling.ForeColor = System.Drawing.Color.White;
            this.btnProsesGiling.Location = new System.Drawing.Point(5, 310);
            this.btnProsesGiling.Name = "btnProsesGiling";
            this.btnProsesGiling.Size = new System.Drawing.Size(185, 35);
            this.btnProsesGiling.TabIndex = 5;
            this.btnProsesGiling.Text = "⚙️ Proses Antrian";
            this.btnProsesGiling.UseVisualStyleBackColor = false;
            this.btnProsesGiling.Click += new System.EventHandler(this.btnProsesGiling_Click);
            // 
            // btnCatatHasil
            // 
            this.btnCatatHasil.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.btnCatatHasil.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCatatHasil.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCatatHasil.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnCatatHasil.ForeColor = System.Drawing.Color.White;
            this.btnCatatHasil.Location = new System.Drawing.Point(5, 355);
            this.btnCatatHasil.Name = "btnCatatHasil";
            this.btnCatatHasil.Size = new System.Drawing.Size(185, 35);
            this.btnCatatHasil.TabIndex = 6;
            this.btnCatatHasil.Text = "📝 Catat Hasil Giling";
            this.btnCatatHasil.UseVisualStyleBackColor = false;
            this.btnCatatHasil.Click += new System.EventHandler(this.btnCatatHasil_Click);
            // 
            // separator2
            // 
            this.separator2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.separator2.Location = new System.Drawing.Point(5, 400);
            this.separator2.Name = "separator2";
            this.separator2.Size = new System.Drawing.Size(185, 2);
            this.separator2.TabIndex = 7;
            // 
            // btnLaporan
            // 
            this.btnLaporan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(188)))), ((int)(((byte)(156)))));
            this.btnLaporan.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLaporan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLaporan.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnLaporan.ForeColor = System.Drawing.Color.White;
            this.btnLaporan.Location = new System.Drawing.Point(5, 410);
            this.btnLaporan.Name = "btnLaporan";
            this.btnLaporan.Size = new System.Drawing.Size(185, 35);
            this.btnLaporan.TabIndex = 8;
            this.btnLaporan.Text = "📊 Laporan";
            this.btnLaporan.UseVisualStyleBackColor = false;
            this.btnLaporan.Click += new System.EventHandler(this.btnLaporan_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(165)))), ((int)(((byte)(166)))));
            this.btnRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(5, 455);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(185, 35);
            this.btnRefresh.TabIndex = 9;
            this.btnRefresh.Text = "🔄 Refresh";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(57)))), ((int)(((byte)(43)))));
            this.btnLogout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.Location = new System.Drawing.Point(5, 500);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(185, 35);
            this.btnLogout.TabIndex = 10;
            this.btnLogout.Text = "🚪 Logout";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // panelMain
            // 
            this.panelMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.panelMain.Controls.Add(this.tabControlMain);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(200, 70);
            this.panelMain.Name = "panelMain";
            this.panelMain.Padding = new System.Windows.Forms.Padding(10);
            this.panelMain.Size = new System.Drawing.Size(900, 565);
            this.panelMain.TabIndex = 0;
            // 
            // tabControlMain
            // 
            this.tabControlMain.Controls.Add(this.tabPageAntrian);
            this.tabControlMain.Controls.Add(this.tabPagePetani);
            this.tabControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlMain.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.tabControlMain.ItemSize = new System.Drawing.Size(120, 35);
            this.tabControlMain.Location = new System.Drawing.Point(10, 10);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(880, 545);
            this.tabControlMain.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControlMain.TabIndex = 0;
            // 
            // tabPageAntrian
            // 
            this.tabPageAntrian.BackColor = System.Drawing.Color.White;
            this.tabPageAntrian.Controls.Add(this.dgvAntrian);
            this.tabPageAntrian.Controls.Add(this.groupBoxSearch);
            this.tabPageAntrian.Location = new System.Drawing.Point(4, 39);
            this.tabPageAntrian.Name = "tabPageAntrian";
            this.tabPageAntrian.Padding = new System.Windows.Forms.Padding(8);
            this.tabPageAntrian.Size = new System.Drawing.Size(872, 502);
            this.tabPageAntrian.TabIndex = 0;
            this.tabPageAntrian.Text = "📋 Data Antrian";
            // 
            // dgvAntrian
            // 
            this.dgvAntrian.AllowUserToAddRows = false;
            this.dgvAntrian.BackgroundColor = System.Drawing.Color.White;
            this.dgvAntrian.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvAntrian.ColumnHeadersHeight = 35;
            this.dgvAntrian.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAntrian.Location = new System.Drawing.Point(8, 73);
            this.dgvAntrian.MultiSelect = false;
            this.dgvAntrian.Name = "dgvAntrian";
            this.dgvAntrian.ReadOnly = true;
            this.dgvAntrian.RowHeadersWidth = 51;
            this.dgvAntrian.RowTemplate.Height = 30;
            this.dgvAntrian.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAntrian.Size = new System.Drawing.Size(856, 421);
            this.dgvAntrian.TabIndex = 0;
            this.dgvAntrian.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAntrian_CellClick);
            // 
            // groupBoxSearch
            // 
            this.groupBoxSearch.Controls.Add(this.txtSearch);
            this.groupBoxSearch.Controls.Add(this.btnSearch);
            this.groupBoxSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBoxSearch.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.groupBoxSearch.Location = new System.Drawing.Point(8, 8);
            this.groupBoxSearch.Name = "groupBoxSearch";
            this.groupBoxSearch.Padding = new System.Windows.Forms.Padding(8);
            this.groupBoxSearch.Size = new System.Drawing.Size(856, 65);
            this.groupBoxSearch.TabIndex = 1;
            this.groupBoxSearch.TabStop = false;
            this.groupBoxSearch.Text = "🔍 Pencarian Data Antrian";
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtSearch.Location = new System.Drawing.Point(10, 25);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(250, 30);
            this.txtSearch.TabIndex = 0;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(270, 22);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(80, 30);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "🔍 Cari";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // tabPagePetani
            // 
            this.tabPagePetani.BackColor = System.Drawing.Color.White;
            this.tabPagePetani.Controls.Add(this.dgvPetani);
            this.tabPagePetani.Controls.Add(this.groupBoxSearchPetani);
            this.tabPagePetani.Location = new System.Drawing.Point(4, 39);
            this.tabPagePetani.Name = "tabPagePetani";
            this.tabPagePetani.Padding = new System.Windows.Forms.Padding(8);
            this.tabPagePetani.Size = new System.Drawing.Size(172, 37);
            this.tabPagePetani.TabIndex = 1;
            this.tabPagePetani.Text = "👨‍🌾 Data Petani";
            // 
            // dgvPetani
            // 
            this.dgvPetani.AllowUserToAddRows = false;
            this.dgvPetani.BackgroundColor = System.Drawing.Color.White;
            this.dgvPetani.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvPetani.ColumnHeadersHeight = 35;
            this.dgvPetani.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPetani.Location = new System.Drawing.Point(8, 73);
            this.dgvPetani.MultiSelect = false;
            this.dgvPetani.Name = "dgvPetani";
            this.dgvPetani.ReadOnly = true;
            this.dgvPetani.RowHeadersWidth = 51;
            this.dgvPetani.RowTemplate.Height = 30;
            this.dgvPetani.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPetani.Size = new System.Drawing.Size(156, 0);
            this.dgvPetani.TabIndex = 0;
            this.dgvPetani.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPetani_CellClick);
            // 
            // groupBoxSearchPetani
            // 
            this.groupBoxSearchPetani.Controls.Add(this.txtSearchPetani);
            this.groupBoxSearchPetani.Controls.Add(this.btnSearchPetani);
            this.groupBoxSearchPetani.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBoxSearchPetani.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.groupBoxSearchPetani.Location = new System.Drawing.Point(8, 8);
            this.groupBoxSearchPetani.Name = "groupBoxSearchPetani";
            this.groupBoxSearchPetani.Padding = new System.Windows.Forms.Padding(8);
            this.groupBoxSearchPetani.Size = new System.Drawing.Size(156, 65);
            this.groupBoxSearchPetani.TabIndex = 1;
            this.groupBoxSearchPetani.TabStop = false;
            this.groupBoxSearchPetani.Text = "🔍 Pencarian Data Petani";
            // 
            // txtSearchPetani
            // 
            this.txtSearchPetani.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtSearchPetani.Location = new System.Drawing.Point(10, 25);
            this.txtSearchPetani.Name = "txtSearchPetani";
            this.txtSearchPetani.Size = new System.Drawing.Size(250, 30);
            this.txtSearchPetani.TabIndex = 0;
            // 
            // btnSearchPetani
            // 
            this.btnSearchPetani.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnSearchPetani.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearchPetani.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearchPetani.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnSearchPetani.ForeColor = System.Drawing.Color.White;
            this.btnSearchPetani.Location = new System.Drawing.Point(270, 22);
            this.btnSearchPetani.Name = "btnSearchPetani";
            this.btnSearchPetani.Size = new System.Drawing.Size(80, 30);
            this.btnSearchPetani.TabIndex = 1;
            this.btnSearchPetani.Text = "🔍 Cari";
            this.btnSearchPetani.UseVisualStyleBackColor = false;
            this.btnSearchPetani.Click += new System.EventHandler(this.btnSearchPetani_Click);
            // 
            // panelStatus
            // 
            this.panelStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.panelStatus.Controls.Add(this.panelStats);
            this.panelStatus.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelStatus.Location = new System.Drawing.Point(0, 635);
            this.panelStatus.Name = "panelStatus";
            this.panelStatus.Padding = new System.Windows.Forms.Padding(8);
            this.panelStatus.Size = new System.Drawing.Size(1100, 65);
            this.panelStatus.TabIndex = 3;
            // 
            // panelStats
            // 
            this.panelStats.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.panelStats.Controls.Add(this.lblTotalRecord);
            this.panelStats.Controls.Add(this.lblMenunggu);
            this.panelStats.Controls.Add(this.lblDiproses);
            this.panelStats.Controls.Add(this.lblSelesai);
            this.panelStats.Controls.Add(this.lblSelectedInfo);
            this.panelStats.Controls.Add(this.lblSelectedPetaniInfo);
            this.panelStats.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelStats.Location = new System.Drawing.Point(8, 8);
            this.panelStats.Name = "panelStats";
            this.panelStats.Padding = new System.Windows.Forms.Padding(8);
            this.panelStats.Size = new System.Drawing.Size(1084, 49);
            this.panelStats.TabIndex = 0;
            // 
            // lblTotalRecord
            // 
            this.lblTotalRecord.AutoSize = true;
            this.lblTotalRecord.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTotalRecord.ForeColor = System.Drawing.Color.White;
            this.lblTotalRecord.Location = new System.Drawing.Point(10, 8);
            this.lblTotalRecord.Name = "lblTotalRecord";
            this.lblTotalRecord.Size = new System.Drawing.Size(163, 23);
            this.lblTotalRecord.TabIndex = 0;
            this.lblTotalRecord.Text = "📊 Total Antrian: 0";
            // 
            // lblMenunggu
            // 
            this.lblMenunggu.AutoSize = true;
            this.lblMenunggu.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblMenunggu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(196)))), ((int)(((byte)(15)))));
            this.lblMenunggu.Location = new System.Drawing.Point(10, 32);
            this.lblMenunggu.Name = "lblMenunggu";
            this.lblMenunggu.Size = new System.Drawing.Size(128, 20);
            this.lblMenunggu.TabIndex = 1;
            this.lblMenunggu.Text = "⏳ Menunggu: 0";
            // 
            // lblDiproses
            // 
            this.lblDiproses.AutoSize = true;
            this.lblDiproses.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblDiproses.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.lblDiproses.Location = new System.Drawing.Point(120, 32);
            this.lblDiproses.Name = "lblDiproses";
            this.lblDiproses.Size = new System.Drawing.Size(113, 20);
            this.lblDiproses.TabIndex = 2;
            this.lblDiproses.Text = "⚙ Diproses: 0";
            // 
            // lblSelesai
            // 
            this.lblSelesai.AutoSize = true;
            this.lblSelesai.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblSelesai.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.lblSelesai.Location = new System.Drawing.Point(230, 32);
            this.lblSelesai.Name = "lblSelesai";
            this.lblSelesai.Size = new System.Drawing.Size(99, 20);
            this.lblSelesai.TabIndex = 3;
            this.lblSelesai.Text = "✅ Selesai: 0";
            // 
            // lblSelectedInfo
            // 
            this.lblSelectedInfo.AutoSize = true;
            this.lblSelectedInfo.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Italic);
            this.lblSelectedInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(165)))), ((int)(((byte)(166)))));
            this.lblSelectedInfo.Location = new System.Drawing.Point(400, 10);
            this.lblSelectedInfo.Name = "lblSelectedInfo";
            this.lblSelectedInfo.Size = new System.Drawing.Size(226, 19);
            this.lblSelectedInfo.TabIndex = 4;
            this.lblSelectedInfo.Text = "📌 Belum ada data antrian dipilih";
            // 
            // lblSelectedPetaniInfo
            // 
            this.lblSelectedPetaniInfo.AutoSize = true;
            this.lblSelectedPetaniInfo.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Italic);
            this.lblSelectedPetaniInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(165)))), ((int)(((byte)(166)))));
            this.lblSelectedPetaniInfo.Location = new System.Drawing.Point(400, 32);
            this.lblSelectedPetaniInfo.Name = "lblSelectedPetaniInfo";
            this.lblSelectedPetaniInfo.Size = new System.Drawing.Size(220, 19);
            this.lblSelectedPetaniInfo.TabIndex = 5;
            this.lblSelectedPetaniInfo.Text = "👨‍🌾 Belum ada data petani dipilih";
            // 
            // FormUtama
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.ClientSize = new System.Drawing.Size(1100, 700);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panelSidebar);
            this.Controls.Add(this.panelHeader);
            this.Controls.Add(this.panelStatus);
            this.MinimumSize = new System.Drawing.Size(1000, 650);
            this.Name = "FormUtama";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "🌾 Aplikasi Manajemen Antrian Gilingan Padi";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormUtama_FormClosing);
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).EndInit();
            this.panelSidebar.ResumeLayout(false);
            this.panelSubmenuAntrian.ResumeLayout(false);
            this.panelSubmenuPetani.ResumeLayout(false);
            this.panelMain.ResumeLayout(false);
            this.tabControlMain.ResumeLayout(false);
            this.tabPageAntrian.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAntrian)).EndInit();
            this.groupBoxSearch.ResumeLayout(false);
            this.groupBoxSearch.PerformLayout();
            this.tabPagePetani.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPetani)).EndInit();
            this.groupBoxSearchPetani.ResumeLayout(false);
            this.groupBoxSearchPetani.PerformLayout();
            this.panelStatus.ResumeLayout(false);
            this.panelStats.ResumeLayout(false);
            this.panelStats.PerformLayout();
            this.ResumeLayout(false);

        }
    }
}