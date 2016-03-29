angular.module('app').controller('addListController', function ($scope, listService) {

    $scope.$on('showAddListDialog', function () {
        $scope.showAddListDialog = true;
        $scope.newListTitle = '';
    });

    $scope.closeAddListDialog = function () {
        $scope.showAddListDialog = false;
        $scope.newListTitle = '';
    }

    $scope.addNewList = function (title) {
        listService.addList(title);
        $scope.closeAddListDialog();
    }

    $scope.showAddListDialog = false;
    $scope.newListTitle = '';
});
