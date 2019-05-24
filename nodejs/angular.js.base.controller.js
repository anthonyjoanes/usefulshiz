/**
 * @title: `setting up BaseCtrl` in AngularJS 1.3.x
 * @author: Shahzad Nawaz
 * @dated: 2/28/2015.
 */

(function () {
  'use strict';

  /*Base Controller starts*/
  angular
      .module('testMod')
      .controller('BaseCtrl', BaseCtrl );

  BaseCtrl.$inject = ['$scope'];

  function BaseCtrl( $scope ) {

      //listeners
      /*
      Angular destroys all listeners on scope, by itself, before destroying any scope of a controller, and
      after triggering $destroy event on that scope.
      */
      $scope.$on('$destroy', scopeDestroyListener );

      //listener for '$destroy' event on scope.
      function scopeDestroyListener() {

          //invokes $scope.onDestroy method ( if defined in child controller ).
          /*
          This is specifically used to destroy any third-party component, that was intergrated in any dedicated view of application
          for example: d3 graphs, Google Maps, Jquery's Carousel etc.
          $rootscope listeners could be destroyed here, as well.
          */
          $scope.onDestroy && $scope.onDestroy();

          //logging for development purpose
          console.log('released $scope.');
      }
  }
  /*Base Controller ends*/

  /*test1 Controller starts*/
  angular
      .module('testMod')
      .controller('test1Ctrl', test1Ctrl );

  test1Ctrl.$inject = ['$scope', '$controller', 'fooService', 'barService'];

  function test1Ctrl( $scope, $controller, fooService, barService ) {

      //Extends BaseCtrl's scope
      $controller('BaseCtrl', {$scope: $scope});

      //some object inside $scope
      $scope.testObj = {
          x: 'xoxo',
          y: 'yoyo'
      };

      //method from fooService
      $scope.fooFunc = fooService.fooFunc;

      //method from barService
      $scope.barFunc = barService.barFunc;

      //method to be invoked before BaseCtrl destroys $scope.
      $scope.onDestroy = function() {
          //release (off) any events, which controller was listening to.
      };
  }
  /*test1 Controller ends*/

})();