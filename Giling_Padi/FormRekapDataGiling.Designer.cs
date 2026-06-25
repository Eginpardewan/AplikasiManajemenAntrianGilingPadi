using System;
using System.Drawing;
using System.Windows.Forms;
using CrystalDecisions.Windows.Forms;

namespace Giling_Padi
{
    partial class FormRekapDataGiling
    {
        private System.ComponentModel.IContainer components = null;

        private Panel panelFilter;
        private Label lblTanggalAwal;
        private Label lblTanggalAkhir;
        private DateTimePicker dtpTanggalAwal;
        private DateTimePicker dtpTanggalAkhir;
        private Button btnLoad;
        private Button btnCetak;
        private Button btnRefresh;
        private DataGridView dgvData;
        private Label lblTitle;
        private Label lblInfo;
        private CrystalReportViewer crystalReportViewer1;
        private Panel panelMain;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelFilter = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblTanggalAwal = new System.Windows.Forms.Label();
            this.dtpTanggalAwal = new System.Windows.Forms.DateTimePicker();
            this.lblTanggalAkhir = new System.Windows.Forms.Label();
            this.dtpTanggalAkhir = new System.Windows.Forms.DateTimePicker();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnCetak = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.lblInfo = new System.Windows.Forms.Label();
            this.panelMain = new System.Windows.Forms.Panel();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.panelFilter.SuspendLayout();
            this.panelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.SuspendLayout();
            // 
            // panelFilter
            // 
            this.panelFilter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.panelFilter.Controls.Add(this.lblTitle);
            this.panelFilter.Controls.Add(this.lblTanggalAwal);
            this.panelFilter.Controls.Add(this.dtpTanggalAwal);
            this.panelFilter.Controls.Add(this.lblTanggalAkhir);
            this.panelFilter.Controls.Add(this.dtpTanggalAkhir);
            this.panelFilter.Controls.Add(this.btnLoad);
            this.panelFilter.Controls.Add(this.btnCetak);
            this.panelFilter.Controls.Add(this.btnRefresh);
            this.panelFilter.Controls.Add(this.lblInfo);
            this.panelFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelFilter.Location = new System.Drawing.Point(0, 0);
            this.panelFilter.Name = "panelFilter";
            this.panelFilter.Padding = new System.Windows.Forms.Padding(20, 15, 20, 10);
            this.panelFilter.Size = new System.Drawing.Size(1100, 130);
            this.panelFilter.TabIndex = 1;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(20, 12);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(363, 37);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "📊 Rekap Data Hasil Giling";
            // 
            // lblTanggalAwal
            // 
            this.lblTanggalAwal.AutoSize = true;
            this.lblTanggalAwal.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblTanggalAwal.ForeColor = System.Drawing.Color.White;
            this.lblTanggalAwal.Location = new System.Drawing.Point(20, 55);
            this.lblTanggalAwal.Name = "lblTanggalAwal";
            this.lblTanggalAwal.Size = new System.Drawing.Size(114, 23);
            this.lblTanggalAwal.TabIndex = 1;
            this.lblTanggalAwal.Text = "Tanggal Awal:";
            // 
            // dtpTanggalAwal
            // 
            this.dtpTanggalAwal.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpTanggalAwal.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTanggalAwal.Location = new System.Drawing.Point(140, 52);
            this.dtpTanggalAwal.Name = "dtpTanggalAwal";
            this.dtpTanggalAwal.Size = new System.Drawing.Size(130, 30);
            this.dtpTanggalAwal.TabIndex = 2;
            this.dtpTanggalAwal.Value = new System.DateTime(2026, 5, 25, 15, 46, 53, 720);
            // 
            // lblTanggalAkhir
            // 
            this.lblTanggalAkhir.AutoSize = true;
            this.lblTanggalAkhir.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblTanggalAkhir.ForeColor = System.Drawing.Color.White;
            this.lblTanggalAkhir.Location = new System.Drawing.Point(300, 55);
            this.lblTanggalAkhir.Name = "lblTanggalAkhir";
            this.lblTanggalAkhir.Size = new System.Drawing.Size(117, 23);
            this.lblTanggalAkhir.TabIndex = 3;
            this.lblTanggalAkhir.Text = "Tanggal Akhir:";
            // 
            // dtpTanggalAkhir
            // 
            this.dtpTanggalAkhir.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpTanggalAkhir.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTanggalAkhir.Location = new System.Drawing.Point(430, 52);
            this.dtpTanggalAkhir.Name = "dtpTanggalAkhir";
            this.dtpTanggalAkhir.Size = new System.Drawing.Size(130, 30);
            this.dtpTanggalAkhir.TabIndex = 4;
            this.dtpTanggalAkhir.Value = new System.DateTime(2026, 6, 25, 15, 46, 53, 720);
            // 
            // btnLoad
            // 
            this.btnLoad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.btnLoad.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoad.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnLoad.ForeColor = System.Drawing.Color.White;
            this.btnLoad.Location = new System.Drawing.Point(590, 50);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(100, 35);
            this.btnLoad.TabIndex = 5;
            this.btnLoad.Text = "Tampilkan";
            this.btnLoad.UseVisualStyleBackColor = false;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnCetak
            // 
            this.btnCetak.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnCetak.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCetak.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCetak.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnCetak.ForeColor = System.Drawing.Color.White;
            this.btnCetak.Location = new System.Drawing.Point(700, 50);
            this.btnCetak.Name = "btnCetak";
            this.btnCetak.Size = new System.Drawing.Size(100, 35);
            this.btnCetak.TabIndex = 6;
            this.btnCetak.Text = "Cetak Data";
            this.btnCetak.UseVisualStyleBackColor = false;
            this.btnCetak.Click += new System.EventHandler(this.btnCetak_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(165)))), ((int)(((byte)(166)))));
            this.btnRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(810, 50);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(90, 35);
            this.btnRefresh.TabIndex = 7;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.lblInfo.Location = new System.Drawing.Point(22, 98);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(409, 20);
            this.lblInfo.TabIndex = 8;
            this.lblInfo.Text = "Pilih rentang tanggal, lalu klik \'Tampilkan\' untuk melihat data";
            // 
            // panelMain
            // 
            this.panelMain.BackColor = System.Drawing.Color.White;
            this.panelMain.Controls.Add(this.dgvData);
            this.panelMain.Controls.Add(this.crystalReportViewer1);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 130);
            this.panelMain.Name = "panelMain";
            this.panelMain.Padding = new System.Windows.Forms.Padding(50, 20, 50, 20);
            this.panelMain.Size = new System.Drawing.Size(1100, 570);
            this.panelMain.TabIndex = 0;
            // 
            // dgvData
            // 
            this.dgvData.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.dgvData.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvData.BackgroundColor = System.Drawing.Color.White;
            this.dgvData.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvData.ColumnHeadersHeight = 30;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvData.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvData.EnableHeadersVisualStyles = false;
            this.dgvData.Location = new System.Drawing.Point(50, 20);
            this.dgvData.Name = "dgvData";
            this.dgvData.ReadOnly = true;
            this.dgvData.RowHeadersWidth = 51;
            this.dgvData.RowTemplate.Height = 25;
            this.dgvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvData.Size = new System.Drawing.Size(1000, 530);
            this.dgvData.TabIndex = 1;
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = -1;
            this.crystalReportViewer1.BackColor = System.Drawing.Color.White;
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalReportViewer1.Location = new System.Drawing.Point(50, 20);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.ShowCloseButton = false;
            this.crystalReportViewer1.Size = new System.Drawing.Size(1000, 530);
            this.crystalReportViewer1.TabIndex = 2;
            this.crystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            this.crystalReportViewer1.Visible = false;
            // 
            // FormRekapDataGiling
            // 
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1100, 700);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panelFilter);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormRekapDataGiling";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "📊 Rekap Data Hasil Giling";
            this.Load += new System.EventHandler(this.FormRekapDataGiling_Load);
            this.panelFilter.ResumeLayout(false);
            this.panelFilter.PerformLayout();
            this.panelMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.ResumeLayout(false);

        }
    }
}