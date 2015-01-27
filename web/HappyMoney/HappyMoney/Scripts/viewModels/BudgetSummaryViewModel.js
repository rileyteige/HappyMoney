define(['knockout', 'models/transaction'], function (ko, transactionService) {
    function TransactionViewModel(transaction) {
        this.accountId = transaction.accountId;
        this.total = transaction.total;
        this.payee = transaction.payee;
        this.guid = transaction.guid;
    }

    function AccountViewModel(account) {
        this.balance = ko.observable(account.balance);
        this.id = account.id;
        this.name = account.name;
    }

    function EnvelopeViewModel(envelope) {
        this.name = envelope.name;
        this.balance = envelope.balance;
        this.capacity = envelope.capacity;
    }

    function BudgetSummaryViewModel(budget) {
        this.envelopes = budget.envelopes.map(function (e) { return new EnvelopeViewModel(e); });
        this.accounts = budget.accounts.map(function (a) { return new AccountViewModel(a); });
        this.transactions = ko.observableArray(budget.transactions.map(function (t) { return new TransactionViewModel(t); }));

        var self = this;

        this.deleteTransaction = function (transaction) {
            transactionService.undoTransaction(transaction.guid, function () {
                console.log('Transaction deleted successfully.');
                self.transactions.remove(transaction);
                var matchingAccounts = self.accounts.filter(function (acc) { return acc.id == transaction.id });
                if (matchingAccounts.length > 0) {
                    var account = matchingAccounts[0];
                    account.balance(account.balance() - transaction.total);
                }
            });
        }
    }

    return BudgetSummaryViewModel;
});