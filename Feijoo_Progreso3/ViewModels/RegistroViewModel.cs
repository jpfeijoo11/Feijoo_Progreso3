using System.Windows.Input;
using Feijoo_Progreso3.Models;
using Feijoo_Progreso3.Services;

namespace Feijoo_Progreso3.ViewModels
{
    public class RegistroViewModel : BaseViewModel
    {
        public string Nombre { get; set; }
        public string Color { get; set; }
        public int Talla { get; set; }
        public bool EnInventario { get; set; }

        public ICommand GuardarCommand { get; }

        public RegistroViewModel()
        {
            GuardarCommand = new Command(async () => await Guardar());
        }

        private async Task Guardar()
        {

            try
            {
                var prenda = new Prenda
                {
                    Nombre = Nombre,
                    Color = Color,
                    Talla = Talla,
                    EnInventario = EnInventario
                };

                var service = new SQLiteService();
                await service.AddPrendaAsync(prenda);
                await Shell.Current.DisplayAlert("Éxito", "Prenda registrada", "OK");
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error", ex.Message, "OK");
            }
        }
    }
}
