

var Global = {
    _AdicioneNotice: function (msg, type) {
        var icon = this._obtenhaIconNotice(type);
        var options = {
            title: msg,
            text: "",
            hide: false,
            icon: icon,
            modules: {
                Buttons: {
                    closer: false,
                    sticker: false
                },
                Mobile: {
                    swipeDismiss: false
                },
                animate: {
                    animate: true,
                    inClass: 'slideInRight',
                    outClass: 'slideOutRight'
                }
            }
        };

        return this._InicializaNotice(options, type);
    },
    _AdicioneNoticeTemporario: function (msg, type) {

        var icon = this._obtenhaIconNotice(type);
        var defaultOptions = {
            title: msg,
            text: "",
            delay: 3500,
            icon: icon,
            modules: {
                Buttons: {
                    closer: false,
                    sticker: false
                },
                Mobile: {
                    swipeDismiss: false
                },
                animate: {
                    animate: true,
                    inClass: 'slideInRight',
                    outClass: 'slideOutRight'
                }
            }
        };

        this._InicializaNotice(defaultOptions, type);

    },
    _obtenhaIconNotice: function (type) {
        var icon = 'fa fa-2x fa-check pnotify-success';
        if (type === 'info')
            icon = 'fa fa-2x fa-info pnotify-info';
        else if (type === 'loading')
            icon = 'fas fa-2x fa-circle-notch fa-pulse pnotify-loading';
        else if (type === 'error')
            icon = 'fa fa-2x fa-times pnotify-error';
        else if (type === 'warning')
            icon = 'fa fa-2x fa-exclamation-triangle pnotify-warning';

        return icon;
    },
    _InicializaNotice: function (options, type) {

        if (type === 'info')
            return PNotify.info(options);
        else if (type === 'loading')
            return PNotify.info(options);
        else if (type === 'error')
            return PNotify.error(options);
        else if (type === 'warning')
            return PNotify.error(options);

        return PNotify.success(options);

    },
    _LockButtonAjax: function ($botao) {
        let Icon = $($botao).find("i");
        let Disabled = $($botao).is("disabled");
        let TemSpiner = $(Icon).hasClass("fa-spinner")

        if (!Disabled) {
            $($botao).prop("disabled", true).addClass("disabled");
        }

        if (!TemSpiner) {
            if (Icon !== null && typeof Icon !== "undefined")
                $(Icon).addClass("fa-spin fa-spinner");
        }
    },
    _UnlockButtonAjax: function ($botao) {
        let Icon = $($botao).find("i");
        $($botao).prop("disabled", false).removeClass("disabled");
        $(Icon).removeClass("fa-spin fa-spinner");
    },
    _InicializaDatatable: function (seletor) {
        $(seletor).DataTable({
            "lengthChange": false,
            "autoWidth": true,
            "dom": 'r<"pull-left"f><"dtable-margin"t>i<"float-right"p>'
        });
    },
    _GetEditLinkTable: function (Id, Label) {
        return `<td><a href="javascript:void(0)" data-codigo="${Id}" name="EditClick">${Label}</a></td>`;
    },
    _GetDeleteLinkTable: function (Id) {
        return `<td><a href="javascript:void(0)" data-codigo="${Id}" name="DeleteClick">Delete</a></td>`;
    }
};