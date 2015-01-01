
var app = angular.module('app', ['flow']);
var urlProduct = '/api/CompaniesCategory/';


app.factory('ProductFactory', function ($http) {
    return {
        getProduct: function () {
            return $http.get(urlProduct);
        },
       
        addProduct: function (CompaniesCategory) {
            return $http.post(urlProduct, CompaniesCategory);
        },
        deleteProduct: function (CompaniesCategory) {
            return $http.delete(urlProduct + CompaniesCategory.id);
        },
        updateProduct: function (CompaniesCategory) {
            return $http.put(urlProduct + CompaniesCategory.id, CompaniesCategory);
        }
    };
});

app.controller('ProductController', ['$scope', 'ProductFactory', function ($scope, ProductFactory) {
    $scope.Products = [];
    $scope.loading = true;
    $scope.addMode = false;

    $scope.toggleEdit = function () {
        this.CompaniesCategory.editMode = !this.CompaniesCategory.editMode;
    };
    $scope.toggleAdd = function () {
        $scope.addMode = !$scope.addMode;
    };


    // Save CompaniesCategory Event
    $scope.save = function () {
        $scope.loading = true;
        var us = this.CompaniesCategory;
        ProductFactory.updateProduct(us).success(function (data) {
            alert("Saved Successfully!!");
            us.editMode = false;
            $scope.loading = false;
        }).error(function (data) {
            $scope.error = "An Error has occurred while Saving CompaniesCategory! " + data.ExceptionMessage;
            $scope.loading = false;

        });
    };

    // add CompaniesCategory Event
    $scope.add = function () {
        $scope.loading = true;
        ProductFactory.addProduct(this.newCompanyProductService).success(function (data) {
            alert("Added Successfully!!");
            $scope.addMode = false;
            $scope.CompaniesCategorys.push(data);
            $scope.loading = false;
        }).error(function (data) {
            $scope.error = "An Error has occurred while Adding CompaniesCategory! " + data.ExceptionMessage;
            $scope.loading = false;

        });
    };
    // delete CompaniesCategory Event
    $scope.delProduct = function () {
        $scope.loading = true;
        var currentProduct = this.CompaniesCategory;
        ProductFactory.deleteProduct(currentProduct).success(function (data) {
            alert("Deleted Successfully!!");
            $.each($scope.Products, function (i) {
                if ($scope.Products[i].id === currentProduct.id) {
                    $scope.Products.splice(i, 1);
                    return false;
                }
            });
            $scope.loading = false;
        }).error(function (data) {
            $scope.error = "An Error has occurred while Saving CompaniesCategory! " + data.ExceptionMessage;
            $scope.loading = false;

        });
    };

    //get all CompaniesCategory- Self Calling -On load
    ProductFactory.getProduct().success(function (data) {
        $scope.CompaniesCategorys = data;

        $scope.loading = false;
    })
    .error(function (data) {
        $scope.error = "An Error has occurred while loading Products! " + data.ExceptionMessage;
        $scope.loading = false;
    });

    //get all category- Self Calling -On load
    
}]);
app.config(['flowFactoryProvider', function (flowFactoryProvider) {
  flowFactoryProvider.defaults = {
    target: 'upload.php',
    permanentErrors: [404, 500, 501],
    maxChunkRetries: 1,
    chunkRetryInterval: 5000,
    simultaneousUploads: 4,
    singleFile: true
  };
  //$scope.$on('flow::filesSubmitted', function (event, $flow, flowFile)
  //    CompaniesCategorys.save($scope.CompaniesCategory)
  //    .$promise.then(function(result) {
  //        $scope.CompaniesCategory = result;
  //        if ($scope.CompaniesCategory.id) {
  //            $flow.opts.target = apiUrl + '/CompaniesCategorys/' + $scope.CompaniesCategory.id + '/images';
  //            $flow.upload();
  //        }
  //    });
  //});
  flowFactoryProvider.on('catchAll', function (event) {
    console.log('catchAll', arguments);
  });
  // Can be used with different implementations of Flow.js
  // flowFactoryProvider.factory = fustyFlowFactory;
}]);