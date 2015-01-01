
var app = angular.module('app', ['flow']);
//, 'ngAnimate' ,'toastr',
var url = '/api/Company/';
var urlUser = '/api/User/';
var urlCompanyType = '/api/CompanyType/';
var urlCat = '/api/Category/';
var urlProduct = '/api/Product/';
var currentCompanyG ={};
app.factory('companyFactory', function ($http) {
 
    return {

        

        getCompany: function () {
           // toaster.pop('success', "title", "text");
            return $http.get(url);
        },
        getCurrentCompany: function () {

            return $http.get(url + 1002);
        },
            getUser: function () {
           
                return $http.get(urlUser);
            },
            getCategory: function () {
                return $http.get(urlCat);
            },
            getCompanyType: function () {

        return $http.get(urlCompanyType);
    },
        addCompany: function (company) {
            
            return $http.post(url, company);
        },
        deleteCompany: function (company) {
            return $http.delete(url + company.id);
        },
        updateCompany: function (company) {
            return $http.put(url + company.id, company);
        }
    };
});
//myApp.controller('FileUploadCtrl',
//    ['$scope', '$rootScope', 'uploadManager', 
//    function ($scope, $rootScope, uploadManager) {
//    $scope.files = [];
app.controller('CompanyController', ['$scope','$rootScope', 'companyFactory', function ($scope,$rootScope, companyFactory) {
    $scope.Companies = [];
    $scope.loading = true;
    $scope.addMode = true;
    $rootScope.rootComany = {};
    $scope.userSelectedCategory = [];

    $scope.toggleEdit = function () {
        this.company.editMode = !this.company.editMode;
    };
    $scope.toggleAdd = function () {
        $scope.addMode = !$scope.addMode;
    };


    // Save company Event
    $scope.save = function () {
        $scope.loading = true;
        var us = this.company;
        companyFactory.updateCompany(us).success(function (data) {
            alert("Saved Successfully!!");
            currentCompanyG = us;
            us.editMode = false;
            $scope.loading = false;
        }).error(function (data) {
            $scope.error = "An Error has occurred while Saving company! " + data.ExceptionMessage;
            $scope.loading = false;

        });
    };


    // add Company Event
    $scope.add = function () {
        $scope.loading = true;
        companyFactory.addCompany(this.newCompany).success(function (data) {
            alert("Added Successfully!!");
            $scope.addMode = false;
            $scope.Companies.push(data);
            currentCompanyG = data;
            $scope.loading = false;
        }).error(function (data) {
            $scope.error = "An Error has occurred while Adding company! " + data.ExceptionMessage;
            $scope.loading = false;

        });
    };
    // delete Company Event
    $scope.delcompany = function () {
        $scope.loading = true;
        var currentCompany = this.company;
        companyFactory.deleteCompany(currentCompany).success(function (data) {
            alert("Deleted Successfully!!");
            $.each($scope.Companies, function (i) {
                if ($scope.Companies[i].id === currentCompany.id) {
                    $scope.Companies.splice(i, 1);
                    return false;
                }
            });
            $scope.loading = false;
        }).error(function (data) {
            $scope.error = "An Error has occurred while Saving company! " + data.ExceptionMessage;
            $scope.loading = false;

        });
    };
   
    //get all company- Self Calling -On load
    companyFactory.getCompany().success(function (data) {
        $scope.Companies = data;
       
        $scope.loading = false;
    })
    .error(function (data) {
        $scope.error = "An Error has occurred while loading Companys! " + data.ExceptionMessage;
        $scope.loading = false;
    });
    //get all company-type load
    companyFactory.getCurrentCompany().success(function (data) {
        rootComany = data;
         
       
    })
    .error(function (data) {
        $scope.error = "An Error has occurred while loading Companys! " + data.ExceptionMessage;
       
    });
    // get the Current Company
    companyFactory.getCompanyType().success(function (data) {
        $scope.CompanyTypeList = data;


    })
    .error(function (data) {
        $scope.error = "An Error has occurred while loading Companys! " + data.ExceptionMessage;

    });
    //get all category- Self Calling -On load
    companyFactory.getCategory().success(function (data) {
        $scope.categorys = data;

       
    })
    .error(function (data) {
        $scope.error = "An Error has occurred while loadingCat Categorys! " + data.ExceptionMessage;
       
    });
   $scope.selectedCat = {
        categoryAreas: []
    };
    companyFactory.getUser().success(function (data) {
      
        $scope.userList = data;
        
       
    })
    .error(function (data) {
        $scope.error = "An Error has occurred while loading Users! " + data.ExceptionMessage;
       
    });
}]);

