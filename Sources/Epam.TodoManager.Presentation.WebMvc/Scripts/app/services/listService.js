(function () {
    'use strict';

    angular
        .module('app')
        .factory('listService', listService);

    listService.$inject = ['$http'];

    function listService($http) {
        var service = {
            create: create,
            getAll: getAll,
            get: get,
            rename: rename,
            remove: remove,

            resourceUrl: "http://localhost:51733/api/TodoLists"
        };

        return service;

        ///////////////////////////

        function create(title) {
            console.log('In list service, title:', title);
            return $http.post(service.resourceUrl, wrapInQuotes(stringData));
        }

        function getAll() {
            return $http.get(service.resourceUrl);
        }

        function get(id) {
            return $http.get(service.resourceUrl + "/" + id);
        }

        function rename(id, newTitle) {
            return $http.put(service.resourceUrl + "/" + id, wrapInQuotes(newTitle));
        }

        function remove(id) {
            return $http.delete(service.resourceUrl + "/" + id);
        }



        function wrapInQuotes(stringData) {
            return '\"' + stringData + '\"';
        }
    }
})();
