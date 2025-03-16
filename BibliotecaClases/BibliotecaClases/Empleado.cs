using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaClases
{
    public class Empleado : Persona
    {
        #region Atributos

        private string strCargo;
        private float fltSalario;

        #endregion

        #region Propiedades
        public string Cargo
        {
            get { return strCargo; }
            set { strCargo = value; }
        }

        public float Salario
        {
            get { return fltSalario; }
            set { fltSalario = value; }
        }

        #endregion

        #region Constructores
        public Empleado()
        {
            strCargo = string.Empty;
            fltSalario = 0;
        }

        public Empleado(string cargo, float salario)
        {
            strCargo = cargo;
            fltSalario = salario;
        }
        #endregion

        #region Sobrecarga del método ValidarDatos

        protected override bool ValidarDatos()
        {
            if (!base.ValidarDatos())
                return false;

            if (string.IsNullOrEmpty(strCargo))
            {
                strError = "El cargo es obligatorio";
                return false;
            }

            if (fltSalario <= 0)
            {
                strError = "El salario debe ser mayor que cero";
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
                string rutaDatabase = Path.Combine(rutaBase, "database", "empleado.txt");

                // Normalizar la ruta para evitar problemas de formato
                string rutaArchivo = Path.GetFullPath(rutaDatabase);

                string contenido = $"{ObtenerDatosBase()}|{strCargo}|{fltSalario}";

                // Verificar si el archivo existe para decidir si añadir cabecera
                bool archivoExiste = File.Exists(rutaArchivo);

                using (StreamWriter sw = new StreamWriter(rutaArchivo, true))
                {
                    // Si el archivo no existe, agregar encabezado
                    if (!archivoExiste)
                    {
                        sw.WriteLine("Documento|Nombres|FechaNacimiento|Telefono|Cargo|Salario");
                    }

                    sw.WriteLine(contenido);
                }

                return true;
            }
            catch (Exception ex)
            {
                strError = $"Error al grabar empleado: {ex.Message}";
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
