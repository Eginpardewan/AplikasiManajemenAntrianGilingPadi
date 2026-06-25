using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace AplikasiGilinganPadi
{
    public partial class FormDashboard : Form
    {
        private SqlConnection conn;
        private string connectionString;
        private int idAdmin;
        private string namaAdmin;

        // ========== CONSTRUCTOR DEFAULT ==========
        public FormDashboard()
        {
            InitializeComponent();
            connectionString = "Data Source=.;Initial Catalog=GilinganPadi;Integrated Security=True;";
            conn = new SqlConnection(connectionString);
            LoadDashboard();
        }

        // ========== CONSTRUCTOR 3 PARAMETER ==========
        public FormDashboard(int idAdmin, string namaAdmin, string connString)
        {
            InitializeComponent();
            this.idAdmin = idAdmin;
            this.namaAdmin = namaAdmin;
            this.connectionString = connString;
            conn = new SqlConnection(connectionString);

            // Tampilkan nama admin di title
            this.Text = $"📊 Dashboard - Selamat Datang, {namaAdmin}";

            LoadDashboard();
        }

        // ========== CONSTRUCTOR 1 PARAMETER ==========
        public FormDashboard(string connString)
        {
            InitializeComponent();
            this.connectionString = connString;
            conn = new SqlConnection(connectionString);
            LoadDashboard();
        }

        private void LoadDashboard()
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                LoadStatistics();
                LoadChartStatusAntrian();
                LoadChartHasilGiling();
                LoadChartTrendBulanan();
                LoadRecentAntrian();

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error load dashboard: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }

        // ========== 1. LOAD STATISTIK (4 CARD) ==========
        private void LoadStatistics()
        {
            try
            {
                // Total Antrian
                string queryTotalAntrian = "SELECT COUNT(*) FROM Antrian";
                SqlCommand cmdTotalAntrian = new SqlCommand(queryTotalAntrian, conn);
                int totalAntrian = Convert.ToInt32(cmdTotalAntrian.ExecuteScalar());
                lblTotalAntrianValue.Text = totalAntrian.ToString();

                // Total Petani
                string queryTotalPetani = "SELECT COUNT(*) FROM Petani";
                SqlCommand cmdTotalPetani = new SqlCommand(queryTotalPetani, conn);
                int totalPetani = Convert.ToInt32(cmdTotalPetani.ExecuteScalar());
                lblTotalPetaniValue.Text = totalPetani.ToString();

                // Total Beras
                string queryTotalBeras = "SELECT ISNULL(SUM(beras_dihasilkan), 0) FROM HasilGiling";
                SqlCommand cmdTotalBeras = new SqlCommand(queryTotalBeras, conn);
                decimal totalBeras = Convert.ToDecimal(cmdTotalBeras.ExecuteScalar());
                lblTotalBerasValue.Text = FormatDecimalWithComma(totalBeras) + " kg";

                // Total Dedak
                string queryTotalDedak = "SELECT ISNULL(SUM(dedak), 0) FROM HasilGiling";
                SqlCommand cmdTotalDedak = new SqlCommand(queryTotalDedak, conn);
                decimal totalDedak = Convert.ToDecimal(cmdTotalDedak.ExecuteScalar());
                lblTotalDedakValue.Text = FormatDecimalWithComma(totalDedak) + " kg";
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error load statistics: " + ex.Message);
            }
        }

        // ========== 2. CHART STATUS ANTRIAN ==========
        private void LoadChartStatusAntrian()
        {
            try
            {
                string query = @"SELECT status, COUNT(*) as Jumlah 
                                FROM Antrian 
                                GROUP BY status";

                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                chartStatusAntrian.Series.Clear();

                Series series = new Series();
                series.Name = "Status";
                series.ChartType = SeriesChartType.Doughnut;
                series["DoughnutRadius"] = "60";
                series["PieLabelStyle"] = "Disabled";
                series["PieDrawingStyle"] = "SoftEdge";
                chartStatusAntrian.Series.Add(series);

                Color[] colors = {
                    Color.FromArgb(241, 196, 15),
                    Color.FromArgb(52, 152, 219),
                    Color.FromArgb(39, 174, 96)
                };

                int i = 0;
                foreach (DataRow row in dt.Rows)
                {
                    string status = row["status"].ToString();
                    int jumlah = Convert.ToInt32(row["Jumlah"]);

                    DataPoint point = new DataPoint();
                    point.SetValueY(jumlah);
                    point.AxisLabel = status;
                    point.LegendText = status.ToUpper() + " (" + jumlah + ")";
                    point.Color = colors[i % colors.Length];
                    point.Label = jumlah > 0 ? jumlah.ToString() : "";
                    point.Font = new Font("Segoe UI", 9F, FontStyle.Bold);

                    chartStatusAntrian.Series["Status"].Points.Add(point);
                    i++;
                }

                if (dt.Rows.Count == 0)
                {
                    DataPoint point = new DataPoint();
                    point.SetValueY(1);
                    point.AxisLabel = "Tidak Ada Data";
                    point.LegendText = "Tidak Ada Data";
                    point.Color = Color.LightGray;
                    chartStatusAntrian.Series["Status"].Points.Add(point);
                }

                if (chartStatusAntrian.Legends.Count == 0)
                {
                    Legend legend = new Legend();
                    legend.Name = "LegendStatus";
                    legend.Docking = Docking.Bottom;
                    legend.Font = new Font("Segoe UI", 8F);
                    chartStatusAntrian.Legends.Add(legend);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error load chart status: " + ex.Message);
            }
        }

        // ========== 3. CHART HASIL GILING ==========
        private void LoadChartHasilGiling()
        {
            try
            {
                string query = @"SELECT TOP 10
                                    p.nama AS Petani,
                                    ISNULL(SUM(h.beras_dihasilkan), 0) AS TotalBeras,
                                    ISNULL(SUM(h.dedak), 0) AS TotalDedak
                                FROM Petani p
                                LEFT JOIN Antrian a ON p.id_petani = a.id_petani
                                LEFT JOIN HasilGiling h ON a.id_antrian = h.id_antrian
                                GROUP BY p.nama
                                HAVING SUM(h.beras_dihasilkan) > 0 OR SUM(h.dedak) > 0
                                ORDER BY TotalBeras DESC";

                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                chartHasilGiling.Series.Clear();

                Series seriesBeras = new Series();
                seriesBeras.Name = "Beras";
                seriesBeras.ChartType = SeriesChartType.Column;
                seriesBeras.Color = Color.FromArgb(39, 174, 96);
                seriesBeras.BorderColor = Color.White;
                seriesBeras.BorderWidth = 2;
                chartHasilGiling.Series.Add(seriesBeras);

                Series seriesDedak = new Series();
                seriesDedak.Name = "Dedak";
                seriesDedak.ChartType = SeriesChartType.Column;
                seriesDedak.Color = Color.FromArgb(155, 89, 182);
                seriesDedak.BorderColor = Color.White;
                seriesDedak.BorderWidth = 2;
                chartHasilGiling.Series.Add(seriesDedak);

                if (chartHasilGiling.Legends.Count == 0)
                {
                    Legend legend = new Legend();
                    legend.Name = "LegendHasil";
                    legend.Docking = Docking.Top;
                    legend.Font = new Font("Segoe UI", 8F);
                    legend.Alignment = StringAlignment.Center;
                    chartHasilGiling.Legends.Add(legend);
                }

                if (chartHasilGiling.ChartAreas.Count == 0)
                {
                    ChartArea chartArea = new ChartArea();
                    chartArea.Name = "ChartAreaHasil";
                    chartArea.BackColor = Color.White;
                    chartArea.AxisX.MajorGrid.Enabled = false;
                    chartArea.AxisY.MajorGrid.LineColor = Color.LightGray;
                    chartArea.AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dash;
                    chartArea.AxisY.Title = "Berat (kg)";
                    chartArea.AxisY.TitleFont = new Font("Segoe UI", 9F, FontStyle.Bold);
                    chartArea.AxisX.Title = "Petani";
                    chartArea.AxisX.TitleFont = new Font("Segoe UI", 9F, FontStyle.Bold);
                    chartHasilGiling.ChartAreas.Add(chartArea);
                }

                if (dt.Rows.Count == 0)
                {
                    DataPoint pointBeras = new DataPoint();
                    pointBeras.SetValueY(0);
                    pointBeras.AxisLabel = "Tidak Ada Data";
                    chartHasilGiling.Series["Beras"].Points.Add(pointBeras);

                    DataPoint pointDedak = new DataPoint();
                    pointDedak.SetValueY(0);
                    pointDedak.AxisLabel = "Tidak Ada Data";
                    chartHasilGiling.Series["Dedak"].Points.Add(pointDedak);
                    return;
                }

                foreach (DataRow row in dt.Rows)
                {
                    string petani = row["Petani"].ToString();
                    decimal beras = Convert.ToDecimal(row["TotalBeras"]);
                    decimal dedak = Convert.ToDecimal(row["TotalDedak"]);

                    DataPoint pointBeras = new DataPoint();
                    pointBeras.SetValueY((double)beras);
                    pointBeras.AxisLabel = petani;
                    pointBeras.Label = beras > 0 ? FormatDecimalWithComma(beras) : "";
                    pointBeras.Font = new Font("Segoe UI", 7F);
                    chartHasilGiling.Series["Beras"].Points.Add(pointBeras);

                    DataPoint pointDedak = new DataPoint();
                    pointDedak.SetValueY((double)dedak);
                    pointDedak.AxisLabel = petani;
                    pointDedak.Label = dedak > 0 ? FormatDecimalWithComma(dedak) : "";
                    pointDedak.Font = new Font("Segoe UI", 7F);
                    chartHasilGiling.Series["Dedak"].Points.Add(pointDedak);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error load chart hasil giling: " + ex.Message);
            }
        }

        // ========== 4. CHART TREND BULANAN ==========
        private void LoadChartTrendBulanan()
        {
            try
            {
                string query = @"SELECT 
                                    YEAR(tanggal_giling) as Tahun,
                                    MONTH(tanggal_giling) as Bulan,
                                    SUM(berat_gabah) as TotalGabah,
                                    COUNT(*) as JumlahAntrian
                                FROM Antrian
                                WHERE tanggal_giling >= DATEADD(MONTH, -6, GETDATE())
                                GROUP BY YEAR(tanggal_giling), MONTH(tanggal_giling)
                                ORDER BY Tahun, Bulan";

                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (chartTrendBulanan.Series.Count > 0)
                {
                    chartTrendBulanan.Series["Berat Gabah"].Points.Clear();
                }
                else
                {
                    Series seriesGabah = new Series();
                    seriesGabah.Name = "Berat Gabah";
                    seriesGabah.ChartType = SeriesChartType.Line;
                    seriesGabah.Color = Color.FromArgb(46, 204, 113);
                    seriesGabah.BorderWidth = 3;
                    seriesGabah.MarkerStyle = MarkerStyle.Circle;
                    seriesGabah.MarkerSize = 8;
                    chartTrendBulanan.Series.Add(seriesGabah);
                }

                if (chartTrendBulanan.Legends.Count == 0)
                {
                    Legend legend = new Legend();
                    legend.Name = "LegendTrend";
                    legend.Docking = Docking.Top;
                    legend.Font = new Font("Segoe UI", 8F);
                    legend.Alignment = StringAlignment.Center;
                    chartTrendBulanan.Legends.Add(legend);
                }

                if (chartTrendBulanan.ChartAreas.Count == 0)
                {
                    ChartArea chartArea = new ChartArea();
                    chartArea.Name = "ChartAreaTrend";
                    chartArea.BackColor = Color.White;
                    chartArea.AxisX.MajorGrid.Enabled = false;
                    chartArea.AxisY.MajorGrid.LineColor = Color.LightGray;
                    chartArea.AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dash;
                    chartArea.AxisY.Title = "Berat Gabah (kg)";
                    chartArea.AxisY.TitleFont = new Font("Segoe UI", 9F, FontStyle.Bold);
                    chartArea.AxisX.Title = "Bulan";
                    chartArea.AxisX.TitleFont = new Font("Segoe UI", 9F, FontStyle.Bold);
                    chartTrendBulanan.ChartAreas.Add(chartArea);
                }

                string[] namaBulan = { "Jan", "Feb", "Mar", "Apr", "Mei", "Jun", "Jul", "Agu", "Sep", "Okt", "Nov", "Des" };

                if (dt.Rows.Count == 0)
                {
                    DataPoint point = new DataPoint();
                    point.SetValueY(0);
                    point.AxisLabel = "Tidak Ada Data";
                    point.Label = "0 kg";
                    point.Font = new Font("Segoe UI", 7F);
                    chartTrendBulanan.Series["Berat Gabah"].Points.Add(point);
                    return;
                }

                foreach (DataRow row in dt.Rows)
                {
                    int bulan = Convert.ToInt32(row["Bulan"]);
                    int tahun = Convert.ToInt32(row["Tahun"]);
                    decimal totalGabah = Convert.ToDecimal(row["TotalGabah"]);
                    int jumlahAntrian = Convert.ToInt32(row["JumlahAntrian"]);

                    string label = namaBulan[bulan - 1] + " " + tahun;
                    DataPoint point = new DataPoint();
                    point.SetValueY((double)totalGabah);
                    point.AxisLabel = label;
                    point.Label = FormatDecimalWithComma(totalGabah) + " kg";
                    point.Font = new Font("Segoe UI", 7F);
                    point.ToolTip = $"{label}\nTotal Gabah: {FormatDecimalWithComma(totalGabah)} kg\nJumlah Antrian: {jumlahAntrian}";
                    point.MarkerColor = Color.FromArgb(46, 204, 113);
                    point.MarkerStyle = MarkerStyle.Circle;
                    point.MarkerSize = 8;

                    chartTrendBulanan.Series["Berat Gabah"].Points.Add(point);
                }

                chartTrendBulanan.Series["Berat Gabah"].Color = Color.FromArgb(46, 204, 113);
                chartTrendBulanan.Series["Berat Gabah"].BorderWidth = 3;
                chartTrendBulanan.Series["Berat Gabah"].MarkerStyle = MarkerStyle.Circle;
                chartTrendBulanan.Series["Berat Gabah"].MarkerSize = 8;
                chartTrendBulanan.Series["Berat Gabah"].MarkerColor = Color.FromArgb(46, 204, 113);
                chartTrendBulanan.ChartAreas["ChartAreaTrend"].AxisX.MajorGrid.Enabled = false;
                chartTrendBulanan.ChartAreas["ChartAreaTrend"].AxisY.MajorGrid.LineColor = Color.LightGray;
                chartTrendBulanan.ChartAreas["ChartAreaTrend"].AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dash;
                chartTrendBulanan.ChartAreas["ChartAreaTrend"].AxisY.Minimum = 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error load chart trend: " + ex.Message);
            }
        }

        // ========== 5. LOAD RECENT ANTRIAN ==========
        private void LoadRecentAntrian()
        {
            try
            {
                string query = @"SELECT TOP 10 
                                    a.nomor_antrian as 'No Antrian',
                                    p.nama as 'Petani',
                                    a.berat_gabah as 'Berat Gabah',
                                    a.tanggal_giling as 'Tanggal',
                                    a.status as 'Status'
                                FROM Antrian a
                                JOIN Petani p ON a.id_petani = p.id_petani
                                ORDER BY a.tanggal_giling DESC, a.nomor_antrian DESC";

                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvRecentAntrian.DataSource = dt;

                if (dgvRecentAntrian.Columns["Berat Gabah"] != null)
                {
                    dgvRecentAntrian.Columns["Berat Gabah"].DefaultCellStyle.Format = "N0";
                }
                if (dgvRecentAntrian.Columns["Tanggal"] != null)
                {
                    dgvRecentAntrian.Columns["Tanggal"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
                }

                dgvRecentAntrian.CellFormatting += (s, e) =>
                {
                    if (e.ColumnIndex == dgvRecentAntrian.Columns["Status"].Index && e.RowIndex >= 0)
                    {
                        string status = e.Value?.ToString()?.ToLower() ?? "";
                        switch (status)
                        {
                            case "menunggu":
                                e.CellStyle.ForeColor = Color.FromArgb(241, 196, 15);
                                e.CellStyle.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
                                break;
                            case "proses":
                                e.CellStyle.ForeColor = Color.FromArgb(52, 152, 219);
                                e.CellStyle.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
                                break;
                            case "selesai":
                                e.CellStyle.ForeColor = Color.FromArgb(39, 174, 96);
                                e.CellStyle.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
                                break;
                        }
                    }
                };

                dgvRecentAntrian.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error load recent: " + ex.Message);
            }
        }

        // ========== FORMAT ANGKA DENGAN KOMA ==========
        private string FormatDecimalWithComma(decimal value)
        {
            return value.ToString("#,0.##", new CultureInfo("id-ID"));
        }

        // ========== TOMBOL REFRESH ==========
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                LoadDashboard();
                conn.Close();

                MessageBox.Show("✅ Dashboard berhasil direfresh!", "Info",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error refresh: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ========== TOMBOL VIEW ALL (DIPERBAIKI) ==========
        private void btnViewAll_Click(object sender, EventArgs e)
        {
            try
            {
                // Tutup Dashboard
                this.Close();

                // Buka FormUtama
                FormUtama formUtama = new FormUtama(idAdmin, namaAdmin, connectionString);
                formUtama.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error membuka FormUtama: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ========== FORM CLOSING ==========
        private void FormDashboard_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (conn != null && conn.State == ConnectionState.Open)
            {
                conn.Close();
                conn.Dispose();
            }
        }
    }
}