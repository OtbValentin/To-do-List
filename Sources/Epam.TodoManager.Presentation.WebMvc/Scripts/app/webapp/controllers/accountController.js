angular.module('app').controller('appController', function ($scope, listsService) {
    $scope.closeAllDialogs = function ($event) {
        if ($event.keyCode == 27) {
            $scope.closeAddListDialog();
            $scope.closeEditListDialog();
            $scope.closeUserSettingsDialog();
        }
    };

    $scope.$on('showUserSettingsDialog', function (event, args) {
        console.log('app controller show user dialog');
        $scope.userToEdit = args;
        $scope.showUserSettingsDialog = true;
    });

    $scope.closeUserSettingsDialog = function () {
        $scope.showUserSettingsDialog = false;
        $scope.userToEdit = null;
    }

    $scope.showUserSettingsDialog = false;
    $scope.userToEdit = null;
});
