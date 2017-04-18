(function() {
    'use strict';

    angular
        .module('app.companyDash')
        .controller('CompanyDashController', CompanyDashController);

    CompanyDashController.$inject = ['MoversDashFactory', 'companiesFactory', '$stateParams'];

    /* @ngInject */
    function CompanyDashController(MoversDashFactory, companiesFactory, $stateParams) {
        var vm = this;
        vm.widget = "revenueChart";
        activate();

        function activate() {
            var id = $stateParams.id;

            MoversDashFactory
                .getRevenueChart(1)
                .then(function(data) {
                    vm.revenueChart = {
                        data: data,
                        labels: data.map(data => data.x)
                    };
                });
            MoversDashFactory
                .getUtilizationChart(1)
                .then(function(data) {
                    vm.utilizationChart = {
                        data: data,
                        labels: data.map(data => data.x)
                    };
                });

        }


    }
})();
