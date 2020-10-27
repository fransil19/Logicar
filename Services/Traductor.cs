using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public static class Traductor
    {
        public static BE.Idioma ObtenerIdiomaDefault()
        {
            return ObtenerIdiomas().Where(i => i.Default).FirstOrDefault();
        }

        public static List<BE.Idioma> ObtenerIdiomas()
        {
            DAL.Traductor _traductorDal = new DAL.Traductor();
            
            List<BE.Idioma> _idiomas = _traductorDal.ObtenerIdiomas();

            return _idiomas;

        }

        public static Dictionary<string, BE.Traduccion> ObtenerTraducciones(BE.Idioma idioma = null)
        {
            DAL.Traductor _traductorDal = new DAL.Traductor();
            //si no hay idioma definido, traigo el idioma por default
            if (idioma == null)
            {
                idioma = ObtenerIdiomaDefault();
            }

            Dictionary<string, BE.Traduccion> _traducciones = _traductorDal.ObtenerTraducciones(idioma); ;

            return _traducciones;
        }
    }
}
