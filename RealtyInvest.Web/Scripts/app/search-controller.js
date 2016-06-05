function searchingCtrl($scope, $http, settings) {

    // Any function returning a promise object can be used to load values asynchronously
    $scope.getRealEstate = function (val) {
        return $http.get(settings.SearchUrl, {
            params: {
                searchString: val
            }
        }).then(function (response) {
            return response.data;
        });
    };

}
angular.module('RealtyInvest.App').controller('SearchCtrl', searchingCtrl);