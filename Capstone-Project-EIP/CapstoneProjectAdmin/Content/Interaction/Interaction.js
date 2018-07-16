﻿$(document).ready(function () {

    var urlApi = $(location).attr('origin');

    $('#btn-save').on('click', function () {
        var id = $('#btn-save').val();
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
        console.log(interactionObject);
        $.ajax({
            url: urlApi + '/api/interaction/UpdateInteractionData',
            method: "POST",
            data: interactionObject,
            success: function () {
                var index = $('#tab-index').val();
                $('#tblInteraction' + index).DataTable().ajax.reload();
            },
            error: function (data) {
                console.log(data);
            }
        });
    });

    $('#btn-add').on('click', function () {
        console.log(urlApi);
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
                    var index = $('#tab-index').val();
                    $('#tblInteraction' + index).DataTable().ajax.reload();
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
                    var index = $('#tab-index').val();
                    $('#tblInteraction' + index).DataTable().ajax.reload();
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
            url: urlApi + '/api/interaction/DeleteInteraction',
            method: "POST",
            data: {
                InteractionId: id,
            },
            success: function (data) {
                var index = $('#tab-index').val();
                $('#tblInteraction' + index).DataTable().ajax.reload();
            },
            error: function (data) {
                console.log(data);
            }
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
                var index = $('#tab-index').val();
                $('#tblInteraction' + index).DataTable().ajax.reload();
                $('#tblInteractionRunning' + index).DataTable().ajax.reload();
            },
            error: function (data) {
                console.log(data);
            }
        });
    });

    $('#btn-play').on('click', function () {
        var id = $('#btn-play').val();
        var sessionId = $('#session-id').val();
        $.ajax({
            url: urlApi + '/api/interaction/PlayInteraction',
            method: "POST",
            data: {
                InteractionId: id,
                SessionId: sessionId,
            },
            success: function (data) {
                var index = $('#tab-index').val();
                $('#tblInteraction' + index).DataTable().ajax.reload();
                $('#tblInteractionRunning' + index).DataTable().ajax.reload();
            },
            error: function (data) {
                console.log(data);
            }
        });
    });

});