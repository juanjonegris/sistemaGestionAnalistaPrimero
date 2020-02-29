using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadesCompartidas
{
    public class Entidad
    {
        private string _nombre;
        private List<string> _telefonos;
        private string _direccion;



        public string Nombre
        {
            get { return _nombre; }
            set
            {

                if (String.IsNullOrEmpty(value))
                    throw new Exception("Debe indicar un nombre para la entidad");
                if (value.Trim().Length > 80)
                    throw new Exception("El nombre para la Entidad Pública que ha sido ingresado excede el tamaño de caracteres permitido");
                _nombre = value;
            }
        }

        public List<string> Telefonos
        {

            get { return _telefonos; }

            set
            {
                
                foreach (string item in value)
                {
                    bool res;
                    int a;
                    res = int.TryParse(item, out a);
                    if(!res)
                        throw new Exception("Hay un dato de telefono que no es válido");
                }
                _telefonos = value;
            }
        }

        public string Direccion
        {

            
            get { return _direccion; }

            set
            {
                if (String.IsNullOrEmpty(value))
                    throw new Exception("Debe indicar una dirección para la entidad");
                if (value.Trim().Length > 80)
                    throw new Exception("El nombre para la dirección que ha sido ingresado excede el tamaño de caracteres permitido");
                _direccion = value;
            }
        }



        // Metodos
        public override string ToString()
        {

            return " \n Nombre: " + Nombre + " \n Dirección: " + Direccion;

        }

        

        // Constructores

        public Entidad(string nombre, List<String> telefonos, string direccion)
        {
            Nombre = nombre;
            Telefonos = telefonos;
            Direccion = direccion;
        }

    }
}
