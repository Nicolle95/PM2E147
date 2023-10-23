using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace PM2E147.Models
{
    public class Paises
    {
        [PrimaryKey,AutoIncrement]
        public int Id { get; set; }

        public double latitud { get; set; }

        public double longitud { get; set; }

        public String descripcion { get; set; }

        public String pathImage { get; set; }   

        public Byte[] image { get; set; }

    }
}
