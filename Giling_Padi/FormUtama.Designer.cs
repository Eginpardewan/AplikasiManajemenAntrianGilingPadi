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

        // SATU Binding Navigator untuk SEMUA data
        private BindingNavigator bindingNavigator1;
        private ToolStripButton bindingNavigatorAddNewItem;
        private ToolStripLabel bindingNavigatorCountItem;
        private ToolStripButton bindingNavigatorDeleteItem;
        private ToolStripButton bindingNavigatorMoveFirstItem;
        private ToolStripButton bindingNavigatorMovePreviousItem;
        private ToolStripSeparator bindingNavigatorSeparator;
        private ToolStripTextBox bindingNavigatorPositionItem;
        private ToolStripSeparator bindingNavigatorSeparator1;
        private ToolStripButton bindingNavigatorMoveNextItem;
        private ToolStripButton bindingNavigatorMoveLastItem;
        private ToolStripSeparator bindingNavigatorSeparator2;

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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormUtama));

            this.panelHeader = new Panel();
            this.pictureBoxLogo = new PictureBox();
            this.lblTitle = new Label();
            this.lblWelcome = new Label();
            this.lblDateTime = new Label();

            // SATU Binding Navigator Components
            this.bindingNavigator1 = new BindingNavigator(this.components);
            this.bindingNavigatorAddNewItem = new ToolStripButton();
            this.bindingNavigatorCountItem = new ToolStripLabel();
            this.bindingNavigatorDeleteItem = new ToolStripButton();
            this.bindingNavigatorMoveFirstItem = new ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new ToolStripButton();
            this.bindingNavigatorSeparator = new ToolStripSeparator();
            this.bindingNavigatorPositionItem = new ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new ToolStripButton();
            this.bindingNavigatorMoveLastItem = new ToolStripButton();
            this.bindingNavigatorSeparator2 = new ToolStripSeparator();

            this.panelSidebar = new Panel();
            this.btnKelolaAntrian = new Button();
            this.panelSubmenuAntrian = new Panel();
            this.btnTambahAntrian = new Button();
            this.btnEditAntrian = new Button();
            this.btnHapusAntrian = new Button();
            this.btnKelolaPetani = new Button();
            this.panelSubmenuPetani = new Panel();
            this.btnTambahPetani = new Button();
            this.btnEditPetani = new Button();
            this.btnHapusPetani = new Button();
            this.separator1 = new Label();
            this.btnProsesGiling = new Button();
            this.btnCatatHasil = new Button();
            this.separator2 = new Label();
            this.btnLaporan = new Button();
            this.btnRefresh = new Button();
            this.btnLogout = new Button();
            this.panelMain = new Panel();
            this.tabControlMain = new TabControl();
            this.tabPageAntrian = new TabPage();
            this.dgvAntrian = new DataGridView();
            this.groupBoxSearch = new GroupBox();
            this.txtSearch = new TextBox();
            this.btnSearch = new Button();
            this.tabPagePetani = new TabPage();
            this.dgvPetani = new DataGridView();
            this.groupBoxSearchPetani = new GroupBox();
            this.txtSearchPetani = new TextBox();
            this.btnSearchPetani = new Button();
            this.panelStatus = new Panel();
            this.panelStats = new Panel();
            this.lblTotalRecord = new Label();
            this.lblMenunggu = new Label();
            this.lblDiproses = new Label();
            this.lblSelesai = new Label();
            this.lblSelectedInfo = new Label();
            this.lblSelectedPetaniInfo = new Label();

            this.panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
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

            // ========== FORM SETTING ==========
            this.ClientSize = new System.Drawing.Size(1100, 700);
            this.Text = "🌾 Aplikasi Manajemen Antrian Gilingan Padi";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.FromArgb(236, 240, 241);
            this.MinimumSize = new System.Drawing.Size(1000, 650);
            this.FormClosing += new FormClosingEventHandler(this.FormUtama_FormClosing);

            // ========== PANEL HEADER (ATAS) ==========
            this.panelHeader.BackColor = Color.FromArgb(52, 73, 94);
            this.panelHeader.Controls.Add(this.pictureBoxLogo);
            this.panelHeader.Controls.Add(this.lblTitle);
            this.panelHeader.Controls.Add(this.lblWelcome);
            this.panelHeader.Controls.Add(this.lblDateTime);
            this.panelHeader.Dock = DockStyle.Top;
            this.panelHeader.Height = 65;
            this.panelHeader.Padding = new Padding(10, 5, 20, 5);

            this.pictureBoxLogo.BackColor = Color.Transparent;
            this.pictureBoxLogo.Location = new System.Drawing.Point(12, 8);
            this.pictureBoxLogo.Size = new System.Drawing.Size(45, 45);
            this.pictureBoxLogo.SizeMode = PictureBoxSizeMode.StretchImage;
            this.pictureBoxLogo.TabIndex = 0;
            this.pictureBoxLogo.TabStop = false;

            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            this.lblTitle.ForeColor = Color.White;
            this.lblTitle.Location = new System.Drawing.Point(65, 10);
            this.lblTitle.Text = "🌾 Aplikasi Antrian Gilingan Padi";

            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new Font("Segoe UI", 8F);
            this.lblWelcome.ForeColor = Color.FromArgb(200, 200, 200);
            this.lblWelcome.Location = new System.Drawing.Point(65, 35);
            this.lblWelcome.Text = "Selamat Datang, User";

            this.lblDateTime.AutoSize = true;
            this.lblDateTime.Font = new Font("Segoe UI", 8F);
            this.lblDateTime.ForeColor = Color.FromArgb(200, 200, 200);
            this.lblDateTime.Location = new System.Drawing.Point(830, 35);
            this.lblDateTime.TextAlign = ContentAlignment.MiddleRight;
            this.lblDateTime.Text = DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss");

            // ========== SATU BINDING NAVIGATOR ==========
            this.bindingNavigator1.AddNewItem = this.bindingNavigatorAddNewItem;
            this.bindingNavigator1.CountItem = this.bindingNavigatorCountItem;
            this.bindingNavigator1.DeleteItem = this.bindingNavigatorDeleteItem;
            this.bindingNavigator1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.bindingNavigator1.Items.AddRange(new ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.bindingNavigatorAddNewItem,
            this.bindingNavigatorDeleteItem});
            this.bindingNavigator1.Dock = DockStyle.Top;
            this.bindingNavigator1.Location = new System.Drawing.Point(0, 65);
            this.bindingNavigator1.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bindingNavigator1.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bindingNavigator1.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bindingNavigator1.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bindingNavigator1.Name = "bindingNavigator1";
            this.bindingNavigator1.PositionItem = this.bindingNavigatorPositionItem;
            this.bindingNavigator1.Size = new System.Drawing.Size(1100, 31);
            this.bindingNavigator1.TabIndex = 21;
            this.bindingNavigator1.Text = "bindingNavigator1";
            this.bindingNavigator1.Visible = true;

            // Tombol Binding Navigator
            this.bindingNavigatorMoveFirstItem.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.Text = "⏮️";
            this.bindingNavigatorMoveFirstItem.ToolTipText = "Pindah ke data pertama";

            this.bindingNavigatorMovePreviousItem.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.Text = "◀️";
            this.bindingNavigatorMovePreviousItem.ToolTipText = "Pindah ke data sebelumnya";

            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 28);

            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 28);
            this.bindingNavigatorPositionItem.Text = "0";

            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(45, 28);
            this.bindingNavigatorCountItem.Text = "of {0}";

            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 28);

            this.bindingNavigatorMoveNextItem.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.Text = "▶️";
            this.bindingNavigatorMoveNextItem.ToolTipText = "Pindah ke data selanjutnya";

            this.bindingNavigatorMoveLastItem.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.Text = "⏭️";
            this.bindingNavigatorMoveLastItem.ToolTipText = "Pindah ke data terakhir";

            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 28);

            this.bindingNavigatorAddNewItem.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
            this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.Text = "➕";
            this.bindingNavigatorAddNewItem.ToolTipText = "Tambah data baru";
            this.bindingNavigatorAddNewItem.Click += new System.EventHandler(this.bindingNavigatorAddNewItem_Click);

            this.bindingNavigatorDeleteItem.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
            this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.Text = "🗑️";
            this.bindingNavigatorDeleteItem.ToolTipText = "Hapus data yang dipilih";
            this.bindingNavigatorDeleteItem.Click += new System.EventHandler(this.bindingNavigatorDeleteItem_Click);

            // ========== PANEL SIDEBAR (KIRI) ==========
            this.panelSidebar.BackColor = Color.FromArgb(44, 62, 80);
            this.panelSidebar.Dock = DockStyle.Left;
            this.panelSidebar.Width = 170;
            this.panelSidebar.Padding = new Padding(3);

            // btnKelolaAntrian
            this.btnKelolaAntrian.BackColor = Color.FromArgb(41, 128, 185);
            this.btnKelolaAntrian.Cursor = Cursors.Hand;
            this.btnKelolaAntrian.FlatStyle = FlatStyle.Flat;
            this.btnKelolaAntrian.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            this.btnKelolaAntrian.ForeColor = Color.White;
            this.btnKelolaAntrian.Location = new System.Drawing.Point(3, 8);
            this.btnKelolaAntrian.Size = new System.Drawing.Size(160, 30);
            this.btnKelolaAntrian.Text = "📋 Kelola Antrian";
            this.btnKelolaAntrian.UseVisualStyleBackColor = false;
            this.btnKelolaAntrian.Click += new EventHandler(this.btnKelolaAntrian_Click);

            // panelSubmenuAntrian
            this.panelSubmenuAntrian.BackColor = Color.FromArgb(52, 73, 94);
            this.panelSubmenuAntrian.Location = new System.Drawing.Point(3, 38);
            this.panelSubmenuAntrian.Size = new System.Drawing.Size(160, 85);
            this.panelSubmenuAntrian.Visible = false;

            this.btnTambahAntrian.BackColor = Color.FromArgb(39, 174, 96);
            this.btnTambahAntrian.Cursor = Cursors.Hand;
            this.btnTambahAntrian.FlatStyle = FlatStyle.Flat;
            this.btnTambahAntrian.Font = new Font("Segoe UI", 7F, FontStyle.Bold);
            this.btnTambahAntrian.ForeColor = Color.White;
            this.btnTambahAntrian.Location = new System.Drawing.Point(3, 3);
            this.btnTambahAntrian.Size = new System.Drawing.Size(154, 25);
            this.btnTambahAntrian.Text = "➕ Tambah Antrian";
            this.btnTambahAntrian.Click += new EventHandler(this.btnTambahAntrian_Click);

            this.btnEditAntrian.BackColor = Color.FromArgb(241, 196, 15);
            this.btnEditAntrian.Cursor = Cursors.Hand;
            this.btnEditAntrian.FlatStyle = FlatStyle.Flat;
            this.btnEditAntrian.Font = new Font("Segoe UI", 7F, FontStyle.Bold);
            this.btnEditAntrian.ForeColor = Color.White;
            this.btnEditAntrian.Location = new System.Drawing.Point(3, 30);
            this.btnEditAntrian.Size = new System.Drawing.Size(154, 25);
            this.btnEditAntrian.Text = "✏️ Edit Antrian";
            this.btnEditAntrian.Click += new EventHandler(this.btnEditAntrian_Click);

            this.btnHapusAntrian.BackColor = Color.FromArgb(231, 76, 60);
            this.btnHapusAntrian.Cursor = Cursors.Hand;
            this.btnHapusAntrian.FlatStyle = FlatStyle.Flat;
            this.btnHapusAntrian.Font = new Font("Segoe UI", 7F, FontStyle.Bold);
            this.btnHapusAntrian.ForeColor = Color.White;
            this.btnHapusAntrian.Location = new System.Drawing.Point(3, 57);
            this.btnHapusAntrian.Size = new System.Drawing.Size(154, 25);
            this.btnHapusAntrian.Text = "🗑️ Hapus Antrian";
            this.btnHapusAntrian.Click += new EventHandler(this.btnHapusAntrian_Click);

            this.panelSubmenuAntrian.Controls.Add(this.btnTambahAntrian);
            this.panelSubmenuAntrian.Controls.Add(this.btnEditAntrian);
            this.panelSubmenuAntrian.Controls.Add(this.btnHapusAntrian);

            // btnKelolaPetani
            this.btnKelolaPetani.BackColor = Color.FromArgb(41, 128, 185);
            this.btnKelolaPetani.Cursor = Cursors.Hand;
            this.btnKelolaPetani.FlatStyle = FlatStyle.Flat;
            this.btnKelolaPetani.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            this.btnKelolaPetani.ForeColor = Color.White;
            this.btnKelolaPetani.Location = new System.Drawing.Point(3, 128);
            this.btnKelolaPetani.Size = new System.Drawing.Size(160, 30);
            this.btnKelolaPetani.Text = "👨‍🌾 Kelola Petani";
            this.btnKelolaPetani.UseVisualStyleBackColor = false;
            this.btnKelolaPetani.Click += new EventHandler(this.btnKelolaPetani_Click);

            // panelSubmenuPetani
            this.panelSubmenuPetani.BackColor = Color.FromArgb(52, 73, 94);
            this.panelSubmenuPetani.Location = new System.Drawing.Point(3, 158);
            this.panelSubmenuPetani.Size = new System.Drawing.Size(160, 85);
            this.panelSubmenuPetani.Visible = false;

            this.btnTambahPetani.BackColor = Color.FromArgb(39, 174, 96);
            this.btnTambahPetani.Cursor = Cursors.Hand;
            this.btnTambahPetani.FlatStyle = FlatStyle.Flat;
            this.btnTambahPetani.Font = new Font("Segoe UI", 7F, FontStyle.Bold);
            this.btnTambahPetani.ForeColor = Color.White;
            this.btnTambahPetani.Location = new System.Drawing.Point(3, 3);
            this.btnTambahPetani.Size = new System.Drawing.Size(154, 25);
            this.btnTambahPetani.Text = "➕ Tambah Petani";
            this.btnTambahPetani.Click += new EventHandler(this.btnTambahPetani_Click);

            this.btnEditPetani.BackColor = Color.FromArgb(241, 196, 15);
            this.btnEditPetani.Cursor = Cursors.Hand;
            this.btnEditPetani.FlatStyle = FlatStyle.Flat;
            this.btnEditPetani.Font = new Font("Segoe UI", 7F, FontStyle.Bold);
            this.btnEditPetani.ForeColor = Color.White;
            this.btnEditPetani.Location = new System.Drawing.Point(3, 30);
            this.btnEditPetani.Size = new System.Drawing.Size(154, 25);
            this.btnEditPetani.Text = "✏️ Edit Petani";
            this.btnEditPetani.Click += new EventHandler(this.btnEditPetani_Click);

            this.btnHapusPetani.BackColor = Color.FromArgb(231, 76, 60);
            this.btnHapusPetani.Cursor = Cursors.Hand;
            this.btnHapusPetani.FlatStyle = FlatStyle.Flat;
            this.btnHapusPetani.Font = new Font("Segoe UI", 7F, FontStyle.Bold);
            this.btnHapusPetani.ForeColor = Color.White;
            this.btnHapusPetani.Location = new System.Drawing.Point(3, 57);
            this.btnHapusPetani.Size = new System.Drawing.Size(154, 25);
            this.btnHapusPetani.Text = "🗑️ Hapus Petani";
            this.btnHapusPetani.Click += new EventHandler(this.btnHapusPetani_Click);

            this.panelSubmenuPetani.Controls.Add(this.btnTambahPetani);
            this.panelSubmenuPetani.Controls.Add(this.btnEditPetani);
            this.panelSubmenuPetani.Controls.Add(this.btnHapusPetani);

            // separator1
            this.separator1.BackColor = Color.FromArgb(100, 100, 100);
            this.separator1.Location = new System.Drawing.Point(3, 250);
            this.separator1.Size = new System.Drawing.Size(160, 2);

            // btnProsesGiling
            this.btnProsesGiling.BackColor = Color.FromArgb(52, 152, 219);
            this.btnProsesGiling.Cursor = Cursors.Hand;
            this.btnProsesGiling.FlatStyle = FlatStyle.Flat;
            this.btnProsesGiling.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            this.btnProsesGiling.ForeColor = Color.White;
            this.btnProsesGiling.Location = new System.Drawing.Point(3, 258);
            this.btnProsesGiling.Size = new System.Drawing.Size(160, 30);
            this.btnProsesGiling.Text = "⚙️ Proses Antrian";
            this.btnProsesGiling.Click += new EventHandler(this.btnProsesGiling_Click);

            // btnCatatHasil
            this.btnCatatHasil.BackColor = Color.FromArgb(155, 89, 182);
            this.btnCatatHasil.Cursor = Cursors.Hand;
            this.btnCatatHasil.FlatStyle = FlatStyle.Flat;
            this.btnCatatHasil.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            this.btnCatatHasil.ForeColor = Color.White;
            this.btnCatatHasil.Location = new System.Drawing.Point(3, 294);
            this.btnCatatHasil.Size = new System.Drawing.Size(160, 30);
            this.btnCatatHasil.Text = "📝 Catat Hasil";
            this.btnCatatHasil.Click += new EventHandler(this.btnCatatHasil_Click);

            // separator2
            this.separator2.BackColor = Color.FromArgb(100, 100, 100);
            this.separator2.Location = new System.Drawing.Point(3, 330);
            this.separator2.Size = new System.Drawing.Size(160, 2);

            // btnLaporan
            this.btnLaporan.BackColor = Color.FromArgb(26, 188, 156);
            this.btnLaporan.Cursor = Cursors.Hand;
            this.btnLaporan.FlatStyle = FlatStyle.Flat;
            this.btnLaporan.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            this.btnLaporan.ForeColor = Color.White;
            this.btnLaporan.Location = new System.Drawing.Point(3, 338);
            this.btnLaporan.Size = new System.Drawing.Size(160, 30);
            this.btnLaporan.Text = "📊 Laporan";
            this.btnLaporan.Click += new EventHandler(this.btnLaporan_Click);

            // btnRefresh
            this.btnRefresh.BackColor = Color.FromArgb(149, 165, 166);
            this.btnRefresh.Cursor = Cursors.Hand;
            this.btnRefresh.FlatStyle = FlatStyle.Flat;
            this.btnRefresh.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            this.btnRefresh.ForeColor = Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(3, 374);
            this.btnRefresh.Size = new System.Drawing.Size(160, 30);
            this.btnRefresh.Text = "🔄 Refresh";
            this.btnRefresh.Click += new EventHandler(this.btnRefresh_Click);

            // btnLogout
            this.btnLogout.BackColor = Color.FromArgb(192, 57, 43);
            this.btnLogout.Cursor = Cursors.Hand;
            this.btnLogout.FlatStyle = FlatStyle.Flat;
            this.btnLogout.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            this.btnLogout.ForeColor = Color.White;
            this.btnLogout.Location = new System.Drawing.Point(3, 410);
            this.btnLogout.Size = new System.Drawing.Size(160, 30);
            this.btnLogout.Text = "🚪 Logout";
            this.btnLogout.Click += new EventHandler(this.btnLogout_Click);

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

            // ========== PANEL MAIN ==========
            this.panelMain.BackColor = Color.FromArgb(236, 240, 241);
            this.panelMain.Dock = DockStyle.Fill;
            this.panelMain.Padding = new Padding(10);

            this.tabControlMain.Dock = DockStyle.Fill;
            this.tabControlMain.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.tabControlMain.SizeMode = TabSizeMode.Fixed;
            this.tabControlMain.ItemSize = new Size(120, 35);

            // Tab Page Antrian
            this.tabPageAntrian.Text = "📋 Data Antrian";
            this.tabPageAntrian.Padding = new Padding(8);
            this.tabPageAntrian.BackColor = Color.White;

            this.groupBoxSearch.Text = "🔍 Pencarian Data Antrian";
            this.groupBoxSearch.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            this.groupBoxSearch.Dock = DockStyle.Top;
            this.groupBoxSearch.Height = 60;
            this.groupBoxSearch.Padding = new Padding(8);

            this.txtSearch.Font = new Font("Segoe UI", 10F);
            this.txtSearch.Location = new System.Drawing.Point(10, 22);
            this.txtSearch.Size = new System.Drawing.Size(250, 28);

            this.btnSearch.BackColor = Color.FromArgb(52, 152, 219);
            this.btnSearch.Cursor = Cursors.Hand;
            this.btnSearch.FlatStyle = FlatStyle.Flat;
            this.btnSearch.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.btnSearch.ForeColor = Color.White;
            this.btnSearch.Location = new System.Drawing.Point(270, 20);
            this.btnSearch.Size = new System.Drawing.Size(80, 28);
            this.btnSearch.Text = "🔍 Cari";
            this.btnSearch.Click += new EventHandler(this.btnSearch_Click);

            this.groupBoxSearch.Controls.Add(this.txtSearch);
            this.groupBoxSearch.Controls.Add(this.btnSearch);

            this.dgvAntrian.Dock = DockStyle.Fill;
            this.dgvAntrian.BackgroundColor = Color.White;
            this.dgvAntrian.BorderStyle = BorderStyle.Fixed3D;
            this.dgvAntrian.ColumnHeadersHeight = 35;
            this.dgvAntrian.RowTemplate.Height = 30;
            this.dgvAntrian.AllowUserToAddRows = false;
            this.dgvAntrian.ReadOnly = true;
            this.dgvAntrian.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvAntrian.MultiSelect = false;

            this.tabPageAntrian.Controls.Add(this.dgvAntrian);
            this.tabPageAntrian.Controls.Add(this.groupBoxSearch);

            // Tab Page Petani
            this.tabPagePetani.Text = "👨‍🌾 Data Petani";
            this.tabPagePetani.Padding = new Padding(8);
            this.tabPagePetani.BackColor = Color.White;

            this.groupBoxSearchPetani.Text = "🔍 Pencarian Data Petani";
            this.groupBoxSearchPetani.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            this.groupBoxSearchPetani.Dock = DockStyle.Top;
            this.groupBoxSearchPetani.Height = 60;
            this.groupBoxSearchPetani.Padding = new Padding(8);

            this.txtSearchPetani.Font = new Font("Segoe UI", 10F);
            this.txtSearchPetani.Location = new System.Drawing.Point(10, 22);
            this.txtSearchPetani.Size = new System.Drawing.Size(250, 28);

            this.btnSearchPetani.BackColor = Color.FromArgb(52, 152, 219);
            this.btnSearchPetani.Cursor = Cursors.Hand;
            this.btnSearchPetani.FlatStyle = FlatStyle.Flat;
            this.btnSearchPetani.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.btnSearchPetani.ForeColor = Color.White;
            this.btnSearchPetani.Location = new System.Drawing.Point(270, 20);
            this.btnSearchPetani.Size = new System.Drawing.Size(80, 28);
            this.btnSearchPetani.Text = "🔍 Cari";
            this.btnSearchPetani.Click += new EventHandler(this.btnSearchPetani_Click);

            this.groupBoxSearchPetani.Controls.Add(this.txtSearchPetani);
            this.groupBoxSearchPetani.Controls.Add(this.btnSearchPetani);

            this.dgvPetani.Dock = DockStyle.Fill;
            this.dgvPetani.BackgroundColor = Color.White;
            this.dgvPetani.BorderStyle = BorderStyle.Fixed3D;
            this.dgvPetani.ColumnHeadersHeight = 35;
            this.dgvPetani.RowTemplate.Height = 30;
            this.dgvPetani.AllowUserToAddRows = false;
            this.dgvPetani.ReadOnly = true;
            this.dgvPetani.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvPetani.MultiSelect = false;
            this.dgvPetani.CellClick += new DataGridViewCellEventHandler(this.dgvPetani_CellClick);

            this.tabPagePetani.Controls.Add(this.dgvPetani);
            this.tabPagePetani.Controls.Add(this.groupBoxSearchPetani);

            this.tabControlMain.Controls.Add(this.tabPageAntrian);
            this.tabControlMain.Controls.Add(this.tabPagePetani);

            this.panelMain.Controls.Add(this.tabControlMain);

            // ========== PANEL STATUS ==========
            this.panelStatus.BackColor = Color.FromArgb(52, 73, 94);
            this.panelStatus.Dock = DockStyle.Bottom;
            this.panelStatus.Height = 60;
            this.panelStatus.Padding = new Padding(8);

            this.panelStats.BackColor = Color.FromArgb(44, 62, 80);
            this.panelStats.Dock = DockStyle.Fill;
            this.panelStats.Padding = new Padding(8);

            this.lblTotalRecord.AutoSize = true;
            this.lblTotalRecord.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.lblTotalRecord.ForeColor = Color.White;
            this.lblTotalRecord.Location = new System.Drawing.Point(8, 8);
            this.lblTotalRecord.Text = "📊 Total Antrian: 0";

            this.lblMenunggu.AutoSize = true;
            this.lblMenunggu.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            this.lblMenunggu.ForeColor = Color.FromArgb(241, 196, 15);
            this.lblMenunggu.Location = new System.Drawing.Point(8, 30);
            this.lblMenunggu.Text = "⏳ Menunggu: 0";

            this.lblDiproses.AutoSize = true;
            this.lblDiproses.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            this.lblDiproses.ForeColor = Color.FromArgb(52, 152, 219);
            this.lblDiproses.Location = new System.Drawing.Point(100, 30);
            this.lblDiproses.Text = "⚙ Diproses: 0";

            this.lblSelesai.AutoSize = true;
            this.lblSelesai.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            this.lblSelesai.ForeColor = Color.FromArgb(39, 174, 96);
            this.lblSelesai.Location = new System.Drawing.Point(190, 30);
            this.lblSelesai.Text = "✅ Selesai: 0";

            this.lblSelectedInfo.AutoSize = true;
            this.lblSelectedInfo.Font = new Font("Segoe UI", 7F, FontStyle.Italic);
            this.lblSelectedInfo.ForeColor = Color.FromArgb(149, 165, 166);
            this.lblSelectedInfo.Location = new System.Drawing.Point(350, 10);
            this.lblSelectedInfo.Text = "📌 Belum ada data antrian dipilih";

            this.lblSelectedPetaniInfo.AutoSize = true;
            this.lblSelectedPetaniInfo.Font = new Font("Segoe UI", 7F, FontStyle.Italic);
            this.lblSelectedPetaniInfo.ForeColor = Color.FromArgb(149, 165, 166);
            this.lblSelectedPetaniInfo.Location = new System.Drawing.Point(350, 30);
            this.lblSelectedPetaniInfo.Text = "👨‍🌾 Belum ada data petani dipilih";

            this.panelStats.Controls.Add(this.lblTotalRecord);
            this.panelStats.Controls.Add(this.lblMenunggu);
            this.panelStats.Controls.Add(this.lblDiproses);
            this.panelStats.Controls.Add(this.lblSelesai);
            this.panelStats.Controls.Add(this.lblSelectedInfo);
            this.panelStats.Controls.Add(this.lblSelectedPetaniInfo);

            this.panelStatus.Controls.Add(this.panelStats);

            // ========== ADD TO FORM ==========
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panelSidebar);
            this.Controls.Add(this.bindingNavigator1);
            this.Controls.Add(this.panelHeader);
            this.Controls.Add(this.panelStatus);

            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
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
            this.PerformLayout();
        }
    }
}