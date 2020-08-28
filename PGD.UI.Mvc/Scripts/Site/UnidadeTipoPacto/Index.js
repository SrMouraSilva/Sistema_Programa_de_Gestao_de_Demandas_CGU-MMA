var tblUnidadeTipoPacto = $("#tblUnidadeTipoPacto");

function excluirUnidadeTipoPactoClick(idUnidadeTipoPacto) {
    if (idUnidadeTipoPacto === '0' || !idUnidadeTipoPacto) {
        ShowWarningMessage(Mensagens.REGISTRO_NAO_ENCONTRADO);
        return;
    }

    if (confirm(Mensagens.EXCLUIR_REGISTRO)) {
        excluirUnidadeTipoPacto(idUnidadeTipoPacto);
    }
}

function excluirUnidadeTipoPacto(idUnidadeTipoPacto) {
    $.ajax({
        type: 'POST',
        url: '/UnidadeTipoPacto/Delete',
        data: { idUnidadeTipoPacto },
        dataType: 'json',
        beforeSend: () => showLoading(),
        complete: () => hideLoading(),
        success: (data) => {
            if (!data) {
                ShowWarningMessage(Mensagens.REGISTRO_NAO_ENCONTRADO);
                return;
            }

            ShowOperationSucessMessage();
            removeRowTable(idUnidadeTipoPacto);
        },
        error: err => {
            console.log(err);
            hideLoading();
        }
    });
}

function removeRowTable(idUnidadeTipoPacto) {
    var table = tblUnidadeTipoPacto.DataTable();
    table.rows(`#tableRow_${idUnidadeTipoPacto}`).remove().draw();
}