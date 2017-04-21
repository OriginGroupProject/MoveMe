(function() {
    'use strict';

    angular
        .module('app.orders')
        .controller('OrdersGridController', OrdersGridController);

    OrdersGridController.$inject = ['jobDetailFactory'];

    /* @ngInject */
    function OrdersGridController(jobDetailFactory) {
        var vm = this;

        activate();

        function activate(){
          jobDetailFactory
          .getAll()
          .then(function(jobDetails){
            vm.jobDetails = jobDetails;
          });
        }

       function remove(order){
          ordersFactory
          .remove(order.orderId)
          .then(function() {
            vm.orders.splice(vm.orders.indexOf(order), 1);
          });
        }

    }
})();
