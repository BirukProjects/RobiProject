
var app = angular.module('app', []);
var url = '/api/Category/';
var urlUser = '/api/User/';
var urlCatArea = '/api/CategoryArea/';

app.factory('categoryFactory', function ($http) {
    return {
        getCategory: function () {
            return $http.get(url);
        },
        addCategory: function (category) {
            return $http.post(url, category);
        },
        deleteCategory: function (category) {
            return $http.delete(url + category.id);
        },
        updateCategory: function (category) {
            return $http.put(url + category.id, category);
        }
    };
});

app.controller('CategoryController', ['$scope', 'categoryFactory', function ($scope, categoryFactory) {
    $scope.categorys = [];
    $scope.loadingCat = true;
    $scope.addModeCat = false;

    $scope.toggleEditCat = function () {
        this.category.editModeCat = !this.category.editModeCat;
    };
    $scope.toggleAddCat = function () {
        $scope.addModeCat = !$scope.addModeCat;
    };


    // Save category Event
    $scope.saveCat = function () {
        $scope.loadingCat = true;
        var us = this.category;
        categoryFactory.updateCategory(us).success(function (data) {
            alert("Saved Successfully!!");
            us.editModeCat = false;
            $scope.loadingCat = false;
        }).error(function (data) {
            $scope.error = "An Error has occurred while Saving category! " + data.ExceptionMessage;
            $scope.loadingCat = false;

        });
    };

    // add Category Event
    $scope.addCat = function () {
        $scope.loadingCat = true;
        categoryFactory.addCategory(this.newCategory).success(function (data) {
            alert("Added Successfully!!");
            $scope.addModeCat = false;
            $scope.categorys.push(data);
            $scope.loadingCat = false;
        }).error(function (data) {
            $scope.error = "An Error has occurred while Adding category! " + data.ExceptionMessage;
            $scope.loadingCat = false;

        });
    };
    // delete Category Event
    $scope.delcategory = function () {
        $scope.loadingCat = true;
        var currentCategory = this.category;
        categoryFactory.deleteCategory(currentCategory).success(function (data) {
            alert("Deleted Successfully!!");
            $.each($scope.categorys, function (i) {
                if ($scope.categorys[i].id === currentCategory.id) {
                    $scope.categorys.splice(i, 1);
                    return false;
                }
            });
            $scope.loadingCat = false;
        }).error(function (data) {
            $scope.error = "An Error has occurred while Saving category! " + data.ExceptionMessage;
            $scope.loadingCat = false;

        });
    };

    //get all category- Self Calling -On load
    categoryFactory.getCategory().success(function (data) {
        $scope.categorys = data;

        $scope.loadingCat = false;
    })
    .error(function (data) {
        $scope.error = "An Error has occurred while loadingCat Categorys! " + data.ExceptionMessage;
        $scope.loadingCat = false;
    });

}]);
app.factory('userFactory', function ($http) {
    return {
        getUser: function () {
            return $http.get(urlUser);
        },
        addUser: function (user) {
            return $http.post(urlUser, user);
        },
        deleteUser: function (user) {
            return $http.delete(urlUser + user.id);
        },
        updateUser: function (user) {
            return $http.put(urlUser + user.id, user);
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
app.factory('categoryAreaFactory', function ($http) {
    return {
        getCategoryArea: function () {
            return $http.get(urlCatArea);
        },
        getCategory: function () {
            return $http.get(url);
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