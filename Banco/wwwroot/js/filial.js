class FilialJs {
    updateFilial(submit) {
        if ($("#form_id").valid()) {
            event.preventDefault();
            let data = this.getData(submit);
            this.postFilial(data);
        }
    }

    getData(submit) {
        var linhaId = $(submit).parents('[item-id]');
        var filialId = $(linhaId).attr('item-id');

        //var linhaNomeFantasia = $(linhaId).find('[nomeFantasia]');
        //var novoNomeFantasia = $(linhaNomeFantasia).find('input').val();

        var linhaEmpresa = $(linhaId).find('[empresa]');
        var novoEmpresa = $(linhaEmpresa).find('select').val();

        var linhaPessoaJuridica = $(linhaId).find('[pessoaJuridica]');
        var novoPessoaJuridica = $(linhaPessoaJuridica).find('select').val();

        //var linhaCNPJ = $(linhaId).find('[cnpj]');
        //var novoCNPJ = $(linhaCNPJ).find('input').val();

        //var linhaNumeroDaInscricaoMunicipal = $(linhaId).find('[numeroDaInscricaoMunicipal]');
        //var novoNumeroDaInscricaoMunicipal = $(linhaNumeroDaInscricaoMunicipal).find('input').val();

        var linhaNumeroRegistroNaJuntaComercial = $(linhaId).find('[numeroRegistroNaJuntaComercial]');
        var novoNumeroRegistroNaJuntaComercial = $(linhaNumeroRegistroNaJuntaComercial).find('input').val();

        var novoAtivo = $("#ativo").is(":checked");
        
        return {
            Id: filialId,
            //NomeFantasia: novoNomeFantasia,
            //CNPJ: novoCNPJ,
            //NumeroDaInscricaoMunicipal: novoNumeroDaInscricaoMunicipal,
            NumeroRegistroNaJuntaComercial: novoNumeroRegistroNaJuntaComercial,
            Ativo: novoAtivo,
            Empresa: {
                Id: novoEmpresa
            },
            PessoaJuridica: {
                Id: novoPessoaJuridica
            }
        }
    }

    postFilial(data) {
        let token = $('[name=__RequestVerificationToken]').val();
        let headers = {};
        headers['RequestVerificationToken'] = token;
        $.ajax({
            url: '/filiais/updatefilial',
            type: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(data),
            headers: headers
        }).done(function (response) {
            location.replace('/Filiais/Index')
        });
    }
}

var filialJs = new FilialJs();
