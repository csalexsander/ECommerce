$(function () {
    userRole.init();
});


var userRole = {
    notice: [],
    $modal: $("#RoleModal"),
    $Name: $("#Name"),
    $Id: $("#Id"),
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

        $("#UserRoleTable").dataTable({
            "lengthChange": false,
            "autoWidth": true,
            "dom": 'r<"pull-left"f><"dtable-margin"t>i<"float-right"p>'
        });

        $(document).on("click", "a[name='EditClick']", function (e) {
            e.preventDefault();

            userRole._ajaxUserRoleData($(this).data("codigo"));
        });

        userRole.$modal.on('hidden.bs.modal', function () {
            userRole.$Name.val("");
            userRole.$Id.val(0);
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

        let idtd = userRole._GetIdTd(result.data.idToString);

        let row = [idtd, result.data.name, result.data.accessLevelTostring, result.data.activeToString, result.data.dateToString];

        $(userRole.$DataTable).DataTable().row.add(row).draw();
    },
    FailNewRole: function () {
        Global._AdicioneNoticeTemporario("An erro has ocurred, please contact the suport team", "error");
    },
    CompleteNewRole: function () {
        userRole.notice.remove();
    },
    _GetIdTd: function (Id) {
        return `<a href="javascript:void(0)" data-codigo="${Id}" name="EditClick">${Id}</a>`;
    }
};