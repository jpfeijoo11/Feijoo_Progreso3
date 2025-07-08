using System.Collections.ObjectModel;
using Feijoo_Progreso3.Models;
using Feijoo_Progreso3.Services;

namespace Feijoo_Progreso3.ViewModels
{
    public class InventarioViewModel : BaseViewModel
    {
        public ObservableCollection<Prenda> Prendas { get; } = new();

        public async Task Cargar()
        {
            var service = new SQLiteService();
            var prendas = await service.GetPrendasAsync();
            Prendas.Clear();
            foreach (var p in prendas)
                Prendas.Add(p);
        }
    }
}
