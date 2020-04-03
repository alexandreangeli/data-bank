class UsuarioJs {
    updateUsuario(submit) {
        if ($("#form_id").valid()) {
            event.preventDefault();
            let data = this.getData(submit);
            this.postUsuario(data);
        }
    }

    getData(submit) {
        var linhaId = $(submit).parents('[item-id]');
        var UsuarioId = $(linhaId).attr('item-id');
        var linhaEmpresa = $(linhaId).find('[empresa]');
        var novoEmpresa = $(linhaEmpresa).find('select').val();

        var linhaFilial = $(linhaId).find('[filial]');
        var novoFilial = $(linhaFilial).find('select').val();

        var linhaPessoaFisica = $(linhaId).find('[pessoaFisica]');
        var novoPessoaFisica = $(linhaPessoaFisica).find('select').val();

        var linhaEmail = $(linhaId).find('[email]');
        var novoEmail = $(linhaEmail).find('input').val();

        var linhaCelular = $(linhaId).find('[celular]');
        var novoCelular = $(linhaCelular).find('input').val();

        var linhaSenha = $(linhaId).find('[senha]');
        var novoSenha = $(linhaSenha).find('input').val();

        var novoAtivo = $("#ativo").is(":checked");

        return {
            Id: UsuarioId,
            Email: novoEmail,
            Celular: novoCelular,
            Senha: novoSenha,
            Ativo: novoAtivo,
            Empresa: {
                Id: novoEmpresa
            },
            Filial: {
                Id: novoFilial
            },
            PessoaFisica: {
                Id: novoPessoaFisica
            }
        }
    }

    postUsuario(data) {
        let token = $('[name=__RequestVerificationToken]').val();
        let headers = {};
        headers['RequestVerificationToken'] = token;
        $.ajax({
            url: '/usuarios/updateusuario',
            type: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(data),
            headers: headers
        }).done(function (response) {
            location.replace('/Usuarios/Index')
        });
    }

    reloadEdit(usuarioId) {
        var e = document.getElementById("SelectedEmpresaId");
        var strUser = e.options[e.selectedIndex].value;
        $.ajax({
            url: '/usuarios/edit',
            type: 'POST',
            data: {
                "id": usuarioId,
                "empresaId": strUser}
        }).done(function (response) {
            location.replace('/Usuarios/Edit?id=' + usuarioId + '&empresaId=' + strUser)
        });
    }

    reloadCreate() {
        var e = document.getElementById("SelectedEmpresaId");
        var strUser = e.options[e.selectedIndex].value;
        $.ajax({
            url: '/usuarios/create',
            type: 'GET',
            data: {
                "empresaId": strUser
            }
        }).done(function (response) {
            location.replace('/Usuarios/Create?empresaId=' + strUser)
        });
    }
}

var usuarioJs = new UsuarioJs();
