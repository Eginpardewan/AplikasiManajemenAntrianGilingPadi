using System;
using System.Drawing;
using System.Windows.Forms;

namespace AplikasiGilinganPadi
{
    partial class FormUtama
    {
        private System.ComponentModel.IContainer components = null;

        // Panel Utama
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Panel panelSidebar;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Panel panelStatus;
        private System.Windows.Forms.Panel panelStats;

        // Header Controls
        private System.Windows.Forms.PictureBox pictureBoxLogo;  // TAMBAHKAN
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Label lblDateTime;

        // Sidebar Buttons - Menu Utama
        private System.Windows.Forms.Button btnKelolaAntrian;
        private System.Windows.Forms.Button btnProsesGiling;
        private System.Windows.Forms.Button btnCatatHasil;
        private System.Windows.Forms.Button btnLaporan;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnLogout;

        // Submenu Kelola Antrian
        private System.Windows.Forms.Panel panelSubmenuAntrian;
        private System.Windows.Forms.Button btnTambahAntrian;
        private System.Windows.Forms.Button btnEditAntrian;
        private System.Windows.Forms.Button btnHapusAntrian;

        // Main Area Controls
        private System.Windows.Forms.GroupBox groupBoxSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DataGridView dgvAntrian;

        // Status Panel Controls
        private System.Windows.Forms.Label lblTotalRecord;
        private System.Windows.Forms.Label lblMenunggu;
        private System.Windows.Forms.Label lblDiproses;
        private System.Windows.Forms.Label lblSelesai;
        private System.Windows.Forms.Label lblSelectedInfo;

