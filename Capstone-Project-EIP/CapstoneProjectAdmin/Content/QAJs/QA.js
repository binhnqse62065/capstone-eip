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

    $('#btn-add').on('click', function () {
        var name = $('#newName').val();
        console.log(name);
        $.ajax({
            url: 'api/QA/AddQA',
            method: "POST",
            data: {
                QAName: name,
                EventId: 1,
            },
            success: function (data) {
                console.log('Success');
                $('#tblQA').DataTable().ajax.reload();
            },
            error: function (data) {
                console.log(data);
            }
        });
    });

    $('#btn-del').on('click', function () {
        var id = $('#btn-del').val();
        $.ajax({
            url: 'api/QA/DeleteQA',
            method: "POST",
            data: {
                QAId: id,
            },
            success: function (data) {
                $('#tblQA').DataTable().ajax.reload();
            },
            error: function (data) {
                console.log(data);
            }
        });
    });


});