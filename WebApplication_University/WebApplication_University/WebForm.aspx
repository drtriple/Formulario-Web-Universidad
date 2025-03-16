<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm.aspx.cs" Inherits="WebApplication_University.WebForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Sistema Universidad</title>
    <!-- Referencias a Bootstrap -->
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.0.0/dist/css/bootstrap.min.css" crossorigin="anonymous"/>
    <script src="https://code.jquery.com/jquery-3.2.1.slim.min.js" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.12.9/dist/umd/popper.min.js" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@4.0.0/dist/js/bootstrap.min.js" crossorigin="anonymous"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container mt-4">
            <div class="row">
                <div class="col-12">
                    <h2 class="mb-4">Sistema Universidad</h2>
                    
                    <div class="card">
                        <div class="card-header">
                            <asp:HiddenField ID="hfActiveTab" runat="server" Value="pregrado" />
                            <ul class="nav nav-tabs card-header-tabs" id="myTab" role="tablist">
                                <li class="nav-item" role="presentation">
                                    <asp:LinkButton ID="lnkPregrado" runat="server" CssClass="nav-link" OnClick="lnkPregrado_Click">Pregrado</asp:LinkButton>
                                </li>
                                <li class="nav-item" role="presentation">
                                    <asp:LinkButton ID="lnkExtension" runat="server" CssClass="nav-link" OnClick="lnkExtension_Click">Extensión</asp:LinkButton>
                                </li>
                                <li class="nav-item" role="presentation">
                                    <asp:LinkButton ID="lnkEmpleado" runat="server" CssClass="nav-link" OnClick="lnkEmpleado_Click">Empleado</asp:LinkButton>
                                </li>
                            </ul>
                        </div>
                        <div class="card-body">
                            <div class="tab-content" id="myTabContent">
                                <!-- Pestaña de Pregrado -->
                                <div class="tab-pane fade" id="pregrado" runat="server">
                                    <h4 class="mb-3">Registro de Estudiante de Pregrado</h4>
                                    
                                    <div class="row mb-3">
                                        <div class="col-md-6">
                                            <label for="txtDocumentoPregrado" class="form-label">Documento</label>
                                            <asp:TextBox ID="txtDocumentoPregrado" runat="server" CssClass="form-control" placeholder="Ingrese número de documento"></asp:TextBox>
                                        </div>
                                        <div class="col-md-6">
                                            <label for="txtNombrePregrado" class="form-label">Nombres</label>
                                            <asp:TextBox ID="txtNombrePregrado" runat="server" CssClass="form-control" placeholder="Ingrese nombres completos"></asp:TextBox>
                                        </div>
                                    </div>
                                    
                                    <div class="row mb-3">
                                        <div class="col-md-6">
                                            <label for="txtFechaNacPregrado" class="form-label">Fecha de Nacimiento</label>
                                            <asp:TextBox ID="txtFechaNacPregrado" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                                        </div>
                                        <div class="col-md-6">
                                            <label for="txtTelefonoPregrado" class="form-label">Teléfono</label>
                                            <asp:TextBox ID="txtTelefonoPregrado" runat="server" CssClass="form-control" placeholder="Ingrese número telefónico"></asp:TextBox>
                                        </div>
                                    </div>
                                    
                                    <div class="row mb-3">
                                        <div class="col-md-6">
                                            <label for="txtFacultadPregrado" class="form-label">Facultad</label>
                                            <asp:TextBox ID="txtFacultadPregrado" runat="server" CssClass="form-control" placeholder="Ingrese facultad"></asp:TextBox>
                                        </div>
                                        <div class="col-md-6">
                                            <label for="txtProgramaPregrado" class="form-label">Programa</label>
                                            <asp:TextBox ID="txtProgramaPregrado" runat="server" CssClass="form-control" placeholder="Ingrese programa académico"></asp:TextBox>
                                        </div>
                                    </div>
                                    
                                    <div class="row mb-3">
                                        <div class="col-md-6">
                                            <label for="txtCarnetPregrado" class="form-label">Carnet</label>
                                            <asp:TextBox ID="txtCarnetPregrado" runat="server" CssClass="form-control" placeholder="Ingrese número de carnet"></asp:TextBox>
                                        </div>
                                    </div>
                                    
                                    <div class="row mb-3">
                                        <div class="col-12">
                                            <asp:Button ID="btnGuardarPregrado" runat="server" Text="Guardar" CssClass="btn btn-primary" OnClick="btnGuardarPregrado_Click" /> <!--  -->
                                            <asp:Button ID="btnLimpiarPregrado" runat="server" Text="Limpiar" CssClass="btn btn-secondary" OnClick="btnLimpiarPregrado_Click" /> <!--  -->
                                        </div>
                                    </div>
                                    
                                    <div class="row">
                                        <div class="col-12">
                                            <div class="alert alert-danger" id="divErrorPregrado" runat="server" visible="false">
                                                <asp:Label ID="lblErrorPregrado" runat="server" Text=""></asp:Label>
                                            </div>
                                            <div class="alert alert-success" id="divExitoPregrado" runat="server" visible="false">
                                                <asp:Label ID="lblExitoPregrado" runat="server" Text=""></asp:Label>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                
                                <!-- Pestaña de Extensión -->
                                <div class="tab-pane fade" id="extension" runat="server">
                                    <h4 class="mb-3">Registro de Estudiante de Extensión</h4>
                                    
                                    <div class="row mb-3">
                                        <div class="col-md-6">
                                            <label for="txtDocumentoExtension" class="form-label">Documento</label>
                                            <asp:TextBox ID="txtDocumentoExtension" runat="server" CssClass="form-control" placeholder="Ingrese número de documento"></asp:TextBox>
                                        </div>
                                        <div class="col-md-6">
                                            <label for="txtNombreExtension" class="form-label">Nombres</label>
                                            <asp:TextBox ID="txtNombreExtension" runat="server" CssClass="form-control" placeholder="Ingrese nombres completos"></asp:TextBox>
                                        </div>
                                    </div>
                                    
                                    <div class="row mb-3">
                                        <div class="col-md-6">
                                            <label for="txtFechaNacExtension" class="form-label">Fecha de Nacimiento</label>
                                            <asp:TextBox ID="txtFechaNacExtension" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                                        </div>
                                        <div class="col-md-6">
                                            <label for="txtTelefonoExtension" class="form-label">Teléfono</label>
                                            <asp:TextBox ID="txtTelefonoExtension" runat="server" CssClass="form-control" placeholder="Ingrese número telefónico"></asp:TextBox>
                                        </div>
                                    </div>
                                    
                                    <div class="row mb-3">
                                        <div class="col-md-6">
                                            <label for="txtFacultadExtension" class="form-label">Facultad</label>
                                            <asp:TextBox ID="txtFacultadExtension" runat="server" CssClass="form-control" placeholder="Ingrese facultad"></asp:TextBox>
                                        </div>
                                        <div class="col-md-6">
                                            <label for="txtCursoExtension" class="form-label">Curso</label>
                                            <asp:TextBox ID="txtCursoExtension" runat="server" CssClass="form-control" placeholder="Ingrese curso de extensión"></asp:TextBox>
                                        </div>
                                    </div>
                                    
                                    <div class="row mb-3">
                                        <div class="col-12">
                                            <asp:Button ID="btnGuardarExtension" runat="server" Text="Guardar" CssClass="btn btn-primary"  OnClick="btnGuardarExtension_Click" /> <!--  -->
                                            <asp:Button ID="btnLimpiarExtension" runat="server" Text="Limpiar" CssClass="btn btn-secondary" OnClick="btnLimpiarExtension_Click" /> <!--   -->
                                        </div>
                                    </div>
                                    
                                    <div class="row">
                                        <div class="col-12">
                                            <div class="alert alert-danger" id="divErrorExtension" runat="server" visible="false">
                                                <asp:Label ID="lblErrorExtension" runat="server" Text=""></asp:Label>
                                            </div>
                                            <div class="alert alert-success" id="divExitoExtension" runat="server" visible="false">
                                                <asp:Label ID="lblExitoExtension" runat="server" Text=""></asp:Label>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                
                                <!-- Pestaña de Empleado -->
                                <div class="tab-pane fade" id="empleado" runat="server">
                                    <h4 class="mb-3">Registro de Empleado</h4>
                                    
                                    <div class="row mb-3">
                                        <div class="col-md-6">
                                            <label for="txtDocumentoEmpleado" class="form-label">Documento</label>
                                            <asp:TextBox ID="txtDocumentoEmpleado" runat="server" CssClass="form-control" placeholder="Ingrese número de documento"></asp:TextBox>
                                        </div>
                                        <div class="col-md-6">
                                            <label for="txtNombreEmpleado" class="form-label">Nombres</label>
                                            <asp:TextBox ID="txtNombreEmpleado" runat="server" CssClass="form-control" placeholder="Ingrese nombres completos"></asp:TextBox>
                                        </div>
                                    </div>
                                    
                                    <div class="row mb-3">
                                        <div class="col-md-6">
                                            <label for="txtFechaNacEmpleado" class="form-label">Fecha de Nacimiento</label>
                                            <asp:TextBox ID="txtFechaNacEmpleado" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                                        </div>
                                        <div class="col-md-6">
                                            <label for="txtTelefonoEmpleado" class="form-label">Teléfono</label>
                                            <asp:TextBox ID="txtTelefonoEmpleado" runat="server" CssClass="form-control" placeholder="Ingrese número telefónico"></asp:TextBox>
                                        </div>
                                    </div>
                                    
                                    <div class="row mb-3">
                                        <div class="col-md-6">
                                            <label for="txtCargoEmpleado" class="form-label">Cargo</label>
                                            <asp:TextBox ID="txtCargoEmpleado" runat="server" CssClass="form-control" placeholder="Ingrese cargo"></asp:TextBox>
                                        </div>
                                        <div class="col-md-6">
                                            <label for="txtSalarioEmpleado" class="form-label">Salario</label>
                                            <asp:TextBox ID="txtSalarioEmpleado" runat="server" CssClass="form-control" placeholder="Ingrese salario" TextMode="Number" Step="0.01"></asp:TextBox>
                                        </div>
                                    </div>
                                    
                                    <div class="row mb-3">
                                        <div class="col-12">
                                            <asp:Button ID="btnGuardarEmpleado" runat="server" Text="Guardar" CssClass="btn btn-primary"  OnClick="btnGuardarEmpleado_Click" /> <!--  -->
                                            <asp:Button ID="btnLimpiarEmpleado" runat="server" Text="Limpiar" CssClass="btn btn-secondary" OnClick="btnLimpiarEmpleado_Click" /> <!--   -->
                                        </div>
                                    </div>
                                    
                                    <div class="row">
                                        <div class="col-12">
                                            <div class="alert alert-danger" id="divErrorEmpleado" runat="server" visible="false">
                                                <asp:Label ID="lblErrorEmpleado" runat="server" Text=""></asp:Label>
                                            </div>
                                            <div class="alert alert-success" id="divExitoEmpleado" runat="server" visible="false">
                                                <asp:Label ID="lblExitoEmpleado" runat="server" Text=""></asp:Label>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>