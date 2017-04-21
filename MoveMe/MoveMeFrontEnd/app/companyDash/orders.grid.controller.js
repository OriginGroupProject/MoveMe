(function() {
    'use strict';

    angular
        .module('app.orders')
        .controller('OrdersGridController', OrdersGridController);

    OrdersGridController.$inject = ['ordersFactory'];

    /* @ngInject */
    function OrdersGridController(ordersFactory) {
        var vm = this;

        activate();

        function activate(){
          ordersFactory
          .getAll()
          .then(function(orders){
            vm.orders = orders;
          })
        }

    }
})();
