define(['knockout', 'models/transaction', 'util/formatter'], function (ko, transactionService, formatter) {
    var dateString = function (date) {
        var month = date.getMonth() + 1;
        var day = date.getDate() + 1;
        var year = date.getFullYear();

        return month + '-' + day + '-' + year;
    }



    function TransactionViewModel(transaction) {
        this.id = transaction.id;
        this.accountId = transaction.accountId;
        this.total = transaction.total.toFixed(2);
        this.payee = transaction.payee;
        this.eventDate = Date.parse(transaction.eventDate);
        this.displayDate = dateString(new Date(this.eventDate));
        this.displayTotal = formatter.toMoney(this.total);
        this.guid = transaction.guid;
    }

    var compareFn = function (a, b) {
        var rtn = a.eventDate < b.eventDate
            ? 1
            : a.eventDate > b.eventDate
                ? -1
                : (a.id < b.id ? 1 : a.id > b.id ? -1 : 0);

        return rtn;
    }

    var findMaxId = function (transactions) {
        var max = -1;
        for (var i = 0; i < transactions.length; i++) {
            var t = transactions[i];
            if (t.id > max) {
                max = t.id;
            }
        };

        return max;
    }

    function TransactionsViewModel(accounts, transactions) {
        this.transactions = ko.observableArray(transactions.map(function (t) { return new TransactionViewModel(t); }));

        var maxId = this.transactions().length > 0 ? (findMaxId(this.transactions()) + 1) : 1;

        this.selectedAccount = ko.observable(accounts.length > 0 ? accounts[0] : {});
        this.newTransactionPayee = ko.observable('');
        this.newTransactionTotal = ko.observable('');
        this.newTransactionDate = ko.observable(new Date().toDateInputValue());

        var findAccount = function (id) {
            var elems = accounts.filter(function (acc) { return acc.id == id });
            return elems.length > 0 ? elems[0] : null;
        }

        var self = this;

        this.postTransaction = function () {
            var transaction = {
                id: maxId,
                accountId: self.selectedAccount().id,
                total: parseFloat(self.newTransactionTotal()),
                payee: self.newTransactionPayee(),
                eventDate: self.newTransactionDate()
            };

            transactionService.postTransaction(transaction, function (guid) {
                var account = findAccount(transaction.accountId);
                if (account != null) {
                    account.balance(account.balance() + transaction.total);
                }

                maxId += 1;
                self.newTransactionPayee('');
                self.newTransactionTotal('');

                transaction.guid = guid;
                self.transactions.push(new TransactionViewModel(transaction));
                self.transactions(self.transactions().sort(compareFn));
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