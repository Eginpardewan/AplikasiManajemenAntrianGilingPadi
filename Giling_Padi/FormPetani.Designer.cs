using System.Windows.Forms;

namespace AplikasiGilinganPadi
{
    partial class FormPetani
    {
        private System.ComponentModel.IContainer components = null;
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
            this.SuspendLayout();

            // Form
            this.ClientSize = new System.Drawing.Size(500, 350);
            this.Text = "Form Petani";
            this.StartPosition = FormStartPosition.CenterParent;
            this.BackColor = System.Drawing.Color.White;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            // Label Nama
            this.lblNama.AutoSize = true;
            this.lblNama.Location = new System.Drawing.Point(30, 30);
            this.lblNama.Text = "Nama Petani :";

            // TextBox Nama
            this.txtNama.Location = new System.Drawing.Point(150, 27);
            this.txtNama.Size = new System.Drawing.Size(300, 23);

            // Label Alamat
            this.lblAlamat.AutoSize = true;
            this.lblAlamat.Location = new System.Drawing.Point(30, 70);
            this.lblAlamat.Text = "Alamat :";

            // TextBox Alamat
            this.txtAlamat.Location = new System.Drawing.Point(150, 67);
            this.txtAlamat.Size = new System.Drawing.Size(300, 23);

            // Label No Telepon
            this.lblNoTelepon.AutoSize = true;
            this.lblNoTelepon.Location = new System.Drawing.Point(30, 110);
            this.lblNoTelepon.Text = "No Telepon :";

            // TextBox No Telepon
            this.txtNoTelepon.Location = new System.Drawing.Point(150, 107);
            this.txtNoTelepon.Size = new System.Drawing.Size(180, 23);

            // Button Test Injection
            this.btnTestInjection.BackColor = System.Drawing.Color.FromArgb(231, 76, 60);
            this.btnTestInjection.Cursor = Cursors.Hand;
            this.btnTestInjection.FlatStyle = FlatStyle.Flat;
            this.btnTestInjection.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnTestInjection.ForeColor = System.Drawing.Color.White;
            this.btnTestInjection.Location = new System.Drawing.Point(30, 160);
            this.btnTestInjection.Size = new System.Drawing.Size(140, 35);
            this.btnTestInjection.Text = "🧪 Test SQL Injection";
            this.btnTestInjection.Click += new System.EventHandler(this.btnTestInjection_Click);

            // Button Reset Data
            this.btnResetData.BackColor = System.Drawing.Color.FromArgb(52, 73, 94);
            this.btnResetData.Cursor = Cursors.Hand;
            this.btnResetData.FlatStyle = FlatStyle.Flat;
            this.btnResetData.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnResetData.ForeColor = System.Drawing.Color.White;
            this.btnResetData.Location = new System.Drawing.Point(190, 160);
            this.btnResetData.Size = new System.Drawing.Size(120, 35);
            this.btnResetData.Text = "🔄 Reset Data";
            this.btnResetData.Click += new System.EventHandler(this.btnResetData_Click);

            // Button Simpan
            this.btnSimpan.BackColor = System.Drawing.Color.FromArgb(39, 174, 96);
            this.btnSimpan.Cursor = Cursors.Hand;
            this.btnSimpan.FlatStyle = FlatStyle.Flat;
            this.btnSimpan.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSimpan.ForeColor = System.Drawing.Color.White;
            this.btnSimpan.Location = new System.Drawing.Point(150, 220);
            this.btnSimpan.Size = new System.Drawing.Size(100, 35);
            this.btnSimpan.Text = "💾 Simpan";
            this.btnSimpan.Click += new System.EventHandler(this.btnSimpan_Click);

            // Button Batal
            this.btnBatal.BackColor = System.Drawing.Color.FromArgb(149, 165, 166);
            this.btnBatal.Cursor = Cursors.Hand;
            this.btnBatal.FlatStyle = FlatStyle.Flat;
            this.btnBatal.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnBatal.ForeColor = System.Drawing.Color.White;
            this.btnBatal.Location = new System.Drawing.Point(270, 220);
            this.btnBatal.Size = new System.Drawing.Size(100, 35);
            this.btnBatal.Text = "❌ Batal";
            this.btnBatal.Click += new System.EventHandler(this.btnBatal_Click);

            // Add Controls
            this.Controls.Add(this.lblNama);
            this.Controls.Add(this.txtNama);
            this.Controls.Add(this.lblAlamat);
            this.Controls.Add(this.txtAlamat);
            this.Controls.Add(this.lblNoTelepon);
            this.Controls.Add(this.txtNoTelepon);
            this.Controls.Add(this.btnTestInjection);
            this.Controls.Add(this.btnResetData);
            this.Controls.Add(this.btnSimpan);
            this.Controls.Add(this.btnBatal);

            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}