///Function to create a new user
document.addEventListener('DOMContentLoaded', function () {
    var form = document.getElementById('CreateUserForm');

    // Validate when the form is submitted.
    form.addEventListener('submit', function (event) {
        event.preventDefault();

        var nombreUsuario = document.getElementById('txtName').value;
        var emailUsuario = document.getElementById('txtCorreo').value;
        var telefonoUsuario = document.getElementById('txtTelefono').value;
        var passwordUsuario = 'Pasword1234'
        var role = document.getElementById('txtRole').value;

        //Execute the call to the controller to create the user
        $.ajax(
            {
                url: "/Usuarios/crearUsuarioController",
                type: "POST",
                data: {
                    "roleUsuario": role,
                    "nombre": nombreUsuario,
                    "correo": emailUsuario,
                    "contraseña": passwordUsuario,
                    "telefono": telefonoUsuario,
                    "sessionVariablesReload": false
                },

                dataType: "json",
                success: function (data) {

                    location.reload();

                },
                error: function (xhr, status, error) {
                    // Handle errors here
                    console.log('Error');
                }
            })

    });
});

//Functions to complete the form to edit a user
function openEditUserModal(user_id) {

    $.ajax(
        {
            url: "/Usuarios/optenerUsuario",
            type: "GET",
            data: {
                "idUsuario": user_id,
            },
            dataType: "json",
            success: function (data) {

                //Modify the fields of the form using the data of the inputs
                document.getElementById('inputParam').value = user_id;
                document.getElementById('txtNameEdit').value = data.nombre;
                document.getElementById('txtCorreoEdit').value = data.correo;
                document.getElementById('txtRoleEdit').value = data.role.id_role
                document.getElementById('txtTelefonoEdit').value = data.telefono


                //Open the modal
                $('#editarUsuario').modal('show');

            },
            error: function (xhr, status, error) {
                // Handle errors here
                console.log('Error');
            }
        })


}

//Function to connect to the server and modify the user after completing the form. 
document.addEventListener('DOMContentLoaded', function () {
    var form = document.getElementById('editarUsuario');

    // Validate when the form is submitted.
    form.addEventListener('submit', function (event) {
        event.preventDefault();

        var id_usuario = document.getElementById('inputParam').value;
        var nombreUsuario = document.getElementById('txtNameEdit').value;
        var emailUsuario = document.getElementById('txtCorreoEdit').value;
        var telefonoUsuario = document.getElementById('txtTelefonoEdit').value;
        var role = document.getElementById('txtRoleEdit').value;

        //Execute the call to the controller to create the user
        $.ajax(
            {
                url: "/Usuarios/editarUsuario",
                type: "POST",
                data: {
                    "idUsuario": id_usuario,
                    "roleUsuario": role,
                    "nombre": nombreUsuario,
                    "correo": emailUsuario,
                    "telefono": telefonoUsuario,
                },

                dataType: "json",
                success: function (data) {

                    location.reload();

                },
                error: function (xhr, status, error) {
                    // Handle errors here
                    console.log('Error');
                }
            })

    });
});