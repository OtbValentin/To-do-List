angular.module('app').controller('taskController', function ($scope, dataService, listService, $routeParams, $filter) {
    console.log('tasks controller');

    $scope.sortableOptions = {
        stop: function (event, ui) {
            console.log('sortable stop')
        }
    }

    $scope.redirectToTask = function (task) {
        document.location = '#/lists/' + $scope.data.activeList.Id + '/tasks/' + task.Id;
    }

    $scope.addTask = function (title) {
        dataService.createTask($scope.data.activeList, title);
        $scope.newTaskTitle = '';
    }

    $scope.selectTask = function (task) {
        dataService.selectTask(task);
    }

    $scope.toggleCompletedTasks = function () {
        $scope.data.showCompleted = !$scope.data.showCompleted;
    };

    $scope.setCompleted = function ($event, task) {

        task.IsCompleted = true;
        document.getElementById('wl3-complete').load();
        document.getElementById('wl3-complete').play();
        $event.stopPropagation();

        dataService.saveTask($scope.data.activeList, task);
    };

    $scope.setUncompleted = function ($event, task) {
        task.IsCompleted = false;
        $event.stopPropagation();

        dataService.saveTask($scope.data.activeList, task);
    };

    $scope.stopPropagation = function ($event) {
        $event.stopPropagation();
    };

    $scope.data = dataService.data;
    $scope.newTaskTitle = '';
});