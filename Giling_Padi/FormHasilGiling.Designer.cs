using System.Windows.Forms;

namespace AplikasiGilinganPadi
{
    partial class FormHasilGiling
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Panel panelButton;

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubTitle;

        private System.Windows.Forms.Label lblNomorAntrian;
        private System.Windows.Forms.Label lblNamaPetani;
        private System.Windows.Forms.Label lblAlamat;
        private System.Windows.Forms.Label lblNoTelepon;
        private System.Windows.Forms.Label lblBeratGabah;
        private System.Windows.Forms.Label lblBerasDihasilkan;
        private System.Windows.Forms.Label lblDedak;
        private System.Windows.Forms.Label lblInfoMaksimal;

        // TAMBAHKAN LABEL STATUS
        private System.Windows.Forms.Label lblInfoBatasBeras;
        private System.Windows.Forms.Label lblInfoBatasDedak;
        private System.Windows.Forms.Label lblStatusBeras;
        private System.Windows.Forms.Label lblStatusDedak;
        private System.Windows.Forms.Label lblStatusTotal;

        private System.Windows.Forms.TextBox txtNomorAntrian;
        private System.Windows.Forms.TextBox txtNamaPetani;
        private System.Windows.Forms.TextBox txtAlamat;
        private System.Windows.Forms.TextBox txtNoTelepon;
        private System.Windows.Forms.TextBox txtBeratGabah;
        private System.Windows.Forms.TextBox txtBerasDihasilkan;
        private System.Windows.Forms.TextBox txtDedak;

        private System.Windows.Forms.Button btnSimpan;
        private System.Windows.Forms.Button btnBatal;

        private System.Windows.Forms.GroupBox groupBoxInfo;
        private System.Windows.Forms.GroupBox groupBoxHasil;

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
            this.groupBoxInfo = new System.Windows.Forms.GroupBox();
            this.groupBoxHasil = new System.Windows.Forms.GroupBox();

            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSubTitle = new System.Windows.Forms.Label();

            this.lblNomorAntrian = new System.Windows.Forms.Label();
            this.lblNamaPetani = new System.Windows.Forms.Label();
            this.lblAlamat = new System.Windows.Forms.Label();
            this.lblNoTelepon = new System.Windows.Forms.Label();
            this.lblBeratGabah = new System.Windows.Forms.Label();
            this.lblBerasDihasilkan = new System.Windows.Forms.Label();
            this.lblDedak = new System.Windows.Forms.Label();
            this.lblInfoMaksimal = new System.Windows.Forms.Label();

            // INISIALISASI LABEL STATUS BARU
            this.lblInfoBatasBeras = new System.Windows.Forms.Label();
            this.lblInfoBatasDedak = new System.Windows.Forms.Label();
            this.lblStatusBeras = new System.Windows.Forms.Label();
            this.lblStatusDedak = new System.Windows.Forms.Label();
            this.lblStatusTotal = new System.Windows.Forms.Label();

            this.txtNomorAntrian = new System.Windows.Forms.TextBox();
            this.txtNamaPetani = new System.Windows.Forms.TextBox();
            this.txtAlamat = new System.Windows.Forms.TextBox();
            this.txtNoTelepon = new System.Windows.Forms.TextBox();
            this.txtBeratGabah = new System.Windows.Forms.TextBox();
            this.txtBerasDihasilkan = new System.Windows.Forms.TextBox();
            this.txtDedak = new System.Windows.Forms.TextBox();

            this.btnSimpan = new System.Windows.Forms.Button();
            this.btnBatal = new System.Windows.Forms.Button();

            this.panelHeader.SuspendLayout();
            this.panelMain.SuspendLayout();
            this.panelButton.SuspendLayout();
            this.groupBoxInfo.SuspendLayout();
            this.groupBoxHasil.SuspendLayout();
            this.SuspendLayout();

