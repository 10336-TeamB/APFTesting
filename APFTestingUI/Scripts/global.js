$(function() {
    $("#reset").click(function() {
        $.ajax({
            url: '/api/reset',
            type: 'POST',
            dataType: 'json',
            contentType: 'application/json',
            success: function (data) {
                alert("Exam status reset");
                location.reload();
            },
            error: function() {
                alert("ERROR: Exam status not reset");
            }
        });
    });
});