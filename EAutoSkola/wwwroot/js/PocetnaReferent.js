
    $.fn.jQuerySimpleCounter = function (options) {
        var settings = $.extend({
        start: 0,
    end: 100,
    easing: 'swing',
    duration: 400,
    complete: ''
}, options);

var thisElement = $(this);

        $({count: settings.start }).animate({count: settings.end }, {
        duration: settings.duration,
    easing: settings.easing,
            step: function () {
                var mathCount = Math.ceil(this.count);
    thisElement.text(mathCount);
},
complete: settings.complete
});
};

var broj1 = document.getElementById("number1").innerHTML.valueOf();
var broj2 = document.getElementById("number2").innerHTML.valueOf();
var broj3 = document.getElementById("number3").innerHTML.valueOf();
var broj4 = document.getElementById("number4").innerHTML.valueOf();

    $('#number1').jQuerySimpleCounter({end: broj1, duration: 1000 });
$('#number2').jQuerySimpleCounter({ end: broj2, duration: 1000 });
$('#number3').jQuerySimpleCounter({ end: broj3, duration: 1000 });
$('#number4').jQuerySimpleCounter({ end: broj4, duration: 1000 });
