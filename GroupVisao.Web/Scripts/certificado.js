window.certificado = {};

certificado.global = {

    selectedRowId: 0,
    table: null

};

certificado.fn = {

    CadastraCertificado: function () {

        $('#sucesso').hide();
        $('#erro').hide();


        $.ajax({

            url: 'api/API_Certificado/CadastraCertificado',
            type: 'POST',
            dataType: 'json',
            data: {
                "fkempresa": $('#selectCategory').val(),
                "tipo": $('#tipo').val(),
                "data_emissao": $('#data_emissao').val(),
                "data_vencimento": $('#data_vencimento').val(),
                "celular": $('#celular').val()

            },
            success: function (e) {
                certificado.global.table.destroy()
                certificado.fn.SelecionaTodosCertificados()
                $('form')[0].reset();
                $('#sucesso').show();
            },
            error: function (e) {
                $('#erro').show();
            }

        });


    },

    AtualizaCertificado: function () {
        console.log('foi');
        $('#sucesso').hide();
        $('#erro').hide();

        $.ajax({

            url: 'api/API_Certificado/AtualizaCertificado',
            type: 'PUT',
            dataType: 'json',
            data: {
                "fkempresa": $('#selectCategory').val(),
                "tipo": $('#tipo').val(),
                "data_emissao": $('#data_emissao').val(),
                "data_vencimento": $('#data_vencimento').val(),
                "celular": $('#celular').val(),
                "id": certificado.global.selectedRowId
            },
            success: function (e) {
                certificado.global.table.destroy()
                certificado.fn.SelecionaTodosCertificados()
                $('form')[0].reset();
                $('#sucesso').show();
            },
            error: function (e) {
                $('#erro').show();
            }

        });

    },

    DesativaCertificado: function () {
        $('#sucesso').hide();
        $('#erro').hide();

        $.ajax({

            url: 'api/API_Certificado/DesativaCertificado?id=' + certificado.global.selectedRowId,
            type: 'DELETE',
            success: function (e) {
                certificado.global.table.destroy()
                certificado.fn.SelecionaTodosCertificados()
                $('form')[0].reset();
                $('#sucesso').show();

            },
            error: function (e) {
                $('#erro').show();
            }

        });

    },

    editCertificado: function (that) {
        $('#btn_Certificado').trigger('click');
        certificado.fn.hideShowModalFooter('cadastrasCertificado', 'modal-footer-editar');

        var rowSelected = certificado.global.table.row(that).data()
        certificado.global.selectedRowId = rowSelected.id;
        $('#tipo').val(rowSelected.tipo);
        $('#data_emissao').val(rowSelected.data_emissao);
        $('#data_vencimento').val(rowSelected.data_vencimento);
        $('#celular').val(rowSelected.celular);
        $("#selectCategory").val(rowSelected.fkempresa);
        $("#selectCategory").selectpicker('refresh');

    },

    selecionaEmpresas: function () {
        $.ajax({

            url: 'api/API_Empresa/PopulaDropDownEmpresa',
            type: 'GET',
            dataType: 'json',
            success: function (msg) {
                $("#selectCategory").html('');
                $("#selectCategory").append("<option></option>");
                $.each(msg, function (id, obj) {
                    $("#selectCategory").append("<option value='$value'>$html</option>".replace(/\$value/g, obj.id).replace(/\$html/g, obj.nome));
                });
                $("#selectCategory").selectpicker('refresh');
            }
        });
    },

    SelecionaTodosCertificados: function () {
        $.ajax({

            url: 'api/API_Certificado/SelecionaTodosCertificados',
            type: 'GET',
            dataType: 'json',
            success: function (data) {

                certificado.global.table = $('#tableCertificado').DataTable({
                    "bScrollInfinite": false,
                    "bScrollCollapse": true,
                    "sScrollY": "500px",
                    "bPaginate": false,
                    data: data,
                    columns: [
                        { data: 'id' },
                        { data: 'tipo' },
                        { data: 'data_emissao' },
                        { data: 'data_vencimento' },
                        { data: 'celular' },
                         { data: 'empresa' }
                    ]
                });

            }
        });
    },

    hideShowModalFooter: function (modal, footerId) {
        $('#' + modal + ' .modal-footer').hide();
        $('#' + footerId).show();
        $('form')[0].reset();
    }

};

certificado.delegate = function () {

    $('body').delegate('button[name="btnSalvarCertificado"]', 'click', function () { certificado.fn.CadastraCertificado(); })
             .delegate('#tableCertificado tbody tr', 'click', function () { certificado.fn.editCertificado(this); $('.modal-title').html('Certificado'); })
             .delegate('#btn_Certificado', 'click', function () { certificado.fn.hideShowModalFooter('cadastrasCertificado', 'modal-footer-salvar'); $('.modal-title').html('Nova Empresa'); })
             .delegate('button[name="btnEditarCertificado"]', 'click', function () { certificado.fn.AtualizaCertificado() })
             .delegate('button[name="btnDesativarCertificado"]', 'click', function () { certificado.fn.DesativaCertificado() });;

};

certificado.config = function () {

    certificado.delegate();

};

certificado.init = function () {

    certificado.config();

    certificado.fn.SelecionaTodosCertificados();

    certificado.fn.selecionaEmpresas();

}();