angular.module('app').controller('accountController', function ($scope, dataService) {
    $scope.$on('closeDialogs', function () { $scope.closeUserSettingsDialog(); });

    $scope.$on('showUserSettingsDialog', function (event) {
        $scope.newName = $scope.data.user.Name;
        $scope.newEmail = $scope.data.user.Email;
        $scope.showUserSettingsDialog = true;
    });

    $scope.closeUserSettingsDialog = function () {
        $scope.showUserSettingsDialog = false;
    }

    $scope.renameUser = function () {
        //$scope.data.user.Name = $scope.newName;
        dataService.renameUser($scope.data.user, $scope.newName);
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
        $scope.emailConfirmPassword = '';
        $scope.newEmail = $scope.data.user.Email;
    }

    $scope.beginPasswordEditing = function () {
        $scope.passwordEditing = true;
    }

    $scope.stopPasswordEditing = function () {
        $scope.passwordEditing = false;
        $scope.currentPassword = '';
        $scope.newPassword = '';
        $scope.repeatedPassword = '';
    }

    $scope.saveEmail = function () {
        // return error message if error occured, otherwise return null
        if ($scope.data.user.Email != $scope.newEmail) {
            $scope.data.user.Email = $scope.newEmail;

            dataService.changeEmail($scope.data.user, $scope.data.newEmail, $scope.emailConfirmPassword);
        }
    }

    $scope.savePassword = function () {
        if ($scope.newPassword != $scope.repeatedPassword) {
            $scope.passwordErrorText = 'New password does not match to the confirmed password.';
            $scope.passwordError = true;
        }
        else
        {
            dataService.changePassword($scope.data.user, $scope.currentPassword, $scope.newPassword);
        }
    }

    $scope.data = dataService.data;

    $scope.showUserSettingsDialog = false;

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