            // ========== FORM SETTING ==========
            this.ClientSize = new System.Drawing.Size(550, 580);
            this.Text = "📝 Catat Hasil Giling";
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.BackColor = System.Drawing.Color.FromArgb(236, 240, 241);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);

            // ========== PANEL HEADER ==========
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(52, 73, 94);
            this.panelHeader.Dock = DockStyle.Top;
            this.panelHeader.Height = 75;
            this.panelHeader.Padding = new Padding(15);

            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(15, 12);
            this.lblTitle.Text = "📝 Catat Hasil Giling";

            this.lblSubTitle.AutoSize = true;
            this.lblSubTitle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSubTitle.ForeColor = System.Drawing.Color.FromArgb(200, 200, 200);
            this.lblSubTitle.Location = new System.Drawing.Point(18, 42);
            this.lblSubTitle.Text = "Isi hasil produksi dari proses penggilingan padi";

            this.panelHeader.Controls.Add(this.lblTitle);
            this.panelHeader.Controls.Add(this.lblSubTitle);

            // ========== PANEL MAIN ==========
            this.panelMain.BackColor = System.Drawing.Color.FromArgb(236, 240, 241);
            this.panelMain.Dock = DockStyle.Fill;
            this.panelMain.Padding = new Padding(20);

            // ========== GROUPBOX INFO ANTRIAN ==========
            this.groupBoxInfo.Text = "📋 Informasi Antrian";
            this.groupBoxInfo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.groupBoxInfo.BackColor = System.Drawing.Color.White;
            this.groupBoxInfo.Location = new System.Drawing.Point(20, 20);
            this.groupBoxInfo.Size = new System.Drawing.Size(490, 210);
            this.groupBoxInfo.Padding = new Padding(10);

            // No Antrian
            this.lblNomorAntrian.AutoSize = true;
            this.lblNomorAntrian.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblNomorAntrian.Location = new System.Drawing.Point(15, 32);
            this.lblNomorAntrian.Size = new System.Drawing.Size(77, 20);
            this.lblNomorAntrian.Text = "No Antrian :";

            this.txtNomorAntrian.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtNomorAntrian.Location = new System.Drawing.Point(120, 28);
            this.txtNomorAntrian.Size = new System.Drawing.Size(100, 27);
            this.txtNomorAntrian.ReadOnly = true;
            this.txtNomorAntrian.BackColor = System.Drawing.Color.FromArgb(236, 240, 241);
            this.txtNomorAntrian.BorderStyle = BorderStyle.FixedSingle;

            // Nama Petani
            this.lblNamaPetani.AutoSize = true;
            this.lblNamaPetani.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblNamaPetani.Location = new System.Drawing.Point(15, 68);
            this.lblNamaPetani.Size = new System.Drawing.Size(90, 20);
            this.lblNamaPetani.Text = "Nama Petani :";

            this.txtNamaPetani.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtNamaPetani.Location = new System.Drawing.Point(120, 64);
            this.txtNamaPetani.Size = new System.Drawing.Size(250, 27);
            this.txtNamaPetani.ReadOnly = true;
            this.txtNamaPetani.BackColor = System.Drawing.Color.FromArgb(236, 240, 241);
            this.txtNamaPetani.BorderStyle = BorderStyle.FixedSingle;

            // Alamat
            this.lblAlamat.AutoSize = true;
            this.lblAlamat.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblAlamat.Location = new System.Drawing.Point(15, 104);
            this.lblAlamat.Size = new System.Drawing.Size(58, 20);
            this.lblAlamat.Text = "Alamat :";

            this.txtAlamat.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtAlamat.Location = new System.Drawing.Point(120, 100);
            this.txtAlamat.Size = new System.Drawing.Size(350, 27);
            this.txtAlamat.ReadOnly = true;
            this.txtAlamat.BackColor = System.Drawing.Color.FromArgb(236, 240, 241);
            this.txtAlamat.BorderStyle = BorderStyle.FixedSingle;

            // No Telepon
            this.lblNoTelepon.AutoSize = true;
            this.lblNoTelepon.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblNoTelepon.Location = new System.Drawing.Point(15, 140);
            this.lblNoTelepon.Size = new System.Drawing.Size(80, 20);
            this.lblNoTelepon.Text = "No Telepon :";

            this.txtNoTelepon.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtNoTelepon.Location = new System.Drawing.Point(120, 136);
            this.txtNoTelepon.Size = new System.Drawing.Size(150, 27);
            this.txtNoTelepon.ReadOnly = true;
            this.txtNoTelepon.BackColor = System.Drawing.Color.FromArgb(236, 240, 241);
            this.txtNoTelepon.BorderStyle = BorderStyle.FixedSingle;

            // Berat Gabah
            this.lblBeratGabah.AutoSize = true;
            this.lblBeratGabah.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblBeratGabah.Location = new System.Drawing.Point(15, 176);
            this.lblBeratGabah.Size = new System.Drawing.Size(86, 20);
            this.lblBeratGabah.Text = "Berat Gabah :";

            this.txtBeratGabah.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtBeratGabah.Location = new System.Drawing.Point(120, 172);
            this.txtBeratGabah.Size = new System.Drawing.Size(100, 27);
            this.txtBeratGabah.ReadOnly = true;
            this.txtBeratGabah.BackColor = System.Drawing.Color.FromArgb(236, 240, 241);
            this.txtBeratGabah.BorderStyle = BorderStyle.FixedSingle;

            Label lblKg1 = new Label();
            lblKg1.AutoSize = true;
            lblKg1.Font = new System.Drawing.Font("Segoe UI", 9F);
            lblKg1.Location = new System.Drawing.Point(225, 176);
            lblKg1.Text = "kg";

            this.groupBoxInfo.Controls.Add(this.lblNomorAntrian);
            this.groupBoxInfo.Controls.Add(this.txtNomorAntrian);
            this.groupBoxInfo.Controls.Add(this.lblNamaPetani);
            this.groupBoxInfo.Controls.Add(this.txtNamaPetani);
            this.groupBoxInfo.Controls.Add(this.lblAlamat);
            this.groupBoxInfo.Controls.Add(this.txtAlamat);
            this.groupBoxInfo.Controls.Add(this.lblNoTelepon);
            this.groupBoxInfo.Controls.Add(this.txtNoTelepon);
            this.groupBoxInfo.Controls.Add(this.lblBeratGabah);
            this.groupBoxInfo.Controls.Add(this.txtBeratGabah);
            this.groupBoxInfo.Controls.Add(lblKg1);

            // ========== GROUPBOX HASIL GILING ==========
            this.groupBoxHasil.Text = "📊 Hasil Penggilingan";
            this.groupBoxHasil.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.groupBoxHasil.BackColor = System.Drawing.Color.White;
            this.groupBoxHasil.Location = new System.Drawing.Point(20, 245);
            this.groupBoxHasil.Size = new System.Drawing.Size(490, 210);
            this.groupBoxHasil.Padding = new Padding(10);

            // Beras Dihasilkan
            this.lblBerasDihasilkan.AutoSize = true;
            this.lblBerasDihasilkan.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblBerasDihasilkan.ForeColor = System.Drawing.Color.FromArgb(39, 174, 96);
            this.lblBerasDihasilkan.Location = new System.Drawing.Point(15, 35);
            this.lblBerasDihasilkan.Size = new System.Drawing.Size(124, 23);
            this.lblBerasDihasilkan.Text = "🍚 Beras Dihasilkan :";

            this.txtBerasDihasilkan.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.txtBerasDihasilkan.Location = new System.Drawing.Point(170, 30);
            this.txtBerasDihasilkan.Size = new System.Drawing.Size(130, 32);
            this.txtBerasDihasilkan.BackColor = System.Drawing.Color.White;
            this.txtBerasDihasilkan.TextAlign = HorizontalAlignment.Right;
            this.txtBerasDihasilkan.BorderStyle = BorderStyle.FixedSingle;

            Label lblKg2 = new Label();
            lblKg2.AutoSize = true;
            lblKg2.Font = new System.Drawing.Font("Segoe UI", 10F);
            lblKg2.Location = new System.Drawing.Point(310, 35);
            lblKg2.Text = "kg";

            // INFO BATAS BERAS
            this.lblInfoBatasBeras.AutoSize = true;
            this.lblInfoBatasBeras.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblInfoBatasBeras.ForeColor = System.Drawing.Color.Gray;
            this.lblInfoBatasBeras.Location = new System.Drawing.Point(310, 42);
            this.lblInfoBatasBeras.Text = "Max: 0 kg";

            // STATUS BERAS
            this.lblStatusBeras.AutoSize = true;
            this.lblStatusBeras.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblStatusBeras.Location = new System.Drawing.Point(400, 38);

            // Dedak
            this.lblDedak.AutoSize = true;
            this.lblDedak.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblDedak.ForeColor = System.Drawing.Color.FromArgb(155, 89, 182);
            this.lblDedak.Location = new System.Drawing.Point(15, 85);
            this.lblDedak.Size = new System.Drawing.Size(78, 23);
            this.lblDedak.Text = "🌾 Dedak :";

            this.txtDedak.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.txtDedak.Location = new System.Drawing.Point(170, 80);
            this.txtDedak.Size = new System.Drawing.Size(130, 32);
            this.txtDedak.BackColor = System.Drawing.Color.White;
            this.txtDedak.TextAlign = HorizontalAlignment.Right;
            this.txtDedak.BorderStyle = BorderStyle.FixedSingle;

            Label lblKg3 = new Label();
            lblKg3.AutoSize = true;
            lblKg3.Font = new System.Drawing.Font("Segoe UI", 10F);
            lblKg3.Location = new System.Drawing.Point(310, 85);
            lblKg3.Text = "kg";

            // INFO BATAS DEDAK
            this.lblInfoBatasDedak.AutoSize = true;
            this.lblInfoBatasDedak.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblInfoBatasDedak.ForeColor = System.Drawing.Color.Gray;
            this.lblInfoBatasDedak.Location = new System.Drawing.Point(310, 92);
            this.lblInfoBatasDedak.Text = "Max: 0 kg";

            // STATUS DEDAK
            this.lblStatusDedak.AutoSize = true;
            this.lblStatusDedak.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblStatusDedak.Location = new System.Drawing.Point(400, 88);

            // Label Info Maksimal Total
            this.lblInfoMaksimal.AutoSize = true;
            this.lblInfoMaksimal.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Italic);
            this.lblInfoMaksimal.ForeColor = System.Drawing.Color.FromArgb(231, 76, 60);
            this.lblInfoMaksimal.Location = new System.Drawing.Point(15, 135);
            this.lblInfoMaksimal.Size = new System.Drawing.Size(200, 19);
            this.lblInfoMaksimal.Text = "⚠️ Maksimal total beras + dedak = 0 kg";

            // STATUS TOTAL
            this.lblStatusTotal.AutoSize = true;
            this.lblStatusTotal.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblStatusTotal.Location = new System.Drawing.Point(15, 160);

            this.groupBoxHasil.Controls.Add(this.lblBerasDihasilkan);
            this.groupBoxHasil.Controls.Add(this.txtBerasDihasilkan);
            this.groupBoxHasil.Controls.Add(lblKg2);
            this.groupBoxHasil.Controls.Add(this.lblInfoBatasBeras);
            this.groupBoxHasil.Controls.Add(this.lblStatusBeras);
            this.groupBoxHasil.Controls.Add(this.lblDedak);
            this.groupBoxHasil.Controls.Add(this.txtDedak);
            this.groupBoxHasil.Controls.Add(lblKg3);
            this.groupBoxHasil.Controls.Add(this.lblInfoBatasDedak);
            this.groupBoxHasil.Controls.Add(this.lblStatusDedak);
            this.groupBoxHasil.Controls.Add(this.lblInfoMaksimal);
            this.groupBoxHasil.Controls.Add(this.lblStatusTotal);

            // ========== ADD TO PANEL MAIN ==========
            this.panelMain.Controls.Add(this.groupBoxInfo);
            this.panelMain.Controls.Add(this.groupBoxHasil);

            // ========== PANEL BUTTON ==========
            this.panelButton.BackColor = System.Drawing.Color.FromArgb(236, 240, 241);
            this.panelButton.Dock = DockStyle.Bottom;
            this.panelButton.Height = 65;
            this.panelButton.Padding = new Padding(15);

            this.btnSimpan.BackColor = System.Drawing.Color.FromArgb(39, 174, 96);
            this.btnSimpan.FlatStyle = FlatStyle.Flat;
            this.btnSimpan.ForeColor = System.Drawing.Color.White;
            this.btnSimpan.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSimpan.Location = new System.Drawing.Point(160, 12);
            this.btnSimpan.Size = new System.Drawing.Size(130, 40);
            this.btnSimpan.Text = "💾 Simpan";
            this.btnSimpan.UseVisualStyleBackColor = false;
            this.btnSimpan.Cursor = Cursors.Hand;

            this.btnBatal.BackColor = System.Drawing.Color.FromArgb(231, 76, 60);
            this.btnBatal.FlatStyle = FlatStyle.Flat;
            this.btnBatal.ForeColor = System.Drawing.Color.White;
            this.btnBatal.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnBatal.Location = new System.Drawing.Point(310, 12);
            this.btnBatal.Size = new System.Drawing.Size(130, 40);
            this.btnBatal.Text = "❌ Batal";
            this.btnBatal.UseVisualStyleBackColor = false;
            this.btnBatal.Cursor = Cursors.Hand;

            this.panelButton.Controls.Add(this.btnSimpan);
            this.panelButton.Controls.Add(this.btnBatal);

            // ========== ADD TO FORM ==========
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panelButton);
            this.Controls.Add(this.panelHeader);

            // ========== EVENT HANDLER ==========
            this.btnSimpan.Click += new System.EventHandler(this.btnSimpan_Click);
            this.btnBatal.Click += new System.EventHandler(this.btnBatal_Click);
            this.txtBerasDihasilkan.KeyPress += new KeyPressEventHandler(this.txtBerasDihasilkan_KeyPress);
            this.txtDedak.KeyPress += new KeyPressEventHandler(this.txtDedak_KeyPress);
            this.txtBerasDihasilkan.TextChanged += new System.EventHandler(this.txtBerasDihasilkan_TextChanged);
            this.txtDedak.TextChanged += new System.EventHandler(this.txtDedak_TextChanged);
            this.txtBerasDihasilkan.KeyDown += new KeyEventHandler(this.txtBerasDihasilkan_KeyDown);
            this.txtDedak.KeyDown += new KeyEventHandler(this.txtDedak_KeyDown);
            this.FormClosing += new FormClosingEventHandler(this.FormHasilGiling_FormClosing);

            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panelMain.ResumeLayout(false);
            this.panelButton.ResumeLayout(false);
            this.groupBoxInfo.ResumeLayout(false);
            this.groupBoxInfo.PerformLayout();
            this.groupBoxHasil.ResumeLayout(false);
            this.groupBoxHasil.PerformLayout();
            this.ResumeLayout(false);
        }
    }
}