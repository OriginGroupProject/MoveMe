(function() {
    'use strict';

    angular
        .module('app.ordersDetail')
        .controller('OrdersDetailController', OrdersDetailController);

    OrdersDetailController.$inject = ['jobDetailFactory', '$stateParams'];

    /* @ngInject */
    function OrdersDetailController(jobDetailFactory, $stateParams) {
        var vm = this;

        activate();

        function activate(){
          jobDetailFactory
          .getById($stateParams.id)
          .then(function(jobDetails){
            vm.jobDetails = jobDetails;
            console.log(vm.jobDetails);
          });
        }

        function save(){
          jobDetailFactory
          .update(vm.jobDetails.jobDetailsId, vm.jobDetails)
          .then(
            console.log("Mr.Anderson... it seems you've changed " + vm.jobDetails.firstName)
          )
        }
    }
})();
