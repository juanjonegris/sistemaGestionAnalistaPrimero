using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadesCompartidas
{
    public class Empleado
    {

        private int _cedula;
        private string _nombre;
        private string _contrasena;

        public int Cedula
        {

            get { return _cedula; }
            set
            {

                if (value.ToString().Trim().Length != 8)
                    throw new Exception("La cédula debe tener 8 digitos. No incluya guión");
                _cedula = value;
            }
        }
        public string Nombre
        {
            get
            { return _nombre; }
            set
            {
                if (String.IsNullOrEmpty(value))
                    throw new Exception("Debe indicar un nombre de empleado");
                if( value.Trim().Length > 80)
                    throw new Exception("El nombre ingresado excede el tamaño de caracteres permitido");

                _nombre = value;
            }
        }
        public string Contrasena
        {
            get { return _contrasena; }
            set
            {

                if (String.IsNullOrEmpty(value))
                    throw new Exception("Debe indicar una contraseña");

                if (value.Trim().Length > 20)
                    throw new Exception("La contraseña ingresada excede el tamaño de caracteres permitido");


                _contrasena = value;
            }
        }


        public override string ToString()
        {
            return " \n Cedula: " + Cedula.ToString() + " \n Nombre: " + Nombre;

        }



        // Constructores

        public Empleado(int cedula, string nombre, string contrasena)
        {
            Cedula = cedula;
            Nombre = nombre;
            Contrasena = contrasena;
        }
    }
}
