angular.module('app').controller('listController', function ($scope, $rootScope, dataService, listService, $location, $routeParams, $route) {

    $scope.toggle = function () {
        $scope.isCollapsed = !$scope.isCollapsed;
    }

    $scope.setActive = function (list) {
        listService.setActiveList(list);
    }

    $scope.showAddListDialog = function () {
        $rootScope.$broadcast('showAddListDialog');
    }

    $scope.showEditListDialog = function (list) {
        $rootScope.$broadcast('showEditListDialog');
    }

    $scope.showUserSettingsDialog = function () {
        $rootScope.$broadcast('showUserSettingsDialog', null);
    }

    $scope.isCollapsed = false;

    $scope.$on('routeChanged', function () {
        $scope.setActive(listService.todoLists.filter(function (list) { return list.Id == $routeParams.listid })[0]);
    });

    $scope.userName = 'Valentin';
});