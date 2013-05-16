$(function () {
    $(".toggle").click(function () {
        $(this).children("ul").slideToggle(100);
    });
});