﻿window.certificado = {};

certificado.global = {

    selectedRowId: 0,
    table: null

};

certificado.fn = {

    CadastraCertificado: function () {

        $('#sucesso').hide();
        $('#erro').hide();

        if ($('#tipo').val() == "" || $('#celular').val() == "") {
            $.snackbar("add", {
                msg: "Por favor, preencha todos os campos",
                buttonText: "Fechar",
            });

        }
        else {
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
        }

    },

    AtualizaCertificado: function () {
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


        debugger;
        
        var d = rowSelected.data_emissao.split('/');
        var f = rowSelected.data_vencimento.split('/');
        if (d[0].length < 2) {
            d[0] = '0' + d[0];
        }
        if (d[1].length < 2) {
            d[1] = '0' + d[1];
        }
        if (f[0].length < 2) {
            f[0] = '0' + f[0];
        }
        if (f[1].length < 2) {
            f[1] = '0' + f[1];
        }
        var dataEmissao = d[2]+'-'+ d[0] + '-' + d[1];
        var dataVencimento = f[2]+'-'+f[0] + '-' + f[1];


        $('#data_emissao').val(dataEmissao);
        $('#data_vencimento').val(dataVencimento);
        $('#celular').val(rowSelected.celular);
        $("#selectCategory").val(rowSelected.fkEmpresa);
        setTimeout(function () {
            $("#selectCategory").selectpicker('refresh');
        }, 0);
        

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
                         { data: 'empresa' },
                         { data: 'vencido' }
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
             .delegate('#btn_Certificado', 'click', function () { certificado.fn.hideShowModalFooter('cadastrasCertificado', 'modal-footer-salvar'); $('.modal-title').html('Novo Certificado'); })
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