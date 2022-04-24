(function ($) {
    $(function () {
        var l = abp.localization.getResource('AbpSettingManagement');

        $("#PerfectMoneySettings").on('submit', function (event) {
            event.preventDefault();
            var form = $(this).serializeFormToObject();

            goodnites.payment.perfectMoney.perfectMoneySettings.update(form).then(function (result) {
                $(document).trigger("AbpSettingSaved");
            });
        });
    });
})(jQuery);