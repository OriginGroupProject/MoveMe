(function() {
    'use strict';

    angular
        .module('app.orders')
        .controller('OrdersDetailController', OrdersDetailController);

    OrdersDetailController.$inject = ['jobDetailFactory', '$stateParams'];

    /* @ngInject */
    function OrdersDetailController(jobDetailFactory, $stateParams) {

        var vm = this;

        activate();

        function activate(){

          var jobDetailId = $stateParams.id;
          
          jobDetailFactory
          .getById(jobDetailId)
          .then(function(jobDetails){
            vm.jobDetails = jobDetails;
            console.log(vm.jobDetails);
          });
        }

        function save(){
          jobDetailFactory
          .update(vm.jobDetails.jobDetailId, vm.jobDetails)
          .then()
        }
    }
})();
