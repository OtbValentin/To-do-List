﻿(function () {
    'use strict';

    angular
        .module('todoListApp')
        .factory('dataService', dataService);

    dataService.$inject = ['$http', 'listService', 'taskService'];

    function dataService($http, listService, taskService) {
        var service = {
            data: {
                lists: null,
                activeList: null,
                selectedTask: null,
                showCompleted: false
            },

            //list actions
            createList: createList,
            deleteList: deleteList,
            renameList: renameList,
            selectList: selectList,

            //task actions
            createTask: createTask,
            deleteTask: deleteTask,
            moveTask: moveTask,
            saveTask: saveTask,
            selectTask: selectTask,
            shiftTask: shiftTask,

            updateAll: updateAll,
            updateList: updateList
        };

        updateAll();

        return service;

        //////////////////////////

        function createList(title) {
            listService.create(title).then(function () {
                updateAll();
            });
        }

        function deleteList(list) {
            listService.remove(list.Id).then(function () {
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

        function renameList(list, title) {
            listService.rename(list.Id, title).then(function (response) {
                list.Title = title;
            });
        }

        function selectList(list) {
            service.data.activeList = list;
            service.data.selectedTask = null;
        }



        function createTask(list, text) {
            taskService.create(list.Id, text).then(function (response) {
                updateList(list);
            });
        }

        function deleteTask(list, task) {
            taskService.remove(task.Id, list.Id).then(function (response) {
                updateList(list);
            });
        }

        function moveTask(task, list, newList) {
            taskService.move(task.Id, list.Id, newList.Id).then(function (response) {
                updateList(list);
                updateList(newList);
            });
        }

        function saveTask(list, task) {
            taskService.update(task.Id, list.Id);
        }

        function selectTask(task) {
            service.data.selectedTask = task;
        }

        function shiftTask(list, task, newIndex) {
            taskService.shift(task.Id, list.Id, newIndex);
        }


        function updateAll() {
            var data = service.data;

            listService.getAll().then(function (response) {
                data.lists = response.data;

                if (data.activeList) {
                    var newActiveList = data.lists.find(function (list) {
                        return list.Id == data.activeList.Id;
                    });
                    data.activeList = !!newActiveList ? newActiveList : null;
                }

                if (data.selectedTask) {
                    if (!data.activeList)
                        data.selectedTask = null;

                    var newSelectedTask = data.activeList.find(function (task) {
                        return task.Id == data.selectedTask;
                    });
                    data.selectedTask = !!newSelectedTask ? newSelectedTask : null;
                }
            });
        }

        function updateList(list) {
            var data = service.data;

            listService.get(list.Id).then(function (response) {
                var newList = response.data;

                var oldListIndex = data.lists.indexOf(list);
                if (oldListIndex >= 0) {
                    data.lists.splice(oldListIndex, 1, newList);
                }

                if (data.activeList == list) {
                    data.activeList = newList;
                }

                if (data.selectedTask) {
                    var newSelectedTask = data.activeList.find(function (task) {
                        return task.Id == data.selectedTask;
                    });
                    data.selectedTask = !!newSelectedTask ? newSelectedTask : null;
                }
            });
        }
    }
})();
