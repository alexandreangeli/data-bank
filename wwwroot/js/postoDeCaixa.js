class PostoDeCaixaJs {
    updatePostoDeCaixa(submit) {
        if ($("#form_id").valid()) {
            event.preventDefault();
            let data = this.getData(submit);
           
            this.postPostoDeCaixa(data);
        }
    }

    getData(submit) {
        var linhaId = $(submit).parents('[item-id]');
        var postoDeCaixaId = $(linhaId).attr('item-id');

        var linhaFilial = $(linhaId).find('[filial]');
        var novoFilial = $(linhaFilial).find('select').val();

        var linhaUsuario = $(linhaId).find('[usuario]');
        var novoUsuario = $(linhaUsuario).find('select').val();

        var linhaContaCorrente = $(linhaId).find('[contaCorrente]');
        var novoContaCorrente = $(linhaContaCorrente).find('select').val();

        var linhaNome = $(linhaId).find('[nome]');
        var novoNome = $(linhaNome).find('input').val();

        var novoAtivo = $("#ativo").is(":checked");

        return {
            Id: postoDeCaixaId,
            Nome: novoNome,
            Ativo: novoAtivo,
            Filial: {
                Id: novoFilial
            },
            ContaCorrente: {
                Id: novoContaCorrente
            },
            Usuario: {
                Id: novoUsuario
            }
        }
    }

    postPostoDeCaixa(data) {
        let token = $('[name=__RequestVerificationToken]').val();
        let headers = {};
        headers['RequestVerificationToken'] = token;
        $.ajax({
            url: '/postosdecaixa/updatepostodecaixa',
            type: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(data),
            headers: headers
        }).done(function (response) {
            location.replace('/PostosDeCaixa/Index')
        });
    }

    reloadEdit(postoDeCaixaId) {
        var e = document.getElementById("SelectedFilialId");
        var strUser = e.options[e.selectedIndex].value;
        $.ajax({
            url: '/postosdecaixa/edit',
            type: 'POST',
            data: {
                "id": postoDeCaixaId,
                "filialId": strUser}
        }).done(function (response) {
            location.replace('/PostosDeCaixa/Edit?id=' + postoDeCaixaId + '&filialId=' + strUser)
        });
    }

    reloadCreate() {
        var strUser1 = $('#SelectedFilialId').val();        
        var strUser2 = $('#SelectedUsuarioId').val();
        $.ajax({
            url: '/postosdecaixa/create',
            type: 'GET',
            data: {
                "filialId": strUser1,
                "usuarioId": strUser2
            }
        }).done(function (response) {
            location.replace('/PostosDeCaixa/Create?filialId=' + strUser1 + '&usuarioId=' + strUser2)
        });
    }
}

var postoDeCaixaJs = new PostoDeCaixaJs();
