app.service("SinglePageCRUDService", function ($http) {

    //Function to Read All users
    this.getusers = function () {
        return $http.get("/api/userInfoAPI");
    };

    //Fundction to Read user based upon id
    this.getuser = function (id) {
        return $http.get("/api/userInfoAPI/" + id);
    };

    //Function to create new user
    this.post = function (user) {
        var request = $http({
            method: "post",
            url: "/api/userInfoAPI",
            data: user
        });
        return request;
    };
    //Function  to Edit user based upon id 
    this.put = function (id, user) {
        var request = $http({
            method: "put",
            url: "/api/userInfoAPI/" + id,
            data: user
        });
        return request;
    };

    //Function to Delete user based upon id
    this.delete = function (id) {
        var request = $http({
            method: "delete",
            url: "/api/userInfoAPI/" + id
        });
        return request;
    };
});