(function() {
    'use strict';

    angular
        .module('app')
        .factory('MoversDashFactory', MoversDashFactory);

    MoversDashFactory.$inject = ['$http', 'apiUrl'];

    /* @ngInject */
    function MoversDashFactory($http, apiUrl) {
        var service = {
            getCalendar : getCalendar
        };

        return service;

        function getCalendar(id) {
          return $http
              .get(apiUrl + 'moversDash/calendar/'+ id)
              .then(function(response){
                return response.data;
              });
        }
    }
})();
