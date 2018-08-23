var urlApi = $(location).attr('origin') + '/';


/*Function*/

/*Shared*/
$('#cb-session-id').on('change', function () {
    if (this.value != 0) {
        InitActivityDatatable(this.value);
        InitTimelineDatatable(this.value);
        InitInteractionDatatable(this.value);
        $('#session-id').val(this.value);
        setDateRangeActivity(this.value);
    }

});

function InitActivityDatatable(sessionId) {
    $('#tblActivity').DataTable({
        "bDestroy": true,
        "oLanguage": {
            "sSearch": "Tìm kiếm",
            "oPaginate": {
                "sFirst": "Trang đầu",
                "sLast": "Trang cuối",
                "sNext": "Trang kế",
                "sPrevious": "Trang trước"
            },
            "sInfoEmpty": "",
            "sInfo": "Hiển thị từ dòng _START_ tới _END_ trong tổng số _TOTAL_ dòng",
            "sZeroRecords": "Không có dữ liệu",
            "sLengthMenu": "Hiển thị _MENU_ dòng"
        },
        ajax: {
            url: urlApi + "api/activity/GetAllActivityBySessionId/" + sessionId,
            dataSrc: ""
        },
        columns: [
            {
                name: "Name",
                render: function (data, type, row) {
                    return row.name;
                }
            },
            {
                name: "StartTime - End Time",
                render: function (data, type, row) {
                    return row.startTime + " - " + row.endTime;
                }
            },
            {
                name: "Description",
                render: function (data, type, row) {
                    return row.description;
                }
            },
            {
                name: "Speaker Name",
                render: function (data, type, row) {
                    var speakerName = '';

                    for (var i = 0; i < row.speakerName.length; i++) {
                        if (i == 0) {
                            speakerName += row.speakerName[i];
                        } else {
                            speakerName += ', ';
                            speakerName += row.speakerName[i];
                        }
                    }
                    return speakerName;
                }
            },
            {
                name: "Function",
                render: function (data, type, row) {
                    return '<button class="btn btn-primary btn-sm" data-toggle="modal" data-target="#modalUpdateActivity" onclick="openModelUpdate(' + row.activityID + ',\'' + row.name + '\', \'' + row.startTime + '\', \'' + row.endTime + '\', \'' + row.description + '\')"><i class="fa fa-pencil"></i></button>     ' +
                        '<button class="btn btn-danger btn-sm btn-delete" onclick="deleteActivity(' + row.activityID + ')" id="btn-delete"><i class="fa fa-trash"></i></button>';
                }
            }
        ]
    });
}


function InitTimelineDatatable(sessionId) {
    $('#tblTimeline').DataTable({
        "bDestroy": true,
        "oLanguage": {
            "sSearch": "Tìm kiếm",
            "oPaginate": {
                "sFirst": "Trang đầu",
                "sLast": "Trang cuối",
                "sNext": "Trang kế",
                "sPrevious": "Trang trước"
            },
            "sInfoEmpty": "",
            "sInfo": "Hiển thị từ dòng _START_ tới _END_ trong tổng số _TOTAL_ dòng",
            "sZeroRecords": "Không có dữ liệu",
            "sLengthMenu": "Hiển thị _MENU_ dòng"
        },
        ajax: {
            url: urlApi + 'api/timeline/GetAllTimelineBySessionId/' + sessionId,
            dataSrc: ""
        },
        columns: [
            {
                name: "Title",
                render: function (data, type, row) {
                    return row.timelineTitle;
                }
            },

            {
                name: "Detail",
                render: function (data, type, row) {
                    return row.timelineDetail;
                }
            },
            {
                name: "startTime",
                render: function (data, type, row) {
                    if (row.startTime.length > 0) {
                        //return row.startTime.split(' ')[1].split(':')[0] + ':' + row.startTime.split(' ')[1].split(':')[1];
                        return row.startTime;
                    }
                    else {
                        return row.startTime;
                    }
                }
            },
            {
                name: "Function",
                render: function (data, type, row) {
                    return '<button class="btn btn-primary btn-sm" data-toggle="modal" data-target="#modalUpdateTimeline" onclick="openModelUpdateTimeline(' + row.timelineId + ',\'' + row.timelineTitle + '\',\'' + row.timelineDetail + '\')"><i class="fa fa-pencil"></i></button>     ' +
                        '<button class="btn btn-danger btn-sm btn-delete" onclick="deleteTimeline(' + row.timelineId + ')" id="btn-delete"><i class="fa fa-trash"></i></button>';
                }
            }
        ]
    });
}

