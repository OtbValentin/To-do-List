var app = angular.module("app", ['ngRoute', 'ui.sortable', 'angled-dragndrop']);

app.config(['$routeProvider',
  function ($routeProvider) {
      $routeProvider.
        when('/lists', {
            templateUrl: 'Webapp/Lists',
            controller: 'listsRouteController'
        }).
        when('/lists/:listid', {
            templateUrl: 'Webapp/Tasks',
            controller: 'tasksRouteController'
        }).
        when('/lists/:listid/tasks/:taskid', {
            templateUrl: 'Webapp/Task',
            controller: 'detailsRouteController'
        }).
        otherwise({
            redirectTo: 'Lists'
        });
  }]);