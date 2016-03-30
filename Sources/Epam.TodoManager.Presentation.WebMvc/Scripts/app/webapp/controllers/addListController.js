angular.module('app').controller('addListController', function ($scope, dataService) {

    $scope.$on('closeDialogs', function () { $scope.closeAddListDialog(); });

    $scope.$on('showAddListDialog', function () {
        $scope.showAddListDialog = true;
        $scope.newListTitle = '';
    });

    $scope.closeAddListDialog = function () {
        $scope.showAddListDialog = false;
        $scope.newListTitle = '';
    }

    $scope.addNewList = function (title) {
        dataService.addList(title);
        $scope.closeAddListDialog();
    }

    $scope.showAddListDialog = false;
    $scope.newListTitle = '';
});
