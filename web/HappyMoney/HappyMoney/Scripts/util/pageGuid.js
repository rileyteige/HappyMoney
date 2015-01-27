define(['jquery'], function ($) {
    return function () {
        return $('body').data('identifier');
    };
});