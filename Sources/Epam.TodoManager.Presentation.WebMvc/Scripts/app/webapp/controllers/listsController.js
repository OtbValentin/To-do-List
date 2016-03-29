angular.module('app').controller('listsController', function ($scope, listsService, $location, $routeParams, $route) {
    $scope.$on('list added', function () {
    });

    $scope.toggle = function () {
        $scope.isCollapsed = !$scope.isCollapsed;
    }

    $scope.setActive = function (list) {
        listsService.setActiveList(list);
    }

    $scope.showAddListDialog = function () {
        listsService.showAddListDialog();
    }

    $scope.addNewList = function (title) {
        listsService.addList('title');
    }

    $scope.showEditListDialog = function (list) {
        listsService.showEditListDialog(list);
    }

    $scope.showUserSettingsDialog = function () {
        listsService.showUserSettingsDialog(listsService.user);
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

    $scope.$on('angled.droppable.dropped', function (event) {
        console.log(event);
    });
});