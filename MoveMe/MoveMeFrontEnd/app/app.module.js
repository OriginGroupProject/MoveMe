(function() {
    'use strict';

    angular
        .module('app', [
          'chart.js',
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
        .value('apiUrl', 'http://localhost:57488/api/')
        .config(function($stateProvider, $urlRouterProvider){
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
        })

})();
