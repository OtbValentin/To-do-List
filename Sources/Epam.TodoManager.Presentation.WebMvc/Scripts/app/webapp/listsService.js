angular.module('app').factory('listsService', function ($rootScope) {
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
            }
        ],
        activeList: null,
        selectedTask: null,
        showCompleted: false,
        selectTask: function (task) {
            console.log('select task in service', task);
            service.selectedTask = task;
            $rootScope.$broadcast('taskSelected');
        },
        addList: function (title) {
            var list = { Id: 0, Title: title, TodoItems: [] };

            service.todoLists.push(list);
            $rootScope.$broadcast('listAdded');
        },
        addTask: function (list, title) {
            list.TodoItems.unshift({ Id: 0, List: list.Id, Text: title, Note: "", IsCompleted: false });
            $rootScope.$broadcast('taskAdded');
        },
        deleteTask: function(list, task){
            list.TodoItems.splice(list.TodoItems.indexOf(task), 1);
            $rootScope.$broadcast('taskDeleted');
        },
        setActiveList: function (list) {
            console.log('set active list service', list);
            service.activeList = list;
            $rootScope.$broadcast('activeListUpdated');
        }
    };

    return service;
});