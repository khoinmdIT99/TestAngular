//James Trevithick          jtrevithick2@cnm.edu                TrevithickP4
(function (app) {
    var listController = function ($scope, campaignService) {
        campaignService
            .getAll()
            .then(function (response) {
                $scope.page = 1;
                $scope.perPage = 10;
                $scope.campaigns = response.data;
            });
        $scope.getPage = function () {
            campaignService
                .getPage($scope.page - 1, $scope.perPage)
                .then(function (response){
                $scope.campaigns = response.data;
            });
        };
    };
    app.controller("listController", listController);
}(angular.module("TheCampaign")));
