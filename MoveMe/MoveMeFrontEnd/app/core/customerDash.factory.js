(function() {
    'use strict';

    angular
        .module('app')
        .factory('CustomerDashFactory', CustomerDashFactory);

    CustomerDashFactory.$inject = ['$http', 'apiUrl'];

    /* @ngInject */
    function CustomerDashFactory($http, apiUrl) {
        var service = {
            getCalendar : getCalendar
        };

        return service;

        function getCalendar(id) {
          return $http
              .get(apiUrl + 'customerDash/calendar/'+ id)
              .then(function(response){
                return response.data;
              });
        }
    }
})();
