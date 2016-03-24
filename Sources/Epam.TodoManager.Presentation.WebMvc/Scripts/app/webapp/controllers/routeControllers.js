angular.module('app').controller('listsRouteController', function ($scope, $routeParams) {
    console.log('started lists route controller');
    console.log($routeParams);
    console.log('AHSHSHHSSHHS');
}).controller('tasksRouteController', function ($scope) {
    console.log('started tasks route controller');
}).controller('detailsRouteController', function ($scope) {
    console.log('started details route controller');
});