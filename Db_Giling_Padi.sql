USE GilinganPadi;
GO

-- Tabel LogError
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name = 'LogError' AND xtype = 'U')
BEGIN
    CREATE TABLE LogError (
        id_log INT IDENTITY(1,1) PRIMARY KEY,
        waktu DATETIME DEFAULT GETDATE(),
        pesan_error VARCHAR(MAX)
    );
    PRINT '✅ Tabel LogError berhasil dibuat';
END
ELSE
    PRINT '✅ Tabel LogError sudah ada';
GO

-- Tabel LogAktivitas
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name = 'LogAktivitas' AND xtype = 'U')
BEGIN
    CREATE TABLE LogAktivitas (
        id_log INT IDENTITY(1,1) PRIMARY KEY,
        aktivitas VARCHAR(100),
        waktu DATETIME DEFAULT GETDATE()
    );
    PRINT '✅ Tabel LogAktivitas berhasil dibuat';
END
ELSE
    PRINT '✅ Tabel LogAktivitas sudah ada';
GO

-- Tabel LogKeamanan
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name = 'LogKeamanan' AND xtype = 'U')
BEGIN
    CREATE TABLE LogKeamanan (
        id_log INT IDENTITY(1,1) PRIMARY KEY,
        aktivitas VARCHAR(200),
        jumlah_data INT,
        waktu DATETIME DEFAULT GETDATE()
    );
    PRINT '✅ Tabel LogKeamanan berhasil dibuat';
END
ELSE
    PRINT '✅ Tabel LogKeamanan sudah ada';
GO

-- Tabel LogAktivitasSalah
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name = 'LogAktivitasSalah' AND xtype = 'U')
BEGIN
    CREATE TABLE LogAktivitasSalah (
        id_log INT IDENTITY(1,1) PRIMARY KEY,
        aktivitas VARCHAR(200),
        waktu DATETIME DEFAULT GETDATE()
    );
    PRINT '✅ Tabel LogAktivitasSalah berhasil dibuat';
END
ELSE
    PRINT '✅ Tabel LogAktivitasSalah sudah ada';
GO

-- ============================================
-- 2. STORED PROCEDURE (ALTER - Hanya yang belum ada)
-- ============================================

-- 2a. sp_GetAllAntrian
IF EXISTS (SELECT * FROM sysobjects WHERE name = 'sp_GetAllAntrian' AND xtype = 'P')
    DROP PROCEDURE sp_GetAllAntrian;
GO
CREATE PROCEDURE sp_GetAllAntrian
AS
BEGIN
    SET NOCOUNT ON;
    SELECT 
        a.id_antrian,
        a.nomor_antrian,
        p.nama AS NamaPetani,
        p.alamat AS Alamat,
        p.no_telepon AS NoTelepon,
        a.berat_gabah AS BeratGabah,
        a.tanggal_giling AS TanggalGiling,
        a.status AS Status,
        a.created_at AS TanggalDaftar
    FROM Antrian a
    JOIN Petani p ON a.id_petani = p.id_petani
    ORDER BY a.nomor_antrian;
END
GO
PRINT '✅ sp_GetAllAntrian berhasil dibuat';

-- 2b. sp_GetAntrianById
IF EXISTS (SELECT * FROM sysobjects WHERE name = 'sp_GetAntrianById' AND xtype = 'P')
    DROP PROCEDURE sp_GetAntrianById;
GO
CREATE PROCEDURE sp_GetAntrianById
    @pIdAntrian INT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT 
        a.id_antrian,
        a.nomor_antrian,
        a.id_petani,
        p.nama AS NamaPetani,
        p.alamat AS Alamat,
        p.no_telepon AS NoTelepon,
        a.berat_gabah AS BeratGabah,
        a.tanggal_giling AS TanggalGiling,
        a.status AS Status
    FROM Antrian a
    JOIN Petani p ON a.id_petani = p.id_petani
    WHERE a.id_antrian = @pIdAntrian;
END
GO
PRINT '✅ sp_GetAntrianById berhasil dibuat';

-- 2c. sp_InsertAntrian
IF EXISTS (SELECT * FROM sysobjects WHERE name = 'sp_InsertAntrian' AND xtype = 'P')
    DROP PROCEDURE sp_InsertAntrian;
GO
CREATE PROCEDURE sp_InsertAntrian
    @pIdPetani INT,
    @pNomorAntrian INT,
    @pBeratGabah DECIMAL(10,2),
    @pTanggalGiling DATE,
    @pStatus VARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO Antrian (id_petani, nomor_antrian, berat_gabah, tanggal_giling, status)
    VALUES (@pIdPetani, @pNomorAntrian, @pBeratGabah, @pTanggalGiling, @pStatus);
