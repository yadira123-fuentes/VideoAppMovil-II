using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PhotoApp.Models
{
   public class db
    {
        readonly SQLiteAsyncConnection basedatos;

        public db(String pathdb)
        {
            basedatos = new SQLiteAsyncConnection(pathdb);

            basedatos.CreateTableAsync<Photo>().Wait();
        }

        // Lista de Videos
        public Task<List<Photo>> ObtenerListaVideos()
        {
            return basedatos.Table<Photo>().ToListAsync();
        }

        // Codigo de videos
        public Task<Photo> ObtenerVideoCodigo(int codeParam)
        {
            return basedatos.Table<Photo>()
                .Where(i => i.codigo == codeParam)
                .FirstOrDefaultAsync();
        }

        // Guardar Video
        public Task<int> GuardarVideo(Photo photo)
        {
            if (photo.codigo != 0)
            {
                return basedatos.UpdateAsync(photo);
            }
            else
            {
                return basedatos.InsertAsync(photo);
            }

        }

        public Task<int> EliminarVideo(Photo photo)
        {
            return basedatos.DeleteAsync(photo);
        }

    }
}