        // Separators
        private System.Windows.Forms.Label separator1;
        private System.Windows.Forms.Label separator2;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.panelHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.lblDateTime = new System.Windows.Forms.Label();
            this.panelSidebar = new System.Windows.Forms.Panel();
            this.btnKelolaAntrian = new System.Windows.Forms.Button();
            this.panelSubmenuAntrian = new System.Windows.Forms.Panel();
            this.btnTambahAntrian = new System.Windows.Forms.Button();
            this.btnEditAntrian = new System.Windows.Forms.Button();
            this.btnHapusAntrian = new System.Windows.Forms.Button();
            this.separator1 = new System.Windows.Forms.Label();
            this.btnProsesGiling = new System.Windows.Forms.Button();
            this.btnCatatHasil = new System.Windows.Forms.Button();
            this.separator2 = new System.Windows.Forms.Label();
            this.btnLaporan = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.panelMain = new System.Windows.Forms.Panel();
            this.groupBoxSearch = new System.Windows.Forms.GroupBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.dgvAntrian = new System.Windows.Forms.DataGridView();
            this.panelStatus = new System.Windows.Forms.Panel();
            this.panelStats = new System.Windows.Forms.Panel();
            this.lblTotalRecord = new System.Windows.Forms.Label();
            this.lblMenunggu = new System.Windows.Forms.Label();
            this.lblDiproses = new System.Windows.Forms.Label();
            this.lblSelesai = new System.Windows.Forms.Label();
            this.lblSelectedInfo = new System.Windows.Forms.Label();
            this.pictureBoxLogo = new System.Windows.Forms.PictureBox();
            this.panelHeader.SuspendLayout();
            this.panelSidebar.SuspendLayout();
            this.panelSubmenuAntrian.SuspendLayout();
            this.panelMain.SuspendLayout();
            this.groupBoxSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAntrian)).BeginInit();
            this.panelStatus.SuspendLayout();
            this.panelStats.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).BeginInit();
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
            this.panelHeader.Size = new System.Drawing.Size(1000, 80);
            this.panelHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(80, 12);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(526, 37);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Aplikasi Menejeman Antrian Giling Padi";
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblWelcome.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.lblWelcome.Location = new System.Drawing.Point(80, 45);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(152, 20);
            this.lblWelcome.TabIndex = 1;
            this.lblWelcome.Text = "Selamat Datang, User";
            // 
            // lblDateTime
            // 
            this.lblDateTime.AutoSize = true;
            this.lblDateTime.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDateTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.lblDateTime.Location = new System.Drawing.Point(680, 45);
            this.lblDateTime.Name = "lblDateTime";
            this.lblDateTime.Size = new System.Drawing.Size(238, 20);
            this.lblDateTime.TabIndex = 2;
            this.lblDateTime.Text = "Wednesday, 15 April 2026 17:41:15";
            // 
            // panelSidebar
            // 
            this.panelSidebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.panelSidebar.Controls.Add(this.btnKelolaAntrian);
            this.panelSidebar.Controls.Add(this.panelSubmenuAntrian);
            this.panelSidebar.Controls.Add(this.separator1);
            this.panelSidebar.Controls.Add(this.btnProsesGiling);
            this.panelSidebar.Controls.Add(this.btnCatatHasil);
            this.panelSidebar.Controls.Add(this.separator2);
            this.panelSidebar.Controls.Add(this.btnLaporan);
            this.panelSidebar.Controls.Add(this.btnRefresh);
            this.panelSidebar.Controls.Add(this.btnLogout);
            this.panelSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSidebar.Location = new System.Drawing.Point(0, 80);
            this.panelSidebar.Name = "panelSidebar";
            this.panelSidebar.Size = new System.Drawing.Size(220, 530);
            this.panelSidebar.TabIndex = 1;
            // 
            // btnKelolaAntrian
            // 
            this.btnKelolaAntrian.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.btnKelolaAntrian.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnKelolaAntrian.Enabled = false;
            this.btnKelolaAntrian.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKelolaAntrian.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnKelolaAntrian.ForeColor = System.Drawing.Color.White;
            this.btnKelolaAntrian.Location = new System.Drawing.Point(15, 20);
            this.btnKelolaAntrian.Name = "btnKelolaAntrian";
            this.btnKelolaAntrian.Size = new System.Drawing.Size(190, 45);
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
            this.panelSubmenuAntrian.Location = new System.Drawing.Point(15, 70);
            this.panelSubmenuAntrian.Name = "panelSubmenuAntrian";
            this.panelSubmenuAntrian.Size = new System.Drawing.Size(190, 135);
            this.panelSubmenuAntrian.TabIndex = 1;
            this.panelSubmenuAntrian.Visible = false;
            // 
            // btnTambahAntrian
            // 
            this.btnTambahAntrian.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.btnTambahAntrian.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTambahAntrian.Enabled = false;
            this.btnTambahAntrian.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTambahAntrian.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnTambahAntrian.ForeColor = System.Drawing.Color.White;
            this.btnTambahAntrian.Location = new System.Drawing.Point(5, 5);
            this.btnTambahAntrian.Name = "btnTambahAntrian";
            this.btnTambahAntrian.Size = new System.Drawing.Size(180, 38);
            this.btnTambahAntrian.TabIndex = 0;
            this.btnTambahAntrian.Text = "➕ Tambah Antrian";
            this.btnTambahAntrian.UseVisualStyleBackColor = false;
            this.btnTambahAntrian.Click += new System.EventHandler(this.btnTambahAntrian_Click);
            // 
            // btnEditAntrian
            // 
            this.btnEditAntrian.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(196)))), ((int)(((byte)(15)))));
            this.btnEditAntrian.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditAntrian.Enabled = false;
            this.btnEditAntrian.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditAntrian.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnEditAntrian.ForeColor = System.Drawing.Color.White;
            this.btnEditAntrian.Location = new System.Drawing.Point(5, 48);
            this.btnEditAntrian.Name = "btnEditAntrian";
            this.btnEditAntrian.Size = new System.Drawing.Size(180, 38);
            this.btnEditAntrian.TabIndex = 1;
            this.btnEditAntrian.Text = "✏️ Edit Antrian";
            this.btnEditAntrian.UseVisualStyleBackColor = false;
            this.btnEditAntrian.Click += new System.EventHandler(this.btnEditAntrian_Click);
            // 
            // btnHapusAntrian
            // 
            this.btnHapusAntrian.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnHapusAntrian.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHapusAntrian.Enabled = false;
            this.btnHapusAntrian.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHapusAntrian.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnHapusAntrian.ForeColor = System.Drawing.Color.White;
            this.btnHapusAntrian.Location = new System.Drawing.Point(5, 91);
            this.btnHapusAntrian.Name = "btnHapusAntrian";
            this.btnHapusAntrian.Size = new System.Drawing.Size(180, 38);
            this.btnHapusAntrian.TabIndex = 2;
            this.btnHapusAntrian.Text = "🗑️ Hapus Antrian";
            this.btnHapusAntrian.UseVisualStyleBackColor = false;
            this.btnHapusAntrian.Click += new System.EventHandler(this.btnHapusAntrian_Click);
            // 
            // separator1
            // 
            this.separator1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.separator1.Location = new System.Drawing.Point(15, 210);
            this.separator1.Name = "separator1";
            this.separator1.Size = new System.Drawing.Size(190, 2);
            this.separator1.TabIndex = 2;
            // 
            // btnProsesGiling
            // 
            this.btnProsesGiling.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnProsesGiling.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnProsesGiling.Enabled = false;
            this.btnProsesGiling.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProsesGiling.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnProsesGiling.ForeColor = System.Drawing.Color.White;
            this.btnProsesGiling.Location = new System.Drawing.Point(15, 225);
            this.btnProsesGiling.Name = "btnProsesGiling";
            this.btnProsesGiling.Size = new System.Drawing.Size(190, 45);
            this.btnProsesGiling.TabIndex = 3;
            this.btnProsesGiling.Text = "⚙️ Proses Antrian";
            this.btnProsesGiling.UseVisualStyleBackColor = false;
            this.btnProsesGiling.Click += new System.EventHandler(this.btnProsesGiling_Click);
            // 
            // btnCatatHasil
            // 
            this.btnCatatHasil.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.btnCatatHasil.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCatatHasil.Enabled = false;
            this.btnCatatHasil.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCatatHasil.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnCatatHasil.ForeColor = System.Drawing.Color.White;
            this.btnCatatHasil.Location = new System.Drawing.Point(15, 280);
            this.btnCatatHasil.Name = "btnCatatHasil";
            this.btnCatatHasil.Size = new System.Drawing.Size(190, 45);
            this.btnCatatHasil.TabIndex = 4;
            this.btnCatatHasil.Text = "📝 Catat Hasil";
            this.btnCatatHasil.UseVisualStyleBackColor = false;
            this.btnCatatHasil.Click += new System.EventHandler(this.btnCatatHasil_Click);
            // 
            // separator2
            // 
            this.separator2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.separator2.Location = new System.Drawing.Point(15, 340);
            this.separator2.Name = "separator2";
            this.separator2.Size = new System.Drawing.Size(190, 2);
            this.separator2.TabIndex = 5;
            // 
            // btnLaporan
            // 
            this.btnLaporan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(188)))), ((int)(((byte)(156)))));
            this.btnLaporan.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLaporan.Enabled = false;
            this.btnLaporan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLaporan.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnLaporan.ForeColor = System.Drawing.Color.White;
            this.btnLaporan.Location = new System.Drawing.Point(15, 355);
            this.btnLaporan.Name = "btnLaporan";
            this.btnLaporan.Size = new System.Drawing.Size(190, 45);
            this.btnLaporan.TabIndex = 6;
            this.btnLaporan.Text = "📊 Laporan";
            this.btnLaporan.UseVisualStyleBackColor = false;
            this.btnLaporan.Click += new System.EventHandler(this.btnLaporan_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(165)))), ((int)(((byte)(166)))));
            this.btnRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefresh.Enabled = false;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(15, 410);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(190, 45);
            this.btnRefresh.TabIndex = 7;
            this.btnRefresh.Text = "🔄 Refresh";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(57)))), ((int)(((byte)(43)))));
            this.btnLogout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.Location = new System.Drawing.Point(15, 465);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(190, 45);
            this.btnLogout.TabIndex = 8;
            this.btnLogout.Text = "🚪 Logout";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // panelMain
            // 
            this.panelMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.panelMain.Controls.Add(this.groupBoxSearch);
            this.panelMain.Controls.Add(this.dgvAntrian);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(220, 80);
            this.panelMain.Name = "panelMain";
            this.panelMain.Padding = new System.Windows.Forms.Padding(10);
            this.panelMain.Size = new System.Drawing.Size(780, 530);
            this.panelMain.TabIndex = 3;
            // 
            // groupBoxSearch
            // 
            this.groupBoxSearch.BackColor = System.Drawing.Color.White;
            this.groupBoxSearch.Controls.Add(this.txtSearch);
            this.groupBoxSearch.Controls.Add(this.btnSearch);
            this.groupBoxSearch.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.groupBoxSearch.Location = new System.Drawing.Point(10, 10);
            this.groupBoxSearch.Name = "groupBoxSearch";
            this.groupBoxSearch.Size = new System.Drawing.Size(750, 70);
            this.groupBoxSearch.TabIndex = 0;
            this.groupBoxSearch.TabStop = false;
            this.groupBoxSearch.Text = "🔍 Pencarian Data";
            // 
            // txtSearch
            // 
            this.txtSearch.Enabled = false;
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtSearch.Location = new System.Drawing.Point(15, 30);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(300, 30);
            this.txtSearch.TabIndex = 0;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearch.Enabled = false;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(325, 27);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(100, 30);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "🔍 Cari";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // dgvAntrian
            // 
            this.dgvAntrian.BackgroundColor = System.Drawing.Color.White;
            this.dgvAntrian.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvAntrian.ColumnHeadersHeight = 29;
            this.dgvAntrian.Location = new System.Drawing.Point(10, 90);
            this.dgvAntrian.Name = "dgvAntrian";
            this.dgvAntrian.RowHeadersWidth = 51;
            this.dgvAntrian.Size = new System.Drawing.Size(750, 420);
            this.dgvAntrian.TabIndex = 1;
            this.dgvAntrian.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAntrian_CellClick);
            // 
            // panelStatus
            // 
            this.panelStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.panelStatus.Controls.Add(this.panelStats);
            this.panelStatus.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelStatus.Location = new System.Drawing.Point(0, 610);
            this.panelStatus.Name = "panelStatus";
            this.panelStatus.Size = new System.Drawing.Size(1000, 90);
            this.panelStatus.TabIndex = 5;
            // 
            // panelStats
            // 
            this.panelStats.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.panelStats.Controls.Add(this.lblTotalRecord);
            this.panelStats.Controls.Add(this.lblMenunggu);
            this.panelStats.Controls.Add(this.lblDiproses);
            this.panelStats.Controls.Add(this.lblSelesai);
            this.panelStats.Controls.Add(this.lblSelectedInfo);
            this.panelStats.Location = new System.Drawing.Point(10, 10);
            this.panelStats.Name = "panelStats";
            this.panelStats.Size = new System.Drawing.Size(980, 70);
            this.panelStats.TabIndex = 0;
            // 
            // lblTotalRecord
            // 
            this.lblTotalRecord.AutoSize = true;
            this.lblTotalRecord.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTotalRecord.ForeColor = System.Drawing.Color.White;
            this.lblTotalRecord.Location = new System.Drawing.Point(15, 10);
            this.lblTotalRecord.Name = "lblTotalRecord";
            this.lblTotalRecord.Size = new System.Drawing.Size(163, 23);
            this.lblTotalRecord.TabIndex = 0;
            this.lblTotalRecord.Text = "📊 Total Antrian: 0";
            // 
            // lblMenunggu
            // 
            this.lblMenunggu.AutoSize = true;
            this.lblMenunggu.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblMenunggu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(196)))), ((int)(((byte)(15)))));
            this.lblMenunggu.Location = new System.Drawing.Point(15, 35);
            this.lblMenunggu.Name = "lblMenunggu";
            this.lblMenunggu.Size = new System.Drawing.Size(120, 20);
            this.lblMenunggu.TabIndex = 1;
            this.lblMenunggu.Text = "⏳ Menunggu: 0";
            // 
            // lblDiproses
            // 
            this.lblDiproses.AutoSize = true;
            this.lblDiproses.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDiproses.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.lblDiproses.Location = new System.Drawing.Point(150, 35);
            this.lblDiproses.Name = "lblDiproses";
            this.lblDiproses.Size = new System.Drawing.Size(107, 20);
            this.lblDiproses.TabIndex = 2;
            this.lblDiproses.Text = "⚙ Diproses: 0";
            // 
            // lblSelesai
            // 
            this.lblSelesai.AutoSize = true;
            this.lblSelesai.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSelesai.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.lblSelesai.Location = new System.Drawing.Point(280, 35);
            this.lblSelesai.Name = "lblSelesai";
            this.lblSelesai.Size = new System.Drawing.Size(95, 20);
            this.lblSelesai.TabIndex = 3;
            this.lblSelesai.Text = "✅ Selesai: 0";
            // 
            // lblSelectedInfo
            // 
            this.lblSelectedInfo.AutoSize = true;
            this.lblSelectedInfo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
            this.lblSelectedInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(165)))), ((int)(((byte)(166)))));
            this.lblSelectedInfo.Location = new System.Drawing.Point(450, 25);
            this.lblSelectedInfo.Name = "lblSelectedInfo";
            this.lblSelectedInfo.Size = new System.Drawing.Size(180, 20);
            this.lblSelectedInfo.TabIndex = 4;
            this.lblSelectedInfo.Text = "📌 Belum ada data dipilih";
            // 
            // pictureBoxLogo
            // 
            this.pictureBoxLogo.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxLogo.Image = global::Giling_Padi.Properties.Resources.logo;
            this.pictureBoxLogo.Location = new System.Drawing.Point(15, 12);
            this.pictureBoxLogo.Name = "pictureBoxLogo";
            this.pictureBoxLogo.Size = new System.Drawing.Size(55, 55);
            this.pictureBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxLogo.TabIndex = 0;
            this.pictureBoxLogo.TabStop = false;
            // 
            // FormUtama
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.ClientSize = new System.Drawing.Size(1000, 700);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panelSidebar);
            this.Controls.Add(this.panelHeader);
            this.Controls.Add(this.panelStatus);
            this.Name = "FormUtama";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "🌾 Aplikasi Manajemen Antrian Gilingan Padi";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormUtama_FormClosing);
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panelSidebar.ResumeLayout(false);
            this.panelSubmenuAntrian.ResumeLayout(false);
            this.panelMain.ResumeLayout(false);
            this.groupBoxSearch.ResumeLayout(false);
            this.groupBoxSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAntrian)).EndInit();
            this.panelStatus.ResumeLayout(false);
            this.panelStats.ResumeLayout(false);
            this.panelStats.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).EndInit();
            this.ResumeLayout(false);

        }
    }
}