using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace api_Cotizador.Models
{
    public class Reply
    {
        public string Message { get; set; }
        public int Result { get; set; }
        public int NumberOfPackages { get; set; }
        public int PickUpPackages { get; set; }
        public int DeliveryPackages { get; set; }
        public int PackagesWithoutCoverage { get; set; }
        public float TotalPrice { get; set; }
        public List<PaqueteRespuesta> Package { get; set; }
        

    }
}