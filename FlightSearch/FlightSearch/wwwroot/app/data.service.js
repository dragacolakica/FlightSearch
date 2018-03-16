(function () {
    'use strict';

    angular
        .module('app')
        .factory('data', data);

    data.$inject = ['$http'];

    function data($http) {
        var service = {
            getFlights: getFlights,
            getCityCodes: getCityCodes
        };

        return service;

        function getCityCodes() {
            return $http.get("api/Code/").then(getCityCodesComplete)
                .catch(function (message) {
                    console.log('XHR failed for getCityCodes. Message:' + JSON.stringify(message));
                });
            function getCityCodesComplete(data, status, headers, config) {
                return data.data;
            }
        }

        function getFlights(searchInfo) {
            return $http.post("api/Search/", searchInfo).then(getFlightsComplete)
                .catch(function (message) {
                    console.log('XHR failed for searchInfo. Message:' + JSON.stringify(message));
                });
            function getFlightsComplete(data, status, headers, config) {
                return data.data;
            }
        }
    }
})();

