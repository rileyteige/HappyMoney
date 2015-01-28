define(['knockout', 'models/transaction'], function (ko, transactionService) {
    function TransactionViewModel(transaction) {
        this.accountId = transaction.accountId;
        this.total = transaction.total;
        this.payee = transaction.payee;
        this.guid = transaction.guid;
    }

    function TransactionsViewModel(accounts, transactions) {
        this.transactions = ko.observableArray(transactions.map(function (t) { return new TransactionViewModel(t); }));

        this.selectedAccount = ko.observable(accounts.length > 0 ? accounts[0] : {});
        this.newTransactionPayee = ko.observable('');
        this.newTransactionTotal = ko.observable('');

        var findAccount = function (id) {
            console.log(accounts);
            console.log(accounts.filter);
            var elems = accounts.filter(function (acc) { return acc.id == id });
            return elems.length > 0 ? elems[0] : null;
        }

        var self = this;

        this.postTransaction = function () {
            var transaction = {
                accountId: self.selectedAccount().id,
                total: parseFloat(self.newTransactionTotal()),
                payee: self.newTransactionPayee(),
                eventDate: '1-27-2015'
            };

            transactionService.postTransaction(transaction, function (guid) {
                var account = findAccount(transaction.accountId);
                if (account != null) {
                    account.balance(account.balance() + transaction.total);
                }

                self.newTransactionPayee('');
                self.newTransactionTotal('');

                transaction.guid = guid;
                self.transactions.push(new TransactionViewModel(transaction));
                console.log('Transaction posted successfully.');
            })
        }

        this.deleteTransaction = function (transaction) {
            transactionService.undoTransaction(transaction.guid, function () {
                console.log('Transaction deleted successfully.');
                self.transactions.remove(transaction);
                var account = findAccount(transaction.accountId);
                if (account != null) {
                    account.balance(account.balance() - transaction.total);
                }
            });
        }
    }

    return TransactionsViewModel;
});