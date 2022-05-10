using Islem;
namespace Topla
{
    public class Topla : Islem.Islem.IHesap
    {
        public string Isim => "+";

        public int Hesapla(int a, int b)
        {
            return a + b;   
        }
    }
}