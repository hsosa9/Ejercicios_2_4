using Ejercicios_2_4.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Ejercicios_2_4.Vista
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Listado : ContentPage
    {
        public Listado()
        {
            InitializeComponent();

            cargarListado();
        }


        public async void cargarListado()
        {
            var lista = await App.BaseDatos.ObtenerListaVideos();
            lstvideos.ItemsSource = lista;
        }

        private void lstvideos_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            lstvideos.SelectedItem = null;
        }

        private  void lstvideos_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            /*
            Videos selected = e.SelectedItem as Videos;
            if (selected == null)
                return;

            await Navigation.PushAsync(new Informacion(selected));
            //await DisplayAlert("Pais", selected.url_video + "", "ok");
            */
        }

        private async void VerDetalles(object sender, EventArgs e)
        {
            SwipeItem item = sender as SwipeItem;
            Videos model = item.BindingContext as Videos;
            await Navigation.PushAsync(new Informacion(model));
            //await DisplayAlert("Pais", model.url_video + "", "ok");
        }
    }
}