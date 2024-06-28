$(document).ready(function () {
    var defaultOptions = {min: -999, max: 999};
    $('[data-toggle="touchspin"]').each(function (t, a) {
        var n = $.extend({}, defaultOptions, $(a).data());
        $(a).TouchSpin(n);
    });
    var searchParams = new URLSearchParams(window.location.search);
    let precio = searchParams.get("precio") ?? 10000;
    $("#pricerange").ionRangeSlider({
        skin: "round",
        grid: !0,
        min: 0,
        max: 10000,
        step: 50,
        from: precio,
        prefix: "₡",
        onFinish: function (data) {
            console.log(data.from);
            let url = redirectParams("precio", data.from);
            console.log(url);
            window.location.href = url;
        },
    });
});

$("#btn-remover-filtro").on("click", function (e) {
    window.location.href = window.location.href.split('?')[0];
});
$("#btn-categoria").on("click", function (e) {
    $("#btn-promocion").addClass("collapsed");
    $("#btn-vendido").addClass("collapsed");
});
$("#btn-promocion").on("click", function (e) {
    window.location.href = "?descuento=True";
});
$("#btn-vendido").on("click", function (e) {
    window.location.href = "?popular=True";
});
$("#page-link-back").on("click", function (e) {
    var searchParams = new URLSearchParams(window.location.search);
    let paginaActual = parseInt(searchParams.get("pagina") ?? 1);
    window.location.href = redirectParams("pagina", paginaActual - 1);
});
$("#page-link-next").on("click", function (e) {
    var searchParams = new URLSearchParams(window.location.search);
    let paginaActual = parseInt(searchParams.get("pagina") ?? 1);
    window.location.href = redirectParams("pagina", paginaActual + 1);
});

$(".page-link-number").on("click", function (e) {
    window.location.href = redirectParams("pagina", $(this).text());
});


$("#buscar-input").on("input", function (e) {

    let input = document.getElementById("buscar-input");
    let filter = input.value.toUpperCase();
    let cards = document.getElementsByClassName("product-card")
    let titles = document.getElementsByClassName("product-card-title");
    let cabys = document.getElementsByClassName("product-card-cabys");

    for (i = 0; i < cards.length; i++) {
        a = titles[i];
        b = cabys[i];
        if (a.innerHTML.toUpperCase().indexOf(filter) > -1 || b.innerHTML.toUpperCase().indexOf(filter) > -1) {
            cards[i].style.display = "";
        } else {
            cards[i].style.display = "none";
        }
    }
});

function redirectParams(param, paramValue) {
    var currentUrl = window.location.href;
    var searchParams = new URLSearchParams(window.location.search);
    searchParams.set(param, paramValue);
    var qryString = searchParams.toString();
    var newUrl = currentUrl.split('?')[0] + '?' + qryString; 
    
    return newUrl;
}
$('[data-toggle="touchspin"]').keyup(function (e) {
    return validarNumeros($(this).val());
});

function validarNumeros(evt) {
    var charCode = (evt.which) ? evt.which : event.keyCode;
    if (charCode >= 48 && charCode <= 57) {
        return true;
    }
    return false;
}
$(".btn-agregar-carrito").on("click", function (e) {

    let cantProducto = parseInt($(this).closest('.product-carrito').find('[data-toggle="touchspin"]').val());
    let inventario = parseInt($(this).siblings('.inventario').val());
    let idProducto = parseInt($(this).siblings('.consecutivo').val());
    if (cantProducto > inventario) {
        $("#errorModal1").modal('show');
        return;
    }

    if (cantProducto <= 0) {
        $("#errorModal2").modal('show');
        return;
    }
    $(this).addClass("clicked");
    
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
                setTimeout(function () {
                    window.location.href = "/Inicio/PantallaPrincipal";
                }, 2000);
            }
            else {
                alert(data);
            }
        }
    });
});