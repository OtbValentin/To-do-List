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
                listsService.addTask(listsService.activeList, scope.newTaskTitle);
            });
        }
    }
}).directive('focusItem', function ($timeout) {
    return {
        restrict: 'A',
        link: function (scope, element, attrs) {
            $('#focusable').bind('blur', function () {
                scope.stopNoteEditing();
                scope.$apply();
            });
            scope.$watch('noteEditing', function () {
                if (scope.noteEditing == true) {
                    $timeout(function () {
                        $('#focusable').focus();
                    }, 0);
                }
            })
        }
    }
}).directive('selectTask', function (listsService) {
    return {
        restrict: 'A',
        link: function (scope, element, attrs) {
            element.bind('click', function () {
                listsService.selectTask(scope.task);
                scope.$apply();
            });
        }
    }
})
