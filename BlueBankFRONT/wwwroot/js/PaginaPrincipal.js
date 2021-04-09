$.ajaxSetup({
    data: {
        __RequestVerificationToken: document.getElementsByName("__RequestVerificationToken")[0].value
    }
});

function AddCuentaMostrar() {
    document.getElementById('FormConsultarSaldo').style.display = "none";
    $("#formCuenta").dxForm("instance").option("visible", true);
    $("#formCuenta").dxForm("instance").option("disabled", false);
    $("#formCuenta").dxForm("instance").resetValues();
}

function ConsultarSaldoMostrar() {
    document.getElementById('FormConsultarSaldo').style.display = "block";
    $("#formCuenta").dxForm("instance").option("visible", true);
    $("#formCuenta").dxForm("instance").option("disabled", true);
    $("#formCuenta").dxForm("instance").resetValues();
}

function RetirarMostrar() {
    document.getElementById('FormRetirar').style.display = "block";
}

function ConsignarMostrar() {
    document.getElementById('FormConsignar').style.display = "block";
}

function BuscarCuenta() {
    var NumeroCuenta = $("#NumeroCuentaBuscar").dxTextBox("instance").option("value"); 
    $.ajax({
        url: "/Index?handler=ConsultarCuenta",
        type: "post",
        data: { NumeroCuenta: NumeroCuenta },
        success: function (data) {
            $("#formCuenta").dxForm("instance").option("formData", data);
        }

    });
}

function EnviarCuenta() {
    var Cuenta = $("#formCuenta").dxForm("instance").option("formData");
    $.ajax({
        url: "/Index?handler=CrearCuenta",
        type: "post",
        data: { Cuenta: Cuenta },
        success: function (data) {
           
        }

    });
}