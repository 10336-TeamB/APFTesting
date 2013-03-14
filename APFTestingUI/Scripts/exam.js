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

var question = {
     Description: 'This is our ajax question description', Index: 1
}

function answerQuestion() {
    var examId = $("#ExamId").val();
    var index = $("#Index").val();
    var navDirection = $("#NavDirection").val();
    var isMarkedForReview = $("#IsMarkedForReview").is(":checked");
    var answers = [];
    $("[name=ChosenAnswer][checked]").each(function () {
        answers.push(this.value);
    });

    var question = {
        ExamId: examId,
        Index: index,
        NavDirection: navDirection,
        IsMarkedForReview: isMarkedForReview,
        ChosenAnswer: answers
    }

    $.ajax({
        url: '/api/questions',
        type: 'POST',
        data: JSON.stringify(question),
        dataType: 'json',
        contentType: 'application/json',
        success: function (data) {
            renderQuestion(data);
        }
    });
}

function renderQuestion(data) {
    var examId = data["ExamId"];
    var index = data["Index"];
    var navDirection = data["NavDirection"];
    var isMarkedForReview = data["IsMarkedForReview"];
    var chosenAnswer = data["ChosenAnswer"];

    $("#ExamId").val(examId + "TESTING");
    $("#Index").val(index + "TESTING");
    $("#NavDirection").val(navDirection + "TESTING");
}