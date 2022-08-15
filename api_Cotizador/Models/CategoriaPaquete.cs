using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace api_Cotizador.Models
{
    public class CategoriaPaquete
    {
        public float pesoMinimo { get; set; }
        public float pesoMaximo { get; set; }
        public int cantidadMinima { get; set; }
        public int cantidadMaxima { get; set; }
        public float precioPaquete { get; set; }
        public float precioRecoleccion { get; set; }
    }
}