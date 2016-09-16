window.empresa = {};

empresa.global = {

    selectedRowId: 0,
    table: null

};

empresa.fn = {

    CadastraEmpresa: function () {

        $('#sucesso').hide();
        $('#erro').hide();

        if ($('#nome').val() == "" || $('#cnpj').val() == "" || $('#celular').val() == "" || $('#telefone').val() == "" || $('#email_cliente').val() == ""
            || $('#email_escritorio').val() == "" || $('#email_certificado').val() == "" || $('#responsavel').val() == "" || $('#logradouro').val() == "" || $('#cidade').val() == ""
             || $('#estado').val() == "" || $('#cep').val() == "" || $('#bairro').val() == "")
        {
            $.snackbar("add", {
                msg: "Por favor, preencha todos os campos",
                buttonText: "Fechar",
            });

        }
        else {
            $.ajax({

                url: 'api/API_Empresa/CadastraEmpresa',
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

        }
        

    },

    AtualizaEmpresa: function () {
        console.log('foi');
        $('#sucesso').hide();
        $('#erro').hide();

        $.ajax({

            url: 'api/API_Empresa/AtualizaEpresa',
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

    DesativaEmpresa: function () {
        $('#sucesso').hide();
        $('#erro').hide();

        $.ajax({

            url: 'api/API_Empresa/DesativaEmpresa?id=' + empresa.global.selectedRowId,
            type: 'DELETE',
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

    editEmpresa: function (that) {
        $('#btn_Empresa').trigger('click');
        empresa.fn.hideShowModalFooter('cadastraempresa', 'modal-footer-editar');

        var rowSelected = empresa.global.table.row(that).data()
        empresa.global.selectedRowId = rowSelected.id;
        $('#nome').val(rowSelected.nome);
        $('#apelido').val(rowSelected.apelido);
        $('#cnpj').val(rowSelected.cnpj);
        $('#celular').val(rowSelected.celular);
        $('#telefone').val(rowSelected.telefone);
        $('#email_cliente').val(rowSelected.email_cliente);
        $('#email_escritorio').val(rowSelected.email_escritorio);
        $('#email_certificado').val(rowSelected.email_certificado);
        $('#responsavel').val(rowSelected.responsavel);
        $('#logradouro').val(rowSelected.logradouro);
        $('#cidade').val(rowSelected.cidade);
        $('#estado').val(rowSelected.estado);
        $('#cep').val(rowSelected.cep);
        $('#bairro').val(rowSelected.bairro);
        $('#complemento').val(rowSelected.complemento);

    },

    selecionaTodasEmpresas: function () {
        $.ajax({

            url: 'api/API_Empresa/SelecionaTodasEmpresas',
            type: 'GET',
            dataType: 'json',
            success: function (data) {

                empresa.global.table = $('#tableEmpresa').DataTable({
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

empresa.delegate = function () {

    $('body').delegate('button[name="btnSalvarEmpresa"]', 'click', function () { empresa.fn.CadastraEmpresa(); })
             .delegate('#tableEmpresa tbody tr', 'click', function () { empresa.fn.editEmpresa(this); $('.modal-title').html('Empresa'); })
             .delegate('#btn_Empresa', 'click', function () { empresa.fn.hideShowModalFooter('cadastraempresa', 'modal-footer-salvar'); $('.modal-title').html('Nova Empresa'); })
             .delegate('button[name="btnEditarEmpresa"]', 'click', function () { empresa.fn.AtualizaEmpresa() })
             .delegate('button[name="btnDeletarEmpresa"]', 'click', function () { empresa.fn.DesativaEmpresa() });;

};

empresa.config = function () {

    empresa.delegate();

};

empresa.init = function () {

    empresa.config();

    empresa.fn.selecionaTodasEmpresas();

}();