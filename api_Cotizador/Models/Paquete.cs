using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace api_Cotizador.Models
{
    public class Paquete
    {
        public int CodigoPostal { get; set; }
        public float Peso { get; set; }
        public int  Recoleccion { get; set; }
        //se usara la misma nomenclatura 
        //0=recoleccion
        //1=entrega
        public string Tamano { get; set; }
        //los tamaños seran chicos, medianos, grandes

    }
}