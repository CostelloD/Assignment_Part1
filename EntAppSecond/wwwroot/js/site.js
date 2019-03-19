// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your Javascript code.




// The validation check for the application date

jQuery.validator.addMethod("StartDate",
    function (value, element, param) {
        var now = new Date(); // gets date and time.
        now = new Date(now.setHours(0, 0, 0, 0)) // sets time to 00:00
        var enteredDate = Date.parse(value)
        return (enteredDate > now); // 
    });
// Registering the validation check.

jQuery.validator.unobtrusive.adapters.addBool("StartDate");


// The validation check for date of birth

jQuery.validator.addMethod("BirthDate",
    function (value, element, param) {

        var start = new Date(new Date().setFullYear(new Date().getFullYear() - 5));
        start = Date.parse(start);
        var end = new Date(new Date().setFullYear(new Date().getFullYear() - 2));
        end = Date.parse(end);
        var dateEntered = Date.parse(value)
        if (dateEntered > start && dateEntered < end) {
            return (true)
        }
    });

jQuery.validator.unobtrusive.adapters.addBool("BirthDate");

