var app = angular.module("app", ['ngRoute', 'ui.sortable']);

app.config(['$routeProvider',
  function ($routeProvider) {
      $routeProvider.
        when('/lists', {
            templateUrl: '/webapp/lists',
            controller: 'listsRouteController'
        }).
        when('/lists/:listid', {
            templateUrl: '/webapp/tasks',
            controller: 'tasksRouteController'
        }).
        when('/lists/:listid/tasks/:taskid', {
            templateUrl: '/webapp/task',
            controller: 'detailsRouteController'
        }).
        otherwise({
            redirectTo: '/lists'
        });
  }]);