END
GO
PRINT '✅ sp_InsertAntrian berhasil dibuat';

-- 2d. sp_UpdateAntrian
IF EXISTS (SELECT * FROM sysobjects WHERE name = 'sp_UpdateAntrian' AND xtype = 'P')
    DROP PROCEDURE sp_UpdateAntrian;
GO
CREATE PROCEDURE sp_UpdateAntrian
    @pIdAntrian INT,
    @pIdPetani INT,
    @pNomorAntrian INT,
    @pBeratGabah DECIMAL(10,2),
    @pTanggalGiling DATE,
    @pStatus VARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE Antrian
    SET id_petani = @pIdPetani,
        nomor_antrian = @pNomorAntrian,
        berat_gabah = @pBeratGabah,
        tanggal_giling = @pTanggalGiling,
        status = @pStatus
    WHERE id_antrian = @pIdAntrian;
END
GO
PRINT '✅ sp_UpdateAntrian berhasil dibuat';

-- 2e. sp_DeleteAntrian
IF EXISTS (SELECT * FROM sysobjects WHERE name = 'sp_DeleteAntrian' AND xtype = 'P')
    DROP PROCEDURE sp_DeleteAntrian;
GO
CREATE PROCEDURE sp_DeleteAntrian
    @pIdAntrian INT
AS
BEGIN
    SET NOCOUNT ON;
    DELETE FROM Antrian WHERE id_antrian = @pIdAntrian;
END
GO
PRINT '✅ sp_DeleteAntrian berhasil dibuat';

-- 2f. sp_CountAntrian
IF EXISTS (SELECT * FROM sysobjects WHERE name = 'sp_CountAntrian' AND xtype = 'P')
    DROP PROCEDURE sp_CountAntrian;
GO
CREATE PROCEDURE sp_CountAntrian
    @Total INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT @Total = COUNT(*) FROM Antrian;
END
GO
PRINT '✅ sp_CountAntrian berhasil dibuat';

-- 2g. sp_GetPetani
IF EXISTS (SELECT * FROM sysobjects WHERE name = 'sp_GetPetani' AND xtype = 'P')
    DROP PROCEDURE sp_GetPetani;
GO
CREATE PROCEDURE sp_GetPetani
AS
BEGIN
    SET NOCOUNT ON;
    SELECT id_petani, nama, alamat, no_telepon, created_at
    FROM Petani
    ORDER BY nama;
END
GO
PRINT '✅ sp_GetPetani berhasil dibuat';

-- 2h. sp_InsertPetani
IF EXISTS (SELECT * FROM sysobjects WHERE name = 'sp_InsertPetani' AND xtype = 'P')
    DROP PROCEDURE sp_InsertPetani;
GO
CREATE PROCEDURE sp_InsertPetani
    @pNama VARCHAR(100),
    @pAlamat VARCHAR(255),
    @pNoTelepon VARCHAR(15)
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO Petani (nama, alamat, no_telepon)
    VALUES (@pNama, @pAlamat, @pNoTelepon);
END
GO
PRINT '✅ sp_InsertPetani berhasil dibuat';

-- 2i. sp_UpdatePetani
IF EXISTS (SELECT * FROM sysobjects WHERE name = 'sp_UpdatePetani' AND xtype = 'P')
    DROP PROCEDURE sp_UpdatePetani;
GO
CREATE PROCEDURE sp_UpdatePetani
    @pIdPetani INT,
    @pNama VARCHAR(100),
    @pAlamat VARCHAR(255),
    @pNoTelepon VARCHAR(15)
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE Petani
    SET nama = @pNama,
        alamat = @pAlamat,
        no_telepon = @pNoTelepon
    WHERE id_petani = @pIdPetani;
END
GO
PRINT '✅ sp_UpdatePetani berhasil dibuat';

-- 2j. sp_DeletePetani
IF EXISTS (SELECT * FROM sysobjects WHERE name = 'sp_DeletePetani' AND xtype = 'P')
    DROP PROCEDURE sp_DeletePetani;
GO
CREATE PROCEDURE sp_DeletePetani
    @pIdPetani INT
AS
BEGIN
    SET NOCOUNT ON;
    DELETE FROM Petani WHERE id_petani = @pIdPetani;
END
GO
PRINT '✅ sp_DeletePetani berhasil dibuat';

-- 2k. sp_Dashboard
IF EXISTS (SELECT * FROM sysobjects WHERE name = 'sp_Dashboard' AND xtype = 'P')
    DROP PROCEDURE sp_Dashboard;
