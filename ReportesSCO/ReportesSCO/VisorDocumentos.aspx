<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VisorDocumentos.aspx.cs" Inherits="ReportesSCO.VisorDocumentos" %>


<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="CSS/General.css" rel="stylesheet" />
    <script src="clases/scripts.js" type="text/javascript"></script>
    <script>
        function fileOpen(sender, args) {
            var wndMng = sender.get_windowManager();
            wndMng.set_width(800);
            wndMng.set_height(800);
        }
    </script>
    <script type="text/javascript">
        function OnClientLoad(oExplorer, args) {
            var grid = oExplorer.get_grid();
            grid.add_command(sortCommandHandler);

        }

        function sortCommandHandler() {
            if (args.get_commandName() == "Sort") {
                //add custom code here
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div id="encabezado">
            <img src="Imagenes/Reportes-Tecnicos-SCO-Administracion-de-la-Integridad-Mecanica-BANNER.jpg" />
        </div>

        <telerik:RadScriptManager ID="RadScriptManager2" runat="server" AjaxFrameworkMode="Enabled" ScriptMode="Auto">
        </telerik:RadScriptManager>
        <telerik:RadFileExplorer ID="RadFileExplorer" runat="server" RenderMode="Classic" Width="1080px" Height="750px"
            AllowPaging="true" Language="es-MX" style="top: 105px; left: 25%" EnableCreateNewFolder="false" PageSize="25" ExplorerMode="Default"
            OnClientFileOpen="fileOpen" EnableFilterTextBox="true" OnClientFilter="OnClientFilter" FilterTextBoxLabel="FILTRAR POR:" OnExplorerPopulated="RadFileExplorer1_ExplorerPopulated">
            <%--OnClientLoad="OnClientLoad"--%>
            <configuration searchpatterns="*.pdf" viewpaths="/visorsco/REGION/" uploadpaths="/visorsco/REGION/" maxuploadfilesize="104857600"></configuration>
        </telerik:RadFileExplorer>
    </form>
</body>
</html>
