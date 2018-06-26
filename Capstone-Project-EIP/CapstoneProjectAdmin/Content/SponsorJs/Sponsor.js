$(document).ready(function () {
    $('#btn-save').on('click', function () {
        var id = $('#btn-save').val();
        var name = $('.sponsor-title').val();
        var description = $('.sponsor-description').val();
        var imageUrl = $('.sponsor-image').val();
        console.log($('.sponsor-title').val());
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
                $('#sponsor-image-' + id).attr('src', data.data.sponsorImage);

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
                Alert('Success');
            },
            error: function (data) {
                console.log(data);
            }
        });

    });

        $('#btn-del').on('click', function () {
        var id = $('#btn-save').val();
        $.ajax({
            url: 'api/sponsor/DeleteSponsor',
            method: "POST",
            data: {
                CollectionItemID: id,
            },
            success: function (data) {
                Alert('Success');
            },
            error: function (data) {
                console.log(data);
            }
        });
    });

});