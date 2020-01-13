using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using RecordApp.Pages;

//[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace RecordApp
{
    public partial class App : Application
    {
        static ItemDatabase database;

        public App()
        {
            InitializeComponent();
            
            var main = new NavigationPage(new TaskList())
            {
                //BarBackgroundColor = (Color)App.Current.Resources["colorIvory"],
                BarTextColor = Color.White
            };

            MainPage = main;
        }

        public static ItemDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new ItemDatabase();
                }
                return database;
            }
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
