using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication_University
{
	public partial class WebForm : System.Web.UI.Page
	{
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
    }
}