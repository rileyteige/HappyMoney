define(['knockout', 'viewModels/TransactionsViewModel'], function (ko, TransactionsViewModel) {
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
        this.transactionSet = new TransactionsViewModel(this.accounts, budget.transactions);
    }

    return BudgetSummaryViewModel;
});