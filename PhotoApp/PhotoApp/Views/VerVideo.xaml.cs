﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xam.Forms.VideoPlayer;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PhotoApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VerVideo : ContentPage
    {
        public VerVideo(string rutaVideo)
        {
            InitializeComponent();

            UriVideoSource uriVideoSource = new UriVideoSource()
            {
                /* Direcciones de video de pruebas */
                // Uri = "https://sec.ch9.ms/ch9/5d93/a1eab4bf-3288-4faf-81c4-294402a85d93/XamarinShow_mid.mp4"
                // Uri = "/storage/emulated/0/Android/data/com.companyname.photoapp/files/Movies/DefaultVideos/video_3.mp4"

                /* Direccion real recibida por parametro */
                Uri = rutaVideo
            };

            videoPlayer.Source = uriVideoSource;
        }

        private async void CloseButton_Clicked(object sender, EventArgs e)
        {
            videoPlayer.Pause();
            await Navigation.PopAsync();
        }

        private void videoPlayer_PlayCompletion(object sender, EventArgs e)
        {

        }
    }
}