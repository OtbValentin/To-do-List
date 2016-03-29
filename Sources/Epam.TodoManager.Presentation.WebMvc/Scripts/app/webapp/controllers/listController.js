angular.module('app').controller('listController', function ($scope, $rootScope, listService, $location, $routeParams, $route) {
    $scope.$on('list added', function () {
    });

    $scope.toggle = function () {
        $scope.isCollapsed = !$scope.isCollapsed;
    }

    $scope.setActive = function (list) {
        listService.setActiveList(list);
    }

    $scope.showAddListDialog = function () {
        listService.showAddListDialog();
    }

    $scope.addNewList = function (title) {
        listService.addList('title');
    }

    $scope.showEditListDialog = function (list) {
        listService.showEditListDialog(list);
    }

    $scope.showUserSettingsDialog = function () {
        $rootScope.$broadcast('showUserSettingsDialog', null);
    }

    $scope.$on('activeListUpdated', function () {
        $scope.activeList = listService.activeList;
    });

    $scope.isCollapsed = false;
    $scope.lists = listService.todoLists;
    $scope.activeList = null;

    $scope.$on('routeChanged', function () {
        $scope.setActive(listService.todoLists.filter(function (list) { return list.Id == $routeParams.listid })[0]);
    });

    $scope.userName = 'Valentin';
});