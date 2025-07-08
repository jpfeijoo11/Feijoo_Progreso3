using Feijoo_Progreso3.ViewModels;

namespace Feijoo_Progreso3.Views
{
    public partial class LogsPage : ContentPage
    {
        public LogsPage()
        {
            InitializeComponent();

            
            BindingContext = new LogsViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (BindingContext is LogsViewModel vm)
                vm.CargarLogs(); 
        }
    }
}
