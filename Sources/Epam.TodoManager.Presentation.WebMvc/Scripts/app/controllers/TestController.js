(function () {
    'use strict';

    angular
        .module('todoListApp')
        .controller('TestController', TestController);

    TestController.$inject = ['$location', 'OAuth', 'listService'];

    function TestController($location, OAuth, listService) {
        var vm = this;
        vm.title = 'TestController';

        activate();

        function activate() {
            vm.isAuthenticated = OAuth.isAuthenticated();
            listService.getAll().then(function (response) {
                vm.lists = response.data;
            });
        };
    }
})();
