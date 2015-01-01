
var app = angular.module('app', []);
var urlCatArea = '/api/CategoryArea/';
var urlCat = '/api/Category/';

app.factory('categoryAreaFactory', function ($http) {
    return {
        getCategoryArea: function () {
            return $http.get(urlCatArea);
        },
        getCategory: function () {
            return $http.get(urlCat);
        },
        addCategoryArea: function (categoryArea) {
            return $http.post(urlCatArea, categoryArea);
        },
        deleteCategoryArea: function (categoryArea) {
            return $http.delete(urlCatArea + categoryArea.id);
        },
        updateCategoryArea: function (categoryArea) {
            return $http.put(urlCatArea + categoryArea.id, categoryArea);
        }
    };
});

app.controller('CategoryAreaController', ['$scope', 'categoryAreaFactory', function ($scope, categoryAreaFactory) {
    $scope.categoryAreas = [];
    $scope.loading = true;
    $scope.addMode = false;

    $scope.toggleEdit = function () {
        this.categoryArea.editMode = !this.categoryArea.editMode;
    };
    $scope.toggleAdd = function () {
        $scope.addMode = !$scope.addMode;
    };


    // Save categoryArea Event
    $scope.save = function () {
        $scope.loading = true;
        var us = this.categoryArea;
        categoryAreaFactory.updateCategoryArea(us).success(function (data) {
            alert("Saved Successfully!!");
            us.editMode = false;
            $scope.loading = false;
        }).error(function (data) {
            $scope.error = "An Error has occurred while Saving categoryArea! " + data.ExceptionMessage;
            $scope.loading = false;

        });
    };

    // add CategoryArea Event
    $scope.add = function () {
        $scope.loading = true;
        categoryAreaFactory.addCategoryArea(this.newCategoryArea).success(function (data) {
            alert("Added Successfully!!");
            $scope.addMode = false;
            $scope.categoryAreas.push(data);
            $scope.loading = false;
        }).error(function (data) {
            $scope.error = "An Error has occurred while Adding categoryArea! " + data.ExceptionMessage;
            $scope.loading = false;

        });
    };
    // delete CategoryArea Event
    $scope.delcategoryArea = function () {
        $scope.loading = true;
        var currentCategoryArea = this.categoryArea;
        categoryAreaFactory.deleteCategoryArea(currentCategoryArea).success(function (data) {
            alert("Deleted Successfully!!");
            $.each($scope.categoryAreas, function (i) {
                if ($scope.categoryAreas[i].id === currentCategoryArea.id) {
                    $scope.categoryAreas.splice(i, 1);
                    return false;
                }
            });
            $scope.loading = false;
        }).error(function (data) {
            $scope.error = "An Error has occurred while Saving categoryArea! " + data.ExceptionMessage;
            $scope.loading = false;

        });
    };

    //get all categoryArea- Self Calling -On load
    categoryAreaFactory.getCategoryArea().success(function (data) {
        $scope.categoryAreas = data;

        $scope.loading = false;
    })
    .error(function (data) {
        $scope.error = "An Error has occurred while loading CategoryAreas! " + data.ExceptionMessage;
        $scope.loading = false;
    });

    //get all category- Self Calling -On load
    categoryAreaFactory.getCategory().success(function (data) {
        $scope.categorys = data;

       
    })
    .error(function (data) {
        $scope.error = "An Error has occurred while loadingCat Categorys! " + data.ExceptionMessage;
       
    });
}]);