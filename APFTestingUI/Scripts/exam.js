$(function () {
    $('#PreviousButton').click(function () {
        $('#NavDirection').val("PreviousQuestion");
        $('#QuestionForm').submit();
    });

    $('#SummaryButton').click(function () {
        $('#NavDirection').val("DisplaySummary");
        $('#QuestionForm').submit();
    });
});

$(function () {
    var progress = $("#progress-bar-inner span").text() * 100;
    $("#progress-bar-inner").css("width", progress + "%");
});