using System.Windows.Forms;

namespace AplikasiGilinganPadi
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
            this.dgvAntrian = new System.Windows.Forms.DataGridView();
            this.btnTambah = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnHapus = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAntrian)).BeginInit();
            this.SuspendLayout();

            // dgvAntrian
            this.dgvAntrian.Location = new System.Drawing.Point(20, 20);
            this.dgvAntrian.Size = new System.Drawing.Size(760, 350);
            this.dgvAntrian.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvAntrian.MultiSelect = false;

            // btnTambah
            this.btnTambah.Location = new System.Drawing.Point(20, 390);
            this.btnTambah.Size = new System.Drawing.Size(100, 35);
            this.btnTambah.Text = "Tambah";

            // btnEdit
            this.btnEdit.Location = new System.Drawing.Point(130, 390);
            this.btnEdit.Size = new System.Drawing.Size(100, 35);
            this.btnEdit.Text = "Edit";

            // btnHapus
            this.btnHapus.Location = new System.Drawing.Point(240, 390);
            this.btnHapus.Size = new System.Drawing.Size(100, 35);
            this.btnHapus.Text = "Hapus";

            // btnRefresh
            this.btnRefresh.Location = new System.Drawing.Point(350, 390);
            this.btnRefresh.Size = new System.Drawing.Size(100, 35);
            this.btnRefresh.Text = "Refresh";

            // btnLogout
            this.btnLogout.Location = new System.Drawing.Point(680, 390);
            this.btnLogout.Size = new System.Drawing.Size(100, 35);
            this.btnLogout.Text = "Logout";

            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Text = "Dashboard - Aplikasi Gilingan Padi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;

            this.Controls.Add(this.dgvAntrian);
            this.Controls.Add(this.btnTambah);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnHapus);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnLogout);

            ((System.ComponentModel.ISupportInitialize)(this.dgvAntrian)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.DataGridView dgvAntrian;
        private System.Windows.Forms.Button btnTambah;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnHapus;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnLogout;
    }
}