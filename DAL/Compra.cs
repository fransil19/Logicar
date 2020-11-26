using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Compra
    {
        Acceso _acceso;

        public Compra()
        {
            _acceso = new Acceso();
        }

        public void GuardarCompra(BE.Compra compra)
        {
            string query = $"INSERT INTO compra (es_consignacion,id_vehiculo,precio_sugerido,id_cliente,legajo_empleado,fecha,dvh)" +
                $" VALUES ('{compra.EsConsignacion}',{compra.VehiculoStock.Id},'{compra.PrecioSugerido}',{compra.Cliente.Id}," +
                $"{compra.Empleado.legajo},'{compra.Fecha.ToString("yyyy-MM-dd HH:mm:ss")}',{compra.Dvh});";

            _acceso.ExecuteNonQuery(query);
        }

        
    }
}
