$('#btn-save').on('click', function () {
    var id = $('#btn-save').val();
    var name = $('.home-title').val();
    var description = $('.home-description').val();
    var imageUrl = $('.home-image').val();
    var codeLogin = $('.home-code-login').val();
    var address = $('.home-address').val();
    var template = $('.home-template').val();
    var startTime = $('#startEndTime').val().split("-")[0].trim();
    var endTime = $('#startEndTime').val().split("-")[1].trim();
    $.ajax({
        url: 'api/home/EditHome',
        method: "POST",
        data: {
            EventID: id,
            Name: name,
            EventDescription: description,
            ImageURL: imageUrl,
            Address: address,
            TemplateId: template,
            CodeLogin: codeLogin,
            StartTime: startTime,
            EndTime: endTime
        },
        success: function (data) {
            console.log(data.data.Code);
            $('.home-page-title').html(data.data.Name);
            $('.home-page-description').html(data.data.Description);
            $('.home-page-image').attr('src', data.data.Image);
            $('.home-page-code-login').html(data.data.Code);
            $('.home-page-address').html(data.data.Address);
            $('.home-page-template').html(data.data.Template);
            $('.home-page-start-time').html(data.data.StartTime);
            $('.home-page-end-time').html(data.data.EndTime);
        },
        error: function (data) {
            console.log(data);
        }
    });
});


