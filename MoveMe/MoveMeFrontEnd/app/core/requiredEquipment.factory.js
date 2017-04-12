(function() {
    'use strict';

    angular
        .module('app')
        .factory('requiredEquipmentFactory', requiredEquipmentFactory);

    requiredEquipmentFactory.$inject = ['$http', 'apiUrl'];

    /* @ngInject */
    function requiredEquipmentFactory($http, apiUrl) {
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
              .get(apiUrl + 'requiredEquipments')
              .then(function(response){
                return response.data;
              });
            }
          function getById(id){
            return $http
                .get(apiUrl +'requiredEquipments/'+ id)
                .then(function(response){
                  return response.data;
                });
          }
          function update(id, requiredEquipments){
                return $http.put(apiUrl +'requiredEquipments/' + id, requiredEquipments);
          }
          function create(requiredEquipments){
            return $http
                .post(apiUrl, 'requiredEquipments')
                .then(function(response){
                  return response.data;
                });
          }
          function remove(id){
            return $http
            .delete(apiUrl +'requiredEquipments/' + id)
            .then(function(response){
              return response.data;
            });
          }
        }
})();
