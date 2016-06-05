function editEstateCtrl($scope, $http, editEstateConfig) {
    $scope.countryList = [];
    $scope.citiesList = [];
    $scope.country = "";
    $scope.city = "";

    $scope.chooseCountry = function() {
        $http.get('/Scripts/countriesToCities.json').success(function (data) {
            $scope.citiesList = data[$scope.country];
            $scope.city = $scope.citiesList[0];
        });
    }
    $scope.chooseCity = function() {

    }
    $scope.initCountres = function() {
        $http.get('/Scripts/countriesToCities.json').success(function(data) {
            angular.forEach(data, function (value, key) {
                if(key.trim()!="") $scope.countryList.push(key);
            });
            $scope.country = $scope.countryList[0];
        });
    }
    $scope.setLocation = function(lng, lat) {
        $scope.$apply(function () {
            $scope.Latitude = lat;
            $scope.Longatude = lng;
        });
    }
    function initialize() {
        $scope.map = new google.maps.Map(document.getElementById("map"),
        {
            center: { lat: $scope.Latitude, lng: $scope.Longatude },
            scrollwheel: true,
            zoom: 8
        });

        $scope.marker = new google.maps.Marker({
            position: { lat: $scope.Latitude, lng: $scope.Longatude },
            map: $scope.map,
            title: "Real estate possition"
        });

        $scope.map.addListener('click', function (e) {
            $scope.setLocation(e.latLng.lng(), e.latLng.lat());
            $scope.marker.setPosition(e.latLng);
            $scope.marker.setTitle(e.latLng.toString());
        });
    }
    google.maps.event.addDomListener(window, 'load', initialize);
}

angular.module('RealtyInvest.App').controller('EditEstateCtrl', editEstateCtrl);