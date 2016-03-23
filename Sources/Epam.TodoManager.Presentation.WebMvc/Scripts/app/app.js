(function () {
    'use strict';

    angular.module('todoListApp', [
        // Angular modules 
        'ngRoute',
        'ngResource',

        // Custom modules 

        // 3rd Party Modules
        'angular-oauth2'
    ])
    .config([ 'OAuthProvider', function (OAuthProvider) {
        OAuthProvider.configure({
            baseUrl: "http://localhost:51733/api",
            grantPath: "/Account/Token",
            clientId: "WebApp"
        });
    }]);
})();