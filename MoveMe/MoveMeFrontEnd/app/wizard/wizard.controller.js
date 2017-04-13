(function() {
    'use strict';

    angular
        .module('app.wizard')
        .controller('WizardController', WizardController);

    WizardController.$inject = ['jobDetailFactory'];

    /* @ngInject */
    function WizardController(jobDetailFactory) {
        var vm = this;

        vm.jobDetail = {};
        vm.save = save;

        function save() {
            jobDetailFactory
                .create(vm.jobDetail)
                .then(function(data) {
                    alert(data);
                });
        };
    }
})();
