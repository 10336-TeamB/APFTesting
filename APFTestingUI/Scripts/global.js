//$(function () {
//    var headerHeight = $('#header').height();
//    var menuHeight = $('#menu').height();
//    var footerHeight = $('#footer').height();
//    var contentPadding = parseInt($('#content .size-wrapper').css('padding-top')) + parseInt($('#content .size-wrapper').css('padding-bottom'));
//    var totalHeight = headerHeight + menuHeight + footerHeight + contentPadding;
//    var screenHeight = $(document).height();
//    if (totalHeight < screenHeight)
//        $('#content .size-wrapper').height(screenHeight - totalHeight);
//});

$(function() {
    $("#reset").click(function() {
        $.ajax({
            url: '/api/reset',
            type: 'POST',
            dataType: 'json',
            contentType: 'application/json',
            success: function (data) {
                alert("Exam status reset");
            },
            error: function() {
                alert("ERROR: Exam status not reset");
            }
        });
    });
});