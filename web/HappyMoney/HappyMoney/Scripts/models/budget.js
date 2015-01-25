define(['util/endpoints'], function (endpoints) {
    return {
        getEnvelopes: function (budgetGuid, callback) {
            if (typeof budgetGuid === "undefined" || budgetGuid === null || budgetGuid == '') {
                throw new Error("budgetGuid must be supplied.");
            }

            endpoints.get('/Envelope', { budgetGuid: budgetGuid }, callback);
        }
    }
});