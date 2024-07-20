function init()
{
    consultarTodos();
};

function consultarTodos()
{
    //Pendiente modificar traer vehiculos por usuario o por admin 
    //Puede ser con el rol guardado en el modelo o en el cookie 
    $.ajax(
        {
            url: "/Inventario/getInventarioController",
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

function consultarPorID(event)
{
    var item = event.target.closest('.seccion-editar');
    var id_inventario = item.querySelector('.idInventario').textContent;
    
    $.ajax(
        {
            url: "/Inventario/getInventarioPorIDModel",
            type: "POST",
            dataType: "json",
            data: {
                "id_inventario": id_inventario
            },
            success: function (data) {

                var modal = $('#actualizarInventario');
                modal.modal('show');

                console.log(data);
                modal.find('#txtIDInventario').val(data.id_inventario);
                modal.find('#txtCategoria').val(data.id_categoria);
                modal.find('#txtNombre').val(data.nombre);
                modal.find('#txtCantidad').val(data.cantidad);
                modal.find('#txtPrecioCompra').val(data.precio_compra);
                modal.find('#txtPrecioVenta').val(data.precio_venta);
            },
            error: function (xhr, status, error) {
                console.log(error);
                // Handle errors here
                //document.getElementById('errorAlert').style.display = "";
            }
        })
}


function cargarLista(inventario)
{

    var btnActualizar = document.querySelectorAll('.btn-editar');
    btnActualizar.forEach(function (button) {
        button.addEventListener('click', consultarPorID)
    });

}

function guardarInventario() {

    var id_inventario = document.getElementById('txtIDInventario').value;
    var id_categoria = document.getElementById('txtCategoria').value;
    var nombre = document.getElementById('txtNombre').value;
    var cantidad = document.getElementById('txtCantidad').value;
    var precio_compra = document.getElementById('txtPrecioCompra').value;
    var precio_venta = document.getElementById('txtPrecioVenta').value;
    var id_usuario = 1;

    $.ajax(
        {
            url: "/Inventario/guardarInventarioController",
            type: "POST",
            data: {
                "id_inventario": id_inventario,
                "id_categoria": id_categoria,
                "nombre": nombre,
                "cantidad": cantidad,
                "precio_compra": precio_compra,
                "precio_venta": precio_venta,
                "id_usuario": id_usuario, //Este id tiene que cargarse de la sesion de usuario o cookie o del modelo
                "estado": true
            },

            dataType: "json",
            success: function (data) {

                consultarTodos();
                document.getElementById('errorAlert').style.display = "none";

            },
            error: function (xhr, status, error) {
                // Handle errors here
                
                document.getElementById('errorAlert').style.display = "";
            }
        })
}

function actualizarInventario()
{
    console.log("test actualizar");
    var modal = $('#actualizarInventario');
    var id_inventario = modal.find('#txtIDInventario').val();
    var id_categoria = modal.find('#txtCategoria').val();
    var nombre = modal.find('#txtNombre').val();
    var cantidad = modal.find('#txtCantidad').val();
    var precio_compra = modal.find('#txtPrecioCompra').val();
    var precio_venta = modal.find('#txtPrecioVenta').val();
    $.ajax(
        {
            url: "/Inventario/actualizarInventarioController",
            type: "POST",
            data: {
                "id_inventario": id_inventario,
                "id_categoria": id_categoria,
                "nombre": nombre,
                "cantidad": cantidad,
                "precio_compra": precio_compra,
                "precio_venta": precio_venta,
                "id_usuario": 1 //Este id tiene que cargarse de la sesion de usuario o cookie o del modelo

            },

            dataType: "json",
            success: function (data) {
                console.log(data);
                consultarTodos();
            },
            error: function (xhr, status, error) {
                // Handle errors here
                
            }
        })

}


init();