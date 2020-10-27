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
            string nombre_usuario = Cifrado.Encriptar("SYSTEM", true);
            DAL.Usuario _usuarioDal = new DAL.Usuario();
            Bitacora _bitacoraBll = new Bitacora();
            try
            {
                BE.Usuario usr = _usuarioDal.GetUsuarioUser(nombre_usuario);
                int error = 0;

                DAL.DigitoVerificador _DVDAL = new DAL.DigitoVerificador();

                List<BE.DigitoVerificador> listaDvv = _DVDAL.TraerDVV();

                foreach (BE.DigitoVerificador digito in listaDvv)
                {
                    DataTable tabla = _DVDAL.TraerTabla(digito.nombreTabla);

                    /* CALCULO Y COMPARO DVV LA TABLA VERIFICADA CON EL ALMACENADO*/
                    if (tabla.Rows.Count != 0)
                    {
                        long resultado = 0;

                        foreach (DataRow r in tabla.Rows)
                        {
                            resultado += long.Parse(r["dvh"].ToString());
                        }

                        if (resultado != digito.valorDvv)
                        {
                            // registro en bitacora
                            string descripcion_bitacora = string.Format(@"Error de integridad: Digito Verificador Vertical de la tabla {0} 
                                                                no coincide. Calculado = {1} , Almacenado = {2}", digito.nombreTabla, resultado, digito.valorDvv);

                            _bitacoraBll.RegistrarBitacora(usr, descripcion_bitacora, 1, 0);
                            error = 1;
                        }
                        /* CALCULO Y COMPARO DVH DE CADA REGISTRO DE LA TABLA VERIFICADA */
                        foreach (DataRow fila in tabla.Rows)
                        {
                            long dvh = 0;

                            foreach (DataColumn col in tabla.Columns)
                            {
                                long sumador = 0;
                                if (col.ColumnName != "id" && col.ColumnName != "legajo" && col.ColumnName != "dvh")
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
                                                                no coincide. Calculado = {1} , Almacenado = {2}", digito.nombreTabla, dvh, fila["dvh"].ToString());

                                _bitacoraBll.RegistrarBitacora(usr, descripcion_bitacora, 1, 0);
                                error = 1;
                            }
                        }
                    }
                    else
                    {
                        long resultado = 0;

                        if (resultado != digito.valorDvv)
                        {
                            // registro en bitacora
                            string descripcion_bitacora = string.Format(@"Error de integridad: Digito Verificador Vertical de la tabla {0} 
                                                                no coincide. Calculado = {1} , Almacenado = {2}", digito.nombreTabla, resultado, digito.valorDvv);

                            _bitacoraBll.RegistrarBitacora(usr, descripcion_bitacora, 1, 0);
                            error = 1;
                        }
                    }
                }

                return error;
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }


        /*Para calcular el DV*/
        public static long CalcularDV(Object obj,string nTabla)
        {
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
                            var subProp1 = prop.GetValue(obj);
                            PropertyInfo[] subpropiedades = subProp1.GetType().GetProperties();
                            foreach(var p in subpropiedades)
                            {
                                if (p.Name == "id" || p.Name == "legajo")
                                {
                                    if (p.GetValue(subProp1) != null) {
                                        string cadena = p.GetValue(subProp1).ToString();
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
                if (propiedades[posProp].GetValue(obj) == null || (int)propiedades[posProp].GetValue(obj) == 0)
                {
                    sum += long.Parse(row["dvh"].ToString());
                }
            }

            long dvv = sum+dvh;

            _DVDAL.ActualizarDVV(dvv, nTabla);
            return dvh;
        }

        public static string RecalcularDV(BE.Usuario _usuario)
        {
            Bitacora _bitacoraBll = new Bitacora();

            DAL.DigitoVerificador _DVDAL = new DAL.DigitoVerificador();

            List<BE.DigitoVerificador> listaDvv = _DVDAL.TraerDVV();

            foreach (BE.DigitoVerificador digito in listaDvv)
            {
                DataTable tabla = _DVDAL.TraerTabla(digito.nombreTabla);

                /* CALCULO Y COMPARO DVV LA TABLA VERIFICADA CON EL ALMACENADO*/

                long dvv = 0;
                /* CALCULO Y COMPARO DVH DE CADA REGISTRO DE LA TABLA VERIFICADA */
                foreach (DataRow fila in tabla.Rows)
                {
                    string identificador="";
                    long dvh = 0;

                    foreach (DataColumn col in tabla.Columns)
                    {
                        long sumador = 0;
                        if (col.ColumnName == "id" || col.ColumnName == "legajo")
                        {
                            identificador = col.ColumnName;
                        }
                        
                        if (col.ColumnName != "id" && col.ColumnName != "legajo" && col.ColumnName != "dvh")
                        {
                            var cadena_ascii = ASCIIEncoding.ASCII.GetBytes(fila[col].ToString());
                            for (int i = 0; i < cadena_ascii.Length; i++)
                            {
                                sumador += long.Parse(cadena_ascii[i].ToString()) * (i + 1);
                            }
                            dvh += sumador;
                        }
                    }
                    dvv += dvh;

                    _DVDAL.ActualizarDVH(dvh, digito.nombreTabla, identificador, fila[identificador].ToString());
                }

                _DVDAL.ActualizarDVV(dvv, digito.nombreTabla);
            }

            string descripcion_bitacora = $@"Se reestablecio la integridad del sistema";

            _bitacoraBll.RegistrarBitacora(_usuario, descripcion_bitacora, 1);

            return descripcion_bitacora;
        }
    }
}
