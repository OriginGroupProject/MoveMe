(function() {
  'use strict';

  angular
    .module('app', [
      'ui.router',
      'mgo-angular-wizard',
      'app.wizard',
      'app.customers',
      'oitozero.ngSweetAlert'
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
        .state('customers', {
          url: '/customers',
          abstract: true,
          template: '<div ui-view></div>'
        })
        .state('customers.grid', {
          url: '/grid', //http://localhost:3000/#/grid
          controller: 'CustomersGridController as customersGridCtrl',
          templateUrl: 'app/customers/customers.grid.html'
        });
    })

})();
