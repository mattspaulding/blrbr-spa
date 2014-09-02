angular.module('app')
.controller('CreateBlrbCtrl', ['$scope', 'security', function ($scope, Security) {
    Security.authenticate();
    var CreateBlrbModel = function () {
        return {
            username: '',
            request: '',
        }
    };

    $scope.createBlrbModel = new CreateBlrbModel();
    $scope.createBlrb = function () {
        debugger;
        $.ajax({
            url: "../api/Blrb",
            data: $scope.createBlrbModel,
            type: "POST",
            datatype: "JSON",
            success: function (response) {
                debugger;
                $scope.init.HospitalApc = response.d;
                $scope.$apply();
            }
        });

        //if (!$scope.loginForm.$valid) return;
        //$scope.message = "Processing Login...";
        //Security.login(angular.copy($scope.user)).catch(function (data) {
        //	$scope.message = null;
        //});
    }
    $scope.schema = [
		{ property: 'username', type: 'text', attr: { required: true } },
		{ property: 'request', type: 'file', accept: 'audio/*;capture=microphone', attr: { required: true } }
    ];



    $('#save').hide();
    $('#controlsGroup').hide();


    $('#controlsLink').click(function () {
        initAudio();
        $('#controlsGroup').show();
        $('#controlsLink').hide();
    })

    $('#record').click(function () {
        $('#save').show();
    })

    $('#save').click(function () {
        $('#save').hide();
        $('#controlsGroup').hide();
        $('#controlsLink').show();
        text = $('#text').val();
        isTweet = $('#tweetCheckbox').prop('checked');
    })

}]);