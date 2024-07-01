//Function to validate if the user is already in the system (Log in)
function validarUsuario() {

    var correoUsuario = document.getElementById('txtEmail').value;
    var contraseñaUsuario = document.getElementById('txtPassword').value;

    $.ajax(
        {
        url: "/Usuarios/validarUsuarioController",
        type: "POST",
        data: {
            "correo": correoUsuario,
            "contraseña": contraseñaUsuario

        },
        
        dataType: "json",
        success: function (data) {

            console.log(data)
            document.getElementById('errorAlert').style.display = "none";

            if (data.role.id_role == 1) location.href = "/admin"
            if (data.role.id_role == 2) location.href = "/mecanico"
            if (data.role.id_role == 3) location.href = "/cliente"


        },
        error: function (xhr, status, error) {
            // Handle errors here
            document.getElementById('errorAlert').style.display = ""; 
        }
    })

}