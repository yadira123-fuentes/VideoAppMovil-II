using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using PhotoApp.Views;
using PhotoApp.Models;
using System.IO;

namespace PhotoApp

{
    public partial class App : Application
    {

        static db database;
        public static db BaseDatos
        {
            get
            {
                if (database == null)
                {
                    database = new db(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Mydatabase.db3"));
                }

                return database;
            }


        }

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
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
