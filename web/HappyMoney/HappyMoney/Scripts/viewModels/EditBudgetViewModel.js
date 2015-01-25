define(['knockout', 'toastr', 'models/envelope'], function (ko, toastr, envelopeService) {
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

    var EditBudgetViewModel = function (budgetGuid, data) {
        var self = this;

        this.envelopes = ko.observableArray(data.map(function (env) {
            return new EnvelopeViewModel(env);
        }));

        this.capacity = ko.computed(function () {
            return self.envelopes().reduce(function (accum, curr) {
                return accum + parseFloat(curr.capacity());
            }, 0.0);
        });

        this.newEnvelopeName = ko.observable();

        this.createEnvelope = function () {
            var name = self.newEnvelopeName();
            console.log('creating envelope with name ' + name + '...');
            envelopeService.createEnvelope(budgetGuid, self.newEnvelopeName(), function (guid) {
                toastr.success("Envelope created.");
                self.newEnvelopeName('');
                self.envelopes.push(new EnvelopeViewModel({ name: name, capacity: 0.0, guid: guid }));
            }, function () {
                toastr.error('Could not create envelope.');
            });
        }

        this.deleteEnvelope = function (env) {
            envelopeService.deleteEnvelope(env.guid, function () {
                toastr.success("Envelope deleted successfully.");
                self.envelopes.remove(env);
            }, function () {
                toastr.error("Could not delete envelope.");
            })
        }

        this.saveChanges = function () {
            envelopeService.updateEnvelopes(this.envelopes().map(function (env) { return env.toPojo(); }), function () {
                toastr.success("Envelopes saved successfully.");
            });
        };
    };

    return EditBudgetViewModel;
});