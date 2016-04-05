angular.module('app').controller('listsRouteController', function ($scope, $routeParams, $rootScope) {
    $rootScope.$broadcast('routeChanged');
}).controller('tasksRouteController', function ($scope, $rootScope) {
    $rootScope.$broadcast('routeChanged');
}).controller('detailsRouteController', function ($scope, $rootScope) {
    console.log('details route controller');
    $rootScope.$broadcast('routeChanged');
});