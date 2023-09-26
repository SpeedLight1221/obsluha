using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace obsluhovač
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<string>[] recepty = new List<string>[6];
        public MainWindow()
        {
            InitializeComponent();
            recepty[0] = new List<string> { "maly", "kafe" };
            recepty[1] = new List<string> { "stredni", "kafe", "slehacka" };
            recepty[2] = new List<string> { "stredni", "kafe", "mleko" };
            recepty[3] = new List<string> { "stredni", "kafe", "mleko", "pena" };
            recepty[4] = new List<string> { "velky", "kafe", "mleko", "pena" };
            recepty[5] = new List<string> { "sklenice", "kafe", "mleko", "led" };


            foreach (List<string> item in recepty)
            {
                item.Sort();
            }




        }
        int naPriprave = 0;

        //100,119
        List<string> PripravaList = new List<string>();
        private void Surovina_click(object sender, MouseButtonEventArgs e)
        {
            if (naPriprave == 6) { return; }


            Image sur = new Image()
            {
                Source = new BitmapImage(new Uri("img/suroviny-" + (sender as Label).Name + ".png", UriKind.Relative))
            };
            Grid.SetColumn(sur, naPriprave % 3);
            Grid.SetRow(sur, naPriprave / 3);
            PripravaList.Add((sender as Label).Name);
            priprava.Children.Add(sur);
            naPriprave++;
        }

        bool hrnekVKavovaru = false;
        Image hrnek;
        private void Hrnek_click(object sender, MouseButtonEventArgs e)
        {

            if (hrnekVKavovaru) { return; }

            hrnek = new Image()
            {
                Source = (sender as Image).Source,
                Margin = new Thickness(100, 120, 0, 0),
                VerticalAlignment = VerticalAlignment.Top,
                HorizontalAlignment = HorizontalAlignment.Left,
                Height = 40,
                Width = 40,

            };
            PripravaList.Add((sender as Image).Name);
            Kavovar.Children.Add(hrnek);
            hrnekVKavovaru = true;
        }


        private void UvarKafe(object sender, MouseButtonEventArgs e)
        {
            bool nasel = true;

            priprava.Children.Clear();
            naPriprave = 0;
            Kavovar.Children.Remove(hrnek);
            hrnekVKavovaru = false;

            PripravaList.Sort();



            for (int recept = 0; recept < 6; recept++)
            {
                nasel = true;
                if (recepty[recept].Count != PripravaList.Count)
                {
                    continue;
                }


                for (int i = 0; i < PripravaList.Count; i++)
                {
                    if (PripravaList[i] != recepty[recept][i])
                    {
                        nasel = false;
                        break;
                    }
                }
                Image kafe = new Image()
                {
                    Margin = new Thickness(0),
                    VerticalAlignment = VerticalAlignment.Center,
                    HorizontalAlignment = HorizontalAlignment.Left,
                    Source = new BitmapImage(new Uri("obr/nezname.png", UriKind.Relative))
                };
                if (nasel)
                {
                    //kafe na pas

                    switch (recept)
                    {
                        case 0:
                            kafe.Source = new BitmapImage(new Uri("obr/kafe-male_espresso.png", UriKind.Relative));
                            break;
                        case 1:
                            kafe.Source = new BitmapImage(new Uri("obr/kafe-espresso_s_mlekem.png", UriKind.Relative));
                            break;
                        case 2:
                            kafe.Source = new BitmapImage(new Uri("obr/kafe-espresso_se_slehackou.png", UriKind.Relative));
                            break;
                        case 3:
                            kafe.Source = new BitmapImage(new Uri("obr/kafe-espresso_macchiato.png", UriKind.Relative));
                            break;
                        case 4:
                            kafe.Source = new BitmapImage(new Uri("obr/kafe-capuccino.png", UriKind.Relative));
                            break;
                        case 5:
                            kafe.Source = new BitmapImage(new Uri("obr/kafe-ledova_kava.png", UriKind.Relative));
                            break;

                    }

                  
                }
                kafe = new Image()
                {
                    Margin = new Thickness(0),
                    VerticalAlignment = VerticalAlignment.Center,
                    HorizontalAlignment = HorizontalAlignment.Left,
                    Source = new BitmapImage(new Uri("obr/nezname.png", UriKind.Relative))
                };
                pas.Children.Add(kafe); 
            }


        }
    }
}
