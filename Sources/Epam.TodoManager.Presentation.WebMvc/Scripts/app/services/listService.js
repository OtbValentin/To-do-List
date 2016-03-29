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
            return $http.post(service.resourceUrl, title);
        }

        function getAll() {
            return $http.get(service.resourceUrl);
        }

        function get(id) {
            return $http.get(service.resourceUrl + "/" + id);
        }

        function rename(id, newTitle) {
            return $http.put(service.resourceUrl + "/" + id, newTitle);
        }

        function remove(id) {
            return $http.delete(service.resourceUrl + "/" + id);
        }
    }
})();