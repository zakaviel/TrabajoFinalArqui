$(function () {
    var $

        = $('#cart');
    $('#clickme').click(function (e) {
        e.stopPropagation();
        if ($cart.is(":hidden")) {
            $cart.slideDown("slow");
        } else {
            $cart.slideUp("slow");
        }
    });
    $(document.body).click(function () {
        if ($cart.not(":hidden")) {
            $cart.slideUp("slow");
        }
    });
});