var app = angular.module("app", ['ngRoute']);

app.config(['$routeProvider',
  function ($routeProvider) {
      $routeProvider.
        when('/lists', {
            templateUrl: 'webapp/lists',
            controller: 'tasksController'
        }).
        when('/lists/:listid', {
            templateUrl: 'webapp/tasks',
            controller: 'tasksController'
        }).
        otherwise({
            redirectTo: '/lists'
        });
  }]);