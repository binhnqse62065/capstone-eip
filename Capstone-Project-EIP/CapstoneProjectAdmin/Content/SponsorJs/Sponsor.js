$(document).ready(function () {
    var urlApi = $(location).attr('origin');

    $(document).on('click', '#btn-save', function () {
        var id = $('#btn-save').val();
        var name = $('.sponsor-title').val();
        var description = $('.sponsor-description').val();
        var imageUrl = $('.sponsor-img').val();
        $.ajax({
            url: urlApi + '/api/sponsor/UpdateSponsorData',
            method: "POST",
            data: {
                collectionItemId: id,
                collectionItemName: name,
                collectionItemDescription: description,
                collectionItemImageUrl: imageUrl,
            },
            success: function (data) {
                $('#tblSponsor').DataTable().ajax.reload();
                swal("Thành công!", "Bạn đã sửa thông tin nhà tài trợ thành công", "success");
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
        $.ajax({
            url: urlApi + '/api/sponsor/AddSponsor',
            method: "POST",
            data: {
                Name: name,
                Description: description,
                ImageUrl: imageUrl,
            },
            success: function (data) {
                $('#tblSponsor').DataTable().ajax.reload();
                swal("Thành công!", "Bạn đã thêm nhà tài trợ thành công", "success");
            },
            error: function (data) {
                console.log(data);
            }
        });

    });
});


function delSponsor(id, name) {
    swal({
        title: "Bạn có chắc?",
        text: "Bạn có chắc chắn xóa nhà tài trợ " + name + ", bạn sẽ không thể phục hồi!",
        type: "warning",
        showCancelButton: true,
        confirmButtonClass: "btn-danger",
        confirmButtonText: "Có!",
        cancelButtonText: "Không!",
        closeOnConfirm: false
    },
        function () {
            $.ajax({
                url: urlApi + '/api/sponsor/DeleteSponsor',
                method: "POST",
                data: {
                    CollectionItemID: id,
                },
                success: function (data) {
                    $('#tblSponsor').DataTable().ajax.reload();
                    swal("Thành công!", "Bạn đã xóa nhà tài trợ thành công", "success");
                },
                error: function (data) {
                    console.log(data);
                }
            });
        });
}