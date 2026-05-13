namespace Giling_Padi
{
    partial class FormPetani
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
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
            this.SuspendLayout();

            // ========== FORM SETTING ==========
            this.ClientSize = new System.Drawing.Size(450, 280);
            this.Text = "👨‍🌾 Form Petani";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.BackColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            // ========== LABEL NAMA ==========
            this.lblNama.AutoSize = true;
            this.lblNama.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblNama.Location = new System.Drawing.Point(30, 30);
            this.lblNama.Name = "lblNama";
            this.lblNama.Size = new System.Drawing.Size(108, 20);
            this.lblNama.TabIndex = 0;
            this.lblNama.Text = "👨‍🌾 Nama Petani :";

            // ========== TEXTBOX NAMA ==========
            this.txtNama.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtNama.Location = new System.Drawing.Point(150, 27);
            this.txtNama.Name = "txtNama";
            this.txtNama.Size = new System.Drawing.Size(250, 28);
            this.txtNama.TabIndex = 1;

            // ========== LABEL ALAMAT ==========
            this.lblAlamat.AutoSize = true;
            this.lblAlamat.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblAlamat.Location = new System.Drawing.Point(30, 75);
            this.lblAlamat.Name = "lblAlamat";
            this.lblAlamat.Size = new System.Drawing.Size(67, 20);
            this.lblAlamat.TabIndex = 2;
            this.lblAlamat.Text = "🏠 Alamat :";

            // ========== TEXTBOX ALAMAT ==========
            this.txtAlamat.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtAlamat.Location = new System.Drawing.Point(150, 72);
            this.txtAlamat.Name = "txtAlamat";
            this.txtAlamat.Size = new System.Drawing.Size(250, 28);
            this.txtAlamat.TabIndex = 3;

            // ========== LABEL NO TELEPON ==========
            this.lblNoTelepon.AutoSize = true;
            this.lblNoTelepon.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblNoTelepon.Location = new System.Drawing.Point(30, 120);
            this.lblNoTelepon.Name = "lblNoTelepon";
            this.lblNoTelepon.Size = new System.Drawing.Size(97, 20);
            this.lblNoTelepon.TabIndex = 4;
            this.lblNoTelepon.Text = "📞 No Telepon :";

            // ========== TEXTBOX NO TELEPON ==========
            this.txtNoTelepon.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtNoTelepon.Location = new System.Drawing.Point(150, 117);
            this.txtNoTelepon.Name = "txtNoTelepon";
            this.txtNoTelepon.Size = new System.Drawing.Size(180, 28);
            this.txtNoTelepon.TabIndex = 5;

            // ========== BUTTON SIMPAN ==========
            this.btnSimpan.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSimpan.Location = new System.Drawing.Point(100, 180);
            this.btnSimpan.Name = "btnSimpan";
            this.btnSimpan.Size = new System.Drawing.Size(120, 40);
            this.btnSimpan.BackColor = System.Drawing.Color.FromArgb(39, 174, 96);
            this.btnSimpan.ForeColor = System.Drawing.Color.White;
            this.btnSimpan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSimpan.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSimpan.TabIndex = 6;
            this.btnSimpan.Text = "💾 Simpan";
            this.btnSimpan.UseVisualStyleBackColor = false;
            this.btnSimpan.Click += new System.EventHandler(this.btnSimpan_Click);

            // ========== BUTTON BATAL ==========
            this.btnBatal.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnBatal.Location = new System.Drawing.Point(240, 180);
            this.btnBatal.Name = "btnBatal";
            this.btnBatal.Size = new System.Drawing.Size(120, 40);
            this.btnBatal.BackColor = System.Drawing.Color.FromArgb(231, 76, 60);
            this.btnBatal.ForeColor = System.Drawing.Color.White;
            this.btnBatal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBatal.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBatal.TabIndex = 7;
            this.btnBatal.Text = "❌ Batal";
            this.btnBatal.UseVisualStyleBackColor = false;
            this.btnBatal.Click += new System.EventHandler(this.btnBatal_Click);

            // ========== EVENT KEYPRESS ==========
            this.txtNoTelepon.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNoTelepon_KeyPress);
            this.txtNama.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNama_KeyPress);

            // ========== ADD CONTROLS ==========
            this.Controls.Add(this.lblNama);
            this.Controls.Add(this.txtNama);
            this.Controls.Add(this.lblAlamat);
            this.Controls.Add(this.txtAlamat);
            this.Controls.Add(this.lblNoTelepon);
            this.Controls.Add(this.txtNoTelepon);
            this.Controls.Add(this.btnSimpan);
            this.Controls.Add(this.btnBatal);

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        // ========== DEKLARASI VARIABEL ==========
        private System.Windows.Forms.Label lblNama;
        private System.Windows.Forms.Label lblAlamat;
        private System.Windows.Forms.Label lblNoTelepon;
        private System.Windows.Forms.TextBox txtNama;
        private System.Windows.Forms.TextBox txtAlamat;
        private System.Windows.Forms.TextBox txtNoTelepon;
        private System.Windows.Forms.Button btnSimpan;
        private System.Windows.Forms.Button btnBatal;
    }
}