$(function () {
    login.init();
});


var login = {
    init: function () {
        login._Eventos();
    },
    _Eventos: function () {

        Global._InicializaDatatable("#UserTable");

    }
};