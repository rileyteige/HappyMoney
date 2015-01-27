define(['knockout', 'util/pageGuid', 'models/budget', 'viewModels/BudgetSummaryViewModel'], function (ko, extractPageGuid, budgetService, BudgetSummaryViewModel) {
    function appMain() {
        var budgetGuid = extractPageGuid();

        budgetService.getTransactions(budgetGuid, function (transactions) {
            ko.applyBindings(new BudgetSummaryViewModel(transactions));
        });
    }

    return { start: appMain };
});