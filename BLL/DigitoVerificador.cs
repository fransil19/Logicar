using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Reflection;

namespace BLL
{
    public static class DigitoVerificador
    {
        public static int VerificarDV()
        {
            DAL.Acceso acceso = new DAL.Acceso();
            string nombre_usuario = Cifrado.Encriptar("SYSTEM", true);
            DAL.Usuario _usuarioDal = new DAL.Usuario();
            Bitacora _bitacoraBll = new Bitacora();
            try
            {
                BE.Usuario usr = _usuarioDal.GetUsuarioUser(nombre_usuario);
                int error = 0;

                DAL.DigitoVerificador _DVDAL = new DAL.DigitoVerificador();

                DataTable dt = _DVDAL.TraerTabla("DigitoVerificador");

                foreach (DataRow row in dt.Rows)
                {
                    DataTable tabla = _DVDAL.TraerTabla(row["nombreTabla"].ToString());

                    /* CALCULO Y COMPARO DVV LA TABLA VERIFICADA CON EL ALMACENADO*/

                    long resultado = 0;

                    foreach (DataRow r in tabla.Rows)
                    {
                        resultado += long.Parse(r["dvh"].ToString());
                    }

                    if (resultado != long.Parse(row["dvv"].ToString()))
                    {
                        // registro en bitacora
                        string descripcion_bitacora = string.Format(@"Error de integridad: Digito Verificador Vertical de la tabla {0} 
                                                                no coincide. Calculado = {1} , Almacenado = {2}", row["nombreTabla"].ToString(), resultado, row["dvv"].ToString());
                      
                        _bitacoraBll.RegistrarBitacora(usr, descripcion_bitacora, 1);
                        error = 1;
                    }
                    /* CALCULO Y COMPARO DVH DE CADA REGISTRO DE LA TABLA VERIFICADA */
                    foreach (DataRow fila in tabla.Rows)
                    {
                        long dvh = 0;

                        foreach (DataColumn col in tabla.Columns)
                        {
                            long sumador = 0;
                            if (col.ColumnName != "id" || col.ColumnName != "legajo")
                            {
                                var cadena_ascii = ASCIIEncoding.ASCII.GetBytes(fila[col].ToString());
                                for (int i = 0; i < cadena_ascii.Length; i++)
                                {
                                    sumador += long.Parse(cadena_ascii[i].ToString()) * (i + 1);
                                }
                                dvh += sumador;
                            }

                        }

                        if (dvh != long.Parse(fila["dvh"].ToString()))
                        {
                            // registro en bitacora
                            string descripcion_bitacora = string.Format(@"Error de integridad: Digito Verificador Horizontal de la tabla {0} 
                                                                no coincide. Calculado = {1} , Almacenado = {2}", row["nombreTabla"].ToString(), dvh, fila["dvh"].ToString());

                            _bitacoraBll.RegistrarBitacora(usr, descripcion_bitacora, 1);
                            error = 1;
                        }
                    }
                }

                return error;
            }
            catch
            {
                throw new Exception("No existe el usuario de Sistema");
            }
        }


        /*Para calcular el DV*/
        public static long CalcularDV(Object obj,string nTabla)
        {
            DAL.Acceso acceso = new DAL.Acceso();
            Type t = obj.GetType();
            PropertyInfo[] propiedades = t.GetProperties();

            DAL.DigitoVerificador _DVDAL = new DAL.DigitoVerificador();

            DataTable tabla = _DVDAL.TraerTabla(nTabla);

            long dvh = 0;
            
            foreach (var prop in propiedades)
            {
                if (prop.Name != "id" && prop.Name != "legajo" && prop.Name !="dvh")
                {
                    if (!prop.PropertyType.IsGenericType)
                    {
                        if (prop.PropertyType.Assembly.FullName == t.Assembly.FullName)
                        {
                            if (prop.Name == "id" || prop.Name == "legajo")
                            {
                                if (prop.GetValue(obj) != null) {
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
                        }
                        else
                        {
                            if (prop.GetValue(obj) != null)
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
                    }
                   
                }
            }

            long sum = 0;
            int posProp = 0;
            for (int i = 0; i < propiedades.Length; i++)
            {
                if (propiedades[i].Name == "id" || propiedades[i].Name == "legajo")
                {
                    posProp = i;
                }
            }

            foreach (DataRow row in tabla.Rows)
            {
                if (propiedades[posProp].GetValue(obj) == null)
                {
                    sum += long.Parse(row["dvh"].ToString());
                }

            }

            long dvv = sum+dvh;

            _DVDAL.ActualizarDVV(dvv, nTabla);
            return dvh;
        }
    }
}
