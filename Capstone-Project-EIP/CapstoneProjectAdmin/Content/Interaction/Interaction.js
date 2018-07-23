$(document).ready(function () {

    var urlApi = $(location).attr('origin');

    $('#btn-update-interaction').on('click', function () {
        var id = $('#btn-update-interaction').val();
        var name = $('.interaction-name').val();
        var selectValue = $('#InteractionEditSelectBox').find(":selected").val();
        var kindInteractionId = $('#KindOfInteractionEditSelectBox').find(":selected").val();

        var interactionObject = {
            interactionId: id,
            interactionName: name,
        };
        if (selectValue == 1) {
            interactionObject.votingId = kindInteractionId
            interactionObject.qaId = null
        } else if (selectValue == 2) {
            interactionObject.qaId = kindInteractionId
            interactionObject.votingId = null

        }

        $.ajax({
            url: urlApi + '/api/interaction/UpdateInteractionData',
            method: "POST",
            data: interactionObject,
            success: function () {
                swal("Thành công!", "Cập nhật tương tác thành công", "success");
                $('#tblInteraction').DataTable().ajax.reload();
            },
            error: function (data) {
                console.log(data);
            }
        });
    });

    $('#btn-add-interaction').on('click', function () {

        var sessionId = $('#session-id').val();
        var name = $('#newName').val();
        var selectValue = $('#InteractionSelectBox').find(":selected").val();
        var kindInteractionId = $('#KindOfInteractionSelectBox').find(":selected").val();
        if (selectValue == 1) {
            $.ajax({
                url: urlApi + '/api/interaction/AddInteraction',
                method: "POST",
                data: {
                    InteractionName: name,
                    VotingId: kindInteractionId,
                    SessionId: sessionId,
                    IsRunning: false
                },
                success: function (data) {
                    $('#tblInteraction').DataTable().ajax.reload();
                    swal("Thành công!", "Thêm mới tương tác thành công", "success");
                },
                error: function (data) {
                    console.log(data);
                }
            });
        } else if (selectValue == 2) {
            $.ajax({
                url: urlApi + '/api/interaction/AddInteraction',
                method: "POST",
                data: {
                    InteractionName: name,
                    QAId: kindInteractionId,
                    SessionId: sessionId,
                    IsRunning: false
                },
                success: function (data) {
                    $('#tblInteraction').DataTable().ajax.reload();
                    swal("Thành công!", "Thêm mới tương tác thành công", "success");
                },
                error: function (data) {
                    console.log(data);
                }
            });
        }


    });

    $('#btn-del').on('click', function () {
        swal({
            title: "Are you sure?",
            text: "You will not be able to recover this imaginary file!",
            type: "warning",
            showCancelButton: true,
            confirmButtonClass: "btn-danger",
            confirmButtonText: "Yes, delete it!",
            cancelButtonText: "No, cancel plx!",
            closeOnConfirm: false
        }, function () {
            var id = $('#btn-del').val();
            $.ajax({
                url: urlApi + '/api/interaction/DeleteInteraction',
                method: "POST",
                data: {
                    InteractionId: id,
                },
                success: function (data) {
                    $('#tblInteraction').DataTable().ajax.reload();
                },
                error: function (data) {
                    console.log(data);
                }
            });

        });

    });

    $('#btn-stop').on('click', function () {
        var id = $('#btn-stop').val();
        $.ajax({
            url: urlApi + '/api/interaction/StopInteraction',
            method: "POST",
            data: {
                InteractionId: id,
            },
            success: function (data) {
                $('#tblInteraction').DataTable().ajax.reload();
                $('#tblInteractionRunning').DataTable().ajax.reload();
            },
            error: function (data) {
                console.log(data);
            }
        });
    });

});




