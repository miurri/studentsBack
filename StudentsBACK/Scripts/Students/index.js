$('#get_students').click(function () {
    alert('Чекай консоль');

    $.ajax({
        url: 'students/getstudents',
        type: 'POST',
        success: function (res) {
            console.log(res);
        },
        error: function (e) {
            console.log(e);
        }
    });
});

$('#changestudent').click(function () {
    alert('Чекай консоль');

    $.ajax({
        url: 'students/changestudent',
        data: 
        {
            PersonID: 1,
            Name: 'Даниил',
            PhotoUrl: 'localhostDOTcom'
        },
        type: 'POST',
        success: function (res) {
            console.log(res);
        },
        error: function (e) {
            console.log(e);
        }
    });
});