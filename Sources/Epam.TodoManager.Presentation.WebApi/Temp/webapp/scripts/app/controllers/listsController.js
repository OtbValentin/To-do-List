angular.module('app').controller('listsController', function ($scope, listsService) {
    $scope.$on('lists update', function () {
        $scope.lists = listsService.todoLists;
        $scope.$apply();
    });

    $scope.toggle = function () {
        $scope.isCollapsed = !$scope.isCollapsed;
    }

    $scope.setActive = function (index) {
        listsService.setActive(index);
    }

    $scope.$on('index update', function () {
        $scope.activeListIndex = listsService.activeListIndex;
    });

    $scope.isCollapsed = false;
    $scope.lists = listsService.todoLists;
    $scope.activeListIndex = -1;

    if (listsService.todoLists.length > 0) {
        listsService.setActive(0);
    }
});