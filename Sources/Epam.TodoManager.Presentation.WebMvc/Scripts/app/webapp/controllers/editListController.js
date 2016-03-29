angular.module('app').controller('editListController', function ($scope, listService) {
    $scope.$on('closeDialogs', function () { $scope.closeEditListDialog(); });

    $scope.$on('showEditListDialog', function (event, args) {
        $scope.listToEdit = args;
        $scope.newListTitle = $scope.listToEdit.Title;
        $scope.showEditListDialog = true;
    });

    $scope.closeEditListDialog = function () {
        $scope.listToEdit = null;
        $scope.newListTitle = '';
        $scope.showEditListDialog = false;
    }

    $scope.saveChanges = function () {
        if ($scope.newListTitle != $scope.listToEdit.Title) {
            $scope.renameList($scope.listToEdit, $scope.newListTitle);
        }

        $scope.closeEditListDialog();
    }

    $scope.renameList = function (list, newTitle) {
        listService.renameList(list, newTitle);
    }

    $scope.deleteList = function () {
        listService.deleteList($scope.listToEdit);
        $scope.closeEditListDialog();
    }

    $scope.showEditListDialog = false;
    $scope.newListTitle = '';
    $scope.listToEdit = null;
});
