
var app = angular.module('app', []);
var url = 'api/Customers/';
app.factory('categoryFactory', function ($http) {
    return {
        getcategory: function () {
            return $http.get(url);
        },
        addcategory: function (category) {
            return $http.post(url, category);
        },
        deletecategory: function (category) {
            return $http.delete(url + category.CategoryAreaID);
        },
        updateCategory: function (category) {
            return $http.put(url + category.Id, category);
        }
    };
});

app.controller('CategoryController', ['$scope', 'categoryFactory', function ($scope, categoryFactory) {
    $scope.category = [];
    $scope.loading = true;
    $scope.addMode = false;

    $scope.toggleEdit = function () {
        this.customer.editMode = !this.customer.editMode;
    };
    $scope.toggleAdd = function () {
        $scope.addMode = !$scope.addMode;
    };


    // Save Customer Event
    $scope.save = function () {
        $scope.loading = true;
        var cust = this.customer;
        categoryFactory.updateCategory(cust).success(function (data) {
            alert("Saved Successfully!!");
            cust.editMode = false;
            $scope.loading = false;
        }).error(function (data) {
            $scope.error = "An Error has occurred while Saving category! " + data.ExceptionMessage;
            $scope.loading = false;

        });
    };

    // add Customer Event
    $scope.add = function () {
        $scope.loading = true;
        customerFactory.addCustomer(this.newcustomer).success(function (data) {
            alert("Added Successfully!!");
            $scope.addMode = false;
            $scope.category.push(data);
            $scope.loading = false;
        }).error(function (data) {
            $scope.error = "An Error has occurred while Adding customer! " + data.ExceptionMessage;
            $scope.loading = false;

        });
    };
    // delete Customer Event
    $scope.delcategory = function () {
        $scope.loading = true;
        var currentCategory = this.category;
        categoryFactory.deleteCategory(categoryCustomer).success(function (data) {
            alert("Deleted Successfully!!");
            $.each($scope.category, function (i) {
                if ($scope.category[i].CustomerID === currentCategory.CategoryID) {
                    $scope.category.splice(i, 1);
                    return false;
                }
            });
            $scope.loading = false;
        }).error(function (data) {
            $scope.error = "An Error has occurred while Saving customer! " + data.ExceptionMessage;
            $scope.loading = false;

        });
    };

    //get all Customers- Self Calling -On load
    categoryFactory.getCategory().success(function (data) {
        $scope.customers = data;
        $scope.loading = false;
    })
    .error(function (data) {
        $scope.error = "An Error has occurred while loading posts! " + data.ExceptionMessage;
        $scope.loading = false;
    });

}]);