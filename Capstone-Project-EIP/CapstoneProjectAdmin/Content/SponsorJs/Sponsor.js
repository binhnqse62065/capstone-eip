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
                swal("Thành công!", "Bạn đã thêm thông tin nhà tài trợ thành công", "success");
            },
            error: function (data) {
                console.log(data);
            }
        });

    });

    $(document).on('click', '#btn-del', function () {
        //swal({
        //    title: "Are you sure?",
        //    text: "All voting option will be delete with this voting",
        //    type: "warning",
        //    showCancelButton: true,
        //    confirmButtonClass: "btn-danger",
        //    confirmButtonText: "Yes, delete it!",
        //    cancelButtonText: "No, cancel plx!",
        //    closeOnConfirm: false
        //},
        //    function () {
        var id = $('#btn-del').val();
        $.ajax({
            url: urlApi + '/api/sponsor/DeleteSponsor',
            method: "POST",
            data: {
                CollectionItemID: id,
            },
            success: function (data) {
                $('#tblSponsor').DataTable().ajax.reload();
                swal("Thành công!", "Bạn đã xóa thông tin nhà tài trợ thành công", "success");
            },
            error: function (data) {
                console.log(data);
            }
        });
        //});

    });

});