﻿angular.module('app')
.controller('HomeCtrl', ['$scope', 'security', function ($scope, Security) {
  
    Security.redirectAuthenticated('/createblrb');
}]);