//Function to create a new user
document.addEventListener('DOMContentLoaded', function () {
    var form = document.getElementById('formCrearUsuario');

    // Validate when the form is submitted.
    form.addEventListener('submit', function (event) {
        event.preventDefault();

        var nombreUsuario = document.getElementById('txtName').value;
        var emailUsuario = document.getElementById('txtEmail').value;
        var telefonoUsuario = document.getElementById('txtPhone').value;
        var passwordUsuario = document.getElementById('txtPassword').value;
        var passwordConfirmacion = document.getElementById('txtPasswordConfirmation').value;
        var termsConfirmation = document.getElementById('checkTerms');

        if (!termsConfirmation.checked) {
            document.getElementById("alertText").innerHTML = "Accept terms and conditions";
            document.getElementById("errorAlert").style.display = "block"; // Changed to "block" to display the alert
        } else if (passwordUsuario != passwordConfirmacion) {
            document.getElementById("alertText").innerHTML = "Passwords are not matching"; 
            document.getElementById("errorAlert").style.display = "block"; 
        } else {

            document.getElementById("errorAlert").style.display = "none"; 


            //Execute the call to the controller to create the user
            $.ajax(
                {
                    url: "/Usuarios/crearUsuarioController",
                    type: "POST",
                    data: {
                        "roleUsuario":3,
                        "nombre": nombreUsuario,
                        "correo": emailUsuario,
                        "contraseña": passwordUsuario,
                        "telefono": telefonoUsuario
                    },

                    dataType: "json",
                    success: function (data) {

                        window.location.href = '/usuarios/perfil'

                    },
                    error: function (xhr, status, error) {
                        // Handle errors here
                        document.getElementById('errorAlert').style.display = "";
                        document.getElementById("alertText").innerHTML = "Error during the creation of the user, try later";
                    }
                })

        }
    });
});

document.addEventListener('DOMContentLoaded', function () {
    var form = document.getElementById('formRestablecerContraseña');

    // Validate when the form is submitted.
    form.addEventListener('submit', function (event) {

        event.preventDefault();

        var emailUsuario = document.getElementById('txtEmail').value;

        //Execute the call to the controller to create the user
        $.ajax(
            {
                url: "/Usuarios/restaurarContraseñaController",
                type: "POST",
                data: {
                    "correo": emailUsuario,
                },

                dataType: "json",
                success: function (data) {

                    console.log(data)

                },
                error: function (xhr, status, error) {
                    // Handle errors here
                    document.getElementById('errorAlert').style.display = "";
                    document.getElementById("alertText").innerHTML = "Error during the creation of the user, try later";
                }
            })
    });
});
