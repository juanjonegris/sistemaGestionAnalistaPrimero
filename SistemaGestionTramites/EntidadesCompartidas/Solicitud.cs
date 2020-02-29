using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadesCompartidas
{
    public class Solicitud
    {
        private int _numero;
        private Empleado _empleado;
        private Tramite _tipoTramite;
        private DateTime _fechaHora;
        private string nombreSolicitante;
        private string _estado;

        public int Numero {
            get { return _numero;

            }

            set {


                _numero = value; }

        }
        public Empleado empleado {
            get
            {
                return _empleado;

            }

            set
            {
                _empleado = value; //?? throw new Exception("No existe el empleado");
            }
        }
        public Tramite tipoTramite { get {
                return _tipoTramite;
            }
            set {


                _tipoTramite = value; //?? throw new Exception("No existe el trámite");
            }
        }
        public DateTime FechaHora { get {
                return  _fechaHora;
            }
            set
            {
                
                _fechaHora = value;
            }
        }
        public string NombreSolicitante { get
            {
                return nombreSolicitante;
            }
            set
            {
                if (String.IsNullOrEmpty(value))
                    throw new Exception("Debe indicar el nombre de la perosna que solicita el trámite");

                if (value.Trim().Length > 80)
                    throw new Exception("El nombre de la perosna solicitante del tramite que ha ingresado excede el tamaño de caracteres permitido");

                nombreSolicitante = value;
            }
            }
        public string Estado { get
            {
                return _estado;
            }
            set {
                if ( value.ToUpper() != "ALTA" && value.ToUpper() != "EJECUTADA" && value.ToUpper() != "ANULADA")
                    throw new Exception("No se ha ingresado un valor válido de Estado");

                _estado = value;
            }
        }

        //Metodos

        public override string ToString()
        {
            return " \n Numero: " + Numero.ToString() + " \n Nombre del empleado: " + empleado.Nombre + " \n Tipo de Trámite : " + tipoTramite.Nombre + " \n Fecha y Hora: " + FechaHora.ToString() + " \n Nommbre del solicitante: "+ NombreSolicitante + " \n Estado:  "+ Estado;

        }

        //Constructores

        public Solicitud(int numero, Empleado eempleado, Tramite ttipotramite, DateTime fechahora, string nombresolicitante, string estado)
        {
            Numero = numero;
            empleado = eempleado;
            tipoTramite = ttipotramite;
            FechaHora = fechahora;
            NombreSolicitante = nombresolicitante;
            Estado = estado;
        }

    }
}
