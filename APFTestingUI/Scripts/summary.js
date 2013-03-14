$(function () {
    $("dd").hide();
    $("dt").not("a").click(function (event) {
        var $target = $(event.target);
        if (!$target.is("a")) {
            $(this).next().slideToggle(200);
        }
    });
});