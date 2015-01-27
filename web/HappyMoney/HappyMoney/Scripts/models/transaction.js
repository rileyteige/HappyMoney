define(['util/endpoints'], function (endpoints) {
    return {
        undoTransaction: function (guid, callback, error) {
            endpoints.httpDelete('/Transaction', { transactionGuid: guid }, callback, error);
        }
    };
});