using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
namespace HelloXamarin
{
	public partial class App : Application
	{
        private Entry sy�tekentt�;
        private Label arvauksenTulosLabel;
        private int oikeaLuku;
        private int arvaustenM��r� = 0;
        private int maxLuku = 100;
        //private ListView listaus;

        public App ()
		{
			InitializeComponent();

            Random rnd = new Random();
            oikeaLuku = rnd.Next(1, maxLuku + 1);

            //Painonapin alustus
            Button arvaaNappi = new Button();
            arvaaNappi.Text = "Arvaa luku v�lilt� 1-" + maxLuku;
            arvaaNappi.Clicked += ArvaaNappi_Clicked;

            sy�tekentt� = new Entry
            {
                Keyboard = Keyboard.Numeric,
                Text = ""
            };

            arvauksenTulosLabel = new Label();
            arvauksenTulosLabel.Text = "";

            //MainPage = new MainPage();

            MainPage = new ContentPage
            {
                Content = new StackLayout
                {
                    VerticalOptions = LayoutOptions.Center,
                    Children =
                    {
                        new Label
                        {
                            HorizontalTextAlignment = TextAlignment.Center,
                            Text = "Arvaa luku -peli",
                            TextColor = Color.Red
                        },
                        new Label
                        {
                            HorizontalTextAlignment = TextAlignment.Center,
                            Text = "Versio 0.1",
                            TextColor = Color.CadetBlue
                        },
                        sy�tekentt�,
                        arvaaNappi,
                        arvauksenTulosLabel
                    }
                }
            };
        }

        private void ArvaaNappi_Clicked(object sender, EventArgs e)
        {
            int arvaus = int.Parse(sy�tekentt�.Text);
            if (arvaus < oikeaLuku)
            {
                arvauksenTulosLabel.Text = "Arvasit " + arvaus +". Oikea luku on suurempi.";
                arvaustenM��r�++;
            }
            else if (arvaus > oikeaLuku)
            {
                arvauksenTulosLabel.Text = "Arvasit " + arvaus + ". Oikea luku on pienempi.";
                arvaustenM��r�++;
            }
            else if (arvaus == oikeaLuku)
            {
                arvauksenTulosLabel.Text = "Arvasit oikein! K�ytit " + arvaustenM��r� + " arvausta. Otetaan uusi peli.";
                arvaustenM��r� = 0;
                Random rnd = new Random();
                oikeaLuku = rnd.Next(1, maxLuku + 1);
            }
        }

        protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
