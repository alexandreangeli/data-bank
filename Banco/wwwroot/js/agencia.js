class AgenciaJs {
    updateAgencia(submit) {
        if ($("#form_id").valid()) {
            event.preventDefault();
            let data = this.getData(submit);
            this.postAgencia(data);
        }
    }

    getData(submit) {
        var linhaId = $(submit).parents('[item-id]');
        var agenciaId = $(linhaId).attr('item-id');

        //var linhaNomeFantasia = $(linhaId).find('[nomeFantasia]');
        //var novoNomeFantasia = $(linhaNomeFantasia).find('input').val();

        var linhaBanco = $(linhaId).find('[banco]');
        var novoBanco = $(linhaBanco).find('select').val();

        var linhaPessoaJuridica = $(linhaId).find('[pessoaJuridica]');
        var novoPessoaJuridica = $(linhaPessoaJuridica).find('select').val();

        //var linhaCNPJ = $(linhaId).find('[cnpj]');
        //var novoCNPJ = $(linhaCNPJ).find('input').val();

        //var linhaNumeroDaInscricaoMunicipal = $(linhaId).find('[numeroDaInscricaoMunicipal]');
        //var novoNumeroDaInscricaoMunicipal = $(linhaNumeroDaInscricaoMunicipal).find('input').val();

        var linhaCodigo = $(linhaId).find('[codigo]');
        var novoCodigo = $(linhaCodigo).find('input').val();

        var linhaDigitoVerificador = $(linhaId).find('[digitoVerificador]');
        var novoDigitoVerificador = $(linhaDigitoVerificador).find('input').val();

        //var novoAtivo = $("#ativo").is(":checked");
        
        return {
            Id: agenciaId,
            Codigo: novoCodigo,
            DigitoVerificador: novoDigitoVerificador,
            Banco: {
                Id: novoBanco
            },
            PessoaJuridica: {
                Id: novoPessoaJuridica
            }
        }
    }

    postAgencia(data) {
        let token = $('[name=__RequestVerificationToken]').val();
        let headers = {};
        headers['RequestVerificationToken'] = token;
        $.ajax({
            url: '/agencias/updateagencia',
            type: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(data),
            headers: headers
        }).done(function (response) {
            location.replace('/Agencias/Index')
            });
    }
}

var agenciaJs = new AgenciaJs();
