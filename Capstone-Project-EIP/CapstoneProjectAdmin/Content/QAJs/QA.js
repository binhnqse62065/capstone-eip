$(document).ready(function () {

    var urlApi = $(location).attr('origin');


    $('#btn-del-question').on('click', function () {
        var id = $('#btn-del-question').val();
        $.ajax({
            url: urlApi + '/api/QA/DeleteQuestion',
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
            url: urlApi + '/api/QA/DeleteComment',
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

    $('#btn-add').on('click', function (e) {
        var name = $('#newName').val();
        if ($('#newName').val().length == 0) {
            $('#emptyWarning').css('display', 'block');
            $('#btn-add').attr('data-dismiss',null);
        } else {
            $('#btn-add').attr('data-dismiss', 'modal');
            $('#emptyWarning').css('display', 'none');
            console.log(name);
            $.ajax({
                url: urlApi + '/api/QA/AddQA',
                method: "POST",
                data: {
                    QAName: name,
                    EventId: 1,
                },
                success: function (data) {
                    console.log('Success');
                    $('#tblQA').DataTable().ajax.reload();
                    swal("Thành công!", "Thêm hỏi đáp thành công", "success");
                },
                error: function (data) {
                    console.log(data);
                }
            });
        }
    });

    $('#btn-del').on('click', function () {
        var id = $('#btn-del').val();
        $.ajax({
            url: urlApi + '/api/QA/DeleteQA',
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