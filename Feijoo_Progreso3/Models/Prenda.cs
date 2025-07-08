using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace Feijoo_Progreso3.Models
{
    internal class Prenda
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Color { get; set; }
        public int Talla { get; set; }
        public bool EnInventario { get; set; }

    }
}
