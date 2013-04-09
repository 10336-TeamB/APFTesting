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