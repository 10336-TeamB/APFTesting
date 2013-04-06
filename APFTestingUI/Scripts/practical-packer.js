$(function(){
    $('input[type=date]').attr("type", "text");
    $("#Date").datepicker(
        {
            dateFormat: "dd/mm/yy"
        }
    );

    if ($('#HarnessContainerType :selected').val() != 'Other')
    {
        $('#HarnessContainerTypeOther').attr('disabled', 'true');
    }

    $('#HarnessContainerType').change(function () {
        if ($('#HarnessContainerType :selected').val() != 'Other')
        {
            $('#HarnessContainerTypeOther').attr('disabled', 'true');
        }
        else
        {
            $('#HarnessContainerTypeOther').removeAttr('disabled');
        }
    });
    
    if ($('#CanopyType :selected').val() != 'Other') {
        $('#CanopyTypeOther').attr('disabled', 'true');
    }

    $('#CanopyType').change(function () {
        if ($('#CanopyType :selected').val() != 'Other') {
            $('#CanopyTypeOther').attr('disabled', 'true');
        }
        else
        {
            $('#CanopyTypeOther').removeAttr('disabled');
        }
    });

});