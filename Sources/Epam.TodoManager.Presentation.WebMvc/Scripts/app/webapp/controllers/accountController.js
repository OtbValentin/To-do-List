angular.module('app').controller('accountController', function ($scope, accountService) {
    $scope.$on('closeDialogs', function () { $scope.closeUserSettingsDialog(); });

    $scope.$on('showUserSettingsDialog', function (event, args) {
        $scope.userToEdit = args;
        $scope.showUserSettingsDialog = true;
    });

    $scope.closeUserSettingsDialog = function () {
        console.log('close user settings dialog');
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

    $scope.beginPasswordEditing = function () {
        $scope.passwordEditing = true;
    }

    $scope.stopPasswordEditing = function () {
        $scope.passwordEditing = false;
    }

    $scope.saveEmail = function () {
        console.log('save email');
        $scope.emailError = !$scope.emailError;
    }

    $scope.savePassword = function () {
        console.log('save password');
        $scope.passwordError = !$scope.passwordError;
    }

    $scope.showUserSettingsDialog = false;
    $scope.newName = '';
    $scope.userToEdit = null;

    $scope.emailEditing = false;
    $scope.passwordEditing = false;

    $scope.emailErrorText = 'Email error';
    $scope.passwordErrorText = 'Password error';

    $scope.emailError = false;
    $scope.passwordError = false;
});
