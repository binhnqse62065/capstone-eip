
$(document).ready(function () {
    var urlApi = $(location).attr('origin');
    $('.progress .progress-bar').progressbar({ display_text: 'center', percent_format: function (p) { return p + '%'; } });
    $('#btn-vote').on('click', function () {
        var select = $('input[name=group-poll]:checked').val();
        $.ajax({
            url: urlApi + '/api/voting/ChangeNumberOfVoting',
            method: "POST",
            data: {
                VotingOptionId: select,
                VotingId: $('#txt-voting-id').val()
            },
            success: function (data) {
                console.log(data.data);
                $('#result').load(' #result', function () {
                    $('#btn-vote').css('display', 'none');
                    $('#thanks').css('display', 'show');
                    $('#thanks').text("Cảm ơn vì đã bình chọn!");
                    $('.result').css('display', 'block');

                    var resultTemplate = $('#progress-bar-result-template').clone();
                    for (var i = 0; i < data.data.length; i++) {
                        resultTemplate.find('.progress-bar').attr('data-transitiongoal', data.data[i]);
                        $('#result-voting-section').append(resultTemplate.html());
                    }

                    $('.progress .progress-bar').progressbar({ display_text: 'center', percent_format: function (p) { return p + '%'; } });
                });
            },
            error: function (data) {
                console.log(data);
            }
        });

    });
});