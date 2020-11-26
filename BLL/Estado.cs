using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Estado
    {
        Bitacora _bitacoraBll;
        DAL.Estado _estadoDal;

        public Estado()
        {
            _bitacoraBll = new Bitacora();
            _estadoDal = new DAL.Estado();
        }

        public BE.Estado ComprobarEstado(int valorMotor,int valorCarroceria,int valorFrenos,
            int valorAmortiguacion,int valorImpSonoro,int valorInterior)
        {
            BE.Usuario usuario = Services.SessionManager.GetInstance.Usuario;
            if (valorMotor <= 2 || valorCarroceria <= 2 || valorFrenos == 1 || valorAmortiguacion == 1)
            {
                _bitacoraBll.RegistrarBitacora(usuario, $"Estado del vehiculo no es aceptable, motor = {valorMotor}, carroceria =  {valorCarroceria}, frenos = {valorFrenos} y amortiguacion = {valorAmortiguacion}", 1);
                throw new Exception("El estado del vehiculo no es aceptable");
            }

            int sumaValores = valorMotor + valorCarroceria + valorFrenos + valorAmortiguacion + valorImpSonoro + valorInterior;
            float prom = (sumaValores / 25) * 100;
            int estadoFinal = 0;
            if (prom % 1 != 0)
            {
                if (valorMotor >= 4)
                {
                    estadoFinal = Convert.ToInt32(Math.Ceiling(prom));
                }
                else
                {
                    estadoFinal = Convert.ToInt32(Math.Ceiling(prom));
                }
            }
            else
            {
                estadoFinal = Convert.ToInt32(prom);
            }

            if (estadoFinal >= 70)
            {
                BE.Estado estado = new BE.Estado();
                estado.Resultado = estadoFinal;
                _estadoDal.GuardarEstado(estado);
                _bitacoraBll.RegistrarBitacora(usuario, $"Estado del vehiculo aceptable, resultado = {estadoFinal}", 1);
                return estado;
            }
            else
            {
                _bitacoraBll.RegistrarBitacora(usuario, $"Estado del vehiculo no es aceptable, resultado = {estadoFinal}", 1);
                throw new Exception("El estado del vehiculo no es aceptable");
            }
        }
    }
}
