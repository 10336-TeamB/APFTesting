$(function() {
    $("#logoff").hide();

    $("#login-name").click(function() {
        $("#logoff").slideToggle();
    });

    $("#logoff").click(function () {
        $("#logout-form").submit();
    });
});