(function () {
    'use strict';

    angular
        .module('app')
        .controller('RegisterController', RegisterController);

    RegisterController.$inject = ['$location', '$window', 'accountService'];

    function RegisterController($location, $window, accountService) {
        var vm = this;
        vm.title = 'RegisterController';

        vm.newAccount = new accountService.Account();

        vm.displayErrorMessage = false;
        vm.errorMessage = "";

        vm.register = function () {
            vm.newAccount.$save()
                .then(function () {
                    $window.location.href = "/Account/Login";
                })
                .catch(function (response) {
                    var responseData = response.data;
                    if (responseData.ModelState) {
                        for (key in responseData.ModelState) {
                            if (responseData.ModelState.hasOwnProperty(key))
                                vm.errorMessage += responseData.ModelState[key];
                        }
                    }
                    else if (responseData.Message) {
                        vm.errorMessage = responseData.Message;
                    }

                    vm.displayErrorMessage = true;
                })
        };
    }
})();
