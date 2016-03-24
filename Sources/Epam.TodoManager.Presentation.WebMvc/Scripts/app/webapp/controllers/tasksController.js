angular.module('app').controller('tasksController', function ($scope, listsService, $routeParams) {
    console.log('tasks controller');
    console.log(listsService.selectedTask);
    $scope.$on('taskAdded', function () {
        $scope.newTaskTitle = '';
    });

    $scope.redirectToTask = function (task) {
        document.location = '#/lists/' + $scope.activeList.Id + '/tasks/' + task.Id;
    }

    $scope.addTask = function (title) {
        listsService.addTask(listsService.activeList, title);
    }

    $scope.selectTask = function (task) {
        console.log('selected task in task cntrl');
        listsService.selectTask(task);
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
        $scope.selectedTask = listsService.selectedTask;
    });

    $scope.$on('activeListUpdated', function () {
        $scope.activeList = listsService.activeList;
    });

    $scope.stopPropagation = function ($event) {
        $event.stopPropagation();
    };

    $scope.updateSelected = function () {
        listsService.setActiveList(listsService.todoLists.filter(function (list) { return list.Id == $routeParams.listid })[0]);
        var taskId = $routeParams.taskid;

        if (taskId != null && taskId != undefined) {
            listsService.selectTask(listsService.activeList.TodoItems.filter(function (task) { return task.Id == taskId })[0]);
            console.log('assigned task', listsService.selectedTask);
        }
    };

    $scope.$on('routeChanged', $scope.updateSelected);

    $scope.showCompleted = lists.showCompleted;
    $scope.updateSelected();
    $scope.selectedTask = listsService.selectedTask;

    console.log('final selected', $scope.selectedTask, listsService.selectedTask);
});