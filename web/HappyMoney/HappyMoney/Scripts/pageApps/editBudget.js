// App module for the "Edit Budget" page.

define(['knockout', 'toastr', 'jquery', 'models/budget', 'viewModels/EditBudgetViewModel'], function (ko, toastr, $, budget, EditBudgetViewModel) {
    toastr.options = {
        "positionClass": "toast-offset-top-right"
    }

    var appMain = function () {
        var budgetGuid = $('body').data('identifier');

        if (!budgetGuid) {
            throw new Error('No budget GUID embedded in the page.');
        }

        budget.getEnvelopes(budgetGuid, function (envelopes) { loadEnvelopes(budgetGuid, envelopes); });
    }

    var loadEnvelopes = function (budgetGuid, envelopes) {
        ko.applyBindings(new EditBudgetViewModel(budgetGuid, envelopes));
    }

    return {
        start: appMain
    };
});