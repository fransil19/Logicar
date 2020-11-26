using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class VehiculoMercado
    {
        private int _id;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private int _tipoVehiculo;

        public int TipoVehiculo
        {
            get { return _tipoVehiculo; }
            set { _tipoVehiculo = value; }
        }

        private string _marca;

        public string Marca
        {
            get { return _marca; }
            set { _marca = value; }
        }

        private string _modelo;

        public string Modelo
        {
            get { return _modelo; }
            set { _modelo = value; }
        }

        private string _version;

        public string Version
        {
            get { return _version; }
            set { _version = value; }
        }

        private int _precioMercado;

        public int PrecioMercado
        {
            get { return _precioMercado; }
            set { _precioMercado = value; }
        }

        private int _unidadesVendidas;

        public int UnidadesVendidas
        {
            get { return _unidadesVendidas; }
            set { _unidadesVendidas = value; }
        }

    }
}
