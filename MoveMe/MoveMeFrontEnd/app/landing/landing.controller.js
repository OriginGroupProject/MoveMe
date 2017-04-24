(function() {
    'use strict';

    angular
        .module('app.landing')
        .controller('landingController', landingController);

    landingController.$inject = ['userFactory', '$state'];

    /* @ngInject */
    function landingController(userFactory, $state) {
        var vm = this;

        activate();

        function activate() {

        }
    }
})();
