using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Reflection;

namespace BLL
{
    public class DigitoVerificador
    {
        private DAL.Acceso acceso;

        public DigitoVerificador()
        {
            acceso = new DAL.Acceso();
        }
         
        public int VerificarDV(BE.Usuario usuario)
        {
            int error = 0;
            String query = "SELECT * FROM DigitoVerificador";
            DataTable dt;

            dt = acceso.ExecuteReader(query);
            
            foreach (DataRow row in dt.Rows)
            {
                query = "SELECT * from " + row["nombreTabla"].ToString();
                DataTable tabla = acceso.ExecuteReader(query);

                long resultado = CalcularDVV(tabla);

                if (resultado != long.Parse(row["dvh"].ToString()))
                {
                    // cifro datos de usuario

                    // registro en bitacora
                }

                foreach (DataRow fila in tabla.Rows)
                {
                    long calculado = CalcularDVH(fila,tabla);
                }
            }

            return error;
        }

        //DVV para la verificacion
        private long CalcularDVV(DataTable tabla)
        {
            long sumador = 0;

            foreach (DataRow row in tabla.Rows)
            {
                sumador += long.Parse(row["dvh"].ToString());
            }

            return sumador;
        }

        // DVV para el calculo de DV
        private long CalcularDVV(DataTable tabla, Object obj)
        {
            Type t = obj.GetType();
            PropertyInfo[] propiedades = t.GetProperties();

            long sumador = 0;
            int posProp = 0;
            for(int i = 0; i< propiedades.Length; i++)
            {
                if(propiedades[i].Name == "id" || propiedades[i].Name == "legajo")
                {
                    posProp = i;
                }
            }

            foreach (DataRow row in tabla.Rows)
            {
                if (propiedades[posProp].GetValue(obj) == null)
                {
                    sumador += long.Parse(row["dvh"].ToString());
                }
                
            }

            return sumador;
        }

        private long CalcularDVH(DataRow fila,DataTable tabla)
        {
            long sumador = 0;

            foreach (DataColumn col in tabla.Columns)
            {

                sumador += long.Parse(fila[col].ToString());
            }

            return sumador;
        }


        /*Para calcular el DV*/
        public long CalcularDV(BE.Usuario usuario, Object obj,string nTabla)
        {
            Type t = obj.GetType();
            PropertyInfo[] propiedades = t.GetProperties();
            int error = 0;
            
            string query = "SELECT * from " + nTabla;
            DataTable tabla = acceso.ExecuteReader(query);

            long dvh = 0;

            foreach (var prop in propiedades)
            {
                if (prop.Name != "id" || prop.Name != "legajo")
                {
                    string cadena = prop.GetValue(obj).ToString();
                    var cadena_ascii = ASCIIEncoding.ASCII.GetBytes(cadena);
                    long sumador = 0;

                    for (int i = 0; i < cadena_ascii.Length; i++)
                    {
                        sumador += long.Parse(cadena_ascii[i].ToString()) * (i + 1);
                    }
                    dvh += sumador;
                }
            }


            long dvv = CalcularDVV(tabla, obj)+dvh;


            query = "";

            return error;
        }
    }
}
