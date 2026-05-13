using System.Windows.Forms;

namespace AplikasiGilinganPadi
{
    partial class FormLaporan
    {
        private System.ComponentModel.IContainer components = null;
        private TabControl tabControl1;
        private TabPage tabAntrian;
        private TabPage tabHasil;
        private DataGridView dgvLaporanAntrian;
        private DataGridView dgvLaporanHasil;
        private Button btnRefresh;
        private Button btnTutup;
        private Panel panelSummary;
        private Label lblTotalAntrian;
        private Label lblMenunggu;
        private Label lblDiproses;
        private Label lblSelesai;
        private Label lblTotalGabah;
        private Label lblTotalBeras;
        private Label lblTotalDedak;
        private Label lblKonversi;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.tabControl1 = new TabControl();
            this.tabAntrian = new TabPage();
            this.dgvLaporanAntrian = new DataGridView();
            this.tabHasil = new TabPage();
            this.dgvLaporanHasil = new DataGridView();
            this.btnRefresh = new Button();
            this.btnTutup = new Button();
            this.panelSummary = new Panel();
            this.lblTotalAntrian = new Label();
            this.lblMenunggu = new Label();
            this.lblDiproses = new Label();
            this.lblSelesai = new Label();
            this.lblTotalGabah = new Label();
            this.lblTotalBeras = new Label();
            this.lblTotalDedak = new Label();
            this.lblKonversi = new Label();

            // tabControl1
            this.tabControl1.Controls.Add(this.tabAntrian);
            this.tabControl1.Controls.Add(this.tabHasil);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.Size = new System.Drawing.Size(860, 350);
            this.tabControl1.TabIndex = 0;

            // tabAntrian
            this.tabAntrian.Controls.Add(this.dgvLaporanAntrian);
            this.tabAntrian.Location = new System.Drawing.Point(4, 29);
            this.tabAntrian.Name = "tabAntrian";
            this.tabAntrian.Padding = new Padding(3);
            this.tabAntrian.Size = new System.Drawing.Size(852, 317);
            this.tabAntrian.TabIndex = 0;
            this.tabAntrian.Text = "📋 Laporan Antrian";
            this.tabAntrian.UseVisualStyleBackColor = true;

            // dgvLaporanAntrian
            this.dgvLaporanAntrian.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLaporanAntrian.Dock = DockStyle.Fill;
            this.dgvLaporanAntrian.Location = new System.Drawing.Point(3, 3);
            this.dgvLaporanAntrian.Name = "dgvLaporanAntrian";
            this.dgvLaporanAntrian.RowHeadersWidth = 51;
            this.dgvLaporanAntrian.Size = new System.Drawing.Size(846, 311);
            this.dgvLaporanAntrian.TabIndex = 0;
            this.dgvLaporanAntrian.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            // tabHasil
            this.tabHasil.Controls.Add(this.dgvLaporanHasil);
            this.tabHasil.Location = new System.Drawing.Point(4, 29);
            this.tabHasil.Name = "tabHasil";
            this.tabHasil.Padding = new Padding(3);
            this.tabHasil.Size = new System.Drawing.Size(852, 317);
            this.tabHasil.TabIndex = 1;
            this.tabHasil.Text = "📊 Laporan Hasil Giling";
            this.tabHasil.UseVisualStyleBackColor = true;

            // dgvLaporanHasil
            this.dgvLaporanHasil.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLaporanHasil.Dock = DockStyle.Fill;
            this.dgvLaporanHasil.Location = new System.Drawing.Point(3, 3);
            this.dgvLaporanHasil.Name = "dgvLaporanHasil";
            this.dgvLaporanHasil.RowHeadersWidth = 51;
            this.dgvLaporanHasil.Size = new System.Drawing.Size(846, 311);
            this.dgvLaporanHasil.TabIndex = 0;
            this.dgvLaporanHasil.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            // panelSummary
            this.panelSummary.BorderStyle = BorderStyle.FixedSingle;
            this.panelSummary.Controls.Add(this.lblTotalAntrian);
            this.panelSummary.Controls.Add(this.lblMenunggu);
            this.panelSummary.Controls.Add(this.lblDiproses);
            this.panelSummary.Controls.Add(this.lblSelesai);
            this.panelSummary.Controls.Add(this.lblTotalGabah);
            this.panelSummary.Controls.Add(this.lblTotalBeras);
            this.panelSummary.Controls.Add(this.lblTotalDedak);
            this.panelSummary.Controls.Add(this.lblKonversi);
            this.panelSummary.Location = new System.Drawing.Point(12, 370);
            this.panelSummary.Name = "panelSummary";
            this.panelSummary.Size = new System.Drawing.Size(860, 85);
            this.panelSummary.TabIndex = 1;

