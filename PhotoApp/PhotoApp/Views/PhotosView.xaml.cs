using PhotoApp.Models;
using Plugin.Media;
using SQLite;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PhotoApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PhotosView : ContentPage
    {
        readonly string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Mydatabase.db3");
        string rutaDeVideo;
        public PhotosView()
        {
            InitializeComponent();
            btnvideo.Clicked += Btnvideo_Clicked;
        }

        private async void Btnvideo_Clicked(object sender, EventArgs e)
        {
            try
            {
                await CrossMedia.Current.Initialize();

                if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
                {
                    await DisplayAlert("No hay camara", "No se deteca la camara.", "Ok");
                    return;
                }

                var file = await CrossMedia.Current.TakeVideoAsync(new Plugin.Media.Abstractions.StoreVideoOptions
                {
                    Name = "video.mp4",
                    Directory = "DefaultVideos",
                });

                if (file == null)
                    return;

                await DisplayAlert("Video Recorded", "Location: " + file.Path, "OK");
                rutaDeVideo = file.Path;
                file.Dispose();

            }
            catch (Exception ex)
            {
                await DisplayAlert("Permiso denegado", "Da permisos de cámara al dispositivo.\nError: " + ex.Message, "Ok");
            }


        }
        
        private async void Btnguardar_Clicked(object sender, EventArgs e)
        {
            var db = new SQLiteAsyncConnection(dbPath);

            var video = new Photo
            {
                nombre = txtName.Text,
                descripcion = txtDescription.Text,
                ruta = rutaDeVideo
            };

            var result = await App.BaseDatos.GuardarVideo(video);
            if (result == 1)
            {
                await DisplayAlert("Guardar", "Video guardado correctamente", "OK");
            }
        }
    }
}