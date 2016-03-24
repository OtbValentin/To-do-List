angular.module('app').controller('listsController', function ($scope, listsService, $routeParams) {

    console.log('started lists controller');
    $scope.$on('list added', function () {
    });

    $scope.toggle = function () {
        $scope.isCollapsed = !$scope.isCollapsed;
    }

    $scope.setActive = function (list) {
        console.log('controller setActive', list);
        listsService.setActiveList(list);
    }

    $scope.addNewList = function () {
        listsService.addList('New list title');
        //listsService.setActiveList(listsService.todoLists[listsService.todoLists.length - 1]);
        listsService.selectTask(null);
    }

    $scope.$on('activeListUpdated', function () {
        $scope.activeList = listsService.activeList;
    });

    $scope.isCollapsed = false;
    $scope.lists = listsService.todoLists;
    $scope.activeList = null;
    console.log($scope.lists);
    $scope.$on('stateChangeSuccess', function () {
        console.log('state change success');
        console.log($routeParams);
        console.log($routeParams["listid"]);
        console.log($routeParams.listid);
        $scope.setActive(listsService.todoLists.filter(function (list) { console.log(list.Id); return list.Id == $routeParams.listid })[0]);
    });

    $scope.userName = 'Valentin';
});