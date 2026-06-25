using System;

namespace Giling_Padi
{
    public class ClassDataHasilGiling  // ← HARUS PUBLIC
    {
        public string NamaPetani { get; set; }
        public string Alamat { get; set; }
        public string NoTelepon { get; set; }
        public int NoAntrian { get; set; }
        public DateTime TanggalGiling { get; set; }
        public decimal BeratGabah { get; set; }
        public decimal Beras { get; set; }
        public decimal Dedak { get; set; }
        public string Status { get; set; }
        public decimal KonversiBeras { get; set; }
        public decimal KonversiDedak { get; set; }
        public decimal SisaGabah { get; set; }
        public string Periode { get; set; }
        public int TotalPetani { get; set; }
        public string TanggalCetak { get; set; }
        public decimal TotalGabah { get; set; }
        public decimal TotalBeras { get; set; }
        public decimal TotalDedak { get; set; }
    }
}