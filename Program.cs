using System;
using TP_Modul9;

class Program
{
    static void Main(string[] args)
    {
        CovidConfig config = new CovidConfig();
        config.Load();

        config.UbahSatuan();

        Console.Write($"Berapa suhu badan anda saat ini? Dalam nilai {config.SatuanSuhu}: ");
        double suhu = double.Parse(Console.ReadLine());

        Console.Write("Berapa hari yang lalu (perkiraan) anda terakhir memiliki gejala deman? ");
        int hariDeman = int.Parse(Console.ReadLine());

        bool suhuNormal;
        if (config.SatuanSuhu == "celcius")
            suhuNormal = suhu >= 36.5 && suhu <= 37.5;
        else
            suhuNormal = suhu >= 97.7 && suhu <= 99.5;

        bool hariNormal = hariDeman < config.BatasHariDeman;

        if (suhuNormal && hariNormal)
            Console.WriteLine(config.PesanDiterima);
        else
            Console.WriteLine(config.PesanDitolak);
    }
}