function forecastCtrl($scope, $http, forecastsettings) {

    $scope.loadData = function() {
        $http.post(forecastsettings.UpdateData,
        {
            period : $scope.period
        }).success(function (data) {
            $scope.updateChart(data);
        });
    }

    $scope.updateChart = function(data)
    {
        var ctx = document.getElementById("forecastChart");
        
        $scope.chart = new Chart(ctx, {
            type: 'line',
            data: {
                labels: $.map(data, function (val, i) { return val.X }), //.format("MMM Do YY");
                datasets: [{
                    backgroundColor: "rgba(0,200,132,0.2)",
                    label: 'Price',
                    data: $.map(data, function (val, i) { return val.Y; }),
                }]
            },
            options: {
                scales: {
                    yAxes: [{
                        ticks: {
                            beginAtZero: true
                        }
                    }]
                }
            }
        });
    }
    $scope.initChart = function() {
        $scope.loadData();
    }
}
angular.module('RealtyInvest.App').controller('ForecastCtrl', forecastCtrl);