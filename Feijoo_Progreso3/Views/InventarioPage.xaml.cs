using Feijoo_Progreso3.ViewModels;

namespace Feijoo_Progreso3.Views
{
    public partial class InventarioPage : ContentPage
    {
        public InventarioPage()
        {
            InitializeComponent();

            
            BindingContext = new InventarioViewModel();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            if (BindingContext is InventarioViewModel vm)
                await vm.Cargar();
        }
    }
}
