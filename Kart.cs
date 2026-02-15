namespace BlackjackGame
{
    // Kart tiplerini ve değerlerini okunaklı hale getirmek için Enum kullanıyoruz
    public enum KartTipi { Kupa, Maça, Karo, Sinek }
    public enum KartDegeri { As = 1, Iki, Uc, Dort, Bes, Alti, Yedi, Sekiz, Dokuz, On, Vale, Kiz, Papaz }

    public class Kart
    {
        public KartTipi Tip { get; set; }
        public KartDegeri Deger { get; set; }

        public Kart(KartTipi tip, KartDegeri deger)
        {
            Tip = tip;
            Deger = deger;
        }

        // Skor hesaplarken kullanılacak sayısal değer
        public int SayisalDeger
        {
            get
            {
                if ((int)Deger >= 10) return 10; // Vale, Kız, Papaz 10 sayılır
                if (Deger == KartDegeri.As) return 11; // As başlangıçta 11 sayılır (mantık sonra kurulacak)
                return (int)Deger;
            }
        }

        public override string ToString()
        {
            return $"{Tip} {Deger}";
        }
    }
}