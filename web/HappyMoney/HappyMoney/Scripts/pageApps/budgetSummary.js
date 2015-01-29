define(['knockout', 'jquery', 'util/pageGuid', 'models/budget', 'viewModels/BudgetSummaryViewModel'], function (ko, $, extractPageGuid, budgetService, BudgetSummaryViewModel) {
    Date.prototype.toDateInputValue = (function () {
        var local = new Date(this);
        local.setMinutes(this.getMinutes() - this.getTimezoneOffset());
        return local.toJSON().slice(0, 10);
    });

    function appMain() {
        var budgetGuid = extractPageGuid();

        budgetService.getBudgetSummary(budgetGuid, function (budget) {
            ko.applyBindings(new BudgetSummaryViewModel(budget));
        });

        $('.date-picker').val(new Date().toDateInputValue());
    }

    return { start: appMain };
});