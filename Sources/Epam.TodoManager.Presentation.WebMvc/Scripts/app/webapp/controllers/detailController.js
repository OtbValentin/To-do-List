angular.module('app').controller('detailsController', function ($scope, $timeout, listsService) {
    console.log('started details controller');
    $scope.toggleDetail = function () {
        $scope.showDetail = !$scope.showDetail;
    }

    $scope.deleteTask = function (task) {
        listsService.deleteTask(listsService.activeList, task);
        listsService.selectTask(null);
    }

    $scope.deleteNote = function (task) {
        console.log('remove note', task);
        task.Note = "";
    }

    $scope.deleteDueDate = function (task) {
        console.log('remove date', task);
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
        console.log('selected task', $scope.task);
        $scope.task = listsService.selectedTask;
    });

    $scope.$on('showTaskDetails', function () {
        console.log('show details in detail controller');
        $scope.showDetail = true;
    });

    $scope.$watch('task', function () {
        if ($scope.task == null) {
            $scope.showDetail = false;
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
    $scope.task = null;
    $scope.noteEditing = false;
    $scope.dateEditing = false;
    $scope.titleEditing = false;
    $scope.overdue = false;
    $scope.showAddListDialog = false;
});