angular.module('app').controller('accountController', function ($scope, dataService) {
    $scope.$on('closeDialogs', function () { $scope.closeUserSettingsDialog(); });

    $scope.$on('showUserSettingsDialog', function (event) {
        $scope.userToEdit = dataService.data.user;
        console.log($scope.userToEdit);
        $scope.newName = $scope.userToEdit.Name;
        $scope.newEmail = $scope.userToEdit.Email;
        $scope.showUserSettingsDialog = true;
    });

    $scope.closeUserSettingsDialog = function () {
        console.log('close user settings dialog');
        $scope.showUserSettingsDialog = false;
        $scope.userToEdit = null;
        $scope.newName = '';
    }

    $scope.renameUser = function () {
        dataService.renameUser($scope.userToEdit, $scope.newName);
    }

    $scope.saveChanges = function () {
        if ($scope.userToEdit.Name != $scope.newName) {
            $scope.renameUser();
        }

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
        // return error message if error occured, otherwise return null
        dataService.changeEmail($scope.userToEdit, $scope.newEmail);
        console.log('save email');
        $scope.emailError = !$scope.emailError;
    }

    $scope.savePassword = function () {
        if ($scope.newPassword != $scope.repeatedPassword) {
            $scope.passwordErrorText = 'New password does not match to the confirmed password.';
            $scope.passwordError = true;
        }
        else
        {
            dataService.changePassword($scope.currentPassword, $scope.newPassword);
        }

        console.log('save password');
        $scope.passwordError = !$scope.passwordError;
    }

    $scope.showUserSettingsDialog = false;
    $scope.userToEdit = null;

    $scope.newName = '';

    $scope.emailEditing = false;
    $scope.emailError = false;
    $scope.emailErrorText = 'Email error';
    $scope.emailConfirmPassword = '';
    $scope.newEmail = '';

    $scope.passwordEditing = false;
    $scope.passwordError = false; 
    $scope.passwordErrorText = 'Password error';
    $scope.newPassword = '';
    $scope.repeatedPassword = '';
    $scope.currentPassword = '';



});
