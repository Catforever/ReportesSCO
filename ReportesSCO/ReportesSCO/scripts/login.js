$(document).ready(function () {

    $("#BtnAcceso").click(function () {
        //var parametros = $("#txt_Usuario").val() + "?" +
        //                 $("#txt_Password").val();

        if ($("#txt_Usuario").val() === "Repositorio" && $("#txt_Password").val() === "Cidimipn") {
            window.location.href = "VisorDocumentos.aspx?parametrosurl=" + btoa($("#txt_Usuario").val() + "©" + $("#txt_Password").val());
        }
        else {
            swal("Error", "Usuario Y/O Contraseña no valido", "error");
            $("#txt_Password").val("");
        }
        //var actionData = "{'parametros': '" + parametros + "'}";
        //$.ajax({
        //    type: "POST",
        //    url: "Default.aspx/ValidaAcceso2",
        //    data: actionData,
        //    cache: false,
        //    async: false,
        //    contentType: "application/json; charset=utf-8",
        //    dataType: "json",
        //    success: function (msg) {
        //        if (msg.d === "-1") {
        //            swal("Error", "Usuario Y/O Contraseña no valido", "error");
        //            $("#txt_Password").val("");
        //        }
        //        else {
        //            window.location.href = "aspx/Menu.aspx?parametrosurl=" + btoa(msg.d);
        //        }
        //    },
        //    error: function () {
        //        swal("Error", "Error en la red favor de consultar con el administrador de sistema", "error");
        //    }
        //});
    }); //termina click del boton 
}); //termina documen.ready

