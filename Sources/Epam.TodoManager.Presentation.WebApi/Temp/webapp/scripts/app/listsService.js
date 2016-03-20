angular.module('app').factory('listsService', function ($rootScope) {
    var service = {
        todoLists: [
                { title: 'first list', todos: [{ title: '11', isCompleted: false }, { title: '12', isCompleted: false }, { title: '13', isCompleted: true }]},
                { title: 'second list', todos: [{ title: '21', isCompleted: true }, { title: '22', isCompleted: false }, { title: '33', isCompleted: true }, {title: '34', isCompleted: true}]},
                { title: '3d list ', todos: [{ title: '31', isCompleted: false }, { title: '32', isCompleted: false }, { title: '33', isCompleted: true }] },
        ],
        activeListIndex: 0,
        //todoLists: ['123', '12f', 'qwe', '1po22'],
        addList: function (title) {
            service.todoLists.push({ title: title, todos: [] });
            $rootScope.$broadcast('lists update');
        },
        //tasks: ['Do 1', 'Do 2', 'Do 3', '4 Do'],
        addTask: function (listIndex, title) {
            service.todoLists[service.activeListIndex].todos.unshift({ title: title, isCompleted: false });
            $rootScope.$broadcast('tasks update');
        },
        setActive: function (index) {
            service.activeListIndex = index;
            $rootScope.$broadcast('index update');
        }
    };

    return service;
});