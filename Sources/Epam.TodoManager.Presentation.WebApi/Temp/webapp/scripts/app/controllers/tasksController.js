angular.module('app').controller('tasksController', function ($scope, listsService) {
    $scope.$on('tasks update', function () {
        $scope.tasks = listsService.todoLists[listsService.activeListIndex].todos;
        $scope.newTaskTitle = '';
        $scope.$apply();
    });

    $scope.toggleCompletedTasks = function () {
        $scope.showCompleted = !$scope.showCompleted;
    }

    $scope.setCompleted = function (task) {
        task.isCompleted = true;
    }

    $scope.setUncompleted = function (task) {
        task.isCompleted = false;
    }

    $scope.$on('index update', function () {
        $scope.tasks = listsService.todoLists[listsService.activeListIndex].todos;
        $scope.showCompleted = false;
    });
    $scope.tasks = listsService.todoLists[listsService.activeListIndex].todos;
    $scope.showCompleted = false;
});