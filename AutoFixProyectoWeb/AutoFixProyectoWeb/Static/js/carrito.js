var defaultOptions = {min:0}; $('[data-toggle="touchspin"]').each(function (t, a) { var n = $.extend({}, defaultOptions, $(a).data()); $(a).TouchSpin(n) });

$("input").on("change", function () {
    let cantProducto = parseInt($(this).val());
    let inventario = parseInt($(this).parent().siblings('.inventario').val());
    let idProducto = parseInt($(this).parent().siblings('.idProducto').val());
    if (cantProducto > inventario) {
        $("#errorModal1").modal('show');
        return;
    }
    else if (cantProducto <= 0) {
        $("#errorModal2").modal('show');
        return;
    }
    else {
        $.ajax({
            url: '/Carrito/AgregarCarrito',
            type: "POST",
            data:
            {
                "IdProducto": idProducto,
                "Cantidad": cantProducto
            },
            success: function (data) {
                if (data == "OK") {
                    window.location.href = "/Carrito/ConsultarCarrito";
                }
                else {
                    alert(data);
                }
            }
        });
    }
    

    
});
$("#btn-realizar-pedido").on("click", function () {
    let total = parseInt($("#total").val());
    let saldo = parseInt($("#saldo").val());
    if (total > saldo) {
        $("#errorModal3").modal('show');
        return;
    }
    else {
        $.ajax({
            url: '/Pedido/RealizarPedido',
            type: "POST",
            success: function (data) {
                if (data == "OK") {
                    Swal.fire({
                        position: "center",
                        icon: "success",
                        title: "Pedido realizado exitosamente",
                        showConfirmButton: false,
                        timer: 2500
                    }).then(() => {
                        window.location.href = "/Inicio/PantallaPrincipal";
                    });
                }
                else {
                    alert(data);
                }
            }
        });
    }

    
});