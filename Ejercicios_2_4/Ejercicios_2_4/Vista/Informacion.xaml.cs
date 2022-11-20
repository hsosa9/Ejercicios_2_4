using Ejercicios_2_4.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xam.Forms.VideoPlayer;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Ejercicios_2_4.Vista
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Informacion : ContentPage
    {
        public Informacion(Videos datos)
        {
            InitializeComponent();
            nombre.Text = datos.nombre;
            descripcion.Text = datos.descripcion;
            UriVideoSource uriVideoSurce = new UriVideoSource()
            {
                Uri = datos.url_video
            };

            videoPlayer.Source = uriVideoSurce;
        }

        private void videoPlayer_PlayCompletion(object sender, EventArgs e)
        {

        }
    }
}