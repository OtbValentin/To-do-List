angular.module('app').directive('addNewList', function (listsService) {
    return {
        restrict: 'A',
        link: function (scope, element, attrs) {
            element.bind("click", function () {
                listsService.addList('newList');
            });
        }
    }
}).directive('addNewTask', function (listsService) {
    return {
        restrict: 'A',
        link: function (scope, element, attrs) {
            element.bind("click", function () {
                listsService.addTask(listsService.activeListIndex, scope.newTaskTitle);
            });
            element.on("keydown keypress", function (event) {
                console.log(event);
                if (event.which > 0) {
                    console.log('pressed enter');
                    listsService.addTask(scope.newTaskTitle);
                }
            });
        }
    }
});
