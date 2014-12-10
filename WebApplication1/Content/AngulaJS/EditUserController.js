app.controller("EditUserController", function ($scope, $location,ShareData,SinglePageCRUDService) {
 
    getUser();
    function getUser() {
 
        var promiseGetUser = SinglePageCRUDService.getUser(ShareData.value);
 
 
        promiseGetUser.then(function (pl)
        {
            $scope.User = pl.data;
        },
              function (errorPl) {
                  $scope.error = 'failure loading User', errorPl;
              });
    }
    $scope.save = function () {
        var User = {
            Email: $scope.User.Email,
            UserName: $scope.User.UserName,
            PasswordHash: $scope.User.PasswordHash,
            //DeptName: $scope.User.DeptName,
            //Designation: $scope.User.Designation
        };

        var promisePutUser = SinglePageCRUDService.put($scope.User.EmpNo, User);
        promisePutUser.then(function (pl) {
            $location.path("/_showUser");
        },
              function (errorPl) {
                  $scope.error = 'failure loading User', errorPl;
              });
    };
});