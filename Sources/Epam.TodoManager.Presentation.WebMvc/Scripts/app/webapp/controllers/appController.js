angular.module('app').controller('appController', function ($scope, listService, $rootScope) {
    $scope.closeAllDialogs = function ($event) {
        if ($event.keyCode == 27) {
            console.log('close dialogs broadcast');
            $rootScope.$broadcast('closeDialogs');
        }
    };

    $scope.showAddListDialog = function()
    {
        listService.showAddListDialog();
    }

    $scope.showEditListDialog = function () {
        listService.showEditListDialog();
    }

    $scope.showEditAccountDialog = function () {
        $rootScope.$broadcast('showUserSettingsDialog');
    }
});
