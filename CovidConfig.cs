using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace TP_Modul9
{
    internal class CovidConfig
    {
        private static readonly string FilePath = "covid_config.json";

        public string SatuanSuhu { get; set; } = "celcius";
        public int BatasHariDeman { get; set; } = 14;
        public string PesanDitolak { get; set; } = "Anda tidak diperbolehkan masuk ke dalam gedung ini";
        public string PesanDiterima { get; set; } = "Anda dipersilahkan untuk masuk ke dalam gedung ini";

        public void Load()
        {
            if (!File.Exists(FilePath))
            {
                Console.WriteLine("Config file tidak ditemukan, menggunakan nilai default.");
                return;
            }

            string json = File.ReadAllText(FilePath);
            using JsonDocument doc = JsonDocument.Parse(json);
            JsonElement root = doc.RootElement;

            if (root.TryGetProperty("satuan_suhu", out JsonElement s)) SatuanSuhu = s.GetString();
            if (root.TryGetProperty("batas_hari_deman", out JsonElement b)) BatasHariDeman = b.GetInt32();
            if (root.TryGetProperty("pesan_ditolak", out JsonElement pd)) PesanDitolak = pd.GetString();
            if (root.TryGetProperty("pesan_diterima", out JsonElement pdr)) PesanDiterima = pdr.GetString();
        }

        public void Save()
        {
            var data = new
            {
                satuan_suhu = SatuanSuhu,
                batas_hari_deman = BatasHariDeman,
                pesan_ditolak = PesanDitolak,
                pesan_diterima = PesanDiterima
            };

            string json = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(FilePath, json);
        }

        public void UbahSatuan()
        {
            SatuanSuhu = SatuanSuhu == "celcius" ? "fahrenheit" : "celcius";
            Save();
            Console.WriteLine($"Satuan suhu berhasil diubah menjadi: {SatuanSuhu}");
        }
    }
}
    