define(['knockout'], function (ko) {
    function TransactionViewModel(transaction) {
        this.total = transaction.total;
        this.payee = transaction.payee;
    }

    function BudgetSummaryViewModel(transactions) {
        this.transactions = ko.observableArray(transactions.map(function (t) { return new TransactionViewModel(t); }));
    }

    return BudgetSummaryViewModel;
});