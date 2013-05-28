$(function() {
    $("#logoff").hide();

    $("#login-name").click(function() {
        $("#logoff").slideToggle();
    });

    $("#button-logoff").click(function () {
        $("#logout-form").submit();
    });
});