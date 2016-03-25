var app = angular.module("app", ['ngRoute', 'ui.sortable']);

app.config(['$routeProvider',
  function ($routeProvider) {
      $routeProvider.
        when('/lists', {
            templateUrl: 'Lists',
            controller: 'listsRouteController'
        }).
        when('/lists/:listid', {
            templateUrl: 'Tasks',
            controller: 'tasksRouteController'
        }).
        when('/lists/:listid/tasks/:taskid', {
            templateUrl: 'Task',
            controller: 'detailsRouteController'
        }).
        otherwise({
            redirectTo: 'Lists'
        });
  }]);