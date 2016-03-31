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
            dataService.selectList(dataService.data.lists.filter(function (list) { return list.Id == $routeParams.listid })[0]);

            var taskId = $routeParams.taskid;

            if (!!taskId) {
                dataService.selectTask(dataService.data.activeList.TodoItems.filter(function (task) { return task.Id == taskId })[0]);
            }
            else {
                dataService.selectTask(null);
            }
        }
        else {
            dataService.selectList(null);
            dataService.selectTask(null);
        }
    };

    $scope.$on('routeChanged', function () { $scope.updateSelection(); });

    $scope.updateSelection();
});
