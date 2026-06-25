using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace AplikasiGilinganPadi
{
    public class DAL
    {
        public static string GetLocalIPAddress()
        {
            string localIP = string.Empty;
            try
            {
                var host = System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName());
                foreach (var ip in host.AddressList)
                {
                    if (ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                    {
                        localIP = ip.ToString();
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getting local IP address: " + ex.Message);
            }
            return localIP;
        }

        public static string GetConnectionString()
        {
            string connectionString = $"Data Source={GetLocalIPAddress()};Initial Catalog=GilinganPadi;User ID=sa;Password=PasswordSA;";
            return connectionString;
        }

        // ========== Connection String ==========
        private static string connectionString = GetConnectionString();
        private SqlConnection conn;
        private SqlDataAdapter da;
        private DataTable dt;

        public DAL()
        {
            conn = new SqlConnection(connectionString);
        }

        // ========== OPEN / CLOSE CONNECTION ==========
        private void OpenConnection()
        {
            if (conn.State == ConnectionState.Closed)
                conn.Open();
        }

        private void CloseConnection()
        {
            if (conn.State == ConnectionState.Open)
                conn.Close();
        }

        // ============================================================
        // 1. LOGIN
        // ============================================================
        public bool Login(string email, string password)
        {
            try
            {
                OpenConnection();
                string query = "SELECT COUNT(*) FROM Admin WHERE email = @email AND password = @pass";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@pass", password);
                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error login: " + ex.Message);
                return false;
            }
            finally
            {
                CloseConnection();
            }
        }

        // ============================================================
        // 2. CRUD PETANI
        // ============================================================

        // 2a. Get All Petani
        public DataTable GetPetani()
        {
            try
            {
                OpenConnection();
                string query = "SELECT id_petani, nama, alamat, no_telepon FROM Petani ORDER BY nama";
                da = new SqlDataAdapter(query, conn);
                dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error get petani: " + ex.Message);
                return null;
            }
            finally
            {
                CloseConnection();
            }
        }

        // 2b. Insert Petani
        public void InsertPetani(string nama, string alamat, string noTelepon)
        {
            try
            {
                OpenConnection();
                string query = "INSERT INTO Petani (nama, alamat, no_telepon) VALUES (@nama, @alamat, @noTelp)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@nama", nama);
                cmd.Parameters.AddWithValue("@alamat", alamat);
                cmd.Parameters.AddWithValue("@noTelp", noTelepon);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error insert petani: " + ex.Message);
                throw;
            }
            finally
            {
                CloseConnection();
            }
        }

        // 2c. Update Petani
        public void UpdatePetani(int idPetani, string nama, string alamat, string noTelepon)
        {
            try
            {
                OpenConnection();
                string query = "UPDATE Petani SET nama = @nama, alamat = @alamat, no_telepon = @noTelp WHERE id_petani = @id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", idPetani);
                cmd.Parameters.AddWithValue("@nama", nama);
                cmd.Parameters.AddWithValue("@alamat", alamat);
                cmd.Parameters.AddWithValue("@noTelp", noTelepon);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error update petani: " + ex.Message);
                throw;
            }
            finally
            {
                CloseConnection();
            }
        }

        // 2d. Delete Petani
        public void DeletePetani(int idPetani)
        {
            try
            {
                OpenConnection();
                string query = "DELETE FROM Petani WHERE id_petani = @id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", idPetani);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error delete petani: " + ex.Message);
                throw;
            }
            finally
            {
                CloseConnection();
            }
        }

        // 2e. Count Petani
        public int CountPetani()
        {
            try
            {
                OpenConnection();
                string query = "SELECT COUNT(*) FROM Petani";
                SqlCommand cmd = new SqlCommand(query, conn);
                return (int)cmd.ExecuteScalar();
            }
            catch
            {
                return 0;
            }
            finally
            {
                CloseConnection();
            }
        }

        // 2f. Cek Petani Exist (untuk Import)
        public bool CekPetaniExist(string nama, string alamat)
        {
            try
            {
                OpenConnection();
                string query = "SELECT COUNT(*) FROM Petani WHERE nama = @nama AND alamat = @alamat";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@nama", nama);
                cmd.Parameters.AddWithValue("@alamat", alamat);
                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
            catch
            {
                return false;
            }
            finally
            {
                CloseConnection();
            }
        }

        // ============================================================
        // 3. IMPORT PETANI BATCH (UNTUK EXCEL)
        // ============================================================
        public void ImportPetaniBatch(DataTable dtPetani)
        {
            try
            {
                OpenConnection();
                SqlTransaction trans = conn.BeginTransaction();

                try
                {
                    int sukses = 0, gagal = 0;

                    foreach (DataRow row in dtPetani.Rows)
                    {
                        try
                        {
                            string nama = row["Nama"].ToString().Trim();
                            string alamat = row["Alamat"].ToString().Trim();
                            string noTelp = row["No_Telepon"].ToString().Trim();

                            if (string.IsNullOrEmpty(nama) || string.IsNullOrEmpty(alamat) || string.IsNullOrEmpty(noTelp))
                            {
                                gagal++;
                                continue;
                            }

                            // Cek duplikat
                            if (CekPetaniExist(nama, alamat))
                            {
                                gagal++;
                                continue;
                            }

                            string query = "INSERT INTO Petani (nama, alamat, no_telepon) VALUES (@nama, @alamat, @noTelp)";
                            SqlCommand cmd = new SqlCommand(query, conn, trans);
                            cmd.Parameters.AddWithValue("@nama", nama);
                            cmd.Parameters.AddWithValue("@alamat", alamat);
                            cmd.Parameters.AddWithValue("@noTelp", noTelp);
                            cmd.ExecuteNonQuery();
                            sukses++;
                        }
                        catch
                        {
                            gagal++;
                        }
                    }

                    trans.Commit();
                    MessageBox.Show($"✅ Berhasil import {sukses} data petani!\n❌ Gagal: {gagal} data (duplikat atau error)",
                        "Hasil Import", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch
                {
                    trans.Rollback();
                    throw;
                }
            }
            finally
            {
                CloseConnection();
            }
        }

        // ============================================================
        // 4. CRUD ANTRIAN
        // ============================================================

        // 4a. Get All Antrian
        public DataTable GetAntrian()
        {
            try
            {
                OpenConnection();
                string query = "SELECT * FROM vw_AntrianLengkap ORDER BY nomor_antrian";
                da = new SqlDataAdapter(query, conn);
                dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error get antrian: " + ex.Message);
                return null;
            }
            finally
            {
                CloseConnection();
            }
        }

        // 4b. Insert Antrian
        public void InsertAntrian(int idPetani, int nomorAntrian, decimal beratGabah, DateTime tanggalGiling, string status)
        {
            try
            {
                OpenConnection();
                string query = @"INSERT INTO Antrian (id_petani, nomor_antrian, berat_gabah, tanggal_giling, status) 
                                 VALUES (@idPetani, @nomor, @berat, @tgl, @status)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@idPetani", idPetani);
                cmd.Parameters.AddWithValue("@nomor", nomorAntrian);
                cmd.Parameters.AddWithValue("@berat", beratGabah);
                cmd.Parameters.AddWithValue("@tgl", tanggalGiling);
                cmd.Parameters.AddWithValue("@status", status);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error insert antrian: " + ex.Message);
                throw;
            }
            finally
            {
                CloseConnection();
            }
        }

        // 4c. Update Antrian
        public void UpdateAntrian(int idAntrian, int idPetani, int nomorAntrian, decimal beratGabah, DateTime tanggalGiling, string status)
        {
            try
            {
                OpenConnection();
                string query = @"UPDATE Antrian 
                                 SET id_petani = @idPetani, 
                                     nomor_antrian = @nomor, 
                                     berat_gabah = @berat, 
                                     tanggal_giling = @tgl, 
                                     status = @status 
                                 WHERE id_antrian = @id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", idAntrian);
                cmd.Parameters.AddWithValue("@idPetani", idPetani);
                cmd.Parameters.AddWithValue("@nomor", nomorAntrian);
                cmd.Parameters.AddWithValue("@berat", beratGabah);
                cmd.Parameters.AddWithValue("@tgl", tanggalGiling);
                cmd.Parameters.AddWithValue("@status", status);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error update antrian: " + ex.Message);
                throw;
            }
            finally
            {
                CloseConnection();
            }
        }

        // 4d. Delete Antrian
        public void DeleteAntrian(int idAntrian)
        {
            try
            {
                OpenConnection();
                string query = "DELETE FROM Antrian WHERE id_antrian = @id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", idAntrian);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error delete antrian: " + ex.Message);
                throw;
            }
            finally
            {
                CloseConnection();
            }
        }

        // 4e. Count Antrian
        public int CountAntrian()
        {
            try
            {
                OpenConnection();
                string query = "SELECT COUNT(*) FROM Antrian";
                SqlCommand cmd = new SqlCommand(query, conn);
                return (int)cmd.ExecuteScalar();
            }
            catch
            {
                return 0;
            }
            finally
            {
                CloseConnection();
            }
        }

        // 4f. Get Last Nomor Antrian
        public int GetLastNomorAntrian()
        {
            try
            {
                OpenConnection();
                string query = "SELECT ISNULL(MAX(nomor_antrian), 0) FROM Antrian";
                SqlCommand cmd = new SqlCommand(query, conn);
                return (int)cmd.ExecuteScalar();
            }
            catch
            {
                return 0;
            }
            finally
            {
                CloseConnection();
            }
        }

        // 4g. Update Status Antrian
        public void UpdateStatusAntrian(int idAntrian, string status)
        {
            try
            {
                OpenConnection();
                string query = "UPDATE Antrian SET status = @status WHERE id_antrian = @id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@status", status);
                cmd.Parameters.AddWithValue("@id", idAntrian);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error update status: " + ex.Message);
                throw;
            }
            finally
            {
                CloseConnection();
            }
        }

        // ============================================================
        // 5. CRUD HASIL GILING
        // ============================================================

        // 5a. Get Hasil Giling
        public DataTable GetHasilGiling()
        {
            try
            {
                OpenConnection();
                string query = @"SELECT h.*, a.nomor_antrian, p.nama AS nama_petani 
                                 FROM HasilGiling h
                                 JOIN Antrian a ON h.id_antrian = a.id_antrian
                                 JOIN Petani p ON a.id_petani = p.id_petani
                                 ORDER BY h.tanggal_proses DESC";
                da = new SqlDataAdapter(query, conn);
                dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error get hasil giling: " + ex.Message);
                return null;
            }
            finally
            {
                CloseConnection();
            }
        }

        // 5b. Insert Hasil Giling
        public void InsertHasilGiling(int idAntrian, decimal beras, decimal dedak, string keterangan)
        {
            try
            {
                OpenConnection();
                string query = @"INSERT INTO HasilGiling (id_antrian, beras_dihasilkan, dedak, keterangan) 
                                 VALUES (@idAntrian, @beras, @dedak, @ket)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@idAntrian", idAntrian);
                cmd.Parameters.AddWithValue("@beras", beras);
                cmd.Parameters.AddWithValue("@dedak", dedak);
                cmd.Parameters.AddWithValue("@ket", keterangan);
                cmd.ExecuteNonQuery();

                UpdateStatusAntrian(idAntrian, "selesai");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error insert hasil giling: " + ex.Message);
                throw;
            }
            finally
            {
                CloseConnection();
            }
        }

        // 5c. Update Hasil Giling
        public void UpdateHasilGiling(int idHasil, decimal beras, decimal dedak, string keterangan)
        {
            try
            {
                OpenConnection();
                string query = "UPDATE HasilGiling SET beras_dihasilkan = @beras, dedak = @dedak, keterangan = @ket WHERE id_hasil = @id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", idHasil);
                cmd.Parameters.AddWithValue("@beras", beras);
                cmd.Parameters.AddWithValue("@dedak", dedak);
                cmd.Parameters.AddWithValue("@ket", keterangan);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error update hasil giling: " + ex.Message);
                throw;
            }
            finally
            {
                CloseConnection();
            }
        }

        // 5d. Delete Hasil Giling
        public void DeleteHasilGiling(int idHasil)
        {
            try
            {
                OpenConnection();
                // Ambil id_antrian sebelum delete
                string getIdQuery = "SELECT id_antrian FROM HasilGiling WHERE id_hasil = @id";
                SqlCommand getIdCmd = new SqlCommand(getIdQuery, conn);
                getIdCmd.Parameters.AddWithValue("@id", idHasil);
                object result = getIdCmd.ExecuteScalar();

                if (result != null)
                {
                    int idAntrian = Convert.ToInt32(result);

                    string query = "DELETE FROM HasilGiling WHERE id_hasil = @id";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", idHasil);
                    cmd.ExecuteNonQuery();

                    // Kembalikan status antrian menjadi 'proses'
                    UpdateStatusAntrian(idAntrian, "proses");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error delete hasil giling: " + ex.Message);
                throw;
            }
            finally
            {
                CloseConnection();
            }
        }

        // ============================================================
        // 6. DASHBOARD / CHART (SP_Dashboard)
        // ============================================================

        // 6a. Get Dashboard (Semua data)
        public DataTable GetDashboard()
        {
            try
            {
                OpenConnection();
                SqlCommand cmd = new SqlCommand("sp_Dashboard", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error get dashboard: " + ex.Message);
                return null;
            }
            finally
            {
                CloseConnection();
            }
        }

        // 6b. Get Dashboard by Tahun
        public DataTable GetDashboardByTahun(string tahun)
        {
            try
            {
                OpenConnection();
                SqlCommand cmd = new SqlCommand("sp_DashboardByTahun", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@intTglMsuk", tahun);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error get dashboard by tahun: " + ex.Message);
                return null;
            }
            finally
            {
                CloseConnection();
            }
        }

        // 6c. Get Chart Hasil Giling
        public DataTable GetChartHasilGiling()
        {
            try
            {
                OpenConnection();
                SqlCommand cmd = new SqlCommand("sp_ChartHasilGiling", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error get chart hasil giling: " + ex.Message);
                return null;
            }
            finally
            {
                CloseConnection();
            }
        }

        // ============================================================
        // 7. REPORT (SP_Report)
        // ============================================================
        public DataTable GetReport(string tahun)
        {
            try
            {
                OpenConnection();
                SqlCommand cmd = new SqlCommand("sp_Report", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@inTgLMsuK", tahun);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error get report: " + ex.Message);
                return null;
            }
            finally
            {
                CloseConnection();
            }
        }

        // ============================================================
        // 8. LAPORAN (VIEW)
        // ============================================================
        public DataTable GetLaporan()
        {
            try
            {
                OpenConnection();
                string query = "SELECT * FROM vw_LaporanGilingan ORDER BY tanggal_giling DESC, nomor_antrian";
                da = new SqlDataAdapter(query, conn);
                dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error get laporan: " + ex.Message);
                return null;
            }
            finally
            {
                CloseConnection();
            }
        }

        // ============================================================
        // 9. TEST CONNECTION
        // ============================================================
        public bool TestConnection()
        {
            try
            {
                OpenConnection();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                CloseConnection();
            }
        }
    }
}