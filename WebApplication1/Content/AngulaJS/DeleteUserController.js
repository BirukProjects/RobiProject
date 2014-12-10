app.controller("DeleteUserController", function ($scope, $location, ShareData, SinglePageCRUDService) {

    getUser();
    function getUser() {

        var promiseGetUser = SinglePageCRUDService.getUser(ShareData.value);

        promiseGetUser.then(function (pl) {
            $scope.User = pl.data;
        },
              function (errorPl) {
                  $scope.error = 'failure loading User', errorPl;
              });
    }

    //The delete method used to make HTTP DELETE call to the WEB API to update the record
    $scope.delete = function () {
        var promiseDeleteUser = SinglePageCRUDService.delete(ShareData.value);

        promiseDeleteUser.then(function (pl) {
            $location.path("/_showUser");
        },
              function (errorPl) {
                  $scope.error = 'failure loading User', errorPl;
              });
    };

});