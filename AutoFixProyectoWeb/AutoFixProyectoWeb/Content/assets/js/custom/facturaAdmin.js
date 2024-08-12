
//Functions to complete the form to edit a user
function openModal(user_id) {

    document.getElementById('inputParam').value = user_id;
    $('#actualizarFactura').modal('show');


}

function actualizarFactura()
{
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
