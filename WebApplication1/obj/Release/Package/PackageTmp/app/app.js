var app = angular.module("web-app", ['toastr', 'cp.ngConfirm', 'ngRoute']);
app.directive('uiDatepicker', function () {
    return {
        require: 'ngModel',
        restrict: 'EAC',
        replace: true,
        scope: {

        },
        link: function (scope, elem, attrs) {
            $(elem[0]).datepicker({
                autoclose: true,
                todayHighlight: true
            })
                //show datepicker when clicking on the icon
                .next().on(ace.click_event, function () {
                    $(this).prev().focus();
                });
        }
    };
})