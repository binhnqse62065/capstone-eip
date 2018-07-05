
$(document).ready(function () {
    $('.progress .progress-bar').progressbar({ display_text: 'center', percent_format: function (p) { return p + '%'; } });
    $('#btn-vote').on('click', function () {
        var select = $('input[name=group-poll]:checked').val();
        $.ajax({
            url: 'api/voting/ChangeNumberOfVoting',
            method: "POST",
            data: {
                votingOptionId: select,
            },
            success: function () {
                $('#result').load(' #result', function () {
                    $('#btn-vote').css('display', 'none');
                    $('#thanks').css('display', 'show');
                    $('#thanks').text("Thank you for your voting!");
                    $('.result').css('display', 'block');
                    $('.progress .progress-bar').progressbar({ display_text: 'center', percent_format: function (p) { return p + '%'; } });
                });
            },
            error: function (data) {
                console.log(data);
            }
        });

    });
});