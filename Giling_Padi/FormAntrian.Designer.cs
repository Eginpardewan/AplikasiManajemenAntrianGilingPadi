using System.Windows.Forms;

namespace AplikasiGilinganPadi
{
    partial class FormAntrian
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblNomorAntrian;
        private System.Windows.Forms.Label lblNamaPetani;
        private System.Windows.Forms.Label lblAlamat;
        private System.Windows.Forms.Label lblNoTelepon;
        private System.Windows.Forms.Label lblBeratGabah;
        private System.Windows.Forms.Label lblTanggal;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.TextBox txtNomorAntrian;
        private System.Windows.Forms.TextBox txtNamaPetani;
        private System.Windows.Forms.TextBox txtAlamat;
        private System.Windows.Forms.TextBox txtNoTelepon;
        private System.Windows.Forms.TextBox txtBeratGabah;
        private System.Windows.Forms.DateTimePicker dtpTanggal;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Button btnSimpan;
        private System.Windows.Forms.Button btnBatal;
        private System.Windows.Forms.ToolTip toolTipInfo;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblNomorAntrian = new System.Windows.Forms.Label();
            this.lblNamaPetani = new System.Windows.Forms.Label();
            this.lblAlamat = new System.Windows.Forms.Label();
            this.lblNoTelepon = new System.Windows.Forms.Label();
            this.lblBeratGabah = new System.Windows.Forms.Label();
            this.lblTanggal = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.txtNomorAntrian = new System.Windows.Forms.TextBox();
            this.txtNamaPetani = new System.Windows.Forms.TextBox();
            this.txtAlamat = new System.Windows.Forms.TextBox();
            this.txtNoTelepon = new System.Windows.Forms.TextBox();
            this.txtBeratGabah = new System.Windows.Forms.TextBox();
            this.dtpTanggal = new System.Windows.Forms.DateTimePicker();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.btnSimpan = new System.Windows.Forms.Button();
            this.btnBatal = new System.Windows.Forms.Button();
            this.toolTipInfo = new System.Windows.Forms.ToolTip();
            this.SuspendLayout();

