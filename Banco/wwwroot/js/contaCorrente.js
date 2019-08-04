class ContaCorrenteJs {
    updateContaCorrente(submit) {
        if ($("#form_id").valid()) {
            event.preventDefault();
            let data = this.getData(submit);
            this.postContaCorrente(data);
        }
    }

    getData(submit) {
        var linhaId = $(submit).parents('[item-id]');
        var ContaCorrenteId = $(linhaId).attr('item-id');

        var linhaBanco = $(linhaId).find('[banco]');
        var novoBanco = $(linhaBanco).find('select').val();

        var linhaAgencia = $(linhaId).find('[agencia]');
        var novoAgencia= $(linhaAgencia).find('select').val();

        var linhaFilial = $(linhaId).find('[filial]');
        var novoFilial = $(linhaFilial).find('select').val();

        var linhaDescricao = $(linhaId).find('[descricao]');
        var novoDescricao = $(linhaDescricao).find('input').val();

        var linhaNumeroDaConta= $(linhaId).find('[numeroDaConta]');
        var novoNumeroDaConta = $(linhaNumeroDaConta).find('input').val();

        var linhaDigitoVerificadorCC = $(linhaId).find('[digitoVerificadorCC]');
        var novoDigitoVerificadorCC = $(linhaDigitoVerificadorCC).find('input').val();


        return {
            Id: ContaCorrenteId,
            Descricao: novoDescricao,
            NumeroDaConta: novoNumeroDaConta,
            DigitoVerificadorCC: novoDigitoVerificadorCC,
            Banco: {
                Id: novoBanco
            },
            Filial: {
                Id: novoFilial
            },
            Agencia: {
                Id: novoAgencia
            }
        }
    }

    postContaCorrente(data) {
        let token = $('[name=__RequestVerificationToken]').val();
        let headers = {};
        headers['RequestVerificationToken'] = token;
        $.ajax({
            url: '/contascorrentes/updatecontacorrente',
            type: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(data),
            headers: headers
        }).done(function (response) {
            location.replace('/ContasCorrentes/Index')
        });
    }

    reloadEdit(contaCorrenteId) {
        var e = document.getElementById("SelectedBancoId");
        var strUser = e.options[e.selectedIndex].value;
        $.ajax({
            url: '/contascorrentes/edit',
            type: 'POST',
            data: {
                "id": contaCorrenteId,
                "bancoId": strUser}
        }).done(function (response) {
            location.replace('/ContasCorrentes/Edit?id=' + contaCorrenteId + '&bancoId=' + strUser)
        });
    }

    reloadCreate() {
        var e = document.getElementById("SelectedBancoId");
        var strUser = e.options[e.selectedIndex].value;
        $.ajax({
            url: '/contascorrentes/create',
            type: 'GET',
            data: {
                "bancoId": strUser
            }
        }).done(function (response) {
            location.replace('/ContasCorrentes/Create?bancoId=' + strUser)
        });
    }
}

var contaCorrenteJs = new ContaCorrenteJs();
