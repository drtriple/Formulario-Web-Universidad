using System;
using System.Configuration;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaClases
{
    public class Pregrado : Estudiante
    {
        #region Atributos

        private string strPrograma;
        private string strCarnet;

        #endregion

        #region Propiedades

        public string Programa
        {
            get { return strPrograma; }
            set { strPrograma = value; }
        }

        public string Carnet
        {
            get { return strCarnet; }
            set { strCarnet = value; }
        }

        #endregion

        #region Constructor

        public Pregrado()
        {
            strPrograma = string.Empty;
            strCarnet = string.Empty;
        }

        public Pregrado(string programa, string carnet) //Sobrecargado
        {
            strPrograma = programa;
            strCarnet = carnet;
        }

        #endregion

        #region Sobrecarga del método ValidarDatos
        protected override bool ValidarDatos()
        {
            if (!base.ValidarDatos())
                return false;

            if (string.IsNullOrEmpty(strPrograma))
            {
                strError = "El programa es obligatorio";
                return false;
            }

            if (string.IsNullOrEmpty(strCarnet))
            {
                strError = "El carnet es obligatorio";
                return false;
            }

            return true;
        }

        #endregion

        #region Métodos Publicos
        public override bool Grabar()
        {
            try
            {
                // Obtener la ruta base del proyecto en ejecución (WebApplication_University)
                string rutaBase = AppDomain.CurrentDomain.BaseDirectory;
                // Subir dos niveles y moverse a la carpeta "database"
                string rutaDatabase = Path.Combine(rutaBase, "database", "pregrado.txt");

                // Normalizar la ruta para evitar problemas de formato
                string rutaArchivo = Path.GetFullPath(rutaDatabase);

                //string rutaArchivo = $"{rutaBase}\\pregrado.txt";
                string contenido = $"{ObtenerDatosBase()}|{strPrograma}|{strCarnet}";

                // Verificar si el archivo existe para decidir si añadir cabecera
                bool archivoExiste = File.Exists(rutaArchivo);

                using (StreamWriter sw = new StreamWriter(rutaArchivo, true))
                {
                    // Si el archivo no existe, agregar encabezado
                    if (!archivoExiste)
                    {
                        sw.WriteLine("Documento|Nombres|FechaNacimiento|Telefono|Facultad|Programa|Carnet");
                    }

                    sw.WriteLine(contenido);
                }

                return true;
            }
            catch (Exception ex)
            {
                strError = $"Error al grabar estudiante de pregrado: {ex.Message}";
                return false;
            }
        }

        public bool EsValido()
        {
            return ValidarDatos();
        }

        #endregion

        #region Metodos Protegidos

        protected override string ObtenerDatosBase()
        {
            return $"{base.ObtenerDatosBase()}";
        }

        #endregion
    }
}
