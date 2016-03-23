angular.module('app').controller('listsController', function ($scope, listsService) {
    $scope.$on('list added', function () {
    });

    $scope.toggle = function () {
        $scope.isCollapsed = !$scope.isCollapsed;
    }

    $scope.setActive = function (list) {
        if (list != $scope.activeList) {
            listsService.setActiveList(list);
            listsService.selectTask(null);
        }
    }

    $scope.addNewList = function () {
        listsService.addList('New list title');
        listsService.setActiveList(listsService.todoLists[listsService.todoLists.length - 1]);
        listsService.selectTask(null);     
    }

    $scope.$on('active list updated', function () {
        $scope.activeList = listsService.activeList;
    });

    $scope.isCollapsed = false;
    $scope.lists = listsService.todoLists;
    $scope.activeList = listsService.activeList;

    if (listsService.todoLists.length > 0) {
        listsService.setActiveList(listsService.todoLists[0]);
    }
});