$(".btn-detalle-pedido").on("click", function (e) {
    var thisId = this.id;
    window.location.href = "/Pedido/ConsultarDetallePedido?IdPedido=" + thisId;
});
$(".select2").select2({
    minimumResultsForSearch: -1,
    width: "resolve"
});

$(".select2").on("select2:select", function (e) {
    let consecutivo = parseInt($(this).parents("tr").find("input").val());
    var data = e.params.data;
    let estado = data.id;
    $.ajax({
        url: '/Pedido/ActualizarEstadoPedido',
        type: "POST",
        data:
        {
            "Consecutivo": consecutivo,
            "Estado": estado
        },
        success: function (data) {
            if (data == "OK") {
                window.location.href = "/Pedido/ConsultarPedidos";
            }
            else {
                alert(data);
            }
        }
    });
});