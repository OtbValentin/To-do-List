var app = angular.module("app", ['ngRoute']);

//app.config(['$routeProvider',
//  function ($routeProvider) {
//      $routeProvider.
//        when('/lists', {
//            templateUrl: 'home/lists',
//            controller: 'PhoneListCtrl'
//        }).
//        when('/phones/:phoneId', {
//            templateUrl: 'partials/phone-detail.html',
//            controller: 'PhoneDetailCtrl'
//        }).
//        otherwise({
//            redirectTo: '/phones'
//        });
//  }]);