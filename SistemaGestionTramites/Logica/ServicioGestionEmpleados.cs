using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesCompartidas;
using Persistencia;

namespace Logica
{
    public class ServicioGestionEmpleados
    {
        perGestionEmpleados pergesemp = new perGestionEmpleados();
        public Empleado loginEmpleado(int cedula, string contrasena)
        {
            
            Empleado emp = null;

            emp = pergesemp.loginEmpleado(cedula, contrasena);

            return emp;

        }

        public Empleado BuscarEmpleado(int ci)
        {
            return pergesemp.conseguirEmpleado(ci);
        }

        public void altaEmpleado(Empleado emp)
        {
            pergesemp.altaEmpleado(emp);
        }

        public void eliminarEmpleado(Empleado emp)
        {
            pergesemp.eliminarEmpleado(emp);
        }

        public void modificarEmpleado(Empleado emp)
        {
            pergesemp.modificarEmpleado(emp);
        }

    }
}
