

var userDetails = {
    Notice: [],
    Start: function () {
        userDetails.Notice = Global._AdicioneNotice("Saving user","loading");
    },
    Success: function (Result) {

        if (Result === null || Result === undefined) {
            Global._AdicioneNoticeTemporario("An error has ocurred, please contact the support team");
            return;
        }

        if (!Result.success) {
            Global._AdicioneNoticeTemporario(Result.message, "error");
            return;
        }

        $("#Id").val(Result.data);

        Global._AdicioneNoticeTemporario(Result.message, "success");
    },
    Fail: function () {
        Global._AdicioneNoticeTemporario("An error has ocurred, please contact the support team");
    },
    Complete: function () {
        userDetails.Notice.remove();
    }
};