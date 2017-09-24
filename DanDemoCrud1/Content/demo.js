(function () {
    'use strict';

    var app = angular.module('DemoApp', []);

    app.controller('DemoController', DemoController);

    DemoController.$inject = ['$http'];

    function DemoController($http) {
        var vm = this;
      //  console.log(this);
        $http({
            method: 'GET',
            url: '/api/demo/message'
        }).then(success, error);
        
        function success(response) {
            vm.messages = response.data

        }
        function error(error) {
            console.log(error);
        }

    }

})();