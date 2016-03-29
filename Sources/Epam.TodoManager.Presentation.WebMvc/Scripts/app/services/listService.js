(function () {
    'use strict';

    angular
        .module('app')
        .factory('listService', listService);

    listService.$inject = ['$http'];

    function listService($http) {
        var service = {
            data: {
                lists: null,
                activeList: null,
                selectedTask: null,
                showCompleted: false
            },

            create: create,
            getAll: getAll,
            get: get,
            rename: rename,
            remove: remove,

            resourceUrl: "http://localhost:51733/api/TodoLists"
        };

        updateAll();

        return service;

        ///////////////////////////

        function addTask(list, task) {
            if (list.TodoItems) {
                list.TodoItems.push(task);
            }
            else {
                list.TodoItems = [task];
            }
        }

        function removeTask(list, task) {
            var taskIndex = list.TodoItems.indexOf(task);
            if (taskIndex >= 0) {
                list.TodoItems.splice(taskIndex, 1);
            }
            else {
                throw (list + ' does not contain ' + task + '.');
            }
        }

        function selectTask(task) {
            var taskIndex = service.data.activeList.TodoItems.indexOf(task);
            if (taskIndex >= 0) {
                service.data.selectedTask = task;
            }
            else {
                throw (task + ' is not an item of the active list.');
            }
        }




        function createList(title) {
            create(title).then(function () {
                updateAll();
            });
        }

        function deleteList(list) {
            remove(list.Id).then(function () {
                //updateAll();

                if (service.data.activeList === list) {
                    //redirect?
                    service.data.activeList = null;
                    service.data.selectedTask = null;
                }

                var listIndex = service.data.lists.indexOf(list);
                if (listIndex >= 0) {
                    service.data.lists.splice(listIndex, 1);
                }
            });
        }

        function selectList(list) {
            service.data.activeList = list;
            service.data.selectedTask = null;
        }



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