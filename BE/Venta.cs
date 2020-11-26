using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Venta
    {
        private int _id;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private VehiculoStock _vehiculo;

        public VehiculoStock Vehiculo
        {
            get { return _vehiculo; }
            set { _vehiculo = value; }
        }

        private int _precio;

        public int Precio
        {
            get { return _precio; }
            set { _precio = value; }
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

    }
}
