var app = angular.module('RealtyInvest.App', ['ui.bootstrap', 'ngAnimate']);

app.controller('LoginCtrl', function ($scope, $uibModal,  $log) {
    $scope.openLogin = function () {
        $('#LoginDlg').modal();
    };
    $scope.openRegistration = function () {
        $('#RegisterDlg').modal();
    };

    (function init() {

    })();
});

app.controller('LoginInstanceCtrl', function ($scope, $log) {
    $scope.success = function (result) {
        if (result === 'OK') {
            $('#LoginDlg').modal('hide');
            document.location = "\\";
        }
    };
    $scope.login = function () {
        $('#loginForm').submit();
    };
    
    $scope.cancel = function () {
        $('#LoginDlg').modal('hide');
    };
});
app.controller('RegInstanceCtrl', function ($scope, $log) {
    $scope.success = function (result) {
        if (result === 'OK') {
            $('#RegisterDlg').modal('hide');
            document.location = "\\";
        }
    };

    $scope.ok = function () {
        $('#registrationForm').submit();
    };
    
    $scope.cancel = function () {
        $('#RegisterDlg').modal('hide');
    };
});