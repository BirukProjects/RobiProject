var app = angular.module("ApplicationModule", ["ngRoute"]);
 
//The Factory used to define the value to
//Communicate and pass data across controllers
 
app.factory("ShareData", function () {
return { value: 0 }
});

//Defining Routing
app.config(['$routeProvider','$locationProvider', function ($routeProvider,$locationProvider) {
    $routeProvider.when('/SuperAdmin/catTreeView',
{
    templateUrl: '/SuperAdmin/ShowUsers',
    controller: 'ShowUsersController'
});
    $routeProvider.when('/SuperAdmin/addUser',
{
    templateUrl: 'SuperAdmin/AddNewUser',
    controller: 'AddUserController'
});
    $routeProvider.when("/SuperAdmin/editUser",
{
    templateUrl: 'SuperAdmin/EditUser',
    controller: 'EditUserController'
});
    $routeProvider.when('/SuperAdmin/deleteUser',
{
    templateUrl: 'SuperAdmin/DeleteUser',
    controller: 'DeleteUserController'
});
$routeProvider.otherwise(
{
    redirectTo: '/'
});
// $locationProvider.html5Mode(true);
$locationProvider.html5Mode(true).hashPrefix('!')
}]);
app.service("SinglePageCRUDService", function ($http) {

    //Function to Read All Users
    this.getUsers = function () {
        return $http.get("/api/UserInfoAPI");
    };

    //Fundction to Read User based upon id
    this.getUser = function (id) {
        return $http.get("/api/UserInfoAPI/" + id);
    };

    //Function to create new User
    this.post = function (User) {
        var request = $http({
            method: "post",
            url: "/api/UserInfoAPI",
            data: User
        });
        return request;
    };

    //Function  to Edit User based upon id 
    this.put = function (id, User) {
        var request = $http({
            method: "put",
            url: "/api/UserInfoAPI/" + id,
            data: User
        });
        return request;
    };

    //Function to Delete User based upon id
    this.delete = function (id) {
        var request = $http({
            method: "delete",
            url: "/api/UserInfoAPI/" + id
        });
        return request;
    };
});