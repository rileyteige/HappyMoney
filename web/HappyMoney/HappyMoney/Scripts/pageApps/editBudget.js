// App module for the "Edit Budget" page.

define(['knockout', 'jquery', 'models/budget', 'viewModels/EditBudgetViewModel'], function (ko, $, budget, EditBudgetViewModel) {
    var appMain = function () {
        var budgetGuid = $('body').data('identifier');

        if (!budgetGuid) {
            throw new Error('No budget GUID embedded in the page.');
        }

        budget.getEnvelopes(budgetGuid, loadEnvelopes);
    }

    var loadEnvelopes = function (envelopes) {
        ko.applyBindings(new EditBudgetViewModel(envelopes));
    }

    return {
        start: appMain
    };
});