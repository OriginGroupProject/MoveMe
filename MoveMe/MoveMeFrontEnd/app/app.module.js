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
          'app.orders',
          'app.orderDetail',
          'app.results',
          'app.wizard'
        ])
        .value('apiUrl', 'https://localhost:57488/api/')
        .config(function($stateProvider, $urlRouterProvider){
          $urlRouterProvider.otherwise('/home');
          $stateProvider
            .state('home', {
              url: '/home',
              templateUrl: 'app/landing/landing.html'
            })


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
          .state('order', {
            url: '/detail',
            controller: 'OrdersDetailController as ordersDetailCtrl',
            templateUrl: 'app/companyDash/orders.detail.html'
          })
        })

})();
