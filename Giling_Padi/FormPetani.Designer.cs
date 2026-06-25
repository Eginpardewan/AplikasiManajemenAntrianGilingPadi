using System.Drawing;
using System.Windows.Forms;

namespace AplikasiGilinganPadi
{
    partial class FormPetani
    {
        private System.ComponentModel.IContainer components = null;

        // ========== DEKLARASI KOMPONEN ==========
        private System.Windows.Forms.Label lblNama;
        private System.Windows.Forms.Label lblAlamat;
        private System.Windows.Forms.Label lblNoTelepon;
        private System.Windows.Forms.TextBox txtNama;
        private System.Windows.Forms.TextBox txtAlamat;
        private System.Windows.Forms.TextBox txtNoTelepon;
        private System.Windows.Forms.Button btnSimpan;
        private System.Windows.Forms.Button btnBatal;
        private System.Windows.Forms.Button btnTestInjection;
        private System.Windows.Forms.Button btnResetData;
        private System.Windows.Forms.Button btnImportExcel;
        private System.Windows.Forms.Button btnExportExcel;  // TAMBAHAN UCP 3
        private System.Windows.Forms.Button btnImpDb;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ComboBox cmbStatusImport; // TAMBAHAN UCP 3
        private System.Windows.Forms.ToolTip toolTipInfo;     // TAMBAHAN UCP 3

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblNama = new System.Windows.Forms.Label();
            this.lblAlamat = new System.Windows.Forms.Label();
            this.lblNoTelepon = new System.Windows.Forms.Label();
            this.txtNama = new System.Windows.Forms.TextBox();
            this.txtAlamat = new System.Windows.Forms.TextBox();
            this.txtNoTelepon = new System.Windows.Forms.TextBox();
            this.btnSimpan = new System.Windows.Forms.Button();
            this.btnBatal = new System.Windows.Forms.Button();
            this.btnTestInjection = new System.Windows.Forms.Button();
            this.btnResetData = new System.Windows.Forms.Button();
            this.btnImportExcel = new System.Windows.Forms.Button();
            this.btnExportExcel = new System.Windows.Forms.Button(); // TAMBAHAN
            this.btnImpDb = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.lblStatus = new System.Windows.Forms.Label();
            this.cmbStatusImport = new System.Windows.Forms.ComboBox(); // TAMBAHAN
            this.toolTipInfo = new System.Windows.Forms.ToolTip();     // TAMBAHAN
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();

            // ============================================================
            // FORM
            // ============================================================
            this.ClientSize = new System.Drawing.Size(700, 540);
            this.Text = "📋 Data Petani";
            this.StartPosition = FormStartPosition.CenterParent;
            this.BackColor = System.Drawing.Color.White;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            // ============================================================
            // LABEL NAMA
            // ============================================================
            this.lblNama.AutoSize = true;
            this.lblNama.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblNama.Location = new System.Drawing.Point(30, 30);
            this.lblNama.Name = "lblNama";
            this.lblNama.Size = new System.Drawing.Size(96, 20);
            this.lblNama.Text = "Nama Petani :";
            this.lblNama.TabIndex = 0;

            // ============================================================
            // TEXTBOX NAMA
            // ============================================================
            this.txtNama.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtNama.Location = new System.Drawing.Point(150, 27);
            this.txtNama.Name = "txtNama";
            this.txtNama.Size = new System.Drawing.Size(300, 30);
            this.txtNama.TabIndex = 1;
            this.toolTipInfo.SetToolTip(this.txtNama, "Masukkan nama petani (minimal 3 karakter)");

            // ============================================================
            // LABEL ALAMAT
            // ============================================================
            this.lblAlamat.AutoSize = true;
            this.lblAlamat.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblAlamat.Location = new System.Drawing.Point(30, 75);
            this.lblAlamat.Name = "lblAlamat";
            this.lblAlamat.Size = new System.Drawing.Size(66, 20);
            this.lblAlamat.Text = "Alamat :";
            this.lblAlamat.TabIndex = 2;

            // ============================================================
            // TEXTBOX ALAMAT
            // ============================================================
            this.txtAlamat.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtAlamat.Location = new System.Drawing.Point(150, 72);
            this.txtAlamat.Name = "txtAlamat";
            this.txtAlamat.Size = new System.Drawing.Size(300, 30);
            this.txtAlamat.TabIndex = 3;
            this.toolTipInfo.SetToolTip(this.txtAlamat, "Masukkan alamat petani (minimal 5 karakter)");

            // ============================================================
            // LABEL NO TELEPON
            // ============================================================
            this.lblNoTelepon.AutoSize = true;
            this.lblNoTelepon.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblNoTelepon.Location = new System.Drawing.Point(30, 120);
            this.lblNoTelepon.Name = "lblNoTelepon";
            this.lblNoTelepon.Size = new System.Drawing.Size(94, 20);
            this.lblNoTelepon.Text = "No Telepon :";
            this.lblNoTelepon.TabIndex = 4;

