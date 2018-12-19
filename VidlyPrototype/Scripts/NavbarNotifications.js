$(document).ready(function () {

    var polling = function () {
        $.ajax({
            url: "/api/notifications",
            method: "GET",
            success: function (data) {
                var notificationsCount = data.length == 0 ? "" : data.length;

                if (data.length == 0) {
                    $("#user-informer").html("<div class='d-flex flex-column'><div class='mx-auto'><i class='fas fa-info-circle text-info fa-3x'></i></div><div><p class='h6 text-center py-2'>There are no notifications</p></div></div>");
                }

                $(".badge-the-notifier").text(notificationsCount);

                var notificationsHolder = styleHolder = "";

                data.forEach(function (value, key) {
                    var date = Date.parse(value['dateReceived']);
                    date = new Date(date).toLocaleString("tr-TR");

                    if (value['hasBeenRead'] == false)
                        styleHolder = "style='background: #b7def8;'";

                    notificationsHolder += "<div class='rounded p-2 mb-2 notifications-display'" + styleHolder + "><h6 class='pb-0'><a href='/Notifications/Index'>".concat(value['message'], "</a></h6><small>Sent on ", date, "</small>", "<div class='dropdown-divider'></div>", "</div>");

                });

                $(".user-informer-card").html(notificationsHolder);
            },
            error: function (x) {
                console.log(x.status);
            }
        });
    }

    //set inteval for polling
    setInterval(polling, 1000);

    $("#user-informer a").css({ "text-decoration": "none" });

    $(".mark-as-read").on('click', function (e) {
        e.preventDefault();

        $.ajax({
            url: "/api/notifications",
            method: "PUT",
            success: function (data) {
                console.log('success');
                $(".notifications-display").css({ "background": "" });
            },
            error: function (x) {
                console.log(x.status);
            }

        });
    });
});