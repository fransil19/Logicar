using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BLL
{
    public class VehiculoMercado
    {
        public List<BE.VehiculoMercado> ListarVehiculos()
        {
            string path = "VehiculosMercado.json";
            List<BE.VehiculoMercado> vehiculos = JsonConvert.DeserializeObject<List<BE.VehiculoMercado>>(JsonManager.Read(path, "Json"));
            return vehiculos;
        }
        /*
        public void Prueba(List<BE.VehiculoMercado> vm)
        {
            string path = "VehiculosMercado.json";
            string jSONString = JsonConvert.SerializeObject(vm);
            JsonManager.Write(path, "Json", jSONString);
            
        }*/
    }
}
