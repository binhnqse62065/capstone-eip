$(document).ready(function () {
    $('#btn-submit').on('click', function () {
        var name = $('#guestName').val();
        var phone = $('#guestPhone').val();
        var email = $('#guestEmail').val();
        $.ajax({
            url:'api/landingPage/AddGuest',
            method: "POST",
            data: {
                GuestName: name,
                GuestPhone: phone,
                GuestEmail: email,
                EventId: 1,
            },
            success: function (data) {
                console.log('Add success');
            },
            error: function (data) {
                console.log(data);
            }
        });
    });
});