var app = angular.module('RealtyInvest.App', ['ui.bootstrap', 'ngAnimate']);

app.controller('LoginCtrl', function ($scope, $uibModal,  $log) {
    $scope.animationsEnabled = true;

    $scope.openLogin = function (size) {

        var modalInstance = $uibModal.open({
            animation: $scope.animationsEnabled,
            templateUrl: 'templateLoginDlg.html',
            controller: 'LoginInstanceCtrl',
            size: size
        });
    };
    $scope.openRegistration = function (size) {
        var modalInstance = $uibModal.open({
            animation: $scope.animationsEnabled,
            templateUrl: 'templateRegistrationDlg.html',
            controller: 'LoginInstanceCtrl',
            size: size
        });
    };
    $scope.toggleAnimation = function () {
        $scope.animationsEnabled = !$scope.animationsEnabled;
    };
});

app.controller('LoginInstanceCtrl', function ($scope, $uibModalInstance, $log) {
    $scope.animationsEnabled = true;

    $scope.login = function () {
       $('#loginForm').submit();
        //$uibModalInstance.close($scope.selected.item);
    };
    
    $scope.cancel = function () {
        $uibModalInstance.dismiss('cancel');
    };
});