$.ajaxSetup({
    data: {
        __RequestVerificationToken: document.getElementsByName("__RequestVerificationToken")[0].value
    }
});

function AddCuentaMostrar() {
    document.getElementById('FormCuentasDiv').style.display = "block"; 
    document.getElementById('FormMovimientosDiv').style.display = "none";
    document.getElementById('FormConsultarSaldo').style.display = "none";
    $("#formCuenta").dxForm("instance").option("visible", true);
    $("#formCuenta").dxForm("instance").option("disabled", false);
    $("#formCuenta").dxForm("instance").resetValues();
    $("#btnEnviarCuenta").dxButton("instance").option("visible", true);
}

function ConsultarSaldoMostrar() {
    document.getElementById('FormCuentasDiv').style.display = "block";
    document.getElementById('FormMovimientosDiv').style.display = "none";
    document.getElementById('FormConsultarSaldo').style.display = "block";
    $("#formCuenta").dxForm("instance").option("visible", true);
    $("#formCuenta").dxForm("instance").option("disabled", true);
    $("#formCuenta").dxForm("instance").resetValues();
    $("#btnEnviarCuenta").dxButton("instance").option("visible", false);
}

function RetirarMostrar() {
    document.getElementById('FormCuentasDiv').style.display = "none";
    document.getElementById('FormMovimientosDiv').style.display = "block";
    $("#formMovimiento").dxForm("instance").getEditor("Valor").option("value", -1000);
    $("#btnEnviarMovimiento").dxButton("instance").option("text", "Retirar");
}

function ConsignarMostrar() {
    document.getElementById('FormCuentasDiv').style.display = "none";
    document.getElementById('FormMovimientosDiv').style.display = "block";
    $("#formMovimiento").dxForm("instance").getEditor("Valor").option("value", 1000);
    $("#btnEnviarMovimiento").dxButton("instance").option("text", "Consignar");
}

function BuscarCuenta() {
    var NumeroCuenta = $("#NumeroCuentaBuscar").dxTextBox("instance").option("value"); 
    $.ajax({
        url: "/Index?handler=ConsultarCuenta",
        type: "post",
        data: { NumeroCuenta: NumeroCuenta },
        success: function (data) {
            $("#formCuenta").dxForm("instance").option("formData", data);

            Swal.fire({

                icon: 'success',
                title: 'Registro encontrado',
                showConfirmButton: false,
                timer: 1500
            })
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
            console.log(data);

            Swal.fire({

                icon: 'success',
                title: 'Cuenta creada',
                showConfirmButton: false,
                timer: 1500
            })
        }

    });
}

function EnviarMovimiento() {
    var Movimiento = $("#formMovimiento").dxForm("instance").option("formData");
    $.ajax({
        url: "/Index?handler=EnviarMovimiento",
        type: "post",
        data: { Movimiento: Movimiento },
        success: function (data) {
            $("#formMovimiento").dxForm("instance").resetValues();

            console.log(data);

            Swal.fire({
                
                icon: 'success',
                title: 'Movimiento realizado',
                showConfirmButton: false,
                timer: 1500
            })
        }

    });
}