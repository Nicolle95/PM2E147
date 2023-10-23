using System;
using System.Collections.Generic;
using System.Text;
using PM2E147.Models;
using System.Threading.Tasks;
using SQLite;

namespace PM2E147.Controllers
{
   public class BDpaises
    {

        readonly SQLiteAsyncConnection dbase;

        public BDpaises(string dbpath)
        {
            dbase = new SQLiteAsyncConnection(dbpath);

            //Creacion de las tablas de la base de datos

            dbase.CreateTableAsync<Paises>(); 

        }

        #region OperacionesSitio
        //Metodos CRUD - CREATE UPDATE
        public Task<int> insertUpdateSitio(Paises sitio)
        {
            if (sitio.Id != 0)
            {
                return dbase.UpdateAsync(sitio);
            }
            else
            {
                return dbase.InsertAsync(sitio);
            }
        }

        //Metodos CRUD - READ LIST
        public Task<List<Paises>> getListSitio()
        {
            return dbase.Table<Paises>().ToListAsync();
        }

        public Task<Paises> getSitio(int id)
        {
            return dbase.Table<Paises>()
                .Where(i => i.Id == id)
                .FirstOrDefaultAsync();
        }

        //Metodos CRUD - DELETE
        public Task<int> deleteSitio(Paises sitio)
        {
            return dbase.DeleteAsync(sitio);
        }

        #endregion OperacionesSitio

    }
}
