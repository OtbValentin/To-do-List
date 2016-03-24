angular.module('app').controller('appController', function ($scope, listsService) {
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
        console.log('canceled');
        $scope.showAddListDialog = false;
        $scope.newListTitle = '';
    }

    $scope.closeEditListDialog = function () {
        $scope.showEditListDialog = false;
        $scope.newListTitle = '';
        $scope.listToEdit = null;
    }

    $scope.addNewList = function (title) {
        listsService.addList(title);
        $scope.closeAddListDialog();
    }

    $scope.showAddListDialog = false;
    $scope.showEditListDialog = false;
    $scope.newListTitle = '';
    $scope.listToEdit = null;
});
