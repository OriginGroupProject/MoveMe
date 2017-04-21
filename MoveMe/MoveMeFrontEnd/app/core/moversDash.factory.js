(function() {
    'use strict';

    angular
        .module('app')
        .factory('MoversDashFactory', MoversDashFactory);

    MoversDashFactory.$inject = ['$http', 'apiUrl'];

    /* @ngInject */
    function MoversDashFactory($http, apiUrl) {
        var service = {
            getCalendar : getCalendar,
            getJobs : getJobs,
            getRevenueChart : getRevenueChart,
            getUtilizationChart : getUtilizationChart
        };

        return service;

        function getCalendar(id) {
          return $http
              .get(apiUrl + 'moversDash/calendar/'+ id)
              .then(function(response){
                return response.data;
              });
            }

        function getJobs(id) {
          return $http
              .get(apiUrl + 'moversDash/jobdetails/'+ id)
              .then(function(response){
                return response.data;
              });
        }

        function getRevenueChart(id) {
          return $http
            .get(apiUrl + 'moversDash/revenueChart/' + id)
            .then(function(response) {
              return response.data;
            });
        }
        function getUtilizationChart (id) {
          return $http
            .get(apiUrl + 'moversDash/utilizationChart/' + id)
            .then(function(response){
              return response.data;
            });
        }
    }
})();