function InitInteractionDatatable(sessionId) {
    $('#tblInteraction').DataTable({
        ajax: {
            url: urlApi + "/api/interaction/getAllInteractionNotRunning/" + sessionId,
            dataSrc: ""
        },
        "bDestroy": true,
        "oLanguage": {
            "sSearch": "Tìm kiếm",
            "oPaginate": {
                "sFirst": "Trang đầu",
                "sLast": "Trang cuối",
                "sNext": "Trang kế",
                "sPrevious": "Trang trước"
            },
            "sInfoEmpty": "",
            "sInfo": "Hiển thị từ dòng _START_ tới _END_ trong tổng số _TOTAL_ dòng",
            "sZeroRecords": "Không có dữ liệu",
            "sLengthMenu": "Hiển thị _MENU_ dòng"
        },
        columns: [
            {
                name: "Name",
                render: function (data, type, row) {
                    return row.interactionName;
                }
            },
            {
                name: "NameOfInteraction",
                render: function (data, type, row) {
                    if (row.voting != null) {
                        return row.voting.name;
                    }
                    else {
                        return row.qa.name;
                    }

                }
            },
            {
                name: "Type",
                render: function (data, type, row) {
                    if (row.votingId != null) {
                        return '<p>Voting<p/>';
                    } else if (row.qaId != null) {
                        return '<p>QA<p/>';
                    }
                }
            },
            {
                name: "Function",
                render: function (data, type, row) {
                    return '<button class="btn btn-primary btn-sm" data-toggle="modal" data-target="#editInteractionModal" onclick="editInteractionModal(' + row.interactionId + ',\'' + row.interactionName + '\', \'' + row.votingId + '\', \'' + row.qaId + '\')"><i class="fa fa-pencil"></i></button>     ' +
                        '<button class="btn btn-danger btn-sm speaker-id" onclick="delInteraction(' + row.interactionId + ')"><i class="fa fa-trash"></i></button>       ' +
                        '<button class="btn btn-success btn-sm speaker-id" onclick="playInteraction(' + row.interactionId + ', ' + row.sessionId + ')"><i class="fa fa-play" aria-hidden="true"></i></button>';
                }
            }
        ]
    });


    $('#tblInteractionRunning').DataTable({
        ajax: {
            url: urlApi + "/api/interaction/getIsRunningInteraction/" + sessionId,
            dataSrc: ""
        },
        "bDestroy": true,
        "oLanguage": {
            "sSearch": "Tìm kiếm",
            "oPaginate": {
                "sFirst": "Trang đầu",
                "sLast": "Trang cuối",
                "sNext": "Trang kế",
                "sPrevious": "Trang trước"
            },
            "sInfoEmpty": "",
            "sInfo": "Hiển thị từ dòng _START_ tới _END_ trong tổng số _TOTAL_ dòng",
            "sZeroRecords": "Không có dữ liệu",
            "sLengthMenu": "Hiển thị _MENU_ dòng"
        },
        columns: [
            {
                name: "Name",
                render: function (data, type, row) {
                    return row.interactionName;
                }
            },
            {
                name: "Type",
                render: function (data, type, row) {
                    if (row.votingId != null) {
                        return '<p>Voting<p/>';
                    } else if (row.qaId != null) {
                        return '<p>QA<p/>';
                    }
                }
            },
            {
                name: "Function",
                render: function (data, type, row) {
                    return '<button class="btn btn-danger btn-sm" onclick="stopInteraction(' + row.interactionId + ')"><i class="fa fa-stop" aria-hidden="true"></i></button>';
                }
            }
        ]
    });
}

