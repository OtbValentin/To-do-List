angular.module('app').factory('', function ($rootScope) {
    var service = {
        todoLists: [
            {
                Id: 1,
                Title: "List1 modified",
                TodoItems: [
                  {
                      Id: 1,
                      List: 0,
                      Text: "Item1 modified",
                      Note: "kek drek",
                      IsCompleted: true,
                      DueDate: null
                  },
                  {
                      Id: 5,
                      List: 0,
                      Text: "Item5",
                      Note: "",
                      IsCompleted: false,
                      DueDate: null
                  },
                  {
                      Id: 8,
                      List: 0,
                      Text: "Item8",
                      Note: "",
                      IsCompleted: false,
                      DueDate: null
                  }
                ]
            },
            {
                Id: 2,
                Title: "List2 modified",
                TodoItems: [
                  {
                      Id: 10,
                      List: 0,
                      Text: "Item10",
                      Note: "kek drek",
                      IsCompleted: false,
                      DueDate: null
                  },
                  {
                      Id: 11,
                      List: 0,
                      Text: "Item11",
                      Note: "",
                      IsCompleted: false,
                      DueDate: null
                  }
                ]
            }
        ],
        activeList: null,
        selectedTask: null,
        showCompleted: false,

        //Dialogs
        showAddListDialog: function () {
            $rootScope.$broadcast('showAddListDialog');
        },
        showEditListDialog: function (list) {
            console.log('broadcasted edit');
            $rootScope.$broadcast('showEditListDialog', list);
        },
        showUserSettingsDialog: function (user) {
            console.log('broadcast user dialog');
            $rootScope.$broadcast('showUserSettingsDialog', user);
        },



        //Task actions
        addTask: function (list, title) {
            //trash
            var id = 312;
            if (list.TodoItems.length != 0) {
                id = list.TodoItems[0].Id + 10;
            }

            list.TodoItems.unshift({ Id: id, List: list.Id, Text: title, Note: "", IsCompleted: false });
            $rootScope.$broadcast('taskAdded');
        },
        deleteTask: function (list, task) {
            list.TodoItems.splice(list.TodoItems.indexOf(task), 1);
            $rootScope.$broadcast('taskDeleted');
        },
        selectTask: function (task) {
            console.log('select task in service', task);
            service.selectedTask = task;
            $rootScope.$broadcast('taskSelected');
        },




        //List actions
        addList: function (title) {
            var id = 6712;
            if (service.todoLists.length != 0) {
                id = service.todoLists[service.todoLists.length - 1].Id + 10;
            }

            var list = { Id: id, Title: title, TodoItems: [] };

            service.todoLists.push(list);
            $rootScope.$broadcast('listAdded');
        },
        deleteList: function (list) {
            service.todoLists.splice(service.todoLists.indexOf(list), 1);
            $rootScope.$broadcast('listDeleted');
            service.setActiveList(null);
        },
        setActiveList: function (list) {
            console.log('set active list service', list);
            service.activeList = list;
            $rootScope.$broadcast('activeListUpdated');

            if (service.activeList == null) {
                document.location = '#/lists';
            }
        }
    };

    return service;
});