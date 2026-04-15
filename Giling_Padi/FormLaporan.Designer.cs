using System.Windows.Forms;

namespace AplikasiGilinganPadi
{
    partial class FormLaporan
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Panel panelButton;
        private System.Windows.Forms.Panel panelSummary;

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubTitle;

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabAntrian;
        private System.Windows.Forms.TabPage tabHasil;

        private System.Windows.Forms.DataGridView dgvLaporanAntrian;
        private System.Windows.Forms.DataGridView dgvLaporanHasil;

        private System.Windows.Forms.Label lblTotalAntrian;
        private System.Windows.Forms.Label lblMenunggu;
        private System.Windows.Forms.Label lblDiproses;
        private System.Windows.Forms.Label lblSelesai;
        private System.Windows.Forms.Label lblTotalBeras;
        private System.Windows.Forms.Label lblTotalDedak;

        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnCetak;
        private System.Windows.Forms.Button btnTutup;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.panelHeader = new System.Windows.Forms.Panel();
            this.panelMain = new System.Windows.Forms.Panel();
            this.panelButton = new System.Windows.Forms.Panel();
            this.panelSummary = new System.Windows.Forms.Panel();

            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSubTitle = new System.Windows.Forms.Label();

            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabAntrian = new System.Windows.Forms.TabPage();
            this.tabHasil = new System.Windows.Forms.TabPage();

            this.dgvLaporanAntrian = new System.Windows.Forms.DataGridView();
            this.dgvLaporanHasil = new System.Windows.Forms.DataGridView();

            this.lblTotalAntrian = new System.Windows.Forms.Label();
            this.lblMenunggu = new System.Windows.Forms.Label();
            this.lblDiproses = new System.Windows.Forms.Label();
            this.lblSelesai = new System.Windows.Forms.Label();
            this.lblTotalBeras = new System.Windows.Forms.Label();
            this.lblTotalDedak = new System.Windows.Forms.Label();

            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnCetak = new System.Windows.Forms.Button();
            this.btnTutup = new System.Windows.Forms.Button();

