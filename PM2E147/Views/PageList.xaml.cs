using PM2E147.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PM2E147.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageList : ContentPage
    {

        private Paises Sites = null;
        public PageList()
        {
            InitializeComponent();
            if (App.DBaseSitios == null) Debug.WriteLine("Creando base de datos");
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            LoadData();

            Sites = null;
        }

        private void listaSites_ItemTapped(object sender, ItemTappedEventArgs e)
        {

            try
            {

                Sites = e.Item as Paises;

            }
            catch (Exception ex)
            {
                Mensage("Error:", ex.Message);
            }

        }

        private async void btnEliminar_Clicked(object sender, EventArgs e)
        {

            try
            {


                if (Sites == null)
                {
                    Mensage("Aviso", "Debe seleccionar un sitio");
                    return;
                }

                var status = await DisplayAlert("Aviso", $"¿Desea eliminar el sitio: {Sites.descripcion}?", "SI", "NO");

                if (status)
                {
                    //El usuario dijo que si
                    var result = await App.DBaseSitios.deleteSitio(Sites);

                    if (result > 0)
                    {
                        Mensage("Aviso", "Exito, El sitio fue eliminado correctamente");
                        Sites = null;
                        LoadData();
                    }
                    else
                    {

                        Mensage("Aviso", " No se logro eliminar el sitio deseado");
                    }
                }
                else
                {
                    //El usuario dijo que no
                }

            }
            catch (Exception ex)
            {
                Mensage("Error:", ex.Message);
            }

        }

        private async void btnVerMapa_Clicked(object sender, EventArgs e)
        {

            try
            {


                if (Sites == null)
                {
                    Mensage("Aviso Advertencia", "Seleccione el sitio que desea ver");
                    return;
                }

                var status = await DisplayAlert("Aviso", $"¿Desea ir a la ubicacion indicada de dicha imagen?", "SI", "NO");

                if (status)
                {
                    //El usuario dijo que si
                    await Navigation.PushAsync(new Views.PageMaps(Sites));
                }
                else
                {
                    //El usuario dijo que no
                }

            }
            catch (Exception ex)
            {
                Mensage("Error:", ex.Message);
            }

        }

        private async void LoadData()
        {
            try
            {
                listaSites.ItemsSource = await App.DBaseSitios.getListSitio();


            }
            catch (Exception ex)
            {
                Mensage("Error: ", ex.Message);
            }
        }

        #region Metodos Utiles


        private async void Mensage(string title, string message)
        {
            await DisplayAlert(title, message, "OK");
        }

        #endregion Metodos Utiles

    }
}