
//Functions to complete the form to edit a user

function init() {
    consultarTodos();
};

function openModal(user_id) {

    document.getElementById('inputParam').value = user_id;
    $('#procesarPago').modal('show');


}

function procesarPago() {
    var id_factura = document.getElementById('inputParam').value;
    var metodoPago = document.getElementById('txtMetodoPago').value
    $.ajax(
        {
            url: "/Facturacion/actualizarFacturaAdminController",
            type: "POST",
            data: {
                "idFactura": id_factura,
                "metodoPago": metodoPago
            },

            dataType: "json",
            success: function (data) {
                location.reload();

            },
            error: function (xhr, status, error) {
                // Handle errors here

            }
        })
}

function consultarTodos() {
    //Pendiente modificar traer vehiculos por usuario o por admin 
    //Puede ser con el rol guardado en el modelo o en el cookie 
    $.ajax(
        {
            url: "/Facturacion/getFacturaController",
            type: "GET",
            dataType: "json",
            success: function (data) {

                cargarLista(data);
            },
            error: function (xhr, status, error) {
                // Handle errors here
                document.getElementById('errorAlert').style.display = "";
            }
        })

}
function consultarPorID(event) {
    var item = event.target.closest('.seccion-editar');
    var id_factura = item.querySelector('.idFactura').textContent;

    $.ajax(
        {
            url: "/Facturacion/getFacturaPorIDModel",
            type: "POST",
            dataType: "json",
            data: {
                "id_factura": id_factura
            },
            success: function (data) {

                var modal = $('#actualizarFactura');
                modal.modal('show');

                console.log(data);
                modal.find('#txtIDFactura').val(data.id_factura);
                modal.find('#txtIDUsuario').val(data.id_usuario);
                modal.find('#txtDetalle').val(data.detalle);
                modal.find('#txtMonto').val(data.monto);
            },
            error: function (xhr, status, error) {
                console.log(error);
                // Handle errors here
                //document.getElementById('errorAlert').style.display = "";
            }
        })
}

function cargarLista(factura) {

    var btnActualizar = document.querySelectorAll('.btn-editar');
    btnActualizar.forEach(function (button) {
        button.addEventListener('click', consultarPorID)
    });

}
    function actualizarFactura() {

        var modal = $('#actualizarFactura');
        var id_factura = modal.find('#txtIDFactura').val();
        var id_usuario = modal.find('#txtIDUsuario').val();
        var detalle = modal.find('#txtDetalle').val();
        var monto = modal.find('#txtMonto').val();
        if (id_factura === '' || id_usuario === '' || detalle === '' || monto === '') {
            alert('Por favor complete todos los campos.');
            return;
        }
        $.ajax(
            {
                url: "/Facturacion/actualizarFacturaController",
                type: "POST",
                data: {
                    "id_factura": id_factura,
                    "id_usuario": id_usuario,
                    "detalle": detalle,
                    "monto": monto

                },

                dataType: "json",
                success: function (data) {
                    location.reload();

                },
                error: function (xhr, status, error) {
                    // Handle errors here

                }
            })
}


$(document).on('click', '.btn-eliminar', function () {
    var idFactura = $(this).data("id-factura");
    $('#idFacturaEliminar').val(idFactura);
});

function eliminarFactura() {
    var id_factura = $('#idFacturaEliminar').val();
    $.ajax(
        {
            url: "/Facturacion/eliminarFacturaController",
            type: "POST",
            data: {
                "id_factura": id_factura
            },

            dataType: "json",
            success: function (data) {

                location.reload();

            },
            error: function (xhr, status, error) {
                // Handle errors here

                // document.getElementById('errorAlert').style.display = "";
            }
        })
}


init();