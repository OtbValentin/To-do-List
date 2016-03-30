(function () {
    'use strict';

    angular.module('app', [
        // Angular modules 
        'ngRoute',
        'ngResource',
        'ngCookies',

        // Custom modules 

        // 3rd Party Modules
        'angular-oauth2',
        'ui.sortable'
    ])
    .config(['OAuthProvider', function (OAuthProvider) {
        OAuthProvider.configure({
            baseUrl: "http://localhost:51733/api",
            grantPath: "/Account/Token",
            clientId: "WebApp"
        });
    }])
    .config(['OAuthTokenProvider', function (OAuthTokenProvider) {
        OAuthTokenProvider.configure({
            name: 'token',
            options: {
                secure: false
            }
        });
    }])
    .config(['$routeProvider',
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
            redirectTo: 'lists'
        });
        }
    ]);
})();