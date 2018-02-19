<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ReportesSCO.Default" %>

<!DOCTYPE html >
<html lang="en">
<head>
    <title>Acceso al Repositorio de Reportes</title>
    <meta name="viewport" content="width=device-width, initial-escale=1.0" />
    <meta http-equiv="content-type" content="text/html; charset=UTF-8" />
    <link href="Assets/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="Assets/css/bootstrap-theme.min.css" rel="stylesheet" type="text/css" />
    <link href="Assets/alerts/sweetalert2.min.css" rel="stylesheet" type="text/css" />
    <link href="Css/login.css" rel="stylesheet" type="text/css" />
    
    <script src="Assets/js/jquery.js" type="text/javascript"></script>
    <script src="Assets/js/bootstrap.js" type="text/javascript"></script>
    <script src="Assets/alerts/sweetalert2.min.js" type="text/javascript"></script>
    <script src="scripts/login.js" type="text/javascript"></script>

    <script type="text/javascript">
        function CheckIfPageIsInFrame() {//Si el logín se encuentra dentro del iFrame, salirse del Iframe
            var isInIFrame = window.location !== window.parent.location ? true : false;
            if (isInIFrame)
            { window.parent.location = "Default.aspx"; }
        }
        window.onload = CheckIfPageIsInFrame();
    </script>
</head>
<body style="background-color: #e3e3e3;">
    <!--divVentanaLogin-->
    <div class="boxlogin2">
        <div class="container-fluid">
            <form name="flogin" runat="server">
            <div class="panel-primary">
                <div class="panel-heading text-center">
                    Repositorio de Reportes
                </div>
                <div class="panel-body">
                    <div class="row">
                        <div class=" col-xs-6 text-center">
                            <img alt="" src="Imagenes/LOGOS-CIDIM-IPN.jpg" width="100%" height="100%"/>
                        </div>
                        <div class="col-xs-6 text-center">
                            <div class="col-xs-4" style="padding: 10px 15px; font-weight: bolder">
                                <span>Usuario:</span>
                            </div>
                            <div class=" col-xs-8 text-center">
                                <asp:TextBox ID="txt_Usuario" CssClass="form-control" MaxLength="20" runat="server"></asp:TextBox>
                            </div>
                            <div class="clearfix">
                            </div>
                            <div class="col-xs-4" style="padding: 10px 15px; font-weight: bolder">
                                <span>Password:</span>
                            </div>
                            <div class=" col-xs-8 text-center">
                                <asp:TextBox ID="txt_Password" CssClass="form-control" MaxLength="15" runat="server"
                                    TextMode="Password"></asp:TextBox>
                            </div>
                            <div class="clearfix">
                            </div>
                            <div class="col-xs-4" style="padding: 10px 15px; font-weight: bolder">
                            </div>
                            <div class=" col-xs-8 text-center">
                                <button type="button" id="BtnAcceso" class="btn btn-success form-control top">
                                    <span> Acceso </span>
                                </button>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            </form>
        </div>
    </div>
</body>
</html>

