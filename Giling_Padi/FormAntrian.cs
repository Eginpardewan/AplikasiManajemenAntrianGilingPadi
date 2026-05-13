using System;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Windows.Forms;

namespace AplikasiGilinganPadi
{
    public partial class FormAntrian : Form
    {
        private SqlConnection conn;
        private string connectionString;
        private int idAntrian;
        private bool isEdit = false;
        private DateTime tanggalAwal;
        private DateTime minDate;
        private DateTime maxDate;
        private int idPetaniTerpilih = 0;
        private DataTable dtPetani;

        public FormAntrian(string connString, int id)
        {
            InitializeComponent();
            connectionString = connString;
            conn = new SqlConnection(connectionString);
            idAntrian = id;
            isEdit = (id > 0);

            LoadPetaniToComboBox();

            if (isEdit)
            {
                this.Text = "✏️ Edit Antrian";
                btnSimpan.Text = "✅ Update";
                LoadData();
            }
            else
            {
                this.Text = "➕ Tambah Antrian Baru";
                btnSimpan.Text = "💾 Simpan";
                GenerateNomorAntrian();
                dtpTanggal.Value = DateTime.Today;
                minDate = DateTime.Today;
                maxDate = DateTime.Today.AddDays(7);
            }
        }

        private void LoadPetaniToComboBox()
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                string query = "SELECT id_petani, nama, alamat, no_telepon FROM Petani ORDER BY nama";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                dtPetani = new DataTable();
                da.Fill(dtPetani);

                cmbNamaPetani.DataSource = dtPetani;
                cmbNamaPetani.DisplayMember = "nama";
                cmbNamaPetani.ValueMember = "id_petani";
                cmbNamaPetani.SelectedIndex = -1;

