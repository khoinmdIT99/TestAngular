//James Trevithick          jtrevithick2@cnm.edu                TrevithickP4
(function (app) {
    var detailsController = function ($scope, $routeParams, campaignService) {
        var id = $routeParams.id;
        campaignService
            .getById(id)
            .then(function (response) {
                $scope.campaigns = response.data;
            });
       
    };
    app.controller("detailsController", detailsController);
}(angular.module("TheCampaign")));