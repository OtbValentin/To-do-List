angular.module('app').controller('detailsController', function ($scope, $timeout, listService, $routeParams) {
    console.log('details controller');
    $scope.closeDetail = function () {
        document.location = '#/lists/' + $routeParams.listid;
    }

    $scope.deleteTask = function (task) {
        listService.deleteTask(listService.activeList, task);
        listService.selectTask(null);
    }

    $scope.deleteNote = function (task) {
        task.Note = "";
    }

    $scope.deleteDueDate = function (task) {
        task.DueDate = null;
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

    $scope.$on('taskSelected', function () {
        $scope.task = listService.selectedTask;
        document.location = '#/lists/' + listService.activeList.Id + '/tasks/' + $scope.task.Id;
    });

    $scope.$watch('task', function () {
        if ($scope.task == null) {
            $scope.closeDetail();
        }
    });

    $scope.toggleCompletion = function ($event) {
        $scope.task.IsCompleted = !$scope.task.IsCompleted;

        if ($scope.task.IsCompleted) {
            document.getElementById('wl3-complete').load();
            document.getElementById('wl3-complete').play();
            $event.stopPropagation();
        }
    }

    $scope.compareDates = function (a, b) {
        return a - b;
    }

    $scope.$watch('task.DueDate', function () {
        if ($scope.task != null && $scope.task.DueDate != null && $scope.compareDates(Date.parse($scope.task.DueDate), Date.now()) < 0) {
            $scope.overdue = true;
        }
        else
        {
            $scope.overdue = false;
        }
    });

    $("#datepicker").datepicker();
    $scope.showDetail = false;
    $scope.task = listService.selectedTask;
    console.log($scope.task);
    $scope.noteEditing = false;
    $scope.dateEditing = false;
    $scope.titleEditing = false;
    $scope.overdue = false;
});