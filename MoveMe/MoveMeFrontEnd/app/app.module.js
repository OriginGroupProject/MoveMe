(function() {
    'use strict';

    angular
        .module('app', [
            'ui.router',
            'mgo-angular-wizard',
            'app.companyDash',
            'app.companyForm',
            'app.customerDash',
            'app.landing',
            'app.results',
            'app.wizard',
            'app.orders'
        ])
        .value('apiUrl', 'http://movemeapi-dev.azurewebsites.net/api/')
        .config(function($stateProvider, $urlRouterProvider) {
            $urlRouterProvider.otherwise('/wizard');


            $stateProvider
                .state('wizard', {
                    url: '/wizard',
                    controller: 'WizardController as wizCtrl',
                    templateUrl: 'app/wizard/wizard.html'
                })
            $stateProvider
                .state('orders', {
                    url: '/orders',
                    abstract: true,
                    template: '<div ui-view></div>'
                })
                $stateProvider
                .state('orders.grid', {
                    url: '/grid',
                    controller: 'OrdersGridController as ordersGridCtrl',
                    templateUrl: 'app/ordersModule/orders.grid.html'
                })
                $stateProvider
                .state('orders.detail', {
                    url: '/detail/:id',
                    controller: 'OrdersDetailController as ordersDetailCtrl',
                    templateUrl: 'app/orderDetail/orders.detail.html'
                })
        })

})();
