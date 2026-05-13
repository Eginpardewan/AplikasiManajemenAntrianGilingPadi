# 🌾 Aplikasi Manajemen Antrian Gilingan Padi

## Deskripsi Aplikasi

Aplikasi Manajemen Antrian Gilingan Padi adalah sistem berbasis basis data yang dirancang untuk membantu pengelola dalam mencatat dan memantau antrian penggilingan padi. Aplikasi ini digunakan oleh satu aktor yaitu **Admin (Pengelola)** yang bertugas mengelola antrian, memproses antrian, mencatat hasil giling, serta melihat laporan penggilingan.

### Fitur Utama

- Login Admin
- Kelola Data Petani (Tambah, Edit, Hapus)
- Kelola Antrian (Tambah, Edit, Hapus)
- Proses Giling (Ubah Status)
- Catat Hasil Giling
- Laporan Antrian dan Hasil Giling

---

## 🧪 SQL INJECTION - Demo dan Skenario

### Apa itu SQL Injection?

SQL Injection adalah teknik serangan siber dimana attacker menyisipkan kode SQL berbahaya ke dalam input pengguna yang kemudian dieksekusi oleh database. Serangan ini dapat menyebabkan:
- Bypass autentikasi (login tanpa password)
- Pengambilan data sensitif
- Modifikasi atau penghapusan data
- Bahkan penghapusan seluruh tabel database

---

### Lokasi Kerentanan SQL Injection

Kerentanan SQL Injection terdapat pada **Form Petani** ketika mengakses melalui tombol **🧪 Test SQL Injection** yang ada di dalam form tersebut.

**File yang rentan:** `FormPetani.cs`

**Kode rentan:**
```csharp
// ⚠️ KODE RENTAN SQL INJECTION ⚠️
string query = "UPDATE Petani SET alamat = 'HACKED BY SQL INJECTION' WHERE nama = '" + txtNama.Text + "'";
SqlCommand cmd = new SqlCommand(query, conn);
cmd.ExecuteNonQuery();
