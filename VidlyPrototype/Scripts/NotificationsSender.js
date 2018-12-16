$(document).ready(function () {

    $.ajax({
        url: "/api/notifications",
        method: "POST",
        success: function (data) {
            console.log("Success");
        },
        error: function (x) {
            console.log(x.status);
        }
    });
});