(function() {
    'use strict';

    angular
        .module('app')
        .factory('equipmentFactory', equipmentFactory);

    equipmentFactory.$inject = ['$http', 'apiUrl'];

    /* @ngInject */
    function equipmentFactory($http, apiUrl) {
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
              .get(apiUrl + 'equipments')
              .then(function(response){
                return response.data;
              });
            }
          function getById(id){
            return $http
                .get(apiUrl +'equipments/'+ id)
                .then(function(response){
                  return response.data;
                });
          }
          function update(id, equipments){
                return $http.put(apiUrl +'equipments/' + id, equipments);
          }
          function create(equipments){
            return $http
                .post(apiUrl, 'equipments')
                .then(function(response){
                  return response.data;
                });
          }
          function remove(id){
            return $http
            .delete(apiUrl +'equipments/' + id)
            .then(function(response){
              return response.data;
            });
          }
        }
})();
