using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaClases
{
    public abstract class Estudiante : Persona
    {
        #region Atributos
        protected string strFacultad;
        #endregion

        #region Constructores
        public Estudiante()
        {
            strFacultad = string.Empty;
        }

        public Estudiante(string facultad)  //Sobrecargado
        {
            strFacultad = facultad;
        }
        #endregion

        #region Propiedades

        public string Facultad
        {
            get { return strFacultad; }
            set { strFacultad = value; }
        }

        #endregion

        #region Sobrecarga del método ValidarDatos

        protected override bool ValidarDatos()
        {
            if (!base.ValidarDatos())
                return false;

            if (string.IsNullOrEmpty(strFacultad))
            {
                strError = "La facultad es obligatoria";
                return false;
            }

            return true;
        }

        #endregion

        #region Métodos Protegidos

        protected override string ObtenerDatosBase()
        {
            return $"{base.ObtenerDatosBase()}|{strFacultad}";
        }

        #endregion
    }
}
