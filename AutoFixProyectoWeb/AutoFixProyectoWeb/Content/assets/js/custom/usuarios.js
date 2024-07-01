//Function to validate if the user is already in the system (Log in)
function validarUsuario() {

    var correoUsuario = document.getElementById('txtEmail').value;
    var contraseñaUsuario = document.getElementById('txtPassword').value;

    $.ajax({
        url: "/Usuarios/validarUsuarioController",
        type: "POST",
        data: {
            "correo": correoUsuario,
            "contraseña": contraseñaUsuario

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