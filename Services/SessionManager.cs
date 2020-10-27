using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class SessionManager
    {
        private static SessionManager _session;
        private static object _lock = new Object();
        static List<IIdiomaObserver> _observers = new List<IIdiomaObserver>();

        public BE.Usuario Usuario { get; set; }
        public DateTime FechaInicio { get; set; }

        public BE.Idioma Idioma { get; set; }

        public static SessionManager GetInstance
        {
            get
            {
                if (_session == null) throw new Exception("Sesion no iniciada");
                return _session;
            }
        }

        public static bool IsLogged()
        {
            return _session != null;
        }
        public static void Login(BE.Usuario usuario,BE.Idioma idioma)
        {
            lock (_lock)
            {
                if (_session == null)
                {
                    _session = new SessionManager();
                    _session.Usuario = usuario;
                    _session.FechaInicio = DateTime.Now;
                    _session.Idioma = idioma;

                }
                else
                {
                    throw new Exception("Sesion ya iniciada");
                }
            }
        }

        public static void Logout()
        {
            lock (_lock)
            {
                if (_session != null)
                {
                    _session = null;
                    Notificar(Traductor.ObtenerIdiomaDefault());
                }
                else
                {
                    throw new Exception("Sesion no iniciada");
                }
            }
            
        }

        private SessionManager()
        {

        }

        public static void SuscribirObservador(IIdiomaObserver o)
        {
            _observers.Add(o);
        }
        public static void DesuscribirObservador(IIdiomaObserver o)
        {
            _observers.Remove(o);
        }

        private static void Notificar(BE.Idioma idioma)
        {
            foreach (var o in _observers)
            {
                o.UpdateLanguage(idioma);
            }
        }
        public static void CambiarIdioma(BE.Idioma idioma)
        {
            if (_session != null)
            {
                _session.Idioma = idioma;
                Notificar(idioma);
            }
        }

        public bool TienePermiso(string permiso)
        {
            bool existe = false;
            foreach (var item in Usuario.Permisos)
            {
                if (item.nombre.Equals(permiso))
                    return true;
                else
                {
                    existe = TienePermiso(item, permiso, existe);
                    if (existe) return true;
                }

            }

            return existe;
        }

        public bool TienePermiso(BE.Permiso c, string permiso, bool existe)
        {
            if (c.nombre.Equals(permiso))
                existe = true;
            else
            {
                foreach (var item in c.Hijos)
                {
                    existe = TienePermiso(item, permiso, existe);
                    if (existe) return true;
                }
            }
            return existe;
        }
    }
}
