(function() {
    'use strict';

    angular
        .module('app.companyDash')
        .controller('CompanyDashController', CompanyDashController);

    CompanyDashController.$inject = [ 'MoversDashFactory', 'companiesFactory', '$stateparams'];

    /* @ngInject */
    function CompanyDashController(MoversDashFactory, companiesFactory, $stateparams) {
        var vm = this;


        activate();

        function activate() {
          var id = $stateparams.id;
          MoversDashFactory
            .getCalendar(id)
            .then(function(data) {
              vm.calendar = data;
            })


        MoversDashFactory
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
