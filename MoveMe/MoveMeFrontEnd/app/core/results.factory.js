(function() {
    'use strict';

    angular
        .module('app')
        .factory('ResultsFactory', ResultsFactory);

    ResultsFactory.$inject = ['$http', 'apiUrl' ];

    /* @ngInject */
    function ResultsFactory($http, apiUrl)  {
        var service = {
            getResults: getResults
        };

        return service;

        function getResults(jobDetails) {
            $http
              .post(apiUrl + 'results', jobDetails)
              .then(function(response){
                return response;
              });
        }
    }
})();
