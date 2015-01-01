
var app = angular.module('app', []);
var url = '/api/User/';
app.factory('userFactory', function ($http) {
    return {
        getUser: function () {
            return $http.get(url);
        },
        addUser: function (user) {
            return $http.post(url, user);
        },
        deleteUser: function (user) {
            return $http.delete(url + user.id);
        },
        updateUser: function (user) {
            return $http.put(url + user.id, user);
        }
    };
});

app.controller('UserController', ['$scope', 'userFactory', function ($scope, userFactory) {
    $scope.users = [];
    $scope.loading = true;
    $scope.addMode = false;

    $scope.toggleEdit = function () {
        this.user.editMode = !this.user.editMode;
    };
    $scope.toggleAdd = function () {
        $scope.addMode = !$scope.addMode;
    };


    // Save user Event
    $scope.save = function () {
        $scope.loading = true;
        var us = this.user;
        userFactory.updateUser(us).success(function (data) {
            alert("Saved Successfully!!");
            us.editMode = false;
            $scope.loading = false;
        }).error(function (data) {
            $scope.error = "An Error has occurred while Saving user! " + data.ExceptionMessage;
            $scope.loading = false;

        });
    };

    // add User Event
    $scope.add = function () {
        $scope.loading = true;
        userFactory.addUser(this.newUser).success(function (data) {
            alert("Added Successfully!!");
            $scope.addMode = false;
            $scope.users.push(data);
            $scope.loading = false;
        }).error(function (data) {
            $scope.error = "An Error has occurred while Adding user! " + data.ExceptionMessage;
            $scope.loading = false;

        });
    };
    // delete User Event
    $scope.deluser = function () {
        $scope.loading = true;
        var currentUser = this.user;
        userFactory.deleteUser(currentUser).success(function (data) {
            alert("Deleted Successfully!!");
            $.each($scope.users, function (i) {
                if ($scope.users[i].id === currentUser.id) {
                    $scope.users.splice(i, 1);
                    return false;
                }
            });
            $scope.loading = false;
        }).error(function (data) {
            $scope.error = "An Error has occurred while Saving user! " + data.ExceptionMessage;
            $scope.loading = false;

        });
    };

    //get all user- Self Calling -On load
    userFactory.getUser().success(function (data) {
        $scope.users = data;
       
        $scope.loading = false;
    })
    .error(function (data) {
        $scope.error = "An Error has occurred while loading Users! " + data.ExceptionMessage;
        $scope.loading = false;
    });

}]);