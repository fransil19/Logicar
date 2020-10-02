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

        public BE.Usuario Usuario { get; set; }
        public DateTime FechaInicio { get; set; }

        public static SessionManager GetInstance
        {
            get
            {
                if (_session == null) throw new Exception("Sesion no iniciada");
                return _session;
            }
        }

        public static void Login(BE.Usuario usuario)
        {
            lock (_lock)
            {
                if (_session == null)
                {
                    _session = new SessionManager();
                    _session.Usuario = usuario;
                    _session.FechaInicio = DateTime.Now;

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

    }
}
