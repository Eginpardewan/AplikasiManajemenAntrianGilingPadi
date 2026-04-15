namespace AplikasiGilinganPadi
{
    partial class FormLogin
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
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // label1 (Email)
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(50, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 17);
            this.label1.Text = "Email:";

            // txtEmail
            this.txtEmail.Location = new System.Drawing.Point(120, 47);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(200, 22);
            this.txtEmail.Text = "admin@gmail.com";

            // label2 (Password)
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(50, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 17);
            this.label2.Text = "Password:";

            // txtPassword
            this.txtPassword.Location = new System.Drawing.Point(120, 87);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(200, 22);
            this.txtPassword.PasswordChar = '*';

            // btnLogin
            this.btnLogin.Location = new System.Drawing.Point(120, 130);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(90, 30);
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = true;

            // btnExit
            this.btnExit.Location = new System.Drawing.Point(230, 130);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(90, 30);
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;

            // FormLogin
            this.ClientSize = new System.Drawing.Size(400, 200);
            this.Text = "Login - Aplikasi Gilingan Padi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;

            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.btnExit);

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnExit;
    }
}