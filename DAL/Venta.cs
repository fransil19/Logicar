using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DAL
{
    public class Venta
    {
        Acceso _acceso;

        public Venta()
        {
            _acceso = new Acceso();
        }

        public void RegistrarVenta(BE.Venta venta)
        {
            string query = $"INSERT INTO venta (id_vehiculo,precio,id_cliente,legajo_empleado,fecha) VALUES" +
                $" ({venta.Vehiculo.Id},{venta.Precio},{venta.Cliente.Id},{venta.Empleado.legajo}," +
                $"'{venta.Fecha.ToString("yyyy-MM-dd HH:mm:ss")}');";

            _acceso.ExecuteNonQuery(query);
        }

        public List<BE.Venta> ListarVentas()
        {
            string query = $"SELECT * FROM venta";
            List<BE.Venta> lista = new List<BE.Venta>();

            DataTable tabla = _acceso.ExecuteReader(query);

            if (tabla.Rows.Count > 0)
            {
                foreach(DataRow fila in tabla.Rows)
                {
                    BE.Venta venta = new BE.Venta();
                    venta.Id = int.Parse(fila["id"].ToString());

                    Cliente _clientaDal = new Cliente();
                    venta.Cliente = _clientaDal.BuscarClienteId(int.Parse(fila["id_cliente"].ToString()));

                    Empleado _empleadoDal = new Empleado();
                    venta.Empleado = _empleadoDal.BuscarEmpleadoLegajo(int.Parse(fila["legajo_empleado"].ToString()));

                    VehiculoStock _vehiculoDal = new VehiculoStock();
                    venta.Vehiculo = _vehiculoDal.BuscarVehiculoId(int.Parse(fila["id_vehiculo"].ToString()));

                    venta.Precio = int.Parse(fila["precio"].ToString());
                    venta.Fecha = DateTime.Parse(fila["fecha"].ToString());

                    lista.Add(venta);
                }

                return lista;
            }
            else
            {
                throw new Exception("No existen ventas registradas");
            }
            
        }
    }
}
