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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAntrian));
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
            this.toolTipInfo = new System.Windows.Forms.ToolTip(this.components);
            this.lblKg = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblNomorAntrian
            // 
            this.lblNomorAntrian.AutoSize = true;
            this.lblNomorAntrian.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblNomorAntrian.Location = new System.Drawing.Point(30, 30);
            this.lblNomorAntrian.Name = "lblNomorAntrian";
            this.lblNomorAntrian.Size = new System.Drawing.Size(95, 20);
            this.lblNomorAntrian.TabIndex = 0;
            this.lblNomorAntrian.Text = "No Antrian :";
            // 
            // lblNamaPetani
            // 
            this.lblNamaPetani.AutoSize = true;
            this.lblNamaPetani.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblNamaPetani.Location = new System.Drawing.Point(30, 70);
            this.lblNamaPetani.Name = "lblNamaPetani";
            this.lblNamaPetani.Size = new System.Drawing.Size(100, 20);
            this.lblNamaPetani.TabIndex = 2;
            this.lblNamaPetani.Text = "Nama Petani :";
            // 
            // lblAlamat
            // 
            this.lblAlamat.AutoSize = true;
            this.lblAlamat.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblAlamat.Location = new System.Drawing.Point(30, 110);
            this.lblAlamat.Name = "lblAlamat";
            this.lblAlamat.Size = new System.Drawing.Size(64, 20);
            this.lblAlamat.TabIndex = 4;
            this.lblAlamat.Text = "Alamat :";
            // 
            // lblNoTelepon
            // 
            this.lblNoTelepon.AutoSize = true;
            this.lblNoTelepon.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblNoTelepon.Location = new System.Drawing.Point(30, 150);
            this.lblNoTelepon.Name = "lblNoTelepon";
            this.lblNoTelepon.Size = new System.Drawing.Size(93, 20);
            this.lblNoTelepon.TabIndex = 6;
            this.lblNoTelepon.Text = "No Telepon :";
            // 
            // lblBeratGabah
            // 
            this.lblBeratGabah.AutoSize = true;
            this.lblBeratGabah.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblBeratGabah.Location = new System.Drawing.Point(30, 190);
            this.lblBeratGabah.Name = "lblBeratGabah";
            this.lblBeratGabah.Size = new System.Drawing.Size(98, 20);
            this.lblBeratGabah.TabIndex = 8;
            this.lblBeratGabah.Text = "Berat Gabah :";
            // 
            // lblTanggal
            // 
            this.lblTanggal.AutoSize = true;
            this.lblTanggal.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTanggal.Location = new System.Drawing.Point(30, 230);
            this.lblTanggal.Name = "lblTanggal";
            this.lblTanggal.Size = new System.Drawing.Size(68, 20);
            this.lblTanggal.TabIndex = 11;
            this.lblTanggal.Text = "Tanggal :";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblStatus.Location = new System.Drawing.Point(30, 270);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(56, 20);
            this.lblStatus.TabIndex = 13;
            this.lblStatus.Text = "Status :";
            // 
            // txtNomorAntrian
            // 
            this.txtNomorAntrian.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.txtNomorAntrian.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtNomorAntrian.Location = new System.Drawing.Point(150, 27);
            this.txtNomorAntrian.Name = "txtNomorAntrian";
            this.txtNomorAntrian.ReadOnly = true;
            this.txtNomorAntrian.Size = new System.Drawing.Size(100, 30);
            this.txtNomorAntrian.TabIndex = 1;
            // 
            // txtNamaPetani
            // 
            this.txtNamaPetani.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtNamaPetani.Location = new System.Drawing.Point(150, 67);
            this.txtNamaPetani.Name = "txtNamaPetani";
            this.txtNamaPetani.Size = new System.Drawing.Size(280, 30);
            this.txtNamaPetani.TabIndex = 3;
            this.txtNamaPetani.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNamaPetani_KeyPress);
            // 
            // txtAlamat
            // 
            this.txtAlamat.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtAlamat.Location = new System.Drawing.Point(150, 107);
            this.txtAlamat.Name = "txtAlamat";
            this.txtAlamat.Size = new System.Drawing.Size(280, 30);
            this.txtAlamat.TabIndex = 5;
            // 
            // txtNoTelepon
            // 
            this.txtNoTelepon.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtNoTelepon.Location = new System.Drawing.Point(150, 147);
            this.txtNoTelepon.Name = "txtNoTelepon";
            this.txtNoTelepon.Size = new System.Drawing.Size(180, 30);
            this.txtNoTelepon.TabIndex = 7;
            this.txtNoTelepon.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNoTelepon_KeyPress);
            // 
            // txtBeratGabah
            // 
            this.txtBeratGabah.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtBeratGabah.Location = new System.Drawing.Point(150, 187);
            this.txtBeratGabah.Name = "txtBeratGabah";
            this.txtBeratGabah.Size = new System.Drawing.Size(120, 30);
            this.txtBeratGabah.TabIndex = 9;
            this.txtBeratGabah.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBeratGabah_KeyPress);
            // 
            // dtpTanggal
            // 
            this.dtpTanggal.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpTanggal.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTanggal.Location = new System.Drawing.Point(150, 227);
            this.dtpTanggal.Name = "dtpTanggal";
            this.dtpTanggal.Size = new System.Drawing.Size(250, 30);
            this.dtpTanggal.TabIndex = 12;
            this.toolTipInfo.SetToolTip(this.dtpTanggal, resources.GetString("dtpTanggal.ToolTip"));
            // 
            // cmbStatus
            // 
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbStatus.Items.AddRange(new object[] {
            "menunggu",
            "sedang diproses",
            "selesai"});
            this.cmbStatus.Location = new System.Drawing.Point(150, 267);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(150, 31);
            this.cmbStatus.TabIndex = 14;
            // 
            // btnSimpan
            // 
            this.btnSimpan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.btnSimpan.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSimpan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSimpan.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSimpan.ForeColor = System.Drawing.Color.White;
            this.btnSimpan.Location = new System.Drawing.Point(150, 340);
            this.btnSimpan.Name = "btnSimpan";
            this.btnSimpan.Size = new System.Drawing.Size(120, 40);
            this.btnSimpan.TabIndex = 15;
            this.btnSimpan.Text = "💾 Simpan";
            this.btnSimpan.UseVisualStyleBackColor = false;
            this.btnSimpan.Click += new System.EventHandler(this.btnSimpan_Click);
            // 
            // btnBatal
            // 
            this.btnBatal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnBatal.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBatal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBatal.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnBatal.ForeColor = System.Drawing.Color.White;
            this.btnBatal.Location = new System.Drawing.Point(290, 340);
            this.btnBatal.Name = "btnBatal";
            this.btnBatal.Size = new System.Drawing.Size(120, 40);
            this.btnBatal.TabIndex = 16;
            this.btnBatal.Text = "❌ Batal";
            this.btnBatal.UseVisualStyleBackColor = false;
            this.btnBatal.Click += new System.EventHandler(this.btnBatal_Click);
            // 
            // lblKg
            // 
            this.lblKg.AutoSize = true;
            this.lblKg.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblKg.Location = new System.Drawing.Point(280, 190);
            this.lblKg.Name = "lblKg";
            this.lblKg.Size = new System.Drawing.Size(25, 20);
            this.lblKg.TabIndex = 10;
            this.lblKg.Text = "kg";
            // 
            // FormAntrian
            // 
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(650, 450);
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
            this.Controls.Add(this.lblKg);
            this.Controls.Add(this.lblTanggal);
            this.Controls.Add(this.dtpTanggal);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.cmbStatus);
            this.Controls.Add(this.btnSimpan);
            this.Controls.Add(this.btnBatal);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormAntrian";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Form Antrian";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private Label lblKg;
    }
}