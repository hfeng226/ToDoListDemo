(function () {
    angular.module('DemoApp', [])
})();

(function () {
    angular.module('DemoApp').controller('DemoController', DemoController);
    DemoController.$inject = ['DemoServices'];
    function DemoController(DemoServices) {
        var vm = this;
        console.log(vm);
        vm.$onInit = _getList;
        vm.addBtn = _postInput;
        vm.editBtn = _edit;
        vm.removeBtn = _removeItem;
        vm.itemList = [];
        
        function _getList() {
            DemoServices.getListService().then(_getListSuccess, _getListError);
        }
        function _getListSuccess(response) {
            console.log(response);
            vm.itemList = response.data;
        }
        function _getListError(error) {
            console.log(error);
        }
        function _edit(data) {
            vm.data = data;
}
        function _putInput(data) {
        //    $uibModal.open({
        //        templateUrl: '',
        //        controller: uibController,
        //        controllerAs: uib
        //    });
            //debugger
            DemoServices.putListService(data).then(_putItemSuccess, _putItemError)
        }
        function _putItemSuccess(response) {
            console.log(response);
        }
        function _putItemError(error) {
            console.log(error);
        }
        function _postInput() {
            DemoServices.postListService(vm.data).then(_postItemSuccess, _postItemError)
        }
        function _postItemSuccess(response) {
            console.log(response);
            vm.data = null;
            vm.itemList.push(Object.assign({}, vm.data));
            DemoServices.getListService().then(_getListSuccess, _getListError);
        }
        function _postItemError(error) {
            console.log(error);
        }
        function _removeItem(id, index) {
            vm.index = index;
            DemoServices.deleteListService(id).then(_deleteItemSuccess, _deleteItemError);
            vm.itemList.splice(index, 1);
        }
        function _deleteItemSuccess(response) {
            console.log(response)
        }
        function _deleteItemError(error) {
            console.log(error);
        }
    }
})();
(function () {
    'use strict';
    angular.module('DemoApp').factory('DemoServices', DemoServices);
    DemoServices.$inject = ['$http']

    function DemoServices($http, $q) {
        return {
            getListService: _getListService
            , postListService: _postListService
            , putListService: _putListService
            , deleteListService: _deleteListService
        }
        function _getListService() {
            var settings = {
                url: "/api/demo/message"
                        , cache: false
                        , contentType: 'application/json; charset=UTF-8'
                        , dataType: 'json'
                        , method: 'GET'
            }
            return $http(settings);
        }
        function _postListService(data) {
           var settings = {
                url: "/api/demo"
                , cache: false
                , contentType: 'application/json; charset=UTF-8'
                , dataType: 'json'
                , method: 'POST'
                , data: data
            }
            return $http(settings);
        }
        function _putListService(data) {
           var settings = {
                url: "/api/demo/" + data.Id
                , cache: false
                , contentType: 'application/json; charset=UTF-8'
                , dataType: 'json'
                , method: 'PUT'
                , data: data
            }
            return $http(settings);
        }

        function _deleteListService(id) {
           var settings = {
                url: "/api/demo/" + id
                , cache: false
                , contentType: 'application/json; charset=UTF-8'
                , dataType: 'json'
                , method: 'DELETE'
               , data: id         
            }
            return $http(settings);
        }
    }
})();
















//(function () {
//    'use strict';

//    var app = angular.module('DemoApp', []);

//    app.controller('DemoController', DemoController);

//    DemoController.$inject = ['$http'];

//    function DemoController($http) {
//        var vm = this;

//        $http({
//            method: 'GET',
//            url: '/api/demo/message'
//        }).then(success, error);

//        function success(response) {
//            console.log(response.data);
//            vm.messages = response.data

//        }
//        function error(error) {
//            console.log(error);
//        }
//        $http({
//            method: 'POST',
//            url: '/api/demo'
//        }).then(success, error);
//        function success(response){
//            console.log(response);
//        }
//        function error(error) {
//            console.log(error);
//        }


//    }

//})();