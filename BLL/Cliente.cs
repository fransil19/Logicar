using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Cliente
    {
        DAL.Cliente _clienteDal;

        public Cliente()
        {
            _clienteDal = new DAL.Cliente();
        }
        public BE.Cliente AltaCliente(BE.Cliente cliente)
        {
            if (!ExisteCliente(cliente))
            {
                _clienteDal.AltaCliente(cliente);
                return cliente;
            }
            else
            {
                throw new Exception("El usuario ya existe");
            }
            
        }

        private bool ExisteCliente(BE.Cliente cliente)
        {
            try
            {
                var _cliente = _clienteDal.BuscarCliente(cliente);
                if(_cliente != null)
                {
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        public List<BE.Cliente> ListarClientes()
        {
            return _clienteDal.ListarClientes();
        }

        public void EliminarCliente(BE.Cliente cliente)
        {
            cliente.Estado = false;
            _clienteDal.ActualizarCliente(cliente);
        }

        public void ModificarCliente(BE.Cliente cliente)
        {
            _clienteDal.ActualizarCliente(cliente);
        }

        public BE.Cliente BuscarCliente(int tipoDoc, long nroDoc)
        {
            return _clienteDal.BuscarCliente(tipoDoc, nroDoc);
        }

    }
}
