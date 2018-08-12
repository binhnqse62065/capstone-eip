//$(document).ready(function () {
//    $('#btn-submit').on('click', function () {
//        var name = $('#guestName').val();
//        var phone = $('#guestPhone').val();
//        var email = $('#guestEmail').val();
//        $.ajax({
//            url:'api/landingPage/AddGuest',
//            method: "POST",
//            data: {
//                GuestName: name,
//                GuestPhone: phone,
//                GuestEmail: email,
//                EventId: 1,
//            },
//            success: function (data) {
//                console.log('Add success');
//            },
//            error: function (data) {
//                console.log(data);
//            }
//        });
//    });
//});

function validateEmail(email) {
    var re = /^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
    return re.test(email);
}

function phonenumber(inputtxt) {
    var phoneno = /^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$/;
    if (phoneno.test(inputtxt)) {
        return true;
    }
    else {   
        return false;
    }
}