                cmbNamaPetani.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                cmbNamaPetani.AutoCompleteSource = AutoCompleteSource.ListItems;

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading petani: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbNamaPetani_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbNamaPetani.SelectedValue != null && cmbNamaPetani.SelectedValue is int)
            {
                idPetaniTerpilih = (int)cmbNamaPetani.SelectedValue;

                foreach (DataRow row in dtPetani.Rows)
                {
                    if (Convert.ToInt32(row["id_petani"]) == idPetaniTerpilih)
                    {
                        txtAlamat.Text = row["alamat"].ToString();
                        txtNoTelepon.Text = row["no_telepon"].ToString();
                        break;
                    }
                }
            }
        }

        private void GenerateNomorAntrian()
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                string query = "SELECT ISNULL(MAX(nomor_antrian), 0) + 1 FROM Antrian";
                SqlCommand cmd = new SqlCommand(query, conn);
                int nomor = Convert.ToInt32(cmd.ExecuteScalar());
                txtNomorAntrian.Text = nomor.ToString();

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error generate nomor: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadData()
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                string query = @"SELECT a.id_antrian, a.id_petani, a.nomor_antrian, 
                                        a.berat_gabah, a.tanggal_giling, a.status,
                                        p.nama, p.alamat, p.no_telepon
                                 FROM Antrian a
                                 JOIN Petani p ON a.id_petani = p.id_petani
                                 WHERE a.id_antrian = @id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", idAntrian);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    idPetaniTerpilih = reader.GetInt32(1);
                    txtNomorAntrian.Text = reader["nomor_antrian"].ToString();

                    // Format angka dengan koma
                    decimal beratGabah = Convert.ToDecimal(reader["berat_gabah"]);
                    txtBeratGabah.Text = FormatDecimalWithComma(beratGabah);

                    tanggalAwal = Convert.ToDateTime(reader["tanggal_giling"]);
                    dtpTanggal.Value = tanggalAwal;
                    cmbStatus.SelectedItem = reader["status"].ToString();

                    cmbNamaPetani.SelectedValue = idPetaniTerpilih;

                    minDate = tanggalAwal;
                    maxDate = tanggalAwal.AddDays(7);
                }
                reader.Close();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error load data: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateTanggal()
        {
            DateTime selectedDate = dtpTanggal.Value.Date;

            if (!isEdit)
            {
                if (selectedDate < minDate)
                {
                    MessageBox.Show($"❌ Tanggal tidak boleh kurang dari {minDate:dd/MM/yyyy}!", "Validasi",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dtpTanggal.Value = minDate;
                    return false;
                }
                if (selectedDate > maxDate)
                {
                    MessageBox.Show($"❌ Tanggal tidak boleh lebih dari {maxDate:dd/MM/yyyy}!", "Validasi",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dtpTanggal.Value = maxDate;
                    return false;
                }
            }
            else
            {
                if (selectedDate < minDate)
                {
                    MessageBox.Show($"❌ Tanggal tidak boleh kurang dari {minDate:dd/MM/yyyy}!", "Validasi",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dtpTanggal.Value = minDate;
                    return false;
                }
                if (selectedDate > maxDate)
                {
                    MessageBox.Show($"❌ Tanggal tidak boleh lebih dari {maxDate:dd/MM/yyyy}!", "Validasi",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dtpTanggal.Value = maxDate;
                    return false;
                }
            }
            return true;
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            if (cmbNamaPetani.SelectedIndex == -1)
            {
                MessageBox.Show("❌ Pilih Nama Petani terlebih dahulu!", "Validasi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbNamaPetani.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtBeratGabah.Text))
            {
                MessageBox.Show("❌ Berat Gabah harus diisi!", "Validasi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtBeratGabah.Focus();
                return;
            }

            // Parse angka dengan dukungan koma
            decimal beratGabah = ParseDecimalWithComma(txtBeratGabah.Text);

            if (beratGabah <= 0)
            {
                MessageBox.Show("❌ Berat Gabah harus berupa angka positif!\nContoh: 100,5 atau 100.5", "Validasi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtBeratGabah.Focus();
                return;
            }

            if (cmbStatus.SelectedItem == null)
            {
                MessageBox.Show("❌ Pilih Status Antrian terlebih dahulu!", "Validasi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbStatus.Focus();
                return;
            }

            if (!ValidateTanggal())
                return;

            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                if (isEdit)
                {
                    string query = @"UPDATE Antrian 
                                    SET id_petani = @id_petani, 
                                        berat_gabah = @berat, 
                                        tanggal_giling = @tanggal, 
                                        status = @status 
                                    WHERE id_antrian = @id";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id_petani", idPetaniTerpilih);
                    cmd.Parameters.AddWithValue("@berat", beratGabah);
                    cmd.Parameters.AddWithValue("@tanggal", dtpTanggal.Value);
                    cmd.Parameters.AddWithValue("@status", cmbStatus.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@id", idAntrian);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("✅ Data antrian berhasil diupdate!", "Sukses",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    string query = @"INSERT INTO Antrian 
                                    (id_petani, nomor_antrian, berat_gabah, tanggal_giling, status) 
                                    VALUES (@id_petani, @nomor, @berat, @tanggal, @status)";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id_petani", idPetaniTerpilih);
                    cmd.Parameters.AddWithValue("@nomor", Convert.ToInt32(txtNomorAntrian.Text));
                    cmd.Parameters.AddWithValue("@berat", beratGabah);
                    cmd.Parameters.AddWithValue("@tanggal", dtpTanggal.Value);
                    cmd.Parameters.AddWithValue("@status", cmbStatus.SelectedItem.ToString());
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("✅ Antrian baru berhasil ditambahkan!", "Sukses",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                conn.Close();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }

        private void btnBatal_Click(object sender, EventArgs e)
        {
            DialogResult confirm = MessageBox.Show("Yakin ingin membatalkan?",
                "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
                this.Close();
        }

        // ========== KONVERSI ANGKA DENGAN DUKUNGAN KOMA ==========
        private decimal ParseDecimalWithComma(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return 0;

            // Ganti koma dengan titik untuk parsing
            string normalized = input.Trim().Replace(',', '.');

            if (decimal.TryParse(normalized, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal result))
                return result;

            return 0;
        }

        private string FormatDecimalWithComma(decimal value)
        {
            // Format dengan koma sebagai pemisah desimal
            return value.ToString("#,0.##", new CultureInfo("id-ID"));
        }

        // ========== KEYPRESS UNTUK BERAT (DENGAN KOMA) ==========
        private void txtBeratGabah_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Izinkan backspace, delete, enter, tab
            if (char.IsControl(e.KeyChar))
                return;

            // Izinkan angka, koma, dan titik
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != ',' && e.KeyChar != '.')
            {
                e.Handled = true;
                return;
            }

            // Cegah lebih dari satu koma atau titik
            TextBox txt = sender as TextBox;
            if ((e.KeyChar == ',' || e.KeyChar == '.') && (txt.Text.Contains(",") || txt.Text.Contains(".")))
            {
                e.Handled = true;
                return;
            }
        }

        private void FormAntrian_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (conn != null && conn.State == ConnectionState.Open)
            {
                conn.Close();
                conn.Dispose();
            }
        }
    }
}