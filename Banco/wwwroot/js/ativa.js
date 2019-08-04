$(document).ready(function () {
    $("#ativo").change(function () {
        var checado = $(this).is(":checked");
        if (!checado) {

            $("#lab").html(" <label for='ativo'style='cursor:pointer;transition:all 1s ease-in-out;' id='lab'><i class='material-icons  float-left text-danger'>close</i>Desativada</label>");

        }
        else {
            $("#lab").html(" <label for='ativo' style='cursor:pointer;transition:all 1s ease-in-out;' id='lab'><i class='material-icons  float-left text-success '>check</i>Ativada</label>");

        }


    });
});