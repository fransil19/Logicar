using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DAL
{
    public class VehiculoStock
    {
        Acceso _acceso;

        public VehiculoStock()
        {
            _acceso = new Acceso();
        }

        public List<BE.VehiculoStock> ListarVehiculosStock()
        {
            string query = $@"SELECT * FROM vehiculoStock;";

            List<BE.VehiculoStock> listaVehiculos = new List<BE.VehiculoStock>();

            DataTable tabla = _acceso.ExecuteReader(query);

            foreach(DataRow fila in tabla.Rows)
            {
                BE.VehiculoStock vehiculo = new BE.VehiculoStock();

                vehiculo.Id = int.Parse(fila["id"].ToString());
                vehiculo.Patente = fila["patente"].ToString();
                vehiculo.TipoVehiculo = int.Parse(fila["tipo_vehiculo"].ToString());
                vehiculo.Marca = fila["marca"].ToString();
                vehiculo.Modelo = fila["modelo"].ToString();
                vehiculo.Anio = int.Parse(fila["anio"].ToString());
                vehiculo.Version = fila["version"].ToString();
                vehiculo.Kilometraje = int.Parse(fila["kilometraje"].ToString());
                vehiculo.Color = fila["color"].ToString();

                Estado _estadoDal = new Estado();
                vehiculo.Estado = _estadoDal.BuscarEstadoId(int.Parse(fila["id_estado"].ToString()));

                vehiculo.Precio = fila["precio"].ToString();
                vehiculo.Adquirido = Convert.ToBoolean(fila["adquirido"].ToString());
                vehiculo.Disponible = Convert.ToBoolean(fila["disponible"].ToString());

                Cliente _clienteDal = new Cliente();
                vehiculo.Cliente = _clienteDal.BuscarClienteId(int.Parse(fila["id_cliente"].ToString()));

                vehiculo.Dvh = long.Parse(fila["dvh"].ToString());

                listaVehiculos.Add(vehiculo);
            }

            return listaVehiculos;
        }

        public BE.VehiculoStock BuscarVehiculoPatente(string patente)
        {
            string query = $@"SELECT * FROM vehiculoStock WHERE patente = '{patente}';";

            BE.VehiculoStock vehiculo = new BE.VehiculoStock();

            DataTable tabla = _acceso.ExecuteReader(query);
            if(tabla.Rows.Count == 1)
            {
                foreach (DataRow fila in tabla.Rows)
                {
                    vehiculo.Id = int.Parse(fila["id"].ToString());
                    vehiculo.Patente = fila["patente"].ToString();
                    vehiculo.TipoVehiculo = int.Parse(fila["tipo_vehiculo"].ToString());
                    vehiculo.Marca = fila["marca"].ToString();
                    vehiculo.Modelo = fila["modelo"].ToString();
                    vehiculo.Anio = int.Parse(fila["anio"].ToString());
                    vehiculo.Version = fila["version"].ToString();
                    vehiculo.Kilometraje = int.Parse(fila["kilometraje"].ToString());
                    vehiculo.Color = fila["color"].ToString();

                    Estado _estadoDal = new Estado();
                    vehiculo.Estado = _estadoDal.BuscarEstadoId(int.Parse(fila["id_estado"].ToString()));

                    vehiculo.Precio = fila["precio"].ToString();
                    vehiculo.Adquirido = Convert.ToBoolean(fila["adquirido"].ToString());
                    vehiculo.Disponible = Convert.ToBoolean(fila["disponible"].ToString());

                    Cliente _clienteDal = new Cliente();
                    vehiculo.Cliente = _clienteDal.BuscarClienteId(int.Parse(fila["id_cliente"].ToString()));

                    vehiculo.Dvh = long.Parse(fila["dvh"].ToString());
                }

                return vehiculo;
            }
            else
            {
                return null;
            }

        }

        public void AltaVehiculo(BE.VehiculoStock vehiculo)
        {
            string query = $"INSERT INTO vehiculoStock (patente,tipo_vehiculo,marca,modelo,anio,version,kilometraje,color,id_estado," +
                $"precio,id_cliente,dvh) VALUES ('{vehiculo.Patente}','{vehiculo.TipoVehiculo}','{vehiculo.Marca}'," +
                $"'{vehiculo.Modelo}',{vehiculo.Anio},'{vehiculo.Version}',{vehiculo.Kilometraje},'{vehiculo.Color}',{vehiculo.Estado.Id}," +
                $"'{vehiculo.Precio}',{vehiculo.Cliente.Id},{vehiculo.Dvh})";

            _acceso.ExecuteNonQuery(query);
        }

        public BE.VehiculoStock BuscarVehiculoOfrecido(BE.Cliente cliente)
        {
            string query = $@"SELECT * FROM vehiculoStock WHERE id_cliente = {cliente.Id} AND (adquirido is null OR adquirido = 0);";

            BE.VehiculoStock vehiculo = new BE.VehiculoStock();
            DataTable tabla = _acceso.ExecuteReader(query);
            if(tabla.Rows.Count == 1)
            {
                foreach (DataRow fila in tabla.Rows)
                {
                    vehiculo.Id = int.Parse(fila["id"].ToString());
                    vehiculo.Patente = fila["patente"].ToString();
                    vehiculo.TipoVehiculo = int.Parse(fila["tipo_vehiculo"].ToString());
                    vehiculo.Marca = fila["marca"].ToString();
                    vehiculo.Modelo = fila["modelo"].ToString();
                    vehiculo.Anio = int.Parse(fila["anio"].ToString());
                    vehiculo.Version = fila["version"].ToString();
                    vehiculo.Kilometraje = int.Parse(fila["kilometraje"].ToString());
                    vehiculo.Color = fila["color"].ToString();

                    Estado _estadoDal = new Estado();
                    vehiculo.Estado = _estadoDal.BuscarEstadoId(int.Parse(fila["id_estado"].ToString()));

                    vehiculo.Precio = fila["precio"].ToString();
                    if (!String.IsNullOrEmpty(fila["adquirido"].ToString()))
                    {
                        vehiculo.Adquirido = Convert.ToBoolean(fila["adquirido"].ToString());
                    }
                    if (!String.IsNullOrEmpty(fila["disponible"].ToString()))
                    {
                        vehiculo.Disponible = Convert.ToBoolean(fila["disponible"].ToString());
                    }
                    

                    Cliente _clienteDal = new Cliente();
                    vehiculo.Cliente = _clienteDal.BuscarClienteId(int.Parse(fila["id_cliente"].ToString()));

                    vehiculo.Dvh = long.Parse(fila["dvh"].ToString());
                }
                return vehiculo;
            }
            else
            {
                throw new Exception("Existe mas de un vehiculo ofrecido y sin adquirir");
            }
        }

        public BE.VehiculoStock BuscarVehiculoOfrecidoPatente(string patente)
        {
            string query = $@"SELECT * FROM vehiculoStock WHERE patente = '{patente}' AND (adquirido is null OR adquirido = 0);";

            BE.VehiculoStock vehiculo = new BE.VehiculoStock();
            DataTable tabla = _acceso.ExecuteReader(query);
            if (tabla.Rows.Count == 1)
            {
                foreach (DataRow fila in tabla.Rows)
                {
                    vehiculo.Id = int.Parse(fila["id"].ToString());
                    vehiculo.Patente = fila["patente"].ToString();
                    vehiculo.TipoVehiculo = int.Parse(fila["tipo_vehiculo"].ToString());
                    vehiculo.Marca = fila["marca"].ToString();
                    vehiculo.Modelo = fila["modelo"].ToString();
                    vehiculo.Anio = int.Parse(fila["anio"].ToString());
                    vehiculo.Version = fila["version"].ToString();
                    vehiculo.Kilometraje = int.Parse(fila["kilometraje"].ToString());
                    vehiculo.Color = fila["color"].ToString();

                    Estado _estadoDal = new Estado();
                    vehiculo.Estado = _estadoDal.BuscarEstadoId(int.Parse(fila["id_estado"].ToString()));

                    vehiculo.Precio = fila["precio"].ToString();
                    if (!String.IsNullOrEmpty(fila["adquirido"].ToString()))
                    {
                        vehiculo.Adquirido = Convert.ToBoolean(fila["adquirido"].ToString());
                    }
                    if (!String.IsNullOrEmpty(fila["disponible"].ToString()))
                    {
                        vehiculo.Disponible = Convert.ToBoolean(fila["disponible"].ToString());
                    }

                    Cliente _clienteDal = new Cliente();
                    vehiculo.Cliente = _clienteDal.BuscarClienteId(int.Parse(fila["id_cliente"].ToString()));

                    vehiculo.Dvh = long.Parse(fila["dvh"].ToString());
                }
                return vehiculo;
            }
            else
            {
                throw new Exception("No existe el vehiculo o ya se encuentra adquirido");
            }
        }

        public void ActualizarVehiculo(BE.VehiculoStock vehiculo)
        {
            int adquirido = vehiculo.Adquirido ? 1 : 0;
            int disponible = vehiculo.Disponible ? 1 : 0;
            string query = $"UPDATE vehiculoStock set precio = '{vehiculo.Precio}',dvh = {vehiculo.Dvh}, adquirido = {adquirido}, disponible = {disponible}";

            _acceso.ExecuteNonQuery(query);
        }

        public BE.VehiculoStock BuscarVehiculoDisponible(string patente)
        {
            string query = $@"SELECT * FROM vehiculoStock WHERE patente = '{patente}' AND adquirido = 1 AND disponible = 1;";

            BE.VehiculoStock vehiculo = new BE.VehiculoStock();
            DataTable tabla = _acceso.ExecuteReader(query);
            if (tabla.Rows.Count == 1)
            {
                foreach (DataRow fila in tabla.Rows)
                {
                    vehiculo.Id = int.Parse(fila["id"].ToString());
                    vehiculo.Patente = fila["patente"].ToString();
                    vehiculo.TipoVehiculo = int.Parse(fila["tipo_vehiculo"].ToString());
                    vehiculo.Marca = fila["marca"].ToString();
                    vehiculo.Modelo = fila["modelo"].ToString();
                    vehiculo.Anio = int.Parse(fila["anio"].ToString());
                    vehiculo.Version = fila["version"].ToString();
                    vehiculo.Kilometraje = int.Parse(fila["kilometraje"].ToString());
                    vehiculo.Color = fila["color"].ToString();

                    Estado _estadoDal = new Estado();
                    vehiculo.Estado = _estadoDal.BuscarEstadoId(int.Parse(fila["id_estado"].ToString()));

                    vehiculo.Precio = fila["precio"].ToString();
                    if (!String.IsNullOrEmpty(fila["adquirido"].ToString()))
                    {
                        vehiculo.Adquirido = Convert.ToBoolean(fila["adquirido"].ToString());
                    }
                    if (!String.IsNullOrEmpty(fila["disponible"].ToString()))
                    {
                        vehiculo.Disponible = Convert.ToBoolean(fila["disponible"].ToString());
                    }

                    Cliente _clienteDal = new Cliente();
                    vehiculo.Cliente = _clienteDal.BuscarClienteId(int.Parse(fila["id_cliente"].ToString()));

                    vehiculo.Dvh = long.Parse(fila["dvh"].ToString());
                }
                return vehiculo;
            }
            else
            {
                throw new Exception("No existe el vehiculo o ya no esta disponible");
            }
        }

        public BE.VehiculoStock BuscarVehiculoId(int id)
        {
            string query = $@"SELECT * FROM vehiculoStock WHERE id = {id};";

            BE.VehiculoStock vehiculo = new BE.VehiculoStock();

            DataTable tabla = _acceso.ExecuteReader(query);
            if (tabla.Rows.Count == 1)
            {
                foreach (DataRow fila in tabla.Rows)
                {
                    vehiculo.Id = int.Parse(fila["id"].ToString());
                    vehiculo.Patente = fila["patente"].ToString();
                    vehiculo.TipoVehiculo = int.Parse(fila["tipo_vehiculo"].ToString());
                    vehiculo.Marca = fila["marca"].ToString();
                    vehiculo.Modelo = fila["modelo"].ToString();
                    vehiculo.Anio = int.Parse(fila["anio"].ToString());
                    vehiculo.Version = fila["version"].ToString();
                    vehiculo.Kilometraje = int.Parse(fila["kilometraje"].ToString());
                    vehiculo.Color = fila["color"].ToString();

                    Estado _estadoDal = new Estado();
                    vehiculo.Estado = _estadoDal.BuscarEstadoId(int.Parse(fila["id_estado"].ToString()));

                    vehiculo.Precio = fila["precio"].ToString();
                    vehiculo.Adquirido = Convert.ToBoolean(fila["adquirido"].ToString());
                    vehiculo.Disponible = Convert.ToBoolean(fila["disponible"].ToString());

                    Cliente _clienteDal = new Cliente();
                    vehiculo.Cliente = _clienteDal.BuscarClienteId(int.Parse(fila["id_cliente"].ToString()));

                    vehiculo.Dvh = long.Parse(fila["dvh"].ToString());
                }

                return vehiculo;
            }
            else
            {
                throw new Exception("No existe el vehiculo buscado");
            }

        }
    }
}
