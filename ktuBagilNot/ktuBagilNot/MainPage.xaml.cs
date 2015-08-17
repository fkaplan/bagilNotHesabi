using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Networking.Connectivity;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;


// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=391641

namespace ktuBagilNot
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            this.NavigationCacheMode = NavigationCacheMode.Required;


        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // TODO: Prepare page for display here.

            // TODO: If your application contains multiple pages, ensure that you are
            // handling the hardware Back button by registering for the
            // Windows.Phone.UI.Input.HardwareButtons.BackPressed event.
            // If you are using the NavigationHelper provided by some templates,
            // this event is handled for you.
        }

        private void Temizle_Click(object sender, RoutedEventArgs e)
        {
            TxtFinalNotu.Text = "";
            TxtSinifOrtalamasi.Text = "";
            TxtSonuc.Text = "";
            TxtStandartSapma.Text = "";
            TxtVizeNotu.Text = "";

            txtAlinanNot.Text = "";
            txtSinifDuzeyi.Text = "";
            txtAA.Text = "";           
            txtBA.Text = "";
            txtBB.Text = "";
            txtCB.Text = "";
            txtCC.Text = "";
            txtDC.Text = "";
        }

        private void HarfliNot_Click(object sender, RoutedEventArgs e)
        {
            
            if (Convert.ToBoolean(rbOgrenciSayisi30Ustu.IsChecked))
            {
                if (TxtVizeNotu.Text == "" || TxtSinifOrtalamasi.Text == "")
                    TxtSonuc.Text = "Vize Notu ve Ortalama Boş Bırakılamaz.";
                else if(Double.Parse(TxtSinifOrtalamasi.Text)<80)
                {
                    if(TxtStandartSapma.Text=="")
                        TxtSonuc.Text = "Vize Notu , Ortalama ve Standart Sapma Boş Bırakılamaz.";
                    else
                        tablo1();
                }
                else if( Double.Parse(TxtSinifOrtalamasi.Text) >= 80)
                    tablo3();
            }
            else if(Convert.ToBoolean(rbOgrenciSayisi1ile10.IsChecked) || Double.Parse(TxtSinifOrtalamasi.Text) >= 80)
            {
                tablo3();
            }                  
        }
        public void tablo1()
        {
            double Final;

            //Yalnızca Vize Notu Girilmişse
            if (TxtFinalNotu.Text == "")
            {   

                //Sınıf Durumu Mükemmel           
                if (70 < Double.Parse(TxtSinifOrtalamasi.Text) && Double.Parse(TxtSinifOrtalamasi.Text) < 80)
                {
                    for (double x = 34.0; x <= 38.99; x++)
                    {
                        Final = (((((x - 50.0) / 10.0) * Double.Parse(TxtStandartSapma.Text)) + Double.Parse(TxtSinifOrtalamasi.Text)) * 2) - Double.Parse(TxtVizeNotu.Text);
                        if (45 <= Final && Final <= 100)
                        {
                            txtDC.Text = "" + Final;
                            break;
                        }
                        txtDC.Text = "X";
                    }

                    for (double x = 39.0; x <= 43.99; x++)
                    {
                        Final = (((((x - 50.0) / 10.0) * Double.Parse(TxtStandartSapma.Text)) + Double.Parse(TxtSinifOrtalamasi.Text)) * 2) - Double.Parse(TxtVizeNotu.Text);
                        if (45 <= Final && Final <= 100)
                        {
                            txtCC.Text = "" + Final;
                            break;
                        }
                        txtCC.Text = "X";
                    }

                    for (double x = 44.0; x <= 48.99; x++)
                    {
                        Final = (((((x - 50.0) / 10.0) * Double.Parse(TxtStandartSapma.Text)) + Double.Parse(TxtSinifOrtalamasi.Text)) * 2) - Double.Parse(TxtVizeNotu.Text);
                        if (45 <= Final && Final <= 100)
                        {
                            txtCB.Text = "" + Final;
                            break;
                        }
                        txtCB.Text = "X";
                    }

                    for (double x = 49.0; x <= 53.99; x++)
                    {
                        Final = (((((x - 50.0) / 10.0) * Double.Parse(TxtStandartSapma.Text)) + Double.Parse(TxtSinifOrtalamasi.Text)) * 2) - Double.Parse(TxtVizeNotu.Text);
                        if (45 <= Final && Final <= 100)
                        {
                            txtBB.Text = "" + Final;
                            break;
                        }
                        txtBB.Text = "X";
                    }

                    for (double x = 54.0; x <= 58.99; x++)
                    {
                        Final = (((((x - 50.0) / 10.0) * Double.Parse(TxtStandartSapma.Text)) + Double.Parse(TxtSinifOrtalamasi.Text)) * 2) - Double.Parse(TxtVizeNotu.Text);
                        if (45 <= Final && Final <= 100)
                        {
                            txtBA.Text = "" + Final;
                            break;
                        }
                        txtBA.Text = "X";
                    }

                    for (double x = 59.0; x <= 100.0; x++)
                    {
                        Final = (((((x - 50.0) / 10.0) * Double.Parse(TxtStandartSapma.Text)) + Double.Parse(TxtSinifOrtalamasi.Text)) * 2) - Double.Parse(TxtVizeNotu.Text);
                        if (45 <= Final && Final <= 100)
                        {
                            txtAA.Text = "" + Final;
                            break;
                        }
                        txtAA.Text = "X";
                    }                        
                }

                //Sınıf Durumu Çok İyi
                else if(62.5 < Double.Parse(TxtSinifOrtalamasi.Text) && Double.Parse(TxtSinifOrtalamasi.Text) < 70)
                {
                    for (double x = 36.0; x <= 40.99; x++)
                    {
                        Final = (((((x - 50.0) / 10.0) * Double.Parse(TxtStandartSapma.Text)) + Double.Parse(TxtSinifOrtalamasi.Text)) * 2) - Double.Parse(TxtVizeNotu.Text);
                        if (45 <= Final && Final <= 100)
                        {
                            txtDC.Text = "" + Final;
                            break;
                        }
                        txtDC.Text = "X";
                    }

                    for (double x = 41.0; x <= 45.99; x++)
                    {
                        Final = (((((x - 50.0) / 10.0) * Double.Parse(TxtStandartSapma.Text)) + Double.Parse(TxtSinifOrtalamasi.Text)) * 2) - Double.Parse(TxtVizeNotu.Text);
                        if (45 <= Final && Final <= 100)
                        {
                            txtCC.Text = "" + Final;
                            break;
                        }
                        txtCC.Text = "X";
                    }

                    for (double x = 46.0; x <= 50.99; x++)
                    {
                        Final = (((((x - 50.0) / 10.0) * Double.Parse(TxtStandartSapma.Text)) + Double.Parse(TxtSinifOrtalamasi.Text)) * 2) - Double.Parse(TxtVizeNotu.Text);
                        if (45 <= Final && Final <= 100)
                        {
                            txtCB.Text = "" + Final;
                            break;
                        }
                        txtCB.Text = "X";
                    }

                    for (double x = 51.0; x <= 55.99; x++)
                    {
                        Final = (((((x - 50.0) / 10.0) * Double.Parse(TxtStandartSapma.Text)) + Double.Parse(TxtSinifOrtalamasi.Text)) * 2) - Double.Parse(TxtVizeNotu.Text);
                        if (45 <= Final && Final <= 100)
                        {
                            txtBB.Text = "" + Final;
                            break;
                        }
                        txtBB.Text = "X";
                    }

                    for (double x = 56.0; x <= 60.99; x++)
                    {
                        Final = (((((x - 50.0) / 10.0) * Double.Parse(TxtStandartSapma.Text)) + Double.Parse(TxtSinifOrtalamasi.Text)) * 2) - Double.Parse(TxtVizeNotu.Text);
                        if (45 <= Final && Final <= 100)
                        {
                            txtBA.Text = "" + Final;
                            break;
                        }
                        txtBA.Text = "X";   
                    }

                    for (double x = 61.0; x <= 100.0; x++)
                    {
                        Final = (((((x - 50.0) / 10.0) * Double.Parse(TxtStandartSapma.Text)) + Double.Parse(TxtSinifOrtalamasi.Text)) * 2) - Double.Parse(TxtVizeNotu.Text);
                        if (45 <= Final && Final <= 100)
                        {
                            txtAA.Text = "" + Final;
                            break;
                        }
                        txtAA.Text = "X";
                    }
                }

                //Sınıf Durumu İyi
                else if (57.5 < Double.Parse(TxtSinifOrtalamasi.Text) && Double.Parse(TxtSinifOrtalamasi.Text) < 62.5)
                {
                    for (double x = 38.0; x <= 42.99; x++)
                    {
                        Final = (((((x - 50.0) / 10.0) * Double.Parse(TxtStandartSapma.Text)) + Double.Parse(TxtSinifOrtalamasi.Text)) * 2) - Double.Parse(TxtVizeNotu.Text);
                        if (45 <= Final && Final <= 100)
                        {
                            txtDC.Text = "" + Final;
                            break;
                        }
                        txtDC.Text = "X";
                    }

                    for (double x = 43.0; x <= 47.99; x++)
                    {
                        Final = (((((x - 50.0) / 10.0) * Double.Parse(TxtStandartSapma.Text)) + Double.Parse(TxtSinifOrtalamasi.Text)) * 2) - Double.Parse(TxtVizeNotu.Text);
                        if (45 <= Final && Final <= 100)
                        {
                            txtCC.Text = "" + Final;
                            break;
                        }
                        txtCC.Text = "X";
                    }

                    for (double x = 48.0; x <= 52.99; x++)
                    {
                        Final = (((((x - 50.0) / 10.0) * Double.Parse(TxtStandartSapma.Text)) + Double.Parse(TxtSinifOrtalamasi.Text)) * 2) - Double.Parse(TxtVizeNotu.Text);
                        if (45 <= Final && Final <= 100)
                        {
                            txtCB.Text = "" + Final;
                            break;
                        }
                        txtCB.Text = "X";
                    }

                    for (double x = 53.0; x <= 57.99; x++)
                    {
                        Final = (((((x - 50.0) / 10.0) * Double.Parse(TxtStandartSapma.Text)) + Double.Parse(TxtSinifOrtalamasi.Text)) * 2) - Double.Parse(TxtVizeNotu.Text);
                        if (45 <= Final && Final <= 100)
                        {
                            txtBB.Text = "" + Final;
                            break;
                        }
                        txtBB.Text = "X";
                    }

                    for (double x = 58.0; x <= 62.99; x++)
                    {
                        Final = (((((x - 50.0) / 10.0) * Double.Parse(TxtStandartSapma.Text)) + Double.Parse(TxtSinifOrtalamasi.Text)) * 2) - Double.Parse(TxtVizeNotu.Text);
                        if (45 <= Final && Final <= 100)
                        {
                            txtBA.Text = "" + Final;
                            break;
                        }
                        txtBA.Text = "X";
                    }

                    for (double x = 63.0; x <= 100.0; x++)
                    {
                        Final = (((((x - 50.0) / 10.0) * Double.Parse(TxtStandartSapma.Text)) + Double.Parse(TxtSinifOrtalamasi.Text)) * 2) - Double.Parse(TxtVizeNotu.Text);
                        if (45 <= Final && Final <= 100)
                        {
                            txtAA.Text = "" + Final;
                            break;
                        }
                        txtAA.Text = "X";
                    }
                }

                //Sınıf Durumu Ortanın Üstü
                else if (52.5 < Double.Parse(TxtSinifOrtalamasi.Text) && Double.Parse(TxtSinifOrtalamasi.Text) < 57.5)
                {
                    for (double x = 40.0; x <= 44.99; x++)
                    {
                        Final = (((((x - 50.0) / 10.0) * Double.Parse(TxtStandartSapma.Text)) + Double.Parse(TxtSinifOrtalamasi.Text)) * 2) - Double.Parse(TxtVizeNotu.Text);
                        if (45 <= Final && Final <= 100)
                        {
                            txtDC.Text = "" + Final;
                            break;
                        }
                        txtDC.Text = "X";
                    }

                    for (double x = 45.0; x <= 49.99; x++)
                    {
                        Final = (((((x - 50.0) / 10.0) * Double.Parse(TxtStandartSapma.Text)) + Double.Parse(TxtSinifOrtalamasi.Text)) * 2) - Double.Parse(TxtVizeNotu.Text);
                        if (45 <= Final && Final <= 100)
                        {
                            txtCC.Text = "" + Final;
                            break;
                        }
                        txtCC.Text = "X";
                    }

                    for (double x = 50.0; x <= 54.99; x++)
                    {
                        Final = (((((x - 50.0) / 10.0) * Double.Parse(TxtStandartSapma.Text)) + Double.Parse(TxtSinifOrtalamasi.Text)) * 2) - Double.Parse(TxtVizeNotu.Text);
                        if (45 <= Final && Final <= 100)
                        {
                            txtCB.Text = "" + Final;
                            break;
                        }
                        txtCB.Text = "X";
                    }

                    for (double x = 55.0; x <= 59.99; x++)
                    {
                        Final = (((((x - 50.0) / 10.0) * Double.Parse(TxtStandartSapma.Text)) + Double.Parse(TxtSinifOrtalamasi.Text)) * 2) - Double.Parse(TxtVizeNotu.Text);
                        if (45 <= Final && Final <= 100)
                        {
                            txtBB.Text = "" + Final;
                            break;
                        }
                        txtBB.Text = "X";
                    }

                    for (double x = 60.0; x <= 64.99; x++)
                    {
                        Final = (((((x - 50.0) / 10.0) * Double.Parse(TxtStandartSapma.Text)) + Double.Parse(TxtSinifOrtalamasi.Text)) * 2) - Double.Parse(TxtVizeNotu.Text);
                        if (45 <= Final && Final <= 100)
                        {
                            txtBA.Text = "" + Final;
                            break;
                        }
                        txtBA.Text = "X";
                    }

                    for (double x = 65.0; x <= 100.0; x++)
                    {
                        Final = (((((x - 50.0) / 10.0) * Double.Parse(TxtStandartSapma.Text)) + Double.Parse(TxtSinifOrtalamasi.Text)) * 2) - Double.Parse(TxtVizeNotu.Text);
                        if (45 <= Final && Final <= 100)
                        {
                            txtAA.Text = "" + Final;
                            break;
                        }
                        txtAA.Text = "X";
                    }
                }

                //Sınıf Durumu Orta
                else if (47.5 < Double.Parse(TxtSinifOrtalamasi.Text) && Double.Parse(TxtSinifOrtalamasi.Text) < 52.5)
                {
                    for (double x = 42.0; x <= 46.99; x++)
                    {
                        Final = (((((x - 50.0) / 10.0) * Double.Parse(TxtStandartSapma.Text)) + Double.Parse(TxtSinifOrtalamasi.Text)) * 2) - Double.Parse(TxtVizeNotu.Text);
                        if (45 <= Final && Final <= 100)
                        {
                            txtDC.Text = "" + Final;
                            break;
                        }
                        txtDC.Text = "X";
                    }

                    for (double x = 47.0; x <= 51.99; x++)
                    {
                        Final = (((((x - 50.0) / 10.0) * Double.Parse(TxtStandartSapma.Text)) + Double.Parse(TxtSinifOrtalamasi.Text)) * 2) - Double.Parse(TxtVizeNotu.Text);
                        if (45 <= Final && Final <= 100)
                        {
                            txtCC.Text = "" + Final;
                            break;
                        }
                        txtCC.Text = "X";
                    }

                    for (double x = 52.0; x <= 56.99; x++)
                    {
                        Final = (((((x - 50.0) / 10.0) * Double.Parse(TxtStandartSapma.Text)) + Double.Parse(TxtSinifOrtalamasi.Text)) * 2) - Double.Parse(TxtVizeNotu.Text);
                        if (45 <= Final && Final <= 100)
                        {
                            txtCB.Text = "" + Final;
                            break;
                        }
                        txtCB.Text = "X";
                    }

                    for (double x = 57.0; x <= 61.99; x++)
                    {
                        Final = (((((x - 50.0) / 10.0) * Double.Parse(TxtStandartSapma.Text)) + Double.Parse(TxtSinifOrtalamasi.Text)) * 2) - Double.Parse(TxtVizeNotu.Text);
                        if (45 <= Final && Final <= 100)
                        {
                            txtBB.Text = "" + Final;
                            break;
                        }
                        txtBB.Text = "X";
                    }

                    for (double x = 62.0; x <= 66.99; x++)
                    {
                        Final = (((((x - 50.0) / 10.0) * Double.Parse(TxtStandartSapma.Text)) + Double.Parse(TxtSinifOrtalamasi.Text)) * 2) - Double.Parse(TxtVizeNotu.Text);
                        if (45 <= Final && Final <= 100)
                        {
                            txtBA.Text = "" + Final;
                            break;
                        }
                        txtBA.Text = "X";
                    }

                    for (double x = 67.0; x <= 100.0; x++)
                    {
                        Final = (((((x - 50.0) / 10.0) * Double.Parse(TxtStandartSapma.Text)) + Double.Parse(TxtSinifOrtalamasi.Text)) * 2) - Double.Parse(TxtVizeNotu.Text);
                        if (45 <= Final && Final <= 100)
                        {
                            txtAA.Text = "" + Final;
                            break;
                        }
                        txtAA.Text = "X";
                    }
                }

                //Sınıf Durumu Zayıf
                else if (42.5 < Double.Parse(TxtSinifOrtalamasi.Text) && Double.Parse(TxtSinifOrtalamasi.Text) < 47.5)
                {
                    for (double x = 44.0; x <= 48.99; x++)
                    {
                        Final = (((((x - 50.0) / 10.0) * Double.Parse(TxtStandartSapma.Text)) + Double.Parse(TxtSinifOrtalamasi.Text)) * 2) - Double.Parse(TxtVizeNotu.Text);
                        if (45 <= Final && Final <= 100)
                        {
                            txtDC.Text = "" + Final;
                            break;
                        }
                        txtDC.Text = "X";
                    }

                    for (double x = 49.0; x <= 53.99; x++)
                    {
                        Final = (((((x - 50.0) / 10.0) * Double.Parse(TxtStandartSapma.Text)) + Double.Parse(TxtSinifOrtalamasi.Text)) * 2) - Double.Parse(TxtVizeNotu.Text);
                        if (45 <= Final && Final <= 100)
                        {
                            txtCC.Text = "" + Final;
                            break;
                        }
                        txtCC.Text = "X";
                    }

                    for (double x = 54.0; x <= 58.99; x++)
                    {
                        Final = (((((x - 50.0) / 10.0) * Double.Parse(TxtStandartSapma.Text)) + Double.Parse(TxtSinifOrtalamasi.Text)) * 2) - Double.Parse(TxtVizeNotu.Text);
                        if (45 <= Final && Final <= 100)
                        {
                            txtCB.Text = "" + Final;
                            break;
                        }
                        txtCB.Text = "X";
                    }

                    for (double x = 59.0; x <= 63.99; x++)
                    {
                        Final = (((((x - 50.0) / 10.0) * Double.Parse(TxtStandartSapma.Text)) + Double.Parse(TxtSinifOrtalamasi.Text)) * 2) - Double.Parse(TxtVizeNotu.Text);
                        if (45 <= Final && Final <= 100)
                        {
                            txtBB.Text = "" + Final;
                            break;
                        }
                        txtBB.Text = "X";
                    }

                    for (double x = 64.0; x <= 68.99; x++)
                    {
                        Final = (((((x - 50.0) / 10.0) * Double.Parse(TxtStandartSapma.Text)) + Double.Parse(TxtSinifOrtalamasi.Text)) * 2) - Double.Parse(TxtVizeNotu.Text);
                        if (45 <= Final && Final <= 100)
                        {
                            txtBA.Text = "" + Final;
                            break;
                        }
                        txtBA.Text = "X";
                    }

                    for (double x = 69.0; x <= 100.0; x++)
                    {
                        Final = (((((x - 50.0) / 10.0) * Double.Parse(TxtStandartSapma.Text)) + Double.Parse(TxtSinifOrtalamasi.Text)) * 2) - Double.Parse(TxtVizeNotu.Text);
                        if (45 <= Final && Final <= 100)
                        {
                            txtAA.Text = "" + Final;
                            break;
                        }
                        else txtAA.Text = "X";
                    }
                }

                //Sınıf Durumu Kötü
                else if (0 < Double.Parse(TxtSinifOrtalamasi.Text) && Double.Parse(TxtSinifOrtalamasi.Text) <= 42.5)
                {
                    for (double x = 46.0; x <= 50.99; x++)
                    {
                        Final = (((((x - 50.0) / 10.0) * Double.Parse(TxtStandartSapma.Text)) + Double.Parse(TxtSinifOrtalamasi.Text)) * 2) - Double.Parse(TxtVizeNotu.Text);
                        if (45 <= Final && Final <= 100)
                        {
                            txtDC.Text = "" + Final;
                            break;
                        }
                        txtDC.Text = "X";
                    }

                    for (double x = 51.0; x <= 55.99; x++)
                    {
                        Final = (((((x - 50.0) / 10.0) * Double.Parse(TxtStandartSapma.Text)) + Double.Parse(TxtSinifOrtalamasi.Text)) * 2) - Double.Parse(TxtVizeNotu.Text);
                        if (45 <= Final && Final <= 100)
                        {
                            txtCC.Text = "" + Final;
                            break;
                        }
                        txtCC.Text = "X";
                    }

                    for (double x = 56.0; x <= 60.99; x++)
                    {
                        Final = (((((x - 50.0) / 10.0) * Double.Parse(TxtStandartSapma.Text)) + Double.Parse(TxtSinifOrtalamasi.Text)) * 2) - Double.Parse(TxtVizeNotu.Text);
                        if (45 <= Final && Final <= 100)
                        {
                            txtCB.Text = "" + Final;
                            break;
                        }
                        txtCB.Text = "X";
                    }

                    for (double x = 61.0; x <= 65.99; x++)
                    {
                        Final = (((((x - 50.0) / 10.0) * Double.Parse(TxtStandartSapma.Text)) + Double.Parse(TxtSinifOrtalamasi.Text)) * 2) - Double.Parse(TxtVizeNotu.Text);
                        if (45 <= Final && Final <= 100)
                        {
                            txtBB.Text =""+Final;
                            break;
                        }
                        txtBB.Text = "X";
                    }

                    for (double x = 66.0; x <= 70.99; x++)
                    {
                        Final = (((((x - 50.0) / 10.0) * Double.Parse(TxtStandartSapma.Text)) + Double.Parse(TxtSinifOrtalamasi.Text)) * 2) - Double.Parse(TxtVizeNotu.Text);
                        if (45 <= Final && Final <= 100)
                        {
                            txtBA.Text =""+ Final;
                            break;
                        }
                        txtBA.Text = "X";
                    }

                    for (double x = 71.0; x <= 100; x++)
                    {
                        Final = (((((x - 50.0) / 10.0) * Double.Parse(TxtStandartSapma.Text)) + Double.Parse(TxtSinifOrtalamasi.Text)) * 2) - Double.Parse(TxtVizeNotu.Text);
                        if (45 <= Final && Final <= 100)
                        {
                            txtAA.Text = "" + Final;
                            break;
                        }
                        txtAA.Text = "X";
                    }
                }
            }

            //Vize ve Final Notu Girilmişse Kesin Not Hesaplanıyor
            else
            {    
                double T;
                T = (((((Double.Parse(TxtVizeNotu.Text) + Double.Parse(TxtFinalNotu.Text)) / 2) - Double.Parse(TxtSinifOrtalamasi.Text)) / Double.Parse(TxtStandartSapma.Text)) * 10) + 50;

                //Sınıf Düzeyi Mükemmel
                if (70 < Double.Parse(TxtSinifOrtalamasi.Text) && Double.Parse(TxtSinifOrtalamasi.Text) < 80)
                {
                    if (Double.Parse(TxtFinalNotu.Text) < 45) txtAlinanNot.Text = "Ders Notunuz : FF";
                    else if (T < 24) txtAlinanNot.Text = "Ders Notunuz : FF";
                    else if (24 <= T && T <= 28.99) txtAlinanNot.Text = "Ders Notunuz : FD";
                    else if (29 <= T && T <= 33.99) txtAlinanNot.Text = "Ders Notunuz : DD";
                    else if (34 <= T && T <= 38.99) txtAlinanNot.Text = "Ders Notunuz : DC";
                    else if (39 <= T && T <= 43.99) txtAlinanNot.Text = "Ders Notunuz : CC";
                    else if (44 <= T && T <= 48.99) txtAlinanNot.Text = "Ders Notunuz : CB";
                    else if (49 <= T && T <= 53.99) txtAlinanNot.Text = "Ders Notunuz : BB";
                    else if (54 <= T && T <= 58.99) txtAlinanNot.Text = "Ders Notunuz : BA";
                    else if (59 <= T) txtAlinanNot.Text = "Ders Notunuz : AA";
                    

                    for (double x = 34.0; x <= 38.99; x++)
                    {
                        Final = (((((x - 50.0) / 10.0) * Double.Parse(TxtStandartSapma.Text)) + Double.Parse(TxtSinifOrtalamasi.Text)) * 2) - Double.Parse(TxtVizeNotu.Text);
                        if (45 <= Final && Final <= 100)
                        {
                            txtDC.Text = "" + Final;
                            break;
                        }
                        txtDC.Text = "X";
                    }

                    for (double x = 39.0; x <= 43.99; x++)
                    {
                        Final = (((((x - 50.0) / 10.0) * Double.Parse(TxtStandartSapma.Text)) + Double.Parse(TxtSinifOrtalamasi.Text)) * 2) - Double.Parse(TxtVizeNotu.Text);
                        if (45 <= Final && Final <= 100)
                        {
                            txtCC.Text = "" + Final;
                            break;
                        }
                        txtCC.Text = "X";
                    }

                    for (double x = 44.0; x <= 48.99; x++)
                    {
                        Final = (((((x - 50.0) / 10.0) * Double.Parse(TxtStandartSapma.Text)) + Double.Parse(TxtSinifOrtalamasi.Text)) * 2) - Double.Parse(TxtVizeNotu.Text);
                        if (45 <= Final && Final <= 100)
                        {
                            txtCB.Text = "" + Final;
                            break;
                        }
                        txtCB.Text = "X";
                    }

                    for (double x = 49.0; x <= 53.99; x++)
                    {
                        Final = (((((x - 50.0) / 10.0) * Double.Parse(TxtStandartSapma.Text)) + Double.Parse(TxtSinifOrtalamasi.Text)) * 2) - Double.Parse(TxtVizeNotu.Text);
                        if (45 <= Final && Final <= 100)
                        {
                            txtBB.Text = "" + Final;
                            break;
                        }
                        txtBB.Text = "X";
                    }

                    for (double x = 54.0; x <= 58.99; x++)
                    {
                        Final = (((((x - 50.0) / 10.0) * Double.Parse(TxtStandartSapma.Text)) + Double.Parse(TxtSinifOrtalamasi.Text)) * 2) - Double.Parse(TxtVizeNotu.Text);
                        if (45 <= Final && Final <= 100)
                        {
                            txtBA.Text = "" + Final;
                            break;
                        }
                        txtBA.Text = "X";
                    }

                    for (double x = 59.0; x <= 100.0; x++)
                    {
                        Final = (((((x - 50.0) / 10.0) * Double.Parse(TxtStandartSapma.Text)) + Double.Parse(TxtSinifOrtalamasi.Text)) * 2) - Double.Parse(TxtVizeNotu.Text);
                        if (45 <= Final && Final <= 100)
                        {
                            txtAA.Text = "" + Final;
                            break;
                        }
                        txtAA.Text = "X";
                    }

                    txtSinifDuzeyi.Text = "Sınıf : Mükemmel";                    
                }
                
                //Sınıf Düzeyi Çok İyi
                else if (62.5 < Double.Parse(TxtSinifOrtalamasi.Text) && Double.Parse(TxtSinifOrtalamasi.Text) <= 70)
                {
                    if (Double.Parse(TxtFinalNotu.Text) < 45) txtAlinanNot.Text = "Ders Notunuz : FF";
                    else if (T < 26) txtAlinanNot.Text = "Ders Notunuz : FF";
                    else if (26 <= T && T <= 30.99) txtAlinanNot.Text = "Ders Notunuz : FD";
                    else if (31 <= T && T <= 35.99) txtAlinanNot.Text = "Ders Notunuz : DD";
                    else if (36 <= T && T <= 40.99) txtAlinanNot.Text = "Ders Notunuz : DC";
                    else if (41 <= T && T <= 45.99) txtAlinanNot.Text = "Ders Notunuz : CC";
                    else if (46 <= T && T <= 50.99) txtAlinanNot.Text = "Ders Notunuz : CB";
                    else if (51 <= T && T <= 55.99) txtAlinanNot.Text = "Ders Notunuz : BB";
                    else if (56 <= T && T <= 60.99) txtAlinanNot.Text = "Ders Notunuz : BA";
                    else if (61 <= T) txtAlinanNot.Text = "Ders Notunuz : AA";                   

                    for (double x = 36.0; x <= 40.99; x++)
                    {
                        Final = (((((x - 50.0) / 10.0) * Double.Parse(TxtStandartSapma.Text)) + Double.Parse(TxtSinifOrtalamasi.Text)) * 2) - Double.Parse(TxtVizeNotu.Text);
                        if (45 <= Final && Final <= 100)
                        {
                            txtDC.Text = "" + Final;
                            break;
                        }
                        txtDC.Text = "X";
                    }

                    for (double x = 41.0; x <= 45.99; x++)
                    {
                        Final = (((((x - 50.0) / 10.0) * Double.Parse(TxtStandartSapma.Text)) + Double.Parse(TxtSinifOrtalamasi.Text)) * 2) - Double.Parse(TxtVizeNotu.Text);
                        if (45 <= Final && Final <= 100)
                        {
                            txtCC.Text = "" + Final;
                            break;
                        }
                        txtCC.Text = "X";
                    }

                    for (double x = 46.0; x <= 50.99; x++)
                    {
                        Final = (((((x - 50.0) / 10.0) * Double.Parse(TxtStandartSapma.Text)) + Double.Parse(TxtSinifOrtalamasi.Text)) * 2) - Double.Parse(TxtVizeNotu.Text);
                        if (45 <= Final && Final <= 100)
                        {
                            txtCB.Text = "" + Final;
                            break;
                        }
                        txtCB.Text = "X";
                    }

                    for (double x = 51.0; x <= 55.99; x++)
                    {
                        Final = (((((x - 50.0) / 10.0) * Double.Parse(TxtStandartSapma.Text)) + Double.Parse(TxtSinifOrtalamasi.Text)) * 2) - Double.Parse(TxtVizeNotu.Text);
                        if (45 <= Final && Final <= 100)
                        {
                            txtBB.Text = "" + Final;
                            break;
                        }
                        txtBB.Text = "X";
                    }

                    for (double x = 56.0; x <= 60.99; x++)
                    {
                        Final = (((((x - 50.0) / 10.0) * Double.Parse(TxtStandartSapma.Text)) + Double.Parse(TxtSinifOrtalamasi.Text)) * 2) - Double.Parse(TxtVizeNotu.Text);
                        if (45 <= Final && Final <= 100)
                        {
                            txtBA.Text = "" + Final;
                            break;
                        }
                        txtBA.Text = "X";
                    }

                    for (double x = 61.0; x <= 100.0; x++)
                    {
                        Final = (((((x - 50.0) / 10.0) * Double.Parse(TxtStandartSapma.Text)) + Double.Parse(TxtSinifOrtalamasi.Text)) * 2) - Double.Parse(TxtVizeNotu.Text);
                        if (45 <= Final && Final <= 100)
                        {
                            txtAA.Text = "" + Final;
                            break;
                        }
                        txtAA.Text = "X";
                    }

                    txtSinifDuzeyi.Text = "Sınıf : Çok İyi";                   
                }
                //Sınıf Düzeyi İyi
                else if (57.5 < Double.Parse(TxtSinifOrtalamasi.Text) && Double.Parse(TxtSinifOrtalamasi.Text) <= 62.5)
                {
                    if (Double.Parse(TxtFinalNotu.Text) < 45) txtAlinanNot.Text = "Ders Notunuz : FF";
                    else if (T < 28) txtAlinanNot.Text = "Ders Notunuz : FF";
                    else if (28 <= T && T <= 32.99) txtAlinanNot.Text = "Ders Notunuz : FD";
                    else if (33 <= T && T <= 37.99) txtAlinanNot.Text = "Ders Notunuz : DD";
                    else if (38 <= T && T <= 42.99) txtAlinanNot.Text = "Ders Notunuz : DC";
                    else if (43 <= T && T <= 47.99) txtAlinanNot.Text = "Ders Notunuz : CC";
                    else if (48 <= T && T <= 52.99) txtAlinanNot.Text = "Ders Notunuz : CB";
                    else if (53 <= T && T <= 57.99) txtAlinanNot.Text = "Ders Notunuz : BB";
                    else if (58 <= T && T <= 62.99) txtAlinanNot.Text = "Ders Notunuz : BA";
                    else if (63 <= T) txtAlinanNot.Text = "Ders Notunuz : AA";

                    for (double x = 38.0; x <= 42.99; x++)
                    {
                        Final = (((((x - 50.0) / 10.0) * Double.Parse(TxtStandartSapma.Text)) + Double.Parse(TxtSinifOrtalamasi.Text)) * 2) - Double.Parse(TxtVizeNotu.Text);
                        if (45 <= Final && Final <= 100)
                        {
                            txtDC.Text = "" + Final;
                            break;
                        }
                        txtDC.Text = "X";
                    }

                    for (double x = 43.0; x <= 47.99; x++)
                    {
                        Final = (((((x - 50.0) / 10.0) * Double.Parse(TxtStandartSapma.Text)) + Double.Parse(TxtSinifOrtalamasi.Text)) * 2) - Double.Parse(TxtVizeNotu.Text);
                        if (45 <= Final && Final <= 100)
                        {
                            txtCC.Text = "" + Final;
                            break;
                        }
                        txtCC.Text = "X";
                    }

                    for (double x = 48.0; x <= 52.99; x++)
                    {
                        Final = (((((x - 50.0) / 10.0) * Double.Parse(TxtStandartSapma.Text)) + Double.Parse(TxtSinifOrtalamasi.Text)) * 2) - Double.Parse(TxtVizeNotu.Text);
                        if (45 <= Final && Final <= 100)
                        {
                            txtCB.Text = "" + Final;
                            break;
                        }
                        txtCB.Text = "X";
                    }

                    for (double x = 53.0; x <= 57.99; x++)
                    {
                        Final = (((((x - 50.0) / 10.0) * Double.Parse(TxtStandartSapma.Text)) + Double.Parse(TxtSinifOrtalamasi.Text)) * 2) - Double.Parse(TxtVizeNotu.Text);
                        if (45 <= Final && Final <= 100)
                        {
                            txtBB.Text = "" + Final;
                            break;
                        }
                        txtBB.Text = "X";
                    }

                    for (double x = 58.0; x <= 62.99; x++)
                    {
                        Final = (((((x - 50.0) / 10.0) * Double.Parse(TxtStandartSapma.Text)) + Double.Parse(TxtSinifOrtalamasi.Text)) * 2) - Double.Parse(TxtVizeNotu.Text);
                        if (45 <= Final && Final <= 100)
                        {
                            txtBA.Text = "" + Final;
                            break;
                        }
                        txtBA.Text = "X";
                    }

                    for (double x = 63.0; x <= 100.0; x++)
                    {
                        Final = (((((x - 50.0) / 10.0) * Double.Parse(TxtStandartSapma.Text)) + Double.Parse(TxtSinifOrtalamasi.Text)) * 2) - Double.Parse(TxtVizeNotu.Text);
                        if (45 <= Final && Final <= 100)
                        {
                            txtAA.Text = "" + Final;
                            break;
                        }
                        txtAA.Text = "X";
                    }

                    txtSinifDuzeyi.Text = "Sınıf : İyi";
                }
                //Sınıf Düzeyi Ortanın Üstü
                else if (52.5 < Double.Parse(TxtSinifOrtalamasi.Text) && Double.Parse(TxtSinifOrtalamasi.Text) <= 57.5)
                {
                    if (Double.Parse(TxtFinalNotu.Text) < 45) txtAlinanNot.Text = "Ders Notunuz : FF";
                    else if (T < 30) txtAlinanNot.Text = "Ders Notunuz : FF";
                    else if (30 <= T && T <= 34.99) txtAlinanNot.Text = "Ders Notunuz : FD";
                    else if (35 <= T && T <= 39.99) txtAlinanNot.Text = "Ders Notunuz : DD";
                    else if (40 <= T && T <= 44.99) txtAlinanNot.Text = "Ders Notunuz : DC";
                    else if (45 <= T && T <= 49.99) txtAlinanNot.Text = "Ders Notunuz : CC";
                    else if (50 <= T && T <= 54.99) txtAlinanNot.Text = "Ders Notunuz : CB";
                    else if (55 <= T && T <= 59.99) txtAlinanNot.Text = "Ders Notunuz : BB";
                    else if (60 <= T && T <= 64.99) txtAlinanNot.Text = "Ders Notunuz : BA";
                    else if (65 <= T) txtAlinanNot.Text = "Ders Notunuz : AA";
                    else if (Double.Parse(TxtFinalNotu.Text) < 45) txtAlinanNot.Text = "Ders Notunuz : FF";

                    for (double x = 40.0; x <= 44.99; x++)
                    {
                        Final = (((((x - 50.0) / 10.0) * Double.Parse(TxtStandartSapma.Text)) + Double.Parse(TxtSinifOrtalamasi.Text)) * 2) - Double.Parse(TxtVizeNotu.Text);
                        if (45 <= Final && Final <= 100)
                        {
                            txtDC.Text = "" + Final;
                            break;
                        }
                        txtDC.Text = "X";
                    }

                    for (double x = 45.0; x <= 49.99; x++)
                    {
                        Final = (((((x - 50.0) / 10.0) * Double.Parse(TxtStandartSapma.Text)) + Double.Parse(TxtSinifOrtalamasi.Text)) * 2) - Double.Parse(TxtVizeNotu.Text);
                        if (45 <= Final && Final <= 100)
                        {
                            txtCC.Text = "" + Final;
                            break;
                        }
                        txtCC.Text = "X";
                    }

                    for (double x = 50.0; x <= 54.99; x++)
                    {
                        Final = (((((x - 50.0) / 10.0) * Double.Parse(TxtStandartSapma.Text)) + Double.Parse(TxtSinifOrtalamasi.Text)) * 2) - Double.Parse(TxtVizeNotu.Text);
                        if (45 <= Final && Final <= 100)
                        {
                            txtCB.Text = "" + Final;
                            break;
                        }
                        txtCB.Text = "X";
                    }

                    for (double x = 55.0; x <= 59.99; x++)
                    {
                        Final = (((((x - 50.0) / 10.0) * Double.Parse(TxtStandartSapma.Text)) + Double.Parse(TxtSinifOrtalamasi.Text)) * 2) - Double.Parse(TxtVizeNotu.Text);
                        if (45 <= Final && Final <= 100)
                        {
                            txtBB.Text = "" + Final;
                            break;
                        }
                        txtBB.Text = "X";
                    }

                    for (double x = 60.0; x <= 64.99; x++)
                    {
                        Final = (((((x - 50.0) / 10.0) * Double.Parse(TxtStandartSapma.Text)) + Double.Parse(TxtSinifOrtalamasi.Text)) * 2) - Double.Parse(TxtVizeNotu.Text);
                        if (45 <= Final && Final <= 100)
                        {
                            txtBA.Text = "" + Final;
                            break;
                        }
                        txtBA.Text = "X";
                    }

                    for (double x = 65.0; x <= 100.0; x++)
                    {
                        Final = (((((x - 50.0) / 10.0) * Double.Parse(TxtStandartSapma.Text)) + Double.Parse(TxtSinifOrtalamasi.Text)) * 2) - Double.Parse(TxtVizeNotu.Text);
                        if (45 <= Final && Final <= 100)
                        {
                            txtAA.Text = "" + Final;
                            break;
                        }
                        txtAA.Text = "X";
                    }

                    txtSinifDuzeyi.Text = "Sınıf : Orta Üstü";
                }
                //Sınıf Düzeyi Orta
                else if (47.5 < Double.Parse(TxtSinifOrtalamasi.Text) && Double.Parse(TxtSinifOrtalamasi.Text) <= 52.5)
                {
                    if (Double.Parse(TxtFinalNotu.Text) < 45) txtAlinanNot.Text = "Ders Notunuz : FF";
                    else if (T < 32) txtAlinanNot.Text = "Ders Notunuz : FF";
                    else if (32 <= T && T <= 36.99) txtAlinanNot.Text = "Ders Notunuz : FD";
                    else if (37 <= T && T <= 41.99) txtAlinanNot.Text = "Ders Notunuz : DD";
                    else if (42 <= T && T <= 46.99) txtAlinanNot.Text = "Ders Notunuz : DC";
                    else if (47 <= T && T <= 51.99) txtAlinanNot.Text = "Ders Notunuz : CC";
                    else if (52 <= T && T <= 56.99) txtAlinanNot.Text = "Ders Notunuz : CB";
                    else if (57 <= T && T <= 61.99) txtAlinanNot.Text = "Ders Notunuz : BB";
                    else if (62 <= T && T <= 66.99) txtAlinanNot.Text = "Ders Notunuz : BA";
                    else if (67 <= T) txtAlinanNot.Text = "Ders Notunuz : AA";
                    else if (Double.Parse(TxtFinalNotu.Text) < 45) txtAlinanNot.Text = "Ders Notunuz : FF";

                    for (double x = 42.0; x <= 46.99; x++)
                    {
                        Final = (((((x - 50.0) / 10.0) * Double.Parse(TxtStandartSapma.Text)) + Double.Parse(TxtSinifOrtalamasi.Text)) * 2) - Double.Parse(TxtVizeNotu.Text);
                        if (45 <= Final && Final <= 100)
                        {
                            txtDC.Text = "" + Final;
                            break;
                        }
                        txtDC.Text = "X";
                    }

                    for (double x = 47.0; x <= 51.99; x++)
                    {
                        Final = (((((x - 50.0) / 10.0) * Double.Parse(TxtStandartSapma.Text)) + Double.Parse(TxtSinifOrtalamasi.Text)) * 2) - Double.Parse(TxtVizeNotu.Text);
                        if (45 <= Final && Final <= 100)
                        {
                            txtCC.Text = "" + Final;
                            break;
                        }
                        txtCC.Text = "X";
                    }

                    for (double x = 52.0; x <= 56.99; x++)
                    {
                        Final = (((((x - 50.0) / 10.0) * Double.Parse(TxtStandartSapma.Text)) + Double.Parse(TxtSinifOrtalamasi.Text)) * 2) - Double.Parse(TxtVizeNotu.Text);
                        if (45 <= Final && Final <= 100)
                        {
                            txtCB.Text = "" + Final;
                            break;
                        }
                        txtCB.Text = "X";
                    }

                    for (double x = 57.0; x <= 61.99; x++)
                    {
                        Final = (((((x- 50.0) / 10.0) * Double.Parse(TxtStandartSapma.Text)) + Double.Parse(TxtSinifOrtalamasi.Text)) * 2) - Double.Parse(TxtVizeNotu.Text);
                        if (45 <= Final && Final <= 100)
                        {
                            txtBB.Text = "" + Final;
                            break;
                        }
                        txtBB.Text = "X";
                    }

                    for (double x = 62.0; x <= 66.99; x++)
                    {
                        Final = (((((x - 50.0) / 10.0) * Double.Parse(TxtStandartSapma.Text)) + Double.Parse(TxtSinifOrtalamasi.Text)) * 2) - Double.Parse(TxtVizeNotu.Text);
                        if (45 <= Final && Final <= 100)
                        {
                            txtBA.Text = "" + Final;
                            break;
                        }
                        txtBA.Text = "X";
                    }

                    for (double x = 67.0; x <= 100.0; x++)
                    {
                        Final = (((((x - 50.0) / 10.0) * Double.Parse(TxtStandartSapma.Text)) + Double.Parse(TxtSinifOrtalamasi.Text)) * 2) - Double.Parse(TxtVizeNotu.Text);
                        if (45 <= Final && Final <= 100)
                        {
                            txtAA.Text = "" + Final;
                            break;
                        }
                        txtAA.Text = "X";
                    }

                    txtSinifDuzeyi.Text = "Sınıf : Orta";
                }
                //Sınıf Düzeyi Zayıf
                else if (42.5 < Double.Parse(TxtSinifOrtalamasi.Text) && Double.Parse(TxtSinifOrtalamasi.Text) <= 47.5)
                {
                    if (Double.Parse(TxtFinalNotu.Text) < 45) txtAlinanNot.Text = "Ders Notunuz : FF";
                    else if (T < 34) txtAlinanNot.Text = "Ders Notunuz : FF";
                    else if (34 <= T && T <= 38.99) txtAlinanNot.Text = "Ders Notunuz : FD";
                    else if (39 <= T && T <= 43.99) txtAlinanNot.Text = "Ders Notunuz : DD";
                    else if (44 <= T && T <= 48.99) txtAlinanNot.Text = "Ders Notunuz : DC";
                    else if (49 <= T && T <= 53.99) txtAlinanNot.Text = "Ders Notunuz : CC";
                    else if (54 <= T && T <= 58.99) txtAlinanNot.Text = "Ders Notunuz : CB";
                    else if (59 <= T && T <= 63.99) txtAlinanNot.Text = "Ders Notunuz : BB";
                    else if (64 <= T && T <= 68.99) txtAlinanNot.Text = "Ders Notunuz : BA";
                    else if (69 <= T) txtAlinanNot.Text = "Ders Notunuz : AA";
                    

                    for (double x = 44.0; x <= 48.99; x++)
                    {
                        Final = (((((x - 50.0) / 10.0) * Double.Parse(TxtStandartSapma.Text)) + Double.Parse(TxtSinifOrtalamasi.Text)) * 2) - Double.Parse(TxtVizeNotu.Text);
                        if (45 <= Final && Final <= 100)
                        {
                            txtDC.Text = "" + Final;
                            break;
                        }
                        txtDC.Text = "X";
                    }

                    for (double x = 49.0; x <= 53.99; x++)
                    {
                        Final = (((((x - 50.0) / 10.0) * Double.Parse(TxtStandartSapma.Text)) + Double.Parse(TxtSinifOrtalamasi.Text)) * 2) - Double.Parse(TxtVizeNotu.Text);
                        if (45 <= Final && Final <= 100)
                        {
                            txtCC.Text = "" + Final;
                            break;
                        }
                        txtCC.Text = "X";
                    }

                    for (double x = 54.0; x <= 58.99; x++)
                    {
                        Final = (((((x - 50.0) / 10.0) * Double.Parse(TxtStandartSapma.Text)) + Double.Parse(TxtSinifOrtalamasi.Text)) * 2) - Double.Parse(TxtVizeNotu.Text);
                        if (45 <= Final && Final <= 100)
                        {
                            txtCB.Text = "" + Final;
                            break;
                        }
                        txtCB.Text = "X";
                    }

                    for (double x = 59.0; x <= 63.99; x++)
                    {
                        Final = (((((x - 50.0) / 10.0) * Double.Parse(TxtStandartSapma.Text)) + Double.Parse(TxtSinifOrtalamasi.Text)) * 2) - Double.Parse(TxtVizeNotu.Text);
                        if (45 <= Final && Final <= 100)
                        {
                            txtBB.Text = "" + Final;
                            break;
                        }
                        txtBB.Text = "X";
                    }

                    for (double x = 64.0; x <= 68.99; x++)
                    {
                        Final = (((((x - 50.0) / 10.0) * Double.Parse(TxtStandartSapma.Text)) + Double.Parse(TxtSinifOrtalamasi.Text)) * 2) - Double.Parse(TxtVizeNotu.Text);
                        if (45 <= Final && Final <= 100)
                        {
                            txtBA.Text = "" + Final;
                            break;
                        }
                        txtBA.Text = "X";
                    }

                    for (double x = 69.0; x <= 100.0; x++)
                    {
                        Final = (((((x - 50.0) / 10.0) * Double.Parse(TxtStandartSapma.Text)) + Double.Parse(TxtSinifOrtalamasi.Text)) * 2) - Double.Parse(TxtVizeNotu.Text);
                        if (45 <= Final && Final <= 100)
                        {
                            txtAA.Text = "" + Final;
                            break;
                        }
                        txtAA.Text = "X";
                    }

                    txtSinifDuzeyi.Text = "Sınıf : Zayıf";
                }
                //Sınıf Düzeyi Kötü
                else if (0 < Double.Parse(TxtSinifOrtalamasi.Text) && Double.Parse(TxtSinifOrtalamasi.Text) <= 42.5)
                {
                    if (Double.Parse(TxtFinalNotu.Text) < 45) txtAlinanNot.Text = "Ders Notunuz : FF";
                    else if (T < 36) txtAlinanNot.Text = "Ders Notunuz : FF";
                    else if (36 <= T && T <= 40.99) txtAlinanNot.Text = "Ders Notunuz : FD";
                    else if (41 <= T && T <= 45.99) txtAlinanNot.Text = "Ders Notunuz : DD";
                    else if (46 <= T && T <= 50.99) txtAlinanNot.Text = "Ders Notunuz : DC";
                    else if (51 <= T && T <= 55.99) txtAlinanNot.Text = "Ders Notunuz : CC";
                    else if (56 <= T && T <= 60.99) txtAlinanNot.Text = "Ders Notunuz : CB";
                    else if (61 <= T && T <= 65.99) txtAlinanNot.Text = "Ders Notunuz : BB";
                    else if (66 <= T && T <= 70.99) txtAlinanNot.Text = "Ders Notunuz : BA";
                    else if (71 <= T) txtAlinanNot.Text = "Ders Notunuz : AA";
                    

                    for (double x = 46.0; x <= 50.99; x++)
                    {
                        Final = (((((x - 50.0) / 10.0) * Double.Parse(TxtStandartSapma.Text)) + Double.Parse(TxtSinifOrtalamasi.Text)) * 2) - Double.Parse(TxtVizeNotu.Text);
                        if (45 <= Final && Final <= 100)
                        {
                            txtDC.Text = "" + Final;
                            break;
                        }
                        txtDC.Text = "X";
                    }

                    for (double x = 51.0; x <= 55.99; x++ )
                    {
                        Final = (((((x - 50.0) / 10.0) * Double.Parse(TxtStandartSapma.Text)) + Double.Parse(TxtSinifOrtalamasi.Text)) * 2) - Double.Parse(TxtVizeNotu.Text);
                        if (45 <= Final && Final <= 100)
                        {
                            txtCC.Text = "" + Final;
                            break;
                        }
                        txtCC.Text = "X";
                    }

                    for (double x = 56.0; x <= 60.99; x++)
                    {
                        Final = (((((x - 50.0) / 10.0) * Double.Parse(TxtStandartSapma.Text)) + Double.Parse(TxtSinifOrtalamasi.Text)) * 2) - Double.Parse(TxtVizeNotu.Text);
                        if (45 <= Final && Final <= 100)
                        {
                            txtCB.Text = "" + Final;
                            break;
                        }
                        txtCB.Text = "X";
                    }

                    for (double x = 61.0; x <= 65.99; x++)
                    {
                        Final = (((((x - 50.0) / 10.0) * Double.Parse(TxtStandartSapma.Text)) + Double.Parse(TxtSinifOrtalamasi.Text)) * 2) - Double.Parse(TxtVizeNotu.Text);
                        if (45 <= Final && Final <= 100)
                        {
                            txtBB.Text = "" + Final;
                            break;
                        }
                        txtBB.Text = "X";
                    }

                    for (double x = 66.0; x <= 70.99; x++)
                    {
                        Final = (((((x - 50.0) / 10.0) * Double.Parse(TxtStandartSapma.Text)) + Double.Parse(TxtSinifOrtalamasi.Text)) * 2) - Double.Parse(TxtVizeNotu.Text);
                        if (45 <= Final && Final <= 100)
                        {
                            txtBA.Text = "" + Final;
                            break;
                        }
                        txtBA.Text = "X";
                    }

                    for (double x = 71.0; x <= 100; x++)
                    {
                        Final = (((((x - 50.0) / 10.0) * Double.Parse(TxtStandartSapma.Text)) + Double.Parse(TxtSinifOrtalamasi.Text)) * 2) - Double.Parse(TxtVizeNotu.Text);
                        if (45 <= Final && Final <= 100)
                        {
                            txtAA.Text = "" + Final;
                            break;
                        }
                        txtAA.Text = "X";
                    }

                    txtSinifDuzeyi.Text = "Sınıf : Kötü";
                }
            }
        }

        public void tablo3()
        {
            double T;
            double Final;
            

            //Vize Notuna Girilmiş, Final Aralıkları Belirleniyor
            if (TxtFinalNotu.Text == "")
            {
                for (double x = 90.0; x <= 100.0; x++)
                {
                    Final = (2 * x) - Double.Parse(TxtVizeNotu.Text);
                    if (45 <= Final && Final <= 100)
                    {
                        txtAA.Text = "" + Final;
                        break;
                    }
                    txtAA.Text = "X";
                }

                for (double x = 80.0; x <= 89.0; x++)
                {
                    Final = (2 * x) - Double.Parse(TxtVizeNotu.Text);
                    if (45 <= Final && Final <= 100)
                    {
                        txtBA.Text = "" + Final;
                        break;
                    }
                    txtBA.Text = "X";
                }

                for (double x = 75.0; x <= 79.0; x++)
                {
                    Final = (2 * x) - Double.Parse(TxtVizeNotu.Text);
                    if (45 <= Final && Final <= 100)
                    {
                        txtBB.Text = "" + Final;
                        break;
                    }
                    txtBB.Text = "X";
                }
                for (double x = 70.0; x <= 74.0; x++)
                {
                    Final = (2 * x) - Double.Parse(TxtVizeNotu.Text);
                    if (45 <= Final && Final <= 100)
                    {
                        txtCB.Text = "" + Final;
                        break;
                    }
                    txtCB.Text = "X";
                }
                for (double x = 60.0; x <= 69.0; x++)
                {
                    Final = (2 * x) - Double.Parse(TxtVizeNotu.Text);
                    if (45 <= Final && Final <= 100)
                    {
                        txtCC.Text = "" + Final;
                        break;
                    }
                    txtCC.Text = "X";
                }
                for (double x = 50.0; x <= 59.0; x++)
                {
                    Final = (2 * x) - Double.Parse(TxtVizeNotu.Text);
                    if (45 <= Final && Final <= 100)
                    {
                        txtDC.Text = "" + Final;
                        break;
                    }
                    txtDC.Text = "X";
                }
            }

            else
            {
                T = ((Double.Parse(TxtVizeNotu.Text) + Double.Parse(TxtFinalNotu.Text)) / 2);

                if (Double.Parse(TxtFinalNotu.Text) < 45) txtAlinanNot.Text = "Ders Notunuz : FF";
                else if (T <= 29) txtAlinanNot.Text = "Ders Notunuz : FF";
                else if (30 <= T && T <= 39) txtAlinanNot.Text = "Ders Notunuz : FD";
                else if (40 <= T && T <= 49) txtAlinanNot.Text = "Ders Notunuz : DD";
                else if (50 <= T && T <= 59) txtAlinanNot.Text = "Ders Notunuz : DC";
                else if (60 <= T && T <= 69) txtAlinanNot.Text = "Ders Notunuz : CC";
                else if (70 <= T && T <= 74) txtAlinanNot.Text = "Ders Notunuz : CB";
                else if (75 <= T && T <= 79) txtAlinanNot.Text = "Ders Notunuz : BB";
                else if (80 <= T && T <= 89) txtAlinanNot.Text = "Ders Notunuz : BA";
                else if (90 <= T && T <= 100) txtAlinanNot.Text = "Ders Notunuz : AA";
                

                for (double x = 90.0; x <= 100.0; x++)
                {
                    Final = (2 * x) - Double.Parse(TxtVizeNotu.Text);
                    if (45 <= Final && Final <= 100)
                    {
                        txtAA.Text = "" + Final;
                        break;
                    }
                    txtAA.Text = "X";
                }

                for (double x = 80.0; x <= 89.0; x++)
                {
                    Final = (2 * x) - Double.Parse(TxtVizeNotu.Text);
                    if (45 <= Final && Final <= 100)
                    {
                        txtBA.Text = "" + Final;
                        break;
                    }
                    txtBA.Text = "X";
                }

                for (double x = 75.0; x <= 79.0; x++)
                {
                    Final = (2 * x) - Double.Parse(TxtVizeNotu.Text);
                    if (45 <= Final && Final <= 100)
                    {
                        txtBB.Text = "" + Final;
                        break;
                    }
                    txtBB.Text = "X";
                }
                for (double x = 70.0; x <= 74.0; x++)
                {
                    Final = (2 * x) - Double.Parse(TxtVizeNotu.Text);
                    if (45 <= Final && Final <= 100)
                    {
                        txtCB.Text = "" + Final;
                        break;
                    }
                    txtCB.Text = "X";
                }
                for (double x = 60.0; x <= 69.0; x++)
                {
                    Final = (2 * x) - Double.Parse(TxtVizeNotu.Text);
                    if (45 <= Final && Final <= 100)
                    {
                        txtCC.Text = "" + Final;
                        break;
                    }
                    txtCC.Text = "X";
                }
                for (double x = 50.0; x <= 59.0; x++)
                {
                    Final = (2 * x) - Double.Parse(TxtVizeNotu.Text);
                    if (45 <= Final && Final <= 100)
                    {
                        txtDC.Text = "" + Final;
                        break;
                    }
                    txtDC.Text = "X";
                }
            }           
        }



        //AppBar Kodlamaları
        private void rateButton_Click(object sender, RoutedEventArgs e)
        {
            AskForAppRating();
        }
        private async Task AskForAppRating()
        {
            if (!CheckInternetConnectivity())
                return;

            MessageDialog msg;
            bool retry = false;
            msg = new MessageDialog("Uygulamayı mağazada değerlendirerek geliştirme sürecine destek olmak ister misiniz?");
            msg.Commands.Add(new UICommand("Oyla", new UICommandInvokedHandler(this.OpenStoreRating)));
            msg.Commands.Add(new UICommand("Şimdi Değil"));
            msg.DefaultCommandIndex = 0;
            msg.CancelCommandIndex = 1;
            await msg.ShowAsync();

            while (retry)
            {
                try { await msg.ShowAsync(); }
                catch (Exception ex) { }
            }

        }

        //Mağazaya yönlendirmeden önce internet bağlantısı kontrolü yapılan kısım
        public static bool CheckInternetConnectivity()
        {
            var internetProfile = NetworkInformation.GetInternetConnectionProfile();
            if (internetProfile == null)
                return false;

            return (internetProfile.GetNetworkConnectivityLevel() == NetworkConnectivityLevel.InternetAccess);
        }

        // Launches the store app, using the application storeID
        private async void OpenStoreRating(IUICommand command)
        {
            await Windows.System.Launcher.LaunchUriAsync(new Uri("ms-windows-store:reviewapp?appid=a2cd9e60-0ea5-484f-b4e9-ee674b0f264c"));
        }

        private void hakkinda_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(hakkinda));
        }

        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Exit();
        }

    } 
}
