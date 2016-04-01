angular.module('app').controller('listController', function ($scope, $rootScope, dataService, listService, $location, $routeParams, $route) {

    $scope.toggle = function () {
        $scope.isCollapsed = !$scope.isCollapsed;
    }

    $scope.setActive = function (list) {
        dataService.selectList(list);
    }

    $scope.showAddListDialog = function () {
        $rootScope.$broadcast('showAddListDialog');
    }

    $scope.showEditListDialog = function (list) {
        $rootScope.$broadcast('showEditListDialog', list);
    }

    $scope.showUserSettingsDialog = function () {
        $rootScope.$broadcast('showUserSettingsDialog');
    }

    $scope.isCollapsed = false;
    $scope.data = dataService.data;
    $scope.searchTitle = '';
});