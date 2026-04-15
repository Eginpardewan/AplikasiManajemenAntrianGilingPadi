namespace Giling_Padi
{
    partial class FormAntrian
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.txtNamaPetani = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAlamat = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNoTelepon = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtBeratGabah = new System.Windows.Forms.TextBox();
            this.btnSimpan = new System.Windows.Forms.Button();
            this.btnBatal = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // Labels and TextBoxes
            this.label1.Location = new System.Drawing.Point(30, 30);
            this.label1.Text = "Nama Petani:";

            this.txtNamaPetani.Location = new System.Drawing.Point(150, 27);
            this.txtNamaPetani.Size = new System.Drawing.Size(200, 22);

            this.label2.Location = new System.Drawing.Point(30, 70);
            this.label2.Text = "Alamat:";

            this.txtAlamat.Location = new System.Drawing.Point(150, 67);
            this.txtAlamat.Size = new System.Drawing.Size(250, 22);

            this.label3.Location = new System.Drawing.Point(30, 110);
            this.label3.Text = "No Telepon:";

            this.txtNoTelepon.Location = new System.Drawing.Point(150, 107);
            this.txtNoTelepon.Size = new System.Drawing.Size(150, 22);

            this.label4.Location = new System.Drawing.Point(30, 150);
            this.label4.Text = "Berat Gabah (kg):";

            this.txtBeratGabah.Location = new System.Drawing.Point(150, 147);
            this.txtBeratGabah.Size = new System.Drawing.Size(120, 22);

            this.btnSimpan.Location = new System.Drawing.Point(150, 200);
            this.btnSimpan.Text = "Simpan";

            this.btnBatal.Location = new System.Drawing.Point(260, 200);
            this.btnBatal.Text = "Batal";

            this.ClientSize = new System.Drawing.Size(450, 280);
            this.Text = "Form Antrian";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;

            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNamaPetani);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtAlamat);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtNoTelepon);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtBeratGabah);
            this.Controls.Add(this.btnSimpan);
            this.Controls.Add(this.btnBatal);

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNamaPetani;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtAlamat;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNoTelepon;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtBeratGabah;
        private System.Windows.Forms.Button btnSimpan;
        private System.Windows.Forms.Button btnBatal;
    }
}