app.factory('ProductFactory', function ($http) {
    return {
       
        
        getProduct: function () {
            return $http.get(urlProduct);
            //alert("best" + currentCompanyG.companyId);
            //return currentCompanyG.companyProductServices;
        },
       
        addProduct: function (product, $flow) {
            product.companyId = rootComany.companyId;
            if ($flow != null) {
                $flow.opts.target = apiUrl + '/products/' + product.companyProductServiceId + '/images';
                $flow.upload();
                product.url = $flow.opts.target;
            }
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
//myApp.controller('FileUploadCtrl',
//    ['$scope', '$rootScope', 'uploadManager', 
//    function ($scope, $rootScope, uploadManager) {
//    $scope.files = [];
app.controller('ProductController', ['$scope', 'ProductFactory', function ($scope, ProductFactory) {
    $scope.Products = [];
    $scope.loading = true;
    $scope.addMode = false;
    $scope.currentCompany = {};

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
        $scope.products = rootComany.companyProductServices;
        alert("new year" + products[1].companyProductServiceId);
        $scope.loading = false;d
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

app.directive('checklistModel', ['$parse', '$compile', function ($parse, $compile) {
    // contains
    function contains(arr, item) {
        if (angular.isArray(arr)) {
            for (var i = 0; i < arr.length; i++) {
                if (angular.equals(arr[i], item)) {
                    return true;
                }
            }
        }
        return false;
    }

    // add
    function add(arr, item) {
        arr = angular.isArray(arr) ? arr : [];
        for (var i = 0; i < arr.length; i++) {
            if (angular.equals(arr[i], item)) {
                return arr;
            }
        }
        arr.push(item);
        return arr;
    }

    // remove
    function remove(arr, item) {
        if (angular.isArray(arr)) {
            for (var i = 0; i < arr.length; i++) {
                if (angular.equals(arr[i], item)) {
                    arr.splice(i, 1);
                    break;
                }
            }
        }
        return arr;
    }

    // http://stackoverflow.com/a/19228302/1458162
    function postLinkFn(scope, elem, attrs) {
        // compile with `ng-model` pointing to `checked`
        $compile(elem)(scope);

        // getter / setter for original model
        var getter = $parse(attrs.checklistModel);
        var setter = getter.assign;

        // value added to list
        var value = $parse(attrs.checklistValue)(scope.$parent);

        // watch UI checked change
        scope.$watch('checked', function (newValue, oldValue) {
            if (newValue === oldValue) {
                return;
            }
            var current = getter(scope.$parent);
            if (newValue === true) {
                setter(scope.$parent, add(current, value));
            } else {
                setter(scope.$parent, remove(current, value));
            }
        });

        // watch original model change
        scope.$parent.$watch(attrs.checklistModel, function (newArr, oldArr) {
            scope.checked = contains(newArr, value);
        }, true);
    }

    return {
        restrict: 'A',
        priority: 1000,
        terminal: true,
        scope: true,
        compile: function (tElement, tAttrs) {
            if (tElement[0].tagName !== 'INPUT' || tAttrs.type !== 'checkbox') {
                throw 'checklist-model should be applied to `input[type="checkbox"]`.';
            }

            if (!tAttrs.checklistValue) {
                throw 'You should provide `checklist-value`.';
            }

            // exclude recursion
            tElement.removeAttr('checklist-model');

            // local scope var storing individual checkbox model
            tElement.attr('ng-model', 'checked');

            return postLinkFn;
        }
    };
}]);

