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
        $rootScope.$broadcast('showUserSettingsDialog');
    }

    $scope.isCollapsed = false;

    $scope.userName = 'Valentin';
});