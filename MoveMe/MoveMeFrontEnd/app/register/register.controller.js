(function() {
    'use strict';

    angular
        .module('app')
        .controller('RegisterController', RegisterController);

    RegisterController.$inject = ['companiesFactory','authFactory', '$state'];

    /* @ngInject */
    function RegisterController(companiesFactory,authFactory, $state) {
        var vm = this;
        vm.company ={};
        vm.registration = {
        	username: '',
        	password: '',
        	confirmPassword: ''
        };

        vm.save = register;

        ////////////////

        function register() {
        	authFactory.register(vm.registration).then(
        		function(response) {
                    companiesFactory
                        .create(vm.company)
                        .then(function(data){
                            alert('Registration successful! Please login.');
        			        $state.go('login');
                        })
        			alert('Registration successful! Please login.');
        			$state.go('login');
        		},
        		function(response) {
        			alert('Registration form invalid');
        		}
      		);
        }
    }
})();