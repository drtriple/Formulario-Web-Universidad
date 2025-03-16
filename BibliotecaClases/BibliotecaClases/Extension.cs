using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaClases
{
    public class Extension : Estudiante
    {
        #region Atributos

        private string strCurso;

        #endregion

        #region Propiedades

        public string Curso
        {
            get { return strCurso; }
            set { strCurso = value; }
        }

        #endregion

        #region Constructores
        public Extension() : base()
        {
            strCurso = string.Empty;
        }

        public Extension(string curso) //Sobrecargado
        {
            strCurso = curso;
        }

        #endregion

        #region Sobrecarga del método ValidarDatos

        protected override bool ValidarDatos()
        {
            if (!base.ValidarDatos())
                return false;

            if (string.IsNullOrEmpty(strCurso))
            {
                strError = "El curso es obligatorio";
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
                string rutaDatabase = Path.Combine(rutaBase, "database", "extension.txt");

                // Normalizar la ruta para evitar problemas de formato
                string rutaArchivo = Path.GetFullPath(rutaDatabase);

                string contenido = $"{ObtenerDatosBase()}|{strCurso}";

                // Verificar si el archivo existe para decidir si añadir cabecera
                bool archivoExiste = File.Exists(rutaArchivo);

                using (StreamWriter sw = new StreamWriter(rutaArchivo, true))
                {
                    // Si el archivo no existe, agregar encabezado
                    if (!archivoExiste)
                    {
                        sw.WriteLine("Documento|Nombres|FechaNacimiento|Telefono|Facultad|Curso");
                    }

                    sw.WriteLine(contenido);
                }

                return true;
            }
            catch (Exception ex)
            {
                strError = $"Error al grabar estudiante de extensión: {ex.Message}";
                return false;
            }
        }

        public bool EsValido()
        {
            return ValidarDatos();
        }

        #endregion

        #region Métodos Protegidos
        protected override string ObtenerDatosBase()
        {
            return $"{base.ObtenerDatosBase()}";
        }
        #endregion
    }
}
