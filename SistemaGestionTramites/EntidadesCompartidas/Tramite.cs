using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadesCompartidas
{
    public class Tramite
    {

        private string _codigo;
        private string _nombre;
        private Entidad _entidad;
        private string _descripcion;

        public string Codigo
        {
            get { return _codigo; }


            set
            {

                if (value.Trim().Length > 6)
                    throw new Exception("El codigo de tramite debe ser de no más de 6 digitos");

                _codigo = value;
            }
        }
        public string Nombre
        {
            get
            { return _nombre; }

            set
            {

                if (String.IsNullOrEmpty(value))
                    throw new Exception("Debe indicar un nombre de trámite");
                if (value.Trim().Length > 100)
                    throw new Exception("El nombre del trámite que ha sido ingresado excede el tamaño de caracteres permitido");

                _nombre = value;
            }
        }
        public Entidad entidad
        {
            get
            { return _entidad; }

            set
            {
                _entidad = value; //?? throw new Exception("No existe la Entidad Publica");
            }
        }

        public string Descripcion
        {
            get
            { return _descripcion; }

            set
            {
                if (String.IsNullOrEmpty(value))
                    throw new Exception("Debe indicar una descripcion del trámite");
                if (value.Trim().Length >= 8000)
                    throw new Exception("La descripción es demasiado extensa.");
                _descripcion = value;
            }
        }


        // Metodos
        public override string ToString()
        {
            return " \n Codigo: " + Codigo + " \n Nombre: " + Nombre + " \n Nombre Entidad: " + entidad.Nombre + " \n Descripción " + Descripcion;

        }


        public Tramite(string codigo, string nombre, Entidad eentidad, string descripcion)
        {
            Codigo = codigo;
            Nombre = nombre;
            entidad = eentidad;
            Descripcion = descripcion;
        }

        
    }
}
