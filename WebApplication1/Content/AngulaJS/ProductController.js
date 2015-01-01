
var app = angular.module('app', ['flow']);
var urlProduct = '/api/Product/';


app.factory('ProductFactory', function ($http) {
    return {
        getProduct: function () {
            return $http.get(urlProduct);
        },
       
        addProduct: function (product) {
            return $http.post(urlProduct, product);
        },
        deleteProduct: function (product) {
            return $http.delete(urlProduct + product.id);
        },
        updateProduct: function (product) {
            return $http.put(urlProduct + product.id, product);
        }
    };
});

app.controller('ProductController', ['$scope', 'ProductFactory', function ($scope, ProductFactory) {
    $scope.Products = [];
    $scope.loading = true;
    $scope.addMode = false;

    $scope.toggleEdit = function () {
        this.product.editMode = !this.product.editMode;
    };
    $scope.toggleAdd = function () {
        $scope.addMode = !$scope.addMode;
    };


    // Save product Event
    $scope.save = function () {
        $scope.loading = true;
        var us = this.product;
        ProductFactory.updateProduct(us).success(function (data) {
            alert("Saved Successfully!!");
            us.editMode = false;
            $scope.loading = false;
        }).error(function (data) {
            $scope.error = "An Error has occurred while Saving product! " + data.ExceptionMessage;
            $scope.loading = false;

        });
    };

    // add Product Event
    $scope.add = function () {
        $scope.loading = true;
        ProductFactory.addProduct(this.newCompanyProductService).success(function (data) {
            alert("Added Successfully!!");
            $scope.addMode = false;
            $scope.products.push(data);
            $scope.loading = false;
        }).error(function (data) {
            $scope.error = "An Error has occurred while Adding product! " + data.ExceptionMessage;
            $scope.loading = false;

        });
    };
    // delete Product Event
    $scope.delProduct = function () {
        $scope.loading = true;
        var currentProduct = this.product;
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
            $scope.error = "An Error has occurred while Saving product! " + data.ExceptionMessage;
            $scope.loading = false;

        });
    };

    //get all product- Self Calling -On load
    ProductFactory.getProduct().success(function (data) {
        $scope.products = data;

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
  //    products.save($scope.product)
  //    .$promise.then(function(result) {
  //        $scope.product = result;
  //        if ($scope.product.id) {
  //            $flow.opts.target = apiUrl + '/products/' + $scope.product.id + '/images';
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