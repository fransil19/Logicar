using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class VehiculoStock
    {
        Bitacora _bitacoraBll;
        VehiculoMercado _vehiculoMerBll;
        DAL.VehiculoStock _vehiculoStockDal;

        public VehiculoStock()
        {
            _bitacoraBll = new Bitacora();
            _vehiculoMerBll = new VehiculoMercado();
            _vehiculoStockDal = new DAL.VehiculoStock();
        }


        public bool VerificarExistencia(BE.VehiculoStock vehiculo)
        {
            BE.Usuario usuario = Services.SessionManager.GetInstance.Usuario;

            var listaVehiculosMercado = _vehiculoMerBll.ListarVehiculos();
            var esTop = listaVehiculosMercado.Where(r=> r.TipoVehiculo == vehiculo.TipoVehiculo && r.Marca == vehiculo.Marca 
                                                && r.Modelo == vehiculo.Modelo && r.Version == vehiculo.Version).FirstOrDefault();
            if(esTop == null)
            {
                _bitacoraBll.RegistrarBitacora(usuario, $"El vehiculo de patente = {vehiculo.Patente} no se encuentra dentro de los mas vendidos del mercado", 1);
                return true;
            }

            List<BE.VehiculoStock> listaStock = ListarVehiculosStock();

            var listaFiltrada = listaStock.Where(r => r.TipoVehiculo == vehiculo.TipoVehiculo && r.Marca == vehiculo.Marca
                                                && r.Modelo == vehiculo.Modelo && r.Version == vehiculo.Version);
            if (listaFiltrada.Count() >= 4)
            {
                _bitacoraBll.RegistrarBitacora(usuario, $"El vehiculo de patente = {vehiculo.Patente} no puede adquirirse, ya existen 4 vehciulos similares", 1);
                return true;
            }

            return false;
        }

        public List<BE.VehiculoStock> ListarVehiculosStock()
        {
            return _vehiculoStockDal.ListarVehiculosStock();
        }

        public BE.VehiculoStock BuscarVehiculoPatente(string patente)
        {
            return _vehiculoStockDal.BuscarVehiculoPatente(patente);
        }

        public void AltaVehiculo(BE.VehiculoStock vehiculo)
        {
            _vehiculoStockDal.AltaVehiculo(vehiculo);
        }

        public BE.VehiculoStock BuscarVehiculoOfrecido(BE.Cliente cliente)
        {
            return _vehiculoStockDal.BuscarVehiculoOfrecido(cliente);
        }

        public BE.VehiculoStock BuscarVehiculoOfrecidoPatente(string patente)
        {
            return _vehiculoStockDal.BuscarVehiculoOfrecidoPatente(patente);
        }

        public void ActualizarVehiculo(BE.VehiculoStock vehiculo)
        {
            _vehiculoStockDal.ActualizarVehiculo(vehiculo);
        }

        public BE.VehiculoStock BuscarVehiculoDisponible(string patente)
        {
            return _vehiculoStockDal.BuscarVehiculoDisponible(patente);
        }

    }
}
