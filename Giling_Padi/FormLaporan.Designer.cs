using System.Windows.Forms;

namespace AplikasiGilinganPadi
{
    partial class FormLaporan
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabAntrian;
        private System.Windows.Forms.TabPage tabHasil;
        private System.Windows.Forms.DataGridView dgvLaporanAntrian;
        private System.Windows.Forms.DataGridView dgvLaporanHasil;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnCetak;
        private System.Windows.Forms.Button btnTutup;
        private System.Windows.Forms.Panel panelSummary;
        private System.Windows.Forms.Label lblTotalAntrian;
        private System.Windows.Forms.Label lblMenunggu;
        private System.Windows.Forms.Label lblDiproses;
        private System.Windows.Forms.Label lblSelesai;
        private System.Windows.Forms.Label lblTotalBeras;
        private System.Windows.Forms.Label lblTotalDedak;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabAntrian = new System.Windows.Forms.TabPage();
            this.tabHasil = new System.Windows.Forms.TabPage();
            this.dgvLaporanAntrian = new System.Windows.Forms.DataGridView();
            this.dgvLaporanHasil = new System.Windows.Forms.DataGridView();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnCetak = new System.Windows.Forms.Button();
            this.btnTutup = new System.Windows.Forms.Button();
            this.panelSummary = new System.Windows.Forms.Panel();
            this.lblTotalAntrian = new System.Windows.Forms.Label();
            this.lblMenunggu = new System.Windows.Forms.Label();
            this.lblDiproses = new System.Windows.Forms.Label();
            this.lblSelesai = new System.Windows.Forms.Label();
            this.lblTotalBeras = new System.Windows.Forms.Label();
            this.lblTotalDedak = new System.Windows.Forms.Label();

            this.tabControl1.SuspendLayout();
            this.tabAntrian.SuspendLayout();
            this.tabHasil.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLaporanAntrian)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLaporanHasil)).BeginInit();
            this.panelSummary.SuspendLayout();
            this.SuspendLayout();

            // tabControl1
            this.tabControl1.Controls.Add(this.tabAntrian);
            this.tabControl1.Controls.Add(this.tabHasil);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Size = new System.Drawing.Size(860, 350);
            this.tabControl1.TabIndex = 0;

            // tabAntrian
            this.tabAntrian.Controls.Add(this.dgvLaporanAntrian);
            this.tabAntrian.Text = "Laporan Antrian";
            this.tabAntrian.UseVisualStyleBackColor = true;

            // tabHasil
            this.tabHasil.Controls.Add(this.dgvLaporanHasil);
            this.tabHasil.Text = "Laporan Hasil Giling";
            this.tabHasil.UseVisualStyleBackColor = true;

            // dgvLaporanAntrian
            this.dgvLaporanAntrian.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLaporanAntrian.Dock = DockStyle.Fill;
            this.dgvLaporanAntrian.Location = new System.Drawing.Point(0, 0);
            this.dgvLaporanAntrian.Size = new System.Drawing.Size(858, 322);
            this.dgvLaporanAntrian.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            // dgvLaporanHasil
            this.dgvLaporanHasil.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLaporanHasil.Dock = DockStyle.Fill;
            this.dgvLaporanHasil.Location = new System.Drawing.Point(0, 0);
            this.dgvLaporanHasil.Size = new System.Drawing.Size(858, 322);
            this.dgvLaporanHasil.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            // panelSummary
            this.panelSummary.Controls.Add(this.lblTotalAntrian);
            this.panelSummary.Controls.Add(this.lblMenunggu);
            this.panelSummary.Controls.Add(this.lblDiproses);
            this.panelSummary.Controls.Add(this.lblSelesai);
            this.panelSummary.Controls.Add(this.lblTotalBeras);
            this.panelSummary.Controls.Add(this.lblTotalDedak);
            this.panelSummary.Location = new System.Drawing.Point(12, 370);
            this.panelSummary.Size = new System.Drawing.Size(860, 80);
            this.panelSummary.BorderStyle = BorderStyle.FixedSingle;

            // Labels Summary
            this.lblTotalAntrian.Location = new System.Drawing.Point(10, 10);
            this.lblTotalAntrian.Size = new System.Drawing.Size(150, 20);

            this.lblMenunggu.Location = new System.Drawing.Point(170, 10);
            this.lblMenunggu.Size = new System.Drawing.Size(150, 20);

            this.lblDiproses.Location = new System.Drawing.Point(330, 10);
            this.lblDiproses.Size = new System.Drawing.Size(150, 20);

            this.lblSelesai.Location = new System.Drawing.Point(490, 10);
            this.lblSelesai.Size = new System.Drawing.Size(150, 20);

            this.lblTotalBeras.Location = new System.Drawing.Point(10, 40);
            this.lblTotalBeras.Size = new System.Drawing.Size(200, 20);

            this.lblTotalDedak.Location = new System.Drawing.Point(220, 40);
            this.lblTotalDedak.Size = new System.Drawing.Size(200, 20);

            // Buttons

            this.btnTutup.Location = new System.Drawing.Point(772, 460);
            this.btnTutup.Size = new System.Drawing.Size(100, 35);
            this.btnTutup.Text = "✖ Tutup";
            this.btnTutup.BackColor = System.Drawing.Color.LightCoral;

            // Form
            this.ClientSize = new System.Drawing.Size(890, 510);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panelSummary);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnCetak);
            this.Controls.Add(this.btnTutup);
            this.Text = "Laporan - Gilingan Padi";
            this.StartPosition = FormStartPosition.CenterParent;

            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            this.btnCetak.Click += new System.EventHandler(this.btnCetak_Click);
            this.btnTutup.Click += new System.EventHandler(this.btnTutup_Click);

            this.tabControl1.ResumeLayout(false);
            this.tabAntrian.ResumeLayout(false);
            this.tabHasil.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLaporanAntrian)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLaporanHasil)).EndInit();
            this.panelSummary.ResumeLayout(false);
            this.ResumeLayout(false);
        }
    }
}