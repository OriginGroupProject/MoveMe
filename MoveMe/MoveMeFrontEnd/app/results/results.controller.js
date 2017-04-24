(function() {
    'use strict';

    angular
        .module('app.results')
        .controller('ResultsController', ResultsController);

    ResultsController.$inject = ['$stateParams', 'ResultsFactory'];

    /* @ngInject */
    function ResultsController($stateParams, ResultsFactory) {
        var vm = this;

        vm.jobDetails = $stateParams.jobDetails;
        vm.getResults = getResults;
        vm.results = [];

        activate();

        function activate() {
          getResults();
        }
        function getResults(){
          ResultsFactory
          .getResults(vm.jobDetails)
          .then(function(data){
            vm.results = data;
          })
        }
    }
})();
