//Function to create a new user
document.addEventListener('DOMContentLoaded', function ()){

    var form = document.getElementById('formCrearUsuario'); 

    //Validate when the form is submitted. 
    form.addEventListener('submit', function (event)){

        event.preventDefault(); 

        var nombreUsuario = document.getElementById('txtName').value; 
        var emailUsuario = document.getElementById('txtEmail').value; 
        var telefonoUsuario = document.getElementById('txtPhone').value; 
        var passwordUsuario = document.getElementById('txtPassword').value; 
        var passwordConfirmacion = document.getElementById('txtPasswordConfirmation').value; 
        var termsConfirmation = document.getElementById('checkTerms');

        if (!termsConfirmation.checked) {
            document.getElementById("alertText").innerHTML = "Accept terms and conditions"; 
            document.getElementById("errorAlert").style.display = ""; 
        }

    }

}