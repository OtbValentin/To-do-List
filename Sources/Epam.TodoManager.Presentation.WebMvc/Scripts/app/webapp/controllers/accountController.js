﻿angular.module('app').controller('accountController', function ($scope, accountService) {
    $scope.$on('showUserSettingsDialog', function (event, args) {
        $scope.userToEdit = args;
        $scope.showUserSettingsDialog = true;
    });

    $scope.closeUserSettingsDialog = function () {
        $scope.showUserSettingsDialog = false;
        $scope.userToEdit = null;
        $scope.newName = '';
    }

    $scope.saveChanges = function () {
        if ($scope.userToEdit.Name != $scope.newName) {
            $scope.changeName($scope.userToEdit, $s.newName);
        }

        $scope.closeUserSettingsDialog();
    }

    $scope.changeName = function (user, name) {
        account.changeName(use, name);
        $scope.closeUserSettingsDialog();
    }

    $scope.beginEmailEditing = function () {
        $scope.emailEditing = true;
    }

    $scope.stopEmailEditing = function () {
        $scope.emailEditing = false;
    }

    $scope.showUserSettingsDialog = false;
    $scope.newName = '';
    $scope.userToEdit = null;

    $scope.emailEditing = false;
});
