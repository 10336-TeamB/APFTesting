$(function () {

    //remove default html datepicker
    $('input[type="date"]').prop('type', 'text');
    clearDates();

    $('form input[type="reset"]').on('click', function (e) {
        e.preventDefault();
        $(this).closest('form').get(0).reset();
        clearDates();
    })

    $("#DateOfBirth").datepicker(
        {
            changeMonth: true,
            changeYear: true,
            dateFormat: "dd/mm/yy",
            defaultDate: "-30y",
            yearRange: "-86y:-17y" // Age range of pilot 18-85. 1 year buffer added either side
        }
    );
    $("#PilotMedicalExpiry").datepicker(
        {
            changeMonth: true,
            changeYear: true,
            dateFormat: "dd/mm/yy",
            minDate: 0,
            maxDate: "+4y +3m" // Maximum expiry of Pilot Medical Licence is 4 years. 3 months added for buffer.
        }
    );

});

function clearDates() {
    if ($("#DateOfBirth").val() == "1/01/0001") {
        $("#DateOfBirth").val("");
    }
    if ($("#PilotMedicalExpiry").val() == "1/01/0001") {
        $("#PilotMedicalExpiry").val("");
    }
}


//Overload validation for UK date
//http://stackoverflow.com/questions/12053022/mvc-datetime-validation-uk-date-format/14081487#14081487
jQuery(function ($) {
    $.validator.addMethod('date',
    function (value, element) {
        if (this.optional(element)) {
            return true;
        }

        var ok = true;
        try {
            $.datepicker.parseDate('dd/mm/yy', value);
        }
        catch (err) {
            ok = false;
        }
        return ok;
    });
});
