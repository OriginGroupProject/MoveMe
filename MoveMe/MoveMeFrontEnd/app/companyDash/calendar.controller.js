(function() {
	'use strict';

	angular
		.module('app')
		.controller('CalendarController', CalendarController);

	CalendarController.$inject = ['MoversDashFactory', 'uiCalendarConfig'];

	function CalendarController(MoversDashFactory, uiCalendarConfig) {
		var vm = this;

		function getEvents(start, end, timezone, callback) {
			MoversDashFactory
				.getCalendar()
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
	}
})();
