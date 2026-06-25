using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace Giling_Padi
{
    public partial class FormRekapDataGiling : Form
    {
        // ========== KONEKSI DATABASE ==========
        static string connectionString = "Data Source=.;Initial Catalog=GilinganPadi;Integrated Security=True;";
        SqlConnection conn = new SqlConnection(connectionString);
        SqlDataAdapter da;
        DataTable dtData;
        private ReportDocument report;

        // ========== CONSTRUCTOR DEFAULT ==========
        public FormRekapDataGiling()
        {
            InitializeComponent();
        }

        // ========== CONSTRUCTOR DENGAN PARAMETER ==========
        public FormRekapDataGiling(string connString)
        {
            InitializeComponent();
            connectionString = connString;
            conn = new SqlConnection(connectionString);
        }

        // ========== FORM_LOAD ==========
        private void FormRekapDataGiling_Load(object sender, EventArgs e)
        {
            dtpTanggalAwal.Value = DateTime.Now.AddMonths(-1);
            dtpTanggalAkhir.Value = DateTime.Now;
            crystalReportViewer1.Visible = false;
        }

        // ========== TOMBOL TAMPILKAN ==========
        private void btnLoad_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();

                string query = @"
                    SELECT 
                        p.nama AS NamaPetani,
                        p.no_telepon AS NoTelepon,
                        p.alamat AS Alamat,
                        a.berat_gabah AS BeratGabah,
                        ISNULL(h.beras_dihasilkan, 0) AS Beras,
                        ISNULL(h.dedak, 0) AS Dedak,
                        a.tanggal_giling AS TanggalGiling
                    FROM Antrian a
                    JOIN Petani p ON a.id_petani = p.id_petani
                    LEFT JOIN HasilGiling h ON a.id_antrian = h.id_antrian
                    WHERE a.status = 'selesai'
                    AND a.tanggal_giling BETWEEN @tanggalAwal AND @tanggalAkhir
                    ORDER BY p.nama, a.tanggal_giling DESC";

                da = new SqlDataAdapter(query, conn);
                da.SelectCommand.Parameters.AddWithValue("@tanggalAwal", dtpTanggalAwal.Value.Date);
                da.SelectCommand.Parameters.AddWithValue("@tanggalAkhir", dtpTanggalAkhir.Value.Date.AddDays(1).AddSeconds(-1));

                dtData = new DataTable();
                da.Fill(dtData);

                dgvData.DataSource = dtData;

                // ========== ATUR HEADER DATAGRIDVIEW ==========
                if (dgvData.Columns["NamaPetani"] != null)
                    dgvData.Columns["NamaPetani"].HeaderText = "Nama Petani";
                if (dgvData.Columns["NoTelepon"] != null)
                    dgvData.Columns["NoTelepon"].HeaderText = "No Telepon";
                if (dgvData.Columns["Alamat"] != null)
                    dgvData.Columns["Alamat"].HeaderText = "Alamat";
                if (dgvData.Columns["BeratGabah"] != null)
                {
                    dgvData.Columns["BeratGabah"].HeaderText = "Berat Gabah (kg)";
                    dgvData.Columns["BeratGabah"].DefaultCellStyle.Format = "N2";
                }
                if (dgvData.Columns["Beras"] != null)
                {
                    dgvData.Columns["Beras"].HeaderText = "Beras (kg)";
                    dgvData.Columns["Beras"].DefaultCellStyle.Format = "N2";
                }
                if (dgvData.Columns["Dedak"] != null)
                {
                    dgvData.Columns["Dedak"].HeaderText = "Dedak (kg)";
                    dgvData.Columns["Dedak"].DefaultCellStyle.Format = "N2";
                }
                if (dgvData.Columns["TanggalGiling"] != null)
                {
                    dgvData.Columns["TanggalGiling"].HeaderText = "Tanggal Giling";
                    dgvData.Columns["TanggalGiling"].DefaultCellStyle.Format = "dd/MM/yyyy";
                }

                conn.Close();

                if (dtData.Rows.Count == 0)
                {
                    lblInfo.Text = "⚠️ Tidak ada data untuk periode yang dipilih";
                    lblInfo.ForeColor = System.Drawing.Color.Orange;
                    btnCetak.Enabled = false;
                }
                else
                {
                    lblInfo.Text = $"✅ Menampilkan {dtData.Rows.Count} data untuk periode {dtpTanggalAwal.Value:dd/MM/yyyy} - {dtpTanggalAkhir.Value:dd/MM/yyyy}";
                    lblInfo.ForeColor = System.Drawing.Color.FromArgb(200, 200, 200);
                    btnCetak.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ========== HITUNG TOTAL PETANI ==========
        private int GetTotalPetani(DataTable dt)
        {
            System.Collections.Generic.List<string> petaniList = new System.Collections.Generic.List<string>();
            foreach (DataRow row in dt.Rows)
            {
                string nama = row["NamaPetani"].ToString();
                if (!petaniList.Contains(nama) && !string.IsNullOrEmpty(nama) && nama != "TOTAL" && nama != "GRAND TOTAL")
                {
                    petaniList.Add(nama);
                }
            }
            return petaniList.Count;
        }

        // ========== LOAD REPORT ==========
        private void LoadReport()
        {
            try
            {
                if (dtData == null || dtData.Rows.Count == 0)
                {
                    MessageBox.Show("Tidak ada data untuk dicetak!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // ========== COPY DATA ==========
                DataTable dt = dtData.Copy();

                // ========== HITUNG TOTAL ==========
                int totalData = dt.Rows.Count;
                int totalPetani = GetTotalPetani(dt);
                decimal totalGabah = 0, totalBeras = 0, totalDedak = 0;

                foreach (DataRow row in dt.Rows)
                {
                    totalGabah += Convert.ToDecimal(row["BeratGabah"]);
                    totalBeras += Convert.ToDecimal(row["Beras"]);
                    totalDedak += Convert.ToDecimal(row["Dedak"]);
                }

                // ========== TAMBAHKAN ROW TOTAL ==========
                DataRow totalRow = dt.NewRow();
                totalRow["NamaPetani"] = "TOTAL";
                totalRow["NoTelepon"] = "";
                totalRow["Alamat"] = "";
                totalRow["BeratGabah"] = totalGabah;
                totalRow["Beras"] = totalBeras;
                totalRow["Dedak"] = totalDedak;
                totalRow["TanggalGiling"] = DBNull.Value;
                dt.Rows.Add(totalRow);

                // ========== BUAT LAPORAN ==========
                report = new CrystalReportHasilGiling();
                report.SetDataSource(dt);

                // ========== SET PARAMETER ==========
                try
                {
                    var paramDefs = report.DataDefinition.ParameterFields;

                    string periode = $"{dtpTanggalAwal.Value:dd/MM/yyyy} - {dtpTanggalAkhir.Value:dd/MM/yyyy}";

                    if (paramDefs["Periode"] != null)
                    {
                        ParameterValues paramValues = new ParameterValues();
                        ParameterDiscreteValue discreteVal = new ParameterDiscreteValue();
                        discreteVal.Value = periode;
                        paramValues.Add(discreteVal);
                        paramDefs["Periode"].ApplyCurrentValues(paramValues);
                    }

                    if (paramDefs["TotalPetani"] != null)
                    {
                        ParameterValues paramValues = new ParameterValues();
                        ParameterDiscreteValue discreteVal = new ParameterDiscreteValue();
                        discreteVal.Value = totalPetani;
                        paramValues.Add(discreteVal);
                        paramDefs["TotalPetani"].ApplyCurrentValues(paramValues);
                    }

                    if (paramDefs["TanggalCetak"] != null)
                    {
                        ParameterValues paramValues = new ParameterValues();
                        ParameterDiscreteValue discreteVal = new ParameterDiscreteValue();
                        discreteVal.Value = DateTime.Now.ToString("dd MMMM yyyy HH:mm:ss");
                        paramValues.Add(discreteVal);
                        paramDefs["TanggalCetak"].ApplyCurrentValues(paramValues);
                    }

                    if (paramDefs["TotalGabah"] != null)
                    {
                        ParameterValues paramValues = new ParameterValues();
                        ParameterDiscreteValue discreteVal = new ParameterDiscreteValue();
                        discreteVal.Value = totalGabah;
                        paramValues.Add(discreteVal);
                        paramDefs["TotalGabah"].ApplyCurrentValues(paramValues);
                    }

                    if (paramDefs["TotalBeras"] != null)
                    {
                        ParameterValues paramValues = new ParameterValues();
                        ParameterDiscreteValue discreteVal = new ParameterDiscreteValue();
                        discreteVal.Value = totalBeras;
                        paramValues.Add(discreteVal);
                        paramDefs["TotalBeras"].ApplyCurrentValues(paramValues);
                    }

                    if (paramDefs["TotalDedak"] != null)
                    {
                        ParameterValues paramValues = new ParameterValues();
                        ParameterDiscreteValue discreteVal = new ParameterDiscreteValue();
                        discreteVal.Value = totalDedak;
                        paramValues.Add(discreteVal);
                        paramDefs["TotalDedak"].ApplyCurrentValues(paramValues);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Parameter error: " + ex.Message);
                }

                crystalReportViewer1.ReportSource = report;
                crystalReportViewer1.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ========== TOMBOL CETAK ==========
        private void btnCetak_Click(object sender, EventArgs e)
        {
            if (dtData == null || dtData.Rows.Count == 0)
            {
                MessageBox.Show("Tidak ada data untuk dicetak!\n\nSilakan klik 'Tampilkan' terlebih dahulu.",
                    "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Sembunyikan panel filter dan datagridview
                panelFilter.Visible = false;
                dgvData.Visible = false;

                // Tampilkan Crystal Report Viewer
                crystalReportViewer1.Visible = true;
                crystalReportViewer1.Dock = DockStyle.Fill;

                // Load Report
                LoadReport();

                // Ubah teks tombol
                btnCetak.Text = "📄 Kembali ke Data";
                btnCetak.Click -= btnCetak_Click;
                btnCetak.Click += btnKembali_Click;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ========== TOMBOL KEMBALI ==========
        private void btnKembali_Click(object sender, EventArgs e)
        {
            // Tampilkan kembali panel filter dan datagridview
            panelFilter.Visible = true;
            dgvData.Visible = true;

            // Sembunyikan Crystal Report Viewer
            crystalReportViewer1.Visible = false;

            // Reset tombol
            btnCetak.Text = "📄 Cetak Data";
            btnCetak.Click -= btnKembali_Click;
            btnCetak.Click += btnCetak_Click;

            // Close report
            if (report != null)
            {
                try
                {
                    report.Close();
                    report.Dispose();
                    report = null;
                }
                catch { }
            }
        }

        // ========== TOMBOL REFRESH ==========
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            dtpTanggalAwal.Value = DateTime.Now.AddMonths(-1);
            dtpTanggalAkhir.Value = DateTime.Now;
            dgvData.DataSource = null;
            crystalReportViewer1.Visible = false;
            panelFilter.Visible = true;
            dgvData.Visible = true;
            btnCetak.Text = "📄 Cetak Data";
            btnCetak.Click -= btnKembali_Click;
            btnCetak.Click += btnCetak_Click;
            lblInfo.Text = "Pilih rentang tanggal, lalu klik 'Tampilkan' untuk melihat data";
            lblInfo.ForeColor = System.Drawing.Color.FromArgb(200, 200, 200);
        }
    }
}