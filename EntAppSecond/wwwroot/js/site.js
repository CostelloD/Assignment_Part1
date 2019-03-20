// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your Javascript code.

//Script to calculate cost on Client Side and Convert days to int value

function Calculate() {

    var noOfDays = 0;
    var total = 0;
    var primes = [3, 5, 7, 11, 13];
    var days = 1;


    for (var i = 0; i < document.getElementById("SelectedDays").options.length; i++) {
        if (document.getElementById("SelectedDays").options[i].selected) {
            noOfDays++;
            days = days * primes[i];
        }
    }

    document.getElementById("numberofdays").innerHTML = noOfDays.toString();
    document.getElementById("primedays").value = days;


    if (document.getElementById("fulltime").checked) {
        total = noOfDays * 35;
    } else {
        total = noOfDays * 20;
    }

    if (noOfDays > 3) {
        total = total * 0.9;
    }

    document.getElementById("price").innerHTML = total.toString();
}

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

