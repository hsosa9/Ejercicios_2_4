
using Ejercicios_2_4.Vista;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xam.Forms.VideoPlayer;
using Xamarin.Essentials;
using Xamarin.Forms;


//informacion sacada de la pagina
//https://docs.microsoft.com/en-us/xamarin/essentials/media-picker?context=xamarin%2Fxamarin-forms&tabs=android

namespace Ejercicios_2_4
{
    public partial class MainPage : ContentPage
    {

        public string PhotoPath;
        public MainPage()
        {
            InitializeComponent();
        }

        private void btnVideo_Clicked(object sender, EventArgs e)
        {

            TomarVideoDeGaleria();

        }


        //esta funcion toma video de la galeria
        public async void TomarVideoDeGaleria()
        {
            try
            {
                var photo = await MediaPicker.PickVideoAsync();
                await LoadPhotoAsync(photo);
                Console.WriteLine($"CapturePhotoAsync COMPLETED: {PhotoPath}");
                //await DisplayAlert("as", PhotoPath, "ok");

                UriVideoSource uriVideoSurce = new UriVideoSource()
                {
                    Uri = PhotoPath
                };

                videoPlayer.Source = uriVideoSurce;

            }
            catch (FeatureNotSupportedException  )
            {
                // Feature is not supported on the device
            }
            catch (PermissionException  )
            {
                // Permissions not granted
            }
            catch (Exception ex)
            {
                Console.WriteLine($"CapturePhotoAsync THREW: {ex.Message}");
            }
        }


        //esta funcion captura video/ graba el video
        public async void TomarVideoTiempoReal()
        {
            try
            {
                var photo = await MediaPicker.CaptureVideoAsync();
                await LoadPhotoAsync(photo);
                Console.WriteLine($"CapturePhotoAsync COMPLETED: {PhotoPath}");
                //await DisplayAlert("as", PhotoPath, "ok");

                UriVideoSource uriVideoSurce = new UriVideoSource()
                {
                    Uri = PhotoPath
                };

                videoPlayer.Source = uriVideoSurce;

            }
            catch (FeatureNotSupportedException  )
            {
                // Feature is not supported on the device
            }
            catch (PermissionException  )
            {
                // Permissions not granted
            }
            catch (Exception ex)
            {
                Console.WriteLine($"CapturePhotoAsync THREW: {ex.Message}");
            }
        }

        async Task LoadPhotoAsync(FileResult photo)
        {
            // canceled
            if (photo == null)
            {
                PhotoPath = null;
                return;
            }
            // save the file into local storage
            var newFile = Path.Combine(FileSystem.CacheDirectory, photo.FileName);
            using (var stream = await photo.OpenReadAsync())
            using (var newStream = File.OpenWrite(newFile))
                await stream.CopyToAsync(newStream);

            PhotoPath = newFile;
        }

        private void videoPlayer_PlayCompletion(object sender, EventArgs e)
        {

        }

        private void btnreproducir_Clicked(object sender, EventArgs e)
        {
            TomarVideoTiempoReal();
        }

        private void btnGuardar_Clicked(object sender, EventArgs e)
        {
            Guardar_Datos();
        }


        public async void Guardar_Datos()
        {
            var videos = new Modelos.Videos
            {
                url_video = PhotoPath,
                nombre = txtNombre.Text,
                descripcion = txtPineda.Text
             };

            var resultado = await App.BaseDatos.GrabarVideos(videos);

            if (resultado == 1)
            {
                await DisplayAlert("Mensaje", "Registro exitoso!!!", "ok");
                txtNombre.Text = txtPineda.Text =  String.Empty;
             }
            else
            {
                await DisplayAlert("Error", "No se pudo Guardar", "ok");
            }
        }

        private async void btnLista_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Listado());
        }
    }
}
