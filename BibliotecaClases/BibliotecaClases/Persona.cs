using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaClases
{
    //Persona: Clase abstracta base con propiedades para documento, nombres, fecha de nacimiento, teléfono y control de errores. Incluye un método abstracto Grabar().
    public abstract class Persona
    {
        #region Atributos

        protected string strDocumento;
        protected string strNombres;
        protected DateTime dtmFechaNac;
        protected string strTelefono;
        protected string strError;

        #endregion

        #region Constructores
        public Persona()
        {
            strDocumento = string.Empty;
            strNombres = string.Empty;
            dtmFechaNac = DateTime.Now;
            strTelefono = string.Empty;
            strError = string.Empty;
        }

        #endregion

        #region Propiedades
        public string Documento
        {
            get { return strDocumento; }
            set { strDocumento = value; }
        }

        public string Nombre
        {
            get { return strNombres; }
            set { strNombres = value; }
        }

        public string FechaNac
        {
            get { return dtmFechaNac.ToString("yyyy-MM-dd"); }
            set { dtmFechaNac = DateTime.Parse(value); }
        }

        public string Telefono
        {
            get { return strTelefono; }
            set { strTelefono = value; }
        }

        public string Error
        {
            get { return strError; }
        }
        #endregion

        #region Validar General
        // Solo las clases derivadas pueden acceder a él (protected).
        // Las clases derivadas pueden sobrescribir su comportamiento (virtual)

        protected virtual bool ValidarDatos()
        {
            if (string.IsNullOrEmpty(strDocumento))
            {
                strError = "El documento es obligatorio";
                return false;
            }

            if (string.IsNullOrEmpty(strNombres))
            {
                strError = "El nombre es obligatorio";
                return false;
            }

            if (dtmFechaNac > DateTime.Now)
            {
                strError = "La fecha de nacimiento no puede ser mayor a la fecha actual";
                return false;
            }

            return true;
        }

        #endregion

        #region Métodos Publicos
        public abstract bool Grabar();

        #endregion

        #region Metodo Protegido

        protected virtual string ObtenerDatosBase()
        {
            return $"{strDocumento}|{strNombres}|{dtmFechaNac.ToShortDateString()}|{strTelefono}";
        }

        #endregion
    }
}
