$(document).ready(function () {
    var urlApi = $(location).attr('origin');

    $('#btn-save').on('click', function () {
        var id = $('#btn-save').val();
        var name = $('.file-title').val();
        var description = $('.file-description').val();
        var imageUrl = $('.file-image').val();
        $.ajax({
            url: urlApi + '/api/file/UpdateFileData',
            method: "POST",
            data: {
                collectionItemId: id,
                collectionItemName: name,
                collectionItemDescription: description,
                collectionItemImageUrl: imageUrl,
            },
            success: function () {
                $('#tblFile').DataTable().ajax.reload();
            },
            error: function (data) {
                console.log(data);
            }
        });
    });

    $('#btn-add').on('click', function () {
        var name = $('#newName').val();
        var description = $('#newDescription').val();
        var imageUrl = $('#newImageUrl').val();
        if ($('#newName').val().trim().length == 0) {
            $('#file-name-error').css('display', 'block');
            $('#btn-add').attr('data-dismiss', null);
        } else {
            $('#file-name-error').css('display', 'none');
            $('#btn-add').attr('data-dismiss', 'modal');
            $.ajax({
                url: urlApi + '/api/file/AddFile',
                method: "POST",
                data: {
                    Name: name,
                    Description: description,
                    ImageUrl: imageUrl,
                },
                success: function (data) {
                    $('#tblFile').DataTable().ajax.reload();
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
            url: urlApi + '/api/file/DeleteFile',
            method: "POST",
            data: {
                CollectionItemID: id,
            },
            success: function (data) {
                $('#tblFile').DataTable().ajax.reload();
            },
            error: function (data) {
                console.log(data);
            }
        });
    });

});