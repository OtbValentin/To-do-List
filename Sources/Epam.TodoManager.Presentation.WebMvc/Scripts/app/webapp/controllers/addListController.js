angular.module('app').controller('addListController', function ($scope, listsService) {

    $scope.$on('showAddListDialog', function () {
        $scope.showAddListDialog = true;
        $scope.newListTitle = '';
    });

    $scope.closeAddListDialog = function () {
        $scope.showAddListDialog = false;
        $scope.newListTitle = '';
    }

    $scope.addNewList = function (title) {
        listsService.addList(title);
        $scope.closeAddListDialog();
    }

    $scope.showAddListDialog = false;
    $scope.newListTitle = '';
});
