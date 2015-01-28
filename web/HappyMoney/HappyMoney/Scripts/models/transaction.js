define(['util/endpoints'], function (endpoints) {
    return {
        undoTransaction: function (guid, callback, error) {
            endpoints.httpDelete('/Transaction', { transactionGuid: guid }, callback, error);
        },

        postTransaction: function (transaction, callback, error) {
            var args = {
                total: transaction.total,
                payee: escape(transaction.payee),
                eventDate: transaction.eventDate,
                accountId: transaction.accountId
            };

            endpoints.post('/Transaction', args, callback, error);
        }
    };
});