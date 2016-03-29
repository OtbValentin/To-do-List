angular.module('app').controller('taskController', function ($scope, listService, $routeParams, $filter) {
    console.log('tasks controller');
    console.log(listService.selectedTask);

    $scope.sortableOptions = {
        stop: function (event, ui) {
            console.log('sortable stop')
        }
    }

    $scope.$on('taskAdded', function () {
        $scope.newTaskTitle = '';
    });

    $scope.redirectToTask = function (task) {
        document.location = '#/lists/' + $scope.activeList.Id + '/tasks/' + task.Id;
    }

    $scope.addTask = function (title) {
        listService.addTask(listService.activeList, title);
    }

    $scope.selectTask = function (task) {
        listService.selectTask(task);
    }

    $scope.toggleCompletedTasks = function () {
        $scope.showCompleted = !$scope.showCompleted;
        lists.showCompleted = $scope.showCompleted;
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
        $scope.selectedTask = listService.selectedTask;
    });

    $scope.$on('activeListUpdated', function () {
        $scope.activeList = listService.activeList;
    });

    $scope.stopPropagation = function ($event) {
        $event.stopPropagation();
    };

    $scope.updateSelected = function () {
        listService.setActiveList(listService.todoLists.filter(function (list) { return list.Id == $routeParams.listid })[0]);
        var taskId = $routeParams.taskid;

        if (taskId != null && taskId != undefined) {
            listService.selectTask(listService.activeList.TodoItems.filter(function (task) { return task.Id == taskId })[0]);
        }
    };

    $scope.$on('routeChanged', $scope.updateSelected);

    $scope.showCompleted = lists.showCompleted;
    $scope.updateSelected();
    $scope.selectedTask = listService.selectedTask;
});