(function () {
    'use strict';

    angular
        .module('todoListApp')
        .controller('RegisterController', RegisterController);

    RegisterController.$inject = ['$location', '$window', '$resource'];

    function RegisterController($location, $window, $resource) {
        var vm = this;
        vm.title = 'RegisterController';

        var Account = $resource('http://localhost:51733/api/Account');
        vm.newAccount = new Account();

        vm.displayErrorMessage = false;
        vm.errorMessage = "";

        vm.register = function () {
            vm.newAccount.$save()
                .then(function () {
                    $window.location.href = "/WebApp";
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
