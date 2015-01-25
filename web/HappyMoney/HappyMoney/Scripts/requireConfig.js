require.config({
    baseUrl: '/Scripts',
    paths: {
        knockout: 'knockout-2.1.0',
        toastr: '//cdnjs.cloudflare.com/ajax/libs/toastr.js/2.1.0/js/toastr.min'
    }
});

require(['pageApps/' + requireAppScript], function (app) {
    app.start();
});