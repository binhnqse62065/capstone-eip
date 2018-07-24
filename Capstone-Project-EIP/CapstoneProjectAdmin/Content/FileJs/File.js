$(document).ready(function () {
    var urlApi = $(location).attr('origin');

    $(document).on('click', '#btn-save', function () {
        var id = $('#btn-save').val();
        var name = $('.file-title').val();
        var description = $('.file-description').val();
        var fileUrl = $('.file-url').val();
        $.ajax({
            url: urlApi + '/api/file/UpdateFileData',
            method: "POST",
            data: {
                collectionItemId: id,
                collectionItemName: name,
                collectionItemDescription: description,
                collectionItemImageUrl: fileUrl,
            },
            success: function () {
                $('#tblFile').DataTable().ajax.reload();
                swal("Thành công!", "Bạn đã sửa thông tin diễn giả thành công", "success");
            },
            error: function (data) {
                console.log(data);
            }
        });
    });

    $(document).on('click', '#btn-add', function () {
        var name = $('#newName').val();
        var description = $('#newDescription').val();
        var fileUrl = $('#thumbnail-container').val();
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
                    ImageUrl: fileUrl,
                },
                success: function (data) {
                    $('#tblFile').DataTable().ajax.reload();
                    swal("Thành công!", "Bạn đã thêm thông tin diễn giả thành công", "success");
                },
                error: function (data) {
                    console.log(data);
                }
            });
        }

    });

    $(document).on('click', '#btn-del', function () {
        var id = $('#btn-del').val();
        $.ajax({
            url: urlApi + '/api/file/DeleteFile',
            method: "POST",
            data: {
                CollectionItemID: id,
            },
            success: function (data) {
                $('#tblFile').DataTable().ajax.reload();
                swal("Thành công!", "Bạn đã xóa thông tin diễn giả thành công", "success");
            },
            error: function (data) {
                console.log(data);
            }
        });
    });

});