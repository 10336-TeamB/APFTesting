$(function() {
    $('#previous-button').click(function(e) {
        e.preventDefault();
        $('#NavDirection').val("PreviousQuestion");
        answerQuestion(true);
    });

    $("#next-button").click(function(e) {
        e.preventDefault();
        $('#NavDirection').val("NextQuestion");
        answerQuestion(true);
    });

    $(document).ajaxStart(function() {
        $("#exam-container").hide();
        $("#loading").show();
    }).ajaxStop(function() {
        $("#loading").hide();
        $("#exam-container").show();
    }).ajaxError(function(event, jqxhr, settings, exception) {
        $("#error-message").html("<p>" + jqxhr.responseText + "</p>");
        showErrorMessage("#error-message");
    });

    // Add state to first exam page loaded for successful back button navigation to first page
    function overwriteInitialHistoryEntry() {
        if (window.history.replaceState) {
            var currentIndex = parseInt($("#Index").val()) + 1;
            var initialTitle = "Question_" + currentIndex;
            window.history.replaceState({ questionId: currentIndex }, document.title, "/Exam/" + initialTitle);
        }
    }
    overwriteInitialHistoryEntry();

    // Hook in to the browser back and forward buttons
    $(window).on('popstate', function (e) {
        if (e.originalEvent.state) {
            var currentIndex = parseInt($("#Index").val()) + 1;
            var poppedIndex = e.originalEvent.state.questionId;
            if (currentIndex > poppedIndex) {
                $('#NavDirection').val("PreviousQuestion");
                answerQuestion(false);
            } else if (currentIndex < poppedIndex) {
                $('#NavDirection').val("NextQuestion");
                answerQuestion(false);
            }
        }
    });
    
    /*                         */
    /* Exam Void functionality */
    /*                         */
    $("#question-examiner-button").click(function () {
        $("#question-void-button").slideToggle(300);
    });

    $("#question-void-button").click(function (e) {
        e.preventDefault();
        //$("#void-popup").toggle();
        showLightBox("#void-authentication");
    });

    $("#void-cancel").click(function () {
        //$("#void-popup").toggle();
        parent.$.fn.colorbox.close();
    });
});

function showLightBox(id) {
    $.colorbox({ width: "450px", height: "250px", inline: "true", href: id })
}

function showErrorMessage(id) {
    $.colorbox({ inline: "true", href: id, className:"error" })
}

$(function () {
    var progress = $("#progress-bar-inner span").text() * 100;
    $("#progress-bar-inner").css("width", progress + "%");
});

function answerQuestion(changeHistory) {
    var examId = $("#ExamId").val();
    var index = $("#Index").val();
    var navDirection = $("#NavDirection").val();
    var isMarkedForReview = $("#is-marked-for-review").is(":checked");
    var answers = [];
    $('input[name="ChosenAnswer"]:checked').each(function () {
        answers.push(this.value);
    });

    var question = {
        ExamId: examId,
        Index: index,
        NavDirection: navDirection,
        IsMarkedForReview: isMarkedForReview,
        ChosenAnswer: answers
    };

    $.ajax({
        url: '/api/questions',
        type: 'POST',
        data: JSON.stringify(question),
        dataType: 'json',
        contentType: 'application/json',
        success: function (data) {
            renderQuestion(data);
            
            // Prevents history from being updated when browser back and forward buttons pressed
            if (changeHistory) {
                updateHistory();
            }
        }
    });
}

function renderQuestion(data) {
    clearAnswers();

    // Data extracted from ajax received data
    var examId = data["ExamId"];
    var index = parseInt(data["Index"]);
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
    document.title = "Question " + (index + 1);
    $("#question-title").text("Question " + (index + 1));
    $("#question-description").text(description);
    $("#ExamId").val(examId);
    $("#Index").val(index);
    if (isMarkedForReview) {
        $("#is-marked-for-review").prop('checked', true);
    }
        
    populateAnswers(answers, type, className);

    if (isFirstQuestion) {
        $('#previous-button').hide();
    }
    else {
        $('#previous-button').show();
    }

    if (isLastQuestion) {
        $('#next-button').hide();
        $('#summary-button').show();
    }
    else {
        $('#next-button').show();
        $('#summary-button').hide();
    }
}

function clearAnswers() {
    $("fieldset").html("");
    $("#is-marked-for-review").removeAttr("checked");
    $("#error-message").html("");
};

function populateAnswers(answers, type, className) {
    $(answers).each(function (i) {
        var inputValues = {
            id: "ChosenAnswer-" + i,
            'class': className,
            name: "ChosenAnswer",
            value: i
        };

        var input = $('<input type="' + type + '" />').attr(inputValues);
        if (this.IsChecked) {
            input.attr({ checked: "checked" });
        }

        var labelValues = {
            'for': "ChosenAnswer-" + i,
            'class': "answer-description label-" + type
        };

        var label = $('<label />').text(this.Description).attr(labelValues);

        $('fieldset').append('<div class="answer-container" id="answer-container-' + i + '" />');
        $('#answer-container-' + i).append(input);
        $('#answer-container-' + i).append(label);
    });
}

function updateHistory() {
    if (window.history.pushState) {
        var currentIndex = parseInt($("#Index").val()) + 1;
        var historyTitle = "Question_" + currentIndex;
        window.history.pushState({ questionId: currentIndex }, document.title, "/Exam/" + historyTitle);
    }
}

