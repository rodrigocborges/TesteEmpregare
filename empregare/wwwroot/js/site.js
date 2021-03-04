$("#CadastroFrm").on("submit", function (e) {
    e.preventDefault();

    const nome = $("#nome").val();
    const telefone = $("#telefone").val();
    const email = $("#email").val();
    const senha = $("#senha").val();


    $.ajax({
        url: '/Candidato/cadastro',
        data: {nome, telefone, email, senha},
        method: 'POST',
        success: function (data) {
            if (data.status == 200) {
                $("#cadastro-alert").show();
                $("#cadastro-alert").text(data.message);
                if ($("#cadastro-alert").hasClass("alert-danger")) {
                    $("#cadastro-alert").removeClass("alert-danger");
                }
                $("#cadastro-alert").addClass("alert-success");
                $("#nome").val("");
                $("#telefone").val("");
                $("#email").val("");
                $("#senha").val("");
            }
            else {
                $("#cadastro-alert").show();
                $("#cadastro-alert").text(data.message);
                if ($("#cadastro-alert").hasClass("alert-success")) {
                    $("#cadastro-alert").removeClass("alert-success");
                }
                $("#cadastro-alert").addClass("alert-danger");
            }
        }
    });
});


$(document).ready(function () {
    $("#cadastro-alert").hide();

    $.ajax({
        url: '/vaga',
        method: 'GET',
        success: function (data) {
            $.each(data, function (i, e) {
                const code = `<div class="card" style="margin-top:10px;">
                <div class="card-body">
                    <h5 class="card-title">${e.titulo} (${e.tipo})</h5>
                    <h6 class="card-subtitle mb-2 text-muted">${e.empresa} | Salário: R$ ${e.salario}</h6>
                    <p class="card-text">${e.descricao}</p>
                </div>
                </div>`;
                $("#lista-vagas").append(code);
            });
        }
    });

    $('#telefone').keyup(function () {
        $(this).val(this.value.replace(/\D/g, ''));
    });

    $('#senha').keyup(function () {
        if ($(this).val().length < 4) {
            $("#cadastro-alert").show();
            $("#cadastro-alert").text("A senha deve possuir no mínimo 4 caracteres!");
            if ($("#cadastro-alert").hasClass("alert-success")) {
                $("#cadastro-alert").removeClass("alert-success");
            }
            $("#cadastro-alert").addClass("alert-danger");
        } else {
            $("#cadastro-alert").hide();
        }
    });
});