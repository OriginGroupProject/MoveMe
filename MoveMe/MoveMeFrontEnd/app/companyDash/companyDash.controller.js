(function() {
    'use strict';

    angular
        .module('app.companyDash')
        .controller('CompanyDashController', CompanyDashController);

    CompanyDashController.$inject = ['ordersFactory', 'jobDetailFactory', 'companiesFactory'];

    /* @ngInject */
    function CompanyDashController(ordersFactory, jobDetailFactory, companiesFactory) {
        var vm = this;

        activate();

        function activate() {
          ordersFactory
            .getAll()
            .then(function(data) {
              vm.orders = data;
            })
        }
    }
})();
