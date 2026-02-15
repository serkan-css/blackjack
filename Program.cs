using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace BlackjackGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Deste deste = new Deste();
            El oyuncuEli = new El();
            El robotEli = new El();
            int cuzdan = 1000;

            while (cuzdan > 0)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"=== BAKİYE: {cuzdan}$ ===");
                Console.ResetColor();

                // 1. BAHİS ALMA
                int bahis = 0;
                while (true)
                {
                    Console.Write("Bahis miktarını girin (Çıkış için 0): ");
                    string input = Console.ReadLine();
                    if (int.TryParse(input, out bahis) && bahis <= cuzdan && bahis >= 0) break;
                    Console.WriteLine("Geçersiz miktar! Bakiyenizden fazla miktar giremezsiniz.");
                }

                if (bahis == 0) break;

                // 2. HAZIRLIK
                oyuncuEli.Temizle();
                robotEli.Temizle();
                deste.YeniDesteOlustur();

                oyuncuEli.KartEkle(deste.KartCek());
                robotEli.KartEkle(deste.KartCek());
                oyuncuEli.KartEkle(deste.KartCek());
                robotEli.KartEkle(deste.KartCek());

                bool oyuncuDevam = true;
                int? hileliDeger = null;

                // 3. OYUNCU SIRASI
                while (oyuncuDevam && oyuncuEli.ToplamPuan < 21)
                {
                    EkraniCiz(oyuncuEli, robotEli, false, cuzdan, bahis);
                    Console.WriteLine("\n[H] Kart Çek | [S] Bekle");

                    while (!Console.KeyAvailable) { Thread.Sleep(10); }

                    var tusBilgisi = Console.ReadKey(true);
                    char basilanChar = tusBilgisi.KeyChar;

                    // GİZLİ HİLE (Konsolda gözükmez)
                    if (char.IsDigit(basilanChar) && basilanChar != '0')
                    {
                        hileliDeger = (int)char.GetNumericValue(basilanChar);
                        continue; 
                    }

                    if (tusBilgisi.Key == ConsoleKey.H)
                    {
                        oyuncuEli.KartEkle(deste.KartCek(hileliDeger));
                        hileliDeger = null;
                        EkraniCiz(oyuncuEli, robotEli, false, cuzdan, bahis);
                        if (oyuncuEli.ToplamPuan > 21) break;
                    }
                    else if (tusBilgisi.Key == ConsoleKey.S)
                    {
                        oyuncuDevam = false;
                    }
                }

                // 4. ROBOT SIRASI
                if (oyuncuEli.ToplamPuan <= 21)
                {
                    while (robotEli.ToplamPuan < 17)
                    {
                        EkraniCiz(oyuncuEli, robotEli, true, cuzdan, bahis);
                        Console.WriteLine("\nRobot kart çekiyor...");
                        Thread.Sleep(1200);
                        robotEli.KartEkle(deste.KartCek());
                    }
                }

                // 5. SONUÇ VE ÖDEME MANTIĞI
                EkraniCiz(oyuncuEli, robotEli, true, cuzdan, bahis);
                
                bool pBJ = (oyuncuEli.Kartlar.Count == 2 && oyuncuEli.ToplamPuan == 21);
                bool rBJ = (robotEli.Kartlar.Count == 2 && robotEli.ToplamPuan == 21);
                int sonuc = KazananıBelirle(oyuncuEli, robotEli);

                if (pBJ && !rBJ)
                {
                    int kazanc = bahis * 2;
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine($"\n!!! BLACKJACK !!! +{kazanc}$ Kazandınız!");
                    cuzdan += kazanc;
                }
                else if (sonuc == 1)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"\nKAZANDINIZ! +{bahis}$");
                    cuzdan += bahis;
                }
                else if (sonuc == -1)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"\nKAYBETTİNİZ! -{bahis}$");
                    cuzdan -= bahis;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\nBERABERE! Bahis iade.");
                }

                Console.ResetColor();
                if (cuzdan <= 0) { Console.WriteLine("Bakiye bitti! Oyun sona erdi."); break; }
                
                Console.WriteLine("\nDevam etmek için bir tuşa basın...");
                Console.ReadKey();
            }
        }

        static void EkraniCiz(El oyuncu, El robot, bool robotuAc, int cuzdan, int bahis)
        {
            Console.Clear();
            Console.WriteLine("========================================");
            Console.WriteLine($" BAKİYE: {cuzdan}$   |   BAHİS: {bahis}$");
            Console.WriteLine("========================================\n");

            if (robotuAc) Console.WriteLine($"ROBOTUN ELİ: {robot}");
            else Console.WriteLine($"ROBOTUN GÖRÜNEN KARTI: {robot.Kartlar[0]} [ GİZLİ ]");

            Console.WriteLine("\n----------------------------------------");
            Console.WriteLine($"SENİN ELİN: {oyuncu}");
            Console.WriteLine("----------------------------------------");
        }

        static int KazananıBelirle(El oyuncu, El robot)
        {
            int p = oyuncu.ToplamPuan;
            int r = robot.ToplamPuan;
            if (p > 21) return -1;
            if (r > 21) return 1;
            if (p > r) return 1;
            if (r > p) return -1;
            return 0;
        }
    }
}