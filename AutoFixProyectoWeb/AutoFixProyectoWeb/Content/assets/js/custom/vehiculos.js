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
            url: "/Vehiculos/getTodosVehiculoController",
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

function consultarPorPlaca(event)
{
    var item = event.target.closest('.list-group-item');
    var placa = item.querySelector('.text-sm').textContent;

    console.log(placa);
    
    $.ajax(
        {
            url: "/Vehiculos/getVehiculoPorPlacaController",
            type: "POST",
            dataType: "json",
            data: {
                "placa": placa
            },
            success: function (data) {

                var modal = $('#actualizarVehiculo');
               // modal.find('#txtPlaca').prop('readonly', true);
                modal.modal('show');

                console.log(data);
                modal.find('#txtPlaca').val(data.placa);
                modal.find('#txtModelo').val(data.modelo);
                modal.find('#txtChasis').val(data.chasis);
                modal.find('#txtMarca').val(data.marca);
            },
            error: function (xhr, status, error) {
                console.log(error);
                // Handle errors here
                //document.getElementById('errorAlert').style.display = "";
            }
        })
}

function vehiculoLista(vehiculo)
{
    return `<li class="list-group-item border-0 d-flex align-items-center px-0 mb-2" ><div class="d-flex align-items-start flex-column justify-content-center"><h6 class="mb-0 text-sm">${vehiculo.placa}</h6><p class="mb-0 text-xs">${vehiculo.marca} ${vehiculo.modelo}</p></div><a class="btn btn-link pe-3 ps-0 mb-0 ms-auto" href="javascript:;">View</a></li >`;
}

function cargarLista(vehiculos)
{
    var listaVehiculos = document.getElementById('listaVehiculos').querySelector('ul');
    listaVehiculos.innerHTML = '';

    vehiculos.forEach(function (vehiculo) {
        var item = vehiculoLista(vehiculo);
        listaVehiculos.innerHTML = listaVehiculos.innerHTML + item;
    });

    var btnActualizar = document.querySelectorAll('.btn-link');
    btnActualizar.forEach(function (button) {
        button.addEventListener('click', consultarPorPlaca)
    })

}

function guardarVehiculo() {

    var placa = document.getElementById('txtPlaca').value;
    var modelo = document.getElementById('txtModelo').value;
    var chasis = document.getElementById('txtChasis').value;
    var marca = document.getElementById('txtMarca').value;
    var id_usuario = 1;

    $.ajax(
        {
            url: "/Vehiculos/guardarVehiculoController",
            type: "POST",
            data: {
                "placa": placa,
                "modelo": modelo,
                "chasis": chasis,
                "marca": marca,
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

function actualizarVehiculo()
{
    console.log("test actualizar");
    var modal = $('#actualizarVehiculo');
    var placa = modal.find('#txtPlaca').val();
    var modelo = modal.find('#txtModelo').val();
    var chasis = modal.find('#txtChasis').val();
    var marca = modal.find('#txtMarca').val();

    $.ajax(
        {
            url: "/Vehiculos/actualizarVehiculoController",
            type: "POST",
            data: {
                "placa": placa,
                "modelo": modelo,
                "chasis": chasis,
                "marca": marca,
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

function actualizarEstadoVehiculo() {

    var placa = document.getElementById('txtEmail').value;

    $.ajax(
        {
            url: "/Vehiculos/actualizarEstadoVehiculoController",
            type: "POST",
            data: {
                "placa": placa,
                "estado": false
            },

            dataType: "json",
            success: function (data) {

                document.getElementById('errorAlert').style.display = "none";

            },
            error: function (xhr, status, error) {
                // Handle errors here
                document.getElementById('errorAlert').style.display = "";
            }
        })

}

init();