const form = $('#frm-vincular');
const tblPerfilUnidade = $('#tbl-perfil-unidade');
const sltUnidade = $('#slt-unidade');
var temUmUltimaPagina = false;
var veioDeExclusao = false;
var pageNumber = 0;
var qtdRegistrosPagina = 0;
var veioDeInclusao = false;

$(() => {
    tblPerfilUnidade.bootstrapTable({
        pageList: [10, 20, 30, 40, 50]
    });
    
    sltUnidade.select2({
        ajax: {
            url: '/Usuario/BuscarUnidadesPorNomeOuSigla',
            dataType: 'json',
            delay: 500,
            data: (params) => {
                return {
                    query: params.term
                };
            },
            processResults: function (data) {
                return {
                    results: $.map(data.Lista,
                        function (obj) {
                            return { id: obj.IdUnidade, text: `${(obj.Sigla ? obj.Sigla + " -" : "")} ${obj.Nome}` };
                        })

                };
            }
        },
        placeholder: 'Digite o nome ou sigla da unidade',
        minimumInputLength: 2,
        allowClear: true,
        language: {
            inputTooShort: function () { return "Inicie a pesquisa com 2 caracteres"; },
            noResults: function () { return "Nenhum resultado encontrado"; },
            searching: () => "Buscando unidades"
        },
        width: '100%'
    });

    sltUnidade.on("select2:close", () => sltUnidade.valid());
});

function refreshTabelaPerfisVinculados() {
    tblPerfilUnidade.bootstrapTable('refresh');
}

function vincular() {
    if (!form.valid()) {
        var validate = form.validate();
        var erros = validate.errorList.map(x => x.message).join("|||");
        ShowWarningMessage(erros);
        return;
    }

    var data = form.serialize();

    $.ajax({
        type: 'POST',
        url: '/Usuario/VincularPerfil',
        data: data,
        dataType: 'json',
        success: (data) => {
            if (data.camposNaoPreenchidos) {
                ShowWarningMessage(data.camposNaoPreenchidos.join('|||'));
                return;
            }

            ShowValidationResultMessages(data.ValidationResult);
            if (data.ValidationResult.IsValid) {
                veioDeInclusao = true;
                limparCamposVincular();
                refreshTabelaPerfisVinculados();
            }
        },
        error: err => console.log(err)
    });
}

function limparCamposVincular() {
    form.trigger('reset');
    sltUnidade.val(null).trigger("change");
}

function ajaxTablePerfilUnidade(params) {

    var idUsuario = $('#hdn-id-usuario').val();
    var take = params.data.limit;
    var skip = qtdRegistrosPagina === 1 && veioDeExclusao ? ((pageNumber - 2) * take) : params.data.offset;
    //skip = qtdRegistrosPagina === take && veioDeInclusao ? (pageNumber * take) : skip;
    veioDeExclusao = false;
    veioDeInclusao = false;

    $.ajax({
        type: 'POST',
        url: '/Usuario/BuscarUnidadesPerfisUsuario',
        data: { idUsuario, take, skip },
        dataType: 'json',
        success: (data) => {
            qtdRegistrosPagina = data.Lista.length;
            params.success({
                "rows": data.Lista,
                "total": data.QtRegistros
            });
            pageNumber = tblPerfilUnidade.bootstrapTable('getOptions').pageNumber;
        },
        error: err => console.log(err)
    });

    return 0;
} 

function excluirPerfilUnidadeClick(idUsuarioPerfilUnidade) {
    if (confirm('Deseja excluir esse registro?')) {
        excluirPerfilUnidade(idUsuarioPerfilUnidade);
    }
}

function excluirPerfilUnidade(idUsuarioPerfilUnidade) {
    $.ajax({
        type: 'POST',
        url: '/Usuario/ExcluirVinculo',
        data: { idUsuarioPerfilUnidade },
        dataType: 'json',
        success: (data) => {
            ShowValidationResultMessages(data.ValidationResult);
            if (data.ValidationResult.IsValid) {
                veioDeExclusao = true;
                tblPerfilUnidade.bootstrapTable('refresh');
            }
        },
        error: err => console.log(err)
    });
}

function formatterAcoes(value, row) {
    if (row.NomePerfil === 'Solicitante')
        return '';

    return `<span class="btn" onclick="excluirPerfilUnidadeClick(${row.Id})"><i class="fas fa-times-circle fa-2x danger"></i></span>`;
}

function formatterUnidade(value, row) {
    return `${(row.SiglaUnidade ? row.SiglaUnidade + " - " : "")}${row.NomeUnidade}`;
}