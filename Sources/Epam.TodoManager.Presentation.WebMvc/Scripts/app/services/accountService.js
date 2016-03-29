(function () {
    'use strict';

    angular
        .module('app')
        .factory('accountService', accountService);

    accountService.$inject = ['$resource'];

    function accountService($resource) {
        var service = {
            Account: $resource('http://localhost:51733/api/Account')
        };

        return service;
    }
})();