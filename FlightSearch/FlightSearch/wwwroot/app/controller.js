﻿(function () {
    'use strict';

    angular
        .module('app')
        .controller('main', main);

    main.$inject = ['$location', 'data'];

    function main($location, data) {
        var vm = this;
        vm.search = null;
        vm.searchFlight = searchFlight;
        vm.currencies = ["USD", "EUR", "HRK"];
        vm.cityCodes = null;
        vm.format = "yyyy-MM-dd";
        vm.showResult = false;


        data.getCityCodes().then(function (data) {
            vm.cityCodes = data;
        });

        function searchFlight() {
           
            if (vm.searchForm.$valid) {
                vm.showResult = false;
                data.getFlights(vm.search).then(function (data) {
                    //vm.search = null;
                    //vm.searchForm.$setPristine();
                    //vm.searchForm.$setUntouched();
                    vm.showResult = true;
                    vm.results = data;
                    
                });
            }
        }
    }
})();