            // ============================================================
            // TEXTBOX NO TELEPON
            // ============================================================
            this.txtNoTelepon.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtNoTelepon.Location = new System.Drawing.Point(150, 117);
            this.txtNoTelepon.Name = "txtNoTelepon";
            this.txtNoTelepon.Size = new System.Drawing.Size(200, 30);
            this.txtNoTelepon.TabIndex = 5;
            this.toolTipInfo.SetToolTip(this.txtNoTelepon, "Masukkan no telepon (10-15 digit angka)");

            // ============================================================
            // BUTTON TEST INJECTION
            // ============================================================
            this.btnTestInjection.BackColor = System.Drawing.Color.FromArgb(231, 76, 60);
            this.btnTestInjection.Cursor = Cursors.Hand;
            this.btnTestInjection.FlatStyle = FlatStyle.Flat;
            this.btnTestInjection.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnTestInjection.ForeColor = System.Drawing.Color.White;
            this.btnTestInjection.Location = new System.Drawing.Point(30, 170);
            this.btnTestInjection.Name = "btnTestInjection";
            this.btnTestInjection.Size = new System.Drawing.Size(150, 35);
            this.btnTestInjection.TabIndex = 6;
            this.btnTestInjection.Text = "🧪 Test SQL Injection";
            this.btnTestInjection.UseVisualStyleBackColor = false;
            this.toolTipInfo.SetToolTip(this.btnTestInjection, "⚠️ PERINGATAN: Ini adalah simulasi SQL Injection!\nJangan gunakan di produksi!");
            this.btnTestInjection.Click += new System.EventHandler(this.btnTestInjection_Click);

            // ============================================================
            // BUTTON RESET DATA
            // ============================================================
            this.btnResetData.BackColor = System.Drawing.Color.FromArgb(52, 73, 94);
            this.btnResetData.Cursor = Cursors.Hand;
            this.btnResetData.FlatStyle = FlatStyle.Flat;
            this.btnResetData.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnResetData.ForeColor = System.Drawing.Color.White;
            this.btnResetData.Location = new System.Drawing.Point(195, 170);
            this.btnResetData.Name = "btnResetData";
            this.btnResetData.Size = new System.Drawing.Size(130, 35);
            this.btnResetData.TabIndex = 7;
            this.btnResetData.Text = "🔄 Reset Data";
            this.btnResetData.UseVisualStyleBackColor = false;
            this.toolTipInfo.SetToolTip(this.btnResetData, "Reset semua data petani ke kondisi awal (5 data default)");
            this.btnResetData.Click += new System.EventHandler(this.btnResetData_Click);

            // ============================================================
            // BUTTON IMPORT EXCEL
            // ============================================================
            this.btnImportExcel.BackColor = System.Drawing.Color.FromArgb(46, 204, 113);
            this.btnImportExcel.Cursor = Cursors.Hand;
            this.btnImportExcel.FlatStyle = FlatStyle.Flat;
            this.btnImportExcel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnImportExcel.ForeColor = System.Drawing.Color.White;
            this.btnImportExcel.Location = new System.Drawing.Point(340, 170);
            this.btnImportExcel.Name = "btnImportExcel";
            this.btnImportExcel.Size = new System.Drawing.Size(130, 35);
            this.btnImportExcel.TabIndex = 8;
            this.btnImportExcel.Text = "📂 Import Excel";
            this.btnImportExcel.UseVisualStyleBackColor = false;
            this.toolTipInfo.SetToolTip(this.btnImportExcel, "Import data petani dari file Excel (.xlsx / .xls)");
            this.btnImportExcel.Click += new System.EventHandler(this.btnImportExcel_Click);

            // ============================================================
            // BUTTON EXPORT EXCEL (TAMBAHAN UCP 3)
            // ============================================================
            this.btnExportExcel.BackColor = System.Drawing.Color.FromArgb(26, 188, 156);
            this.btnExportExcel.Cursor = Cursors.Hand;
            this.btnExportExcel.FlatStyle = FlatStyle.Flat;
            this.btnExportExcel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnExportExcel.ForeColor = System.Drawing.Color.White;
            this.btnExportExcel.Location = new System.Drawing.Point(340, 215);
            this.btnExportExcel.Name = "btnExportExcel";
            this.btnExportExcel.Size = new System.Drawing.Size(130, 35);
            this.btnExportExcel.TabIndex = 9;
            this.btnExportExcel.Text = "📤 Export Excel";
            this.btnExportExcel.UseVisualStyleBackColor = false;
            this.toolTipInfo.SetToolTip(this.btnExportExcel, "Export data petani ke file Excel/CSV");
            this.btnExportExcel.Click += new System.EventHandler(this.btnExportExcel_Click);

