(function() {
    'use strict';

    angular
        .module('app.results')
        .controller('ResultsController', ResultsController);

    ResultsController.$inject = ['$stateparams', 'ResultsFactory'];

    /* @ngInject */
    function ResultsController($stateparams, ResultsFactory) {
        var vm = this;

        vm.jobDetails = $stateparams.jobDetails;
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
