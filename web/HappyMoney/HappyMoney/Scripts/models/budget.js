define(['util/endpoints'], function (endpoints) {
    var testBudgetGuid = function (budgetGuid) {
        if (typeof budgetGuid === "undefined" || budgetGuid === null || budgetGuid == '') {
            throw new Error("budgetGuid must be supplied.");
        }
    }

    return {
        getEnvelopes: function (budgetGuid, callback) {
            testBudgetGuid(budgetGuid);

            endpoints.get('/Envelope', { budgetGuid: budgetGuid }, callback);
        },

        getBudgetSummary: function (budgetGuid, callback, error) {
            testBudgetGuid(budgetGuid);

            endpoints.get('/Budget/' + budgetGuid, {}, callback, error);
        }
    }
});