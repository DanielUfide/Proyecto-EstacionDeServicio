function init()
{
    consultarTodos();
};

function consultarTodos()
{
    
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

                console.log(data);
                /*document.getElementById('txtPlaca').value = data.placa;
                document.getElementById('txtModelo').value = data.modelo;
                document.getElementById('txtChasis').value = data.chasis;
                document.getElementById('txtMarca').value = data.marca;*/
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
                "id_usuario": id_usuario,
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
    var placa = document.getElementById('txtEmail').value;
    var modelo = document.getElementById('txtPassword').value;
    var chasis = document.getElementById('txtEmail').value;
    var marca = document.getElementById('txtPassword').value;

    $.ajax(
        {
            url: "/Vehiculos/actualizarVehiculoController",
            type: "POST",
            data: {
                "placa": placa,
                "modelo": modelo,
                "chasis": chasis,
                "marca": marca

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