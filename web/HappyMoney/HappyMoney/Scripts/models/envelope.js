define(['util/endpoints'], function (endpoints) {
    return {
        updateEnvelopes: function (envelopes, callback) {
            endpoints.put('/Envelope', { envelopes: envelopes }, callback);
        },

        deleteEnvelope: function (guid, callback, error) {
            var wrapperCallback = function (didDelete) {
                if (didDelete === true) {
                    if (typeof callback === "function") callback(didDelete);
                } else {
                    if (typeof error === "function") error();
                }
            }

            endpoints.httpDelete('/Envelope', { envelopeGuid: guid }, wrapperCallback);
        },

        createEnvelope: function (budgetGuid, name, callback, error) {
            var wrapperCallback = function (envelopeGuid) {
                var emptyGuid = '00000000-0000-0000-0000-000000000000';
                if (envelopeGuid != emptyGuid) {
                    if (typeof callback === "function") callback(envelopeGuid);
                } else {
                    if (typeof error === "function") error();
                }
            }

            endpoints.post('/Envelope', { name: name, budgetGuid: budgetGuid }, wrapperCallback);
        }
    };
});