(function() {
    'use strict';

    angular
        .module('app')
        .factory('companiesFactory', companiesFactory);

    companiesFactory.$inject = ['$http', 'apiUrl'];

    /* @ngInject */
    function companiesFactory($http, apiUrl) {
      var service = {
          getAll: getAll,
          getById: getById,
          create: create,
          remove: remove,
          update: update
        };
        return service;
        function getAll(){
          return $http
              .get(apiUrl + 'companies')
              .then(function(response){
                return response.data;
              });
            }
          function getById(id){
            return $http
                .get(apiUrl +'companies/'+ id)
                .then(function(response){
                  return response.data;
                });
          }
          function update(id, companies){
                return $http.put(apiUrl +'companies/' + id, companies);
          }
          function create(companies){
            return $http
                .post(apiUrl, 'companies')
                .then(function(response){
                  return response.data;
                });
          }
          function remove(id){
            return $http
            .delete(apiUrl +'companies/' + id)
            .then(function(response){
              return response.data;
            });
          }
        }
})();
