window.login = {};

login.fn = {

    //login: function () {

    //    $.ajax({

    //        url: 'api/API_Usuario/Login',
    //        type: 'POST',
    //        data: {
    //            "login": $('#login').val(),
    //            "password": $('#password').val()
    //        },
    //        success: function (e) {
    //            if (e) {
    //                localStorage.removeItem('logado');
    //                window.location.href = "PaginaInicial";
    //            }
    //            else {
    //                $.snackbar("add", {
    //                    type: "danger",
    //                    msg: "ERRO : Usuário ou Senha incorretos",
    //                    buttonText: "Fechar",
    //                });
    //            }
    //        }
    //    });

    //},

    logout: function () {

        $.ajax({

            url: 'Login/Logout',
            type: 'POST',
            //dataType: 'json',
            //data: {
            //    "login": $('#login').val(),
            //    "password": $('#password').val()
            //},
            success: function () {
                window.location.href = "Login/Index";
            },
            error: function () {
                console.log('deu ruim')
            }

        });

    }

}

login.delegate = function () {
    //$('body').delegate('button[name="btnLogin"]', 'click', function () { login.fn.login(); })
    $('body').delegate('#logout', 'click', function () { login.fn.logout(); });
};

login.config = function () { login.delegate() };

login.init = function () { login.config() }();


