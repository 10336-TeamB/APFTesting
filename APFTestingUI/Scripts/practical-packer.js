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