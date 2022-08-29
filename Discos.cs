﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DISCOS_DB
{
    class Discos
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public DateTime FechaLanzamiento { get; set; }
        public int CantidadCanciones { get; set; }
        public string UrlImagen { get; set; }
        public string Estilo { get; set; }
        public string TipoEdicion { get; set; }
    }
}
