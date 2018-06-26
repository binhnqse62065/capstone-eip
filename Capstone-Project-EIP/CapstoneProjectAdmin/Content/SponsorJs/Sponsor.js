$(document).ready(function () {
    $('#btn-save').on('click', function () {
        var id = $('#btn-save').val();
        var name = $('.sponsor-title').val();
        console.log(name);
        var description = $('.sponsor-description').val();
        var imageUrl = $('.sponsor-image').val();
        $.ajax({
            url: 'api/sponsor/UpdateSponsorData',
            method: "POST",
            data: {
                collectionItemId: id,
                collectionItemName: name,
                collectionItemDescription: description,
                collectionItemImageUrl: imageUrl,
            },
            success: function (data) {
                $('#tblSponsor').DataTable().ajax.reload();
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
            url: 'api/sponsor/AddSponsor',
            method: "POST",
            data: {
                Name: name,
                Description: description,
                ImageUrl: imageUrl,
            },
            success: function (data) {
                $('#tblSponsor').DataTable().ajax.reload();
            },
            error: function (data) {
                console.log(data);
            }
        });

    });

        $('#btn-del').on('click', function () {
            var id = $('#btn-del').val();
        $.ajax({
            url: 'api/sponsor/DeleteSponsor',
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