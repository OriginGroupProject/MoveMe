(function() {
    'use strict';

    angular
        .module('app', [
            'chart.js',
            'ui.router',
            'ui.calendar',
            'mgo-angular-wizard',
            'app.companyDash',
            'app.companyForm',
            'app.customerDash',
            'app.landing',
            'app.orderDetail',
            'app.results',
            'app.wizard'
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
                .state('companydash', {
                    url: '/companydash',
                    controller: 'CompanyDashController as companyDashCtrl',
                    templateUrl: 'app/companyDash/companyDash.html'
                });

            $stateProvider
                .state('orders', {
                    url: '/orders',
                    abstract: true,
                    template: '<div ui-view></div>'
                })
                .state('orders.grid', {
                    url: '/grid',
                    controller: 'OrdersGridController as ordersGridCtrl',
                    templateUrl: 'app/orders/orders.grid.html'
                })
        });
})();
