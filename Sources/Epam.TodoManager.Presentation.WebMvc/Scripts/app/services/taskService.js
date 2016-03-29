(function () {
    'use strict';

    angular
        .module('todoListApp')
        .factory('taskService', taskService);

    taskService.$inject = ['$http', 'listService'];

    function taskService($http, listService) {
        var service = {
            create: create,
            get: get,
            getAll: getAll,
            update: update,
            remove: remove,
            move: move,
            shift: shift,

            resourceUrl: "http://localhost:51733/api/TodoItems",
            listResourceUrl: listService.resourceUrl
        };
        return service;

        function create(listId, taskText) {
            return $http.post(service.resourceUrl, {
                list: listId,
                text: taskText
            });
        }

        function get(listId, taskId) {
            return $http.get(service.resourceUrl + "/" + taskId, {
                params: {
                    listId: listId
                }
            });
        }

        function getAll(listId) {
            return $http.get(service.resourceUrl, {
                params: {
                    listId: listId
                }
            });
        }

        function update(task, listId) {
            return $http.put(service.resourceUrl + "/" + task.Id, task);
        }

        function remove(taskId, listId) {
            return $http.delete(service.resourceUrl + "/" + taskId, {
                params: {
                    listId: listId
                }
            });
        }

        function move(taskId, fromListId, toListId) {
            return $http.post(service.resourceUrl + "/" + taskId + "/Move", null, {
                params: {
                    fromList: fromListId,
                    toList: toListId
                }
            });
        }

        function shift(taskId, listId, index) {
            return $http.post(service.listResourceUrl + "/" + listId + "/Shift", null, {
                params: {
                    itemId: taskId,
                    index: index
                }
            });
        }
    }
})();