function clearErrorAddInteraction() {
    $('#errorNameAdd').css('display', 'none');
    $('#errorKindIdAdd').css('display', 'none');
}

function clearValueInputAddInteraction() {
    $('#newName').val("");
    $('#InteractionSelectBox').val(0);
    $('#KindOfInteractionSelectBox').val(0);
}

function clearErrorEditInteraction() {
    $('#errorNameEdit').css('display', 'none');
    $('#errorKindIdEdit').css('display', 'none');
}

function setDateRangeActivity(sessionId) {
    /*Gán giá trị cho daterangepicker dựa theo thời gian của session ở tab Activity*/
    $.ajax({
        url: urlApi + '/api/session/GetSessionById/' + sessionId,
        method: "GET",
        success: function (data) {

            var startTime = data.startTime;
            var endTime = data.endTime;
            $('#activityStartTime').val(startTime);
            $('#activityEndTime').val(endTime);
            $('#AddStartEndTime').daterangepicker({
                locale: {
                    format: 'DD/MM/YYYY HH:mm'
                },
                startDate: startTime,
                endDate: endTime,
                minDate: startTime,
                maxDate: endTime + '23:59',
                timePicker: true,
                timePicker24Hour: true
            });
        },
        error: function (data) {
            console.log(data);
        }
    });
}



/*Interaction*/


$('#InteractionEditSelectBox').on('click', function () {
    var SelectValue = $('#InteractionEditSelectBox').find(":selected").val();
    if (SelectValue == 1) {
        $('#KindOfInteractionEditSelectBox').empty();
        $('#KindOfInteractionEditSelectBox').append($('#cbVotingTemplate').clone().html());

    } else if (SelectValue == 2) {
        $('#KindOfInteractionEditSelectBox').empty();
        $('#KindOfInteractionEditSelectBox').append($('#cbQATemplate').clone().html());
    } else {
        $('#KindOfInteractionEditSelectBox').empty();
        $('#KindOfInteractionEditSelectBox').append('<option value="0">---Chọn---</option>');
    }
});

$('#InteractionSelectBox').on('click', function () {
    var SelectValue = $('#InteractionSelectBox').find(":selected").val();
    if (SelectValue == 1) {
        $('#KindOfInteractionSelectBox').empty();
        $('#KindOfInteractionSelectBox').append($('#cbVotingTemplate').clone().html());

    } else if (SelectValue == 2) {
        $('#KindOfInteractionSelectBox').empty();
        $('#KindOfInteractionSelectBox').append($('#cbQATemplate').clone().html());
    } else {
        $('#KindOfInteractionSelectBox').empty();
        $('#KindOfInteractionSelectBox').append("<option>---Chọn---</option>");
    }
});

$('#btn-update-interaction').on('click', function () {
    clearErrorEditInteraction();

    var id = $('#btn-update-interaction').val();
    var name = $('.interaction-name').val();
    var selectValue = $('#InteractionEditSelectBox').find(":selected").val();
    var kindInteractionId = parseInt($('#KindOfInteractionEditSelectBox').find(":selected").val());

    var isValid = true;
    if (name.length === 0) {
        isValid = false;
        $('#errorNameEdit').css('display', 'block');
        $('#btn-update-interaction').attr('data-dismiss', null);
    }
    if (kindInteractionId === 0) {
        isValid = false;
        $('#errorKindIdEdit').css('display', 'block');
        $('#btn-update-interaction').attr('data-dismiss', null);
    }
    if (isValid) {
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
        clearErrorEditInteraction();
        $('#btn-update-interaction').attr('data-dismiss', 'modal');
    }

});

