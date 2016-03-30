(function () {
    'use strict';

    angular
        .module('todoListApp')
        .controller('AppController', AppController);

    AppController.$inject = ['$location']; 

    function AppController($location) {
        var vm = this;
        vm.title = 'AppController';

        activate();

        function activate() { }
    }
})();
