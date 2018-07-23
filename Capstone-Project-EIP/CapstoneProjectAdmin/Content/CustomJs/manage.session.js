var urlApi = $(location).attr('origin') + '/';
$(document).ready(function () {

    $('#AddStartEndTime').daterangepicker({
        locale: {
            format: 'DD/MM/YYYY'
        }
    });
});


/*Function*/

    /*Shared*/
$('#cb-session-id').on('change', function () {
    if (this.value != 0) {
        InitActivityDatatable(this.value);
        InitTimelineDatatable(this.value);
        InitInteractionDatatable(this.value);
        $('#session-id').val(this.value);
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
                name: "name",
                render: function (data, type, row) {
                    return row.name;
                }
            },
            {
                name: "startTime - End Time",
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
                name: "Session Name",
                render: function (data, type, row) {
                    return row.sessionName;
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
        $('#KindOfInteractionEditSelectBox').append("<option>---Choose---</option>");
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
        $('#KindOfInteractionSelectBox').append("<option>---Choose---</option>");
    }
});

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

function playInteraction(interactionId, sessionId) {

    $.ajax({
        url: urlApi + '/api/interaction/PlayInteraction',
        method: "POST",
        data: {
            InteractionId: interactionId,
            SessionId: sessionId,
        },
        success: function (data) {
            ReloadInteractionDatatable();
            ReloadInteractionRunningDatatable();
            swal("Thành công!", "Tiến hành chạy tương tác thành công", "success");
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
        title: "Bạn có chắc không?",
        text: "Bạn muốn xóa tương tác này!",
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
    var time = $('#AddStartEndTime').val();

    var timeSplit = time.split('-');
    var startTime = timeSplit[0].trim().split("/").reverse().join("-");
    var endTime = timeSplit[1].trim().split("/").reverse().join("-");


    $.ajax({
        url: urlApi + 'api/activity/AddActivity',
        method: 'POST',
        data: {
            SessionId: $('#session-id').val(),
            Name: $('#addName').val(),
            Description: $('#addDescription').val(),
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
});

//Update activity
$('#btn-update-activity').on('click', function () {
    $.ajax({
        url: urlApi + 'api/activity/UpdateActivity',
        method: "POST",
        data: {
            ActivityID: $('#txtActivityId').val(),
            Name: $('#activityName').val(),
            Description: $('#activityDescription').val()
        },
        success: function (data) {
            ReloadActivityDatatable();
            swal("Thành công", "Cập nhật thông tin hoạt động thành công", "success");
        },
        error: function (data) {
            console.log(data);
        }
    });
});

function openModelUpdate(id, name, startTime, endTime, description) {
    $('#activityName').val(name);
    $('#activityDescription').val(description);
    $('#startEndTime').val(startTime + " - " + endTime);
    $('#txtActivityId').val(id);
    $('#startEndTime').daterangepicker({
        locale: {
            format: 'DD/MM/YYYY'
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
                url: urlApi + 'api/activity/DeleteActivity',
                method: "POST",
                data: {
                    ActivityID: id,

                },
                success: function (data) {
                    ReloadActivityDatatable();
                    swal("Deleted!", "Your activity has been deleted successfully", "success");
                },
                error: function (data) {
                    console.log(data);
                    swal("Error", "Some error occur", "error");
                }
            });
        });
}

function ReloadActivityDatatable() {
    $('#tblActivity').DataTable().ajax.reload();
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