            // ========== FORM SETTING ==========
            this.ClientSize = new System.Drawing.Size(480, 420);
            this.Text = "Form Antrian";
            this.StartPosition = FormStartPosition.CenterParent;
            this.BackColor = System.Drawing.Color.White;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormAntrian_FormClosing);

            // ========== NO ANTRIAN ==========
            this.lblNomorAntrian.AutoSize = true;
            this.lblNomorAntrian.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblNomorAntrian.Location = new System.Drawing.Point(30, 30);
            this.lblNomorAntrian.Text = "No Antrian :";

            this.txtNomorAntrian.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtNomorAntrian.Location = new System.Drawing.Point(150, 27);
            this.txtNomorAntrian.Size = new System.Drawing.Size(100, 28);
            this.txtNomorAntrian.ReadOnly = true;
            this.txtNomorAntrian.BackColor = System.Drawing.Color.FromArgb(236, 240, 241);

            // ========== NAMA PETANI ==========
            this.lblNamaPetani.AutoSize = true;
            this.lblNamaPetani.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblNamaPetani.Location = new System.Drawing.Point(30, 70);
            this.lblNamaPetani.Text = "Nama Petani :";

            this.txtNamaPetani.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtNamaPetani.Location = new System.Drawing.Point(150, 67);
            this.txtNamaPetani.Size = new System.Drawing.Size(280, 28);

            // ========== ALAMAT ==========
            this.lblAlamat.AutoSize = true;
            this.lblAlamat.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblAlamat.Location = new System.Drawing.Point(30, 110);
            this.lblAlamat.Text = "Alamat :";

            this.txtAlamat.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtAlamat.Location = new System.Drawing.Point(150, 107);
            this.txtAlamat.Size = new System.Drawing.Size(280, 28);

            // ========== NO TELEPON ==========
            this.lblNoTelepon.AutoSize = true;
            this.lblNoTelepon.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblNoTelepon.Location = new System.Drawing.Point(30, 150);
            this.lblNoTelepon.Text = "No Telepon :";

            this.txtNoTelepon.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtNoTelepon.Location = new System.Drawing.Point(150, 147);
            this.txtNoTelepon.Size = new System.Drawing.Size(180, 28);

            // ========== BERAT GABAH ==========
            this.lblBeratGabah.AutoSize = true;
            this.lblBeratGabah.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblBeratGabah.Location = new System.Drawing.Point(30, 190);
            this.lblBeratGabah.Text = "Berat Gabah :";

            this.txtBeratGabah.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtBeratGabah.Location = new System.Drawing.Point(150, 187);
            this.txtBeratGabah.Size = new System.Drawing.Size(120, 28);

            Label lblKg = new Label();
            lblKg.AutoSize = true;
            lblKg.Font = new System.Drawing.Font("Segoe UI", 9F);
            lblKg.Location = new System.Drawing.Point(280, 190);
            lblKg.Text = "kg";

            // ========== TANGGAL (TANPA MinDate/MaxDate - SEMUA TANGGAL TERLIHAT) ==========
            this.lblTanggal.AutoSize = true;
            this.lblTanggal.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTanggal.Location = new System.Drawing.Point(30, 230);
            this.lblTanggal.Text = "Tanggal :";

            this.dtpTanggal.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpTanggal.Location = new System.Drawing.Point(150, 227);
            this.dtpTanggal.Size = new System.Drawing.Size(250, 28);
            this.dtpTanggal.Format = DateTimePickerFormat.Short;
            // TIDAK ADA MinDate dan MaxDate - semua tanggal terlihat!

            // Tooltip untuk informasi
            this.toolTipInfo.SetToolTip(this.dtpTanggal,
                "📅 Aturan Tanggal:\n" +
                "• Tambah Antrian: Minimal hari ini, maksimal 7 hari ke depan\n" +
                "• Edit Antrian: Minimal tanggal awal, maksimal 7 hari dari tanggal awal\n" +
                "• Validasi dilakukan saat klik SIMPAN");

            // ========== STATUS ==========
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblStatus.Location = new System.Drawing.Point(30, 270);
            this.lblStatus.Text = "Status :";

            this.cmbStatus.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbStatus.Location = new System.Drawing.Point(150, 267);
            this.cmbStatus.Size = new System.Drawing.Size(150, 29);
            this.cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbStatus.Items.AddRange(new object[] { "menunggu", "sedang diproses", "selesai" });

            // ========== BUTTON ==========
            this.btnSimpan.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSimpan.Location = new System.Drawing.Point(150, 330);
            this.btnSimpan.Size = new System.Drawing.Size(120, 40);
            this.btnSimpan.BackColor = System.Drawing.Color.FromArgb(39, 174, 96);
            this.btnSimpan.ForeColor = System.Drawing.Color.White;
            this.btnSimpan.FlatStyle = FlatStyle.Flat;
            this.btnSimpan.Cursor = Cursors.Hand;
            this.btnSimpan.Text = "💾 Simpan";

            this.btnBatal.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnBatal.Location = new System.Drawing.Point(290, 330);
            this.btnBatal.Size = new System.Drawing.Size(120, 40);
            this.btnBatal.BackColor = System.Drawing.Color.FromArgb(231, 76, 60);
            this.btnBatal.ForeColor = System.Drawing.Color.White;
            this.btnBatal.FlatStyle = FlatStyle.Flat;
            this.btnBatal.Cursor = Cursors.Hand;
            this.btnBatal.Text = "❌ Batal";

            // ========== ADD CONTROLS ==========
            this.Controls.Add(this.lblNomorAntrian);
            this.Controls.Add(this.txtNomorAntrian);
            this.Controls.Add(this.lblNamaPetani);
            this.Controls.Add(this.txtNamaPetani);
            this.Controls.Add(this.lblAlamat);
            this.Controls.Add(this.txtAlamat);
            this.Controls.Add(this.lblNoTelepon);
            this.Controls.Add(this.txtNoTelepon);
            this.Controls.Add(this.lblBeratGabah);
            this.Controls.Add(this.txtBeratGabah);
            this.Controls.Add(lblKg);
            this.Controls.Add(this.lblTanggal);
            this.Controls.Add(this.dtpTanggal);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.cmbStatus);
            this.Controls.Add(this.btnSimpan);
            this.Controls.Add(this.btnBatal);

            // ========== EVENT HANDLER ==========
            this.btnSimpan.Click += new System.EventHandler(this.btnSimpan_Click);
            this.btnBatal.Click += new System.EventHandler(this.btnBatal_Click);
            this.txtNoTelepon.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNoTelepon_KeyPress);
            this.txtBeratGabah.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBeratGabah_KeyPress);
            this.txtNamaPetani.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNamaPetani_KeyPress);

            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}