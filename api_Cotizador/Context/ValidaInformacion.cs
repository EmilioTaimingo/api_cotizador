using api_Cotizador.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace api_Cotizador.Context
{
    public class ValidaInformacion
    {
        public Reply Verifica_Informacion(List<Paquete> oPaquetes)
        {
            Reply reply = new Reply();

            bool V_codigo = false;
            bool V_peso = false;
            bool V_Recoleccion = false;
            bool V_Tamano = false;
            int paquete = 1;
            //verificamos que los codigos postales esten correctos 
            foreach (var p in oPaquetes)
            {
                
                var cp = p.CodigoPostal;
                int i;
                if (!Int32.TryParse(cp.ToString(), out i))
                {
                    reply.Message = "El codigo postal debe contener minimo 4 digitos y maximo 5 digitos, revisa el paquete: " +paquete.ToString() ;
                    reply.Result = 401;
                    return reply;
                }
                if(cp.ToString().Length < 4|| cp.ToString().Length >5)
                {
                    reply.Message = "El codigo postal debe contener minimo 4 digitos y maximo 5 digitos, revisa el paquete: "+ paquete.ToString();
                    reply.Result = 401;
                    return reply;
                }
                paquete++;
            }

            paquete = 1;
            foreach (var p in oPaquetes)
            {
                var peso = p.Peso;
                float i;
                if (!float.TryParse(peso.ToString(), out i)|| peso==0)
                {
                    reply.Message = "Ingresa un peso mayor a 0. Revisa el paquete numero: "+paquete.ToString();
                    reply.Result = 402;
                    return reply;
                }
                paquete++;
            }

            paquete = 1;
            foreach (var p in oPaquetes)
            {

                var r = p.Recoleccion;
                int i;
                if (!Int32.TryParse(r.ToString(), out i))
                {
                    reply.Message = "El valor de recoleccion es 0 = Recoleccion y 1 =Entrega. Revisa el paquete numero: "+paquete.ToString();
                    reply.Result = 403;
                    return reply;
                }
                if (r>1)
                {
                    reply.Message = "El valor de recoleccion es 0 = Recoleccion y 1 =Entrega. Revisa el paquete numero: "+paquete.ToString();
                    reply.Result = 403;
                    return reply;
                }
                paquete++;
            }
            paquete= 1;
            foreach (var p in oPaquetes)
            {
                var r = p.Tamano;
                r = r.Replace(" ", "");
                r = r.ToUpper();
                if (r!="CHICO"&& r != "MEDIANO"&& r != "GRANDE")
                {
                    reply.Message = "El tamaño ingresado debe ser CHICO, MEDIANO o GRANDE. Revisa el paquete numero: " + paquete.ToString();
                    reply.Result = 404;
                    return reply;
                }
                paquete++;
            }
           



            return reply;
        }

    }
}