GO
CREATE PROCEDURE sp_Dashboard
AS
BEGIN
    SET NOCOUNT ON;
    SELECT
        p.nama AS NamaPetani,
        COUNT(a.id_antrian) AS JmlhAntrian
    FROM Petani p
    LEFT JOIN Antrian a ON p.id_petani = a.id_petani
    GROUP BY p.nama;
END
GO
PRINT '✅ sp_Dashboard berhasil dibuat';

-- 2l. sp_DashboardByTahun
IF EXISTS (SELECT * FROM sysobjects WHERE name = 'sp_DashboardByTahun' AND xtype = 'P')
    DROP PROCEDURE sp_DashboardByTahun;
GO
CREATE PROCEDURE sp_DashboardByTahun
    @intTglMsuk CHAR(4)
AS
BEGIN
    SET NOCOUNT ON;
    SELECT
        p.nama AS NamaPetani,
        COUNT(a.id_antrian) AS JmlhAntrian
    FROM Petani p
    LEFT JOIN Antrian a ON p.id_petani = a.id_petani
    WHERE YEAR(a.created_at) = @intTglMsuk
    GROUP BY p.nama;
END
GO
PRINT '✅ sp_DashboardByTahun berhasil dibuat';

-- 2m. sp_ChartHasilGiling
IF EXISTS (SELECT * FROM sysobjects WHERE name = 'sp_ChartHasilGiling' AND xtype = 'P')
    DROP PROCEDURE sp_ChartHasilGiling;
GO
CREATE PROCEDURE sp_ChartHasilGiling
AS
BEGIN
    SET NOCOUNT ON;
    SELECT
        p.nama AS NamaPetani,
        ISNULL(SUM(h.beras_dihasilkan), 0) AS TotalBeras,
        ISNULL(SUM(h.dedak), 0) AS TotalDedak
    FROM Petani p
    LEFT JOIN Antrian a ON p.id_petani = a.id_petani
    LEFT JOIN HasilGiling h ON a.id_antrian = h.id_antrian
    GROUP BY p.nama
    ORDER BY TotalBeras DESC;
END
GO
PRINT '✅ sp_ChartHasilGiling berhasil dibuat';

-- 2n. sp_Report
IF EXISTS (SELECT * FROM sysobjects WHERE name = 'sp_Report' AND xtype = 'P')
    DROP PROCEDURE sp_Report;
GO
CREATE PROCEDURE sp_Report
    @inTgLMsuK CHAR(4)
AS
BEGIN
    SET NOCOUNT ON;
    SELECT
        a.nomor_antrian AS NomorAntrian,
        p.nama AS NamaPetani,
        p.alamat AS Alamat,
        p.no_telepon AS NoTelepon,
        a.berat_gabah AS BeratGabah,
        a.tanggal_giling AS TanggalGiling,
        a.status AS Status,
        ISNULL(h.beras_dihasilkan, 0) AS BerasDihasilkan,
        ISNULL(h.dedak, 0) AS Dedak,
        h.tanggal_proses AS TanggalProses,
        h.keterangan AS Keterangan
    FROM Antrian a
    JOIN Petani p ON a.id_petani = p.id_petani
    LEFT JOIN HasilGiling h ON a.id_antrian = h.id_antrian
    WHERE YEAR(a.created_at) = @inTgLMsuK
    ORDER BY a.nomor_antrian;
END
GO
PRINT '✅ sp_Report berhasil dibuat';

-- 2o. sp_ImportPetani
IF EXISTS (SELECT * FROM sysobjects WHERE name = 'sp_ImportPetani' AND xtype = 'P')
    DROP PROCEDURE sp_ImportPetani;
GO
CREATE PROCEDURE sp_ImportPetani
    @pNama VARCHAR(100),
    @pAlamat VARCHAR(255),
    @pNoTelepon VARCHAR(15)
AS
BEGIN
    SET NOCOUNT ON;
    
    IF NOT EXISTS (SELECT 1 FROM Petani WHERE nama = @pNama AND alamat = @pAlamat)
    BEGIN
        INSERT INTO Petani (nama, alamat, no_telepon)
        VALUES (@pNama, @pAlamat, @pNoTelepon);
        
        INSERT INTO LogAktivitas (aktivitas, waktu)
        VALUES ('Import petani: ' + @pNama, GETDATE());
    END
END
GO
PRINT '✅ sp_ImportPetani berhasil dibuat';

-- ============================================
-- 3. TRIGGER (ALTER)
-- ============================================

-- Trigger INSERT
DROP TRIGGER IF EXISTS trg_InsertAntrian;
GO
CREATE TRIGGER trg_InsertAntrian
ON Antrian
AFTER INSERT
AS
BEGIN
    INSERT INTO LogAktivitas (aktivitas, waktu)
    VALUES ('Tambah antrian baru', GETDATE());
