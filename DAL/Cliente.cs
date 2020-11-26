using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Cliente
    {
        Acceso _acceso;
        public Cliente()
        {
            _acceso = new Acceso();
        }

        public BE.Cliente AltaCliente(BE.Cliente cliente)
        {
            int estado = (cliente.Estado == true) ? 1 : 0;
            string query = $@"INSERT INTO cliente (tipo_documento,nro_documento, nombre, apellido, domicilio, email, telefono,estado) 
                           output INSERTED.ID VALUES ({cliente.TipoDoc},{cliente.NroDoc},'{cliente.Nombre}','{cliente.Apellido}','{cliente.Domicilio}',
                           '{cliente.Email}',{cliente.Telefono},{estado});";

            int id = _acceso.ExecuteScalar(query);
            cliente.Id = id;
            return cliente;
        }

        public BE.Cliente BuscarCliente(BE.Cliente cliente)
        {
            string sql = $@"SELECT * FROM cliente where tipo_documento = {cliente.TipoDoc} and nro_documento = {cliente.NroDoc}";

            var reader = _acceso.GetReader(sql);
            if (reader.HasRows)
            {
                BE.Cliente _cliente = new BE.Cliente();
                while (reader.Read())
                {
                    _cliente.Id = int.Parse(reader["id"].ToString());
                    _cliente.Nombre = reader["nombre"].ToString();
                    _cliente.Apellido = reader["apellido"].ToString();
                    _cliente.TipoDoc = int.Parse(reader["tipo_documento"].ToString());
                    _cliente.NroDoc = int.Parse(reader["nro_documento"].ToString());
                    _cliente.Domicilio = reader["domicilio"].ToString();
                    _cliente.Email = reader["email"].ToString();
                    _cliente.Telefono = reader["telefono"] != DBNull.Value ? int.Parse(reader["telefono"].ToString()) : 0;
                    _cliente.Estado = bool.Parse(reader["estado"].ToString());
                }
                _acceso.CloseReader(reader);
                return _cliente;
            }
            else
            {
                _acceso.CloseReader(reader);
                throw new Exception("No se encontro el Cliente");
            }
        }

        public BE.Cliente BuscarClienteId(int id)
        {
            string sql = $@"SELECT * FROM cliente where id = {id}";

            var reader = _acceso.GetReader(sql);
            if (reader.HasRows)
            {
                BE.Cliente _cliente = new BE.Cliente();
                while (reader.Read())
                {
                    _cliente.Id = int.Parse(reader["id"].ToString());
                    _cliente.Nombre = reader["nombre"].ToString();
                    _cliente.Apellido = reader["apellido"].ToString();
                    _cliente.TipoDoc = int.Parse(reader["tipo_documento"].ToString());
                    _cliente.NroDoc = int.Parse(reader["nro_documento"].ToString());
                    _cliente.Domicilio = reader["domicilio"].ToString();
                    _cliente.Email = reader["email"].ToString();
                    _cliente.Telefono = reader["telefono"] != DBNull.Value ? int.Parse(reader["telefono"].ToString()) : 0;
                    _cliente.Estado = bool.Parse(reader["estado"].ToString());
                }
                _acceso.CloseReader(reader);
                return _cliente;
            }
            else
            {
                _acceso.CloseReader(reader);
                throw new Exception("No se encontro el Cliente");
            }
        }

        public List<BE.Cliente> ListarClientes()
        {
            string query = "SELECT * FROM Cliente;";
            List<BE.Cliente> lista = new List<BE.Cliente>();
            var reader = _acceso.GetReader(query);

            while (reader.Read())
            {
                BE.Cliente cliente = new BE.Cliente();
                cliente.Id = int.Parse(reader["id"].ToString());
                cliente.Nombre = reader["nombre"].ToString();
                cliente.Apellido = reader["apellido"].ToString();
                cliente.TipoDoc = int.Parse(reader["tipo_documento"].ToString());
                cliente.NroDoc = int.Parse(reader["nro_documento"].ToString());
                cliente.Domicilio = reader["domicilio"].ToString();
                cliente.Email = reader["email"].ToString();
                cliente.Telefono = reader["telefono"] != DBNull.Value ? int.Parse(reader["telefono"].ToString()) : 0;
                cliente.Estado = bool.Parse(reader["estado"].ToString());

                lista.Add(cliente);
            }
            _acceso.CloseReader(reader);

            return lista;
        }

        public void ActualizarCliente(BE.Cliente cliente)
        {
            string sql = $@"update cliente set nombre='{cliente.Nombre}',apellido='{cliente.Apellido}',domicilio='{cliente.Domicilio}',
                         email='{cliente.Email}',tipo_documento={cliente.TipoDoc},nro_documento={cliente.NroDoc},
                         estado={cliente.Estado},telefono= {cliente.Telefono} WHERE id = {cliente.Id}
                         ;";
            _acceso.ExecuteNonQuery(sql);
        }

        public BE.Cliente BuscarCliente(int tipoDoc, long nroDoc)
        {
            string sql = $@"SELECT * FROM cliente where tipo_documento = {tipoDoc} and nro_documento = {nroDoc}";

            var reader = _acceso.GetReader(sql);
            if (reader.HasRows)
            {
                BE.Cliente _cliente = new BE.Cliente();
                while (reader.Read())
                {
                    _cliente.Id = int.Parse(reader["id"].ToString());
                    _cliente.Nombre = reader["nombre"].ToString();
                    _cliente.Apellido = reader["apellido"].ToString();
                    _cliente.TipoDoc = int.Parse(reader["tipo_documento"].ToString());
                    _cliente.NroDoc = int.Parse(reader["nro_documento"].ToString());
                    _cliente.Domicilio = reader["domicilio"].ToString();
                    _cliente.Email = reader["email"].ToString();
                    _cliente.Telefono = reader["telefono"] != DBNull.Value ? int.Parse(reader["telefono"].ToString()) : 0;
                    _cliente.Estado = bool.Parse(reader["estado"].ToString());
                }
                _acceso.CloseReader(reader);
                return _cliente;
            }
            else
            {
                _acceso.CloseReader(reader);
                throw new Exception("No se encontro el Cliente");
            }
        }
    }
}
