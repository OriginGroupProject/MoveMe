(function() {
    'use strict';

    angular
        .module('app')
        .controller('LoginController', LoginController);

    LoginController.$inject = ['$state', 'authFactory'];

    /* @ngInject */
    function LoginController($state, authFactory) {
        var vm = this;

        vm.login = login;

        ////////////////

        function login() {
        	authFactory.login(vm.username, vm.password).then(
        		function(response) {
        			;

        		},
        		function(error) {
        			alert(error.error_description);
        		}
      		);
        }
    }
})();
