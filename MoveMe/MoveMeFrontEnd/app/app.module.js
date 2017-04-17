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
          'app.orderDetail',
          'app.results',
          'app.wizard'
        ])
        .value('apiUrl', 'https://localhost:57488/api/')
        .config(function($stateProvider, $urlRouterProvider){
          $urlRouterProvider.otherwise('/wizard');


        $stateProvider
          .state('wizard', {
            url: '/wizard',
            controller: 'WizardController as wizCtrl',
            templateUrl: 'app/wizard/wizard.html'
          })
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
        })

})();
