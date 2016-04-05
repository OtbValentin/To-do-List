(function () {
    'use strict';

    angular
        .module('app')
        .factory('imageService', imageService);

    imageService.$inject = ['$http'];

    function imageService($http) {
        var service = {
            uploadAvatar: uploadAvatar,

            resourceUrl: "http://localhost:51733/api/Account"
        };

        return service;

        ///////////////////////////

        function uploadAvatar(data) {
            console.log('image service', data);
            return $http.post(service.resourceUrl + '/Avatar', data, {
                transformRequest: angular.identity,
                headers: { 'Content-Type': undefined }
            });
        }

    }
})();
