using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TTT
{

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
         Grid gr , ngr;
        readonly Label lbl;
        Image b;
        Button uus_mang, reglid;
        public bool esimene;
        int tulemus = -1;
        int[,] Tulemused = new int[3, 3];
        public MainPage()
        {
            lbl = new Label
            {
                TextColor = Color.Lavender,
                FontSize = 25,
                Text = " Trips_traps_trull",
            };
            gr = new Grid
            {

                VerticalOptions = LayoutOptions.FillAndExpand,
                BackgroundColor = Color.White,
                RowDefinitions =
                {

                    new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
                    new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
                    new RowDefinition { Height = new GridLength(1, GridUnitType.Star) }
                },
                ColumnDefinitions =
                {

                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) }
                },
            };
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    b=new Image();
                    gr.Children.Add(b,j, i);
                    TapGestureRecognizer tap = new TapGestureRecognizer();
                    tap.Tapped += Tap_Tapped;
                    b.GestureRecognizers.Add(tap);
                }
            }
           // gr.Children.Add(gr, 0, 0);

            Reglid();
            reglid = new Button()
            {
                Text = "Reglid"

            };
            reglid.Clicked += Reglid_Clicked;
            Content = gr;
            gr.Children.Add(reglid, 0, 4);

            Uus_mang();
            uus_mang = new Button()
            {
                Text = "Uus mäng"
            };
            gr.Children.Add(uus_mang, 0, 3);
            uus_mang.Clicked += Uus_mang_Clicked;
            Content = gr;
            
        }
        private void Uus_mang_Clicked(object sender, EventArgs e)
        {
            Uus_mang();
        }
        public async void Kes_on_esimene()
        {
            string esimene_valik = await DisplayPromptAsync("Kes on esimene?", "Tee valiku X-1 või 0-2", initialValue: "1", maxLength: 1, keyboard: Keyboard.Numeric);
            if (esimene_valik == "1")
            {
                esimene = true;
            }
            else
            {
                esimene = false;
            }
        }
        public async void Uus_mang()
        {
            bool uus = await DisplayAlert("Uus mäng", "Kas tahad uus mäng?", "Jah!", "Ei!");
            if (uus)
            {
                Kes_on_esimene();
                Tulemused = new int[3, 3];
                tulemus = -1;
                ngr = new Grid
                {
                    RowDefinitions =
                {

                    new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
                    new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
                    new RowDefinition { Height = new GridLength(1, GridUnitType.Star) }
                },
                    ColumnDefinitions =
                {
                   new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                   new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                   new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) }

                }
                };
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        ngr.Children.Add(b, j, i);
                        TapGestureRecognizer tap = new TapGestureRecognizer();
                        tap.Tapped += Tap_Tapped;
                        b.GestureRecognizers.Add(tap);
                    }
                }
                //gr.Children.Add(ngr, 0, 0);
            }

        }
        private void Reglid_Clicked(object sender, EventArgs e)
        {
            Reglid();
        }
        public void Reglid()
        {
            DisplayAlert("Reeglid", "Mängijad panevad kordamööda väljaku vabadele lahtritele 3×3 märke (üks on alati ristid, teine ​​nullid). Võidab see, kes esimesena reastab 3 oma tükki vertikaalselt, horisontaalselt või suurel diagonaalil. " , "Jah!");
        }
        public int Kontroll()
        {
            //esimene inimene
            if (Tulemused[0, 0] == 1 && Tulemused[1, 0] == 1 && Tulemused[2, 0] == 1 || Tulemused[0, 1] == 1 && Tulemused[1, 1] == 1 && Tulemused[2, 1] == 1 || Tulemused[0, 2] == 1 && Tulemused[1, 2] == 1 && Tulemused[2, 2] == 1)
            {
                tulemus = 1;
            }
            else if (Tulemused[0, 0] == 1 && Tulemused[0, 1] == 1 && Tulemused[0, 2] == 1 || Tulemused[1, 0] == 1 && Tulemused[1, 1] == 1 && Tulemused[1, 2] == 1 || Tulemused[2, 0] == 1 && Tulemused[2, 1] == 1 && Tulemused[2, 2] == 1)
            {
                tulemus = 1;
            }
            else if (Tulemused[0, 0] == 1 && Tulemused[1, 1] == 1 && Tulemused[2, 2] == 1 || Tulemused[0, 2] == 1 && Tulemused[1, 1] == 1 && Tulemused[2, 0] == 1)
            {
                tulemus = 1;
            }
            //teine inimene
            else if (Tulemused[0, 0] == 2 && Tulemused[1, 0] == 2 && Tulemused[2, 0] == 2 || Tulemused[0, 1] == 2 && Tulemused[1, 1] == 2 && Tulemused[2, 1] == 2 || Tulemused[0, 2] == 2 && Tulemused[1, 2] == 2 && Tulemused[2, 2] == 2)
            {
                tulemus = 2;
            }
            else if (Tulemused[0, 0] == 2 && Tulemused[0, 1] == 2 && Tulemused[0, 2] == 2 || Tulemused[1, 0] == 2 && Tulemused[1, 1] == 2 && Tulemused[1, 2] == 2 || Tulemused[2, 0] == 2 && Tulemused[2, 1] == 2 && Tulemused[2, 2] == 2)
            {
                tulemus = 2;
            }
            else if (Tulemused[0, 0] == 2 && Tulemused[1, 1] == 2 && Tulemused[2, 2] == 2 || Tulemused[0, 2] == 2 && Tulemused[1, 1] == 2 && Tulemused[2, 0] == 2)
            {
                tulemus = 2;
            }
            else if (Tulemused[0, 0] == 1)
            {
                tulemus = 3;
            }
            else
            {
                tulemus = -1;
            }
            return tulemus;
        }
        public void Lopp()
        {
            tulemus = Kontroll();
            if (tulemus == 1)
            {
                DisplayAlert("Võit", "Sa oled võitja!", "Ok");
            }
            else if (tulemus == 2)
            {
                DisplayAlert("Võit", "Sinu sõber on võitja!", "Ok");
            }
            else if (tulemus == 3)
            {
                DisplayAlert("Ei keegi ei on võit", "Hea mäng sõprad", "Ok");
            }
        }
        private void Tap_Tapped(object sender, EventArgs e)
        {
            var b = (Image)sender;
            var r = Grid.GetRow(b);
            var c = Grid.GetColumn(b);
            if (esimene == true)
            {
                b.Source = ImageSource.FromFile("x.png");
                esimene = false;
                Tulemused[r, c] = 1;
            }
            else
            {
                b.Source =ImageSource.FromFile("o.png");
                esimene = true;
                Tulemused[r, c] = 2;
            }
            gr.Children.Add(b, c, r);
            Lopp();
        }
    }
}
