(function() {
    'use strict';

    angular
        .module('app.customerDash')
        .controller('CustomerDashController', CustomerDashController);

    CustomerDashController.$inject = ['CustomerDashFactory', 'ordersFactory', '$state', 'apiUrl', '$stateParams'];

    /* @ngInject */
    function CustomerDashController(CustomerDashFactory, $state, apiUrl, $stateParams) {
        var vm = this;
        vm.widget = "dashboard";
        activate();


        function activate() {
            //var id = $stateParams.id;
           var id = 1;

            CustomerDashFactory
                .getCalendar(id)
                .then(function(response) {
                    vm.calendar = response;

                });
            CustomerDashFactory
                .getUpComing(id)
                .then(function(response) {
                    vm.upComing = response;

                });
        }
    }


})();
