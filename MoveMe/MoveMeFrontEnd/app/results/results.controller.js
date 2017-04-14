(function() {
    'use strict';

    angular
        .module('app.results')
        .controller('ResultsController', ResultsController);

    ResultsController.$inject = ['$stateparams', 'ResultsFactory'];

    /* @ngInject */
    function ResultsController(stateparams, ResultsFactory) {
        var vm = this;



        activate();

        function activate() {

        }
    }
})();
