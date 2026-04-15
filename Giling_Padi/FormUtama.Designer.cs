namespace Giling_Padi
{
    partial class FormUtama
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
            this.btnLogout = new System.Windows.Forms.Button();
            this.SuspendLayout();

            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.label1.Location = new System.Drawing.Point(150, 100);
            this.label1.Text = "Selamat Datang di Aplikasi Gilingan Padi";

            this.btnLogout.Location = new System.Drawing.Point(300, 200);
            this.btnLogout.Text = "Logout";

            this.ClientSize = new System.Drawing.Size(600, 400);
            this.Text = "Dashboard - Aplikasi Gilingan Padi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;

            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnLogout);

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnLogout;
    }
}