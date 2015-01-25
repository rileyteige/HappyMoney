require.config({
    baseUrl: '/Scripts',
    paths: {
        knockout: 'knockout-2.1.0'
    }
});

require(['pageApps/' + requireAppScript], function (app) {
    app.start();
});