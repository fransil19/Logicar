﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Empleado
    {
        public Empleado()
        {

        }

        public void altaEmpleado(BE.Empleado emp)
        {
            String query = "SELECT * FROM Empleado WHERE tipo_documento = " + emp.tipoDocumento + " AND nro_documento = " + emp.nroDocumento;

            //llamo a funcion de busqueda de empleado
            var resultado = true;

            if (resultado)
            {
                throw new Exception("El empleado ya se encuentra registrado"); 
            }

            query = "INSERT INTO Empleado (tipo_documento, nro_documento, nombre, apellido, domicilio)";


            return;
        }




    }
}