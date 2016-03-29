angular.module('app').controller('editListController', function ($scope, listsService) {
    $scope.$on('showEditListDialog', function (event, args) {
        $scope.listToEdit = args;
        $scope.newListTitle = $scope.listToEdit.Title;
        $scope.showEditListDialog = true;
    });

    $scope.saveChanges = function () {
        if ($scope.newListTitle != $scope.listToEdit.Title) {
            $scope.renameList($scope.listToEdit, $scope.newListTitle);
        }

        $scope.closeEditListDialog();
    }

    $scope.renameList = function (list, newTitle) {
        listsService.renameList(list, newTitle);
    }

    $scope.deleteList = function () {
        listsService.deleteList($scope.listToEdit);
        $scope.closeEditListDialog();
    }

    $scope.showEditListDialog = false;
    $scope.newListTitle = '';
    $scope.listToEdit = null;
});
