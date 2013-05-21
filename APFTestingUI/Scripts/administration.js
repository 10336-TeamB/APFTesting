$(function() {
    $(".delete").click(function() {
        if (confirm("DELETE - Are you sure?")) {
            return true;
        }
        return false;
    });

    $(".activate").click(function() {
        if (confirm("Are you sure you wish to activate this item?")) {
            return true;
        }
        return false;
    });

    $(".toggle").click(function () {
        $(this).children("ul").slideToggle(100);
    });
});