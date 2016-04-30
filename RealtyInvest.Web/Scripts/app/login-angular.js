var app = angular.module('RealtyInvest.App', ['ui.bootstrap', 'ngAnimate']);

app.controller('LoginCtrl', function ($scope, $uibModal,  $log) {
    $scope.openLogin = function () {
        $('#LoginDlg').modal();
    };
    $scope.openRegistration = function () {
        $('#RegisterDlg').modal();
    };
});

app.controller('LoginInstanceCtrl', function ($scope, $log) {

    $scope.login = function () {
        $('#loginForm').submit();
    };
    
    $scope.cancel = function () {
        $('#LoginDlg').modal('hide');
    };
});
app.controller('RegInstanceCtrl', function ($scope, $log) {

    $scope.ok = function () {
        $('#registrationForm').submit();
    };
    
    $scope.cancel = function () {
        $('#RegisterDlg').modal('hide');
    };
});