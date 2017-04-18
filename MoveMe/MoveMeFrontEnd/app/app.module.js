(function() {
    'use strict';

    angular
        .module('app', [
          'mgo-angular-wizard',
          'ui.router',
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
          $urlRouterProvider.otherwise('/');

          $stateProvider
            .state('home', {
              url: '/home',
            })

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
            templateUrl: 'app/orders/orders.grid.html'
          })
        })

})();
