(function() {
    'use strict';

    angular
        .module('app.orderDetail')
        .controller('orderDetailController', orderDetailController);

    orderDetailController.$inject = ['userFactory', 'ordersFactory', 'paymentDetailFactory'];

    /* @ngInject */
    function orderDetailController(userFactory, ordersFactory, paymentDetailFactory) {
        var vm = this;

        activate();

        function activate() {

        }
    }
})();
