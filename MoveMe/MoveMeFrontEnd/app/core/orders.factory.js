(function() {
    'use strict';

    angular
        .module('app.orders')
        .factory('ordersFactory', ordersFactory);

    ordersFactory.$inject = ['$http', 'apiUrl'];

    /* @ngInject */
    function ordersFactory($http, apiUrl) {
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
              .get(apiUrl + 'orders')
              .then(function(response){
                return response.data;
              });
            }

          function getById(id){
            return $http
                .get(apiUrl +'orders/'+ id)
                .then(function(response){
                  return response.data;
                });
          }

          function update(id, orders){
                return $http.put(apiUrl +'orders/' + id, orders);
          }

          function create(orders){
            return $http
                .post(apiUrl, 'orders')
                .then(function(response){
                  return response.data;
                });
          }

          function remove(id){
            return $http
            .delete(apiUrl +'orders/' + id)
            .then(function(response){
              return response.data;
            });
          }

        }
})();
