using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Eventing.Reader;
using System.IO.Ports;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ATM_Project
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double bakiye = 2500;
            string sifre = "ab18";
            int hak = 3;


            Console.WriteLine("ATM'ye hoşgeldiniz! Lütfen yapmak istediğiniz işlemi tuşlayınız: ");
        BASADON:
            Console.WriteLine("1 Kartlı İşlem \n2 Kartsız İşlem");
            string islem = Console.ReadLine();

            #region Kartlı İşlem Menüsü
            if (islem == "1")
            {
                while (hak > 0)
                {
                    Console.Write("Lütfen şifrenizi giriniz: ");
                    string sifre1 = Console.ReadLine();

                    if (sifre1 == sifre)
                    {

                        Console.WriteLine("Başarılı bir şekilde giriş yaptınız.");
                    DON:
                        Console.WriteLine("ANA MENÜ \nLütfen yapmak istediğiniz işlemi tuşlayınız\n1 Para Çekme\n2 Para Yatırma\n3 Para Transferi\n4 Eğitim Ödemeleri\n5 Ödemeler\n6 Bilgi Güncelleme");
                        string aMenuSecim = Console.ReadLine();
                        #region Para Çekme
                        if (aMenuSecim == "1")
                        {
                            Console.Write("Lütfen çekilecek tutarı giriniz: ");
                            double cekilecekTutar = Convert.ToDouble(Console.ReadLine());


                            if (cekilecekTutar <= bakiye)
                            {

                                Console.WriteLine("Çekilen tutar: " + cekilecekTutar + "\nGüncel Bakiyeniz: " + (bakiye - cekilecekTutar) + "\n9 Ana Menüye Dön\n0 Hesaptan çık");
                                string secim = Console.ReadLine();
                                bakiye = bakiye - cekilecekTutar;

                                if (secim == "9")
                                {
                                    goto DON;
                                }
                                else if (secim == "0")
                                {
                                    Console.WriteLine("Hesaptan çıkış yapıldı.");
                                }


                            }

                            else if (cekilecekTutar > bakiye)
                            {
                                Console.WriteLine("Yeterli bakiyeniz bulunmamaktadır. \n9 Ana Menüye Dön\n0 Hesaptan çık");
                                string secim = Console.ReadLine();
                                if (secim == "9")
                                {
                                    goto DON;
                                }
                                else if (secim == "0")
                                {
                                    Console.WriteLine("Hesaptan çıkış yapıldı.");
                                }
                            }
                        }
                        #endregion
                        #region Para Yatırma
                        else if (aMenuSecim == "2")
                        {
                            Console.WriteLine("1 Kredi Kartına Para Yatır\n2 Kendi Hesabına Para Yatır");
                            string secim = Console.ReadLine();
                            if (secim == "1")
                            {
                                hak = 3;
                                
                                while (hak > 0)
                                {
                                    Console.WriteLine("Lütfen 12 haneli kredi kartı numaranızı giriniz.");
                                    string kkNo = Console.ReadLine();
                                    
                                    if (kkNo.Length != 12)
                                    {
                                        hak--;
                                        Console.WriteLine("Lütfen kart numaranızı 12 haneli olacak şekilde tuşlayınız.");   
                                    }
                                    if (hak == 0)
                                    {
                                        Console.WriteLine("9 Ana Menüye Dön\n0 Hesaptan çık");
                                        string secim1 = Console.ReadLine();
                                        if (secim1 == "9")
                                        {
                                            goto DON;
                                        }
                                        else if (secim1 == "0")
                                        {
                                            Console.WriteLine("Hesaptan çıkış yapıldı.");
                                        }
                                    }
                                    else if (kkNo.Length == 12)
                                    {
                                        Console.Write("Lütfen yatırılacak tutarı giriniz: ");
                                        double yatirilacakTutar = Convert.ToDouble(Console.ReadLine());
                                        if (bakiye >= yatirilacakTutar)
                                        {
                                            bakiye = bakiye - yatirilacakTutar;
                                            Console.WriteLine("Kredi Kartına ödeme yapılmıştır. \nGüncel Bakiye: " + bakiye);
                                            Console.WriteLine("9 Ana Menüye Dön\n0 Hesaptan çık");
                                            string secim1 = Console.ReadLine();
                                            if (secim1 == "9")
                                            {
                                                goto DON;
                                            }
                                            else if (secim1 == "0")
                                            {
                                                Console.WriteLine("Hesaptan çıkış yapıldı.");
                                            }

                                        }
                                        else
                                        {
                                            Console.WriteLine("Hesabınızda yeterli bakiye bulunmamaktadır.");
                                            Console.WriteLine("9 Ana Menüye Dön\n0 Hesaptan çık");
                                            string secim1 = Console.ReadLine();
                                            if (secim1 == "9")
                                            {
                                                goto DON;
                                            }
                                            else if (secim1 == "0")
                                            {
                                                Console.WriteLine("Hesaptan çıkış yapıldı.");
                                            }
                                        }
                                    }
                                }
                            }
                            else if (secim == "2")
                            {
                                Console.Write("Lütfen hesabınıza yatırmak istediğiniz tutarı giriniz: ");
                                double yatirilacakTutar = Convert.ToDouble(Console.ReadLine());
                                if (bakiye>=yatirilacakTutar)
                                {
                                    bakiye = bakiye - yatirilacakTutar;
                                    Console.WriteLine("Tutar hesabınıza aktarılmıştır. Güncel Bakiyeniz: "+bakiye);
                                    Console.WriteLine("9 Ana Menüye Dön\n0 Hesaptan çık");
                                    string secim1 = Console.ReadLine();
                                    if (secim1 == "9")
                                    {
                                        goto DON;
                                    }
                                    else if (secim1 == "0")
                                    {
                                        Console.WriteLine("Hesaptan çıkış yapıldı.");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Yeterli bakiyeniz bulunmamaktadır.");
                                    Console.WriteLine("9 Ana Menüye Dön\n0 Hesaptan çık");
                                    string secim1 = Console.ReadLine();
                                    if (secim1 == "9")
                                    {
                                        goto DON;
                                    }
                                    else if (secim1 == "0")
                                    {
                                        Console.WriteLine("Hesaptan çıkış yapıldı.");
                                    }
                                }
                            }
                        }
                        #endregion
                        #region Para Transferi
                        else if (aMenuSecim == "3")
                        {
                            Console.WriteLine("Lütfen yapmak istediğiniz işlemi tuşlayınız\n1 Başka Hesaba EFT \n2 Başka Hesaba Havale");
                            string secim2 = Console.ReadLine();

                            if (secim2 == "1")
                            {
                            DON2:
                                Console.Write("Lütfen başına TR ekleyerek EFT yapılacak hesap numarasını giriniz: ");
                                string EFTno = Console.ReadLine();
                                if (EFTno.StartsWith("TR") && EFTno.Length == 14)
                                {
                                    Console.Write("Lütfen yatırmak istediğiniz tutarı giriniz: ");
                                    double gonderilecekTutar = Convert.ToDouble(Console.ReadLine());
                                    if (gonderilecekTutar > bakiye)
                                    {
                                        Console.WriteLine("Yeterli bakiyeniz bulunmamaktadır. \n9 Ana Menüye Dön\n0 Hesaptan çık");
                                        string secim = Console.ReadLine();
                                        if (secim == "9")
                                        {
                                            goto DON;
                                        }
                                        else if (secim == "0")
                                        {
                                            Console.WriteLine("Hesaptan çıkış yapıldı.");
                                        }
                                    }
                                    else if (gonderilecekTutar < bakiye)
                                    {
                                        bakiye = bakiye - gonderilecekTutar;
                                        Console.WriteLine("EFT yapılmıştır. Yeni Bakiyeniz: " + bakiye);
                                        Console.WriteLine("9 Ana Menüye Dön\n0 Hesaptan çık");
                                        string secim = Console.ReadLine();
                                        if (secim == "9")
                                        {
                                            goto DON;
                                        }
                                        else if (secim == "0")
                                        {
                                            Console.WriteLine("Hesaptan çıkış yapıldı.");
                                        }

                                    }

                                }

                                else
                                {
                                    Console.WriteLine("Hatalı EFT Numarası. Lütfen başına TR ekleyin ve 12 haneli bir numara girin.");
                                    goto DON2;
                                }

                            }
                            else if (secim2 == "2")
                            {
                            DON2:
                                Console.Write("Lütfen 11 haneli hesap numarasını giriniz: ");
                                string hesapNo = Console.ReadLine();
                                if (hesapNo.Length == 11)
                                {
                                    Console.Write("Lütfen yatırmak istediğiniz tutarı giriniz: ");
                                    double gonderilecekTutar = Convert.ToDouble(Console.ReadLine());
                                    if (gonderilecekTutar > bakiye)
                                    {
                                        Console.WriteLine("Yeterli bakiyeniz bulunmamaktadır. \n9 Ana Menüye Dön\n0 Hesaptan çık");
                                        string secim = Console.ReadLine();
                                        if (secim == "9")
                                        {
                                            goto DON;
                                        }
                                        else if (secim == "0")
                                        {
                                            Console.WriteLine("Hesaptan çıkış yapıldı.");
                                        }
                                    }
                                    else if (gonderilecekTutar < bakiye)
                                    {
                                        bakiye = bakiye - gonderilecekTutar;
                                        Console.WriteLine("EFT yapılmıştır. Yeni Bakiyeniz: " + bakiye);
                                        Console.WriteLine("9 Ana Menüye Dön\n0 Hesaptan çık");
                                        string secim = Console.ReadLine();
                                        if (secim == "9")
                                        {
                                            goto DON;
                                        }
                                        else if (secim == "0")
                                        {
                                            Console.WriteLine("Hesaptan çıkış yapıldı.");
                                        }

                                    }

                                }

                                else
                                {
                                    Console.WriteLine("Hatalı Hesap Numarası. Lütfen 11 haneli bir numara girin.");
                                    goto DON2;
                                }
                            }

                        }
                        #endregion
                        #region Eğitim Ödemeleri
                        else if (aMenuSecim == "4")
                        {
                            Console.WriteLine("Eğitim Ödemeleri Sayfası arızalıdır. Lütfen daha sonra tekrar deneyiniz. \n9 Ana Menüye Dön\n0 Hesaptan Çık");
                            string secim = Console.ReadLine();

                            if (secim == "9")
                            {
                                goto DON;
                            }
                            else if (secim == "0")
                            {
                                Console.WriteLine("Hesaptan çıkış yapıldı.");
                            }
                        }
                        #endregion
                        #region Ödemeler
                        else if (aMenuSecim == "5")
                        {
                            Console.WriteLine("1 Elektrik Faturası\n2 Telefon Faturası\n3 İnternet Faturası\n4 Su Faturası\n5 OGS Ödemeleri");
                            string secim = Console.ReadLine();
                            if (secim == "1")
                            {
                                Console.Write("Lütfen fatura tutarını giriniz:");
                                double faturaTutari = Convert.ToDouble(Console.ReadLine());
                                if (bakiye >= faturaTutari)
                                {
                                    bakiye = bakiye - faturaTutari;
                                    Console.WriteLine("Faturanız yatırılmıştır.\nKalan Bakiyeniz: " + bakiye + "\n9 Ana Menüye Dön\n0 Hesaptan Çık");
                                    string secim1 = Console.ReadLine();

                                    if (secim1 == "9")
                                    {
                                        goto DON;
                                    }
                                    else if (secim1 == "0")
                                    {
                                        Console.WriteLine("Hesaptan çıkış yapıldı.");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Yeterli bakiyeniz bulunmamaktadır.\n9 Ana Menüye Dön\n0 Hesaptan Çık");
                                    string secim1 = Console.ReadLine();

                                    if (secim1 == "9")
                                    {
                                        goto DON;
                                    }
                                    else if (secim1 == "0")
                                    {
                                        Console.WriteLine("Hesaptan çıkış yapıldı.");
                                    }
                                }
                            }

                            else if (secim == "2")
                            {
                                Console.Write("Lütfen fatura tutarını giriniz:");
                                double faturaTutari = Convert.ToDouble(Console.ReadLine());
                                if (bakiye >= faturaTutari)
                                {
                                    bakiye = bakiye - faturaTutari;
                                    Console.WriteLine("Faturanız yatırılmıştır.\nKalan Bakiyeniz: " + bakiye + "\n9 Ana Menüye Dön\n0 Hesaptan Çık");
                                    string secim1 = Console.ReadLine();

                                    if (secim1 == "9")
                                    {
                                        goto DON;
                                    }
                                    else if (secim1 == "0")
                                    {
                                        Console.WriteLine("Hesaptan çıkış yapıldı.");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Yeterli bakiyeniz bulunmamaktadır.\n9 Ana Menüye Dön\n0 Hesaptan Çık");
                                    string secim1 = Console.ReadLine();

                                    if (secim1 == "9")
                                    {
                                        goto DON;
                                    }
                                    else if (secim1 == "0")
                                    {
                                        Console.WriteLine("Hesaptan çıkış yapıldı.");
                                    }
                                }
                            }

                            else if (secim == "3")
                            {
                                Console.Write("Lütfen fatura tutarını giriniz:");
                                double faturaTutari = Convert.ToDouble(Console.ReadLine());
                                if (bakiye >= faturaTutari)
                                {
                                    bakiye = bakiye - faturaTutari;
                                    Console.WriteLine("Faturanız yatırılmıştır.\nKalan Bakiyeniz: " + bakiye + "\n9 Ana Menüye Dön\n0 Hesaptan Çık");
                                    string secim1 = Console.ReadLine();

                                    if (secim1 == "9")
                                    {
                                        goto DON;
                                    }
                                    else if (secim1 == "0")
                                    {
                                        Console.WriteLine("Hesaptan çıkış yapıldı.");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Yeterli bakiyeniz bulunmamaktadır.\n9 Ana Menüye Dön\n0 Hesaptan Çık");
                                    string secim1 = Console.ReadLine();

                                    if (secim1 == "9")
                                    {
                                        goto DON;
                                    }
                                    else if (secim1 == "0")
                                    {
                                        Console.WriteLine("Hesaptan çıkış yapıldı.");
                                    }
                                }
                            }

                            else if (secim == "4")
                            {
                                Console.Write("Lütfen fatura tutarını giriniz:");
                                double faturaTutari = Convert.ToDouble(Console.ReadLine());
                                if (bakiye >= faturaTutari)
                                {
                                    bakiye = bakiye - faturaTutari;
                                    Console.WriteLine("Faturanız yatırılmıştır.\nKalan Bakiyeniz: " + bakiye + "\n9 Ana Menüye Dön\n0 Hesaptan Çık");
                                    string secim1 = Console.ReadLine();

                                    if (secim1 == "9")
                                    {
                                        goto DON;
                                    }
                                    else if (secim1 == "0")
                                    {
                                        Console.WriteLine("Hesaptan çıkış yapıldı.");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Yeterli bakiyeniz bulunmamaktadır.\n9 Ana Menüye Dön\n0 Hesaptan Çık");
                                    string secim1 = Console.ReadLine();

                                    if (secim1 == "9")
                                    {
                                        goto DON;
                                    }
                                    else if (secim1 == "0")
                                    {
                                        Console.WriteLine("Hesaptan çıkış yapıldı.");
                                    }
                                }
                            }

                            else if (secim == "5")
                            {
                                Console.Write("Lütfen fatura tutarını giriniz:");
                                double faturaTutari = Convert.ToDouble(Console.ReadLine());
                                if (bakiye >= faturaTutari)
                                {
                                    bakiye = bakiye - faturaTutari;
                                    Console.WriteLine("Ödemeniz yapılmıştır.\nKalan Bakiyeniz: " + bakiye + "\n9 Ana Menüye Dön\n0 Hesaptan Çık");
                                    string secim1 = Console.ReadLine();

                                    if (secim1 == "9")
                                    {
                                        goto DON;
                                    }
                                    else if (secim1 == "0")
                                    {
                                        Console.WriteLine("Hesaptan çıkış yapıldı.");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Yeterli bakiyeniz bulunmamaktadır.\n9 Ana Menüye Dön\n0 Hesaptan Çık");
                                    string secim1 = Console.ReadLine();

                                    if (secim1 == "9")
                                    {
                                        goto DON;
                                    }
                                    else if (secim1 == "0")
                                    {
                                        Console.WriteLine("Hesaptan çıkış yapıldı.");
                                    }
                                }

                            }

                        }
                        #endregion
                        #region Bilgi Güncelleme
                        else if (aMenuSecim == "6")
                        {
                            Console.WriteLine("Lütfen yapmak istediğiniz işlemi tuşlayınız: \n1 Şifre değiştirme");
                            string sifreDegistir = Console.ReadLine();
                            Console.WriteLine("Lütfen yeni şifrenizi tuşlayınız: ");
                            string yeniSifre = Console.ReadLine();
                            sifre = yeniSifre;
                            Console.WriteLine("Şifreni değiştirilmiştir.\n9 Ana Menüye Dön\n0 Hesaptan Çık");
                            string secim1 = Console.ReadLine();

                            if (secim1 == "9")
                            {
                                goto DON;
                            }
                            else if (secim1 == "0")
                            {
                                Console.WriteLine("Hesaptan çıkış yapıldı.");
                            }
                        }
                        #endregion
                        break;
                    }
                    else
                    {
                        hak--;
                        Console.WriteLine("Yanlış şifre. Kalan deneme hakkı " + hak);
                    }

                    if (hak == 0)
                    {
                        Console.WriteLine("3 yanlış deneme sonucu kartınız bloke olmuştur. Lütfen müşteri temsilcisiyle iletişime geçiniz.");
                        break;
                    }
                }
            }
            #endregion

            #region Kartsız İşlem Menüsü
            else if (islem == "2")
            {
                string TC = "21935658470";
                string cepNo = "5448681992";
                int hak1 = 3;


                Console.WriteLine("ANA MENÜ \nLütfen yapmak istediğiniz işlemi tuşlayınız\n1 CepBank Para Çekme\n2 Para Yatırma\n3 Kredi Kartı Ödeme\n4 Eğitim Ödemeleri\n5 Ödemeler");
                string secim = Console.ReadLine();
                #region CepBank Para Çekme
                if (secim == "1")
                {
                    while (true)
                    {
                        Console.Write("Lütfen 11 haneli TC Kimlik Numaranızı tuşlayınız: ");
                        string kTC = Console.ReadLine();
                        Console.Write("Lütfen başında sıfır olmadan 10 haneli cep telefonu numaranızı tuşlayınız: ");
                        string kCep = Console.ReadLine();

                        if (kTC == TC && kCep == cepNo)
                        {
                            bakiye = bakiye - 1000;
                            Console.WriteLine("Hesabınızdan 1000 TL çekilmiştir. Kalan bakiyeniz: " + bakiye);
                            Console.WriteLine("\n9 Ana Menüye Dön\n0 Hesaptan Çık");
                            string secim1 = Console.ReadLine();

                            if (secim1 == "9")
                            {
                                goto BASADON;
                            }
                            else if (secim1 == "0")
                            {
                                Console.WriteLine("Hesaptan çıkış yapıldı.");
                            }
                            break;
                        }
                        if (hak1 == 1)
                        {
                            Console.WriteLine("Hesabınız kilitlenmiştir. Lütfen 1 saat sonra tekrar deneyin.");
                            Thread.Sleep(TimeSpan.FromHours(1));
                            hak1 = 3;
                            break;
                        }
                        else if (kTC != TC || kCep != cepNo)
                        {
                            hak1--;
                            Console.WriteLine("TC Kimlik No ya da Cep No hatalıdır. Lütfen tekrar deneyiniz.\nKalan Deneme Hakkınız: " + hak1);
                        }
                    }
                }
                #endregion
                #region Para Yatırma
                else if (secim == "2")
                {
                    Console.WriteLine("1 Nakit Ödeme\n2 Hesaptan Ödeme\n9 Ana Menüye Dön\n0 Hesaptan Çık");
                    string secim1 = Console.ReadLine();

                    if (secim1 == "1")
                    {
                        hak = 3;
                        while (true)
                        {
                            Console.Write("Lütfen en az 12 haneli kredi kartı numaranızı giriniz: ");
                            string kkNo = Console.ReadLine();
                            Console.Write("Lütfen TC Kimlik Numaranızı giriniz: ");
                            string tcNo = Console.ReadLine();

                            if (kkNo.Length == 12 && tcNo.Length == 11)
                            {
                                Console.Write("Lütfen yatırmak istediğiniz tutarı giriniz: ");
                                double yatirilacakTutar = Convert.ToDouble(Console.ReadLine());
                                bakiye = bakiye - yatirilacakTutar;
                                Console.WriteLine(yatirilacakTutar + " TL Kredi Kartınıza ödenmiştir. Güncel Bakiyeniz: " + bakiye);
                                Console.WriteLine("\n9 Ana Menüye Dön\n0 Hesaptan Çık");
                                string secim2 = Console.ReadLine();

                                if (secim2 == "9")
                                {
                                    goto BASADON;
                                }
                                else if (secim2 == "0")
                                {
                                    Console.WriteLine("Hesaptan çıkış yapıldı.");
                                }

                            }
                            else if (kkNo.Length != 12 || tcNo.Length == 11)
                            {
                                hak--;
                                Console.WriteLine("Kredi Kartı ya da TC Kimlik Numarası hatalıdır. Lütfen Kredi Kartı Numaranızı 12, TC Kimlik Numaranızı 11 haneli olacak şekilde tuşlayınız.");
                                Console.WriteLine("Kalan Hakkınız " + hak);
                            }
                            if (hak == 0)
                            {
                                Console.WriteLine("Hesabınız kilitlenmiştir. Hesaptan çıkış yapılıyor.");
                                break;
                            }
                        }
                    }
                    else if (secim1 == "2")
                    {
                        hak = 3;
                        while (true)
                        {
                            Console.Write("Lütfen en az 12 haneli kredi kartı numaranızı giriniz: ");
                            string kkNo = Console.ReadLine();
                            Console.Write("Lütfen hesap numaranızı giriniz: ");
                            string hesapNo = Console.ReadLine();

                            if (kkNo.Length == 12)
                            {
                                Console.Write("Lütfen yatırmak istediğiniz tutarı giriniz: ");
                                double yatirilacakTutar = Convert.ToDouble(Console.ReadLine());
                                bakiye = bakiye - yatirilacakTutar;
                                Console.WriteLine(yatirilacakTutar + " TL Kredi Kartınıza ödenmiştir. Güncel Bakiyeniz: " + bakiye);
                                Console.WriteLine("\n9 Ana Menüye Dön\n0 Hesaptan Çık");
                                string secim2 = Console.ReadLine();

                                if (secim2 == "9")
                                {
                                    goto BASADON;
                                }
                                else if (secim2 == "0")
                                {
                                    Console.WriteLine("Hesaptan çıkış yapıldı.");
                                }

                            }
                            else if (kkNo.Length != 12)
                            {
                                hak--;
                                Console.WriteLine("Kredi Kartı Numarası hatalıdır. Lütfen Kredi Kartı Numaranızı 12 haneli olacak şekilde tuşlayınız.");
                                Console.WriteLine("Kalan Hakkınız " + hak);
                            }
                            if (hak == 0)
                            {
                                Console.WriteLine("Hesabınız kilitlenmiştir. Hesaptan çıkış yapılıyor.");
                                break;
                            }
                        }
                    }

                    else if (secim1 == "9")
                    {
                        goto BASADON;
                    }
                    else if (secim == "0")
                    {
                        Console.WriteLine("Hesaptan çıkış yapıldı.");
                    }
                }
                #endregion
                #region Kredi Kartı Ödeme
                else if (secim == "3") //kontrol et
                {
                    Console.WriteLine("1 Başka Hesaba EFT\n2 Başka Hesaba Havale");
                    string secim1 = Console.ReadLine();
                    if (secim1 == "1")
                    {
                    DON3:
                        Console.Write("Lütfen başına TR ekleyerek EFT yapılacak hesap numarasını giriniz: ");
                        string EFTno = Console.ReadLine();

                        if (EFTno.StartsWith("TR") && EFTno.Length == 14)
                        {
                            Console.Write("Lütfen yatırmak istediğiniz tutarı giriniz: ");
                            double gonderilecekTutar = Convert.ToDouble(Console.ReadLine());
                            if (gonderilecekTutar > bakiye)
                            {
                                Console.WriteLine("Yeterli bakiyeniz bulunmamaktadır. \n9 Ana Menüye Dön\n0 Hesaptan çık");
                                string secim2 = Console.ReadLine();
                                if (secim2 == "9")
                                {
                                    goto BASADON;
                                }
                                else if (secim2 == "0")
                                {
                                    Console.WriteLine("Hesaptan çıkış yapıldı.");
                                }
                            }
                            else if (gonderilecekTutar < bakiye)
                            {
                                bakiye = bakiye - gonderilecekTutar;
                                Console.WriteLine("EFT yapılmıştır. Yeni Bakiyeniz: " + bakiye);
                                Console.WriteLine("9 Ana Menüye Dön\n0 Hesaptan çık");
                                string secim2 = Console.ReadLine();
                                if (secim2 == "9")
                                {
                                    goto BASADON;
                                }
                                else if (secim2 == "0")
                                {
                                    Console.WriteLine("Hesaptan çıkış yapıldı.");
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("EFT No TR ile başlamalı ve 12 hane olmalıdır.");
                            goto DON3;
                        }
                    }
                    else if (secim1 == "2") //kontrol et
                    {
                        hak = 3;
                        while (true)
                        {
                            Console.Write("Lütfen 11 haneli hesap numarasını giriniz: ");
                            string hesapNo = Console.ReadLine();
                            if (hesapNo.Length == 11)
                            {
                                Console.Write("Lütfen yatırmak istediğiniz tutarı giriniz: ");
                                double yatirilacakTutar = Convert.ToDouble(Console.ReadLine());
                                if (bakiye >= yatirilacakTutar)
                                {
                                    bakiye = bakiye - yatirilacakTutar;
                                    Console.WriteLine("Paranız hesaba yatırılmıştır. Güncel bakiyeniz: " + bakiye + "\n9 Ana Menüye Dön\n0 Hesaptan Çık");
                                    string secim2 = Console.ReadLine();
                                    if (secim2 == "9")
                                    {
                                        goto BASADON;
                                    }
                                    else if (secim2 == "0")
                                    {
                                        Console.WriteLine("Hesaptan Çıkılıyor...");
                                        break;
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Yeterli Bakiyeniz Bulunmamaktadır.\n9 Ana Menüye Dön\n0 Hesaptan Çık");
                                    string secim2 = Console.ReadLine();
                                    if (secim2 == "9")
                                    {
                                        goto BASADON;
                                    }
                                    else if (secim2 == "0")
                                    {
                                        Console.WriteLine("Hesaptan Çıkılıyor...");
                                        break;
                                    }
                                }
                            }
                            else if (hesapNo.Length != 11)
                            {
                                hak--;
                                Console.WriteLine("Lütfen hesap numaranızı 11 hane olacak şekilde tuşlayınız. Kalan deneme hakkı: " + hak);
                                if (hak == 0)
                                {
                                    Console.WriteLine("3 yanlış deneme sonucu hesabınız kilitlenmiştir. Çıkış yapılıyor...");
                                    break;
                                }
                            }
                            else
                            {
                                Console.WriteLine("Hesap No 11 haneli olmalıdır. Lütfen tekrar deneyin. Kalan Deneme Hakkınız: " + hak);
                                hak--;
                            }
                            if (hak == 0)
                            {
                                Console.WriteLine("Hesabınız bloke olmuştur. Çıkış yapılıyor.");
                                break;
                            }
                        }
                    }
                }
                #endregion
                #region Eğitim Ödemeleri
                else if (secim == "4")
                {
                    Console.WriteLine("Eğitim Ödemeleri Sayfası arızalıdır. Lütfen daha sonra tekrar deneyiniz. \n9 Ana Menüye Dön\n0 Hesaptan Çık");
                    string secim1 = Console.ReadLine();

                    if (secim == "9")
                    {
                        goto BASADON;
                    }
                    else if (secim == "0")
                    {
                        Console.WriteLine("Hesaptan çıkış yapıldı.");
                    }
                }
                #endregion
                #region Ödemeler
                else if (secim == "5")
                {
                    Console.WriteLine("1 Elektrik Faturası\n2 Telefon Faturası\n3 İnternet Faturası\n4 Su Faturası\n5 OGS Ödemeleri");
                    string secim1 = Console.ReadLine();
                    if (secim1 == "1")
                    {
                        Console.Write("Lütfen fatura tutarını giriniz:");
                        double faturaTutari = Convert.ToDouble(Console.ReadLine());
                        if (bakiye >= faturaTutari)
                        {
                            bakiye = bakiye - faturaTutari;
                            Console.WriteLine("Faturanız yatırılmıştır.\nKalan Bakiyeniz: " + bakiye + "\n9 Ana Menüye Dön\n0 Hesaptan Çık");
                            string secim2 = Console.ReadLine();

                            if (secim2 == "9")
                            {
                                goto BASADON;
                            }
                            else if (secim2 == "0")
                            {
                                Console.WriteLine("Hesaptan çıkış yapıldı.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Yeterli bakiyeniz bulunmamaktadır.\n9 Ana Menüye Dön\n0 Hesaptan Çık");
                            string secim2 = Console.ReadLine();

                            if (secim2 == "9")
                            {
                                goto BASADON;
                            }
                            else if (secim2 == "0")
                            {
                                Console.WriteLine("Hesaptan çıkış yapıldı.");
                            }
                        }
                    }

                    else if (secim == "2")
                    {
                        Console.Write("Lütfen fatura tutarını giriniz:");
                        double faturaTutari = Convert.ToDouble(Console.ReadLine());
                        if (bakiye >= faturaTutari)
                        {
                            bakiye = bakiye - faturaTutari;
                            Console.WriteLine("Faturanız yatırılmıştır.\nKalan Bakiyeniz: " + bakiye + "\n9 Ana Menüye Dön\n0 Hesaptan Çık");
                            string secim2 = Console.ReadLine();

                            if (secim2 == "9")
                            {
                                goto BASADON;
                            }
                            else if (secim2 == "0")
                            {
                                Console.WriteLine("Hesaptan çıkış yapıldı.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Yeterli bakiyeniz bulunmamaktadır.\n9 Ana Menüye Dön\n0 Hesaptan Çık");
                            string secim2 = Console.ReadLine();

                            if (secim2 == "9")
                            {
                                goto BASADON;
                            }
                            else if (secim2 == "0")
                            {
                                Console.WriteLine("Hesaptan çıkış yapıldı.");
                            }
                        }
                    }

                    else if (secim == "3")
                    {
                        Console.Write("Lütfen fatura tutarını giriniz:");
                        double faturaTutari = Convert.ToDouble(Console.ReadLine());
                        if (bakiye >= faturaTutari)
                        {
                            bakiye = bakiye - faturaTutari;
                            Console.WriteLine("Faturanız yatırılmıştır.\nKalan Bakiyeniz: " + bakiye + "\n9 Ana Menüye Dön\n0 Hesaptan Çık");
                            string secim2 = Console.ReadLine();

                            if (secim2 == "9")
                            {
                                goto BASADON;
                            }
                            else if (secim2 == "0")
                            {
                                Console.WriteLine("Hesaptan çıkış yapıldı.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Yeterli bakiyeniz bulunmamaktadır.\n9 Ana Menüye Dön\n0 Hesaptan Çık");
                            string secim2 = Console.ReadLine();

                            if (secim2 == "9")
                            {
                                goto BASADON;
                            }
                            else if (secim2 == "0")
                            {
                                Console.WriteLine("Hesaptan çıkış yapıldı.");
                            }
                        }
                    }

                    else if (secim == "4")
                    {
                        Console.Write("Lütfen fatura tutarını giriniz:");
                        double faturaTutari = Convert.ToDouble(Console.ReadLine());
                        if (bakiye >= faturaTutari)
                        {
                            bakiye = bakiye - faturaTutari;
                            Console.WriteLine("Faturanız yatırılmıştır.\nKalan Bakiyeniz: " + bakiye + "\n9 Ana Menüye Dön\n0 Hesaptan Çık");
                            string secim2 = Console.ReadLine();

                            if (secim2 == "9")
                            {
                                goto BASADON;
                            }
                            else if (secim2 == "0")
                            {
                                Console.WriteLine("Hesaptan çıkış yapıldı.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Yeterli bakiyeniz bulunmamaktadır.\n9 Ana Menüye Dön\n0 Hesaptan Çık");
                            string secim2 = Console.ReadLine();

                            if (secim2 == "9")
                            {
                                goto BASADON;
                            }
                            else if (secim2 == "0")
                            {
                                Console.WriteLine("Hesaptan çıkış yapıldı.");
                            }
                        }
                    }

                    else if (secim == "5")
                    {
                        Console.Write("Lütfen fatura tutarını giriniz:");
                        double faturaTutari = Convert.ToDouble(Console.ReadLine());
                        if (bakiye >= faturaTutari)
                        {
                            bakiye = bakiye - faturaTutari;
                            Console.WriteLine("Ödemeniz yapılmıştır.\nKalan Bakiyeniz: " + bakiye + "\n9 Ana Menüye Dön\n0 Hesaptan Çık");
                            string secim2 = Console.ReadLine();

                            if (secim2 == "9")
                            {
                                goto BASADON;
                            }
                            else if (secim2 == "0")
                            {
                                Console.WriteLine("Hesaptan çıkış yapıldı.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Yeterli bakiyeniz bulunmamaktadır.\n9 Ana Menüye Dön\n0 Hesaptan Çık");
                            string secim2 = Console.ReadLine();

                            if (secim2 == "9")
                            {
                                goto BASADON;
                            }
                            else if (secim2 == "0")
                            {
                                Console.WriteLine("Hesaptan çıkış yapıldı.");
                            }
                        }
                    }
                }
                #endregion
            }
            #endregion
            #region Kartlı / Kartsız işlem menüsünde 1-2 dışında bir şey tuşlanırsa hata ver.
            else if (islem != "1" && islem != "2")
            {
                Console.WriteLine("Lütfen geçerli bir işlem tuşlayınız.");
                goto BASADON;
            }
            #endregion
            Console.ReadLine();
        }
    }
}

