using System;
using System.Collections.Generic;
using System.Linq;

namespace BlackjackGame
{
    public class El
    {
        public List<Kart> Kartlar { get; private set; }

        public El()
        {
            Kartlar = new List<Kart>();
        }

        public void KartEkle(Kart kart)
        {
            Kartlar.Add(kart);
        }

        public int ToplamPuan
        {
            get
            {
                int toplam = Kartlar.Sum(k => k.SayisalDeger);
                int asSayisi = Kartlar.Count(k => k.Deger == KartDegeri.As);

                // Eğer toplam 21'i geçiyorsa ve elimizde AS varsa, 
                // her bir AS için puanı 10 düşür (As'ı 11 yerine 1 saymış oluruz)
                while (toplam > 21 && asSayisi > 0)
                {
                    toplam -= 10;
                    asSayisi--;
                }

                return toplam;
            }
        }

        public void Temizle()
        {
            Kartlar.Clear();
        }

        public override string ToString()
        {
            return string.Join(", ", Kartlar.Select(k => k.ToString())) + $" (Toplam: {ToplamPuan})";
        }
    }
}