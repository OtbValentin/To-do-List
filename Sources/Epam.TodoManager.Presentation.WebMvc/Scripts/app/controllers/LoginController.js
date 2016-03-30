(function () {
    'use strict';

    angular
        .module('app')
        .controller('LoginController', LoginController);

    LoginController.$inject = ['$location', '$window', 'OAuth']; 

    function LoginController($location, $window, OAuth) {
        var vm = this;
        vm.title = 'LoginController';

        vm.email = "";
        vm.password = "";

        vm.displayErrorMessage = false;
        vm.errorMessage = "";

        vm.login = function () {
            vm.displayErrorMessage = false;

            OAuth.getAccessToken({
                username: vm.email,
                password: vm.password
            })
            .then(function () {
                $window.location.href = "/Webapp/Index";
            })
            .catch(function (response) {
                vm.errorMessage = response.data.error_description;
                vm.displayErrorMessage = true;
            });
        };
    }
})();
