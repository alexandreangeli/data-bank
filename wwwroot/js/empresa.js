class EmpresaJs {
    updateEmpresa(submit) {
        if ($("#form_id").valid()) {
            event.preventDefault();
            let data = this.getData(submit);
            this.postEmpresa(data);
        }
    }

    getData(submit) {
        var linhaId = $(submit).parents('[item-id]');
        var EmpresaId = $(linhaId).attr('item-id');

        var linhaNome = $(linhaId).find('[nome]');
        var novoNome = $(linhaNome).find('input').val();

        var linhaSigla = $(linhaId).find('[sigla]');
        var novaSigla = $(linhaSigla).find('input').val();

        var novoAtivo = $("#ativo").is(":checked");

        return {
            Id: EmpresaId,
            Nome: novoNome,
            Sigla: novaSigla,
            Ativo: novoAtivo
        }
    }

    postEmpresa(data) {
        let token = $('[name=__RequestVerificationToken]').val();
        let headers = {};
        headers['RequestVerificationToken'] = token;
        $.ajax({
            url: '/Empresas/updateEmpresa',
            type: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(data),
            headers: headers
        }).done(function (response) {
            location.replace('/Empresas/Index')
        });
    }
}

var empresaJs = new EmpresaJs();
