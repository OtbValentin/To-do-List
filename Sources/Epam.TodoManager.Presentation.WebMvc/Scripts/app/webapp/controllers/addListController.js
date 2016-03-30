angular.module('app').controller('addListController', function ($scope, dataService) {

    $scope.$on('closeDialogs', function () { $scope.closeAddListDialog(); });

    $scope.$on('showAddListDialog', function () {
        $scope.showAddListDialog = true;
        $scope.newListTitle = '';
    });

    $scope.closeAddListDialog = function () {
        $scope.showAddListDialog = false;
    }

    $scope.addNewList = function (title) {
        dataService.createList(title);
        $scope.closeAddListDialog();
        console.log('new list was added', dataService.data);
    }

    $scope.showAddListDialog = false;
    $scope.newListTitle = '';
});
