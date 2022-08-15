using api_validate_collection_code.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Data;
using api_Cotizador.Models;

namespace api_Cotizador.Context
{
    public class ZonasCommand: DBContex
    {
        public bool Valida_Codigo(string CodigoPostal)
        {
            //Code_NumberGuide aqui recibimos la informacion ingresada por el usuario
            //PackageInformation, en este modelo capturamos los datos de respuesta del SP
            List<Zona>  lZonas=new List<Zona>();
        
            string connectionString = $"server ={GetRDSConections().Reader}; {Data_base}";
            using (MySqlConnection conexion = new MySqlConnection(connectionString))
            {

                MySqlCommand cmd = new MySqlCommand("muestra_zona_sp", conexion);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("codigopostal", CodigoPostal);

                conexion.Open();
                cmd.ExecuteNonQuery();
                using (MySqlDataReader dr = cmd.ExecuteReader())
                {


                    while (dr.Read())
                    {
                        lZonas.Add(new Zona()
                        {

                            Descripcion = dr["zon_descripcion"].ToString(),
                            Colonia = dr["cob_colonia"].ToString()

                        });
                    }
                }
            }
            bool bandera = false;
          if(lZonas.Count > 0)
            {
                bandera = true;
            }
            else
            {
                bandera = false;
            }
            return bandera;
                    
        }
    }
}