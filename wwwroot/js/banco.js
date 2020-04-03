class BancoJs {
    updateBanco(submit) {
        if ($("#form_id").valid()) {
            event.preventDefault();
            let data = this.getData(submit);
            this.postBanco(data);
        }       
    }

    getData(submit) {
        var linhaId = $(submit).parents('[item-id]');
        var EmpresaId = $(linhaId).attr('item-id');
        
        var linhaNome = $(linhaId).find('[nome]');
        var novoNome = $(linhaNome).find('input').val();

        return {
            Id: EmpresaId,
            Nome: novoNome,
        }
    }

    postBanco(data) {
        let token = $('[name=__RequestVerificationToken]').val();
        let headers = {};
        headers['RequestVerificationToken'] = token;
        $.ajax({
            url: '/bancos/updatebanco',
            type: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(data),
            headers: headers
        }).done(function (response) {
            location.replace('/Bancos/Index')
        });
    }
}

var bancoJs = new BancoJs();
