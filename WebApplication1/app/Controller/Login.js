
app.controller("LoginController", function ($scope) {
    $scope.Submit = function () {
        $.ajax({
            type: 'POST',
            url: '/Login/LoginUser',
            data: { LoginName: $scope.UserName, password: $scope.pass},
            success: function (data) {
                $scope.$apply();
            }
        });
    };
});