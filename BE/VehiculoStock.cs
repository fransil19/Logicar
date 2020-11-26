using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class VehiculoStock
    {
        private int _id;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _patente;

        public string Patente
        {
            get { return _patente; }
            set { _patente = value; }
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

        private int _anio;

        public int Anio
        {
            get { return _anio; }
            set { _anio = value; }
        }

        private string _version;

        public string Version
        {
            get { return _version; }
            set { _version = value; }
        }

        private int _kilometraje;

        public int Kilometraje
        {
            get { return _kilometraje; }
            set { _kilometraje = value; }
        }

        private string _color;

        public string Color
        {
            get { return _color; }
            set { _color = value; }
        }

        private Estado _estado;

        public Estado Estado
        {
            get { return _estado; }
            set { _estado = value; }
        }

        private string _precio;

        public string Precio
        {
            get { return _precio; }
            set { _precio = value; }
        }


        private bool _adquirido;

        public bool Adquirido
        {
            get { return _adquirido; }
            set { _adquirido = value; }
        }

        private bool _disponible;

        public bool Disponible
        {
            get { return _disponible; }
            set { _disponible = value; }
        }

        private Cliente _cliente;

        public Cliente Cliente
        {
            get { return _cliente; }
            set { _cliente = value; }
        }

        private long _dvh;

        public long Dvh
        {
            get { return _dvh; }
            set { _dvh = value; }
        }
    }
}
