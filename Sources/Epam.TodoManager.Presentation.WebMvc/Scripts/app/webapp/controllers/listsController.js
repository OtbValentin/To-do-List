angular.module('app').controller('listsController', function ($scope, listsService, $location, $routeParams, $route) {
    $scope.$on('list added', function () {
    });

    $scope.toggle = function () {
        $scope.isCollapsed = !$scope.isCollapsed;
    }

    $scope.setActive = function (list) {
        listsService.setActiveList(list);
    }

    $scope.addNewList = function () {
        listsService.addList('New list title');
    }

    $scope.$on('activeListUpdated', function () {
        $scope.activeList = listsService.activeList;
    });

    $scope.isCollapsed = false;
    $scope.lists = listsService.todoLists;
    $scope.activeList = null;

    $scope.$on('routeChanged', function () {
        $scope.setActive(listsService.todoLists.filter(function (list) { return list.Id == $routeParams.listid })[0]);
    });

    $scope.userName = 'Valentin';
});