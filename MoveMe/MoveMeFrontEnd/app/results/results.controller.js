(function() {
    'use strict';

    angular
        .module('app.results')
        .controller('ResultsController', ResultsController);

    ResultsController.$inject = ['companiesFactory', 'jobDetailFactory'];

    /* @ngInject */
    function ResultsController(companiesFactory, jobDetailFactory) {
        var vm = this;

        activate();

        function activate() {

        }
    }
})();
