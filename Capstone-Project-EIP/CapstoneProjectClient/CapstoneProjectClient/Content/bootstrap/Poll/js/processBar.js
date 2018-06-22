//function move(p) {
//    console.log(p[2]);
//    var i = 1;
//    while (i <= p.length) {
//        var classId = "myBar" + i;
//        var demo = "demo" + i;
//        var elem = document.getElementById(classId);
//        var width = 0;
//        (function Run(classId, demo, elem, width) {
//            return new Promise(resolve => {
//                var interval = setInterval(() => {
//                    if (width >= p[i]) {
//                        clearInterval(interval);
//                    } else {
//                        width++;
//                        elem.style.width = width + '%';
//                        document.getElementById(demo).innerHTML = width + '%';
//                    }
//                }, 10);
//            });
//        })(classId, demo, elem, width);
//        i++;
//    }
//}

//$(document).ready(function () {
//    $('.progress .progress-bar').progressbar({ display_text: 'center', percent_format: function (p) { return p + '%'; } });
//    $('#thanks').css('display', 'none');
//    $('#btn-vote').on('click', function () {
//        var select = $('input[name=group-poll]:checked').val();



//        $('#btn-vote').css('display', 'none');
//        $('#thanks').css('display', 'show')
//        $('#thanks').text("Thank you for your voting!");
//    });
//});


$(document).ready(function () {
    $('.progress .progress-bar').progressbar({ display_text: 'center', percent_format: function (p) { return p + '%'; } });
    $('#thanks').css('display', 'none');
    $('#result').css('display', 'none');
    $('#btn-vote').on('click', function () {
        var select = $('input[name=group-poll]:checked').val();
        $.ajax({
            url: 'api/voting/ChangeNumberOfVoting',
            method: "POST",
            data: {
                votingOptionId: select,
                //votingQuestionId: $('#votingQuestionId').val()
            },
            success: function () {
                $('#result').load(' #result', function () {
                    $('.progress .progress-bar').progressbar({ display_text: 'center', percent_format: function (p) { return p + '%'; } });
                    $('#result').css('display', 'show')

                });
            },
            error: function (data) {
                console.log(data);
            }
        });
        $('#btn-vote').css('display', 'none');
        $('#thanks').css('display', 'show')
        $('#thanks').text("Thank you for your voting!");
    });
});