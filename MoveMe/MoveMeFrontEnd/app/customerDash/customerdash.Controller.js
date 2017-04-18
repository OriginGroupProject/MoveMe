(function() {
    'use strict';

    angular
        .module('app.customerDash')
        .controller('CustomerDashController', CustomerDashController);

    CustomerDashController.$inject = [ 'CustomerDashFactory', 'companiesFactory', '$stateparams'];

    /* @ngInject */
    function CustomerDashController(CustomerDashFactory, $stateparams) {
        var vm = this;


        activate();


        function activate() {
          var id = $stateparams.id;
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
    }
    }
})();
