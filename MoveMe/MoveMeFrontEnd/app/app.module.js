(function() {
    'use strict';

    angular
        .module('app', [
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
          $urlRouterProvider.otherwise('/landing');
})();
