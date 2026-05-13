using System.Drawing;
using System.Windows.Forms;

namespace AplikasiGilinganPadi
{
    partial class FormAntrian
    {
        private System.ComponentModel.IContainer components = null;

        private Label lblNomorAntrian;
        private Label lblNamaPetani;
        private Label lblAlamat;
        private Label lblNoTelepon;
        private Label lblBeratGabah;
        private Label lblTanggal;
        private Label lblStatus;
        private TextBox txtNomorAntrian;
        private ComboBox cmbNamaPetani;
        private TextBox txtAlamat;
        private TextBox txtNoTelepon;
        private TextBox txtBeratGabah;
        private DateTimePicker dtpTanggal;
        private ComboBox cmbStatus;
        private Button btnSimpan;
        private Button btnBatal;
        private ToolTip toolTipInfo;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblNomorAntrian = new Label();
            this.lblNamaPetani = new Label();
            this.lblAlamat = new Label();
            this.lblNoTelepon = new Label();
            this.lblBeratGabah = new Label();
            this.lblTanggal = new Label();
            this.lblStatus = new Label();
            this.txtNomorAntrian = new TextBox();
            this.cmbNamaPetani = new ComboBox();
            this.txtAlamat = new TextBox();
            this.txtNoTelepon = new TextBox();
            this.txtBeratGabah = new TextBox();
            this.dtpTanggal = new DateTimePicker();
            this.cmbStatus = new ComboBox();
            this.btnSimpan = new Button();
            this.btnBatal = new Button();
            this.toolTipInfo = new ToolTip();
            this.SuspendLayout();

            // ========== FORM SETTING ==========
            this.ClientSize = new System.Drawing.Size(500, 450);
            this.Text = "📋 Form Antrian";
            this.StartPosition = FormStartPosition.CenterParent;
            this.BackColor = System.Drawing.Color.White;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            // ========== NO ANTRIAN ==========
            this.lblNomorAntrian.AutoSize = true;
            this.lblNomorAntrian.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.lblNomorAntrian.Location = new System.Drawing.Point(30, 25);
            this.lblNomorAntrian.Text = "📍 No Antrian :";
            this.txtNomorAntrian.Font = new Font("Segoe UI", 10F);
            this.txtNomorAntrian.Location = new System.Drawing.Point(150, 22);
            this.txtNomorAntrian.Size = new System.Drawing.Size(100, 28);
            this.txtNomorAntrian.ReadOnly = true;
            this.txtNomorAntrian.BackColor = System.Drawing.Color.FromArgb(236, 240, 241);

            // ========== NAMA PETANI (DIPERBAIKI) ==========
            this.lblNamaPetani.AutoSize = true;
            this.lblNamaPetani.Font = new Font("Segoe UI", 9F);
            this.lblNamaPetani.Location = new System.Drawing.Point(30, 65);
            this.lblNamaPetani.Text = "👨‍🌾 Nama Petani :";

            this.cmbNamaPetani.Font = new Font("Segoe UI", 10F);
            this.cmbNamaPetani.Location = new System.Drawing.Point(150, 62);
            this.cmbNamaPetani.Size = new System.Drawing.Size(300, 29);

            // PERBAIKAN: Gunakan DropDown (bukan DropDownList) agar AutoComplete bekerja
            this.cmbNamaPetani.DropDownStyle = ComboBoxStyle.DropDown;
            this.cmbNamaPetani.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            this.cmbNamaPetani.AutoCompleteSource = AutoCompleteSource.ListItems;
            this.cmbNamaPetani.SelectedIndexChanged += new System.EventHandler(this.cmbNamaPetani_SelectedIndexChanged);

            // ========== ALAMAT (READONLY, OTOMATIS TERISI) ==========
            this.lblAlamat.AutoSize = true;
            this.lblAlamat.Font = new Font("Segoe UI", 9F);
            this.lblAlamat.Location = new System.Drawing.Point(30, 105);
            this.lblAlamat.Text = "🏠 Alamat :";
            this.txtAlamat.Font = new Font("Segoe UI", 10F);
            this.txtAlamat.Location = new System.Drawing.Point(150, 102);
            this.txtAlamat.Size = new System.Drawing.Size(300, 28);
            this.txtAlamat.ReadOnly = true;
            this.txtAlamat.BackColor = System.Drawing.Color.FromArgb(236, 240, 241);

