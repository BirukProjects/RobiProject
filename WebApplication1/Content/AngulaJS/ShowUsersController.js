//The controller has dependency upon the Service and ShareData
app.controller('ShowUserController', function ($scope, $location, SinglePageCRUDService, ShareData) {
 
    loadRecords();
    //Function to Load all User Records.   
    function loadRecords() {
        var promiseGetUser = SinglePageCRUDService.getUser();

        promiseGetUser.then(function (pl) { $scope.User = pl.data },
              function (errorPl) {
                  $scope.error = 'failure loading User', errorPl;
              });
    }


    //Method to route to the addUser
    $scope.addUser = function () {
        $location.path("/addUser");
    }

    //Method to route to the editUser
    //The EmpNo passed to this method is further set to the ShareData.
    //This value can then be used to communicate across the Controllers
    $scope.editUser = function (EmpNo) {
        ShareData.value = EmpNo;
        $location.path("/editUser");
    }

    //Method to route to the deleteUser
    //The EmpNo passed to this method is further set to the ShareData.
    //This value can then be used to communicate across the Controllers
    $scope.deleteUser = function (EmpNo) {
        ShareData.value = EmpNo;
        $location.path("/deleteUser");
    }
});