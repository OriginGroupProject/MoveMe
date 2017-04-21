(function() {
    'use strict';

    angular
        .module('app')
        .factory('orderDetailFactory', orderDetailFactory);

    orderDetailFactory.$inject = ['$http', 'apiUrl'];

    /* @ngInject */
    function orderDetailFactory($http, apiUrl) {
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
              .get(apiUrl + 'orderDetail')
              .then(function(response){
                return response.data;
              });
            }
          function getById(id){
            return $http
                .get(apiUrl +'orderDetail/'+ id)
                .then(function(response){
                  return response.data;
                });
          }
          function update(id, orderDetail){
                return $http.put(apiUrl +'orderDetail/' + id, orderDetail);
          }
          function create(orderDetail){
            return $http
                .post(apiUrl, 'orderDetail')
                .then(function(response){
                  return response.data;
                });
          }
          function remove(id){
            return $http
            .delete(apiUrl +'orderDetail/' + id)
            .then(function(response){
              return response.data;
            });
          }
        }
})();
