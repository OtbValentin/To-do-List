angular.module('app').controller('appController', function ($scope, listsService) {
    $scope.closeAllDialogs = function ($event) {
        if ($event.keyCode == 27) {
            $scope.closeAddListDialog();
            $scope.closeEditListDialog();
            $scope.closeUserSettingsDialog();
        }
    };
    //$scope.$watch(listsService.activeList, function () {
    //    if (listsService.activeList == null) {
    //        document.location = '#/lists';
    //    }
    //});

    $scope.$on('showAddListDialog', function () {
        $scope.showAddListDialog = true;
        $scope.newListTitle = '';
    });

    $scope.$on('showEditListDialog', function (event, args) {
        $scope.listToEdit = args;
        console.log('args', args);
        $scope.newListTitle = $scope.listToEdit.Title;
        $scope.showEditListDialog = true;
    });

    $scope.$on('showUserSettingsDialog', function (event, args) {
        console.log('app controller show user dialog');
        $scope.userToEdit = args;
        $scope.showUserSettingsDialog = true;
    });

    $scope.renameList = function (newTitle) {
        //listsService.renameList($scope.listToEdit, newTitle);
        $scope.listToEdit.Title = newTitle;
        $scope.closeEditListDialog();
    }

    $scope.deleteList = function () {
        listsService.deleteList($scope.listToEdit);
        $scope.closeEditListDialog();
    }

    $scope.closeAddListDialog = function () {
        $scope.showAddListDialog = false;
        $scope.newListTitle = '';
    }

    $scope.closeEditListDialog = function () {
        $scope.showEditListDialog = false;
        $scope.newListTitle = '';
        $scope.listToEdit = null;
    }

    $scope.closeUserSettingsDialog = function () {
        $scope.showUserSettingsDialog = false;
        $scope.userToEdit = null;
    }

    $scope.addNewList = function (title) {
        listsService.addList(title);
        $scope.closeAddListDialog();
    }

    $scope.showAddListDialog = false;
    $scope.showEditListDialog = false;
    $scope.showUserSettingsDialog = false;
    $scope.newListTitle = '';
    $scope.listToEdit = null;
    $scope.userToEdit = null;
});
