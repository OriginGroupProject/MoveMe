(function() {
    'use strict';

    angular
        .module('app')
        .factory('jobDetailFactory', jobDetailFactory);

    jobDetailFactory.$inject = ['$http', 'apiUrl'];

    /* @ngInject */
    function jobDetailFactory($http, apiUrl) {
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
              .get(apiUrl + 'jobDetails')
              .then(function(response){
                return response.data;
              });
            }
          function getById(id){
            return $http
                .get(apiUrl +'jobDetails/'+ id)
                .then(function(response){
                  return response.data;
                });
          }
          function update(id, jobDetails){
                return $http.put(apiUrl +'jobDetails/' + id, jobDetails);
          }
          function create(jobDetails){
            return $http
                .post(apiUrl, 'jobDetails')
                .then(function(response){
                  return response.data;
                });
          }
          function remove(id){
            return $http
            .delete(apiUrl +'jobDetails/' + id)
            .then(function(response){
              return response.data;
            });
          }
        }
})();
