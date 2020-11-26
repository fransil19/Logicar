using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Compra
    {
        private int _id;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _esConsignacion;

        public string EsConsignacion
        {
            get { return _esConsignacion; }
            set { _esConsignacion = value; }
        }

        private VehiculoStock _vehiculoStock;

        public VehiculoStock VehiculoStock
        {
            get { return _vehiculoStock; }
            set { _vehiculoStock = value; }
        }

        private string _precioSugerido;

        public string PrecioSugerido
        {
            get { return _precioSugerido; }
            set { _precioSugerido = value; }
        }

        private Cliente _cliente;

        public Cliente Cliente
        {
            get { return _cliente; }
            set { _cliente = value; }
        }

        private Empleado _empleado;

        public Empleado Empleado
        {
            get { return _empleado; }
            set { _empleado = value; }
        }

        private DateTime _fecha;

        public DateTime Fecha
        {
            get { return _fecha; }
            set { _fecha = value; }
        }

        private long _dvh;

        public long Dvh
        {
            get { return _dvh; }
            set { _dvh = value; }
        }


    }
}
