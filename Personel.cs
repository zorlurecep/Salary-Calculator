using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Son_hal_deneme1
{
    class Personel//our personel class where we store all information
    {
        public string tc;
        public string adi;
        public string soyadi;
        public int yas;
        public int calısmaSuresi;
        public string medeniHali;
        public string esDurumu;
        public int cocukSayisi;
        public int tabanMaas;
        public int makamTazminati;
        public int idariGorevTazminati;
        public int fazlaMesaiSaati;
        public int fazlaMesaiSaatUcreti;
        public int vergiMatrahi;
        public string resimYolu;
        public int brutMaas;
        public int damgaVergisi;
        public int GelirVergisi;
        public int EmekliKesintisi;
        public int NetMaas;

        public void maasHesapla()//calculates "brut maas"
        {
            if ((medeniHali == "e") || (medeniHali == "E"))//makes necessary controls with if statement and calculates
            {
                if ((esDurumu == "e") || (esDurumu == "E"))
                {
                    brutMaas = tabanMaas + makamTazminati + idariGorevTazminati + (cocukSayisi * 30) + (fazlaMesaiSaati * fazlaMesaiSaatUcreti);
                }
                else if ((esDurumu == "h") || (esDurumu == "H"))
                {
                    brutMaas = tabanMaas + makamTazminati + idariGorevTazminati + (cocukSayisi * 30) + (fazlaMesaiSaati * fazlaMesaiSaatUcreti) + 200;
                }
            }

            if ((medeniHali == "b") || (medeniHali == "B") || (medeniHali == "d") || (medeniHali == "D"))
            {
                brutMaas = tabanMaas + makamTazminati + idariGorevTazminati + (cocukSayisi * 30) + (fazlaMesaiSaati * fazlaMesaiSaatUcreti);
            }
        }

        public void damgaVergisiHesapla()//calculates "damga vergisi"
        {
            damgaVergisi = (brutMaas * 10) / 100;
        }

        public void gelirVergisiHesapla()//calculates "gelir vergisi"
        {
            if (vergiMatrahi < 10000)
            {
                GelirVergisi = (brutMaas * 15) / 100;
            }
            if (vergiMatrahi >= 10000 && vergiMatrahi < 20000)
            {
                GelirVergisi = (brutMaas * 20) / 100;
            }
            if (vergiMatrahi >= 20000 && vergiMatrahi < 30000)
            {
                GelirVergisi = (brutMaas * 25) / 100;
            }
            if (vergiMatrahi >= 30000)
            {
                GelirVergisi = (brutMaas * 30) / 100;
            }
        }

        public void EmekliKesintisiHesapla()//calculates "emeklilik kesintisi"
        {
            EmekliKesintisi = (brutMaas * 15) / 100;
        }

        public void NetMaasHesapla()////calculates "new maas"
        {
            maasHesapla();
            damgaVergisiHesapla();
            gelirVergisiHesapla();
            EmekliKesintisiHesapla();
            NetMaas = brutMaas - (EmekliKesintisi + GelirVergisi + damgaVergisi);
        }
    }
}
