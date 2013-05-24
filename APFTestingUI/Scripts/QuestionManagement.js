$(function () {

    //Determine whether to show delete options or not
    showOrHideDeleteBasedOnAnswerCount();

    //Add new answer
    $("#add-answer").click(function () {

        addAnswer();
        showOrHideDeleteBasedOnAnswerCount();

    });

    //Delete specified answer
    $(".delete-answer").click(function () {

        deleteAnswer(this);

    });

})



//new
function deleteAnswer(elementToDelete) {
    
    if (confirm("Confirm answer deletion.")) {
        $(elementToDelete).parent().remove();
        reIndexAnswers();
    }
    showOrHideDeleteBasedOnAnswerCount();

}



//new
function showOrHideDeleteBasedOnAnswerCount() {

    if ($("#answers-table > tbody > tr").length <= 2) {
        $(".delete-answer").hide();
    }
    else {
        $(".delete-answer").show();
    }

}



//new
function addAnswer() {

    var answer =
        [
            '<tr>',
                '<td>',
                    '<input class="check-box" data-val="true" data-val-required="The IsCorrect field is required." id="Answers_#__IsCorrect" name="Answers[#].IsCorrect" type="checkbox" value="true" />',
                    '<input name="Answers[#].IsCorrect" type="hidden" value="false" />',
                '</td>',
                    
                '<td>',
                    '<input class="text-box single-line" type="text" data-val-required="The Description field is required." id="Answers_#__Description" name="Answers[#].Description" />',
                '</td>',

                '<td class="delete-answer"><span>delete</span></td>',
            '</tr>'
        ].join("\n");

    var index = $("#answers-table > tbody > tr").length;

    answer = answer.replace(/#/g, index);

    $("#answers-table > tbody").append(answer);

    //Apply deletion click event to new answer
    $("#answers-table > tbody > tr:last > td[class='delete-answer']").click(function () {

        deleteAnswer(this);

    });

}



//New
function reIndexAnswers() {

    $("#answers-table > tbody > tr").each(function (i) {

        $(this).find("td").each(function () {

            $(this).children().each(function () {

                if ($(this).is("[name]")) {
                    var newName = $(this).attr("name").replace(/[0-9]+/g, i);
                    $(this).attr("name", newName);
                }

                if ($(this).is("[id]")) {
                    var newId = $(this).attr("id").replace(/[0-9]+/g, i);
                    $(this).attr("id", newId);
                }

            });

        });

    });

}




