$(document).ready(function () {
    var headerHeight = $('#header').height();
    var menuHeight = $('#menu').height();
    var footerHeight = $('#footer').height();
    var contentPadding = parseInt($('#content .size-wrapper').css('padding-top')) + parseInt($('#content .size-wrapper').css('padding-bottom'));
    var totalHeight = headerHeight + menuHeight + footerHeight + contentPadding;
    var screenHeight = $(document).height();
    if(totalHeight < screenHeight)
        $('#content .size-wrapper').height(screenHeight - totalHeight);
});

$(function () {
    $('#PreviousButton').click(function () {
        $('#NavDirection').val("true");
        $('#QuestionForm').submit();
    });
});

