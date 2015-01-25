define(['util/endpoints'], function (endpoints) {
    return {
        updateEnvelopes: function (envelopes, callback) {
            endpoints.put('/Envelope', { envelopes: envelopes }, callback);
        }
    };
});