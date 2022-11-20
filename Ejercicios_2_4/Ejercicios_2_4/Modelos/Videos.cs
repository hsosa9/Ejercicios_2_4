using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ejercicios_2_4.Modelos
{
    public class Videos
    {

        [PrimaryKey, AutoIncrement]
        public int codigo { get; set; }

        [MaxLength(200)]
        public string url_video { get; set; }

        [MaxLength(200)]
        public string nombre { get; set; }

        [MaxLength(100)]
        public string descripcion { get; set; }

    }
}