$('#btn-add-interaction').on('click', function () {
    clearErrorAddInteraction();
    var sessionId = $('#session-id').val();
    var name = $('#newName').val();
    var selectValue = $('#InteractionSelectBox').find(":selected").val();
    var kindInteractionId = parseInt($('#KindOfInteractionSelectBox').find(":selected").val());
    var isValid = true;
    if (name.length === 0) {
        isValid = false;
        $('#errorNameAdd').css('display', 'block');
        $('#btn-add-interaction').attr('data-dismiss', null);
    }
    if (kindInteractionId === 0) {
        isValid = false;
        $('#errorKindIdAdd').css('display', 'block');
        $('#btn-add-interaction').attr('data-dismiss', null);
    }
    if (isValid) {
        clearErrorAddInteraction();
        clearValueInputAddInteraction();
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
                    if (data.success) {
                        $('#tblInteraction').DataTable().ajax.reload();
                        swal("Thành công!", "Thêm mới tương tác thành công", "success");
                    }
                    else {
                        swal("Thất bại!", "Đã có lỗi xảy ra", "warning");
                    }
                    
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
        $('#btn-add-interaction').attr('data-dismiss', 'modal');

    }



});

$('#btn-del').on('click', function () {
    swal({
        title: "Bạn có chắc?",
        text: "Bạn có chắc chắn, bạn sẽ không thể phục hồi lại!",
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

function playInteraction(interactionId, sessionId) {

    $.ajax({
        url: urlApi + '/api/interaction/PlayInteraction',
        method: "POST",
        data: {
            InteractionId: interactionId,
            SessionId: sessionId,
        },
        success: function (data) {
            if (data.success) {
                ReloadInteractionDatatable();
                ReloadInteractionRunningDatatable();
                swal("Thành công!", "Tiến hành chạy tương tác thành công", "success");
            }
            else {
                swal("Thất bại!", "Có lỗi xảy ra", "warning");
            }
        },
        error: function (data) {
            console.log(data);
        }
    });
}

function stopInteraction(interactionId) {
    $.ajax({
        url: urlApi + '/api/interaction/StopInteraction',
        method: "POST",
        data: {
            InteractionId: interactionId,
        },
        success: function (data) {
            ReloadInteractionDatatable();
            ReloadInteractionRunningDatatable();
            swal("Thành công!", "Tắt chạy tương tác thành công", "success");
        },
        error: function (data) {
            console.log(data);
        }
    });
}

function delInteraction(interactionId) {
    swal({
        title: "Bạn có chắc?",
        text: "Bạn có chắc chắn, bạn sẽ không thể phục hồi lại!",
        type: "warning",
        showCancelButton: true,
        confirmButtonClass: "btn-danger",
        confirmButtonText: "Có!",
        cancelButtonText: "Không!",
        closeOnConfirm: false
    }, function () {
        $.ajax({
            url: urlApi + '/api/interaction/DeleteInteraction',
            method: "POST",
            data: {
                InteractionId: interactionId,
            },
            success: function (data) {
                ReloadInteractionDatatable();
                swal("Thành công!", "Xóa tương tác thành công", "success");
            },
            error: function (data) {
                console.log(data);
            }
        });

    });
}

function InitQASelectBoxInModalUpdate() {
    $('#KindOfInteractionEditSelectBox').empty();
    $('#KindOfInteractionEditSelectBox').append($('#cbQATemplate').clone().html());
}

function InitVotingSelectBoxInModalUpdate() {
    $('#KindOfInteractionEditSelectBox').empty();
    $('#KindOfInteractionEditSelectBox').append($('#cbVotingTemplate').clone().html());
}

function editInteractionModal(id, name, votingId, qaId) {
    $('.interaction-name').val(name);
    if (votingId != 'null') {
        InitVotingSelectBoxInModalUpdate();
        $('#InteractionEditSelectBox').val(1);
        $('#KindOfInteractionEditSelectBox').val(votingId);
    }
    else if (qaId != 'null') {
        InitQASelectBoxInModalUpdate();
        $('#InteractionEditSelectBox').val(2);
        $('#KindOfInteractionEditSelectBox').val(qaId);
    }
    $('.interaction-id').val(id);

}

function ReloadInteractionDatatable() {
    $('#tblInteraction').DataTable().ajax.reload();
}

function ReloadInteractionRunningDatatable() {
    $('#tblInteractionRunning').DataTable().ajax.reload();
}

/* Activity */

//Add new activity
$('#addActivity').on('click', function () {
    clearErrorAddActivity();
    var collectionItemId = $('#speakerAddSelectBox').val();
    var name = $('#txtActivityNameAdd').val();
    var description = $('#txtActivityDesAdd').val();

    var isValid = true;
    if (name.length === 0) {
        $('#errorNameActivityAdd').css('display', 'block');
        isValid = false;
        $('#addActivity').attr('data-dismiss', null);
    }
    if (description.length === 0) {
        $('#errorDesActivityAdd').css('display', 'block');
        isValid = false;
        $('#addActivity').attr('data-dismiss', null);
    }

    if (isValid) {

        var time = $('#AddStartEndTime').val().trim();
        var timeSplit = time.split('-');
        var startTimeSplit = timeSplit[0].trim().split(" ");
        var endTimeSpit = timeSplit[1].trim().split(" ");

        var startTime = startTimeSplit[0].trim().split("/").reverse().join("-") + ' ' + startTimeSplit[1] /*+ ' ' + startTimeSplit[2]*/;
        var endTime = endTimeSpit[0].trim().split("/").reverse().join("-") + ' ' + endTimeSpit[1]/* + ' ' + endTimeSpit[2]*/;

        var activityId;
        if (collectionItemId != null) {
            $.ajax({
                url: urlApi + 'api/activity/AddActivity',
                method: 'POST',
                data: {
                    SessionId: $('#session-id').val(),
                    Name: name,
                    Description: description,
                    StartTime: startTime,
                    EndTime: endTime
                },
                success: function (data) {
                    activityId = data.data.ActivityID;
                    for (var i = 0; i < collectionItemId.length; i++) {
                        addActivityItem(activityId, collectionItemId[i]);
                    }
                    ReloadActivityDatatable();
                },
                error: function (data) {
                    console.log(data);
                }
            });
        } else {
            $.ajax({
                url: urlApi + 'api/activity/AddActivity',
                method: 'POST',
                data: {
                    SessionId: $('#session-id').val(),
                    Name: name,
                    Description: description,
                    StartTime: startTime,
                    EndTime: endTime
                },
                success: function (data) {
                    ReloadActivityDatatable();
                    swal("Thành công", "Thêm mới hoạt động thành công", "success");
                },
                error: function (data) {
                    console.log(data);
                }
            });
        }

        $('#addActivity').attr('data-dismiss', 'modal');
        clearErrorAddActivity();
        clearInputAddAvtivity();
    }

});

//Update activity
$('#btn-update-activity').on('click', function () {
    clearErrorEditActivity();
    var collectionItemId = $('#speakerUpdateSelectBox').val();
    var name = $('#activityName').val();
    var description = $('#activityDescription').val();

    var isValid = true;
    if (name.length === 0) {
        $('#errorNameActivityEdit').css('display', 'block');
        isValid = false;
        
    }
    if (description.length === 0) {
        $('#errorDesActivityEdit').css('display', 'block');
        isValid = false;
        
    }

    if (isValid) {
        var time = $('#startEndTime').val().trim();
        var timeSplit = time.split('-');
        var startTimeSplit = timeSplit[0].trim().split(" ");
        var endTimeSpit = timeSplit[1].trim().split(" ");

        var startTime = startTimeSplit[0].trim().split("/").reverse().join("-") + ' ' + startTimeSplit[1];
        var endTime = endTimeSpit[0].trim().split("/").reverse().join("-") + ' ' + endTimeSpit[1];

        if (collectionItemId != null) {
            $.ajax({
                url: urlApi + 'api/activity/UpdateActivity',
                method: "POST",
                data: {
                    ActivityID: $('#txtActivityId').val(),
                    Name: $('#activityName').val(),
                    Description: $('#activityDescription').val(),
                    StartTime: startTime,
                    EndTime: endTime
                },
                success: function (data) {
                    deleteActivityItem($('#txtActivityId').val());
                    for (var i = 0; i < collectionItemId.length; i++) {
                        addActivityItem($('#txtActivityId').val(), collectionItemId[i]);
                    }
                    ReloadActivityDatatable();
                    swal("Thành công", "Cập nhật thông tin hoạt động thành công", "success");
                },
                error: function (data) {
                    console.log(data);
                }
            });
        } else {
            $.ajax({
                url: urlApi + 'api/activity/UpdateActivity',
                method: "POST",
                data: {
                    ActivityID: $('#txtActivityId').val(),
                    Name: $('#activityName').val(),
                    Description: $('#activityDescription').val(),
                    StartTime: startTime,
                    EndTime: endTime
                },
                success: function (data) {
                    deleteActivityItem($('#txtActivityId').val());
                    ReloadActivityDatatable();
                    swal("Thành công", "Cập nhật thông tin hoạt động thành công", "success");
                },
                error: function (data) {
                    console.log(data);
                }
            });
        }
        $('#modalUpdateActivity').modal('hide');
    }

    

});

//function openModelUpdate(id, name, startTime, endTime, description) {
//    $('#activityName').val(name);
//    $('#activityDescription').val(description);
//    $('#startEndTime').val(startTime + " - " + endTime);
//    $('#txtActivityId').val(id);
//    $('#startEndTime').daterangepicker({
//        locale: {
//            format: 'DD/MM/YYYY'
//        }
//    });

//}

function deleteActivityItem(id) {
    $.ajax({
        url: urlApi + 'api/activity/DeleteActivityItem',
        method: 'POST',
        data: {
            ActivityId: id,
        },
        success: function (data) {
        },
        error: function (data) {
            console.log(activityId);
            console.log(data);
        }
    });
}

function deleteActivity(id) {
    swal({
        title: "Bạn có chắc?",
        text: "Bạn có chắc chắn, bạn sẽ không thể phục hồi lại!",
        type: "warning",
        showCancelButton: true,
        confirmButtonClass: "btn-danger",
        confirmButtonText: "Có!",
        cancelButtonText: "Không!",
        closeOnConfirm: false
    },
        function () {
            $.ajax({
                url: urlApi + 'api/activity/DeleteActivityItem',
                method: 'POST',
                data: {
                    ActivityId: id,
                },
                success: function (data) {
                    deleteActivityAfterDeleteActivityItem(id);
                },
                error: function (data) {
                    console.log(activityId);
                    console.log(data);
                }
            });
        });
}

function ReloadActivityDatatable() {
    $('#tblActivity').DataTable().ajax.reload();
}

function clearErrorAddActivity() {
    $('#errorNameActivityAdd').css('display', 'none');
    $('#errorDesActivityAdd').css('display', 'none');
}

function clearErrorEditActivity() {
    $('#errorNameActivityEdit').css('display', 'none');
    $('#errorDesActivityEdit').css('display', 'none');
}

function clearInputAddAvtivity() {
    $('#txtActivityNameAdd').val("");
    $('#txtActivityDesAdd').val("");
}

function addActivityItem(activityId, collectionItemId) {
    $.ajax({
        url: urlApi + 'api/activity/AddActivityItem',
        method: 'POST',
        data: {
            ActivityId: activityId,
            CollectionItemId: collectionItemId
        },
        success: function (data) {
            ReloadActivityDatatable();
            swal("Thành công", "Thêm mới hoạt động thành công", "success");
        },
        error: function (data) {
            console.log(activityId + ', ' + collectionItemId);
            console.log(data);
        }
    });
}

function deleteActivityAfterDeleteActivityItem(activityId) {
    $.ajax({
        url: urlApi + 'api/activity/DeleteActivity',
        method: "POST",
        data: {
            ActivityID: activityId,
        },
        success: function (data) {
            ReloadActivityDatatable();
            swal("Xóa Thành Công!", "Hoạt động đã được xóa thành công", "success");
        },
        error: function (data) {
            console.log(data);
            swal("Xóa không thành công", "Phát sinh lỗi", "error");
        }
    });
}

/* Timeline */
//Add new timeline
$('#addTimeline').on('click', function () {
    $('.div-title-error').css('display', 'none');
    $('.div-tldetail-error').css('display', 'none');
    var isValid = true;
    var title = $('#addTitle').val();
    if (title.trim().length == 0) {
        $('.div-title-error').css('display', 'block');
        $('#addTimeline').attr('data-dismiss', null);
        isValid = false;
    } if ($('#addTimelineDetail').val().trim().length == 0) {
        $('.div-tldetail-error').css('display', 'block');
        $('#addTimeline').attr('data-dismiss', null);
        isValid = false
    }
    if (isValid) {
        $('#addTimeline').attr('data-dismiss', 'modal');
        $('.div-title-error').attr('display', 'none');
        $('.div-tldetail-error').css('display', 'none');
        var dt = new Date($.now());
        var time = dt.getHours() + ":" + dt.getMinutes() + ":" + dt.getSeconds();
        $.ajax({
            url: urlApi + 'api/timeline/addTimeline',
            method: 'POST',
            data: {
                SessionId: $('#session-id').val(),
                TimelineTitle: $('#addTitle').val(),
                TimelineDetail: $('#addTimelineDetail').val(),
                StartTime: time,
            },
            success: function (data) {
                reloadTimelineDatatable();
                swal("Thành Công!", "Dòng thời gian đã được thêm thành công", "success");
            },
            error: function (data) {
                console.log(data);
            }
        });
        clearInputAddTimeLine();
    }

});

//Update timeline
$('#btn-update-timeline').on('click', function () {
    $.ajax({
        url: urlApi + 'api/timeline/UpdateTimeline',
        method: "POST",
        data: {
            TimelineId: $('#txtTimelineId').val(),
            TimelineTitle: $('#timelineTitle').val(),
            TimelineDetail: $('#editTimelineDetail').val()
        },
        success: function (data) {
            swal("Thành Công!", "Dòng thời gian đã được cập nhật thành công", "success");
            reloadTimelineDatatable();
        },
        error: function (data) {
            console.log(data);
        }
    });
});

function openModelUpdateTimeline(id, name, description) {
    $('#timelineTitle').val(name);
    $('#editTimelineDetail').val(description);
    $('#txtTimelineId').val(id);
}

function deleteTimeline(id) {
    swal({
        title: "Bạn có chắc không?",
        text: "Bạn sẽ không thể phục hồi lại!",
        type: "warning",
        showCancelButton: true,
        confirmButtonClass: "btn-danger",
        confirmButtonText: "Xóa!",
        cancelButtonText: "Không!",
        closeOnConfirm: false
    },
        function () {
            $.ajax({
                url: urlApi + 'api/timeline/DeleteTimeline',
                method: "POST",
                data: {
                    TimelineId: id,
                },
                success: function (data) {
                    reloadTimelineDatatable();
                    swal("Xóa Thành Công!", "Dòng thời gian đã được xóa thành công", "success");
                },
                error: function (data) {
                    console.log(data);
                    swal("Lỗi", "Có gì đó không đúng", "error");
                }
            });
        });
}

function reloadTimelineDatatable() {
    $('#tblTimeline').DataTable().ajax.reload();
}

function clearInputAddTimeLine() {
    $('#addTitle').val("");
    $('#addTimelineDetail').val("");
}