            // ========== NO TELEPON (READONLY, OTOMATIS TERISI) ==========
            this.lblNoTelepon.AutoSize = true;
            this.lblNoTelepon.Font = new Font("Segoe UI", 9F);
            this.lblNoTelepon.Location = new System.Drawing.Point(30, 145);
            this.lblNoTelepon.Text = "📞 No Telepon :";
            this.txtNoTelepon.Font = new Font("Segoe UI", 10F);
            this.txtNoTelepon.Location = new System.Drawing.Point(150, 142);
            this.txtNoTelepon.Size = new System.Drawing.Size(180, 28);
            this.txtNoTelepon.ReadOnly = true;
            this.txtNoTelepon.BackColor = System.Drawing.Color.FromArgb(236, 240, 241);

            // ========== BERAT GABAH ==========
            this.lblBeratGabah.AutoSize = true;
            this.lblBeratGabah.Font = new Font("Segoe UI", 9F);
            this.lblBeratGabah.Location = new System.Drawing.Point(30, 185);
            this.lblBeratGabah.Text = "⚖️ Berat Gabah :";
            this.txtBeratGabah.Font = new Font("Segoe UI", 10F);
            this.txtBeratGabah.Location = new System.Drawing.Point(150, 182);
            this.txtBeratGabah.Size = new System.Drawing.Size(120, 28);

            Label lblKg = new Label();
            lblKg.AutoSize = true;
            lblKg.Font = new Font("Segoe UI", 9F);
            lblKg.Location = new System.Drawing.Point(280, 185);
            lblKg.Text = "kg";

            // ========== TANGGAL ==========
            this.lblTanggal.AutoSize = true;
            this.lblTanggal.Font = new Font("Segoe UI", 9F);
            this.lblTanggal.Location = new System.Drawing.Point(30, 225);
            this.lblTanggal.Text = "📅 Tanggal :";
            this.dtpTanggal.Font = new Font("Segoe UI", 10F);
            this.dtpTanggal.Location = new System.Drawing.Point(150, 222);
            this.dtpTanggal.Size = new System.Drawing.Size(250, 28);
            this.dtpTanggal.Format = DateTimePickerFormat.Short;

            this.toolTipInfo.SetToolTip(this.dtpTanggal,
                "📅 Aturan Tanggal:\n" +
                "• Tambah Antrian: Minimal hari ini, maksimal 7 hari ke depan\n" +
                "• Edit Antrian: Minimal tanggal awal, maksimal 7 hari dari tanggal awal\n" +
                "• Validasi dilakukan saat klik SIMPAN");

            // ========== STATUS ==========
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new Font("Segoe UI", 9F);
            this.lblStatus.Location = new System.Drawing.Point(30, 265);
            this.lblStatus.Text = "📌 Status :";
            this.cmbStatus.Font = new Font("Segoe UI", 10F);
            this.cmbStatus.Location = new System.Drawing.Point(150, 262);
            this.cmbStatus.Size = new System.Drawing.Size(180, 29);
            this.cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbStatus.Items.AddRange(new object[] { "menunggu", "proses", "selesai" });

            // ========== BUTTON SIMPAN ==========
            this.btnSimpan.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnSimpan.Location = new System.Drawing.Point(150, 330);
            this.btnSimpan.Size = new System.Drawing.Size(130, 40);
            this.btnSimpan.BackColor = System.Drawing.Color.FromArgb(39, 174, 96);
            this.btnSimpan.ForeColor = System.Drawing.Color.White;
            this.btnSimpan.FlatStyle = FlatStyle.Flat;
            this.btnSimpan.Cursor = Cursors.Hand;
            this.btnSimpan.Text = "💾 Simpan";
            this.btnSimpan.Click += new System.EventHandler(this.btnSimpan_Click);

            // ========== BUTTON BATAL ==========
            this.btnBatal.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnBatal.Location = new System.Drawing.Point(300, 330);
            this.btnBatal.Size = new System.Drawing.Size(130, 40);
            this.btnBatal.BackColor = System.Drawing.Color.FromArgb(231, 76, 60);
            this.btnBatal.ForeColor = System.Drawing.Color.White;
            this.btnBatal.FlatStyle = FlatStyle.Flat;
            this.btnBatal.Cursor = Cursors.Hand;
            this.btnBatal.Text = "❌ Batal";
            this.btnBatal.Click += new System.EventHandler(this.btnBatal_Click);

            // ========== KEYPRESS EVENT ==========
            this.txtBeratGabah.KeyPress += new KeyPressEventHandler(this.txtBeratGabah_KeyPress);

            // ========== ADD CONTROLS ==========
            this.Controls.Add(this.lblNomorAntrian);
            this.Controls.Add(this.txtNomorAntrian);
            this.Controls.Add(this.lblNamaPetani);
            this.Controls.Add(this.cmbNamaPetani);
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

            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}