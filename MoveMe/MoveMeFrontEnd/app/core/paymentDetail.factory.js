(function() {
    'use strict';

    angular
        .module('app')
        .factory('paymentDetailFactory', paymentDetailFactory);

    paymentDetailFactory.$inject = ['$http', 'apiUrl'];

    /* @ngInject */
    function paymentDetailFactory($http, apiUrl) {
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
              .get(apiUrl + 'paymentDetails')
              .then(function(response){
                return response.data;
              });
            }
          function getById(id){
            return $http
                .get(apiUrl +'paymentDetails/'+ id)
                .then(function(response){
                  return response.data;
                });
          }
          function update(id, paymentDetails){
                return $http.put(apiUrl +'paymentDetails/' + id, paymentDetails);
          }
          function create(paymentDetails){
            return $http
                .post(apiUrl + 'paymentdetails', paymentDetails)
                .then(function(response){
                  return response.data;
                });
          }
          function remove(id){
            return $http
            .delete(apiUrl +'paymentDetails/' + id)
            .then(function(response){
              return response.data;
            });
          }
        }
})();
