$(function () {
    userRole.init();
});


var userRole = {
    notice: [],
    $modal: $("#RoleModal"),
    $Name: $("#Name"),
    $Id: $("#Id"),
    $Active: $("#Active"),
    $RadioClient: $("#Client"),
    $RadioInternal: $("#Internal"),
    $RadioAdministrator: $("#Administrator"),
    $ErrorRadio: $("#errorRadio"),
    $DataTable: $("#UserRoleTable"),
    isEdit: false,
    init: function () {
        userRole._events();
    },
    _events: function () {

        Global._InicializaDatatable("#UserRoleTable");

        $(document).on("click", "a[name='EditClick']", function (e) {
            e.preventDefault();

            userRole._ajaxUserRoleData($(this).data("codigo"));
        });

        $(document).on("click", "a[name='DeleteClick']", function (e) {
            e.preventDefault();

            userRole._DeleteRoleAjax($(this).data("codigo"));
        });

        userRole.$modal.on('hidden.bs.modal', function () {
            userRole.$Name.val("");
            userRole.$Id.val(0);
            userRole.$Active.prop("checked", "checked");
        });
    },
    _ajaxUserRoleData: function (id) {

        this.notice = Global._AdicioneNotice("Searching data", "loading");

        let config = {
            type: "POST",
            url: "UserRole/Role",
            data: {
                "id": id
            }
        };

        $.ajax(config).done(function (result) {

            if (result === null || result === undefined) {
                Global._AdicioneNoticeTemporario("An erro has ocurred, please contact the suport team", "error");
                return;
            }

            if (!result.success) {
                Global._AdicioneNoticeTemporario(result.message, "error");
                return;
            }

            userRole.$Id.val(result.data.id);
            userRole.$Name.val(result.data.name);
            userRole.$Active.prop("checked", result.data.active);

            switch (result.data.accessLevel) {
                case 1:
                    $("[name='AccessLevel']").prop("checked", false);
                    userRole.$RadioClient.prop("checked", true);
                    break;
                case 2:
                    $("[name='AccessLevel']").prop("checked", false);
                    userRole.$RadioInternal.prop("checked", true);
                    break;
                case 3:
                    $("[name='AccessLevel']").prop("checked", false);
                    userRole.$RadioAdministrator.prop("checked", true);
                    break;
                default:
                    $("[name='AccessLevel']").prop("checked", false);
                    userRole.$RadioInternal.prop("checked", true);
                    break;
            }

            userRole.$modal.modal();

        }).fail(function () {
            Global._AdicioneNoticeTemporario("An erro has ocurred, please contact the suport team", "error");
        }).always(function () {
            userRole.notice.remove();
        });
    },
    StartNewRole: function () {
        userRole.notice = Global._AdicioneNotice("Saving data", "loading");

        userRole.isEdit = userRole.$Id.val() > 0;
    },
    SuccessNewRole: function (result) {

        if (result === null || result === undefined) {
            Global._AdicioneNoticeTemporario("An erro has ocurred, please contact the suport team", "error");
            return;
        }

        if (!result.success) {
            Global._AdicioneNoticeTemporario(result.message, "error");
            return;
        }

        userRole.$modal.modal("hide");

        if (userRole.isEdit) {
            window.location.reload();
            return;
        }

        let idtd = Global._GetEditLinkTable(result.data.id, result.data.idToString);
        let deletetd = Global._GetDeleteLinkTable(result.data.id);

        let row = [idtd, result.data.name, result.data.accessLevelTostring, result.data.activeToString, result.data.dateToString, deletetd];

        $(userRole.$DataTable).DataTable().row.add(row).draw();
    },
    FailNewRole: function () {
        Global._AdicioneNoticeTemporario("An erro has ocurred, please contact the suport team", "error");
    },
    CompleteNewRole: function () {
        userRole.notice.remove();
    },
    _GetIdTd: function (Id, IdString) {
        return `<a href="javascript:void(0)" data-codigo="${Id}" name="EditClick">${IdString}</a>`;
    },
    _GetDeleteTd: function (Id) {
        return `<a href="javascript:void(0)" data-codigo="${Id}" name="DeleteClick">Delete</a>`;
    },
    _DeleteRoleAjax: function (Id) {

        userRole.notice = Global._AdicioneNotice("Searching data", "loading");

        let config = {
            type: "POST",
            url: "UserRole/Delete",
            data: {
                "Id": Id
            }
        };

        $.ajax(config).done(function (result) {

            if (result === null || result === undefined) {
                Global._AdicioneNoticeTemporario("An erro has ocurred, please contact the suport team", "error");
                return;
            }

            if (!result.success) {
                Global._AdicioneNoticeTemporario(result.message, "error");
                return;
            }

            Global._AdicioneNoticeTemporario(result.message);

            window.location.reload();

        }).fail(function () {
            Global._AdicioneNoticeTemporario("An erro has ocurred, please contact the suport team", "error");
        }).always(function () {
            userRole.notice.remove();
        });
    }
};