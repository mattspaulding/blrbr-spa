angular.module('app')
.controller('MeCtrl', ['$scope', 'security', function ($scope, Security) {
    Security.authenticate();
   


}]);