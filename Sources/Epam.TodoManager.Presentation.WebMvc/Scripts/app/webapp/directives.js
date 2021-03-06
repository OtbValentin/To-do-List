angular.module('app').directive('focusNoteItem', function ($timeout) {
    return {
        restrict: 'A',
        link: function (scope, element, attrs) {
            $(element).bind('blur', function () {
                scope.stopNoteEditing();
                scope.$apply();
            });
            scope.$watch('noteEditing', function () {
                if (scope.noteEditing == true) {
                    $timeout(function () {
                        //$('#focusable').focus();
                        $(element).focus();
                    }, 0);
                }
            })
        }
    }
}).directive('focusDateItem', function ($timeout) {
    return {
        restrict: 'A',
        link: function (scope, element, attrs) {
            $(element).bind('blur', function () {
                scope.stopDateEditing();
                scope.$apply();
            });
            scope.$watch('dateEditing', function () {
                if (scope.dateEditing == true) {
                    $timeout(function () {
                        //$('#focusable').focus();
                        $(element).focus();
                    }, 0);
                }
            })
        }
    }
}).directive('focusTitleItem', function ($timeout) {
    return {
        restrict: 'A',
        link: function (scope, element, attrs) {
            $(element).bind('blur', function () {
                scope.stopTitleEditing();
                scope.$apply();
            });
            scope.$watch('titleEditing', function () {
                if (scope.titleEditing == true) {
                    $timeout(function () {
                        //$('#focusable').focus();
                        $(element).focus();
                    }, 0);
                }
            })
        }
    }
});