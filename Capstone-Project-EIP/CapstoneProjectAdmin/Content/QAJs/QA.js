$(document).ready(function () {

    $('#btn-del-question').on('click', function () {
        var id = $('#btn-del-question').val();
        $.ajax({
            url: 'api/QA/DeleteQuestion',
            method: "POST",
            data: {
                QuestionId: id,
            },
            success: function (data) {
                $('#question-' + id).remove();
            },
            error: function (data) {
                console.log(data);
            }
        });
    });

    $('#btn-del-comment').on('click', function () {
        console.log('Click ok');
        var id = $('#btn-del-comment').val();
        $.ajax({
            url: 'api/QA/DeleteComment',
            method: "POST",
            data: {
                CommentId: id,
            },
            success: function (data) {
                $('#comment-' + id).remove();
            },
            error: function (data) {
                console.log(data);
            }
        });
    });

});