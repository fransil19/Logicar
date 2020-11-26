using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Backup
    {
        Acceso _acceso;

        public Backup()
        {
            _acceso = new Acceso();
        }

        public string RealizarBackup(string nombre, string ruta)
        {
            string mensaje = "";

            string Consulta = @"BACKUP DATABASE[Diploma] TO DISK = '" + ruta + nombre + ".bak' WITH NOFORMAT, NOINIT, NAME = N'Diploma-Full Database Backup', SKIP, NOREWIND, NOUNLOAD,  STATS = 10";
            
            try
            {
                _acceso.ExecuteNonQuery(Consulta);
                mensaje = "La copia de la base de datos se realizó correctamente.";
            }
            catch
            {
                mensaje = "Error al copiar la base de datos.";
            }
            return mensaje;
        }

        public string RealizarRestore(string ruta)
        {
            string mensaje = "";

            string Consulta = @"ALTER DATABASE [Diploma] SET SINGLE_USER WITH ROLLBACK IMMEDIATE" +
                                 " USE MASTER RESTORE DATABASE [Diploma] FROM DISK = '" + ruta + "'" +
                                 " WITH REPLACE ALTER DATABASE [Diploma] SET MULTI_USER";
            
            try
            {
                _acceso.ExecuteNonQuery(Consulta);
                mensaje = "El restore se realizó correctamente.";
            }
            catch(Exception e)
            {
                mensaje = e.Message;
            }
            return mensaje;
        }
    }
}