            // ============================================================
            // BUTTON IMPORT TO DB
            // ============================================================
            this.btnImpDb.BackColor = System.Drawing.Color.FromArgb(241, 196, 15);
            this.btnImpDb.Cursor = Cursors.Hand;
            this.btnImpDb.Enabled = false;
            this.btnImpDb.FlatStyle = FlatStyle.Flat;
            this.btnImpDb.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnImpDb.ForeColor = System.Drawing.Color.White;
            this.btnImpDb.Location = new System.Drawing.Point(485, 170);
            this.btnImpDb.Name = "btnImpDb";
            this.btnImpDb.Size = new System.Drawing.Size(130, 35);
            this.btnImpDb.TabIndex = 10;
            this.btnImpDb.Text = "💾 Import to DB";
            this.btnImpDb.UseVisualStyleBackColor = false;
            this.toolTipInfo.SetToolTip(this.btnImpDb, "Import data dari Excel ke database");
            this.btnImpDb.Click += new System.EventHandler(this.btnImpDb_Click);

            // ============================================================
            // COMBOBOX STATUS IMPORT (TAMBAHAN UCP 3)
            // ============================================================
            this.cmbStatusImport.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbStatusImport.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbStatusImport.Items.AddRange(new object[] {
                "Tambah Baru",
                "Update Data"
            });
            this.cmbStatusImport.Location = new System.Drawing.Point(485, 215);
            this.cmbStatusImport.Name = "cmbStatusImport";
            this.cmbStatusImport.Size = new System.Drawing.Size(130, 28);
            this.cmbStatusImport.TabIndex = 11;
            this.cmbStatusImport.Visible = false;
            this.toolTipInfo.SetToolTip(this.cmbStatusImport, "Pilih mode import:\n• Tambah Baru: Hanya insert data baru\n• Update Data: Update data yang sudah ada");

            // ============================================================
            // DATAGRIDVIEW (Untuk Menampilkan Data Excel)
            // ============================================================
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.BorderStyle = BorderStyle.Fixed3D;
            this.dataGridView1.ColumnHeadersHeight = 29;
            this.dataGridView1.Location = new System.Drawing.Point(30, 260);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(640, 180);
            this.dataGridView1.TabIndex = 12;
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.ReadOnly = true;

            // ============================================================
            // LABEL STATUS
            // ============================================================
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblStatus.Location = new System.Drawing.Point(30, 455);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 20);
            this.lblStatus.TabIndex = 13;

            // ============================================================
            // BUTTON SIMPAN
            // ============================================================
            this.btnSimpan.BackColor = System.Drawing.Color.FromArgb(39, 174, 96);
            this.btnSimpan.Cursor = Cursors.Hand;
            this.btnSimpan.FlatStyle = FlatStyle.Flat;
            this.btnSimpan.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSimpan.ForeColor = System.Drawing.Color.White;
            this.btnSimpan.Location = new System.Drawing.Point(150, 480);
            this.btnSimpan.Name = "btnSimpan";
            this.btnSimpan.Size = new System.Drawing.Size(120, 35);
            this.btnSimpan.TabIndex = 14;
            this.btnSimpan.Text = "💾 Simpan";
            this.btnSimpan.UseVisualStyleBackColor = false;
            this.toolTipInfo.SetToolTip(this.btnSimpan, "Simpan data petani ke database");
            this.btnSimpan.Click += new System.EventHandler(this.btnSimpan_Click);

            // ============================================================
            // BUTTON BATAL
            // ============================================================
            this.btnBatal.BackColor = System.Drawing.Color.FromArgb(149, 165, 166);
            this.btnBatal.Cursor = Cursors.Hand;
            this.btnBatal.FlatStyle = FlatStyle.Flat;
            this.btnBatal.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnBatal.ForeColor = System.Drawing.Color.White;
            this.btnBatal.Location = new System.Drawing.Point(290, 480);
            this.btnBatal.Name = "btnBatal";
            this.btnBatal.Size = new System.Drawing.Size(120, 35);
            this.btnBatal.TabIndex = 15;
            this.btnBatal.Text = "❌ Batal";
            this.btnBatal.UseVisualStyleBackColor = false;
            this.toolTipInfo.SetToolTip(this.btnBatal, "Batalkan dan tutup form");
            this.btnBatal.Click += new System.EventHandler(this.btnBatal_Click);

            // ============================================================
            // ADD CONTROLS
            // ============================================================
            this.Controls.Add(this.lblNama);
            this.Controls.Add(this.txtNama);
            this.Controls.Add(this.lblAlamat);
            this.Controls.Add(this.txtAlamat);
            this.Controls.Add(this.lblNoTelepon);
            this.Controls.Add(this.txtNoTelepon);
            this.Controls.Add(this.btnTestInjection);
            this.Controls.Add(this.btnResetData);
            this.Controls.Add(this.btnImportExcel);
            this.Controls.Add(this.btnExportExcel);  // TAMBAHAN
            this.Controls.Add(this.btnImpDb);
            this.Controls.Add(this.cmbStatusImport); // TAMBAHAN
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnSimpan);
            this.Controls.Add(this.btnBatal);

            // ============================================================
            // RESUME
            // ============================================================
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}