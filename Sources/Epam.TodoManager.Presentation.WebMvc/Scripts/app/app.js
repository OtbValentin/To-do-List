(function () {
    'use strict';

    angular.module('todoListApp', [
        // Angular modules 
        'ngRoute',
        'ngResource',
        'ngCookies',

        // Custom modules 

        // 3rd Party Modules
        'angular-oauth2',
        'angled-dragndrop'
    ])
    .config([ 'OAuthProvider', function (OAuthProvider) {
        OAuthProvider.configure({
            baseUrl: "http://localhost:51733/api",
            grantPath: "/Account/Token",
            clientId: "WebApp"
        });
    }])
    .config(['OAuthTokenProvider', function (OAuthTokenProvider) {
        OAuthTokenProvider.configure({
            name: 'token',
            options: {
                secure: false
            }
        });
    }]);
})();