$(function() {
    $(".exam-format-delete").click(function() {
        if (confirm("DELETE - Are you sure?")) {
            return true;
        }
        return false;
    });

    $(".exam-format-activate").click(function() {
        if (confirm("Are you sure you wish to activate this format?")) {
            return true;
        }
        return false;
    });
});