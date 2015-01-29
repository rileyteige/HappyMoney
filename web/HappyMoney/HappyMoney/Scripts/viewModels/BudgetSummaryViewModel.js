define(['knockout', 'viewModels/TransactionsViewModel', 'util/formatter'], function (ko, TransactionsViewModel, formatter) {
    function AccountViewModel(account) {
        var self = this;
        this.balance = ko.observable(account.balance);
        this.displayBalance = ko.computed(function () {
            return formatter.toMoney(self.balance());
        });
        this.id = account.id;
        this.name = account.name;
    }

    function EnvelopeViewModel(envelope) {
        var self = this;
        this.name = envelope.name;
        this.balance = envelope.balance;
        this.displayBalance = ko.computed(function () {
            return formatter.toMoney(self.balance);
        });
        this.capacity = envelope.capacity;
        this.displayCapacity = ko.computed(function () {
            return formatter.toMoney(self.capacity);
        });
    }

    function BudgetSummaryViewModel(budget) {
        this.envelopes = budget.envelopes.map(function (e) { return new EnvelopeViewModel(e); });
        this.accounts = budget.accounts.map(function (a) { return new AccountViewModel(a); });
        this.transactionSet = new TransactionsViewModel(this.accounts, budget.transactions);
    }

    return BudgetSummaryViewModel;
});