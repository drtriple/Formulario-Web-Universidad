using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BibliotecaClases;

namespace WebApplication_University
{
	public partial class WebForm : System.Web.UI.Page
	{
        #region Metodos Logicos Web Defecto

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Inicializar los controles y mostrar la pestaña por defecto
                OcultarMensajes();
                MostrarPestaña("pregrado");
                lnkPregrado.CssClass = "nav-link active";
            }
        }

        // Método para ocultar todos los mensajes de error y éxito
        private void OcultarMensajes()
        {
            divErrorPregrado.Visible = false;
            divExitoPregrado.Visible = false;
            divErrorExtension.Visible = false;
            divExitoExtension.Visible = false;
            divErrorEmpleado.Visible = false;
            divExitoEmpleado.Visible = false;
        }

        // Método para mostrar la pestaña seleccionada y ocultar las demás
        private void MostrarPestaña(string tabName)
        {
            pregrado.Attributes["class"] = "tab-pane fade";
            extension.Attributes["class"] = "tab-pane fade";
            empleado.Attributes["class"] = "tab-pane fade";

            // Establecer la clase CSS apropiada para el enlace activo
            lnkPregrado.CssClass = "nav-link";
            lnkExtension.CssClass = "nav-link";
            lnkEmpleado.CssClass = "nav-link";


            switch (tabName)
            {
                case "pregrado":
                    pregrado.Attributes["class"] = "tab-pane fade show active";
                    lnkPregrado.CssClass = "nav-link active";
                    break;
                case "extension":
                    extension.Attributes["class"] = "tab-pane fade show active";
                    lnkExtension.CssClass = "nav-link active";
                    break;
                case "empleado":
                    empleado.Attributes["class"] = "tab-pane fade show active";
                    lnkEmpleado.CssClass = "nav-link active";
                    break;
            }

            // Guardar la pestaña activa en el hidden field
            hfActiveTab.Value = tabName;
        }

        // Eventos para los enlaces de las pestañas
        protected void lnkPregrado_Click(object sender, EventArgs e)
        {
            OcultarMensajes();
            MostrarPestaña("pregrado");
        }

        protected void lnkExtension_Click(object sender, EventArgs e)
        {
            OcultarMensajes();
            MostrarPestaña("extension");
        }

        protected void lnkEmpleado_Click(object sender, EventArgs e)
        {
            OcultarMensajes();
            MostrarPestaña("empleado");
        }

        #endregion


        #region Estudiante Pregrado

        protected void btnGuardarPregrado_Click(object sender, EventArgs e)
        {
            OcultarMensajes();

            try
            {
                // Crear instancia de Pregrado
                Pregrado pregrado = new Pregrado();

                // Asignar valores desde los controles
                pregrado.Documento = txtDocumentoPregrado.Text.Trim();
                pregrado.Nombre = txtNombrePregrado.Text.Trim();
                pregrado.FechaNac = txtFechaNacPregrado.Text;
                pregrado.Telefono = txtTelefonoPregrado.Text.Trim();
                pregrado.Facultad = txtFacultadPregrado.Text.Trim();
                pregrado.Programa = txtProgramaPregrado.Text.Trim();
                pregrado.Carnet = txtCarnetPregrado.Text.Trim();

                // Validar antes de grabar
                if (!pregrado.EsValido())
                {
                    divErrorPregrado.Visible = true;
                    lblErrorPregrado.Text = pregrado.Error;

                    // Mantener la pestaña activa
                    MostrarPestaña("pregrado");
                    return; // Detiene la ejecución si no es válido
                }


                // Intentar grabar los datos
                if (pregrado.Grabar())
                {
                    divExitoPregrado.Visible = true;
                    lblExitoPregrado.Text = "Estudiante de pregrado registrado exitosamente";
                    LimpiarFormularioPregrado();
                }
                else
                {
                    divErrorPregrado.Visible = true;
                    lblErrorPregrado.Text = pregrado.Error;
                }
            }
            catch (Exception ex)
            {
                divErrorPregrado.Visible = true;
                lblErrorPregrado.Text = "Error al procesar la solicitud: " + ex.Message;
            }

            // Mantener la pestaña activa
            MostrarPestaña("pregrado");
        }

        protected void btnLimpiarPregrado_Click(object sender, EventArgs e)
        {
            OcultarMensajes();
            LimpiarFormularioPregrado();
            MostrarPestaña("pregrado");
        }

        private void LimpiarFormularioPregrado()
        {
            txtDocumentoPregrado.Text = string.Empty;
            txtNombrePregrado.Text = string.Empty;
            txtFechaNacPregrado.Text = string.Empty;
            txtTelefonoPregrado.Text = string.Empty;
            txtFacultadPregrado.Text = string.Empty;
            txtProgramaPregrado.Text = string.Empty;
            txtCarnetPregrado.Text = string.Empty;
        }

        #endregion

        #region Estudiante Extension

        protected void btnGuardarExtension_Click(object sender, EventArgs e)
        {
            OcultarMensajes();

            try
            {
                // Crear instancia de Extension
                Extension extension = new Extension();

                // Asignar valores desde los controles
                extension.Documento = txtDocumentoExtension.Text.Trim();
                extension.Nombre = txtNombreExtension.Text.Trim();
                extension.FechaNac = txtFechaNacExtension.Text;
                extension.Telefono = txtTelefonoExtension.Text.Trim();
                extension.Facultad = txtFacultadExtension.Text.Trim();
                extension.Curso = txtCursoExtension.Text.Trim();

                // Validar antes de grabar
                if (!extension.EsValido())
                {
                    divErrorExtension.Visible = true;
                    lblErrorExtension.Text = extension.Error;

                    // Mantener la pestaña activa
                    MostrarPestaña("extension");
                    return; // Detiene la ejecución si no es válido
                }

                // Intentar grabar los datos
                if (extension.Grabar())
                {
                    divExitoExtension.Visible = true;
                    lblExitoExtension.Text = "Estudiante de extensión registrado exitosamente";
                    LimpiarFormularioExtension();
                }
                else
                {
                    divErrorExtension.Visible = true;
                    lblErrorExtension.Text = extension.Error;
                }
            }
            catch (Exception ex)
            {
                divErrorExtension.Visible = true;
                lblErrorExtension.Text = "Error al procesar la solicitud: " + ex.Message;
            }

            // Mantener la pestaña activa
            MostrarPestaña("extension");
        }

        protected void btnLimpiarExtension_Click(object sender, EventArgs e)
        {
            OcultarMensajes();
            LimpiarFormularioExtension();
            MostrarPestaña("extension");
        }

        private void LimpiarFormularioExtension()
        {
            txtDocumentoExtension.Text = string.Empty;
            txtNombreExtension.Text = string.Empty;
            txtFechaNacExtension.Text = string.Empty;
            txtTelefonoExtension.Text = string.Empty;
            txtFacultadExtension.Text = string.Empty;
            txtCursoExtension.Text = string.Empty;
        }

        #endregion

        #region Empleado

        protected void btnGuardarEmpleado_Click(object sender, EventArgs e)
        {
            OcultarMensajes();

            try
            {
                // Crear instancia de Empleado
                Empleado empleado = new Empleado();

                // Asignar valores desde los controles
                empleado.Documento = txtDocumentoEmpleado.Text.Trim();
                empleado.Nombre = txtNombreEmpleado.Text.Trim();
                empleado.FechaNac = txtFechaNacEmpleado.Text;
                empleado.Telefono = txtTelefonoEmpleado.Text.Trim();
                empleado.Cargo = txtCargoEmpleado.Text.Trim();
                empleado.Salario = Convert.ToSingle(txtSalarioEmpleado.Text.Trim());

                // Validar antes de grabar
                if (!empleado.EsValido())
                {
                    divErrorEmpleado.Visible = true;
                    lblErrorEmpleado.Text = empleado.Error;

                    // Mantener la pestaña activa
                    MostrarPestaña("empleado");
                    return; // Detiene la ejecución si no es válido
                }

                // Intentar grabar los datos
                if (empleado.Grabar())
                {
                    divExitoEmpleado.Visible = true;
                    lblExitoEmpleado.Text = "Empleado registrado exitosamente";
                    LimpiarFormularioEmpleado();
                }
                else
                {
                    divErrorEmpleado.Visible = true;
                    lblErrorEmpleado.Text = empleado.Error;
                }
            }
            catch (Exception ex)
            {
                divErrorEmpleado.Visible = true;
                lblErrorEmpleado.Text = "Error al procesar la solicitud: " + ex.Message;
            }

            // Mantener la pestaña activa
            MostrarPestaña("empleado");
        }

        protected void btnLimpiarEmpleado_Click(object sender, EventArgs e)
        {
            OcultarMensajes();
            LimpiarFormularioEmpleado();
            MostrarPestaña("empleado");
        }

        private void LimpiarFormularioEmpleado()
        {
            txtDocumentoEmpleado.Text = string.Empty;
            txtNombreEmpleado.Text = string.Empty;
            txtFechaNacEmpleado.Text = string.Empty;
            txtTelefonoEmpleado.Text = string.Empty;
            txtCargoEmpleado.Text = string.Empty;
            txtSalarioEmpleado.Text = string.Empty;
        }

        #endregion

    }
}