angular.module("umbraco").controller("LatestNewsEventsBlock.Controller", function ($scope) {

	function Item() {
		this.title = '';
	}

	$scope.control.value = $scope.control.value || new Item();
});
