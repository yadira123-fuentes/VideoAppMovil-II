using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoApp.Views;
using Xamarin.Forms;

namespace PhotoApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void btnAgregar_Clicked(object sender, EventArgs e)
        {
            var paginaCrear = new PhotosView();

            await Navigation.PushAsync(paginaCrear);
        }

        private async void btnSwipe_Clicked(object sender, EventArgs e)
        {
            var paginaLista = new VistaListaVIdeos();

            await Navigation.PushAsync(paginaLista);
        }
    }
}
