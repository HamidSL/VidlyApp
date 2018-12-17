$(document).ready(function () {

    $.ajax({
        url: "/api/notifications",
        method: "GET",
        success: function (data) {
            if (data.length == 0) {
                $("#user-informer").html("<div class='d-flex flex-column'><div class='mx-auto'><i class='fas fa-info-circle text-info fa-3x'></i></div><div><p class='h6 text-center py-2'>There are no notifications</p></div></div>");
            }
            $(".badge-the-notifier").text(data.length);

            data.forEach(function (value, key) {
                var date = Date.parse(value['dateReceived']);
                date = new Date(date).toLocaleString("tr-TR");

                $(".user-informer-card").append("<div><h6 class='pb-0'><a href='/Notifications/Index'>".concat(value['message'], "</a></h6><small>Sent on ", date, "</small>", "<div class='dropdown-divider'></div>", "</div>"));
                
            });
        }, 
        error: function (x) {
            console.log(x.status);
        }
    });
    $("#user-informer a").css({ "text-decoration": "none" });
});