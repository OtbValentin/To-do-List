angular.module('app').controller('tasksController', function ($scope, listsService, $routeParams) {
    console.log('started tasks controller');
    $scope.$on('taskAdded', function () {
        $scope.newTaskTitle = '';
    });

    $scope.redirectToTask = function(task)
    {
        document.location = '/lists/' + $scope.activeList.Id + '/tasks/' + $scope.task.Id;
    }

    $scope.addTask = function (title) {
        listsService.addTask(listsService.activeList, title);
    }

    $scope.selectTask = function (task) {
        listsService.selectTask(task);
    }

    $scope.toggleCompletedTasks = function () {
        $scope.showCompleted = !$scope.showCompleted;
    };

    $scope.setCompleted = function ($event, task) {
        task.IsCompleted = true;
        document.getElementById('wl3-complete').load();
        document.getElementById('wl3-complete').play();
        $event.stopPropagation();
    };

    $scope.setUncompleted = function ($event, task) {
        task.IsCompleted = false;
        $event.stopPropagation();
    };

    $scope.$on('taskSelected', function () {
        $scope.selectedTask = listsService.selectedTask;
    });

    $scope.stopPropagation = function ($event) {
        $event.stopPropagation();
    };

    $scope.activeList = null;
    $scope.selectedTask = null;
    $scope.showCompleted = false;
});