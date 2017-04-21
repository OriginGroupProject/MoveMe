(function() {
    'use strict';

    angular
        .module('app.wizard')
        .controller('WizardController', WizardController);

    WizardController.$inject = [];

    /* @ngInject */
    function WizardController() {
        var vm = this;

        vm.enterValidation = function(){
            return true;
        };

        vm.exitValidation = function(){
            return true;
        };
        //example using context object
        vm.exitValidation = function(context){
            return context.firstName === "Andri-jay";
        }
        //example using promises
        vm.exitValidation = function(){
            var d = $q.defer()
            $timeout(function(){
                return d.resolve(true);
            }, 2000);
            return d.promise;
        }


        vm.jobDetail = {};
        vm.save = save;

        function save() {

        };
    }
})();
