(function() {
    'use strict';

    angular
        .module('app')
        .factory('userFactory', userFactory);

    userFactory.$inject = ['$http', 'apiUrl'];

    /* @ngInject */
    function userFactory($http, apiUrl) {
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
              .get(apiUrl + 'users')
              .then(function(response){
                return response.data;
              });
            }
          function getById(id){
            return $http
                .get(apiUrl +'users/'+ id)
                .then(function(response){
                  return response.data;
                });
          }
          function update(id, users){
                return $http.put(apiUrl +'users/' + id, users);
          }
          function create(users){
            return $http
                .post(apiUrl, 'users')
                .then(function(response){
                  return response.data;
                });
          }
          function remove(id){
            return $http
            .delete(apiUrl +'users/' + id)
            .then(function(response){
              return response.data;
            });
          }
        }
})();
