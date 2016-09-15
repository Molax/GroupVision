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
                "nome": $('#nome').val(),
                "apelido": $('#apelido').val(),
                "cnpj": $('#cnpj').val(),
                "celular": $('#celular').val(),
                "telefone": $('#telefone').val(),
                "email_cliente": $('#email_cliente').val(),
                "email_escritorio": $('#email_escritorio').val(),
                "email_certificado": $('#email_certificado').val(),
                "responsavel": $('#responsavel').val(),
                "logradouro": $('#logradouro').val(),
                "cidade": $('#cidade').val(),
                "estado": $('#estado').val(),
                "cep": $('#cep').val(),
                "bairro": $('#bairro').val(),
                "complemento": $('#complemento').val()

            },
            success: function (e) {
                empresa.global.table.destroy()
                empresa.fn.selecionaTodasEmpresas()
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
                "nome": $('#nome').val(),
                "apelido": $('#apelido').val(),
                "celular": $('#celular').val(),
                "cnpj": $('#cnpj').val(),
                "telefone": $('#telefone').val(),
                "email_cliente": $('#email_cliente').val(),
                "email_escritorio": $('#email_escritorio').val(),
                "email_certificado": $('#email_certificado').val(),
                "responsavel": $('#responsavel').val(),
                "logradouro": $('#logradouro').val(),
                "cidade": $('#cidade').val(),
                "estado": $('#estado').val(),
                "cep": $('#cep').val(),
                "complemento": $('#complemento').val(),
                "bairro": $('#bairro').val(),
                "id": empresa.global.selectedRowId
            },
            success: function (e) {
                certificado.global.table.destroy()
                certificado.fn.selecionaTodasEmpresas()
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

            url: 'api/API_Empresa/DesativaCertificado?id=' + certificado.global.selectedRowId,
            type: 'DELETE',
            success: function (e) {
                certificado.global.table.destroy()
                certificado.fn.selecionaTodasEmpresas()
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
        //$('#nome').val(rowSelected.nome);
        //$('#apelido').val(rowSelected.apelido);
        //$('#cnpj').val(rowSelected.cnpj);
        //$('#celular').val(rowSelected.celular);
        //$('#telefone').val(rowSelected.telefone);
        //$('#email_cliente').val(rowSelected.email_cliente);
        //$('#email_escritorio').val(rowSelected.email_escritorio);
        //$('#email_certificado').val(rowSelected.email_certificado);
        //$('#responsavel').val(rowSelected.responsavel);
        //$('#logradouro').val(rowSelected.logradouro);
        //$('#cidade').val(rowSelected.cidade);
        //$('#estado').val(rowSelected.estado);
        //$('#cep').val(rowSelected.cep);
        //$('#bairro').val(rowSelected.bairro);
        //$('#complemento').val(rowSelected.complemento);
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

                certificado.global.table = $('#tableEmpresa').DataTable({
                    "bScrollInfinite": false,
                    "bScrollCollapse": true,
                    "sScrollY": "500px",
                    "bPaginate": false,
                    data: data,
                    columns: [
                        { data: 'id' },
                        { data: 'nome' },
                        { data: 'apelido' },
                        { data: 'telefone' },
                        { data: 'email_cliente' }
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

    $('body').delegate('button[name="btnSalvarEmpresa"]', 'click', function () { certificado.fn.CadastraCertificado(); })
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