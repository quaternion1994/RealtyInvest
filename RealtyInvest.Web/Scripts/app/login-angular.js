function loginCtrl($scope, $uibModal,  $log) {
    $scope.openLogin = function () {
        $('#LoginDlg').modal();
    };
    $scope.openRegistration = function () {
        $('#RegisterDlg').modal();
    };

    (function init() {

    })();
}
function loginInstanceCtrl ($scope, $log) {
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
}
function regInstanceCtrl($scope, $log) {
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
}
angular.module('RealtyInvest.App').controller('LoginCtrl', loginCtrl);
angular.module('RealtyInvest.App').controller('LoginInstanceCtrl', loginInstanceCtrl);
angular.module('RealtyInvest.App').controller('RegInstanceCtrl', regInstanceCtrl);