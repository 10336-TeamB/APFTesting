$(function () {
    $("#question-examiner-button").click(function () {
        $("#question-void-button").slideToggle(300);
    });

    $("#question-void-button").click(function (e) {
        e.preventDefault();
        showLightBox("#void-authentication");
    });

    $("#void-cancel").click(function () {
        parent.$.fn.colorbox.close();
    });
})

$(function () {
    $("dd").hide();
    $("dt").not("a").click(function (event) {
        var $target = $(event.target);
        if (!$target.is("a")) {
            $(this).next().slideToggle(200);
        }
    });
});
