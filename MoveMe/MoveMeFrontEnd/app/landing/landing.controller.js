(function() {
    'use strict';

    angular
        .module('app.landing')
        .controller('landingController', landingController);

    landingController.$inject = ['userFactory'];

    /* @ngInject */
    function landingController(userFactory) {
        var vm = this;

        activate();

        function activate() {

        }
    }
})();
