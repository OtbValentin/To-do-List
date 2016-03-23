angular.module('app').controller('detailController', function ($scope, $timeout, listsService) {
    $scope.toggleDetail = function () {
        $scope.showDetail = !$scope.showDetail;
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

    $scope.$on('task selected', function () {
        $scope.task = listsService.selectedTask;
    });

    $scope.$watch('task', function () {
        if ($scope.task == null) {
            $scope.showDetail = false;
        }
    });

    $scope.toggleCompletion = function ($event) {
        $scope.task.isCompleted = !$scope.task.isCompleted;

        if ($scope.task.isCompleted) {
            document.getElementById('wl3-complete').load();
            document.getElementById('wl3-complete').play();
            $event.stopPropagation();
        }
    }


    $scope.showDetail = false;
    $scope.task = null;
    $scope.noteEditing = false;
});