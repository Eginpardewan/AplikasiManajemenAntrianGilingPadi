using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace AplikasiGilinganPadi
{
    partial class FormDashboard
    {
        private System.ComponentModel.IContainer components = null;

        private Panel panelHeader;
        private Panel panelMain;
        private Panel panelStats;
        private Panel panelCharts;
        private Panel panelRecent;
        private Panel panelButton;

        private Label lblTitle;
        private Label lblDateTime;

        // 4 Card
        private Panel cardTotalAntrian;
        private Panel cardTotalPetani;
        private Panel cardTotalBeras;
        private Panel cardTotalDedak;

        private Label lblTotalAntrianValue;
        private Label lblTotalPetaniValue;
        private Label lblTotalBerasValue;
        private Label lblTotalDedakValue;

        // 3 Charts
        private Chart chartStatusAntrian;
        private Chart chartHasilGiling;
        private Chart chartTrendBulanan;

        // DataGridView
        private DataGridView dgvRecentAntrian;

        // Buttons
        private Button btnRefresh;
        private Button btnViewAll;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();

            // ========== FORM ==========
            this.ClientSize = new System.Drawing.Size(1200, 800);
            this.Text = "📊 Dashboard - Aplikasi Gilingan Padi";
            this.StartPosition = FormStartPosition.CenterParent;
            this.BackColor = System.Drawing.Color.FromArgb(236, 240, 241);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.FormClosing += new FormClosingEventHandler(this.FormDashboard_FormClosing);

            // ========== HEADER ==========
            this.panelHeader = new Panel();
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(52, 73, 94);
            this.panelHeader.Dock = DockStyle.Top;
            this.panelHeader.Height = 75;
            this.panelHeader.Padding = new Padding(25, 15, 25, 10);

            this.lblTitle = new Label();
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            this.lblTitle.ForeColor = Color.White;
            this.lblTitle.Location = new System.Drawing.Point(20, 15);
            this.lblTitle.Text = "📊 Dashboard Gilingan Padi";

            this.lblDateTime = new Label();
            this.lblDateTime.AutoSize = true;
            this.lblDateTime.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.lblDateTime.ForeColor = System.Drawing.Color.FromArgb(241, 196, 15);
            this.lblDateTime.Location = new System.Drawing.Point(850, 22);
            this.lblDateTime.Text = DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss");

            this.panelHeader.Controls.Add(this.lblTitle);
            this.panelHeader.Controls.Add(this.lblDateTime);

            // ========== MAIN PANEL ==========
            this.panelMain = new Panel();
            this.panelMain.BackColor = System.Drawing.Color.FromArgb(236, 240, 241);
            this.panelMain.Dock = DockStyle.Fill;
            this.panelMain.Padding = new Padding(20);
            this.panelMain.AutoScroll = true;

            // ========== STATISTIK (4 CARD) ==========
            this.panelStats = new Panel();
            this.panelStats.Dock = DockStyle.Top;
            this.panelStats.Height = 120;
            this.panelStats.BackColor = Color.Transparent;
            this.panelStats.Padding = new Padding(5);

            this.cardTotalAntrian = CreateCard("📋", "Total Antrian", "0", Color.FromArgb(52, 152, 219), 5, out lblTotalAntrianValue);
            this.cardTotalPetani = CreateCard("👨‍🌾", "Total Petani", "0", Color.FromArgb(39, 174, 96), 285, out lblTotalPetaniValue);
            this.cardTotalBeras = CreateCard("🍚", "Total Beras", "0 kg", Color.FromArgb(155, 89, 182), 565, out lblTotalBerasValue);
            this.cardTotalDedak = CreateCard("🌾", "Total Dedak", "0 kg", Color.FromArgb(241, 196, 15), 845, out lblTotalDedakValue);

            this.panelStats.Controls.Add(this.cardTotalAntrian);
            this.panelStats.Controls.Add(this.cardTotalPetani);
            this.panelStats.Controls.Add(this.cardTotalBeras);
            this.panelStats.Controls.Add(this.cardTotalDedak);

            // ========== CHARTS PANEL ==========
            this.panelCharts = new Panel();
            this.panelCharts.Dock = DockStyle.Top;
            this.panelCharts.Height = 370;
            this.panelCharts.BackColor = Color.Transparent;
            this.panelCharts.Padding = new Padding(5);

            // Chart 1: Status Antrian (Donut) - Kiri
            this.chartStatusAntrian = new Chart();
            this.chartStatusAntrian.Location = new System.Drawing.Point(5, 10);
            this.chartStatusAntrian.Size = new System.Drawing.Size(380, 350);
            this.chartStatusAntrian.BackColor = Color.White;
            this.chartStatusAntrian.BorderlineColor = Color.LightGray;
            this.chartStatusAntrian.BorderlineWidth = 1;

            ChartArea chartAreaStatus = new ChartArea();
            chartAreaStatus.Name = "ChartAreaStatus";
            chartAreaStatus.BackColor = Color.White;
            this.chartStatusAntrian.ChartAreas.Add(chartAreaStatus);

            Title titleStatus = new Title();
            titleStatus.Text = "📌 Status Antrian";
            titleStatus.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            titleStatus.ForeColor = Color.FromArgb(52, 73, 94);
            this.chartStatusAntrian.Titles.Add(titleStatus);

            Legend legendStatus = new Legend();
            legendStatus.Name = "LegendStatus";
            legendStatus.Docking = Docking.Bottom;
            legendStatus.Font = new Font("Segoe UI", 9F);
            legendStatus.Alignment = StringAlignment.Center;
            this.chartStatusAntrian.Legends.Add(legendStatus);

            Series seriesStatus = new Series();
            seriesStatus.Name = "Status";
            seriesStatus.ChartType = SeriesChartType.Doughnut;
            seriesStatus["DoughnutRadius"] = "60";
            seriesStatus["PieLabelStyle"] = "Disabled";
            seriesStatus["PieDrawingStyle"] = "SoftEdge";
            this.chartStatusAntrian.Series.Add(seriesStatus);

            // Chart 2: Hasil Giling (Column) - Tengah
            this.chartHasilGiling = new Chart();
            this.chartHasilGiling.Location = new System.Drawing.Point(400, 10);
            this.chartHasilGiling.Size = new System.Drawing.Size(380, 350);
            this.chartHasilGiling.BackColor = Color.White;
            this.chartHasilGiling.BorderlineColor = Color.LightGray;
            this.chartHasilGiling.BorderlineWidth = 1;

            ChartArea chartAreaHasil = new ChartArea();
            chartAreaHasil.Name = "ChartAreaHasil";
            chartAreaHasil.BackColor = Color.White;
            chartAreaHasil.AxisX.MajorGrid.Enabled = false;
            chartAreaHasil.AxisY.MajorGrid.LineColor = Color.LightGray;
            chartAreaHasil.AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dash;
            chartAreaHasil.AxisY.Title = "Berat (kg)";
            chartAreaHasil.AxisY.TitleFont = new Font("Segoe UI", 9F, FontStyle.Bold);
            chartAreaHasil.AxisX.Title = "Petani";
            chartAreaHasil.AxisX.TitleFont = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.chartHasilGiling.ChartAreas.Add(chartAreaHasil);

            Title titleHasil = new Title();
            titleHasil.Text = "📊 Hasil Giling per Petani";
            titleHasil.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            titleHasil.ForeColor = Color.FromArgb(52, 73, 94);
            this.chartHasilGiling.Titles.Add(titleHasil);

            Legend legendHasil = new Legend();
            legendHasil.Name = "LegendHasil";
            legendHasil.Docking = Docking.Top;
            legendHasil.Font = new Font("Segoe UI", 9F);
            legendHasil.Alignment = StringAlignment.Center;
            this.chartHasilGiling.Legends.Add(legendHasil);

            Series seriesBeras = new Series();
            seriesBeras.Name = "Beras";
            seriesBeras.ChartType = SeriesChartType.Column;
            seriesBeras.Color = Color.FromArgb(39, 174, 96);
            seriesBeras.BorderColor = Color.White;
            seriesBeras.BorderWidth = 2;
            this.chartHasilGiling.Series.Add(seriesBeras);

            Series seriesDedak = new Series();
            seriesDedak.Name = "Dedak";
            seriesDedak.ChartType = SeriesChartType.Column;
            seriesDedak.Color = Color.FromArgb(155, 89, 182);
            seriesDedak.BorderColor = Color.White;
            seriesDedak.BorderWidth = 2;
            this.chartHasilGiling.Series.Add(seriesDedak);

            // Chart 3: Trend Bulanan (Line) - Kanan
            this.chartTrendBulanan = new Chart();
            this.chartTrendBulanan.Location = new System.Drawing.Point(795, 10);
            this.chartTrendBulanan.Size = new System.Drawing.Size(370, 350);
            this.chartTrendBulanan.BackColor = Color.White;
            this.chartTrendBulanan.BorderlineColor = Color.LightGray;
            this.chartTrendBulanan.BorderlineWidth = 1;

            ChartArea chartAreaTrend = new ChartArea();
            chartAreaTrend.Name = "ChartAreaTrend";
            chartAreaTrend.BackColor = Color.White;
            chartAreaTrend.AxisX.MajorGrid.Enabled = false;
            chartAreaTrend.AxisY.MajorGrid.LineColor = Color.LightGray;
            chartAreaTrend.AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dash;
            chartAreaTrend.AxisY.Title = "Berat (kg)";
            chartAreaTrend.AxisY.TitleFont = new Font("Segoe UI", 9F, FontStyle.Bold);
            chartAreaTrend.AxisX.Title = "Bulan";
            chartAreaTrend.AxisX.TitleFont = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.chartTrendBulanan.ChartAreas.Add(chartAreaTrend);

            Title titleTrend = new Title();
            titleTrend.Text = "📈 Trend Bulanan";
            titleTrend.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            titleTrend.ForeColor = Color.FromArgb(52, 73, 94);
            this.chartTrendBulanan.Titles.Add(titleTrend);

            Legend legendTrend = new Legend();
            legendTrend.Name = "LegendTrend";
            legendTrend.Docking = Docking.Top;
            legendTrend.Font = new Font("Segoe UI", 9F);
            legendTrend.Alignment = StringAlignment.Center;
            this.chartTrendBulanan.Legends.Add(legendTrend);

            Series seriesTrend = new Series();
            seriesTrend.Name = "Berat Gabah";
            seriesTrend.ChartType = SeriesChartType.Line;
            seriesTrend.Color = Color.FromArgb(46, 204, 113);
            seriesTrend.BorderWidth = 3;
            seriesTrend.MarkerStyle = MarkerStyle.Circle;
            seriesTrend.MarkerSize = 8;
            this.chartTrendBulanan.Series.Add(seriesTrend);

            this.panelCharts.Controls.Add(this.chartStatusAntrian);
            this.panelCharts.Controls.Add(this.chartHasilGiling);
            this.panelCharts.Controls.Add(this.chartTrendBulanan);

            // ========== RECENT PANEL ==========
            this.panelRecent = new Panel();
            this.panelRecent.Dock = DockStyle.Top;
            this.panelRecent.Height = 230;
            this.panelRecent.BackColor = Color.Transparent;
            this.panelRecent.Padding = new Padding(5);

            GroupBox groupBoxRecent = new GroupBox();
            groupBoxRecent.Text = "🔄 Antrian Terbaru";
            groupBoxRecent.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            groupBoxRecent.Location = new System.Drawing.Point(5, 10);
            groupBoxRecent.Size = new System.Drawing.Size(1160, 210);
            groupBoxRecent.BackColor = Color.White;
            groupBoxRecent.Padding = new Padding(10);

            this.dgvRecentAntrian = new DataGridView();
            this.dgvRecentAntrian.Dock = DockStyle.Fill;
            this.dgvRecentAntrian.BackgroundColor = Color.White;
            this.dgvRecentAntrian.BorderStyle = BorderStyle.None;
            this.dgvRecentAntrian.ColumnHeadersHeight = 35;
            this.dgvRecentAntrian.RowTemplate.Height = 30;
            this.dgvRecentAntrian.AllowUserToAddRows = false;
            this.dgvRecentAntrian.ReadOnly = true;
            this.dgvRecentAntrian.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvRecentAntrian.MultiSelect = false;
            this.dgvRecentAntrian.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            // ========== STYLE DATAGRIDVIEW ==========
            this.dgvRecentAntrian.EnableHeadersVisualStyles = false;
            this.dgvRecentAntrian.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.dgvRecentAntrian.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(52, 73, 94);
            this.dgvRecentAntrian.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            this.dgvRecentAntrian.DefaultCellStyle.Font = new Font("Segoe UI", 9F);
            this.dgvRecentAntrian.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(52, 73, 94);
            this.dgvRecentAntrian.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(240, 240, 240);

            groupBoxRecent.Controls.Add(this.dgvRecentAntrian);
            this.panelRecent.Controls.Add(groupBoxRecent);

            // ========== BUTTON PANEL ==========
            this.panelButton = new Panel();
            this.panelButton.BackColor = System.Drawing.Color.FromArgb(44, 62, 80);
            this.panelButton.Dock = DockStyle.Bottom;
            this.panelButton.Height = 60;
            this.panelButton.Padding = new Padding(15);

            this.btnRefresh = new Button();
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(52, 152, 219);
            this.btnRefresh.Cursor = Cursors.Hand;
            this.btnRefresh.FlatStyle = FlatStyle.Flat;
            this.btnRefresh.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnRefresh.ForeColor = Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(10, 10);
            this.btnRefresh.Size = new System.Drawing.Size(130, 38);
            this.btnRefresh.Text = "🔄 Refresh";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new EventHandler(this.btnRefresh_Click);

            this.btnViewAll = new Button();
            this.btnViewAll.BackColor = System.Drawing.Color.FromArgb(39, 174, 96);
            this.btnViewAll.Cursor = Cursors.Hand;
            this.btnViewAll.FlatStyle = FlatStyle.Flat;
            this.btnViewAll.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnViewAll.ForeColor = Color.White;
            this.btnViewAll.Location = new System.Drawing.Point(150, 10);
            this.btnViewAll.Size = new System.Drawing.Size(130, 38);
            this.btnViewAll.Text = "📋 Lihat Semua";
            this.btnViewAll.UseVisualStyleBackColor = false;
            this.btnViewAll.Click += new EventHandler(this.btnViewAll_Click);

            this.panelButton.Controls.Add(this.btnRefresh);
            this.panelButton.Controls.Add(this.btnViewAll);

            // ========== ADD CONTROLS ==========
            this.panelMain.Controls.Add(this.panelStats);
            this.panelMain.Controls.Add(this.panelCharts);
            this.panelMain.Controls.Add(this.panelRecent);

            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panelButton);
            this.Controls.Add(this.panelHeader);

            // ========== TIMER ==========
            Timer timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += (s, e) =>
                lblDateTime.Text = DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss");
            timer.Start();

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private Panel CreateCard(string icon, string label, string value, Color color, int x, out Label lblValue)
        {
            Panel card = new Panel();
            card.BackColor = Color.White;
            card.Location = new System.Drawing.Point(x, 10);
            card.Size = new System.Drawing.Size(270, 85);
            card.BorderStyle = BorderStyle.FixedSingle;
            card.Padding = new Padding(15);

            Label lblIcon = new Label();
            lblIcon.AutoSize = true;
            lblIcon.Font = new Font("Segoe UI", 22F);
            lblIcon.Location = new System.Drawing.Point(12, 12);
            lblIcon.Text = icon;

            Label lblLabel = new Label();
            lblLabel.AutoSize = true;
            lblLabel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblLabel.ForeColor = Color.Gray;
            lblLabel.Location = new System.Drawing.Point(65, 15);
            lblLabel.Text = label;

            lblValue = new Label();
            lblValue.AutoSize = true;
            lblValue.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblValue.ForeColor = color;
            lblValue.Location = new System.Drawing.Point(65, 42);
            lblValue.Text = value;

            card.Controls.Add(lblIcon);
            card.Controls.Add(lblLabel);
            card.Controls.Add(lblValue);

            return card;
        }
    }
}