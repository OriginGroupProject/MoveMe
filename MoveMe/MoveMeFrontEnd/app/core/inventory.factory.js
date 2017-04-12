(function() {
    'use strict';

    angular
        .module('app')
        .factory('inventoryFactory', inventoryFactory);

    inventoryFactory.$inject = ['$http', 'apiUrl'];

    /* @ngInject */
    function inventoryFactory($http, apiUrl) {
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
              .get(apiUrl + 'inventories')
              .then(function(response){
                return response.data;
              });
            }
          function getById(id){
            return $http
                .get(apiUrl +'inventories/'+ id)
                .then(function(response){
                  return response.data;
                });
          }
          function update(id, inventories){
                return $http.put(apiUrl +'inventories/' + id, inventories);
          }
          function create(inventories){
            return $http
                .post(apiUrl, 'inventories')
                .then(function(response){
                  return response.data;
                });
          }
          function remove(id){
            return $http
            .delete(apiUrl +'inventories/' + id)
            .then(function(response){
              return response.data;
            });
          }
        }
})();
