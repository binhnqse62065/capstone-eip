$(document).ready(function () {
    var urlApi = $(location).attr('origin');

    $('#btn-save').on('click', function () {
        var id = $('#btn-save').val();
        var name = $('.speaker-title').val();
        var description = $('.speaker-description').val();
        var imageUrl = $('.speaker-image').val();
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
            url: urlApi + '/api/speaker/AddSpeaker',
            method: "POST",
            data: {
                Name: name,
                Description: description,
                ImageUrl: imageUrl,
            },
            success: function (data) {
                $('#tblSpeaker').DataTable().ajax.reload();
            },
            error: function (data) {
                console.log(data);
            }
        });
    });

    $('#btn-del').on('click', function () {
        var id = $('#btn-del').val();
        $.ajax({
            url: urlApi + '/api/speaker/DeleteSpeaker',
            method: "POST",
            data: {
                CollectionItemID: id,
            },
            success: function (data) {
                $('#tblSpeaker').DataTable().ajax.reload();
            },
            error: function (data) {
                console.log(data);
            }
        });
    });

});