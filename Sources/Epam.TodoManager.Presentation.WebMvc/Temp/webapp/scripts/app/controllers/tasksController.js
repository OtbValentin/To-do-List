angular.module('app').controller('tasksController', function ($scope, listsService) {
    $scope.$on('task added', function () {
        $scope.newTaskTitle = '';
    });

    $scope.addTask = function () {
        listsService.addTask(listsService.activeList, $scope.newTaskTitle);
    }

    $scope.selectTask = function(task){
        listsService.selectTask(task);
    }

    $scope.toggleCompletedTasks = function () {
        $scope.showCompleted = !$scope.showCompleted;
    };

    $scope.setCompleted = function ($event, task) {
        task.isCompleted = true;
        document.getElementById('wl3-complete').load();
        document.getElementById('wl3-complete').play();
        $event.stopPropagation();
    };

    $scope.setUncompleted = function ($event, task) {
        task.isCompleted = false;
        $event.stopPropagation();
    };

    $scope.$on('active list updated', function () {
        $scope.activeList = listsService.activeList;
        $scope.showCompleted = false;
    });

    $scope.$on('task selected', function () {
        $scope.selectedTask = listsService.selectedTask;
        //console.log('task selected');
    });

    $scope.stopPropagation = function ($event) {
        $event.stopPropagation();
    };

    $scope.activeList = listsService.activeList;
    $scope.showCompleted = false;
    $scope.selectedTask = null;
});