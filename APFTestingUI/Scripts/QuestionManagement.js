$(function () {
    hideDeleteIfTwoAnswers();

    $('#delete').click(function () {
        return confirm("Are you sure you want to delete?");
    });

    $(".delete-answer").click(function () {

        if (confirm("Are you sure you want to delete?")) {
            $(this).parent().remove();
            hideDeleteIfTwoAnswers();
            reIndexAnswers();
        }

    });

    
})

function hideDeleteIfTwoAnswers() {
    if ($(".delete-answer").size() <= 2) {
        $(".delete-answer").hide();
    }
}

function reIndexAnswers() {
    //console.log($(".delete-answer").parent().children("input"))
    $('#answers-table > tbody > tr').each(
        function (i) {
            var newHiddenName = $(this).children('input').attr('name').replace(/[0-9]{1,}/, i);
            $(this).children('input').attr('name', newHiddenName);

            var newHiddenId = $(this).children('input').attr('id').replace(/[0-9]{1,}/, i);
            $(this).children('input').attr('id', newHiddenId);
            


            $(this).find('td > input').each(function () {
                var newName = $(this).attr('name').replace(/[0-9]{1,}/, i);
                $(this).attr('name', newName);
                //alert($(this).attr('name'));

                if ($(this).attr('id')) {
                    var newId = $(this).attr('id').replace(/[0-9]{1,}/, i);
                    $(this).attr('id', newId);
                    //alert($(this).attr('id'));
                }
                
            });
        }
    );
}