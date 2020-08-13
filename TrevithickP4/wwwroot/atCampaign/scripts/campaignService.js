//James Trevithick          jtrevithick2@cnm.edu                TrevithickP4
(function (app) {
    var campaignService = function ($http, campaignApiUrl) {
        var getAll = function () {
            return $http.get(campaignApiUrl);
        };
        var getByPage = function (page, perPage) {
            return $http.get(campaignApiUrl + "?page="+page+"&per_page="+perPage)
        };
        var getById = function (id) {
            return $http.get(campaignApiUrl + id);
        };
        var update = function (campaigns) {
            return $http.put(campaignApiUrl + campaigns.id, campaigns);
        };
        var create = function (campaigns) {
            return $http.post(campaignApiUrl, campaigns);
        };
        var destroy = function (campaigns) {
            return $http.delete(campaignApiUrl + campaigns.id);
        };
        return {
            getAll: getAll,
            getPage: getByPage,
            getById: getById,
            update: update,
            create: create,
            delete: destroy
        };
    };
    app.factory("campaignService", campaignService);
}(angular.module("TheCampaign")))
