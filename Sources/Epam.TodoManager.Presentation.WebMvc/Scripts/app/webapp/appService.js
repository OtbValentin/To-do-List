angular.module('app').service('appService', function ($rootScope) {
    var service = {
        showTaskDetails: function () {
            $rootScope.$broadcast('showTaskDetails');
        }
    };

    return service;
});