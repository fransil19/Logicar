using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Backup
    {
        DAL.Backup _backupDal;

        public Backup()
        {
            _backupDal = new DAL.Backup();
        }
        public string RealizarBackup(string nombre, string ruta)
        {
            string mensaje = _backupDal.RealizarBackup(nombre, ruta);
            return mensaje;
        }

        public string RealizarRestore(string ruta)
        {
            string mensaje = _backupDal.RealizarRestore(ruta);
            return mensaje;
        }
    }
}
