angular.module('app').factory('listsService', function ($rootScope) {
    var service = {
        todoLists: [
                { title: 'first list', todos: [{ title: '11', isCompleted: false, note: null}, { title: '12', isCompleted: false, note: null}, { title: '13', isCompleted: true, note: null}]},
                { title: 'second list', todos: [{ title: '21', isCompleted: true, note: null}, { title: '22', isCompleted: false, note: null}, { title: '33', isCompleted: true, note: null}, {title: '34', isCompleted: true, note: null}]},
                { title: '3d list ', todos: [{ title: '31', isCompleted: false, note: null}, { title: '32', isCompleted: false, note: null}, { title: '33', isCompleted: true, note: null}] },
        ],
        activeList: null,
        selectedTask: null,

        selectTask: function(task){
            service.selectedTask = task;

            $rootScope.$broadcast('task selected');
        },
        addList: function (title) {
            var list = { title: title, todos: [] };
            service.todoLists.push(list);

            $rootScope.$broadcast('list added');
        },
        addTask: function (list, title) {
            list.todos.unshift({ title: title, isCompleted: false });

            $rootScope.$broadcast('task added');
        },
        setActiveList: function (list) {
            service.activeList = list;

            $rootScope.$broadcast('active list updated');
            
        }
    };

    return service;
});