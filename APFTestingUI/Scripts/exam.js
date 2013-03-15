$(function () {
    $('#PreviousButton').click(function () {
        $('#NavDirection').val("PreviousQuestion");
        answerQuestion();
    });

    $("#NextButton").click(function (e) {
        e.preventDefault();
        $('#NavDirection').val("NextQuestion");
        answerQuestion();
    });

    $('#SummaryButton').click(function () {
        $('#NavDirection').val("DisplaySummary");
        $('#QuestionForm').submit();
    });

    $(document).ajaxStart(function () {
        $("#ExamContainer").hide();
        $("#loading").show();
    }).ajaxStop(function () {
        $("#loading").hide();
        $("#ExamContainer").show();
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
    var index = data["Index"] + 1;
    var navDirection = data["NavDirection"];
    var isMarkedForReview = data["IsMarkedForReview"];
    var answers = data["Answers"];
    var examProgress = data["ExamProgress"] * 100;
    var description = data["Description"];
    var isFirstQuestion = data["IsFirstQuestion"];
    var isLastQuestion = data["IsLastQuestion"];
    var numOfCorrectAnswers = data["NumberOfCorrectAnswers"];

    var type = numOfCorrectAnswers == 1 ? "radio" : "checkbox";
    var className = numOfCorrectAnswers == 1 ? "answer-radiobutton" : "answer-checkbox";

    $("#progress-bar-inner").animate({"width": examProgress + "%"}, 100);
    document.title = "Question " + index;
    $("#question-title").text("Question " + index);
    $("#question-description").text(description);
    $("ExamId").val(examId);
    $("Index").val(index);
    $("NavDirection").val(navDirection);
    
    clearAnswers();
    populateAnswers(answers, type, className);

    if (isFirstQuestion) {
        $('#PreviousButton').hide();
    }
    else {
        $('#PreviousButton').show();
    }

    if (isLastQuestion) {
        $('#NextButton').hide();
        $('#SummaryButton').show();
    }
    else {
        $('#NextButton').show();
        $('#SummaryButton').hide();
    }
}

function clearAnswers() {
    $("fieldset").html("");
};

function populateAnswers(answers, type, className) {
    $(answers).each(function (i) {
        var inputValues = {
            id: "ChosenAnswer-" + i,
            'class': className,
            name: "ChosenAnswer",
            value: i
        }

        var input = $('<input type="' + type + '" />').attr(inputValues);
        if (this.IsChecked) {
            input.attr({ checked: "checked" });
        }

        var labelValues = {
            'for': "ChosenAnswer-" + i,
            'class': "answer-description"
        }

        var label = $('<label />').text(this.Description).attr(labelValues);

        $('fieldset').append('<div class="answer-container" id="answer-container-' + i + '" />');
        $('#answer-container-' + i).append(input);
        $('#answer-container-' + i).append(label);
    });
}

