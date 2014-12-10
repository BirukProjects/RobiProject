app.controller('AddUserController', function ($scope, SinglePageCRUDService) {
    $scope.UserId = 0;
    //The Save scope method used to define the User object and 
    //post the User information to the server by making call to the Service
    $scope.save = function () {
        var User = {
            Email: $scope.Email,
            UserName: $scope.UserName,
            PasswordHash: $scope.PasswordHash,
            //DeptName: $scope.DeptName,
            //Designation: $scope.Designation
        };

        var promisePost = SinglePageCRUDService.post(User);


        promisePost.then(function (pl) {
            $scope.Email = pl.data.Email;
            alert("Email " + pl.data.Email);
        },
              function (errorPl) {
                  $scope.error = 'failure loading User', errorPl;
              });

    };
});