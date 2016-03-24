angular.module('app').service('appService', function ($rootScope) {
    var service = {
        showTaskDetails: function () {
            console.log('show details in app service');
            $rootScope.$broadcast('showTaskDetails');
        }
    };

    return service;
});