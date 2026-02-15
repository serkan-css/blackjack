using System;
using System.Collections.Generic;
using System.Linq;

namespace BlackjackGame
{
    public class Deste
    {
        private List<Kart> kartlar;
        private Random rnd = new Random();

        public Deste()
        {
            kartlar = new List<Kart>();
            YeniDesteOlustur();
        }

        public void YeniDesteOlustur()
        {
            kartlar.Clear();
            foreach (KartTipi tip in Enum.GetValues(typeof(KartTipi)))
            {
                foreach (KartDegeri deger in Enum.GetValues(typeof(KartDegeri)))
                {
                    kartlar.Add(new Kart(tip, deger));
                }
            }
            Karistir();
        }

        public void Karistir()
        {
            kartlar = kartlar.OrderBy(x => rnd.Next()).ToList();
        }

        // --- SENİN İSTEDİĞİN ÖZEL ÖZELLİK BURASI ---
        public Kart KartCek(int? hileliDeger = null)
        {
            if (kartlar.Count == 0) YeniDesteOlustur();

            if (hileliDeger.HasValue)
            {
                // Deste içinde istenen değere sahip ilk kartı bul (Örn: Bes)
                var bulunanKart = kartlar.FirstOrDefault(k => (int)k.Deger == hileliDeger.Value);
                
                if (bulunanKart != null)
                {
                    kartlar.Remove(bulunanKart);
                    return bulunanKart;
                }
            }

            // Hile yoksa veya istenen kart kalmadıysa en üsttekini ver
            Kart kart = kartlar[0];
            kartlar.RemoveAt(0);
            return kart;
        }
    }
}