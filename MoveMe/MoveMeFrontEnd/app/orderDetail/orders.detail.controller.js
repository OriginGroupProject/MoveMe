(function() {
    'use strict';

    angular
        .module('app.orderDetail')
        .controller('OrderDetailController', OrderDetailController);

    OrderDetailController.$inject = ['jobDetailFactory', '$stateParams'];

    /* @ngInject */
    function OrderDetailController(jobDetailFactory, $stateParams) {

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
