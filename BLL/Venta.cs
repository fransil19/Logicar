using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Venta
    {
        DAL.Venta _ventaDal;
        public Venta()
        {
            _ventaDal = new DAL.Venta();
        }

        public void RegistrarVenta(BE.Venta venta)
        {
            _ventaDal.RegistrarVenta(venta);
        }

        public List<BE.Venta> ListarVentas()
        {
            return _ventaDal.ListarVentas();
        }
    }
}
