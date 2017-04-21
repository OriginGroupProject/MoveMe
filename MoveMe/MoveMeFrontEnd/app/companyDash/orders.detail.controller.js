(function() {
    'use strict';

    angular
        .module('app.orders')
        .controller('OrdersDetailController', OrdersDetailController);

    OrdersDetailController.$inject = ['ordersFactory', '$stateParams'];

    /* @ngInject */
    function OrdersDetailController(ordersFactory, $stateParams) {
        var vm = this;



        activate();

        function activate() {
          //http://localhost:3000/#/orders/detail/1
          // grab the order that matches the id provided in the URL
          var orderId = $stateParams.id;

          ordersFactory
            .getById(orderId)
            .then(function(orders) {
              vm.order = orders;
            })
            .catch(function(error) {
              alert(error);
            });
        }

    }
})();
