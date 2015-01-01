//var app = angular.module('app', []);

app.controller('UserController', function ($scope) {


    $scope.bag = [{
        label: 'Glasses',
        value: 'glasses',
        children: [{
            label: 'Top Hat',
            value: 'top_hat'
        }, {
            label: 'Curly Mustache',
            value: 'mustachio'
        }]
    }];
    
});