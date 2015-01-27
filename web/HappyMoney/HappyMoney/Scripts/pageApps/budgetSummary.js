define(['knockout', 'util/pageGuid', 'models/budget', 'viewModels/BudgetSummaryViewModel'], function (ko, extractPageGuid, budgetService, BudgetSummaryViewModel) {
    function appMain() {
        var budgetGuid = extractPageGuid();

        budgetService.getBudgetSummary(budgetGuid, function (budget) {
            ko.applyBindings(new BudgetSummaryViewModel(budget));
        });
    }

    return { start: appMain };
});