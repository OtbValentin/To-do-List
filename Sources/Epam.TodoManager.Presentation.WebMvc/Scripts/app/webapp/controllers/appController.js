angular.module('app').controller('appController', function ($scope, dataService, OAuth, $rootScope, $routeParams) {
    if (!OAuth.isAuthenticated()) {
        document.location = '/login';
    }

    $scope.closeAllDialogs = function ($event) {
        if ($event.keyCode == 27) {
            console.log('close dialogs broadcast');
            $rootScope.$broadcast('closeDialogs');
        }
    } 
    
    $scope.updateSelection = function () {
        var listId = $routeParams.listid;
        if (!!listId) {
            dataService.activeList = listService.todoLists.filter(function (list) { return list.Id == $routeParams.listid })[0];

            var taskId = $routeParams.taskid;

            if (!!taskId) {
                dataService.selectedTask = dataService.activeList.TodoItems.filter(function (task) { return task.Id == taskId })[0];
            }
            else {
                dataService.selectedTask = null;
            }
        }
        else {
            dataService.activeList = null;
            dataService.selectedTask = null;
        }
    };

    $scope.$on('routeChanged', function () { $scope.updateSelection(); });

    $scope.updateSelection();
});