END
GO
PRINT '✅ trg_InsertAntrian berhasil dibuat';

-- Trigger DELETE
DROP TRIGGER IF EXISTS trg_DeleteAntrian;
GO
CREATE TRIGGER trg_DeleteAntrian
ON Antrian
AFTER DELETE
AS
BEGIN
    INSERT INTO LogAktivitas (aktivitas, waktu)
    VALUES ('Hapus antrian', GETDATE());
END
GO
PRINT '✅ trg_DeleteAntrian berhasil dibuat';

-- Trigger UPDATE
DROP TRIGGER IF EXISTS trg_UpdateAntrian;
GO
CREATE TRIGGER trg_UpdateAntrian
ON Antrian
AFTER UPDATE
AS
BEGIN
    INSERT INTO LogAktivitas (aktivitas, waktu)
    VALUES ('Update antrian', GETDATE());
END
GO
PRINT '✅ trg_UpdateAntrian berhasil dibuat';

-- Trigger PREVENT MASS UPDATE
DROP TRIGGER IF EXISTS trg_PreventMassUpdate;
GO
CREATE TRIGGER trg_PreventMassUpdate
ON Antrian
AFTER UPDATE
AS
BEGIN
    DECLARE @jumlah INT;
    
    SELECT @jumlah = COUNT(*) FROM inserted;
    
    IF @jumlah > 5
    BEGIN
        INSERT INTO LogKeamanan (aktivitas, jumlah_data, waktu)
        VALUES ('WARNING : Update massal antrian terdeteksi', @jumlah, GETDATE());
        
        ROLLBACK TRANSACTION;
        RAISERROR('Update dibatalkan! Terlalu banyak data diubah.', 16, 1);
    END
END
GO
PRINT '✅ trg_PreventMassUpdate berhasil dibuat';

-- ============================================
-- 4. VIEW (ALTER)
-- ============================================

-- View Antrian Lengkap
DROP VIEW IF EXISTS vw_AntrianLengkap;
GO
CREATE VIEW vw_AntrianLengkap AS
SELECT 
    a.id_antrian,
    a.nomor_antrian,
    p.nama AS nama_petani,
    p.alamat,
    p.no_telepon,
    a.berat_gabah,
    a.tanggal_giling,
    a.status,
    a.created_at
FROM Antrian a
INNER JOIN Petani p ON a.id_petani = p.id_petani;
GO
PRINT '✅ vw_AntrianLengkap berhasil dibuat';

-- View Laporan Lengkap
DROP VIEW IF EXISTS vw_LaporanGilingan;
GO
CREATE VIEW vw_LaporanGilingan AS
SELECT 
    a.id_antrian,
    a.nomor_antrian,
    p.nama AS nama_petani,
    p.alamat,
    p.no_telepon,
    a.berat_gabah,
    a.tanggal_giling,
    a.status,
    ISNULL(h.beras_dihasilkan, 0) AS beras_dihasilkan,
    ISNULL(h.dedak, 0) AS dedak,
    h.tanggal_proses,
    h.keterangan
FROM Antrian a
INNER JOIN Petani p ON a.id_petani = p.id_petani
LEFT JOIN HasilGiling h ON a.id_antrian = h.id_antrian;
GO
PRINT '✅ vw_LaporanGilingan berhasil dibuat';

-- ============================================
-- 5. VERIFIKASI AKHIR
-- ============================================
PRINT '';
PRINT '========== VERIFIKASI ==========';
PRINT '';

PRINT '📊 DAFTAR STORED PROCEDURE:';
SELECT name FROM sysobjects WHERE xtype = 'P' AND name LIKE 'sp_%' ORDER BY name;

PRINT '';
PRINT '📊 DAFTAR TRIGGER:';
SELECT name, OBJECT_NAME(parent_id) AS TableName
FROM sys.triggers
WHERE name IN ('trg_InsertAntrian', 'trg_DeleteAntrian', 'trg_UpdateAntrian', 'trg_PreventMassUpdate');

PRINT '';
PRINT '📊 DAFTAR VIEW:';
SELECT name FROM sys.views WHERE name IN ('vw_AntrianLengkap', 'vw_LaporanGilingan');

PRINT '';
PRINT '📊 DATA ADMIN:';
SELECT * FROM Admin;

PRINT '';
PRINT '📊 DATA PETANI:';
SELECT * FROM Petani;

PRINT '';
PRINT '📊 DATA ANTRIAN:';
SELECT * FROM vw_AntrianLengkap;

PRINT '';
PRINT '📊 DATA HASIL GILING:';
SELECT * FROM HasilGiling;

PRINT '';
PRINT '✅ SEMUA PROSES SELESAI! Database GilinganPadi siap digunakan.';
PRINT '';