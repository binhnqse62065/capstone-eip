$(document).ready(function () {

    var urlApi = $(location).attr('origin');


    $('#btn-save').on('click', function () {
        var id = $('#btn-save').val();
        var name = $('.sponsor-title').val();
        console.log(name);
        var description = $('.sponsor-description').val();
        var imageUrl = $('.sponsor-image').val();
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
                swal("Success!", "Sponsor has been updated successfully", "success");
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
                swal("Success!", "Your sponsor has been added successfully", "success");
            },
            error: function (data) {
                console.log(data);
            }
        });

    });

    $('#btn-del').on('click', function () {
        swal({
            title: "Are you sure?",
            text: "All voting option will be delete with this voting",
            type: "warning",
            showCancelButton: true,
            confirmButtonClass: "btn-danger",
            confirmButtonText: "Yes, delete it!",
            cancelButtonText: "No, cancel plx!",
            closeOnConfirm: false
        },
            function () {
                var id = $('#btn-del').val();
                $.ajax({
                    url: urlApi + '/api/sponsor/DeleteSponsor',
                    method: "POST",
                    data: {
                        CollectionItemID: id,
                    },
                    success: function (data) {
                        $('#tblSponsor').DataTable().ajax.reload();
                    },
                    error: function (data) {
                        console.log(data);
                    }
                });
            });
        
    });

});