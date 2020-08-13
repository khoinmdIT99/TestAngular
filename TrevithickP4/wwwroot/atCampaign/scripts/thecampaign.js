//James Trevithick          jtrevithick2@cnm.edu                TrevithickP4
(function (app) {
    var config = function ($routeProvider) {
        $routeProvider
            .when("/list",
            { templateUrl: "/atCampaign/views/list.html" })
            .when("/details/:id",
                { templateUrl: "/atCampaign/views/details.html" })
            .otherwise(
                { redirectTo: "/list" });
    };
    config.$inject = ["$routeProvider"];
    app.config(config);
    app.constant("campaignApiUrl", "/api/campaigns/");
}(angular.module("TheCampaign", ["ngRoute"])));