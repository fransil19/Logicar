using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Compra
    {
        Bitacora _bitacoraBll;
        VehiculoMercado _vehiculoMerBll;
        DAL.Compra _compraDal;
        public Compra()
        {
            _bitacoraBll = new Bitacora();
            _vehiculoMerBll = new VehiculoMercado();
            _compraDal = new DAL.Compra();
        }

        public int CalcularPrecio(BE.VehiculoStock vehiculo, int formaAdq, int _precioVenta = 0)
        {
            var listaVehiculosMercado = _vehiculoMerBll.ListarVehiculos();
            var vehiculoMercado = listaVehiculosMercado.Where(r => r.TipoVehiculo == vehiculo.TipoVehiculo && r.Marca == vehiculo.Marca
                                               && r.Modelo == vehiculo.Modelo && r.Version == vehiculo.Version).FirstOrDefault();

            int precioMercado = vehiculoMercado.PrecioMercado;
            int porcentajeGanancia = 0;
            if(formaAdq == 0)
            {
                porcentajeGanancia = 15;
            }
            else
            {
                if (vehiculo.Estado.Resultado >= 90 && (vehiculo.Kilometraje >= 1000 && vehiculo.Kilometraje <= 15000))
                {
                    porcentajeGanancia = 15;
                }
                else
                {
                    porcentajeGanancia = 20;
                }
            }

            double precioCompra = precioMercado - (precioMercado * porcentajeGanancia) / 100;

            double precioGanancia = precioCompra;

            precioCompra = (precioCompra * vehiculo.Estado.Resultado) / 100;

            int porcentajeKilometraje = 0;
            if(vehiculo.Kilometraje > 0 && vehiculo.Kilometraje < 1000)
            {
                porcentajeKilometraje += 1;
            }
            else if (vehiculo.Kilometraje >= 1000 && vehiculo.Kilometraje < 10000)
            {
                porcentajeKilometraje += 2;
            }
            else if (vehiculo.Kilometraje >= 10000 && vehiculo.Kilometraje < 50000)
            {
                porcentajeKilometraje += 5;
            }
            else if (vehiculo.Kilometraje >= 50000 && vehiculo.Kilometraje < 80000)
            {
                porcentajeKilometraje += 7;
            }
            else
            {
                porcentajeKilometraje += 12;
            }

            precioCompra -= (precioCompra * porcentajeKilometraje) / 100;
            int precioCompraSugerido = (int)Math.Floor(precioCompra);
            double precioVenta = precioVenta = precioCompra + (precioCompra * porcentajeGanancia) / 100;

            int precioVentaSugerido = (int)Math.Floor(precioVenta); 
            if (formaAdq != 0)
            {
                if (_precioVenta != 0)
                {
                    if (_precioVenta > precioVentaSugerido)
                    {
                        throw new Exception("El precio de venta solicitado por el cliente es muy alto");
                    }
                    else if (_precioVenta < precioCompraSugerido)
                    {
                        throw new Exception("El precio de venta solicitado por el cliente es muy bajo");
                    }
                    else
                    {
                        precioVentaSugerido = _precioVenta;
                    }
                }
            }

            vehiculo.Precio = precioVentaSugerido.ToString();

            var usuario = Services.SessionManager.GetInstance.Usuario;

            _bitacoraBll.RegistrarBitacora(usuario, $"Precio calculado para el vehiculo de patente = {Cifrado.Desencriptar(vehiculo.Patente)}. " +
                $"Precio compra sugerido = {precioCompraSugerido}, precio de venta = {precioVentaSugerido}", 3);

            return precioCompraSugerido;
        }

        public void GuardarCompra(BE.Compra compra)
        {
            _compraDal.GuardarCompra(compra);
        }
    }
}
