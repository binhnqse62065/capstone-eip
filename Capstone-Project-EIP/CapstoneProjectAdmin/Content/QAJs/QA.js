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
        var eventId = $('#txtEventId').val();
        if ($('#newName').val().length == 0) {
            $('#emptyWarning').css('display', 'block');
            $('#btn-add').attr('data-dismiss',null);
        } else {
            $('#btn-add').attr('data-dismiss', 'modal');
            $('#emptyWarning').css('display', 'none');
            $.ajax({
                url: urlApi + '/api/QA/AddQA',
                method: "POST",
                data: {
                    QAName: name,
                    EventId: eventId,
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
            clearInputAddQa();
        }
    });

    /*Edit name Qa*/
    $('#btnEdit').on('click', function (e) {
        var name = $('#editName').val();
        var qaId = $('#btnEdit').val();

        if ($('#editName').val().length == 0) {
            $('#emptyWarningEdit').css('display', 'block');
            $('#btnEdit').attr('data-dismiss', null);
        } else {
            $('#btnEdit').attr('data-dismiss', 'modal');
            $('#emptyWarningEdit').css('display', 'none');
            $.ajax({
                url: urlApi + '/api/QA/UpdateQA',
                method: "POST",
                data: {
                    QAId: qaId,
                    QAName: name,
                },
                success: function (data) {
                    console.log('Success');
                    $('#tblQA').DataTable().ajax.reload();
                    swal("Thành công!", "Sửa hỏi đáp thành công", "success");
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

    function clearInputAddQa() {
        $('#newName').val("");
    }
});