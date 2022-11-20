using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Ejercicios_2_4.Modelos;
 using SQLite;

namespace Ejercicios_2_4.Controller
{
   public class DataBaseSQLite
    {

        readonly SQLiteAsyncConnection db;
 
        //constructor de la clase DataBaseSQLite
        public DataBaseSQLite(string pathdb)
        {
             db = new SQLiteAsyncConnection(pathdb);
            db.CreateTableAsync<Videos>().Wait();
        }

        //Operaciones crud de sqlite
        //Read List way
        public Task<List<Videos>> ObtenerListaVideos()
        {
            return db.Table<Videos>().ToListAsync();
        }

        //read one by one 
        public Task<Videos> ObtenerVideos(int pcodigo)
        {
            return db.Table<Videos>()
                .Where(i => i.codigo == pcodigo)
                .FirstOrDefaultAsync();
        }

        //Create o update personas
        public Task<int> GrabarVideos(Videos videos)
        {
            if (videos.codigo != 0)
            {
               return db.UpdateAsync(videos);
            }
            else
            {
                return db.InsertAsync(videos);
            }
            
        }

  

        //delete
        public Task<int> EliminarLocalizacion(Videos videos)
        {
            return db.DeleteAsync(videos);
        }


    }
}
