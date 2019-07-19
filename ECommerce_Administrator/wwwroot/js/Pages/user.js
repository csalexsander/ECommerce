$(function () {
    login.init();
});


var login = {
    Notice: [],
    init: function () {
        login._Eventos();
    },
    _Eventos: function () {

        Global._InicializaDatatable("#UserTable");

        $(document).on("click", "[name='EditClick']", function () {
            let id = $(this).data("codigo");

            login._RedirectToDetail(id);
        });

    },
    _RedirectToDetail: function (Id) {
        window.location.href = `/Users/User/${Id}`;
    },
    _RemoveUser: function (Id) {

        let config = {
            type: "POST",
            url: "/Users/RemoveUser",
            data: {
                "Id": Id
            }
        };

        login.Notice = Global._AdicioneNotice("Removing User", "loading");

        $.ajax(config).done(function (Result) {

            if (Result === null || Result === undefined) {
                Global._AdicioneNoticeTemporario("An error has occurred, please contact the support team", "error");
                return;
            }

            if (!Result.success) {
                Global._AdicioneNoticeTemporario(Result.message, "error");
                return;
            }

            window.location.href = "/Users";

        }).fail(function () {

            Global._AdicioneNoticeTemporario("An error has occurred, please contact the support team", "error");

        }).always(function () {

            login.Notice.remove();

        });

    }
};