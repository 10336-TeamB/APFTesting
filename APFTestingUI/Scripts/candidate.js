$(function () {
    if ($("#DateOfBirth").val() == "1/01/0001")
    {
        $("#DateOfBirth").val("");
    }
    if ($("#PilotMedicalExpiry").val() == "1/01/0001") {
        $("#PilotMedicalExpiry").val("");
    }

    $("#DateOfBirth").datepicker(
        {
            changeMonth: true,
            changeYear: true,
            dateFormat: "dd/mm/yy",
            defaultDate: "-18y",
            yearRange: "-90y:-5y"
        }
    );
    $("#PilotMedicalExpiry").datepicker(
        {
            changeMonth: true,
            changeYear: true,
            dateFormat: "dd/mm/yy",
            minDate: 0
        }
    );
});