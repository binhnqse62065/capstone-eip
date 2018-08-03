$(document).ready(function () {
    var urlApi = $(location).attr('origin');

    $(document).on('click', '#btn-save', function () {
        var id = $('#btn-save').val();
        var name = $('.speaker-title').val();
        var description = $('.speaker-description').val();
        var imageUrl = $('.speaker-img').val();
        $.ajax({
            url: urlApi + '/api/speaker/UpdateSpeakerData',
            method: "POST",
            data: {
                collectionItemId: id,
                collectionItemName: name,
                collectionItemDescription: description,
                collectionItemImageUrl: imageUrl,
            },
            success: function () {
                $('#tblSpeaker').DataTable().ajax.reload();
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
        var imageUrl = $('#thumbnail-container').val();
        if ($('#newName').val().trim().length == 0) {
            $('#speaker-name-error').css('display', 'block');
            $('#btn-add').attr('data-dismiss', null);
        } else {
            $('#speaker-name-error').css('display', 'none');
            $('#btn-add').attr('data-dismiss', 'modal');
            $.ajax({
                url: urlApi + '/api/speaker/AddSpeaker',
                method: "POST",
                data: {
                    Name: name,
                    Description: description,
                    ImageUrl: imageUrl,
                },
                success: function (data) {
                    $('#tblSpeaker').DataTable().ajax.reload();
                    swal("Thành công!", "Bạn đã thêm diễn giả thành công", "success");
                },
                error: function (data) {
                    console.log(data);
                }
            });
        }

    });
});

function delSpeaker(id, name) {
    swal({
        title: "Bạn có chắc?",
        text: "Bạn có chắc chắn xóa diễn giả " + name + ", bạn sẽ không thể phục hồi!",
        type: "warning",
        showCancelButton: true,
        confirmButtonClass: "btn-danger",
        confirmButtonText: "Có!",
        cancelButtonText: "Không!",
        closeOnConfirm: false
    }, function () {
        $.ajax({
            url: urlApi + '/api/speaker/DeleteSpeaker',
            method: "POST",
            data: {
                CollectionItemID: id,
            },
            success: function (data) {
                $('#tblSpeaker').DataTable().ajax.reload();
                swal("Thành công!", "Bạn đã xóa diễn giả thành công", "success");
            },
            error: function (data) {
                console.log(data);
            }
        });
    });
}

