using Feijoo_Progreso3.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Feijoo_Progreso3.Services
{
    public class SQLiteService
    {
        private SQLiteAsyncConnection _db;

        public async Task Init()
        {
            if (_db != null) return;

            var dbPath = Path.Combine(FileSystem.AppDataDirectory, "ropa.db");
            _db = new SQLiteAsyncConnection(dbPath);
            await _db.CreateTableAsync<Prenda>();
        }

        public async Task<List<Prenda>> GetPrendasAsync()
        {
            await Init();
            return await _db.Table<Prenda>().ToListAsync();
        }

        public async Task AddPrendaAsync(Prenda prenda)
        {
            await Init();

            
            if (prenda.EnInventario && prenda.Talla < 10)
                throw new Exception("No se pueden registrar prendas con talla menor a 10 si están en inventario.");

            await _db.InsertAsync(prenda);

            
            string logPath = Path.Combine(FileSystem.AppDataDirectory, "Logs_Feijoo.txt");
            string log = $"Se incluyó el registro [{prenda.Nombre}] el {DateTime.Now:dd/MM/yyyy HH:mm}\n";
            File.AppendAllText(logPath, log);
        }
    }
}