            // lblTotalAntrian
            this.lblTotalAntrian.AutoSize = true;
            this.lblTotalAntrian.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTotalAntrian.Location = new System.Drawing.Point(10, 10);
            this.lblTotalAntrian.Size = new System.Drawing.Size(130, 20);
            this.lblTotalAntrian.Text = "📊 Total Antrian: 0";

            // lblMenunggu
            this.lblMenunggu.AutoSize = true;
            this.lblMenunggu.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblMenunggu.ForeColor = System.Drawing.Color.FromArgb(241, 196, 15);
            this.lblMenunggu.Location = new System.Drawing.Point(180, 10);
            this.lblMenunggu.Size = new System.Drawing.Size(100, 20);
            this.lblMenunggu.Text = "⏳ Menunggu: 0";

            // lblDiproses
            this.lblDiproses.AutoSize = true;
            this.lblDiproses.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDiproses.ForeColor = System.Drawing.Color.FromArgb(52, 152, 219);
            this.lblDiproses.Location = new System.Drawing.Point(330, 10);
            this.lblDiproses.Size = new System.Drawing.Size(90, 20);
            this.lblDiproses.Text = "⚙ Diproses: 0";

            // lblSelesai
            this.lblSelesai.AutoSize = true;
            this.lblSelesai.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSelesai.ForeColor = System.Drawing.Color.FromArgb(39, 174, 96);
            this.lblSelesai.Location = new System.Drawing.Point(480, 10);
            this.lblSelesai.Size = new System.Drawing.Size(80, 20);
            this.lblSelesai.Text = "✅ Selesai: 0";

            // lblTotalGabah
            this.lblTotalGabah.AutoSize = true;
            this.lblTotalGabah.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTotalGabah.Location = new System.Drawing.Point(10, 35);
            this.lblTotalGabah.Size = new System.Drawing.Size(140, 20);
            this.lblTotalGabah.Text = "🌾 Total Gabah: 0 kg";

            // lblTotalBeras
            this.lblTotalBeras.AutoSize = true;
            this.lblTotalBeras.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTotalBeras.Location = new System.Drawing.Point(180, 35);
            this.lblTotalBeras.Size = new System.Drawing.Size(140, 20);
            this.lblTotalBeras.Text = "🍚 Total Beras: 0 kg";

            // lblTotalDedak
            this.lblTotalDedak.AutoSize = true;
            this.lblTotalDedak.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTotalDedak.Location = new System.Drawing.Point(350, 35);
            this.lblTotalDedak.Size = new System.Drawing.Size(130, 20);
            this.lblTotalDedak.Text = "📦 Total Dedak: 0 kg";

            // lblKonversi
            this.lblKonversi.AutoSize = true;
            this.lblKonversi.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblKonversi.ForeColor = System.Drawing.Color.FromArgb(155, 89, 182);
            this.lblKonversi.Location = new System.Drawing.Point(520, 35);
            this.lblKonversi.Size = new System.Drawing.Size(160, 20);
            this.lblKonversi.Text = "📈 Konversi Beras: 0%";

            // btnRefresh
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(52, 152, 219);
            this.btnRefresh.Cursor = Cursors.Hand;
            this.btnRefresh.FlatStyle = FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(12, 465);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(100, 35);
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Text = "🔄 Refresh";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);

            // btnTutup
            this.btnTutup.BackColor = System.Drawing.Color.FromArgb(231, 76, 60);
            this.btnTutup.Cursor = Cursors.Hand;
            this.btnTutup.FlatStyle = FlatStyle.Flat;
            this.btnTutup.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnTutup.ForeColor = System.Drawing.Color.White;
            this.btnTutup.Location = new System.Drawing.Point(772, 465);
            this.btnTutup.Name = "btnTutup";
            this.btnTutup.Size = new System.Drawing.Size(100, 35);
            this.btnTutup.TabIndex = 3;
            this.btnTutup.Text = "✖ Tutup";
            this.btnTutup.UseVisualStyleBackColor = false;
            this.btnTutup.Click += new System.EventHandler(this.btnTutup_Click);

            // FormLaporan
            this.ClientSize = new System.Drawing.Size(890, 515);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panelSummary);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnTutup);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormLaporan";
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "📊 Laporan - Aplikasi Gilingan Padi";
            this.FormClosing += new FormClosingEventHandler(this.FormLaporan_FormClosing);

            this.tabControl1.ResumeLayout(false);
            this.tabAntrian.ResumeLayout(false);
            this.tabHasil.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLaporanAntrian)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLaporanHasil)).EndInit();
            this.panelSummary.ResumeLayout(false);
            this.panelSummary.PerformLayout();
            this.ResumeLayout(false);
        }
    }
}