angular.module('app').controller('detailsController', function ($scope, dataService, listService, taskService, $routeParams) {
    console.log('details controller');
    $scope.closeDetail = function () {
        document.location = '#/lists/' + $routeParams.listid;
    }

    $scope.deleteTask = function (task) {
        dataService.deleteTask($routeParams.listid, $routeParams.taskid);
    }

    $scope.deleteNote = function (task) {
        task.Note = "";
        dataService.saveTask(dataService.activeList, task);
    }

    $scope.deleteDueDate = function (task) {
        task.DueDate = null;
        dataService.saveTask($scope.data.activeList, task);
    }

    $scope.toggleNoteEditing = function () {
        $scope.noteEditing = !$scope.noteEditing;
    }
    
    $scope.beginNoteEditing = function () {
        $scope.noteEditing = true;
    }

    $scope.stopNoteEditing = function () {
        $scope.noteEditing = false;
    }

    $scope.beginDateEditing = function () {
        $scope.dateEditing = true;
    }

    $scope.stopDateEditing = function () {
        $scope.dateEditing = false;
    }

    $scope.beginTitleEditing = function () {
        $scope.titleEditing = true;
    }

    $scope.stopTitleEditing = function () {
        $scope.titleEditing = false;
    }

    //$scope.$watch('task', function () {
    //    if ($scope.task == null) {
    //        $scope.closeDetail();
    //    }
    //});

    $scope.toggleCompletion = function ($event) {
        console.log("completion");
        $scope.data.selectedTask.IsCompleted = !$scope.data.selectedTask.IsCompleted;

        if ($scope.data.selectedTask.IsCompleted) {
            document.getElementById('wl3-complete').load();
            document.getElementById('wl3-complete').play();
            $event.stopPropagation();
        }

        dataService.saveTask($scope.data.activeList, $scope.data.selectedTask);
    }

    $scope.compareDates = function (a, b) {
        return a - b;
    }

    $scope.$watch('data.selectedTask.DueDate', function () {
        if ($scope.task != null && $scope.task.DueDate != null && $scope.compareDates(Date.parse($scope.task.DueDate), Date.now()) < 0) {
            $scope.overdue = true;
        }
        else
        {
            $scope.overdue = false;
        }
    });

    $("#datepicker").datepicker();
    $scope.noteEditing = false;
    $scope.dateEditing = false;
    $scope.titleEditing = false;
    $scope.overdue = false;

    $scope.data = dataService.data;
});