function ConsultarNombre() {

  let identificacion = $("#Identificacion").val();

  $.ajax({
    url: "https://apis.gometa.org/cedulas/" + identificacion,
    method: "GET",
    datatype: "json",
    success: function (response)
    {
      $("#Nombre").val(response.nombre);
    }
  })

}

$(".select2").select2();