
var Login = {
    $btnLogin: $("#btnLogin"),
    notice: [],
    init: function () {

    },
    Start: function () {
        Login.notice = Global._AdicioneNotice("Validating data", "loading");
        Global._LockButtonAjax(Login.$btnLogin);
    },
    Success: function (Return) {
        console.log(Return);

        if (!Return.success) {
            Global._AdicioneNoticeTemporario(Return.message, "error");
            return;
        }

        window.location.href = "/";
    },
    Fail: function () {
        Global._AdicioneNoticeTemporario("An error has occurred, Please contact the support team", "error");
    },
    Complete: function () {
        Login.notice.remove();
        Global._UnlockButtonAjax(Login.$btnLogin);
    }
};