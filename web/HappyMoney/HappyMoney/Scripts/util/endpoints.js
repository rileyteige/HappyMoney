define(['jquery'], function ($) {

    function ajaxCaller(methodName) {
        return function (endpoint, arguments, callback) {
            $.ajax({
                url: '/api' + endpoint,
                type: methodName,
                contentType: 'application/json',
                data: methodName !== 'GET' ? JSON.stringify(arguments) : arguments,
                success: callback
            });
        };
    }

    return {
        get: ajaxCaller('GET'),
        put: ajaxCaller('PUT'),
        post: ajaxCaller('POST'),
        httpDelete: ajaxCaller('DELETE')
    };
});