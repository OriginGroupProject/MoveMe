(function() {
    'use strict';

    angular
        .module('app.customerDash')
        .controller('CustomerDashController', CustomerDashController);

    CustomerDashController.$inject = [ 'CustomerDashFactory','ordersFactory', '$state', 'apiUrl', '$stateParams'];

    /* @ngInject */
    function CustomerDashController(CustomerDashFactory, $state, apiUrl, $stateParams ) {
        var vm = this;
        vm.widget = "dashboard";
        activate();


        function activate() {
            var id = $stateParams.id;

          function getById(id){
            return $http
                .get(apiUrl+'customerdash/calendar'+ id)
                .then(function(response){
                  return response.data;

                });
              }
        /*  var id = 1;
          CustomerDashFactory
            .getCalendar(id)
            .then(function(data) {
              vm.calendar = data;
            })


        CustomerDashFactory
            .getJobs(id)
            .then(function(data){
              vm.jobs = data;
            })

        companiesFactory
            .getById(id)
            .then(function(data){
              vm.company = data;
            })
          */
    }

    }
})();
