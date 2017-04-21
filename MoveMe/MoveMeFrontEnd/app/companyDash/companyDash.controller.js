(function() {
    'use strict';

    angular
        .module('app.companyDash')
        .controller('CompanyDashController', CompanyDashController);

    CompanyDashController.$inject = ['MoversDashFactory', 'companiesFactory', '$stateParams', 'uiCalendarConfig'];

    /* @ngInject */
    function CompanyDashController(MoversDashFactory, companiesFactory, $stateParams, uiCalendarConfig) {
        var vm = this;
        vm.widget = "revenueChart";
        activate();

        function getEvents(start, end, timezone, callback) {
    			MoversDashFactory
    				.getCalendar(1)
    				.then(function(events) {
    				      callback(events)
    				});
    		}
    		vm.calendar = {
    			options: {
    				height: 800,
            defaultView: 'month',
    				editable: false,
    				header: {
              left: 'title',
              right: 'today prev,next'
            }
    			},
    			eventSources: [
    				getEvents
    			]
    		};

        function activate() {
            var id = $stateParams.id;

            MoversDashFactory
                .getRevenueChart(1)
                .then(function(data) {
                    vm.revenueChart = {
                        data: data,
                        labels: data.map(data => data.x)
                    };
                });
            MoversDashFactory
                .getUtilizationChart(1)
                .then(function(data) {
                    vm.utilizationChart = {
                        data: data,
                        labels: data.map(data => data.x)
                    };
                });

        }


    }
})();
