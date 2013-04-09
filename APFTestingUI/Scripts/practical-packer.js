$(function(){
    $('input[type=date]').attr("type", "text");
    $("#Date").datepicker(
        {
            dateFormat: "dd/mm/yy"
        }
    );

    if ($('#HarnessContainerType :selected').val() != 'Other')
    {
        $('#HarnessContainerTypeOther').attr('disabled', 'true').val('');
    }

    $('#HarnessContainerType').change(function () {
        if ($('#HarnessContainerType :selected').val() != 'Other')
        {
            $('#HarnessContainerTypeOther').attr('disabled', 'true').val('');
        }
        else
        {
            $('#HarnessContainerTypeOther').removeAttr('disabled');
        }
    });
    
    if ($('#CanopyType :selected').val() != 'Other') {
        $('#CanopyTypeOther').attr('disabled', 'true').val('');
    }

    $('#CanopyType').change(function () {
        if ($('#CanopyType :selected').val() != 'Other') {
            $('#CanopyTypeOther').attr('disabled', 'true').val('');
        }
        else
        {
            $('#CanopyTypeOther').removeAttr('disabled');
        }
    });


});



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