            this.panelHeader.SuspendLayout();
            this.panelMain.SuspendLayout();
            this.panelButton.SuspendLayout();
            this.panelSummary.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabAntrian.SuspendLayout();
            this.tabHasil.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLaporanAntrian)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLaporanHasil)).BeginInit();
            this.SuspendLayout();

            // ========== FORM SETTING ==========
            this.ClientSize = new System.Drawing.Size(1000, 700);
            this.Text = "📊 Laporan - Aplikasi Gilingan Padi";
            this.StartPosition = FormStartPosition.CenterParent;
            this.BackColor = System.Drawing.Color.FromArgb(236, 240, 241);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormLaporan_FormClosing);

            // ========== PANEL HEADER ==========
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(52, 73, 94);
            this.panelHeader.Controls.Add(this.lblTitle);
            this.panelHeader.Controls.Add(this.lblSubTitle);
            this.panelHeader.Dock = DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1000, 80);
            this.panelHeader.TabIndex = 0;

            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(20, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(300, 41);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "📊 Laporan Penggilingan";

            // lblSubTitle
            this.lblSubTitle.AutoSize = true;
            this.lblSubTitle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblSubTitle.ForeColor = System.Drawing.Color.FromArgb(200, 200, 200);
            this.lblSubTitle.Location = new System.Drawing.Point(20, 50);
            this.lblSubTitle.Name = "lblSubTitle";
            this.lblSubTitle.Size = new System.Drawing.Size(250, 23);
            this.lblSubTitle.TabIndex = 1;
            this.lblSubTitle.Text = "Data Antrian dan Hasil Gilingan Padi";

            // ========== PANEL MAIN ==========
            this.panelMain.BackColor = System.Drawing.Color.FromArgb(236, 240, 241);
            this.panelMain.Controls.Add(this.tabControl1);
            this.panelMain.Dock = DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 80);
            this.panelMain.Name = "panelMain";
            this.panelMain.Padding = new Padding(10);
            this.panelMain.Size = new System.Drawing.Size(1000, 500);
            this.panelMain.TabIndex = 1;

            // ========== TAB CONTROL ==========
            this.tabControl1.Controls.Add(this.tabAntrian);
            this.tabControl1.Controls.Add(this.tabHasil);
            this.tabControl1.Dock = DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.tabControl1.Location = new System.Drawing.Point(10, 10);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(980, 480);
            this.tabControl1.TabIndex = 0;

            // ========== TAB ANTRIAN ==========
            this.tabAntrian.Controls.Add(this.dgvLaporanAntrian);
            this.tabAntrian.Location = new System.Drawing.Point(4, 31);
            this.tabAntrian.Name = "tabAntrian";
            this.tabAntrian.Padding = new Padding(3);
            this.tabAntrian.Size = new System.Drawing.Size(972, 445);
            this.tabAntrian.TabIndex = 0;
            this.tabAntrian.Text = "📋 Laporan Antrian";
            this.tabAntrian.UseVisualStyleBackColor = true;

            // dgvLaporanAntrian
            this.dgvLaporanAntrian.BackgroundColor = System.Drawing.Color.White;
            this.dgvLaporanAntrian.BorderStyle = BorderStyle.Fixed3D;
            this.dgvLaporanAntrian.Dock = DockStyle.Fill;
            this.dgvLaporanAntrian.Location = new System.Drawing.Point(3, 3);
            this.dgvLaporanAntrian.Name = "dgvLaporanAntrian";
            this.dgvLaporanAntrian.RowHeadersWidth = 51;
            this.dgvLaporanAntrian.Size = new System.Drawing.Size(966, 439);
            this.dgvLaporanAntrian.TabIndex = 0;
            this.dgvLaporanAntrian.ReadOnly = true;
            this.dgvLaporanAntrian.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // ========== TAB HASIL GILING ==========
            this.tabHasil.Controls.Add(this.dgvLaporanHasil);
            this.tabHasil.Location = new System.Drawing.Point(4, 31);
            this.tabHasil.Name = "tabHasil";
            this.tabHasil.Padding = new Padding(3);
            this.tabHasil.Size = new System.Drawing.Size(972, 445);
            this.tabHasil.TabIndex = 1;
            this.tabHasil.Text = "📊 Laporan Hasil Giling";
            this.tabHasil.UseVisualStyleBackColor = true;

            // dgvLaporanHasil
            this.dgvLaporanHasil.BackgroundColor = System.Drawing.Color.White;
            this.dgvLaporanHasil.BorderStyle = BorderStyle.Fixed3D;
            this.dgvLaporanHasil.Dock = DockStyle.Fill;
            this.dgvLaporanHasil.Location = new System.Drawing.Point(3, 3);
            this.dgvLaporanHasil.Name = "dgvLaporanHasil";
            this.dgvLaporanHasil.RowHeadersWidth = 51;
            this.dgvLaporanHasil.Size = new System.Drawing.Size(966, 439);
            this.dgvLaporanHasil.TabIndex = 0;
            this.dgvLaporanHasil.ReadOnly = true;
            this.dgvLaporanHasil.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // ========== PANEL SUMMARY ==========
            this.panelSummary.BackColor = System.Drawing.Color.FromArgb(44, 62, 80);
            this.panelSummary.Controls.Add(this.lblTotalAntrian);
            this.panelSummary.Controls.Add(this.lblMenunggu);
            this.panelSummary.Controls.Add(this.lblDiproses);
            this.panelSummary.Controls.Add(this.lblSelesai);
            this.panelSummary.Controls.Add(this.lblTotalBeras);
            this.panelSummary.Controls.Add(this.lblTotalDedak);
            this.panelSummary.Dock = DockStyle.Bottom;
            this.panelSummary.Location = new System.Drawing.Point(0, 580);
            this.panelSummary.Name = "panelSummary";
            this.panelSummary.Size = new System.Drawing.Size(1000, 60);
            this.panelSummary.TabIndex = 2;

            // lblTotalAntrian
            this.lblTotalAntrian.AutoSize = true;
            this.lblTotalAntrian.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTotalAntrian.ForeColor = System.Drawing.Color.White;
            this.lblTotalAntrian.Location = new System.Drawing.Point(15, 20);
            this.lblTotalAntrian.Name = "lblTotalAntrian";
            this.lblTotalAntrian.Size = new System.Drawing.Size(163, 23);
            this.lblTotalAntrian.Text = "📊 Total Antrian: 0";

            // lblMenunggu
            this.lblMenunggu.AutoSize = true;
            this.lblMenunggu.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblMenunggu.ForeColor = System.Drawing.Color.FromArgb(241, 196, 15);
            this.lblMenunggu.Location = new System.Drawing.Point(200, 22);
            this.lblMenunggu.Name = "lblMenunggu";
            this.lblMenunggu.Size = new System.Drawing.Size(120, 20);
            this.lblMenunggu.Text = "⏳ Menunggu: 0";

            // lblDiproses
            this.lblDiproses.AutoSize = true;
            this.lblDiproses.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDiproses.ForeColor = System.Drawing.Color.FromArgb(52, 152, 219);
            this.lblDiproses.Location = new System.Drawing.Point(350, 22);
            this.lblDiproses.Name = "lblDiproses";
            this.lblDiproses.Size = new System.Drawing.Size(107, 20);
            this.lblDiproses.Text = "⚙ Diproses: 0";

            // lblSelesai
            this.lblSelesai.AutoSize = true;
            this.lblSelesai.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSelesai.ForeColor = System.Drawing.Color.FromArgb(39, 174, 96);
            this.lblSelesai.Location = new System.Drawing.Point(500, 22);
            this.lblSelesai.Name = "lblSelesai";
            this.lblSelesai.Size = new System.Drawing.Size(95, 20);
            this.lblSelesai.Text = "✅ Selesai: 0";

            // lblTotalBeras
            this.lblTotalBeras.AutoSize = true;
            this.lblTotalBeras.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTotalBeras.ForeColor = System.Drawing.Color.FromArgb(39, 174, 96);
            this.lblTotalBeras.Location = new System.Drawing.Point(650, 22);
            this.lblTotalBeras.Name = "lblTotalBeras";
            this.lblTotalBeras.Size = new System.Drawing.Size(140, 20);
            this.lblTotalBeras.Text = "🍚 Total Beras: 0 kg";

            // lblTotalDedak
            this.lblTotalDedak.AutoSize = true;
            this.lblTotalDedak.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTotalDedak.ForeColor = System.Drawing.Color.FromArgb(155, 89, 182);
            this.lblTotalDedak.Location = new System.Drawing.Point(820, 22);
            this.lblTotalDedak.Name = "lblTotalDedak";
            this.lblTotalDedak.Size = new System.Drawing.Size(140, 20);
            this.lblTotalDedak.Text = "🌾 Total Dedak: 0 kg";

            // ========== PANEL BUTTON ==========
            this.panelButton.BackColor = System.Drawing.Color.FromArgb(236, 240, 241);
            this.panelButton.Controls.Add(this.btnRefresh);
            this.panelButton.Controls.Add(this.btnCetak);
            this.panelButton.Controls.Add(this.btnTutup);
            this.panelButton.Dock = DockStyle.Bottom;
            this.panelButton.Location = new System.Drawing.Point(0, 640);
            this.panelButton.Name = "panelButton";
            this.panelButton.Size = new System.Drawing.Size(1000, 60);
            this.panelButton.TabIndex = 3;

            // btnRefresh
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(52, 152, 219);
            this.btnRefresh.FlatStyle = FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(650, 12);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(100, 35);
            this.btnRefresh.Text = "🔄 Refresh";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Cursor = Cursors.Hand;

            // btnCetak
            this.btnCetak.BackColor = System.Drawing.Color.FromArgb(26, 188, 156);
            this.btnCetak.FlatStyle = FlatStyle.Flat;
            this.btnCetak.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnCetak.ForeColor = System.Drawing.Color.White;
            this.btnCetak.Location = new System.Drawing.Point(760, 12);
            this.btnCetak.Name = "btnCetak";
            this.btnCetak.Size = new System.Drawing.Size(100, 35);
            this.btnCetak.Text = "🖨️ Cetak";
            this.btnCetak.UseVisualStyleBackColor = false;
            this.btnCetak.Cursor = Cursors.Hand;

            // btnTutup
            this.btnTutup.BackColor = System.Drawing.Color.FromArgb(231, 76, 60);
            this.btnTutup.FlatStyle = FlatStyle.Flat;
            this.btnTutup.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnTutup.ForeColor = System.Drawing.Color.White;
            this.btnTutup.Location = new System.Drawing.Point(870, 12);
            this.btnTutup.Name = "btnTutup";
            this.btnTutup.Size = new System.Drawing.Size(100, 35);
            this.btnTutup.Text = "❌ Tutup";
            this.btnTutup.UseVisualStyleBackColor = false;
            this.btnTutup.Cursor = Cursors.Hand;

            // ========== ADD TO FORM ==========
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panelSummary);
            this.Controls.Add(this.panelButton);
            this.Controls.Add(this.panelHeader);

            // ========== EVENT HANDLER ==========
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            this.btnCetak.Click += new System.EventHandler(this.btnCetak_Click);
            this.btnTutup.Click += new System.EventHandler(this.btnTutup_Click);

            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panelMain.ResumeLayout(false);
            this.panelButton.ResumeLayout(false);
            this.panelSummary.ResumeLayout(false);
            this.panelSummary.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabAntrian.ResumeLayout(false);
            this.tabHasil.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLaporanAntrian)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLaporanHasil)).EndInit();
            this.ResumeLayout(false);
        }
    }
}