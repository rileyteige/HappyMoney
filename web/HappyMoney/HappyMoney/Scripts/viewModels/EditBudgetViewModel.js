define(['knockout', 'models/envelope'], function (ko, envelopeService) {
    var EnvelopeViewModel = function (env) {
        this.name = ko.observable(env.name);
        this.capacity = ko.observable(env.capacity);
        this.guid = env.guid;

        var self = this;
        this.toPojo = function () {
            return {
                name: self.name(),
                capacity: self.capacity(),
                guid: self.guid
            };
        }
    }

    var EditBudgetViewModel = function (data) {
        var self = this;

        this.envelopes = ko.observableArray(data.map(function (env) {
            return ko.observable(new EnvelopeViewModel(env));
        }));

        this.capacity = ko.computed(function () {
            return self.envelopes().reduce(function (accum, curr) {
                return accum + parseFloat(curr().capacity());
            }, 0.0);
        });

        this.saveChanges = function () {
            envelopeService.updateEnvelopes(this.envelopes().map(function (env) { return env().toPojo(); }));
        };
    };

    return EditBudgetViewModel;
});